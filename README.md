# PokiguardToolV2

## Mở tool trên Windows

### Bản portable Release Candidate Phase 2F.2

Build chuẩn tạo một bundle Windows x64 không cần cài Python:

```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File .\scripts\build_windows.ps1
```

Artifact build mặc định:

```text
%LOCALAPPDATA%\PokiguardToolV2\package-builds\v1.0.0+15\
PokiguardToolV2-v1.0.0+15-win-x64.zip
```

Giải nén toàn bộ ZIP rồi chạy `PokiguardToolV2.exe`. Không tách riêng EXE ra
khỏi thư mục `_internal`. Runtime data được ghi dưới
`%LOCALAPPDATA%\PokiguardToolV2`, không ghi cạnh EXE, vào source repository hay
thư mục game. Release Candidate đã được clean-build và live-validate từ commit
`1dd53340e20ca405c0bf446682b3fcbf823afe62`. SHA-256 của RC được chấp nhận:

```text
e077a74827478d78bea99200c247f14ba787179352db59a0148bf58d08594a69
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

See [AGENTS.md](AGENTS.md) for workspace rules, the
[Phase 2F.2 report](docs/phase2f2_report.md),
[Phase 2F.2 runbook](docs/phase2f2_runbook.md), and
[release manifest](release/phase2f2_manifest.json) for final RC evidence.

## Current status

Phase 2F.1 remains the latest formally accepted phase (**PASS STRONG**).
Phase 2F.2's same-binary RC passed clean staging and all packaged-live stages
B1-B6, including:

```text
read-only attach smoke
-> bounded 10-WIN farm with evidence-backed technical recovery
-> graceful stop
-> checkpoint resume
-> immediate Emergency stop with zero post-ACK input
-> clean shutdown and unchanged game/package hashes
```

Phase 2F.2 has reached **PASS STRONG** and the finite BASIC scope is complete.
The previously untracked QTE reverse report was preserved byte-for-byte in a
separate documentation commit with explicit user authorization before the
release boundary; it was not mixed into the RC artifact or runtime graph.
Canonical release tag: `v1.0.0+15`.

Supported scope remains finite BASIC farming, exact-room session pinning,
read-only state acquisition, normal foreground input, bounded technical
recovery, graceful checkpoint resume, and Emergency stop. REASONING,
unbounded farming, automatic game launch/restart or login, target rotation,
memory writes, and network manipulation remain unsupported.

Runtime logs and screenshots under `logs/` are intentionally excluded from Git
because they are large, machine/session-specific diagnostic artifacts.

## Tests

From the project root:

```powershell
python -m unittest discover -s tests -v
```

The Phase 2F.2 RC baseline passes 740 tests; the focused release suite passes
14/14. Exact build and acceptance steps are in the
[Phase 2F.2 runbook](docs/phase2f2_runbook.md).
