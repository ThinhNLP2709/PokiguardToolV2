# Pet Puzzle — sửa PlayerPrefs và re-entry sau kết trận

Ngày: **2026-10-10 (Asia/Saigon)**.

**Phát hành tiếp theo:** theo yêu cầu người dùng, cùng payload sửa lỗi này đã
được build thành [v1.2.5](v1.2.5_release_report.md). Gói và SHA-256 bên dưới
thuộc bản candidate v1.2.4 trước khi đổi nhãn và được giữ nguyên để đối chiếu.

Trạng thái: **source + kiểm thử offline + đóng gói PASS; live farm trên máy ảo còn chờ xác nhận**. Đây là bản sửa riêng dựa trên source hiện tại, giữ nhãn ứng dụng v1.2.4; không thay thế gói v1.2.4 đã được chấp nhận trước đó.

## Vấn đề và hành vi sau sửa

Run máy ảo `4bf54d3fa8f046239a141ec1448c4d3a` hoàn thành 50/200 rồi dừng tại room lỗi. Tool đã xác định đúng Lieyun 1436 và nút thoát, nhưng đọc cố định PlayerPrefs của Pokiguard cũ, nhận `SelectedPetId=null` rồi từ chối thoát shell. Ngoài ra, vòng lặp hậu trận bỏ sót `GENERAL_HUB_CANDIDATE` dù route từ sảnh chính về Chinh Phục đã có sẵn.

Đã sửa:

1. **PlayerPrefs theo đúng bản game đang attach.** `RuntimeTarget` giữ đường dẫn EXE đã được chọn/xác minh. Reader đọc `<exe-stem>_Data/app.info`, lấy company/product và mở đúng nhánh HKCU. Với Pet Puzzle hiện tại là `Software\Pet Puzzle\Pet Puzzle`. Product cũ được hỗ trợ khi metadata chính bản game đó xác nhận; không thử lấy selection từ khóa Pokiguard cũ để bù cho khóa Pet Puzzle bị thiếu.
2. **Registry thiếu/cũ không phủ quyết bằng chứng memory đầy đủ ở bước thoát shell.** Vẫn kiểm tra đúng stale enemy pet, không có combat owner, room đã mất membership và hai ảnh chứng minh control. Khi map đang active phía sau room, target phải khớp live manager/panel; thay manager/panel hoặc boss vẫn bị từ chối.
3. **Hậu trận phải về đúng phòng boss mới tiếp tục farm.** Sau confirm kết quả và chờ trạng thái ổn định, map Chinh Phục, island, danh sách boss, room shell mất owner hoặc sảnh chính đều đi qua bộ phân loại route phục hồi chung. Sảnh chính không còn bị rơi khỏi allowlist riêng của vòng lặp hậu trận. Khi kết trận đưa thẳng về sảnh, quyền mở Chinh Phục yêu cầu trận đã kết thúc, không còn combat session, confirm đã được ghi nhận là sent và caller đã xác minh đúng hub/control; không cần giả lập technical abort hay một lần thoát shell.
4. **Log trực tiếp khi thiếu phòng boss.** Event mới `postmatch_boss_room_missing` ghi attempt, pass phục hồi, reason/branch, source route và boss ID đã ghim; dùng log farm hiện tại, không thêm worker hoặc tệp log riêng.

Không đổi solver, cách ra nước, QTE, cách click bàn, thứ tự đọc memory/chụp ảnh/action trong các route đang có, bước xác nhận kết quả hoặc cách đếm trận. Không sửa phần độ trễ của lần dừng thứ hai; không tiếp tục Phase 5B.3.

## Vòng lặp hậu trận

```text
Trận kết thúc -> chụp kết quả -> nhấn xác nhận
  -> chờ trạng thái hậu trận/chuyển cảnh ổn định
  -> đúng phòng boss đã ghim, sẵn sàng: tiếp tục vòng farm
  -> ra map/island/danh sách boss/sảnh hoặc còn room shell lỗi:
       ghi postmatch_boss_room_missing
       -> route hiện có: thoát shell nếu cần / mở Chinh Phục / chọn đúng đảo
       -> chọn lại đúng boss đã ghim
       -> xác minh phòng boss trước bước vào trận tiếp theo
```

“Không về phòng boss sau confirm” được xử lý như mất phòng cần phục hồi, không yêu cầu phải còn nhìn thấy boss trong một room trống. Trạng thái đang chuyển cảnh vẫn chờ; ACTIVE/UNKNOWN hoặc con trỏ không đọc được không tự cấp quyền click recovery. Khi không thể chứng minh một route hợp lệ, cơ chế fail-closed hiện có vẫn áp dụng.

Giữ hai route passes có giới hạn như trước, đủ cho map → room shell lỗi → chọn lại mục tiêu. Không thêm vòng retry vô hạn. Các lần điều hướng này không tự tăng completed/attempts hoặc đếm lại kết quả trận vừa xong.

**Bú win guest/Coop:** giữ chế độ bám phòng đã join và dừng khi bị loại/đổi chủ phòng. Bản sửa lần này phục vụ automatic Solo re-entry; không tự tạo phòng thay cho phòng của người khác.

## File triển khai

- [PlayerPrefs reader](/D:/PokiguardToolV2/src/pokiguard_v2/chinh_phuc_map.py:295): resolve registry từ app.info; ghi source/reason khi thiếu metadata/key, không trộn hai product.
- [RuntimeTarget](/D:/PokiguardToolV2/tools/runtime_common.py:81): giữ EXE của đúng process đã attach.
- [Shell-exit validation](/D:/PokiguardToolV2/tools/farm_run.py:1828): dùng stale room identity và current map manager/panel thay veto từ selected pet trong registry.
- [Postmatch recovery](/D:/PokiguardToolV2/tools/farm_run.py:3594): tái sử dụng classifier/route chung, bao gồm general hub. Entry preflight reroute cũng dùng cùng phân loại thay danh sách reason bị thiếu.
- [Hub input permit](/D:/PokiguardToolV2/src/pokiguard_v2/farm_run.py:2024): bổ sung origin `CONFIRMED_POSTMATCH_HUB`, giữ kiểm tra foreground và chỉ cho mở một lần trong cùng attempt. Origin được ghi cùng event cấp quyền click hiện có.

## Kiểm chứng

- Full unittest discovery trên source cuối: **1.872/1.872 PASS**, 62,954 giây. [Log kiểm thử](/D:/PokiguardToolV2/temp/vm_room_recovery_tests_final_20261010.log).
- Nhóm kiểm thử trực tiếp liên quan PlayerPrefs, FarmRun, re-entry và Bú win: **131/131 PASS**.
- Nhóm regression mới: **12/12 PASS**; bao gồm fresh install chỉ có khóa mới, hai khóa mâu thuẫn, không mượn dữ liệu cũ khi khóa mới thiếu, metadata legacy rõ ràng, nhiều data folders, metadata thiếu/sai, các nguồn re-entry và giới hạn retry.
- Kiểm thử đường đi hậu trận → confirm → sảnh → Chinh Phục → chọn boss chạy dispatcher/route/permit thật với I/O giả lập. Ca này tái hiện được lỗi trước sửa và PASS sau sửa; không gửi shell-exit, không tăng technical abort/recovery, giữ đúng một kết quả thắng. Các ca thiếu confirm, thiếu hub proof, đang combat và click hub trùng đều bị chặn.
- [Fixture trận 50 từ log thật](/D:/PokiguardToolV2/tests/fixtures/vm_empty_room_attempt50_20261009.json:1): target 1436, registry không có selection, room mất owner, map active và hai visual proofs. Kiểm tra hiện tại cho phép shell-exit với nguyên bằng chứng đó; không sửa fixture để thêm SelectedPetId.
- Các regression đang có kiểm tra shell click, target click, foreground/pinned preflight, đối chiếu identity sau lấy focus, emergency và Bú win vẫn nằm trong full suite PASS.
- Đọc **chỉ đọc** metadata/registry thật trên máy chính bằng reader mới: source `Software\Pet Puzzle\Pet Puzzle`, SelectedPetId **2534**, group **16**. Khóa cũ SelectedPetId **650** không được dùng. `ActivePanelIndex` hiện chưa có trong khóa mới và được ghi reason; không tự điền giá trị đoán.
- `git diff --check`: PASS (Git chỉ cảnh báo LF/CRLF của các file trong working tree).
- PyInstaller build: PASS.
- Packaged `--packaging-self-check` của EXE dựng lại sau reset: **exit 0**; production graph/resources import thành công, log xác nhận `processAttachment=false`, `windowsInput=false`. [Log self-check](/D:/PokiguardToolV2/temp/vm-room-recovery-packaged-check-after-reset-20261010/logs/startup/startup.jsonl).

Chưa chạy live farm hoặc phát input thử lên game. Kiểm thử từ snapshot chứng minh nhánh từng từ chối đã được sửa; không thay thế nghiệm thu re-entry thật trên VM.

## Gói máy ảo

- [ZIP bản sửa riêng](/D:/PokiguardToolV2/build/v1.2.4-room-recovery-20261010/PokiguardToolV2-v1.2.4-win-x64.zip)
- Dung lượng: **14.228.997 bytes**.
- SHA-256: `95ca2c82dbebc22a6cb00db6dc66c4bba1d416584ea7288594e7e32194f45b69`.
- EXE: `build/v1.2.4-room-recovery-20261010/dist/PokiguardToolV2/PokiguardToolV2.exe`.
- Gói v1.2.4 cũ tại `build/v1.2.4/` được giữ nguyên.
- Gói lấy source hiện tại, bao gồm thay đổi Bú win guest đã được thực hiện ở các lượt trước; không bật reasoning hoặc tự tiếp tục Phase 5B.3.

Giải nén toàn bộ ZIP vào thư mục riêng trên VM, đóng EXE tool cũ rồi chạy EXE trong thư mục mới. Game và dữ liệu registry không cần sửa thủ công. UI vẫn hiển thị v1.2.4; phân biệt bản sửa này bằng thư mục/gói và SHA-256 nêu trên.
