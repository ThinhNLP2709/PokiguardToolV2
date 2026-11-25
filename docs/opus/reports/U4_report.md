# U4 — Lõi chung v2 (offline, mặc định tắt) — phần U4a + U4b

```text
ROADMAP: Opus canonical plan — U4 (sau U2; user cho làm tiếp tự động 25/11/2026)
RESULT: PARTIAL_PASS_OFFLINE — U4a (kiến thức boss, nhãn tình huống) và U4b (luật D-U1 sau cờ tắt) xong;
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

## 3. Còn lại / cần user

- **U4c (offline, làm tiếp):** schema `common_problem.v2` đọc được v1; đưa G4 (`galaxy_shadow_sword`) vào lõi chung
  bằng schema riêng; sửa G4 bảo vệ sớm sau khi tiến hóa thành công theo K7.
- **Bật luật khi chạy thật** (Mega, Galaxy) cần một phase live riêng (nghiệm thu U10/U11) và user chạy trận.
- Luật K7 cho Demon: chưa áp để giữ checkpoint Demon; muốn áp phải user chốt riêng.
