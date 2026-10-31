# 5F.1 — Packaged acceptance

Đây là prompt thực thi **một bước**, chỉ dùng khi người dùng yêu cầu chạy bước
này. Đọc prompt để chuẩn bị không phải lệnh triển khai.

## Đọc trước

- `D:/PokiguardToolV2/AGENTS.md` hoặc chỉ dẫn AGENTS người dùng cung cấp.
- [STATUS](../STATUS.md), [ROUTER](../ROUTER.md), [EXECUTION_CONTRACT](../EXECUTION_CONTRACT.md).
- [Nghiên cứu gốc](../phase5a0_reasoning_research.md) và [bổ sung](../phase5a0_research_completion_plan.md).
- [v1.2.4_release_report.md](../../v1.2.4_release_report.md).
- [5a3_telemetry_deadline_acceptance.md](../specs/5a3_telemetry_deadline_acceptance.md).
- [capability_manifest.md](../capability_manifest.md).
- Report cha trong `docs/phase5/reports/`; nếu chưa có thì chưa đạt entry gate.

## Entry và mục tiêu

Mode: **PACKAGED_LIVE**. 5E.2 PASS STRONG, scope freeze; baseline v1.2.4 accepted artifact và rollback giữ được.

Build và nghiệm thu đúng một artifact/hash, kiểm packaging không phá BASIC/fallback/log isolation.

## Thực hiện trong phạm vi

1. Dùng packaging flow hiện có, ghi source HEAD + worktree/source fingerprint, config/model hashes/dependencies. Build ra đường dẫn artifact riêng, không overwrite accepted v1.2.4 và không tự bump version/tag/release.

2. Kiểm clean launch/old prefs/BASIC default, disabled no worker, opt-in accepted profiles và diagnostics UI. Worker spawn/paths/model assets chỉ có nếu selected; không tự tải dependency/model lúc game đang chạy.

3. Verify log path writable/rotation/queue errors packaged, IPC/cancel/shutdown/Stop và fallback offline bằng focused package checks.

4. Full regression phù hợp final integration; test results phải map đúng source. Artifact đổi sau fix thì hash mới và revalidate scope ảnh hưởng, không trộn evidence của binary cũ.

5. Nếu live activated: BASIC control2 + accepted REASONING2 attempts, tổng cap4; profile/mode có representative skill/action path, QTE nếu applicable. Chưa đủ domain thì NOT_OBSERVED và bổ sung protocol có cap trước, không tự thêm matches.

6. Kiểm source/package action/ACK/read/capture/lifecycle parity, latency/log path/worker cleanup trên artifact thật. Source-only pass không thay packaged proof.

7. Giữ rollback artifact/config instructions rõ: disable reasoning → BASIC accepted; rollback binary riêng nếu necessary. Không copy file vào game/reference workspaces.

8. Live chưa activated/evidence thiếu: report PARTIAL packaged-live-pending. Không release hoặc gọi roadmap complete.

## Live gate chung

Chỉ chạy live khi người dùng kích hoạt batch bước này và chuẩn bị game.
Chưa kích hoạt: làm runbook/offline thuộc scope, ghi live PENDING và STOP.
Người dùng vận hành game; không computer-use tự chơi. Không extra reads/captures
và không inject fault gây input sai. Stop/user abort hoặc wrong-turn/stale/
duplicate/ownership/ACK conflict/flow regression phải dừng batch ngay.
Mọi invalid/abort đều tính vào cap; tăng cap cần yêu cầu mới.

## Gate bắt buộc

- Exact artifact/hash và tested config/capability mapping, accepted v1.2.4 không bị thay thế.
- Packaged BASIC/fallback/logging/worker parity đủ; zero critical regression.
- Phạm vi advertised có evidence, chưa có live thì không PASS STRONG package.
- Giữ contract: BASIC accepted, flow read/capture/action/ACK không đổi; fallback
  chỉ trước dispatch và qua preflight hiện có; log/worker lỗi không block action.
- Không commit/push/tag/version bump/release; không tự chạy bước kế tiếp.

## Đầu ra và STOP

- Artifact riêng + hash/source manifest, packaged acceptance report.
- Rollback instructions và final accepted/experimental/unsupported matrix.
- Report `docs/phase5/reports/5f1_report.md` theo [HANDOFF](../HANDOFF_TEMPLATE.md);
  update STATUS và router theo bằng chứng, không dùng PASS cho evidence còn thiếu.
- Nếu đủ gate, chọn [5F.2](5F2_CLOSEOUT_AND_ROLLBACK_HANDOFF.md) làm
  next prompt rồi **STOP**. Chưa đủ: cùng bước hoặc remediation/targeted evidence,
  ghi parent/return gate; không advance.
