from __future__ import annotations

from pathlib import Path
import struct
import sys
import unittest


SRC = Path(__file__).resolve().parents[1] / "src"
if str(SRC) not in sys.path:
    sys.path.insert(0, str(SRC))

from pokiguard_v2.obfuscated_int import (
    decode_obfuscated_int,
    encode_for_test,
    rotate_left32,
    rotate_right32,
)


class ObfuscatedIntTests(unittest.TestCase):
    def test_native_getter_inverse_for_signed_values(self) -> None:
        for value, key_a, key_b in (
            (0, 0, 0),
            (160, 0x12345678, -889275714),
            (9_999_999, -2023406815, 0x10203040),
            (-1, -1, 0x7FFFFFFF),
        ):
            raw = encode_for_test(value, key_a, key_b, noise=123)
            self.assertEqual(decode_obfuscated_int(raw), value)

    def test_noise_does_not_affect_native_getter(self) -> None:
        left = encode_for_test(320, 17, 99, noise=1)
        right = encode_for_test(320, 17, 99, noise=0x12345678)
        self.assertEqual(decode_obfuscated_int(left), decode_obfuscated_int(right))

    def test_rotations_are_32_bit(self) -> None:
        value = 0x89ABCDEF
        self.assertEqual(rotate_right32(rotate_left32(value, 13), 13), value)
        self.assertEqual(rotate_left32(value, 32), value)

    def test_short_value_fails_closed(self) -> None:
        with self.assertRaises(ValueError):
            decode_obfuscated_int(struct.pack("<i", 1))


if __name__ == "__main__":
    unittest.main()
