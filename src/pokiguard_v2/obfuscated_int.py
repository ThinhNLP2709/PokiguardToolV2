"""Native-evidenced read-only decoder for Pokiguard's ``ObfuscatedInt``.

The four fields are an inline 16-byte value type.  ``_noise`` is refreshed by
the constructor/setter but is not referenced by the native getter.
"""

from __future__ import annotations

from dataclasses import dataclass
import struct


UINT32_MASK = 0xFFFFFFFF


def _u32(value: int) -> int:
    return value & UINT32_MASK


def _i32(value: int) -> int:
    value &= UINT32_MASK
    return value - 0x100000000 if value & 0x80000000 else value


def rotate_left32(value: int, count: int) -> int:
    count &= 31
    value = _u32(value)
    if count == 0:
        return value
    return _u32((value << count) | (value >> (32 - count)))


def rotate_right32(value: int, count: int) -> int:
    count &= 31
    value = _u32(value)
    if count == 0:
        return value
    return _u32((value >> count) | (value << (32 - count)))


@dataclass(frozen=True)
class ObfuscatedIntRaw:
    stored: int
    key_a: int
    key_b: int
    noise: int

    @classmethod
    def from_bytes(cls, raw: bytes, offset: int = 0) -> "ObfuscatedIntRaw":
        if offset < 0 or len(raw) < offset + 16:
            raise ValueError("ObfuscatedInt requires exactly 16 readable bytes")
        return cls(*struct.unpack_from("<4i", raw, offset))

    @property
    def value(self) -> int:
        # Native get_Value:
        #   RotateRight(_stored, _keyA & 31) ^ _keyB; then subtract _keyA.
        mixed = rotate_right32(self.stored, self.key_a & 31)
        return _i32((mixed ^ _u32(self.key_b)) - _u32(self.key_a))


def decode_obfuscated_int(raw: bytes, offset: int = 0) -> int:
    return ObfuscatedIntRaw.from_bytes(raw, offset).value


def encode_for_test(value: int, key_a: int, key_b: int, noise: int = 0) -> bytes:
    """Mirror the proven setter for deterministic tests, never target writes."""

    mixed = _u32(_u32(key_a) + _u32(value)) ^ _u32(key_b)
    stored = rotate_left32(mixed, key_a & 31)
    return struct.pack(
        "<4I", stored, _u32(key_a), _u32(key_b), _u32(noise)
    )
