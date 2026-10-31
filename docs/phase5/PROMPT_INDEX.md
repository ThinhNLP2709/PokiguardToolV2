# Phase 5 — Danh mục prompt chính đã đóng

<!-- F2_CLOSED_20261031 -->
**31/10/2026: ROADMAP COMPLETE — STOP.** Cả20bước chính đã có report/closure;
5D.5 đóng theo scope BASELINE_ONLY, không phải CoopRlivePASS.
[Đối chiếu kết quả](FINAL_REPORT.md), [status](STATUS.md), [guide](USER_GUIDE.md),
[rollback](ROLLBACK.md). **Không còn next prompt bắt buộc.**

Các prompt dưới là lịch sử/phạm vi thực thi từng bước, không lệnh chạy lại
batches đã đóng. 5L.1–5L.3 chưa được kích hoạt và không bắt buộc cho closeout.
[Danh mục trước F2](artifacts/5f2_closeout_20261031/before/docs/phase5/PROMPT_INDEX.md)
giữ các mốc chuẩn bị cũ.
| Thứ tự | ID | Prompt | Mode |
|---|---|---|---|
| 1 | 5A.1 | [Chốt baseline v1.2.4 và ranh giới REASONING](prompts/5A1_BASELINE_AND_REASONING_CONTRACT.md) | DOCS |
| 2 | 5A.2 | [Đặc tả suy luận thích ứng theo PlayStyle](prompts/5A2_ADAPTIVE_PLAYSTYLE_AND_FEATURE_SPEC.md) | DOCS |
| 3 | 5A.3 | [Chốt log, deadline và protocol đánh giá](prompts/5A3_TELEMETRY_LATENCY_AND_ACCEPTANCE_SPEC.md) | DOCS |
| 4 | 5B.1 | [Snapshot/replay/telemetry offline](prompts/5B1_OFFLINE_SNAPSHOT_REPLAY_AND_TELEMETRY.md) | OFFLINE |
| 5 | 5B.2 | [Planner utility thích ứng offline](prompts/5B2_OFFLINE_ADAPTIVE_UTILITY_PLANNER.md) | OFFLINE |
| 6 | 5B.3 | [Refinement boss reply và uncertainty có giới hạn](prompts/5B3_BOUNDED_REPLY_AND_UNCERTAINTY_REFINEMENT.md) | OFFLINE |
| 7 | 5B.4 | [Runner cô lập lỗi và logging có giới hạn](prompts/5B4_ISOLATED_RUNNER_AND_FAILURE_LOGGING.md) | OFFLINE |
| 8 | 5C.1 | [Nối shadow tại ranh giới chọn action hiện có](prompts/5C1_SHADOW_DECISION_SEAM_ADAPTER.md) | SHADOW_ADAPTER |
| 9 | 5C.2 | [Tab AI/config bất biến và tương thích preferences](prompts/5C2_AI_SETTINGS_AND_IMMUTABLE_RUN_CONFIG.md) | OFFLINE_UI |
| 10 | 5C.3 | [Chứng minh BASIC/shadow/fallback không đổi flow](prompts/5C3_BASELINE_SHADOW_AND_FAULT_ACCEPTANCE.md) | BASELINE_LIVE_OPTIONAL |
| 11 | 5C.4 | [Nối proposal REASONING vào preflight cũ](prompts/5C4_GUARDED_SELECTION_AND_EXISTING_PREFLIGHT.md) | OFFLINE_INTEGRATION |
| 12 | 5D.1 | [Pilot SIMPLE/CAREFUL](prompts/5D1_SIMPLE_CAREFUL_PILOT.md) | BOUNDED_LIVE |
| 13 | 5D.2 | [Acceptance Chịu đấm ăn xôi](prompts/5D2_SKILL_RUSH_ACCEPTANCE.md) | BOUNDED_LIVE |
| 14 | 5D.3 | [Acceptance Demon Aegis](prompts/5D3_DEMON_AEGIS_ACCEPTANCE.md) | BOUNDED_LIVE |
| 15 | 5D.4 | [Acceptance Mega Icarus và chống cứng nhắc](prompts/5D4_MEGA_ICARUS_ADAPTIVE_SURVIVAL_ACCEPTANCE.md) | BOUNDED_LIVE |
| 16 | 5D.5 | [Acceptance Coop Bú win có điều kiện](prompts/5D5_CONDITIONAL_COOP_BU_WIN_ACCEPTANCE.md) | CONDITIONAL_LIVE |
| 17 | 5E.1 | [So sánh hiệu quả gameplay có giới hạn](prompts/5E1_BOUNDED_GAMEPLAY_COMPARISON.md) | BOUNDED_LIVE |
| 18 | 5E.2 | [Soak độ ổn định và fallback](prompts/5E2_RELIABILITY_AND_FALLBACK_SOAK.md) | BOUNDED_LIVE |
| 19 | 5F.1 | [Packaged acceptance](prompts/5F1_PACKAGED_ACCEPTANCE.md) | PACKAGED_LIVE |
| 20 | 5F.2 | [Closeout và bàn giao cuối Phase 5](prompts/5F2_CLOSEOUT_AND_ROLLBACK_HANDOFF.md) | DOCS |

Nhánh model chỉ khi được yêu cầu:
- [5L.1 — offline model](prompts/5L1_OPTIONAL_LEARNED_MODEL_OFFLINE.md).
- [5L.2 — shadow model](prompts/5L2_OPTIONAL_LEARNED_MODEL_SHADOW.md).
- [5L.3 — bounded model pilot](prompts/5L3_OPTIONAL_LEARNED_MODEL_BOUNDED_PILOT.md).
- Sau L3 quay lại E1, không nhảy thẳng sang đóng gói.

Template cho nhánh phụ:
- [Remediation](prompts/REMEDIATION_TEMPLATE.md).
- [Targeted evidence](prompts/TARGETED_EVIDENCE_TEMPLATE.md).

Tổng: **20 prompt chính + 3 prompt model tùy chọn + 2 template**.

P1–P29 là lịch sử sửa thiếu sót của D1, không phải chuỗi roadmap bắt buộc mới. [Index trước consolidation](artifacts/5d1_offline_closeout_v1/before_docs/PROMPT_INDEX.md).
