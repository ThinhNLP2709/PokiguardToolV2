# 5C.4 — Frozen offline selection protocol

2026-10-11. Parent: C3 PASS_OFFLINE_LIVE_PENDING. This protocol is fixed before
recording C4 timing/qualification. No game/process attach, native input, live,
build, release or version change. All native surfaces are explicit fakes.

Scope: completed R1 ordinary SWAP→SWAP, Simple/Careful, Normal/Normal/default
attack only. All production selection is gated. Synthetic Health proxy and
500/2000ms reserves exercise software contracts; neither is game calibration.
R2, other profiles, skill/card/PASS/Evolution ownership and shadow promotion
remain unsupported. Default None must import/create no reasoning resource.

Required evidence:

- Execute archived pre-C4 controller and current controller on identical
  normal/stale/wrong-owner/pending/Stop fixtures. Compare full result/call
  order/gameplay JSON rows, normalizing only the log pathname as C3 did.
- Real R1 result, not a hard-coded preferred move, must override real BASIC in
  the current controller and receive exact fake durable ACK. Calls/read/capture
  order must match the archived controller. Test both supported profiles.
- Bind job/generation/snapshot/config, full controller source hash, capability
  model/scope and absolute timing. Reject malformed, near-tie, missing/unsupported,
  stale, late, insufficient reserve, Stop/pending and diagnostics failures.
- At fresh checkpoint, failure may rebind the existing unsent reservation to
  fresh BASIC. Once mapped/reserved at the final checkpoint, a new invalidation
  cancels through existing preflight flow; the next existing iteration may use
  BASIC. Never map/send an alternative after a sent or uncertain input.
- Reconstruct controller AST by removing only the four optional C4 blocks,
  two local assignments and one keyword. Require equality to archived source.
  Pin changed controller bytes separately; do not rewrite historical C3 evidence.
- All 257 parent Python sources must remain byte-identical except controller
  seam and test fixture/audit helper. Freeze all resulting source hashes.
- Full regression with PYTHONPATH=src;tests must pass.

Timing uses native perf_counter_ns around the host checkpoint only, with a
completed immutable fixture prepared beforehand. Report nearest-rank p50/p95/
p99/max and all samples; do not remove OS tails or rerun a failed block to PASS.
3 blocks ×1000 ready root/fresh/final triples. Adapter/buffer construction and
draining happen outside each measured triple. Test-log bytes remain bounded.
Report each stage plus triple; A3 ready-selection proposal SLO (1/2/5/20ms)
applies to the triple as a conservative offline boundary check. This is not an
end-to-end game timing guarantee or input-reserve calibration.

Fault-known→BASIC:30 trials each no-completed, expired, config changed, source
changed, owner unavailable, diagnostics disabled, queue full, enqueue exception,
selector exception. A3 disposition SLO1/5/10/25ms. Stop:100 signal-only trials,
no queue flush/join; record safety independently. No new worker lifecycle is
introduced; B4/C3 worker evidence stays historical and is not re-certified.

C4 logging uses an externally owned bounded try-lock DiagnosticBuffer, at most
8 small records/second. No new writer/backend; disk, CPU/RAM soak and UI/live
latency are not re-qualified here. C1/C3 separate capped sink remains the
production shadow policy. C4 production wiring remains gated until acceptance.

Result route: C4 offline PASS STRONG can only choose C3 live closure while that
parent gate is pending. D1 is not authorized or run by this protocol.
