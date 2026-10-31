# Phase 5 — Báo cáo cuối

Ngày 31/10/2026, Asia/Saigon. **ROADMAP COMPLETE — STOP**, trong phạm vi R1 đã
nghiệm thu và các phạm vi được đóng rõ là chưa hỗ trợ. BASIC vẫn mặc định.
Kết quả so sánh hiệu quả là **INCONCLUSIVE**; không có quyết định PROMOTE.
Đóng roadmap không phải phát hành binary hoặc mở suy luận cho mọi cấu hình.

## Kết quả bàn giao

Đã có planner chiến thuật theo PlayStyle, dùng snapshot bất biến và nước BASIC
làm incumbent, tính utility có nhãn bằng chứng/UNKNOWN, kiểm deadline, cô lập
worker và diagnostics. Proposal hợp lệ đi qua preflight/action/ACK cũ. Suy luận
có thể giữ nước BASIC; completed retention khác với timeout/error fallback.

Các pilot source đã kiểm SWAP, thời điểm skill và PASS theo profile riêng.
Package cuối chỉ nghiệm thu **lab opt-in Demon Farm ăn Khiên, Solo Lieyun77**
trên game b12, account/loadout/stats đã pin, ngưỡng4 Kiếm hiệu dụng/sàn2 ô Kiếm.
Tab AI thông thường vẫn khóa chọn nước REASONING. Không có nút public để mở
arbitrary reasoning hoặc hồ sơ được phép dùng lại vô hạn.

[Hướng dẫn sử dụng](USER_GUIDE.md), [rollback](ROLLBACK.md),
[matrix chi tiết](capability_manifest.md), [5F.2 report](reports/5f2_report.md).

## Artifact và nguồn nghiệm thu

| Mục | Danh tính |
|---|---|
| Version/HEAD/branch | v1.2.10 / `c646acfa5e895732bbdade553f9d7bd61171cd29` / `codex/phase3a2-board-repair` |
| Source fingerprint,370 Python files | `f0aeab76e40ffc12fa11692702119d181bc8e869ae44033f7624ec80d1a8018b` |
| Exact test ZIP | `D:/PokiguardToolV2/build/phase5-f1-20261031-acceptance/PokiguardToolV2-v1.2.10-win-x64.zip` |
| ZIP SHA256 | `2a7c74d4a8236a2a58404d8ef057be2c44d141fe0cf90d1d6d75533109fd6515` |
| EXE SHA256 | `a41cb23c55a27b7c45e21b3b92bc26261bd338b80b4125cfb485006fc4184efe` |
| Embedded manifest SHA256 | `1ebdeec72244e2df2c0383213b379b97bf8887b3946c9ec657bea4e6b9f0bcaf` |
| GameAssembly b12 SHA256 | `51eaeff77252e7119647a590c534196093b36e752115b500672f24da758f1064` |

HEAD riêng không mô tả đủ dirty worktree. Hash/source manifest và
[133runtime modules+entry parity](artifacts/5f1_packaged_20261031/acceptance_package_identity.json)
gắn đúng binary. [F1 closure](reports/5f1_report.md) chứa config/model/host/cohort
bindings. Không đổi runtime, build hoặc version trong F2; chỉ kiểm hash file
để đối chiếu tài liệu, không chạy lại harness/game/live.

## Đối chiếu 20 bước chính

| Bước | Kết quả đã đóng | Report |
|---|---|---|
| 5A.1 | Contract BASIC/hard/objective/advisory, DOCS PASS | [A1](reports/5a1_report.md) |
| 5A.2 | Features/utility/profile và evidence scope, DOCS PASS | [A2](reports/5a2_report.md) |
| 5A.3 | Telemetry/deadline/bounded evaluation, DOCS PASS | [A3](reports/5a3_report.md) |
| 5B.1 | Snapshot/replay/provenance, offline PASS | [B1](reports/5b1_report.md) |
| 5B.2 | R1 one-step utility, offline PASS | [B2](reports/5b2_report.md) |
| 5B.3 | Bounded structural refinement, offline PASS; R2 game promotion DISABLED | [B3](reports/5b3_report.md) |
| 5B.4 | Isolated worker/logging/fault/resource component PASS | [B4](reports/5b4_report.md) |
| 5C.1 | Shadow seam, offline PASS | [C1](reports/5c1_report.md) |
| 5C.2 | AI tab/preferences/immutable config, offline UI PASS | [C2](reports/5c2_report.md) |
| 5C.3 | Offline parity và scoped Demon shadow/live closure PASS | [C3](reports/5c3_live_closure_report.md) |
| 5C.4 | Guarded selection/existing preflight, offline PASS | [C4](reports/5c4_report.md) |
| 5D.1 | Historical SIMPLE/CAREFUL R1-retention technical PASS | [D1](reports/5d1_report.md) |
| 5D.2 | Historical HT7 skill/SWAP/PASS technical PASS | [D2](reports/5d2_report.md) |
| 5D.3 | Historical Demon minimum Rage/multiplier technical PASS | [D3](reports/5d3_report.md) |
| 5D.4 | Historical Mega technical PASS + narrow PASS-validator offline fix | [D4](reports/5d4_report.md) |
| 5D.5 | CLOSED_BASELINE_ONLY; Coop reasoning/shadow unsupported | [D5](reports/5d5_report.md) |
| 5E.1 | Comparison closed, technical PASS / efficacy INCONCLUSIVE | [E1](reports/5e1_report.md) |
| 5E.2 | Current b12 Demon reliability PASS STRONG scoped | [E2](reports/5e2_report.md) |
| 5F.1 | Exact package offline+live4 PASS STRONG scoped | [F1](reports/5f1_report.md) |
| 5F.2 | Final docs/guide/rollback, DOCS PASS | [F2](reports/5f2_report.md) |

Không gộp các source/game/cohort thành một thống kê. D5 được đóng bằng exception
có điều kiện của prompt, không suy thành Coop live PASS. Optional5L.1–5L.3 chưa
được kích hoạt và không phải đầu ra bắt buộc. Các P lịch sử không tạo chuỗi bước
mới. Hai tài liệu [nghiên cứu gốc](phase5a0_reasoning_research.md) và
[bổ sung](phase5a0_research_completion_plan.md) giữ nguyên là thiết kế/nghiên cứu;
matrix nghiệm thu hiện tại có ưu tiên khi đọc trạng thái triển khai.

## Matrix profile cuối

| Profile | BASIC | REASONING source theo report gốc | Package cuối/current b12 | Efficacy |
|---|---|---|---|---|
| Đơn giản | Giữ baseline | D1 post-fix3WIN/33completed retention | Ngoài scope R của F1 | Chưa chứng minh vượt BASIC |
| Cẩn trọng | Giữ baseline | D1 3WIN/13completed retention | Ngoài scope R của F1 | Chưa chứng minh vượt BASIC |
| Chịu đấm ăn xôi/HT7 | Giữ baseline | D2 có SWAP/skill/PASS, conditional Perfect, source/card/account/boss pin riêng | Không có current package skill/QTE acceptance | Chưa chứng minh vượt BASIC |
| Demon Farm → Khiên | Current package BASIC2 PASS | D3 minimum + E2 current b12 reliability | Experimental lab R1SWAP, exact scope ở trên; F1 có2trận R đều completed retention | E1 INCONCLUSIVE, BASICdefault |
| Demon → Máu/Mana/Hút/Nộ | Cài đặt BASIC giữ nguyên | Không suy từ Shield acceptance | Unsupported R trong package F1 | NOT_EVALUATED |
| Mega Icarus | Giữ baseline/hotfix bảo vệ | D4 historical skill/cycle adaptation; sau narrow PASS fix chỉ có offline verification | Không current package R acceptance; native emergency/PASS execution chưa prove | Chưa chứng minh tránh chết/hiệu quả |
| Bú win/Coop | Giữ BASIC và nhánh sửa song song; D5 baseline live pending | CLOSED_BASELINE_ONLY | Reasoning và shadow Coop UNSUPPORTED | NOT_APPLICABLE |
| Khủng long | Giữ nhánh BASIC riêng | Không nghiệm thu Phase5 R | Reasoning/shadow UNSUPPORTED | NOT_APPLICABLE |

Các entry BASIC không tự cấp live acceptance mới cho mọi game/boss; phạm vi
baseline còn theo report của nhánh đó. Technical accepted không đồng nghĩa
promotion về hiệu quả hay general public enablement.

## Thích ứng đã có bằng chứng và giới hạn

- **HT7:** DarkQueen110, skill khi6 Kiếm hiệu dụng dưới setting7, đủ chi phí;
  có skill→boss còn sống→fresh SWAP/ACK. PASS có owner/counter thật; thiếu payload
  không đoán bộ đếm. QTE không đổi. [D2](reports/5d2_report.md).
- **Demon:** D3 có3 ôKiếm→4 hiệu dụng nhờx2; có3Kiếm với đủ Nộ từ trước.
  E2 b12 có override turn7/Nộ175/3Kiếm, native sent→same-turn WIN. Không suy
  joint gain-before-damage của3Kiếm+5Nộ cùng đợt hoặc lethal cho account khác.
  [D3](reports/5d3_report.md), [E2](reports/5e2_report.md).
- **Mega chống cứng nhắc:** Small Blue220/JavanIV→Mega, setting6 nhưng skill
  khi seal có5Kiếm hiệu dụng, HP≈87,34%, đủ200Mana/150Nộ; sau đó fresh SWAP/ACK.
  Đây là quyết định linh hoạt trước ngưỡng HP cứng, không phải bằng chứng đã
  tránh một cái chết.2PASS-validation faults đã giữ log; fix sau live chỉ
  offline verified. [D4](reports/5d4_report.md).
- **Retain hợp lệ:** F1 cả2quyết định completed rồi giữ BASIC. Không có quota
  override và không biến retention thành failure fallback. [F1](reports/5f1_report.md).

Known ordinary swaps/cascade/geometry là phạm vi simulator. Boss Sword-first
là working model có điều kiện; boss skill/secondary policy/refill distribution,
damage/heal/survival/effect ordering và post-boss passive residual chưa đủ model
để hứa dụ boss/chừa Khiên chắc chắn. R2, learned model, MCTS/POMCP/online learning
không được bật. Không gán xác suất thắng từ utility hoặc tự train sau mỗi trận.

## Evidence cuối và giới hạn phép đo

E1 b10:10BASIC+10REASONING,20WIN, boards không cặp và actualenergyUNKNOWN;
BASIC17localturns/R23 không chứng minh improvement. E2 b12:5BASIC+20R,25WIN;
47Ractions/46retention+1override,20workers reaped,255AIrecords/0loss.
F1:2BASIC+2R,4WIN/confirm/return;6SWAP=2ACK+4proved terminal exclusions,
2completed Rretention,2workers reaped,12AIrecords/0loss;0observed read/input-safety/
timeout/PASS/abort/recovery. Không cộng các batch làm win-rate tổng.

F1 Rcompute66,3042–77,9866ms, N2; reasoned next-turnACK/skill/QTE/live emergency/
re-entry/fault injection NOT_OBSERVED. Paired added CPU/memory, actual account
energy, nativeU/transport/alignment vẫn chưa đo/UNKNOWN. Source E2 resource/fault
soak và package fault probes giữ origin riêng. Các maxima không là hard bound
tương lai. [Raw F1 closure](artifacts/5f1_packaged_20261031/closure_20261031/closure.json).

Full regression F1 có2779cases và225failure/error events đã audit, không phải
toàn suite green:211unique legacy IDs,1unchanged cold-close timing case,1expected
old E2 boundary rejection. Cold-close0,5s có1/30receipt discard1; không che bằng
cách nới timeout hoặc sửa log. Native F1 thực tế12AIrecords/0loss. Chi tiết trong
[F1 report](reports/5f1_report.md); F2 không chạy lại tests để tạo verdict khác.

## Quy tắc vận hành được giữ

PlayStyle/loadout intent giữ nguyên; tactical thresholds là tham khảo trong
phạm vi R đã chứng minh. Actual legality/source/cost/cooldown/turn/PASS/freshness/
ownership là hard gates. BASIC sẵn trước reasoning; deadline bắt đầu từ
observation gốc, trừ reserve/margin, trả sớm khi xong. Không thêm read/capture
hoặc random reaction/jitter cho receipt hợp lệ; mandatory pacing vẫn còn.

Lỗi/timeout/missing evidence giữ BASIC còn hợp lệ **trước dispatch**. State
không hợp lệ vẫn fail closed; sau input, pending/ACK owner xử lý, không phát
baseline input thứ hai. Log/worker failure có thể tắt AI của phiên, không tự
biến thành PASS/recovery game. Flow farm/action/QTE/reader/Stop giữ owner cũ.

9ZIP rollback nguyên vẹn; không overwrite v1.2.4/releasedv1.2.10, không reset
unrelated source work, không ghi V1/game, không commit/push/tag/build/version/
release. **Không còn prompt bắt buộc; ROADMAP COMPLETE — STOP.**
