# B14: nhận diện màn thua — 01/11/2026

User cung cấp ảnh `codex-clipboard-256cdf16-1436-4c04-8db7-344924344ead.png`
và yêu cầu cập nhật cả màn Thua. Đây là nhánh thích ứng giao diện B14, không
thay đổi lối chơi hoặc mở thêm live attempts.

## Evidence và thay đổi

Ảnh gốc1289×656 có thanh tiêu đề20px và border/desktop bên phải. Giữ nguyên
ảnh gốc `defeat_window.png`; fixture `defeat.png` chỉ lấy vùng game quan sát
được `[0,20,1279,656]`,1279×636. Không suy ra kích thước client đầy đủ hoặc
coi ảnh crop/resample là capture native mới của tool. Hash/crop/provenance tại
`tests/fixtures/petpuzzle_b14_result_20261101/defeat_provenance.json`.

Mẫu cũ không nhận được crest Thua ở vùng cũ; B14 còn có góc vàng được tô tối/
trong suốt nên chỉ đếm highlight sáng là không đủ. Bản sửa:

- Giữ hai sừng tím độc lập, dùng vị trí B14 của khiên treo và chữ Thua.
- Với B14, nhận sắc vàng ấm có shading; bắt buộc diện tích đủ ở cả bốn góc.
  Tăng lại gate diện tích từ ngưỡng highlight B14 nhỏ lên gate đầy đủ như
  layout cũ; không dựa vào vài pixel vàng sáng. Không thay color gate cũ.
- Giữ khung xanh, duy nhất một nút xanh đúng hình/vị trí và nhãn trắng đã hiện.
- Đúng POSTMATCH authority, stable frames, fresh preflight, một click, timeout,
  phân loại thắng/thua theo nguồn game và return/re-entry không đổi.

Trên fixture Thua, detector trả `PETPUZZLE_B14_RESULT / DEFEAT_PURPLE_CREST`,
tâm nút≈`(0.49961,0.84119)` của ảnh crop. Đây là measurement, không phải tọa
độ click hardcode. Mẫu thắng vẫn nhận đúng, ảnh hộp quà chưa có nút bị loại.

Source delta chỉ ở ba hàm visual trong `postmatch_ui.py` (một phần là sửa
docstring). `provenance.json.followup_source_change` pin before/after riêng;
source đã live thắng B1 trước đó và constant-only migration được giữ nguyên
ý nghĩa lịch sử, không rebind bằng chứng AI/timing.

## Kiểm tra

**34 visual tests +55 integration/regression tests PASS**:

- Ảnh Thua do user cung cấp; bốn profile được resample, không phải4live runs.
- Thiếu từng sừng/crest/chữ/góc vàng/panel/nút/nhãn, hai nút và popup khác
  đều không cấp input. Stable-frame rule giữ nguyên.
- `_confirm_postmatch` thật với executor giả chờ nút hiện rồi click đúng1lần,
  giữ LOSS1/WIN0; regression tương ứng WIN và layout thắng/thua cũ cùng PASS.
- Exact B14 fields/native/source proofs, legacy victory, terminal accounting
  và bootstrap/re-entry owner cùng PASS. Không sửa controller gameplay.

Màn thua B14 đã kiểm offline qua ảnh và fake executor; **chưa kiểm click Đồng ý
thua bằng live tool**. Không tự tạo trận thua hoặc tăng cap để lấy bằng chứng.
Evidence local: `docs/artifacts/game_1_7_4_b14_loss_20261101/`.

## B1 thắng trước khi thêm mẫu Thua

Phiên `b87f39b5c10f4aedab01fab0a9ceb528`, match`M_1785bd60`, source
`fb856509fcd6721266543f30e9ebbe8aca787cb22c2dc0f3b8b0c345063027d0`:
**PASS vòng WIN → xác nhận → về phòng**.22:17:01 thấy nút,22:17:03 ổn định/
click1lần,22:17:08 về đúng Coop_364884/Lieyun77/Demon Aegis560. Tool kết thúc
`FARM_TARGET_COMPLETED`,1attempt/1WIN, technical abort0, safety counters0.
Ledger riêng swap-ACK=0 do terminal đến trước khi có ACK riêng; không tự gán
ACK. B1 đầu đã lưu exact move ACK độc lập. Không suy ra timing/AI acceptance.

Acceptance JSON ở `game_1_7_4_b14_result_20261101/b1_retest_acceptance.json`.
Phiên3BASIC sau đó đã3WIN,3confirm/3return, safety/technical abort0; run
`73391a59fcfe4830a825e80220dd9c9e`, sourcea330e839… giữ nguyên trong phiên.
Acceptance ở `game_1_7_4_b14_loss_20261101/b2_acceptance.json`. Cả3trận thắng,
click thua live/card/QTE/re-entry cưỡng bức chưa phát sinh. Chưa build.
