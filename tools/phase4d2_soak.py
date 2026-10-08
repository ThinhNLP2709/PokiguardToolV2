from __future__ import annotations

import argparse
import json
from pathlib import Path
import sys


ROOT = Path(__file__).resolve().parents[1]
SRC = ROOT / "src"
if str(SRC) not in sys.path:
    sys.path.insert(0, str(SRC))

from pokiguard_v2.phase4d2_soak import (  # noqa: E402
    BenchmarkDataError,
    analyze_soak_manifest,
    assign_soak_run,
    prepare_soak_manifest,
    render_markdown_summary,
    write_json,
)
from pokiguard_v2.version import APP_VERSION  # noqa: E402


DEFAULT_MANIFEST = ROOT / "docs" / "phase4" / "artifacts" / "phase4d2_manifest.json"
DEFAULT_ANALYSIS = ROOT / "docs" / "phase4" / "artifacts" / "phase4d2_analysis.json"
DEFAULT_SUMMARY = ROOT / "docs" / "phase4" / "artifacts" / "phase4d2_analysis.md"
DEFAULT_CONFIG = {
    "play_style": "skill_rush",
    "intelligence": "basic",
    "main_pet": "legendary",
    "evolution": "none",
    "damage_card": "pet_skill",
    "audition_mode": "audition_v3",
    "board_input_mode": "two_click",
    "cast_when_boss_hp_below": 30000,
    "cast_mana_stockpile": 480,
    "rage_target": 100,
    "pet_skill_fire_condition": "sword_count",
    "pet_skill_fire_value": 7,
}


def _parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(description="Offline Phase 4D.2 reliability soak tool")
    sub = parser.add_subparsers(dest="command", required=True)

    prepare = sub.add_parser("prepare", help="freeze a pending 25-match soak manifest")
    prepare.add_argument("--output", type=Path, default=DEFAULT_MANIFEST)
    prepare.add_argument("--game-executable", type=Path, default=Path(r"D:\pc\PetPuzzle-1.7.4.exe"))
    prepare.add_argument("--game-assembly", type=Path, default=Path(r"D:\pc\GameAssembly.dll"))
    prepare.add_argument("--boss-id", default="1289")
    prepare.add_argument("--boss-name", default="Starburst")
    prepare.add_argument("--target", type=int, default=25)
    prepare.add_argument("--max-attempts", type=int, default=30)
    prepare.add_argument("--minimum-focus-takeovers", type=int, default=25)
    prepare.add_argument("--minimum-qte-focus-takeovers", type=int, default=5)
    prepare.add_argument("--config-json", type=Path)

    assign = sub.add_parser("assign", help="bind the completed FarmRunId")
    assign.add_argument("--manifest", type=Path, default=DEFAULT_MANIFEST)
    assign.add_argument("--run-id", required=True)

    analyze = sub.add_parser("analyze", help="validate the bound soak run")
    analyze.add_argument("--manifest", type=Path, default=DEFAULT_MANIFEST)
    analyze.add_argument("--logs-root", type=Path, default=ROOT / "logs" / "farm_runs")
    analyze.add_argument("--output", type=Path, default=DEFAULT_ANALYSIS)
    analyze.add_argument("--markdown-output", type=Path, default=DEFAULT_SUMMARY)
    return parser


def main(argv: list[str] | None = None) -> int:
    args = _parser().parse_args(argv)
    try:
        if args.command == "prepare":
            config = DEFAULT_CONFIG
            if args.config_json is not None:
                config = json.loads(args.config_json.read_text(encoding="utf-8"))
            manifest = prepare_soak_manifest(
                workspace=ROOT,
                app_version=APP_VERSION,
                game_executable=args.game_executable,
                game_assembly=args.game_assembly,
                expected_target={"boss_id": args.boss_id, "boss_name": args.boss_name},
                gameplay_config=config,
                required_completed_matches=args.target,
                max_match_attempts=args.max_attempts,
                minimum_focus_takeovers=args.minimum_focus_takeovers,
                minimum_qte_focus_takeovers=args.minimum_qte_focus_takeovers,
            )
            write_json(args.output, manifest)
            print(f"Phase 4D.2 manifest prepared: {args.output}")
            return 0
        if args.command == "assign":
            manifest = json.loads(args.manifest.read_text(encoding="utf-8"))
            write_json(args.manifest, assign_soak_run(manifest, args.run_id))
            print(f"Phase 4D.2 soak bound to {args.run_id}")
            return 0
        analysis = analyze_soak_manifest(args.manifest, args.logs_root, workspace=ROOT)
        write_json(args.output, analysis)
        args.markdown_output.parent.mkdir(parents=True, exist_ok=True)
        args.markdown_output.write_text(render_markdown_summary(analysis), encoding="utf-8")
        print(f"Phase 4D.2 analysis: {analysis['acceptance']['result']} ({args.output})")
        return 0 if analysis["acceptance"]["pass_strong"] else 3
    except (BenchmarkDataError, OSError, json.JSONDecodeError) as exc:
        print(f"Phase 4D.2 rejected: {exc}", file=sys.stderr)
        return 2


if __name__ == "__main__":
    raise SystemExit(main())
