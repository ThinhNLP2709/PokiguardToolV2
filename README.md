# PokiguardToolV2

## Mở tool trên Windows

Chạy [run_tool.bat](run_tool.bat) từ thư mục gốc project. Launcher sẽ:

- chạy đúng từ thư mục `PokiguardToolV2`;
- ưu tiên Python x64 trong `.venv`, sau đó dùng Python đã cài trên máy;
- chặn mở hai Desktop UI/controller cùng lúc;
- tạo artifact riêng theo thời gian cho mỗi lần mở;
- chỉ mở UI, không tự động Start hoặc Resume farm.

Game phải được mở sẵn. Để Start một farm session mới, user vẫn phải ở đúng
boss lobby; UI sẽ tự xác minh lại lifecycle và target trước khi cho phép Start.

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
[docs/phase2e3_report.md](docs/phase2e3_report.md) for the latest accepted
milestone.

## Current status

Phase 2E.3 has reached **PASS STRONG**:

```text
compact Desktop UI
-> exact current-room target pin
-> finite autonomous FarmRunner
-> read-only game state + existing solver
-> normal foreground input
-> session-pinned technical recovery/re-entry
-> exact 25 completed matches
-> clean boss-lobby stop and UI shutdown
```

The accepted live soak completed 25/25 STRONG/CONSISTENT WIN results in 27
attempts, including two naturally recovered dead boards, with zero wrong-turn,
duplicate, stale or rejected gameplay inputs.

Runtime logs and screenshots under `logs/` are intentionally excluded from Git
because they are large, machine/session-specific diagnostic artifacts.

## Tests

From the project root:

```powershell
python -m unittest discover -s tests -v
```

The Phase 2E.3 baseline passes 725 tests.
