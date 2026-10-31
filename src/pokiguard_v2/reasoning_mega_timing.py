"""Opt-in BASIC probe of Mega's one required click, without changing its action.

The existing primitive records time.monotonic() AFTER send_normalized_point
returns. Its long readonly post-state wait is still logged separately. The
start uses that same clock; QPC and GetTickCount64 absolute values are never
subtracted. Quantization is explicitly padded, not treated as an exact click.
"""
import math
import time

from .reasoning_swap_timing import SwapTimingCollector, SwapTimingSession

VERSION = '5d4.click_only_input_elapsed.v1'


def input_interval(start, result, returned):
    """Pure elapsed interval; UNKNOWN data cannot become a timing allowance."""
    rejected = dict(protocol=VERSION, status='UNPROVEN', input_authority=False)
    if result is None or getattr(getattr(result, 'kind', None), 'value', None) != 'SUCCESS_NO_ACTION':
        return dict(rejected, reason='CLICK_ONLY_SUCCESS_REQUIRED')
    counts=tuple(getattr(result,k,None) for k in ('card_clicks','space_presses','direction_presses'))
    if any(type(v) is not int for v in counts) or counts != (1,0,0):
        return dict(rejected, reason='ONE_CLICK_ZERO_KEYS_REQUIRED')
    end = getattr(getattr(result, 'telemetry', None), 'card_click_timestamp', None)
    begin, resolution = start.get('monotonic_start'), start.get('resolution_seconds')
    if (any(type(v) not in (float, int) or not math.isfinite(v) for v in
            (begin, end, returned, resolution)) or type(start.get('implementation')) is not str
            or not start['implementation'] or not 0 < resolution <= .1
            or not 0 <= begin <= end <= returned):
        return dict(rejected, reason='MISSING_OR_INVALID_SAME_CLOCK_INTERVAL')
    # Two quantization edges and a 1ms representation/rounding allowance.
    guard = 2 * resolution + .001
    return dict(protocol=VERSION, status='OBSERVED_PADDED_ELAPSED',
        clock='host.time.monotonic', implementation=start['implementation'],
        start_seconds=begin, required_input_completed_seconds=end,
        readonly_return_seconds=returned, resolution_seconds=resolution,
        quantization_guard_ms=guard * 1000,
        required_input_upper_ms=(end-begin+guard) * 1000,
        post_click_readonly_elapsed_ms=(returned-end) * 1000,
        completion_evidence='EXISTING_TELEMETRY_AFTER_SEND_NORMALIZED_POINT_RETURN',
        exact_click_timestamp=False, sample_max_is_future_bound=False,
        input_authority=False)


class MegaClickTimingCollector(SwapTimingCollector):
    def __init__(self, *, sink, run_id, sequence=0, operational_authority=None,
                 on_fault=None,component_monitor=False,measure_skills=True):
        if measure_skills is not True:raise ValueError('Mega skill measurement required')
        if operational_authority is not None:
            from .reasoning_mega import is_mega
            if not is_mega(operational_authority):raise ValueError('own Mega operational timing required')
        super().__init__(sink=sink, run_id=run_id, sequence=sequence, measure_skills=True,
            operational_authority=operational_authority,on_fault=on_fault,component_monitor=component_monitor)
        info = time.get_clock_info('monotonic')
        if not info.monotonic or info.adjustable or not 0 < info.resolution <= .1:
            raise ValueError('known bounded monotonic clock resolution required')
        self.input_clock = dict(implementation=info.implementation,
            resolution_seconds=info.resolution)

    def skill_start(self, **kwargs):
        # Read only the host clock before the existing primitive. No game read.
        start = dict(self.input_clock, monotonic_start=time.monotonic())
        super().skill_start(**kwargs)
        if self.skill_interval is not None and not self.disabled:
            self.skill_interval['click_only_input'] = start

    def skill_finish(self, *, result=None, status='RETURNED'):
        if self.skill_interval is not None:
            self.skill_interval['click_only_input'] = input_interval(
                self.skill_interval.get('click_only_input', {}), result, time.monotonic())
        # Keep the original whole-primitive QPC interval and first-click UNKNOWN.
        super().skill_finish(result=result, status=status)


def required_input_ns(sample):
    """Validate the same-clock padded sample, never a whole-readonly reserve."""
    value=sample.get('click_only_input',{})
    if (value.get('protocol')!=VERSION or value.get('status')!='OBSERVED_PADDED_ELAPSED'
        or value.get('clock')!='host.time.monotonic' or value.get('exact_click_timestamp') is not False
        or value.get('input_authority') is not False):return None
    start,end,resolution,upper=(value.get(k) for k in ('start_seconds','required_input_completed_seconds',
        'resolution_seconds','required_input_upper_ms'))
    if (any(type(v) not in (int,float) or not math.isfinite(v) for v in (start,end,resolution,upper))
        or not 0<=start<=end or not 0<resolution<=.1
        or abs(upper-(end-start+2*resolution+.001)*1000)>1e-6):return None
    return math.ceil(upper*1e6)


class MegaClickTimingSession(SwapTimingSession):
    """Same cap/writer/Stop owner, with this explicit BASIC-only collector."""
    def __init__(self, request, *, config, directory):
        super().__init__(request, config=config, directory=directory, measure_skills=True)
        self.collector = MegaClickTimingCollector(sink=self.sink, run_id=request.run_id)

    def prepare_options(self):
        if self.stopped:
            return {}
        if self.collector.stopped:
            sequence = self.collector.sequence
            self.prior_dropped += self.collector.dropped
            self.collector = MegaClickTimingCollector(sink=self.sink,
                run_id=self.request.run_id, sequence=sequence)
        return dict(swap_timing_adapter=self.collector)

    def stop(self):
        if not self.stopped and self.collector.sequence == 0:
            self.collector._fault('D4_PROBE_NO_MEASUREMENT_RECORDS')
        # Existing background owner performs flush/close. No wait on Stop.
        super().stop()
