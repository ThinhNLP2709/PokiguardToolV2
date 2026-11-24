# Skill Mega/Galaxy — đường thu và binding offline

Ngày 23/11/2026. Theo yêu cầu tiếp tục sau inventory, đã triển khai phần
thu/ngữ cảnh và ghép phản hồi skill. **PASS OFFLINE, NATIVE PENDING**.
Không đổi bộ chọn nước, luật PASS, chi phí game, executor/QTE, ACK,
thời gian poll hoặc giới hạn reader. Không mở tool/trận, fit model,
build/version, commit/push hoặc sửa tài liệu của agent core.

**Cập nhật 24/11: [đã kiểm native 3 BASIC Icarus](ACTIVE_SKILL_NATIVE_BASIC3_20261124.md).**
3 WIN, 7 response skill/53 typed steps; 4 client-card window có mốc trước/sau,
strict wire-card binding vẫn 0 vì projection IDs None. Có sửa lỗi phạm vi
excluded của tool offline và review opt-in riêng; 480 CI PASS. Không mở rộng
sang T-Rex/Galaxy hoặc nghiệm thu chất lượng Suy luận.

Source hiện tại: `fbf861fd81ff6cb656f8fa84dc6d0676eb965b7f4c50fb4997f2a72b28509c96`,
519 Python files theo hàm identity của runtime. Bản EXE v1.3.7 đã phát hành
trước đó chưa chứa phần này. Không rebind native proof/profile cũ sang source
mới; các mốc Demon/G4 vẫn đóng.

## Phần đã bổ sung

### Ngữ cảnh trước primitive

`pet_skill_dispatch_started` có thêm `skillActionContext`, tạo từ state và
capability đã đọc tại checkpoint fresh của controller:

- Source session/match, turn, srvSeq, board/critical hash và actor đã hash.
- Thẻ/family/element, chi phí Mana/Nộ cùng nguồn, pha hiện có hoặc UNKNOWN.
- HP/Mana/Nộ/Khiên/Attack của local và một boss khi ownership hiện rõ.
- Lối chơi, route tiến hóa, điều kiện skill và Tự bảo vệ đã chọn.
- Scope rõ: `CONTROLLER_FRESH_CHECKPOINT_NOT_FINAL_CLICK_REREAD`.

Không thêm đọc bộ nhớ hoặc lấy thông số sau hành động làm đầu vào trước
hành động. Bản ghi có checksum và giới hạn 4 KiB; thiếu state/capability,
identity không khớp hoặc lỗi xuất dữ liệu chỉ tạo UNAVAILABLE. Field này
không cấp quyền bấm hoặc thay preflight của primitive.

### Xuất phản hồi đã giữ trước khi dọn phiên

Sau `pet_skill_dispatch_result`, controller chụp tối đa hai bản ghi skill
đã nằm trong buffer của DispatcherTransportTap. `skill_outcome_snapshot`
không đọc game, chờ response, poll thêm, drain queue hoặc lấy board làm ACK.

- Chỉ lấy đúng match và sequence lớn hơn source, loại callback trùng.
- Dùng cả phản hồi có board và không có board. Bản chụp không nhận board
  attestation, dù bản gốc có snapshot board; ownership vẫn thuộc provider.
- Giữ typed steps/context đã có trong capture. Nếu chỉ có identity vì
  thiếu steps thì giữ UNAVAILABLE, không đổi thành damage bằng 0.
- Quá hai bản ghi có marker giới hạn; cap 128 records và 32 KiB/capture cũ
  giữ nguyên. Không tuyên bố đã thu đủ mọi skill trong một trận rất dài.
- Ghi `pet_skill_capture_checkpoint` cho cả trường hợp buffer chưa có
  record hoặc export lỗi. CHECKED/0 không có nghĩa skill không gây damage.
- Response đến sau checkpoint vẫn đi theo đường export hiện hữu; không
  chờ thêm để ép đủ dữ liệu hoặc ngăn trận kết thúc.

Lỗi diagnostic không tạo safe stop mới. Kết quả helper bị bỏ qua trong
luồng điều khiển; không có nhánh quyết định gameplay dựa vào nó.

### Ghép phản hồi skill offline

`tools/bind_active_skill_outcomes.py` giữ nguyên output normalizer SWAP cũ
trong trường `legacy`, xuất thêm `skill_observations` riêng. Phạm vi đầu
tiên là Mega Icarus/T-Rex và Galaxy click-only; không mở rộng proof QTE.

Một `OBSERVED_SKILL_RESPONSE_MATCH` cần:

1. Primitive có một click thật cùng action ID, capability hiện hành trước
   click, đúng thẻ/session, chi phí rõ; label SUCCESS một mình không đủ.
2. Controller start/result khớp action ID, session/card/cost/tài nguyên,
   và result ghi inputSent. Retry zero input được tách khỏi lần thành công.
3. Một MATCH_SKILL_USE_RES với actor và `skillCardId` rõ, đúng thẻ,
   srvSeq sau source và nằm trong cửa sổ trước hành động kế tiếp.
4. Typed effect được normalizer kiểm, không có input mâu thuẫn; chỉ một
   response phù hợp. Trùng đường export được dedup theo dữ liệu gốc.

Thiếu skillCardId thì không tự lấy cardId thay thế. Card ID mâu thuẫn,
sai actor/session, stale sequence, nhiều response hoặc không biết input
đã gửi đều giữ UNBOUND. Không dùng timestamp gần nhau để sửa identity.

Ghép thành công vẫn có `acknowledged=false`, `server_action_echo=false`:
server không echo action ID của tool. Đây là liên kết quan sát có điều
kiện, không phải proof wire ACK. Các bước DAMAGE/HEAL/BLOCK/nguồn damage
được giữ riêng; không gộp mọi DAMAGE thành damage riêng của skill.

`calibration_eligible`, `training_eligible`, `input_authority` luôn false;
`prediction=null`, complete action coverage UNKNOWN. Context trước primitive
không phải effect-time context; tài nguyên ròng không được coi là chi phí
hay lượng refund. Gear/build/buff/cohort đầy đủ và mô hình damage/heal vẫn
là phần riêng cần agent core kiểm, không được đoán từ các field mới.

## Kiểm chứng

- **474 focused CI tests PASS**. Có test xuyên suốt: fresh context thật từ
  các model state → retained tap → export → offline binding.
- Nhóm liên quan trước lần bổ sung marker cuối: 116 tests PASS, gồm old
  typed outcomes, SWAP normalizer, dispatcher, Mega click-only và Galaxy.
- Test lỗi export, wrong owner/card/session, cost UNKNOWN/đổi cost, input
  bằng 0, duplicate click/result/capture, nhiều response, stale/late packet,
  thiếu post-state kết trận và missing steps đều không tạo authority giả.
- AST witness: xóa đúng một import, một field context, một lời gọi export
  và một method snapshot mới thì toàn bộ AST controller/tap trùng baseline
  `5c887b77`. Nhánh input/PASS/QTE/ACK/cleanup cũ giữ nguyên về cấu trúc.
- Mock memory không phát sinh read từ context/export; snapshot không thay
  queue, message hoặc capture gốc.
- Replay 16 combat log cũ: 136 ứng viên click, 0 typed skill response mới,
  0 matched effect. Output legacy khớp nguyên; không ghi lại raw log.

CI dùng overlay diagnostic mới có before/after hash và AST witness; không
ghi đè các manifest lịch sử hoặc gọi overlay là native acceptance.

[Verification/source và hash](artifacts/active_skill_capture_20261123/verification.json),
[manifest source](artifacts/active_skill_capture_20261123/source_manifest.json),
[replay log cũ](artifacts/active_skill_capture_20261123/old_data_review.json),
[CI transcript](artifacts/active_skill_capture_20261123/ci_final.log).

## Điểm chốt và bài live kế tiếp

Phần collector/binding offline này đã xong. Agent core có thể dùng schema,
negative cases và fixtures để tích hợp U2/U5/U6; chưa được gọi là model đã học.
Không mở lại các cap cũ hoặc chơi thêm Demon/G4 để kiểm active skill.

Bài native kế tiếp cần **source mới + một trận BASIC có Mega hoặc Galaxy
dùng skill**, ưu tiên có skill chưa kết trận để kiểm tài nguyên và nước
tiếp. Cần thấy actor/card/srvSeq và combatSteps thực khớp một primitive,
kiểm export trước cleanup và không có thay đổi input/PASS/ACK. Nếu server
không gửi đủ field, đóng bài với lý do thiếu cụ thể; không lặp trận chỉ để
tăng số lượng. Chưa tạo request/cap, đọc trạng thái game hoặc mở trận mới
trong milestone offline này.

Lệnh audit sau khi có log mới:

```powershell
python -B tools/bind_active_skill_outcomes.py --combat <combat.jsonl> --out temp/reasoning/<case>/skill_bindings.json
python -B scripts/ci_offline.py
```

Các output chỉ dùng để nghiên cứu; công cụ không kết nối game hoặc cấp
action authority từ việc ghép log.
