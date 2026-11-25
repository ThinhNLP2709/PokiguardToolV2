# Opus — STATUS

Con trỏ tiến độ của [plan canonical](opus-reasoning-upgrade-plan.md).

| Mục | Trạng thái |
|---|---|
| Plan canonical | Đã chốt và push (`5c887b77`, 23/11/2026) |
| Phase hiện tại | **U1 hoàn tất phần offline (24/11/2026); D-U1 đã chốt đủ** |
| Phase kế tiếp | **U2: phần offline xong** ([báo cáo](reports/U2_report.md)); D-U2 đã chốt; L0 (2 trận BASIC) chờ user chạy |
| Runtime | `src/` không đổi; không live/build/release/commit/push. Fingerprint source `ace28cad…` → `6beb3b40…` vì có tool/test mới |

## U0 — đã làm

- D-U0 được user duyệt ngày 23/11/2026: mục "Suy luận Opus" trong [DECISIONS.md](../DECISIONS.md)
  và catalog tình huống ở Phụ lục B của plan (S01, S02, S06, S11, S20 theo câu trả lời của user).
- Thêm bảng [knowledge_audit.md](knowledge_audit.md): năng lực ↔ module ↔ bằng chứng ↔ KNOWN/UNKNOWN.
- Ghi giả thuyết chưa xác minh: boss có Khiên thì Hút có thể không lấy được tài nguyên.

## U1 — đã làm

Báo cáo: [reports/U1_report.md](reports/U1_report.md). Bằng chứng commit được:
[artifacts/u1_20261124/](artifacts/u1_20261124/).

- Kiểm lại toàn bộ hash gói bàn giao Mega/Galaxy: 21 portable, 14 closure/raw manifest, 79 raw, 0 lệch.
- Đóng băng corpus: portable 192 case `a5002e24…` (dựng lại được từ fixture), local 255 snapshot
  native `9023ef9b…` (chỉ commit SHA). Build 2 lần cùng SHA.
- Bench BASIC / R native / lõi chung R1 / G4 trên 447 case. 2 process, 2 hash seed cho cùng digest
  `f35e6991…`. Replay native Mega 122/122, G4 9/9, Demon từ 20/11 trở đi 130/130.
- Đo timing native (QPC), Galaxy/G4 (log ms) và micro-benchmark 1 host. Đề xuất KPI K1–K9 và envelope
  E1–E4.
- Tool [`tools/reasoning_u1_bench.py`](../../tools/reasoning_u1_bench.py), test
  `tests/test_reasoning_u1_bench.py` (đã thêm vào `scripts/ci_offline.py`). ci_offline 624/624 PASS.

## U2 — đã làm (offline, chưa commit)

- Thêm `board_operations` (SWAP/DESTROY/FALL/SPAWN theo thứ tự server) và `player_extras` (trường B17
  mới) vào `combatOutcome`; định danh boss (petId + tên đã pin) vào facts. 4 file ghim có bản ghi review
  `tests/fixtures/compatibility/u2_evidence_20261124.json` (user chọn phương án (a)).
- ci_offline 632/632; K2 giữ nguyên digest U1 `f35e6991…` (0 case lệch); không đọc bộ nhớ mới.
- Hút khi boss có Khiên: 0 lần lấy được nếu boss chưa bị đánh trước trong cùng nước; 16/16 lần lấy được
  đều sau một đòn vào boss (`tools/u2_steal_shield_check.py`).

## Câu hỏi còn mở

- **D-U2 đã chốt 24/11/2026** (DECISIONS): chạy L0, không đọc bộ nhớ mới, đảo/level lấy từ log UI có sẵn,
  ghi quan sát Khiên/Hút vào kiến thức chung, commit U2. Đang chờ user chạy 2 trận L0.

- **D-U1 đã chốt đủ 24/11/2026**, nguyên văn ở [DECISIONS.md](../DECISIONS.md). G4 giữ bảo vệ sớm
  khi Galaxy không tiến hóa, hoặc tiến hóa pet thường nhưng chưa thành công.
- Theo K6 đã chốt, Suy luận Mega đang có (common worker) ăn Kiếm khi Nộ ≥ 100 ở Icarus 14/88 và T-Rex
  2/10. Phải sửa ở lõi chung trước khi mở rộng Mega (U4/U5, nghiệm thu U11).
- **S02:** sát thương boss hiện ước lượng từ tri thức offline + chỉ số hiện tại. Dùng sát thương
  quan sát trong chính trận đó là ngoại lệ của luật không nhớ trong trận — cần user chốt.
- D-U2 (đọc bộ nhớ mới), D-U3 (văn bản đồng ý), D-U6 (hoãn tiến hóa/giữ skill) chờ tới phase tương
  ứng.
- Profile `common.json` của chế độ source (worker Mega) cần chuẩn bị lại trước mọi phiên R live ở
  source mới. BASIC, EXE và Galaxy/G4 per-pet không bị ảnh hưởng.
