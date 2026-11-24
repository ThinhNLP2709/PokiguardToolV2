# Mega Icarus — kiểm 3 BASIC và đường thu skill

**Đã xử lý offline tiếp theo:** [đầu vào Icarus cho lõi chung](ICARUS_COMMON_CORE_EVIDENCE_20261124.md).
7 CommonProblem, receipt tách effect, 28 sensitivity giả lập; không đổi gameplay.

Ngày 24/11/2026, Asia/Saigon. **Đã đóng bài kiểm collector native có phạm vi.**
Solo No. 11 lv185, đảo Thời gian; pet thường → Mega Icarus; skill đủ chi phí,
Tự bảo vệ dưới 30% HP. Không nghiệm thu T-Rex/Galaxy hoặc chất lượng Suy luận.

## Trận đấu và ledger

Run hoàn tất `627ad5a673054761b83accb0508c2e67`:

| Trận | Match | Kết quả | Skill click-only |
|---|---|---|---:|
| 1 | `M_f8131918` | WIN | 2 |
| 2 | `M_7f5ff7f9` | WIN | 1 |
| 3 | `M_9a60a18a` | WIN | 4 |

3/3 hoàn tất, 45 SWAP/45 ACK; 11 lần tiến hóa gồm 3 thành công và 8 kết quả
game báo thất bại. Không technical abort/recovery/safe stop trong run này.
7 skill có một card click, không Arrow/Space; bộ đếm “Perfect” lịch sử không
phải proof QTE PERFECT. Có 2 PASS trong trận 3; thirdPassCount,
wrongThirdPassCount và fake idle đều 0. Rule PASS không đổi.

Run dừng FARM_TARGET_COMPLETED, checkpoint cuối BOSS_LOBBY. Khi đọc lại,
UI ở STOPPED/3 trong 3 và game ngoài phòng; không suy game đã ở ngoài phòng
ngay lúc hoàn tất.

Trước đó có run `c676db24eaed4c8a8dc0c092aae7222f`: 1 attempt chưa hoàn tất,
không skill, dừng F9_EMERGENCY_STOP. Giữ riêng tín hiệu F9, không quy thành
crash hoặc lỗi tự dừng của ba ván sau. Toàn phiên có **4 attempt, 3 completed,
2 lần Start từ UI**; agent không bấm Start hoặc tạo thêm trận. Không xóa/reset
lượt đã tiêu, không mở lại cap cũ; lượt được agent mở tiếp = 0.

## Collector đã thu được gì

7 MATCH_SKILL_USE_RES duy nhất, tổng **53 typed steps**: POWER 7, HEAL 7,
MANA 7, SHIELD 7, BLOCK 5, STEAL 6, DAMAGE 7, LIFESTEAL 7. Đã giữ context
trước primitive, current card MEGA_ICARUS/22, cost 200 Mana/150 Nộ và
response player context. Cost này thuộc cohort hiện tại, không hard-code chung.

Mỗi skill có export checkpoint CHECKED với một retained response. Seq130
của `M_9a60a18a` chỉ được ghi bởi pet_skill_retained_outcome, không có bản
sao từ dispatcher_combat_outcome. Đường export mới ghi được một packet kết
trận trước cleanup mà đường ghi thông thường không ghi lại trong run này.
Không thêm read/poll/wait/input hoặc đổi queue/retention.

Native source `fbf861fd81ff6cb656f8fa84dc6d0676eb965b7f4c50fb4997f2a72b28509c96`,
519 Python files. Ba component collector/controller/tap giữ nguyên hash từ
bản đã mở. Sửa sau khi xem log chỉ thuộc công cụ offline và tests; không
rebind source/profile/admission của gameplay.

## Hai điều chỉnh offline

**Phạm vi excluded:** tool cũ loại mọi skill khi normalizer có bất kỳ
excluded record. Trận 3 có hai MOVE UNAVAILABLE/COMBAT_STEPS_ABSENT nằm ngoài
các cửa sổ skill, làm bốn packet tốt bị loại. Đã sửa phạm vi: missing MOVE
có identity hợp lệ ở ngoài cửa sổ không làm hỏng skill khác. Unknown packet
bên trong cửa sổ, input mâu thuẫn hoặc nhiều response vẫn giữ UNBOUND.
Đây là lỗi công cụ phân tích, không phải lỗi đánh/thu game; legacy SWAP giữ nguyên.

**ID thẻ:** cardId/skillCardId trong projection của cả bảy response đều None.
Log không phân biệt field vắng với null; không kết luận server không có ID
ở vị trí khác. **Strict wire-card binding vẫn 0/7**, không điền ID client
thành ID server.

Thêm review opt-in `--review-client-windows`, xuất array riêng:

- **4 OBSERVED_CLIENT_CARD_WINDOW:** một click/action ID, client card ổn định
  trước/sau, fresh context có checksum, actor/session/sequence đúng và duy nhất;
  retained export khớp source; post-state cùng session, đúng response sequence,
  chuyển một lượt sang boss.
- **3 skill kết trận:** post-state partial/UNKNOWN thiếu mốc sau, vẫn UNBOUND.
  Typed effects vẫn được giữ, không đoán lại để lấp chỗ trống.
- Strict output không đổi. Review ghi wire_card_identity UNKNOWN,
  acknowledged/server_action_echo/training_eligible false, prediction null.
  Đây là liên hệ có điều kiện theo thẻ client, không phải proof wire card/ACK.

## Thu hoạch và điểm chốt

Đã có collector thực tế và bốn cửa sổ chưa kết trận để nghiên cứu cost,
tài nguyên và effect. HEAL và LIFESTEAL là hai step riêng, không gộp tổng HP
tăng thành một công thức Icarus. STEAL có cả MANA và POWER; số viên không
tự bằng tài nguyên ròng khi có cap/spend/transfer. Damage source chưa phân
loại riêng skill/kiếm; không gán tổng DAMAGE batch thành damage thuần skill.

After-response context không thay pre-action/effect-time state. Gear/buff/
crit/full formula cần kiểm riêng. Dữ liệu đã được xem khi phát triển parser,
không phải holdout độc lập. Không fit/deploy model hoặc bật authority mới.

**Đủ đóng kiểm collector Icarus; chưa cần lặp thêm BASIC cùng boss.** Đưa dữ
liệu cho U2/U5/U6 và replay của agent core, không mở suy luận bằng profile
cũ hoặc dùng 3 WIN làm chứng minh AI tối ưu. T-Rex/Galaxy giữ phạm vi riêng.

## Bằng chứng

- [Closure, ledger, packet và manifest raw](artifacts/active_skill_live3_20261123_170223_UTC/review/closure.json).
- [CI sau sửa: 480 tests PASS](artifacts/active_skill_live3_20261123_170223_UTC/review/ci_after_native_review.log).
- [Trận 1](artifacts/active_skill_live3_20261123_170223_UTC/review/627ad5a673054761b83accb0508c2e67_attempt_001_client_window_review.json).
- [Trận 2](artifacts/active_skill_live3_20261123_170223_UTC/review/627ad5a673054761b83accb0508c2e67_attempt_002_client_window_review.json).
- [Trận 3](artifacts/active_skill_live3_20261123_170223_UTC/review/627ad5a673054761b83accb0508c2e67_attempt_003_client_window_review.json).

Không điều khiển thêm game, không build/version/commit/push trong review.
