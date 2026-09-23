# Phase 4A.0 Result Handoff

```text
PROJECT:
PokiguardToolV2

ROADMAP:
Phase 4 — Background Input Beta

LATEST PHASE:
Phase 4A.0 — Background Input Transport Audit

RESULT:
PASS STRONG

SOURCE:
- app/source version: v1.1.0
- base commit: d48e3ecc2c0574758de480e6a2266d48d070ad6d
- phase audit commit: 0e1097def42c476da353ebf5badc4b5aaffc4b66
- branch: codex/phase3a2-board-repair
- pushed: yes, focused audit and final status/report checkpoint
- upstream equality: yes, verified after final push
- worktree: Phase-owned docs only; unrelated AGENTS.md and the private/untracked files listed in STATUS.md are preserved and excluded

SCOPE ACTUALLY COMPLETED:
- audited V1 Beta message sequence, client-coordinate packing, unchecked PostMessage returns, missing primitive ACK, visible capture dependency and test gap
- inventoried every FarmRun/FarmCycle/recovery input domain, two board gestures, Pet Skill card, QTE direction and Space
- mapped current Windows primitive, coordinate space, foreground gate, visual dependency, pre-state and authoritative ACK
- defined separate candidate/hypothesis/stop rules for single click, two-click, drag, directions and Space
- created a bounded user-operated 4A.1 runbook and a 21-entry machine-readable capability matrix
- changed no production code/config and sent no game input

INPUT MODE / CAPABILITY:
- foreground baseline: PASS STRONG, unchanged
- background single click: UNKNOWN; ACK and live hypothesis defined
- background two-click: UNKNOWN; exact SWAP ACK defined
- background drag: UNKNOWN; exact SWAP ACK defined independently
- background card click: UNKNOWN
- background arrows: UNKNOWN; per-direction RAM ACK defined
- background Space: UNKNOWN; same-generation runtime PERFECT ACK defined
- covered-window combat: UNKNOWN; production SWAP still uses screen-DC modal proof
- navigation/re-entry mode: UNKNOWN; current route depends on screen-DC locators
- minimized mode: UNSUPPORTED; current backend rejects IsIconic
- selected branch: not selected before 4A.1/4A.2 live evidence

TRANSPORT EVIDENCE:
- exact HWND/PID: current V2 binds WindowBinding and revalidates PID/geometry; live value NOT_OBSERVED in this audit
- game build fingerprint: Pokiguard 1.7.4-b4, GameAssembly SHA-256 D55BDE20918F65E84700736E0EDE33AA8EE50A10956590D28FB8E53D185B28D6
- transport API/message sequence: current foreground SetCursorPos + mouse_event; V1 candidate WM_MOUSEMOVE/DOWN/UP; drag candidate ordered held-button MOVE + unconditional UP
- client coordinates: exact packing contract documented; current foreground path converts to screen coordinates
- message queue result: NOT_OBSERVED; explicitly not acceptance
- authoritative pre-state: exact session/turn/owner/board/target/card/QTE identity mapped per domain
- authoritative post-state/ACK: fresh session/opening, selectedCards, exact SWAP state, card/Fusion response/state, QTE RAM progress/PERFECT, or lifecycle/room transition by domain
- ACK latency: NOT_MEASURED
- foreground before/during/after: NOT_OBSERVED
- cursor moved: NOT_OBSERVED; 4A.1 requires unchanged cursor
- duplicate/unconfirmed input: zero input sent; runbook forbids retry

QTE EVIDENCE:
- MatchId/session: NOT_OBSERVED in 4A.0
- skillCardId/CardUI identity: code/reverse contract mapped
- QTE generation: exact generation binding mapped
- expected directions: typed Left/Right/Up/Down only
- direction inputs: zero live inputs
- per-direction currentIndex/correctCount ACK: code-confirmed exact +1/+1 plus one matching appended press
- Space inputs: zero live inputs
- timingResult: NOT_OBSERVED
- PERFECT/GOOD/BAD: NOT_OBSERVED; runtime PERFECT is required ACK for Space
- focus takeover: NOT_OBSERVED
- stale/duplicate input: zero

FARMRUN / LIVE:
- FarmRunId: NOT_APPLICABLE
- configuration: audit-only
- target/completed/attempts: NOT_APPLICABLE
- W/L/U: NOT_APPLICABLE
- SWAP/CARD/QTE/PASS counts: 0/0/0/0
- technical abort/recovery: 0
- foreground handoffs: 0
- unexpected foreground takeover: 0
- final lifecycle/controller/UI: unchanged; no runtime launched
- extra attempt: 0

VISUAL DEPENDENCY:
- screen-DC captures used: code audit confirms GetDC(0)+BitBlt in capture_client_rgb
- game covered during capture: NOT_OBSERVED
- capture valid/invalid: covered pixels are not trustworthy by construction; minimized rejected
- native/memory alternative: board/session/turn/ACK are available read-only; several UI/navigation targets still require visual closure
- stale visual proof: forbidden by runbook

CRITICAL SAFETY:
- wrong HWND/PID: 0 live input
- wrong-turn input: 0
- partial input: 0
- duplicate input: 0
- stale input: 0
- input after stop ACK: 0
- unconfirmed input retried: 0
- board/QTE ACK conflict: 0
- terminal conflict: 0
- orphan controller/poller: 0

TESTS:
- focused: NOT_REQUIRED; docs-only audit, no code/config changed
- full regression: NOT_REQUIRED; docs-only audit
- compileall: NOT_REQUIRED; no Python changed
- git diff --check: PASS for phase-owned checkpoint
- deterministic/replay: JSON parse, enum coverage and local-link validation PASS

DOCS / ARTIFACTS:
- report: docs/phase4/phase4a0_report.md
- runbook: docs/phase4/phase4a0_live_probe_runbook.md
- audit: docs/phase4/phase4a0_transport_audit.md
- capability matrix: docs/phase4/artifacts/phase4a0_capability_matrix.json
- logs: NOT_APPLICABLE; zero live execution
- STATUS.md updated: yes
- capability matrix updated: yes

KNOWN UNKNOWN / NOT_OBSERVED / UNSUPPORTED:
- every background delivery claim remains UNKNOWN until 4A.1/4A.2
- two-click and drag may produce different Unity behavior
- Input.GetKeyDown may ignore targeted posted key messages
- covered navigation has no accepted offscreen visual/native replacement
- minimized operation is UNSUPPORTED

BLOCKERS:
- none for isolated 4A.1 mouse harness/live probe
- production background integration remains gated by later live evidence

ROUTER DECISION:
- current phase result: Phase 4A.0 PASS STRONG
- next prompt: prompts/4A1_BACKGROUND_MOUSE_LIVE_PROBE.md
- reason: inventory, exact ACKs, separate hypotheses, visual boundary, runbook and evidence matrix are complete
- return gate for remediation: not applicable
```
