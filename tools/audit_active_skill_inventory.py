"""Offline inventory of logged click-only skills; never grants runtime authority.

Distinguishes a proposal, an actual logged click, a fresh resource endpoint and
attributed server effects. A SUCCESS_NO_ACTION label alone proves none of them.
Only explicit action/session/card identities join primitive and controller logs.
"""
from __future__ import annotations

import argparse
from collections import Counter, defaultdict
import hashlib
import json
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
FAMILIES = {"MEGA_ICARUS_CLICK_ONLY", "MEGA_TREX_CLICK_ONLY", "GALAXY_CLICK_ONLY"}
CLICK_EVENT = "pet_skill_no_action_click_sent"


def digest(value):
    return hashlib.sha256(json.dumps(value, sort_keys=True, separators=(",", ":"),
                                    ensure_ascii=False).encode()).hexdigest()


def integer(value):
    return type(value) is int and value >= 0


def pair(value):
    return (isinstance(value, list) and len(value) == 2
            and all(integer(v) for v in value))


def identity_ok(action):
    if not isinstance(action, dict):
        return False
    session = action.get("session_key")
    return (isinstance(action.get("value"), str) and bool(action["value"])
            and isinstance(action.get("match_id"), str) and bool(action["match_id"])
            and isinstance(session, dict)
            and session.get("match_id") == action["match_id"]
            and all(integer(session.get(k)) for k in ("lifecycle_epoch", "board_instance"))
            and integer(action.get("source_turn")) and action["source_turn"] > 0
            and integer(action.get("skill_card_id")))


def read_rows(path):
    rows, errors = [], []
    with path.open(encoding="utf-8-sig") as stream:
        for number, line in enumerate(stream, 1):
            if not line.strip():
                continue
            try:
                item = json.loads(line)
                if not isinstance(item, dict):
                    raise ValueError("row is not an object")
                rows.append((number, item))
            except (ValueError, TypeError):
                errors.append(number)
    return rows, errors


def analyze_rows(rows):
    """Sanitized primitive evidence; no inferred damage, ACK or RNG outcome."""
    records = []
    for line, entry in rows:
        if entry.get("event") != "pet_skill_action_result":
            continue
        result = entry.get("result")
        if not isinstance(result, dict):
            continue
        action = result.get("action_id")
        valid_id = identity_ok(action)
        clicks = [(n, d) for n, d in rows if n < line and d.get("event") == CLICK_EVENT
                  and valid_id and d.get("actionId") == action]
        cutoff = clicks[0][0] if len(clicks) == 1 else line
        observed = [(n, d["capability"]) for n, d in rows
                    if n < cutoff and d.get("event") == "pet_skill_capability_observed"
                    and isinstance(d.get("capability"), dict)]
        # The latest observation is authoritative even when it invalidates an
        # earlier CURRENT capability. Never reach back past an UNKNOWN reread.
        cap = observed[-1][1] if observed else {}
        same_cap_identity = bool(valid_id and cap.get("session_key") == action["session_key"]
                                 and cap.get("skill_card_id") == action["skill_card_id"])
        family = cap.get("skill_family")
        attempted = sorted({c.get("skill_family") for _, c in observed
                            if c.get("skill_family") in FAMILIES})
        current = (cap.get("status") == "CURRENT" and cap.get("ownership_current") is True
                   and cap.get("live_card_present") is True
                   and cap.get("live_card_actionable") is True and family in FAMILIES
                   and same_cap_identity)
        costs = [cap.get("effective_mana_cost"), cap.get("effective_power_cost")]
        source_costs = [cap.get("effective_mana_cost_source"),
                        cap.get("effective_power_cost_source")]
        cost_known = (pair(costs) and all(isinstance(v, str) and bool(v)
                                        and v not in {"UNKNOWN", "NONE"} for v in source_costs))
        actual_click = (len(clicks) == 1 and result.get("card_clicks") == 1
                        and type(result.get("card_clicks")) is int
                        and type(result.get("space_presses")) is int and result["space_presses"] == 0
                        and type(result.get("direction_presses")) is int and result["direction_presses"] == 0)
        # Zero input and stale capability remain useful failure observations.
        complete = result.get("kind") == "SUCCESS_NO_ACTION" and result.get("state") == "COMPLETE"
        local_join = bool(valid_id and current and cost_known and actual_click and complete)
        telemetry = result.get("telemetry") if isinstance(result.get("telemetry"), dict) else {}
        before, after = telemetry.get("resources_before"), telemetry.get("resources_after")
        post = result.get("post_state") if isinstance(result.get("post_state"), dict) else {}
        battle = post.get("battle") if isinstance(post.get("battle"), dict) else {}
        player = post.get("player") if isinstance(post.get("player"), dict) else {}
        session_equal = bool(valid_id and battle.get("session_key") == action["session_key"]
                             and battle.get("match_id") == action["match_id"])
        turns_equal = bool(valid_id and telemetry.get("turn_before") == action["source_turn"]
                           and integer(telemetry.get("turn_after"))
                           and telemetry["turn_after"] == action["source_turn"] + 1
                           and integer(battle.get("turn_number"))
                           and battle.get("turn_number") == telemetry["turn_after"])
        endpoint = bool(local_join and pair(before) and pair(after) and session_equal and turns_equal
                        and player.get("is_local") is True and player.get("is_boss") is False
                        and pair([player.get("mana"), player.get("power")])
                        and [player.get("mana"), player.get("power")] == after)
        reasons = []
        for ok, reason in ((valid_id, "ACTION_IDENTITY_UNAVAILABLE"),
                           (current, "CURRENT_OWNED_ACTIONABLE_CARD_UNVERIFIED"),
                           (cost_known, "COST_PROVENANCE_UNAVAILABLE"),
                           (actual_click, "ONE_EXACT_CLICK_NOT_PROVEN"),
                           (complete, "PRIMITIVE_NOT_COMPLETE"),
                           (endpoint, "RESOURCE_ENDPOINT_UNVERIFIED")):
            if not ok:
                reasons.append(reason)
        records.append(dict(
            action_key=digest(action) if valid_id else None,
            action_id=action.get("value") if valid_id else None,
            match_id=action.get("match_id") if valid_id else None,
            source_turn=action.get("source_turn") if valid_id else None,
            skill_card_id=action.get("skill_card_id") if valid_id else None,
            session_key_sha256=digest(action["session_key"]) if valid_id else None,
            family=family, attempted_families=attempted, element_type=cap.get("element_type"),
            result_line=line, capability_line=observed[-1][0] if observed else None,
            click_line=clicks[0][0] if len(clicks) == 1 else None,
            result_kind=result.get("kind"), card_clicks=result.get("card_clicks"),
            exact_logged_click=actual_click, capability_current=current,
            effective_cost=costs, cost_sources=source_costs,
            logged_click_card_cost_join=local_join,
            resource_endpoint_consistent=endpoint,
            resources_before=before if pair(before) else None,
            resources_after=after if pair(after) else None,
            resource_net_delta=[a-b for a, b in zip(after, before)] if endpoint else None,
            post_sequence=battle.get("srv_seq"), post_turn=battle.get("turn_number"),
            server_response_correlated=telemetry.get("server_response_correlated") is True,
            server_effect_binding_verified=False, damage_training_eligible=False,
            reasons=reasons,
        ))
    return records


def combat_index(path):
    sends, results, typed, response_metadata = [], [], [], []
    errors, rows = [], []
    # Stream large combat logs; retain only the small skill identity evidence.
    with path.open(encoding="utf-8-sig") as stream:
        for number, line in enumerate(stream, 1):
            try:
                d = json.loads(line)
            except ValueError:
                errors.append(number)
                continue
            if not isinstance(d, dict):
                errors.append(number)
                continue
            event = d.get("event")
            if event == "pet_skill_dispatch_started":
                sends.append((number, d))
            elif event == "pet_skill_dispatch_result":
                results.append((number, d))
            # Capture projection keys are explicit; generic HP snapshots do not count.
            outcome = d.get("combatOutcome") or d.get("combat_outcome")
            if isinstance(outcome, dict):
                typed.append((number, outcome))
            if (event == "dispatcher_board_snapshot_offered"
                    and d.get("eventType") in {"MATCH_SKILL_USE_RES", "MATCH_CARD_USE_RES"}):
                response_metadata.append((number, dict(event_type=d["eventType"],
                    server_sequence=d.get("srvSeq"), accepted=d.get("accepted"))))
            if event == "auto_controller_started":
                rows.append(d.get("config") or {})
    return dict(sends=sends, results=results, typed=typed, errors=errors, configs=rows,
                skill_response_metadata=response_metadata)


def controller_join(record, index):
    """Require an echoed action ID in the controller result, never timing alone."""
    matched = [(n, d) for n, d in index["results"]
               if isinstance(d.get("result"), dict)
               and isinstance(d["result"].get("action_id"), dict)
               and record["action_key"] is not None
               and digest(d["result"]["action_id"]) == record["action_key"]]
    out = dict(controller_join_verified=False, controller_result_line=None,
               controller_start_line=None, source_sequence=None,
               typed_outcome_records_in_combat=len(index["typed"]))
    if len(matched) != 1:
        out["controller_join_reason"] = "CONTROLLER_RESULT_NOT_UNIQUE_OR_ABSENT"
        return out
    number, row = matched[0]
    identity = row.get("identity") or {}
    source = identity.get("source") or {}
    action = row["result"]["action_id"]
    previous_result = max((n for n, d in index["results"]
                           if n < number and d.get("identity") == identity), default=0)
    starts = [(n, d) for n, d in index["sends"]
              if previous_result < n < number and d.get("identity") == identity]
    before = [starts[0][1].get("currentMana"), starts[0][1].get("currentRage")] if len(starts) == 1 else None
    cost = [starts[0][1].get("requiredMana"), starts[0][1].get("requiredRage")] if len(starts) == 1 else None
    same = (identity.get("action") == "pet_skill" and source.get("session") == action.get("session_key")
            and source.get("turn") == record["source_turn"]
            and identity.get("target") == [action.get("session_key"), record["skill_card_id"]]
            and integer(source.get("srv_seq")))
    same_result = (row["result"].get("kind") == record["result_kind"]
                   and row["result"].get("card_clicks") == record["card_clicks"]
                   and (row["result"].get("telemetry") or {}).get("resources_before") == record["resources_before"]
                   and (row["result"].get("telemetry") or {}).get("resources_after") == record["resources_after"])
    ok = bool(record["logged_click_card_cost_join"] and same and same_result
              and len(starts) == 1 and before == record["resources_before"]
              and cost == record["effective_cost"] and not index["errors"])
    out.update(controller_join_verified=ok, controller_result_line=number,
               controller_start_line=starts[0][0] if len(starts) == 1 else None,
               previous_same_source_result_line=previous_result or None,
               source_sequence=source.get("srv_seq"),
               controller_join_reason="EXACT_ACTION_ID_SESSION_CARD_COST_RESOURCE_JOIN" if ok
               else "CONTROLLER_SOURCE_OR_COST_MISMATCH")
    candidates = [(n, m) for n, m in index.get("skill_response_metadata", [])
                  if len(starts) == 1 and starts[0][0] < n < number
                  and integer(source.get("srv_seq")) and integer(m.get("server_sequence"))
                  and integer(record.get("post_sequence"))
                  and source["srv_seq"] < m["server_sequence"] <= record["post_sequence"]]
    out["skill_response_metadata_candidates"] = len(candidates)
    # These older dispatcher records have no actor, card or combatSteps.
    # Sequence/line coincidence is retained as a lead, never an effect join.
    out["metadata_only_response_is_effect_binding"] = False
    return out


def label(path):
    try:
        return path.resolve().relative_to(ROOT).as_posix()
    except ValueError:
        return path.resolve().as_posix()


def sha_file(path):
    h = hashlib.sha256()
    with path.open("rb") as stream:
        for chunk in iter(lambda: stream.read(1024 * 1024), b""):
            h.update(chunk)
    return h.hexdigest()


def inventory(roots):
    files = sorted({p.resolve() for r in roots if r.exists() for p in r.rglob("pet_skill_*.jsonl")})
    aliases = defaultdict(list)
    for p in files:
        aliases[sha_file(p)].append(p)
    records, manifest, cache, errors, ignored = [], {}, {}, [], 0
    for sha, copies in sorted(aliases.items()):
        path = min(copies, key=lambda p: (not (p.parent / "combat.jsonl").exists(), label(p)))
        rows, bad = read_rows(path)
        found = analyze_rows(rows)
        if not any(r["family"] in FAMILIES or r["attempted_families"] for r in found):
            ignored += 1
            continue
        manifest[sha] = dict(paths=[label(p) for p in copies], bytes=path.stat().st_size)
        if bad:
            errors.append(dict(path=label(path), lines=bad))
        for record in found:
            record.update(skill_file_sha256=sha, skill_file=label(path), parse_error_lines=bad)
            combat = path.parent / "combat.jsonl"
            if combat.exists():
                if combat not in cache:
                    cache[combat] = combat_index(combat)
                    manifest.setdefault(sha_file(combat), dict(paths=[label(combat)], bytes=combat.stat().st_size))
                idx = cache[combat]
                record.update(controller_join(record, idx))
                record["combat_file"] = label(combat)
                configs = idx["configs"]
                cfg = configs[0] if len(configs) == 1 else {}
                record["configured_route"] = dict(main_pet=cfg.get("main_pet"), evolution=cfg.get("evolution_target"))
                record["recorded_intelligence"] = cfg.get("intelligence")
                record["reasoning_execution_verified"] = False
            else:
                record.update(controller_join_verified=False, controller_join_reason="COMBAT_FILE_ABSENT")
            if bad:
                record.update(logged_click_card_cost_join=False, resource_endpoint_consistent=False,
                              controller_join_verified=False)
                record["reasons"].append("MALFORMED_INPUT_ROWS")
            records.append(record)
    # Equal hashes are aliases. Distinct bytes with the same action are a
    # separate conflict group, never additional independent native samples.
    groups = defaultdict(list)
    for r in records:
        groups[r["action_key"] or r["skill_file_sha256"]].append(r)
    conflicts = [k for k, values in groups.items() if len(values) > 1]
    for k in conflicts:
        for r in groups[k]:
            r.update(logged_click_card_cost_join=False, resource_endpoint_consistent=False,
                     controller_join_verified=False)
            r["reasons"].append("DISTINCT_FILES_SHARE_ACTION_ID_REVIEW_REQUIRED")
    by_family = {}
    for family in sorted(FAMILIES | {"UNKNOWN"}):
        subset = [r for r in records if (r["family"] if r["family"] in FAMILIES else "UNKNOWN") == family]
        by_family[family] = dict(records=len(subset), matches=len({r["match_id"] for r in subset}),
            logged_clicks=sum(r["exact_logged_click"] for r in subset),
            card_cost_joins=sum(r["logged_click_card_cost_join"] for r in subset),
            resource_endpoints=sum(r["resource_endpoint_consistent"] for r in subset),
            controller_joins=sum(r["controller_join_verified"] for r in subset),
            result_kinds=dict(Counter(r["result_kind"] for r in subset)))
    return dict(schema="pokiguard.active_skill_inventory.v1", roots=[label(r) for r in roots],
                input_file_count=len(files), unique_skill_file_hashes=len(aliases),
                duplicate_file_copies=len(files)-len(aliases), excluded_unclassified_files=ignored,
                unique_action_groups=len(groups), conflicting_action_groups=conflicts,
                by_family=by_family, parse_errors=errors, records=records, input_manifest=manifest,
                limitations=["LOCAL_LOG_JOINS_ARE_NOT_ATTRIBUTED_SERVER_EFFECTS",
                             "NET_RESOURCE_DELTA_IS_NOT_THE_SKILL_COST_OR_REFUND",
                             "RECORDED_INTELLIGENCE_IS_NOT_WORKER_EXECUTION_PROOF",
                             "NO_DAMAGE_MODEL_TRAINING_OR_RUNTIME_AUTHORITY"],
                runtime_changed=False, process_attached=False, new_live_attempts=0)


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--root", type=Path, action="append", required=True)
    parser.add_argument("--out", type=Path, required=True)
    args = parser.parse_args()
    out = args.out.resolve()
    if not out.is_relative_to(ROOT):
        parser.error("output must stay inside PokiguardToolV2")
    result = inventory([r.resolve() for r in args.root])
    out.parent.mkdir(parents=True, exist_ok=True)
    out.write_text(json.dumps(result, ensure_ascii=False, indent=2) + "\n", encoding="utf-8")
    print(json.dumps({k: result[k] for k in ("input_file_count", "unique_skill_file_hashes",
                      "duplicate_file_copies", "by_family", "conflicting_action_groups")}, ensure_ascii=True))


if __name__ == "__main__":
    main()
