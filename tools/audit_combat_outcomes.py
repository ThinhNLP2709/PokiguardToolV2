"""Audit saved outcome evidence without attaching to the game or fitting damage."""
from collections import Counter
import argparse
import hashlib
import json
from pathlib import Path
import sys

ROOT = Path(__file__).resolve().parents[1]
sys.path[:0] = [str(ROOT), str(ROOT/'src')]
from pokiguard_v2.combat_outcome_evidence import observed_effect_totals


def audit(paths):
    counts = Counter()
    styles = Counter()
    capture_status = Counter()
    effect_kinds = Counter()
    files = []
    for path in sorted(set(paths)):
        digest = hashlib.sha256()
        local = Counter()
        identities = {}
        with path.open('rb') as stream:
            for raw in stream:
                digest.update(raw)
                if len(raw) > 2*1024*1024:
                    local['oversized_log_lines'] += 1
                    continue
                try:
                    row = json.loads(raw.decode('utf-8-sig'))
                except (ValueError, UnicodeError, RecursionError):
                    local['invalid_log_lines'] += 1
                    continue
                if type(row) is not dict:
                    local['invalid_log_lines'] += 1
                    continue
                event = row.get('event')
                if event == 'auto_controller_started':
                    styles[row.get('config', {}).get('play_style', 'UNKNOWN')] += 1
                if event == 'policy_decision':
                    local['decisions'] += 1
                    if type(row.get('player')) is dict and type(row.get('boss')) is dict:
                        local['decisions_with_actor_stats'] += 1
                if event == 'action_result' and row.get('result') == 'SWAP_ACKNOWLEDGED':
                    local['swap_acks'] += 1
                if event == 'pet_skill_action_proposed':
                    local['skill_proposals'] += 1
                if event == 'pet_skill_dispatch_result':
                    local['skill_dispatch_results'] += 1
                if event == 'terminal_combat_snapshot':
                    local['terminal_snapshots'] += 1
                record = row.get('combatOutcome')
                if type(record) is dict:
                    local['outcome_records'] += 1
                    capture_status[str(record.get('status', 'UNKNOWN'))] += 1
                    evidence = record.get('evidence')
                    if type(evidence) is dict:
                        identity = tuple(evidence.get(k) for k in
                            ('match_id', 'server_sequence', 'event_type', 'actor_identity'))
                        if all(type(k) in (str, int) for k in identity):
                            if identity in identities:
                                local['duplicate_outcomes' if identities[identity] == evidence.get('raw_sha256')
                                    else 'conflicting_outcomes'] += 1
                                continue
                            identities[identity] = evidence.get('raw_sha256')
                    totals = observed_effect_totals(record)
                    if totals:
                        local['batches_with_typed_effects'] += 1
                        for group in totals:
                            effect_kinds[group['kind']] += 1
        counts.update(local)
        files.append(dict(path=str(path.resolve().relative_to(ROOT)) if path.resolve().is_relative_to(ROOT)
            else str(path.resolve()), sha256=digest.hexdigest(), counts=dict(local)))
    return dict(schema='pokiguard.combat_outcome_audit.v1', files=len(files), counts=dict(counts),
        styles=dict(styles), capture_status=dict(capture_status), effect_groups=dict(effect_kinds),
        file_manifest=files, fitted_damage_models=0,
        fit_status='NOT_FITTED_SCOPE_AND_COMPLETE_ACTION_ATTRIBUTION_REQUIRED' if counts['batches_with_typed_effects']
            else 'NO_ATTRIBUTED_SERVER_STEPS', hp_delta_is_not_damage=True,
        input_authority=False, process_attachment=False, windows_input=False)


def main():
    parser = argparse.ArgumentParser(__doc__)
    parser.add_argument('--logs', type=Path, default=ROOT/'logs/farm_runs')
    parser.add_argument('--out', type=Path, required=True)
    args = parser.parse_args()
    paths = [args.logs] if args.logs.is_file() else args.logs.rglob('combat.jsonl')
    report = audit(paths)
    args.out.parent.mkdir(parents=True, exist_ok=True)
    with args.out.open('x', encoding='utf-8') as stream:
        json.dump(report, stream, indent=2)
    print(json.dumps({key: value for key, value in report.items() if key != 'file_manifest'}))


if __name__ == '__main__':
    main()
