"""U2 offline check: does our Drain still take boss resources while the boss has Shield?

Reads retained combat.jsonl only. Pre-move boss Shield comes from the existing
`policy_decision.boss` snapshot; the outcome is our next MATCH_MOVE_RES. Counts
are observations, not a mechanic formula; a missing join stays UNKNOWN.
"""
import argparse
import glob
import hashlib
import json
from collections import Counter
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
DRAIN_TAG = 'trang Dot'  # live_state.TAG_TO_GEM: trang -> DRAIN
PATTERN = 'docs/phase5/artifacts/*/**/combat.jsonl'


def rows(path):
    for line in path.read_text(encoding='utf-8').splitlines():
        try:
            yield json.loads(line)
        except ValueError:
            continue


def scan(path):
    pending, out = None, []
    for r in rows(path):
        event = r.get('event')
        if event == 'policy_decision':
            boss = r.get('boss') if type(r.get('boss')) is dict else {}
            pending = dict(shield=boss.get('shield'), turn=r.get('turn'), srv=r.get('srvSeq'), sent=False)
        elif event == 'action_sent' and pending is not None and (r.get('action') or '').upper() == 'SWAP':
            pending['sent'] = True
        elif event == 'dispatcher_combat_outcome' and pending is not None and pending['sent']:
            e = (r.get('combatOutcome') or {}).get('evidence')
            if type(e) is not dict or e.get('event_type') != 'MATCH_MOVE_RES' or e.get('actor_identity') == 'BOSS':
                continue
            steps = e.get('steps') or []
            steal = [s for s in steps if s.get('kind') == 'STEAL' and s.get('target') == 'BOSS']
            first = min((s['idx'] for s in steal), default=None)
            hit = any(s.get('target') == 'BOSS' and s.get('kind') in ('DAMAGE', 'BLOCK') and s['idx'] < first
                for s in steps) if first is not None else None
            tags = e.get('destroyed_by_tag')
            out.append(dict(shield=pending['shield'], steal_amount=sum(s.get('amount', 0) for s in steal),
                hit_before_steal=hit, drain_destroyed=None if type(tags) is not dict else tags.get(DRAIN_TAG, 0)))
            pending = None
    return out


def main(argv=None):
    parser = argparse.ArgumentParser()
    parser.add_argument('--out', required=True)
    args = parser.parse_args(argv)
    files = sorted(Path(p) for p in glob.glob(str(ROOT / PATTERN), recursive=True))
    table, sources = Counter(), []
    for path in files:
        sources.append(dict(path=path.relative_to(ROOT).as_posix(), sha256=hashlib.sha256(path.read_bytes()).hexdigest()))
        for row in scan(path):
            shield = row['shield']
            state = 'UNKNOWN' if type(shield) is not int else 'SHIELD_GT_0' if shield > 0 else 'SHIELD_0'
            drain = ('DRAIN_UNKNOWN' if row['drain_destroyed'] is None else
                     'DRAIN_DESTROYED' if row['drain_destroyed'] > 0 else 'NO_DRAIN_DESTROYED')
            steal = ('NO_STEAL' if row['steal_amount'] <= 0 else
                     'STEAL_AFTER_BOSS_HIT' if row['hit_before_steal'] else 'STEAL_NO_PRIOR_HIT')
            table[(state, drain, steal)] += 1
    summary = dict(schema='pokiguard.u2.steal_shield_check.v1', files=len(files),
        table={'/'.join(k): n for k, n in sorted(table.items())},
        scope='OBSERVED_OUTCOMES_NOT_A_MECHANIC_FORMULA', sources=sources)
    Path(args.out).write_text(json.dumps(summary, indent=1, sort_keys=True), encoding='utf-8')
    print(json.dumps({k: summary[k] for k in ('files', 'table')}))


if __name__ == '__main__':
    main()
