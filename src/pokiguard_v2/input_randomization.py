"""Operator input jitter, bounded by the existing commanded-wait envelope."""
from __future__ import annotations

from dataclasses import asdict, dataclass, fields
import json
import math


@dataclass(frozen=True)
class InputRandomization:
    reaction_min_seconds: float = 0.0
    reaction_max_seconds: float = 1.0
    inter_click_min_seconds: float = 0.0
    inter_click_max_seconds: float = 1.5
    coordinate_max_percent: float = 10.0

    def __post_init__(self):
        for low, high, cap, label in (
            (self.reaction_min_seconds, self.reaction_max_seconds, 1.0, "Trước nước đi"),
            (self.inter_click_min_seconds, self.inter_click_max_seconds, 1.5, "Giữa hai click"),
        ):
            if any(type(v) not in (int,float) or not math.isfinite(v) or not 0 <= v <= cap
                   for v in (low, high)):
                raise ValueError(f"{label}: Min/Max phải từ 0 đến {cap:g} giây")
            if high != 0 and low > high:
                raise ValueError(f"{label}: Min không được lớn hơn Max")
        v=self.coordinate_max_percent
        if type(v) not in (int,float) or not math.isfinite(v) or not 0 <= v <= 10:
            raise ValueError("Lệch tọa độ phải từ 0 đến 10% kích thước viên")

    @property
    def coordinate_fraction(self):
        return self.coordinate_max_percent/100.0

    @staticmethod
    def sample(low, high, uniform):
        # Max=0 is an explicit OFF switch, even if an old Min is retained.
        if high == 0:
            return 0.0
        return uniform(low, high)

    def to_dict(self):
        return asdict(self)

    @classmethod
    def from_dict(cls, value):
        if value is None:
            return cls()
        if not isinstance(value,dict) or set(value)-{f.name for f in fields(cls)}:
            raise ValueError("Cấu hình random không hợp lệ")
        return cls(**value)

    @classmethod
    def from_strings(cls, **values):
        try:
            return cls(**{k:float(str(v).strip().replace(',','.')) for k,v in values.items()})
        except (TypeError,ValueError) as exc:
            raise ValueError(f"Cấu hình random không hợp lệ: {exc}") from exc

    @classmethod
    def from_json(cls, value):
        return cls.from_dict(json.loads(value))


def add_randomization_argument(parser):
    parser.add_argument('--input-randomization',type=InputRandomization.from_json,
                        default=None,help='JSON khoảng random thời gian và độ lệch tọa độ')


def randomization_from_args(args):
    value=getattr(args,'input_randomization',None)
    if value is None:
        return InputRandomization()
    if type(value) is not InputRandomization:
        raise ValueError('input_randomization must be InputRandomization')
    return value
