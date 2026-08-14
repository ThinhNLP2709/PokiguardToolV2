# PokiguardToolV2

PokiguardToolV2 is the second-generation automation research project for the
Windows x64 Unity IL2CPP game Pokiguard.

The current architecture reads client state externally and read-only, adapts it
to the established V1 solver, and uses normal foreground Windows input. The V1
computer-vision path remains available as a fallback.

## Safety boundary

- no game-file modification or binary patching;
- no `WriteProcessMemory`, injection, remote thread, or hook;
- no direct Unity gameplay-method invocation;
- no packet or network manipulation;
- no HP, damage, reward, or server-authoritative state modification.

See [AGENTS.md](AGENTS.md) for workspace rules and
[docs/phase2d1_report.md](docs/phase2d1_report.md) for the latest accepted
milestone.

## Current status

Phase 2D.1 has reached **PASS STRONG**:

```text
boss lobby
-> exact target identification
-> one normal UI entry click
-> new combat session
-> stable opening board 64/64
-> stop before gameplay
```

Runtime logs and screenshots under `logs/` are intentionally excluded from Git
because they are large, machine/session-specific diagnostic artifacts.

## Tests

From the project root:

```powershell
python -m unittest discover -s tests -v
```

The Phase 2D.1 baseline passes 310 tests.
