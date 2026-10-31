"""One shared host guard; component overruns remain visible diagnostics."""
VERSION = 'SHARED_HOST_GUARD_V1'


def debit_guard(h, i, h_limit, i_limit, guard):
    values=(h,i,h_limit,i_limit,guard)
    if not all(type(v) is int and v>=0 for v in values):
        raise ValueError('nonnegative integer host intervals required')
    h_extra=max(0,h-h_limit);i_extra=max(0,i-i_limit);debit=h_extra+i_extra
    return dict(version=VERSION,shared_guard_ns=guard,controller_excess_ns=h_extra,
        input_excess_ns=i_extra,debit_ns=debit,remaining_ns=max(0,guard-debit),exhausted=debit>guard)
