# U2 — Thu dữ liệu v2 (chỉ evidence)

```text
ROADMAP: Opus canonical plan — U2 (sau D-U1 24/11/2026; user chọn phương án (a) cho file ghim)
RESULT: PASS_OFFLINE — phần offline U2 xong; L0 (2 trận BASIC thật) chờ user chạy; dừng ở D-U2
EFFICACY VERDICT: NOT_APPLICABLE (chỉ thêm evidence, không đổi quyết định)
HEAD: a63c89f5 + thay đổi U2 chưa commit
SOURCE: 3b34d6ba6aae44acbaa29a2ff15b9229ab26fc08fae28c52ed268685bfe67170 (fingerprint sau U2, gồm tool/test mới)
RUNTIME: chỉ thêm trường log và một fact không được planner đọc; không đọc bộ nhớ mới, không đổi input/ACK/PASS/recovery
```

## 1. Đã làm

| Hạng mục | File | Ghi chú |
|---|---|---|
| Thao tác bàn theo thứ tự server (SWAP/DESTROY/FALL/SPAWN, tag + hệ số viên mới) | `src/pokiguard_v2/board_operation_context.py` (mới) | ≤128 thao tác, ≤16 KiB; khóa vắng để vắng; lỗi chỉ làm hỏng bản ghi này |
| Trường người chơi B17 mới (cooldown, stack, pha, tỷ lệ rơi, may mắn, pity tiến hóa, level) | `src/pokiguard_v2/response_player_extras.py` (mới) | Trường vắng liệt kê trong `absent`, không phải 0; ≤4 KiB |
| Gắn 2 bản ghi trên vào `combatOutcome` (`board_operations`, `player_extras`) | `combat_outcome_evidence.py` (ghim) | Gắn sau cùng, không bao giờ đẩy evidence cũ ra; tổng vẫn ≤32 KiB |
| Định danh boss vào facts của Suy luận | `reasoning_common_evidence.py`, `reasoning_common_selection.py`, `reasoning_ui_session.py` (ghim) | `facts.boss_identity` = petId + tên từ mục tiêu farm đã pin; đảo/level để UNKNOWN; planner không đọc |
| Bản ghi review cho 4 file ghim + 2 file mới | `tests/fixtures/compatibility/u2_evidence_20261124.json`, `tests/test_compatibility_migration.py` | Theo cùng quy trình G4/Mega; ghi rõ không đổi read/input/quyết định |
| Kiểm Hút khi boss có Khiên | `tools/u2_steal_shield_check.py` (mới, offline) | Đọc `combat.jsonl` đã lưu |
| Reverse B17 (Phụ lục D) | `docs/il2cpp_symbols.md` | Bảng field/kiểu/offset `MatchPlayerSnapshotDTO`, khóa `MatchOpDTO` |
| Test | `tests/test_u2_response_evidence.py` (8 test), thêm vào `scripts/ci_offline.py` | |

## 2. Kiểm chứng

- `scripts/ci_offline.py`: **632/632 PASS**; 310 test liên quan combat outcome PASS.
- **K2 (D-U1):** chạy lại bench U1 trên corpus đã đóng băng bằng source U2 → digest quyết định trùng
  `f35e69911dd8…`, 447/447 case, 0 case lệch.
- Không có lần đọc bộ nhớ mới: hai projection chỉ nhận envelope JSON mà tap đã có, không có reader
  hay địa chỉ. Định danh boss lấy từ cấu hình mục tiêu farm đã pin.
- Test bảo đảm: lỗi ở thao tác SPAWN hoặc trường mới chỉ đánh dấu bản ghi mới là INVALID; `evidence`,
  `player_context` cũ giữ nguyên; planner và tactics không tham chiếu `boss_identity`.

## 3. Phát hiện: Hút khi boss có Khiên

Ghép Khiên của boss trước nước đi (`policy_decision.boss.shield`, đọc sẵn) với phản hồi
`MATCH_MOVE_RES` của chính nước đó; 176 file, 492 nước SWAP ghép được. "Có ăn Hút" theo
`destroyed_by_tag['trang Dot']` (`live_state.TAG_TO_GEM`: trang = Hút).

| Khiên boss trước nước | Có ăn Hút | Có bước STEAL lấy tài nguyên | Không STEAL |
|---|---|---:|---:|
| 0 | có | 148 | 14 |
| > 0 | có | **16, cả 16 đều sau một đòn DAMAGE/BLOCK vào boss trước đó trong cùng nước** | **26** |
| bất kỳ | không | 0 | 288 |

Kết luận quan sát (chưa là công thức): khi boss còn Khiên, Hút chưa lần nào lấy được tài nguyên nếu
boss chưa bị đánh trước trong cùng nước. Điều này ủng hộ giả thuyết của user, kèm điều kiện "trừ khi
Kiếm đánh vào trước". Lượng Khiên bị phá và thứ tự xử lý chính xác vẫn UNKNOWN.

## 4. Còn thiếu

- **Normalizer kỹ năng boss chưa làm:** 176 file không có phản hồi `MATCH_SKILL_USE_RES`/`CARD_USE_RES`
  nào của boss, nên chưa có gì để phân loại mà không đoán. Các trường skill/cooldown của boss trong
  `player_extras` sẽ có từ L0; làm normalizer sau đó.
- Đảo và level boss: log UI đã ghi sẵn `targetLevel`/`targetIsland` ở mỗi lần poll (ví dụ log cũ có
  `targetLevel 77`, `targetIsland "Thập nhị tinh"`), nên không cần sửa thêm file ghim. Facts của Suy
  luận vẫn để đảo/level UNKNOWN; phân tích offline ghép theo log UI.
- Chưa biết key JSON của các trường B17 mới có đúng tên field hay không — chính là câu hỏi của L0.

## 5. Runbook L0 (user chạy, tối đa 2 trận BASIC)

1. Chạy từ source (`python -m pokiguard_v2` như thường lệ), Trí tuệ **Cơ bản**, không bật Suy luận.
2. Trận 1: một boss thường. Trận 2: một boss từ Đảo Cổ Đại trở đi.
3. Sau trận, gửi tôi thư mục `data/logs/farm_runs/<run>`; tôi kiểm:
   - `dispatcher_combat_outcome.combatOutcome.board_operations`: đủ SWAP/DESTROY/FALL/SPAWN, đúng thứ tự;
   - `player_extras`: key nào xuất hiện cho ta và cho boss, key nào vắng;
   - không có lỗi `INVALID` mới, không thay đổi nước đi/thời gian so với BASIC trước đó.

## 6. D-U2 — user đã chốt 24/11/2026

Đồng ý theo đề xuất: chạy L0; không đọc bộ nhớ mới; đảo/level lấy từ log UI có sẵn (không sửa thêm
file ghim); ghi quan sát Khiên/Hút vào kiến thức chung; commit U2 trước L0. Danh sách câu hỏi gốc:

1. Cho chạy L0 theo runbook trên?
2. Đọc bộ nhớ mới: giữ mặc định **không** (plan D-U2)?
3. Có sửa thêm `desktop_control_plane.py`/`farm_run.py` (ghim) để đưa đảo/level boss vào facts không?
4. Ghi phát hiện ở §3 vào kiến thức chung: "Boss còn Khiên thì Hút không lấy được tài nguyên, trừ khi
   trong cùng nước boss đã bị đánh trước"?
5. Commit phần U2 này chưa?
