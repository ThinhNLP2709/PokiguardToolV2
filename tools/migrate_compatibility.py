"""Prepare/probe/apply address-only compatibility using the same GUI engine."""
from __future__ import annotations
import argparse
import json
from pathlib import Path
from pokiguard_v2.compatibility.service import migrate


def main(argv=None) -> int:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--game", required=True, help="Exact selected launcher or game folder")
    parser.add_argument("--reverse", type=Path, help="Reuse a local Dumper export instead of downloading/running Dumper")
    parser.add_argument("--prepare", action="store_true", help="Static audit only; never activates a profile")
    args = parser.parse_args(argv)
    try:
        result = migrate(args.game, reverse=args.reverse, prepare_only=args.prepare,
                         progress=print)
        print(json.dumps({"status": result.status, "message": result.message,
                          "job": str(result.job) if result.job else None,
                          "profile_id": result.profile_id}, ensure_ascii=False))
        return 0 if result.status in ("builtin", "verified") else 3
    except Exception as exc:
        print(json.dumps({"status": "failed", "reason": getattr(exc, "reason", type(exc).__name__),
                          "error": str(exc)}, ensure_ascii=False))
        return 2


if __name__ == "__main__":
    raise SystemExit(main())
