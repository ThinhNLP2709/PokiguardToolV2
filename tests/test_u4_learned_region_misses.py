"""U4: a learned-region walk that finds nothing is not repeated on every provider poll."""
from types import SimpleNamespace
import unittest
from unittest.mock import patch

from pokiguard_v2.il2cpp_external import MemoryRegion
from pokiguard_v2.memory_board_provider import LEARNED_REGION_MISS_RETRY_SECONDS, MemoryBoardStateProvider
from pokiguard_v2.memory_scan import MEM_PRIVATE

BIG = MemoryRegion(0x100000, 64 * 1024 * 1024, 0x04, MEM_PRIVATE)  # outside the bounded envelope
SMALL = MemoryRegion(0x100000, 1024 * 1024, 0x04, MEM_PRIVATE)


def provider(regions):
    walks = []
    def iterate():
        walks.append(1)
        return iter(regions)
    p = object.__new__(MemoryBoardStateProvider)
    p._learned_regions = {}
    p.config = SimpleNamespace(max_region_mib=8)
    p.target = SimpleNamespace(memory=SimpleNamespace(iter_readable_regions=iterate))
    return p, walks


class LearnedRegionMissTests(unittest.TestCase):
    def test_same_miss_is_not_rewalked_until_the_retry_bound(self):
        p, walks = provider([BIG])
        with patch('pokiguard_v2.memory_board_provider.time.monotonic', side_effect=[10.0, 11.0, 10.0 + LEARNED_REGION_MISS_RETRY_SECONDS + 1]):
            for _ in range(3):
                p._retain_validated_learned_regions('board_ws', {0x100010})
        self.assertEqual(2, len(walks))  # first poll and after the bound; not the middle poll
        self.assertNotIn('board_ws', p._learned_regions)

    def test_hit_learns_region_and_new_addresses_walk_again(self):
        p, walks = provider([SMALL])
        p._retain_validated_learned_regions('board_ws', {0x100010})
        self.assertEqual({SMALL}, p._learned_regions['board_ws'])
        p._retain_validated_learned_regions('board_ws', {0x100020})  # fast path: inside learned region
        self.assertEqual(1, len(walks))
        q, walks2 = provider([BIG])
        with patch('pokiguard_v2.memory_board_provider.time.monotonic', return_value=1.0):
            q._retain_validated_learned_regions('board_ws', {0x100010})
            q._retain_validated_learned_regions('board_ws', {0x100010, 0x200000})
        self.assertEqual(2, len(walks2))  # different address set is never suppressed


if __name__ == '__main__':
    unittest.main()
