"""U4: opt-in provider poll profile is off by default and only observes time."""
import unittest
from unittest.mock import patch

from pokiguard_v2 import provider_poll_profile as profile_module
from pokiguard_v2.provider_poll_profile import ENV, PollProfile, attach_poll_profile
from pokiguard_v2.memory_board_provider import MemoryBoardStateProvider


class Dummy:
    def _read_a(self):
        return self._read_b() + 1

    def _read_b(self):
        return 1

    def _poll_impl(self):
        return self._read_a()


class PollProfileTests(unittest.TestCase):
    def test_off_without_env(self):
        self.assertIsNone(attach_poll_profile(Dummy(), environ={}))
        self.assertIsNone(attach_poll_profile(Dummy(), environ={ENV: '0'}))

    def test_inclusive_times_and_slow_record(self):
        dummy = Dummy()
        profile = attach_poll_profile(dummy, environ={ENV: '1'})
        with patch.object(profile_module, 'SLOW_NS', 0):
            self.assertEqual(2, profile.measure(dummy._poll_impl))
        plain = profile.plain()
        self.assertEqual((1, 1), (plain['polls'], plain['slow_polls_over_100ms']))
        names = {n for n, _ in plain['max_by_method_ms']}
        self.assertEqual({'_read_a', '_read_b'}, names)  # _poll_impl itself is never wrapped
        self.assertEqual(1, len(plain['recent_slow']))

    def test_provider_poll_delegates_unchanged_when_off(self):
        provider = object.__new__(MemoryBoardStateProvider)
        provider._poll_profile = None
        provider._poll_impl = lambda: 'POLL'
        self.assertEqual('POLL', provider.poll())

    def test_provider_poll_measured_when_on(self):
        provider = object.__new__(MemoryBoardStateProvider)
        provider._poll_impl = lambda: 'POLL'
        with patch.dict('os.environ', {ENV: '1'}):
            self.assertEqual('POLL', provider.poll())
        self.assertIsInstance(provider._poll_profile, PollProfile)
        self.assertEqual(1, provider._poll_profile.polls)


if __name__ == '__main__':
    unittest.main()
