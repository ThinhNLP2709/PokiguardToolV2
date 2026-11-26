"""Opt-in timing of one provider poll, for diagnosing slow observation reads.

Enabled only when POKIGUARD_V2_PROVIDER_PROFILE=1 (a test session sets it next to
POKIGUARD_V2_DATA_ROOT). Off by default: nothing is wrapped. Times are inclusive per
private method; nested calls overlap. No reads, writes, input or decisions change.
"""
from collections import deque
import os
import time
import types

ENV = 'POKIGUARD_V2_PROVIDER_PROFILE'
SLOW_NS = 100_000_000


class PollProfile:
    def __init__(self, owner, *, exclude=('_poll_impl',)):
        self.current = None
        self.polls = 0
        self.slow_polls = 0
        self.max_total_ns = 0
        self.slowest = ()
        self.max_by_name = {}
        self.recent_slow = deque(maxlen=16)
        for name, value in vars(type(owner)).items():
            if (name.startswith('_') and not name.startswith('__') and name not in exclude
                    and isinstance(value, types.FunctionType)):
                setattr(owner, name, self._wrap(name, getattr(owner, name)))

    def _wrap(self, name, bound):
        def timed(*args, **kwargs):
            start = time.perf_counter_ns()
            try:
                return bound(*args, **kwargs)
            finally:
                current = self.current
                if current is not None:
                    current[name] = current.get(name, 0) + time.perf_counter_ns() - start
        timed.__name__ = name
        return timed

    def measure(self, poll):
        self.current = {}
        start = time.perf_counter_ns()
        try:
            return poll()
        finally:
            total = time.perf_counter_ns() - start
            current, self.current = self.current or {}, None
            self.polls += 1
            top = sorted(current.items(), key=lambda kv: -kv[1])
            for name, value in current.items():
                if value > self.max_by_name.get(name, 0):
                    self.max_by_name[name] = value
            if total > self.max_total_ns:
                self.max_total_ns, self.slowest = total, tuple(top[:8])
            if total > SLOW_NS:
                self.slow_polls += 1
                self.recent_slow.append((round(total / 1e6, 2), tuple((n, round(v / 1e6, 2)) for n, v in top[:5])))

    def plain(self):
        ms = lambda ns: round(ns / 1e6, 2)
        return dict(polls=self.polls, slow_polls_over_100ms=self.slow_polls, max_poll_ms=ms(self.max_total_ns),
            slowest_poll_top_ms=[[n, ms(v)] for n, v in self.slowest],
            max_by_method_ms=[[n, ms(v)] for n, v in sorted(self.max_by_name.items(), key=lambda kv: -kv[1])[:12]],
            recent_slow=[[total, [list(x) for x in top]] for total, top in self.recent_slow],
            scope='OPT_IN_INCLUSIVE_PRIVATE_METHOD_TIMES_NOT_INPUT_AUTHORITY')


def attach_poll_profile(owner, environ=None):
    if (os.environ if environ is None else environ).get(ENV) != '1':
        return None
    try:
        return PollProfile(owner)
    except Exception:
        return None  # Diagnostics only: a failed attach leaves the provider untouched.
