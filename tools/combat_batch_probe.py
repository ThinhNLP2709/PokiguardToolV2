#!/usr/bin/env python3
"""One-shot post-combat scan for validated WsCombatBatch DTO snapshots."""

from __future__ import annotations

import argparse
import json
from pathlib import Path
import sys
from typing import Sequence


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
for import_path in (str(PROJECT_ROOT), str(SRC_ROOT)):
    if import_path not in sys.path:
        sys.path.insert(0, import_path)

from pokiguard_v2.il2cpp_external import (  # noqa: E402
    WS_COMBAT_BATCH_TYPE_INFO_RVA,
    ExternalReadError,
)
from pokiguard_v2.il2cpp_layout import LayoutValidationError  # noqa: E402
from pokiguard_v2.memory_scan import (  # noqa: E402
    scan_aligned_qwords,
    validate_combat_batch_hits,
)
from tools.board_memory_watch import gem_for_tag  # noqa: E402
from tools.process_probe import ProcessProbeError  # noqa: E402
from tools.runtime_common import (  # noqa: E402
    attach_target,
    default_log_path,
    hex_pointer,
    utc_timestamp,
)


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(
        description="Scan readable memory once for structurally valid WsCombatBatch boards"
    )
    parser.add_argument("--log", type=Path, help="JSON output path")
    parser.add_argument("--chunk-mib", type=int, default=4)
    return parser


def run(args: argparse.Namespace) -> int:
    if not 1 <= args.chunk_mib <= 64:
        raise ValueError("--chunk-mib must be between 1 and 64")
    log_path = (args.log or default_log_path("combat_batch_probe")).resolve()
    log_path.parent.mkdir(parents=True, exist_ok=True)
    with attach_target() as target:
        batch_class = target.resolver.resolve_type_info_class(
            WS_COMBAT_BATCH_TYPE_INFO_RVA
        )
        if batch_class is None:
            raise LayoutValidationError("WsCombatBatch type-info is not initialized")
        regions = list(target.memory.iter_readable_regions())
        print(
            f"Scanning {len(regions)} committed readable regions once...", flush=True
        )
        scan = scan_aligned_qwords(
            target.memory,
            regions,
            {"batch_class": batch_class},
            chunk_size=args.chunk_mib * 1024 * 1024,
        )
        batches = validate_combat_batch_hits(
            target.memory,
            scan.matches["batch_class"],
            batch_class=batch_class,
        )
        output = {
            "timestamp": utc_timestamp(),
            "event": "postmatch_batch_scan",
            "pid": target.pid,
            "gameassembly_base": hex_pointer(target.game_assembly.base),
            "batch_class": hex_pointer(batch_class),
            "scan": {
                "regions": scan.regions_visited,
                "bytes_read": scan.bytes_read,
                "failed_chunks": scan.failed_chunks,
                "class_pointer_hits": len(scan.matches["batch_class"]),
            },
            "validated_batches": len(batches),
            "batches": [
                {
                    "object": hex_pointer(batch.address),
                    "srvSeq": batch.sequence,
                    "board_array": hex_pointer(batch.board_array),
                    "cells": [
                        {
                            "row": cell.row,
                            "col": cell.col,
                            "tag": cell.tag,
                            "gem": gem_for_tag(cell.tag),
                            "multiplier": cell.multiplier,
                        }
                        for cell in batch.cells
                    ],
                }
                for batch in batches
            ],
        }
        with log_path.open("w", encoding="utf-8") as log_file:
            json.dump(output, log_file, ensure_ascii=False, indent=2)
            log_file.write("\n")
        print(
            f"Validated {len(batches)} batch snapshot(s); log: {log_path}",
            flush=True,
        )
        return 0 if batches else 2


def main(argv: Sequence[str] | None = None) -> int:
    args = build_parser().parse_args(argv)
    try:
        return run(args)
    except KeyboardInterrupt:
        print("Probe stopped by user.")
        return 130
    except (
        ExternalReadError,
        LayoutValidationError,
        OSError,
        ProcessProbeError,
        ValueError,
    ) as exc:
        print(f"ERROR: {exc}", file=sys.stderr)
        return 1


if __name__ == "__main__":
    raise SystemExit(main())
