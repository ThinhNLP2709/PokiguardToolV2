from __future__ import annotations

import argparse
from pathlib import Path
import sys


ROOT = Path(__file__).resolve().parents[1]
SRC = ROOT / "src"
if str(SRC) not in sys.path:
    sys.path.insert(0, str(SRC))

from pokiguard_v2.phase3d1_benchmark import (  # noqa: E402
    BenchmarkDataError,
    analyze_manifest,
    render_markdown_summary,
    write_json,
)


def _args(argv: list[str] | None = None) -> argparse.Namespace:
    parser = argparse.ArgumentParser(
        description="Offline Phase 3D.1 FarmRunner A/B analyzer"
    )
    parser.add_argument("--manifest", type=Path, required=True)
    parser.add_argument("--logs-root", type=Path, default=ROOT / "logs" / "farm_runs")
    parser.add_argument("--output", type=Path, required=True)
    parser.add_argument("--markdown-output", type=Path)
    return parser.parse_args(argv)


def main(argv: list[str] | None = None) -> int:
    args = _args(argv)
    try:
        analysis = analyze_manifest(args.manifest, args.logs_root)
    except BenchmarkDataError as exc:
        print(f"Phase 3D.1 analysis rejected: {exc}", file=sys.stderr)
        return 2
    write_json(args.output, analysis)
    if args.markdown_output is not None:
        args.markdown_output.parent.mkdir(parents=True, exist_ok=True)
        args.markdown_output.write_text(
            render_markdown_summary(analysis), encoding="utf-8"
        )
    print(
        f"Phase 3D.1 dataset written: {args.output} "
        f"(A={analysis['modes']['A_DEFAULT']['n']}, "
        f"B={analysis['modes']['B_PET_SKILL']['n']})"
    )
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
