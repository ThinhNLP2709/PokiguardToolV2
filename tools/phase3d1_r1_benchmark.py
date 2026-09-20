#!/usr/bin/env python3
"""Build the Phase 3D.1-R1 remediation and refreshed benchmark dataset."""

from __future__ import annotations

import argparse
from pathlib import Path
import sys


PROJECT_ROOT = Path(__file__).resolve().parents[1]
SRC_ROOT = PROJECT_ROOT / "src"
if str(SRC_ROOT) not in sys.path:
    sys.path.insert(0, str(SRC_ROOT))

from pokiguard_v2.phase3d1_benchmark import BenchmarkDataError  # noqa: E402
from pokiguard_v2.phase3d1_r1_benchmark import (  # noqa: E402
    analyze_manifest,
    render_markdown_summary,
    write_json,
)


def _args(argv: list[str] | None = None) -> argparse.Namespace:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--manifest", type=Path, required=True)
    parser.add_argument("--logs-root", type=Path, default=PROJECT_ROOT / "logs" / "farm_runs")
    parser.add_argument("--output", type=Path, required=True)
    parser.add_argument("--markdown-output", type=Path)
    return parser.parse_args(argv)


def main(argv: list[str] | None = None) -> int:
    args = _args(argv)
    try:
        analysis = analyze_manifest(args.manifest.resolve(), args.logs_root.resolve())
        write_json(args.output.resolve(), analysis)
        markdown = render_markdown_summary(analysis)
        if args.markdown_output is not None:
            args.markdown_output.resolve().parent.mkdir(parents=True, exist_ok=True)
            args.markdown_output.resolve().write_text(markdown, encoding="utf-8")
        print(markdown, end="")
    except (BenchmarkDataError, OSError, ValueError, TypeError) as exc:
        print(f"ERROR: {exc}", file=sys.stderr)
        return 1
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
