"""Bounded one-pass scanners for evidenced Pokiguard managed-object fingerprints."""

from __future__ import annotations

from dataclasses import dataclass
import struct
from typing import Callable, Iterable, Mapping

from .il2cpp_external import ExternalReadError, MemoryReader, MemoryRegion
from .il2cpp_layout import (
    CombatBatchSnapshot,
    DotSnapshot,
    LayoutValidationError,
    read_combat_batch,
    read_dot,
)


MEM_PRIVATE = 0x20000
WRITABLE_PAGE_TYPES = frozenset({0x04, 0x08, 0x40, 0x80})


ProgressCallback = Callable[[int, int], None]


@dataclass(frozen=True)
class QwordScanResult:
    matches: Mapping[str, tuple[int, ...]]
    regions_visited: int
    bytes_read: int
    failed_chunks: int


def bounded_private_writable_regions(
    regions: Iterable[MemoryRegion],
    *,
    max_region_size: int = 8 * 1024 * 1024,
) -> tuple[MemoryRegion, ...]:
    """Select the evidenced managed-heap fallback scan envelope.

    This is intentionally not a whole-RAM pointer scan.  Protection/type are
    revalidated by ``VirtualQueryEx`` before this pure filter is called.
    """

    if max_region_size < 4096:
        raise ValueError("max_region_size must be at least one page")
    return tuple(
        region
        for region in regions
        if region.memory_type == MEM_PRIVATE
        and (region.protection & 0xFF) in WRITABLE_PAGE_TYPES
        and 0 < region.size <= max_region_size
    )


def regions_containing_addresses(
    regions: Iterable[MemoryRegion], addresses: Iterable[int]
) -> tuple[MemoryRegion, ...]:
    """Return the exact source regions containing validated scan hits."""

    candidates = tuple(regions)
    selected: set[MemoryRegion] = set()
    for address in addresses:
        for region in candidates:
            if region.base <= address < region.end:
                selected.add(region)
                break
    return tuple(sorted(selected, key=lambda region: region.base))


def scan_aligned_qwords(
    memory: MemoryReader,
    regions: Iterable[MemoryRegion],
    needles: Mapping[str, int],
    *,
    chunk_size: int = 4 * 1024 * 1024,
    max_matches_per_needle: int = 100_000,
    progress: ProgressCallback | None = None,
) -> QwordScanResult:
    """Search committed readable regions once for one or more aligned qwords."""

    if not needles:
        raise ValueError("at least one qword needle is required")
    if chunk_size < 4096:
        raise ValueError("chunk_size must be at least one page")
    if max_matches_per_needle <= 0:
        raise ValueError("max_matches_per_needle must be positive")

    patterns = {name: struct.pack("<Q", value) for name, value in needles.items()}
    found: dict[str, set[int]] = {name: set() for name in needles}
    visited = 0
    bytes_read = 0
    failures = 0

    for region in regions:
        visited += 1
        offset = 0
        while offset < region.size:
            # Seven bytes of forward overlap catch qwords crossing a chunk edge.
            read_size = min(chunk_size + 7, region.size - offset)
            address = region.base + offset
            try:
                raw = memory.read(address, read_size)
                if len(raw) != read_size:
                    raise ExternalReadError("short region scan read")
            except (ExternalReadError, OSError):
                failures += 1
                offset += chunk_size
                continue
            bytes_read += len(raw)
            for name, pattern in patterns.items():
                matches = found[name]
                if len(matches) >= max_matches_per_needle:
                    continue
                position = raw.find(pattern)
                while position >= 0:
                    match_address = address + position
                    if match_address % 8 == 0:
                        matches.add(match_address)
                        if len(matches) >= max_matches_per_needle:
                            break
                    position = raw.find(pattern, position + 1)
            offset += chunk_size
        if progress is not None:
            progress(visited, bytes_read)

    return QwordScanResult(
        {name: tuple(sorted(addresses)) for name, addresses in found.items()},
        visited,
        bytes_read,
        failures,
    )


@dataclass(frozen=True)
class DotCandidateResult:
    pointer_hits: int
    candidates: tuple[DotSnapshot, ...]
    by_coordinate: Mapping[tuple[int, int], tuple[DotSnapshot, ...]]
    missing_coordinates: tuple[tuple[int, int], ...]
    duplicate_coordinates: Mapping[tuple[int, int], tuple[int, ...]]


def validate_dot_pointer_hits(
    memory: MemoryReader,
    pointer_hits: Iterable[int],
    *,
    board_pointer: int,
    dot_class: int,
) -> DotCandidateResult:
    """Turn Board-pointer hits at Dot+0x48 into strict Dot candidates."""

    candidates: dict[int, DotSnapshot] = {}
    hit_count = 0
    for hit in pointer_hits:
        hit_count += 1
        if hit < 0x48:
            continue
        address = hit - 0x48
        try:
            candidate = read_dot(
                memory,
                address,
                expected_board=board_pointer,
                expected_class=dot_class,
            )
        except (LayoutValidationError, ExternalReadError, OSError):
            continue
        candidates[address] = candidate

    ordered = tuple(sorted(candidates.values(), key=lambda item: (item.row, item.column, item.address)))
    grouped_lists: dict[tuple[int, int], list[DotSnapshot]] = {}
    for candidate in ordered:
        grouped_lists.setdefault((candidate.row, candidate.column), []).append(candidate)
    grouped = {coordinate: tuple(values) for coordinate, values in grouped_lists.items()}
    expected = {(row, col) for row in range(8) for col in range(8)}
    missing = tuple(sorted(expected - set(grouped)))
    duplicates = {
        coordinate: tuple(item.address for item in values)
        for coordinate, values in grouped.items()
        if len(values) > 1
    }
    return DotCandidateResult(
        hit_count,
        ordered,
        grouped,
        missing,
        duplicates,
    )


def validate_combat_batch_hits(
    memory: MemoryReader,
    class_pointer_hits: Iterable[int],
    *,
    batch_class: int,
) -> tuple[CombatBatchSnapshot, ...]:
    """Validate possible WsCombatBatch object starts found by class qword."""

    batches: dict[int, CombatBatchSnapshot] = {}
    for address in class_pointer_hits:
        try:
            batch = read_combat_batch(memory, address, expected_class=batch_class)
        except (LayoutValidationError, ExternalReadError, OSError):
            continue
        batches[address] = batch
    return tuple(sorted(batches.values(), key=lambda item: (item.sequence, item.address)))
