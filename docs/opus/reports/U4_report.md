# U4 — Lõi chung v2 (offline, mặc định tắt) — phần U4a + U4b

```text
ROADMAP: Opus canonical plan — U4 (sau U2; user cho làm tiếp tự động 25/11/2026)
RESULT: PARTIAL_PASS — U4a, U4b (luật D-U1) và D-U4 xong; chạy thử thật 10 trận Mega (26/11) đạt;
        U4c (schema common_problem v2, G4 vào lõi chung) còn làm
EFFICACY VERDICT: NOT_APPLICABLE (bật luật chỉ đo offline trên corpus U1, chưa live)
RUNTIME MẶC ĐỊNH: không đổi — CommonLimits.rules=False; digest quyết định U1 giữ nguyên f35e6991… (447/447)
```

## 1. Đã làm

| Phần | File | Nội dung |
|---|---|---|
| U4a | `src/pokiguard_v2/boss_knowledge.py` | Kiến thức boss chỉ từ khai báo user/quan sát: đảo → tầng (Đảo Liên Minh/II trước Cổ Đại; Đảo Cổ Đại; Đảo Sấm Sét do user chọn làm boss mạnh ở L0), Khiên chặn Hút (U2). Không có số sát thương/ngưỡng tự bịa; đảo không có khai báo → UNKNOWN |
| U4a | `src/pokiguard_v2/reasoning_situations.py` | Nhãn S01–S23 + K6 với lý do tiếng Việt; nhãn cần mô hình (S01, S02, S03, S04, S06, S08, S11, S13, S14) để UNKNOWN; chỉ mô tả, không chọn nước |
| U4b | `src/pokiguard_v2/reasoning_common_planner.py` (ghim; review `tests/fixtures/compatibility/u4_core_20261125.json`) | `CommonLimits(rules=True)` bật luật D-U1: K6 (không ăn Kiếm khi Nộ ≥ 100, gồm Nộ ăn trong cùng nước; ngoại lệ Nộ đầy + mọi nước không ăn Kiếm để boss trên 6 Kiếm hoặc máu dưới ngưỡng), K4 (không chừa Kiếm cho boss nhiều hơn BASIC), K7 (chỉ chấm điểm bảo vệ khi cài đặt Tự bảo vệ bật và máu dưới ngưỡng). Áp cho Đơn giản, Cẩn thận, Khủng long, Mega, Galaxy; **Demon không áp** (giữ checkpoint). K7 chỉ chấm lại khi incumbent là SWAP, nên thời điểm skill vẫn thuộc BASIC |
| Test | `tests/test_u4_knowledge_situations.py` (6), `tests/test_u4_rules.py` (3) | Thêm vào `scripts/ci_offline.py` |

## 2. Kiểm chứng

- `scripts/ci_offline.py`: **641/641 PASS**.
- Luật tắt (mặc định): bench U1 trên corpus đóng băng → digest `f35e69911dd8…`, 447/447, 0 case lệch.
- Luật bật, cùng corpus (`temp/reasoning/u1_bench_20261124/u4b_effect.py`):

| Nhóm | Nước đổi so với luật tắt | Trùng BASIC khi bật | Vi phạm K6: tắt → bật | Vi phạm K4: tắt → bật |
|---|---:|---:|---|---|
| Icarus (88 cặp) | 47 | 41 | 14 → **0** | 0 → 0 |
| Icarus skill (14) | 1 (quay lại skill) | 14 | 1 → **0** | 0 → 0 |
| T-Rex (10) | 5 | 7 | 2 → **0** | 0 → 0 |
| G1 (21, lõi chung chạy thử) | 10 | 7 | 3 → **0** | 0 → 0 |
| G2 (16, chạy thử) | 12 | 9 | 3 → **0** | 0 → 0 |
| G3 (22, chạy thử) | 7 | 15 | 0 → 0 | 0 → 0 |
| Mega local (24) | 0 | 22 | 0 → 0 | 0 → 0 |

Nước đổi khi bật luật không được coi là tốt hơn; đây là phép kiểm luật, không phải phép đo hiệu quả.

Gate còn lại khi bật luật (`temp/reasoning/u1_bench_20261124/u4b_gates.py`, 207 bàn không phải Demon,
mỗi bàn một lần chạy, nên chưa phải phép đo E1 chuẩn 3 lần/bàn):

| Gate | Luật tắt | Luật bật |
|---|---|---|
| K5 — nước làm tăng hazard refill so với BASIC | Icarus 1, G1 1 | Icarus 0, G1 1 (không vượt mức U1) |
| K4 — nước chừa Kiếm cho boss nhiều hơn BASIC | 0 | 0 |
| K8 — ca REVIEW của lõi chung | 0 | 0 |
| K9 — thời gian `plan_common` | p50 76,4 / p95 297,6 / max 738,1 ms | p50 79,3 / p95 347,9 / max 780,8 ms (trong E1: p95 ≤ 500, max ≤ 1000) |

K1 (tái lập hai process) cho chế độ bật luật chưa chạy riêng; p99 theo đúng cách đo E1 cũng chưa đo.

## 3a. Đọc chậm khi chạy thật — nguyên nhân và sửa (25–26/11/2026)

- Trận BASIC hiệu chuẩn nhiều lần bị loại vì có lần đọc trạng thái > 100 ms (gate hiệu chuẩn bắt buộc mọi
  mẫu ≤ 100 ms). Hiện tượng có từ trước U2 (5/6 trận Suy luận Mega ngày 24/11 có lần đọc > 100 ms).
- Bộ đo `POKIGUARD_V2_PROVIDER_PROFILE=1` (opt-in, chỉ bật trong phiên test) chỉ ra nguyên nhân: mỗi lần đọc
  chậm, `_retain_validated_learned_regions` rà lại toàn bộ vùng nhớ (~90–100 ms) vì đối tượng nằm ngoài mọi
  vùng nhớ hợp lệ, và lặp lại ở mọi lần đọc.
- Sửa: cùng một tập địa chỉ không tìm thấy vùng thì chỉ rà lại sau 120 s (`memory_board_provider.py`); tap
  dùng lại capture đã chiếu của cùng JSON (`dispatcher_qte_result_tap.py`). Lần đọc > 100 ms: 78/810 →
  14/593 → 4/443; hai trận hiệu chuẩn cuối đạt 12/12 và 15/15.

## 3b. Chạy thử thật (No. 11 lv185, Mega Icarus, phiên cấu hình riêng)

| | 24/11 (trước sửa) | 26/11 luật D-U1 | 26/11 luật D-U1 + D-U4, skill 6 Kiếm trong vùng ấn |
|---|---|---|---|
| Kết quả | 4/5 WIN (Icarus) | 5/5 WIN | 5/5 WIN |
| Số lượt mỗi trận | — | 97, 51, 55, 89, 41 (TB 67) | 37, 55, 43, 63, 75 (TB 55) |
| SWAP do Suy luận quyết | 76% Icarus, 44% T-Rex | 109/109 | 101/101 |
| Đọc > 100 ms làm rơi về BASIC | 27 + 13 | 0 | 0 |
| Quyết định trước tiến hóa | — | 144 | 69 |
| Trước tiến hóa: Mana / Hút / Khiên / Kiếm / khác | — | 19% / 16% / 9% / 7% / 49% | 35% / 17% / 12% / 12% / 25% |

- Chạy lại lõi offline trên đúng các bàn của phiên D-U4 cho cùng 69/69 lựa chọn (tái lập).
- Với điều kiện ra skill theo số Kiếm, lookahead của Mega lần đầu hoàn tất (COMMON_BOUNDED_IMPROVEMENT 37,
  COMMON_COMPLETED_RETENTION 23 trên 160 quyết định).
- Ván 4 phiên D-U1: trong 18 lượt boss có ≥ 160 Mana, 12 lượt không có nước Hút trên bàn, 5 lượt có Hút,
  1 lượt (85) ăn 5 Kiếm ở Nộ 250 để boss hết Kiếm thay vì Hút 6 (boss khi đó có 3250 Khiên).
- 10 trận trên một boss chỉ cho thấy luật chạy đúng hướng; chưa đủ để nói Suy luận mạnh hơn BASIC.

## 3c. Hai điểm rà sau chạy thử (đã xử lý 26/11/2026)

- **K4:** 2 đề xuất "chừa Kiếm nhiều hơn BASIC" đều là **PASS** (để boss 9 và 11 Kiếm so với 7). Thước đo
  của lõi và công cụ là một (`_replies`); lỗi là K4 chỉ xét nước SWAP. Đã sửa: K4 xét mọi đề xuất khác
  BASIC, kể cả PASS (`tests/test_u4_k4_pass.py`). Luật tắt: digest U1 vẫn `f35e6991…`.
- **K6:** cả 5 nước ăn Kiếm ở Nộ ≥ 100 đều đúng ngoại lệ: Nộ đầy 250 và mọi nước không ăn Kiếm đều để boss
  ăn được 7–11 Kiếm (> 6).

## 3. Còn lại / cần user

- **U4c (offline, làm tiếp):** schema `common_problem.v2` đọc được v1; đưa G4 (`galaxy_shadow_sword`) vào lõi chung
  bằng schema riêng; sửa G4 bảo vệ sớm sau khi tiến hóa thành công theo K7.
- **Bật luật khi chạy thật** (Mega, Galaxy) cần một phase live riêng (nghiệm thu U10/U11) và user chạy trận.
- Luật K7 cho Demon: chưa áp để giữ checkpoint Demon; muốn áp phải user chốt riêng.
