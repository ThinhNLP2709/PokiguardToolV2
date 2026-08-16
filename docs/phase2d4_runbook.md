# Phase 2D.4 Runbook

Phase 2D.4 is complete. This runbook records the accepted bounded commands; it
does not authorize Phase 2D.5 or unbounded farming.

Run commands from `D:\PokiguardToolV2` with 64-bit Python and Pokiguard in the
foreground. Start only from exact boss lobby. Do not run another automation
controller concurrently.

## Offline Stage A

```powershell
$env:PYTHONPATH = 'src'
python tools/farm_run.py --stage-a-replay --boss-id 1289
```

Expected: sequence-desync and deterministic dead-board recovery-resume cases
pass with `actualWindowsInputs=0`.

## Live Stage B1

```powershell
$env:PYTHONPATH = 'src'
python tools/farm_run.py --stage-b1-recovery-resume --boss-id 1289 `
  --target-matches 3 --max-technical-recoveries 1 --max-match-attempts 5 `
  --post-recovery-test-consuming-actions 1
```

Expected: auto entry, TEST_ONLY recovery, exact re-entry, fresh opening, exactly
one accepted consuming BASIC action, then stop. F9 is emergency stop.

## Live Stage B2

```powershell
$env:PYTHONPATH = 'src'
python tools/farm_run.py --stage-b2-farm --boss-id 1289 `
  --target-matches 3 --max-technical-recoveries 1 --max-match-attempts 5
```

Expected: exactly three completed matches, two between-match re-entries, return
to exact boss lobby, and `FARM_TARGET_COMPLETED`; no entry #4. F7 is disabled.

## Verification

```powershell
$env:PYTHONPATH = 'src'
python -m unittest discover -s tests -v
python -m compileall -q src tools tests
git diff --check
git status --short
```

Accepted live artifacts:

- B1: `logs/farm_runs/fc396e1d55dc455390e752e57eb927b2/`
- B2: `logs/farm_runs/8a5ad3f5d02b4871b0baf1a22935a422/`
