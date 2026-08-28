# PokiguardToolV2

## Mở tool trên Windows

### Bản portable Phase 2F.1

Build chuẩn tạo một bundle Windows x64 không cần cài Python:

```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File .\scripts\build_windows.ps1
```

Artifact mặc định:

```text
%LOCALAPPDATA%\PokiguardToolV2\package-builds\v1.0.0+15\
PokiguardToolV2-v1.0.0+15-win-x64.zip
```

Giải nén toàn bộ ZIP rồi chạy `PokiguardToolV2.exe`. Không tách riêng EXE ra
khỏi thư mục `_internal`. Runtime data được ghi dưới
`%LOCALAPPDATA%\PokiguardToolV2`, không ghi cạnh EXE, vào source repository hay
thư mục game. SHA-256 của artifact Phase 2F.1:

```text
b8aed614f43d3550ef1d8dd6d88d3d3dbdb76547f63d5b9b4144bca89f5e1d05
```

### Chạy source/developer

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
[docs/phase2f1_report.md](docs/phase2f1_report.md) for the latest accepted
milestone.

## Current status

Phase 2F.1 has reached **PASS STRONG**:

```text
portable one-folder Windows package
-> no Python/source-tree runtime dependency
-> read-only game attach
-> finite autonomous FarmRunner
-> normal foreground input
-> packaged bounded completion and graceful stop
-> writable state isolated under local app data
```

Packaged live B4 completed one STRONG/CONSISTENT WIN after one naturally
recovered dead board and created no attempt after target. Packaged live B5
accepted the UI Stop After Current Match command during combat, completed the
current WIN, created no next attempt and stopped at exact boss lobby. Final
build `v1.0.0+15` also passes clean staging, game-absent startup, checkpoint
path integration and write-location audit.

Runtime logs and screenshots under `logs/` are intentionally excluded from Git
because they are large, machine/session-specific diagnostic artifacts.

## Tests

From the project root:

```powershell
python -m unittest discover -s tests -v
```

The Phase 2F.1 baseline passes 740 tests. Build and packaged validation details
are in [the Phase 2F.1 runbook](docs/phase2f1_runbook.md).
