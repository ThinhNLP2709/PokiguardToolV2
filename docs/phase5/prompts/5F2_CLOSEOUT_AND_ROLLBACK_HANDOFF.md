# 5F.2 — Closeout và bàn giao cuối Phase 5

Đây là prompt thực thi **một bước**, chỉ dùng khi người dùng yêu cầu chạy bước
này. Đọc prompt để chuẩn bị không phải lệnh triển khai.

## Đọc trước

- `D:/PokiguardToolV2/AGENTS.md` hoặc chỉ dẫn AGENTS người dùng cung cấp.
- [STATUS](../STATUS.md), [ROUTER](../ROUTER.md), [EXECUTION_CONTRACT](../EXECUTION_CONTRACT.md).
- [Nghiên cứu gốc](../phase5a0_reasoning_research.md) và [bổ sung](../phase5a0_research_completion_plan.md).
- [capability_manifest.md](../capability_manifest.md).
- [HANDOFF_TEMPLATE.md](../HANDOFF_TEMPLATE.md).
- [DECISIONS.md](../../DECISIONS.md).
- [basic_gameplay_policy.md](../../basic_gameplay_policy.md).
- [v1.2.4_release_report.md](../../v1.2.4_release_report.md).
- Report cha trong `docs/phase5/reports/`; nếu chưa có thì chưa đạt entry gate.

## Entry và mục tiêu

Mode: **DOCS**. 5F.1 PASS STRONG cho declared scope; không còn required gate pending trong phạm vi công bố.

Đóng Phase5 bằng tài liệu trung thực, hướng dẫn sử dụng/rollback; không tự publish hay sửa runtime.

## Thực hiện trong phạm vi

1. Đối chiếu reports A1→F1, optional model nếu có, với source/artifact/config/hash final. Không chạy lại code/test/gameplay harness chỉ để điền closeout.

2. Final matrix từng profile: BASIC accepted, reasoning technical accepted, efficacy PROMOTE/INCONCLUSIVE/NO_PROMOTION, model scope, live pending/unsupported. Không dùng nhãn chung 'all reasoning accepted' để che Coop.

3. Tóm tắt anti-rigidity Mega và các override có evidence, limits R1/proxy/UNKNOWN; nêu baseline fallback chỉ trước dispatch và state-valid gates.

4. Viết user guide AI settings/advisory semantics, enable/disable, diagnostics vị trí/filter/dropped counters, budget và fallback reason. Không lộ implementation vô ích vào flow sản phẩm.

5. Viết rollback: tắt reasoning về BASIC, giữ prefs phù hợp, artifact v1.2.4 rollback riêng nếu needed. Không reset source/unrelated work hoặc tự overwrite binaries.

6. Cập nhật canonical docs phần REASONING đã accepted và Phase5 README/STATUS/ROUTER/capability manifest; giữ historical reports/proposed research phân biệt accepted behavior.

7. Nếu required packaged/live/reliability evidence còn thiếu: PARTIAL và quay đúng parent; không đóng vì hết thời gian hoặc prompt đã viết xong.

8. Nếu đủ: ghi ROADMAP COMPLETE — STOP. Không commit/push/tag/version bump/release; phát hành cần yêu cầu riêng.

## Gate bắt buộc

- Mọi claim map tới report/source/hash/scope; unsupported và INCONCLUSIVE giữ nguyên.
- Có user guide/diagnostics/rollback, BASIC giữ default; PROMOTE là scoped opt-in.
- Zero runtime/code changes trong closeout; không tự triển khai nhánh mới.
- Giữ contract: BASIC accepted, flow read/capture/action/ACK không đổi; fallback
  chỉ trước dispatch và qua preflight hiện có; log/worker lỗi không block action.
- Không commit/push/tag/version bump/release; không tự chạy bước kế tiếp.

## Đầu ra và STOP

- docs/phase5/FINAL_REPORT.md
- docs/phase5/USER_GUIDE.md
- docs/phase5/ROLLBACK.md
- Canonical/status/router updates phản ánh evidence thực tế.
- Report `docs/phase5/reports/5f2_report.md` theo [HANDOFF](../HANDOFF_TEMPLATE.md);
  update STATUS và router theo bằng chứng, không dùng PASS cho evidence còn thiếu.
- Nếu đủ gate, ghi **ROADMAP COMPLETE — STOP**; không còn next prompt bắt buộc.
  Chưa đủ: cùng bước hoặc remediation/targeted evidence,
  ghi parent/return gate; không advance.
