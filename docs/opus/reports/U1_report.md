# U1 — Bench cùng bàn và đo ngân sách thực tế (offline)

```text
PROJECT: PokiguardToolV2
ROADMAP: Opus canonical plan — U1 (sau D-U0 23/11/2026)
RESULT: PASS_OFFLINE — phần offline U1 hoàn tất; D-U1 đã chốt đủ 24/11/2026
EFFICACY VERDICT: NOT_APPLICABLE (bench cơ học cùng bàn, không phải phép so hiệu quả)
HEAD: d7b8e30e (main) — chưa commit/push
SOURCE: native cohort ace28cad14498ca885aa04cbd0b52967225eb897b510bfcab9c44ed7ed9ca8a7
        sau U1 6beb3b403ebf4096729d6809f49fb76b4188d39baaec6c9dc09b3ed14a6429bb (chỉ thêm tool/test)
RUNTIME: 0 file src/ đổi; BASIC, input/ACK/PASS/recovery, reader giữ nguyên; 0 live, 0 build/release
HOST ĐO: 3a0ab45d… (cùng host các phiên native), Ryzen 5 4600HS 6C/12T, Win 10.0.26300, Python 3.11.9, QPC 100 ns
```

## 1. Tóm tắt

- Gói bàn giao Mega/Galaxy kiểm lại đủ hash: manifest `e0f72521…`, 21 file portable, 14 closure/raw
  manifest, 2 bản sao byte-identical, 79 raw file, run Nightsilver giữ riêng — 0 lệch.
- Corpus cùng bàn **đóng băng 2 tầng**: portable 192 case (`a5002e24…`) và local 255 snapshot
  native (`9023ef9b…`). Build lại 2 lần cùng SHA.
- Runner chạy BASIC / R native / lõi chung R1 replay / nhánh G4 trên 447 case. **Hai lần, hai
  process, PYTHONHASHSEED 0 và 2718: digest quyết định trùng** `f35e6991…`, 0 case lệch.
- Lõi R1 hiện tại **tái lập 100% quyết định native** cùng source (122/122 Mega) và 130/130 quyết định
  Demon từ các source 20–22/11. G4 replay khớp 9/9 cả action lẫn facts.
- Trên cùng bàn, R native của Mega giảm Kiếm đã biết chừa cho boss ở 23/66 nước đổi, **0 nước tăng**,
  đổi lại Mana (−134 viên hiệu dụng). Galaxy per-pet R không đổi Kiếm chừa cho boss, đổi giữa
  Máu/Hút/Khiên/tài nguyên. G4 đổi 2/9 nước, mốc combo bằng nhau.
- Chạy thử lõi chung trên bàn Galaxy (chưa phải R đang live) thì **vi phạm luật Galaxy "không ăn Kiếm
  khi Nộ > 0" ở 11/59 bàn** và thu ít Mana/Nộ cần thiết hơn BASIC ở 26/40 nước đổi. Vì vậy lõi
  chung chưa thay được nhánh per-pet Galaxy (đầu vào cho U4/U10).
- Ngân sách: thời gian chờ worker cao nhất 566 ms ở source hiện tại (p99, n=88) và 613 ms ở Demon
  source cũ, trên budget 4000 ms. Thời gian chờ ≈ 30,5 + 1,93 × compute (worker tính + host tính lại
  để kiểm). Còn ≥ 9,7 s lượt khi input xong. Đề xuất envelope ở §9.

## 2. Phạm vi và ràng buộc đã giữ

- Không sửa runtime (`src/` 0 file), không đổi BASIC, flow input/ACK/PASS/recovery, reader, gate
  read span 100 ms. Không mở live, không build/release, không commit/push.
- Dữ liệu chỉ dùng để hồi quy và đánh giá: mọi case `training_eligible=false`,
  `independent_holdout=false`, `quality_label=null`, không tiêm refill/kết quả quan sát vào đầu vào.
- WIN, số lượt ít hơn hay utility nội bộ **không** là nhãn nước tốt. Bảng ở §6 là phép sàng cơ học
  trong horizon "cascade đã biết, refill UNKNOWN" của solver hiện có.
- G4 dùng schema riêng `G4_NATIVE_V1`, profile `galaxy_shadow_sword` (không có trong `PROFILES`),
  không alias thành Galaxy active skill hay SIMPLE. Skill Galaxy opaque giữ UNKNOWN, không thành mask
  rỗng hay damage 0.
- Demon chỉ được đọc lại (tầng local). Không đổi code, weights hay checkpoint Demon.

## 3. Corpus đóng băng

Builder: [`tools/reasoning_u1_bench.py`](../../../tools/reasoning_u1_bench.py) `corpus`. Mỗi file
nguồn portable phải khớp SHA trong handoff manifest, nếu không thì dừng (`PORTABLE_SOURCE_CHANGED`).
Số case và số nước đổi phải khớp báo cáo bàn giao. Manifest + index từng case:
[`corpus_manifest.json`](../artifacts/u1_20261124/corpus_manifest.json).

| Tầng | SHA-256 | Case | Nội dung |
|---|---|---:|---|
| PORTABLE | `a5002e244d6147b431c1660b36f71d521a522966cb44565d10a27075e5c77626` | 192 | Icarus 88 cặp + 14 skill; T-Rex 10; G1 21+3; G2 16+3; G2 BASIC 3 skill; G3 22+3; G4 9 |
| LOCAL | `9023ef9bf3f84876436436e504946e83e3dcb2d493241ff0e73397675c1b29c3` | 255 | 231 snapshot Demon (17 source cũ, 18–22/11) + 24 quyết định Icarus không phải cặp SWAP (17 evolve, 4 opaque, 3 khác) |

- Corpus portable dựng lại được trên checkout bất kỳ từ fixture đã commit. Tầng local đọc log
  `docs/phase5/artifacts/**` (bị ignore), nên chỉ commit SHA. File corpus giữ ở
  `temp/reasoning/u1_bench_20261124/final_v3/` (local).
- 98/98 cặp Mega portable trùng `snapshot_id` với input worker trong log thật. Như vậy CommonProblem
  của gói bàn giao đúng là input worker đã dùng.
- Phân loại baseline giữ tách:

| Cohort | Baseline (BASIC) | R so sánh | Thực thi |
|---|---|---|---|
| Icarus, T-Rex | `NATIVE_BASIC_INCUMBENT` (đề xuất BASIC native trong snapshot) | `NATIVE_COMMON_WORKER_SENT` | ACK 98/98 |
| G1, G2, G3 | `PRODUCTION_RESOURCE_BRANCH_REPLAY` (replay nhánh BASIC, parity 18/18 ở G2 BASIC) | `NATIVE_GALAXY_PER_PET_SENT` | ACK 59/59 |
| G4 | `PRODUCTION_PLAN_G4_REASONING_FALSE_REPLAY` | `NATIVE_PLAN_G4_REASONING_SENT` | **6 ACK + 3 terminal không ACK thường** |
| Skill pre-state | BASIC native (Icarus, G2 BASIC) hoặc skill R đã ghi (G1/G2/G3) | cùng action đã dispatch | binding phản hồi giữ nguyên (UNBOUND/CLIENT_CARD_WINDOW/thiếu) |
| Local | `NATIVE_BASIC_INCUMBENT` | quyết định worker (chưa join input/ACK) | UNKNOWN |

- Loại khỏi corpus, có ghi lý do: fixture Icarus 13 case (tập con của 88, kiểm `⊂`), skill T-Rex
  (không có CommonProblem), run G1 Nightsilver lv316 (audit còn thiếu; chỉ hiện riêng ở bảng
  timing), các fixture legacy `*_core_20261124` (source cũ, không phải cặp cùng bàn).

## 4. Runner và cách so

Lệnh `run` dựng lại mỗi case từ corpus, không đọc game:

- **CommonProblem:** `project_action` (BASIC, R native), `plan_common` (đồng hồ = 0, `CommonLimits`
  mặc định) cho lõi chung R1 replay, và `CommonLimits(lookahead=False)` để đo phần lookahead đóng
  góp. So bằng `classify_pair` (TRADEOFF / CONDITIONAL_MECHANICAL_ADVANTAGE /
  REVIEW_IMMEDIATE_COST_WITHOUT_MEASURED_GAIN / NO_KNOWN_MECHANICAL_SEPARATION / INSUFFICIENT_DATA).
- **G4:** `evaluate_all_moves` + `plan_g4(reasoning=False/True)` với budget/facts đã ghi. So theo
  schema G4: mốc combo, đơn vị combo hiệu dụng, viên từng loại, Kiếm phản đòn, ô refill.
- Thước đo cho yêu cầu của user:
  - **Combo:** tổng viên hiệu dụng trong cascade đã biết (G4: `known_combo_units` và mốc).
  - **Tài nguyên:** viên hiệu dụng từng loại; Mana/Nộ thu khi đang thiếu cost (chỉ khi cost có trong
    snapshot, còn lại UNKNOWN); thu tài nguyên đã đầy; Khiên còn trên bàn đã biết (Galaxy).
  - **Kiếm chừa cho boss:** `known_reply_sword_max` (Kiếm hiệu dụng lớn nhất boss ăn được bằng một
    nước đã biết) và hazard refill 1 ô. Bằng 0 **không** chứng nhận an toàn sau refill.
  - **Đánh đổi:** danh sách lợi/chi phí theo chiều; mọi thay đổi giữ `count_gain_is_not_net_benefit`.

## 5. Tái lập

| Kiểm | Kết quả |
|---|---|
| Build corpus 2 lần | Cùng SHA (portable `a5002e24…`, local `9023ef9b…`) |
| Bench 2 lần, process riêng, PYTHONHASHSEED 0 / 2718, corpus build độc lập a/b | Digest quyết định trùng `f35e69911dd823b880ea49bbcc5e1f13df623c90bb0c0e14c7233e40aad18929`; 447/447 case trùng byte |
| Source trước/sau mỗi lần chạy | Không đổi (`6beb3b40…`); tool dừng nếu source đổi giữa chừng |
| Replay native cùng source | Mega 122/122 (88 Icarus + 10 T-Rex + 24 local); G4 9/9 action + 9/9 facts; BASIC G4 replay 9/9 |
| Nodes worker so với replay | 105/105 bàn Mega trùng số node |

Tóm tắt có digest và SHA hai lần chạy: [`bench_summary.json`](../artifacts/u1_20261124/bench_summary.json).

## 6. Kết quả cùng bàn (mechanical screen)

Δ là tổng viên hiệu dụng (R − BASIC) trên các nước đổi. "Kiếm chừa" là `known_reply_sword_max`:
giảm/tăng so với BASIC, kèm trung bình/max BASIC → R trên mọi bàn.

### 6.1 R native so với BASIC

| Cohort | n | Đổi | Phân loại nước đổi | Kiếm chừa cho boss (giảm/tăng; mean, max) | Hazard refill 1 ô (giảm/tăng) | Combo (cao/thấp/bằng) | Δ tài nguyên chính |
|---|---:|---:|---|---|---|---|---|
| Icarus | 88 | 60 | 60 TRADEOFF | 20 / **0**; 1,25→0,26; 9→4 | 14 / 1 | 39 / 15 / 6 | Kiếm +112, Máu +113, Nộ +36, Khiên +23, Hút +14, **Mana −112** |
| T-Rex | 10 | 6 | 6 TRADEOFF | 3 / **0**; 2,3→0,3; 9→3 | 3 / 0 | 3 / 2 / 1 | Kiếm +19, Máu +11, Hút +7, Nộ +6, **Mana −22, Khiên −14** |
| G1 | 21 | 7 | 6 TRADEOFF, 1 REVIEW | 0 / 0 (bằng nhau) | 0 / 1 | 2 / 3 / 2 | Hút −15, Máu +9, Khiên −5 |
| G2 | 16 | 7 | 7 TRADEOFF | 0 / 0 | 0 / 0 | 3 / 4 / 0 | Máu +17, Mana +15, Hút −17, Nộ −8, Khiên −4 |
| G3 | 22 | 11 | 10 TRADEOFF, 1 NO_SEPARATION | 0 / 0 | 0 / 0 | 2 / 5 / 4 | Hút −12, Khiên −10, Nộ −9, Mana +9, Máu +6 |
| G4 | 9 | 2 | 2 TRADEOFF | 0 / 0 (mọi bàn 0) | 0 / 0 | đơn vị 0 / 1 / 1; **mốc bằng nhau 9/9** | Hút +4, Máu +4, Mana −8, Nộ −3 |

- **Galaxy (R native):** 0/59 nước ăn Kiếm khi Nộ > 0 (cả BASIC lẫn R). Khiên còn trên bàn đã biết: R
  giữ nhiều hơn BASIC ở G1 3, G2 1, G3 4 nước, ít hơn ở 1 nước (G1). Mana/Nộ thu khi thiếu: bằng
  BASIC trừ 2 nước G2 thu ít hơn.
- **Mega:** 54/60 nước đổi của Icarus không có cost trong snapshot worker nên "Mana/Nộ cần" là
  UNKNOWN, không tính là 0. Trong 6 nước biết cost: 3 bằng, 3 thu ít hơn.
- **G4:** lượt 7 BASIC 4 Mana + 3 Nộ, R 3 Nộ + 4 Hút (7/7 đơn vị). Lượt 9 BASIC 4 Mana + 3 Nộ, R 4 Máu
  (7→4 đơn vị). Cả hai chưa tới mốc 9 và R chọn PROTECT. Không có mẫu x7 runtime.
- **Ca cần rà, giữ nguyên nhãn:** G1 `M_50670e26` lượt 3 (REVIEW: cùng 3 Mana, boss còn thêm 1 cơ hội
  Nộ). Icarus `M_4c05e68f` lượt 59 (Kiếm chừa 4→0 nhưng hazard refill 0→6). G1 `M_a0eed95e` lượt 11
  (3 Hút → 4 Máu, hazard refill 0→4). G3 `M_4e825e33` lượt 3 (NO_KNOWN_MECHANICAL_SEPARATION).

### 6.2 Lõi chung R1 chạy thử trên bàn Galaxy (không phải R đang live)

| Cohort | Đổi so với BASIC | Trùng R per-pet | Kiếm chừa giảm | Ăn Kiếm khi Nộ > 0 | Mana/Nộ cần: thu ít hơn / bằng | Khiên còn ít hơn / nhiều hơn |
|---|---:|---:|---:|---:|---|---|
| G1 | 14/21 | 5/21 | 8 | **5** | 9 / 5 | 3 / 2 |
| G2 | 13/16 | 2/16 | 4 | **4** | 9 / 4 | 4 / 1 |
| G3 | 13/22 | 7/22 | 3 | **2** | 8 / 5 | 4 / 2 |

Lõi chung ưu tiên chặn Kiếm boss (Kiếm chừa còn 0 ở mọi bàn G1/G2). Đổi lại nó tiêu Nộ bằng Kiếm và
bỏ Mana/Nộ đang thiếu cho skill 200/200, trái luật per-pet trong
[galaxy_glank_reasoning.md](../../galaxy_glank_reasoning.md) ("Không ăn kiếm khi nộ lớn hơn 0"). Ví dụ
G1 `M_50670e26` lượt 5: Nộ 85, còn thiếu 115 Nộ. BASIC lấy 3 Mana, lõi chung lấy 3 Kiếm. Đây là
**khoảng trống phải xử lý trước khi Galaxy chuyển sang lõi chung** (U4/U10), không phải lỗi live.

### 6.3 Skill pre-state (27 case)

- 12 skill Galaxy (G1/G2/G3 R và G2 BASIC): lõi chung giữ incumbent opaque 12/12
  (`COMMON_OPAQUE_OR_UNREPRESENTED_INCUMBENT`), projection UNKNOWN, không chấm damage/mask.
- 14 skill Icarus: lõi chung giữ skill 13/14. Một ca đề xuất SWAP thay skill (`M_416b699b` lượt 43:
  9 Kiếm + 4 Khiên so với mô hình ấn first-wave), phân loại INSUFFICIENT_DATA vì horizon không
  so được. Quyền skill vẫn thuộc BASIC owner; đây là đầu vào U6, không phải authority.

### 6.4 Tầng local Demon (chỉ đọc)

| Source (ngày) | Quyết định native tái lập bằng source hiện tại |
|---|---|
| 20–22/11: `61bead5b`, `7a6503d4`, `25a991ea`, `d699a5ac`, `f7ba1ec6`, `28fa103c`, `c50977f8`, `1d8349dc` | **130/130** (mới nhất `1d8349dc` 9/9) |
| 18–19/11 (B16/B17 sớm): 9 source | 86/101 (15 lệch: `836a5e09` 5, `9b4a2109` 4, `b1b718fb` 2, `e48e94d3` 2, `666d13bc` 1, `17c35c7e` 1) |

Mọi quyết định Demon từ 20/11 trở đi tái lập đúng, nên hành vi quyết định gần checkpoint Demon được
giữ nguyên trong source hiện tại. 15 ca lệch thuộc các phiên trước những lần sửa planner sau đó.
Đây là quan sát lịch sử, không phải lỗi mới.

### 6.5 Lookahead

- Mega 122/122 quyết định là `COMMON_FUTURE_INCOMPLETE_USE_COMPLETED_R1`. Với `skill_cost_ready` và
  `pet_skill_fire_value=null`, `_setup` trả UNKNOWN, nên kết quả one-step ≡ full 100%: lookahead
  hiện không đóng góp gì cho Mega (khoảng trống của U5).
- Demon: LOOKAHEAD_COMPLETE 231/231, đổi quyết định so với one-step ở 5/231. Galaxy (chạy thử):
  59/59 complete, đổi 1/59.

## 7. Thời gian native (QPC, `reasoning.swap_timing` + `reasoning.decision`)

Percentile theo nearest-rank, không nội suy; n < 100 thì p99 = max. Đơn vị ms, `remaining` tính bằng
giây server.

| Chỉ số | Icarus R (88) | T-Rex R (10) | Demon R, source cũ (240) | Icarus fallback (27) | BASIC control cùng source (14) |
|---|---|---|---|---|---|
| remaining lúc quan sát, s (min/p50) | 11 / 13 | 12 / 12 | 13 / 13 (max 14) | 12 / 13 | 12 / 13 |
| read span p50 / p95 / max | 47,0 / 97,1 / 99,0 | 36,1 / 97,8 / 97,8 | 33,2 / 41,6 / 71,2 | 106,9 / 169,4 / 172,4 | 32,5 / 40,6 / 40,6 |
| read end → bắt đầu chờ worker (gồm BASIC incumbent) p50 / p95 / max | 98,9 / 201,2 / 298,2 | 66,5 / 94,6 / 94,6 | 92,7 / 175,1 / 246,7 | 86,6 / 155,1 / 164,5 | — |
| compute worker p50 / p95 / p99 / max | 103,3 / 185,5 / 269,3 / 269,3 | 71,0 / 80,8 / 80,8 / 80,8 | 134,0 / 224,3 / 274,1 / 305,4 | — | — |
| chờ worker p50 / p95 / p99 / max | 229,3 / 390,2 / 565,7 / 565,7 | 164,8 / 198,9 / 198,9 / 198,9 | 291,3 / 455,2 / 559,2 / 613,2 | 202,6 / 269,9 / 325,2 / 325,2 | — |
| chờ / compute p50 / max | 2,22 / 3,48 | 2,39 / 2,69 | 2,15 / 4,12 | — | — |
| budget được cấp | 4000 (100%) | 4000 (100%) | 4000 (100%) | 4000 | — |
| quan sát → quyết định p50 / p95 / max | 384,6 / 667,4 / 960,1 | 279,0 / 372,1 / 372,1 | 417,9 / 659,8 / 868,7 | 202,2 / 258,6 / 268,3 | 82,9 / 146,9 / 146,9 |
| H (quyết định → preflight) p50 / max | 168,5 / 281,2 | 152,4 / 205,8 | 131,0 / 185,1 | 230,4 / 301,2 | 131,4 / 150,4 |
| I (preflight → executor trả) p50 / max | 639,4 / 653,2 | 649,7 / 657,8 | 648,2 / 662,1 | 1675,5 / 2699,4 | 1747,6 / 2706,5 |
| quan sát → input xong p50 / max | 1188,7 / 1882,7 | 1079,3 / 1232,7 | 1195,0 / 1698,1 | 2053,7 / 3123,6 | 1963,3 / 2911,7 |
| còn lại của lượt (min / p50) | 9749,8 / 11647,1 | 10897,6 / 10936,2 | 11301,9 / 11804,8 | 9876,4 / 10903,8 | 9232,7 / 10790,3 |
| nodes p50 / max (cap 18000) | 1582 / 3390 | 1243 / 1356 | 6041 / 16374 | — | — |

- **Mô hình thời gian chờ:** chờ ≈ 30,5 + 1,93 × compute (n=344 mẫu R; phần dư p99 +44,6, max +94,1).
  Chỉ tính source hiện tại: 23,1 + 2,01 × compute (n=98). Hệ số ≈ 2 vì host tính lại `plan_common` để
  kiểm worker (`CommonCompleted.prepare`). Đây là thiết kế "kiểm đề xuất" hiện có, không phải lỗi.
- **Reserve profile Mega cùng source:** 6228,86 ms = command_wait 3120 + controller_tail 150,44 +
  final_input 2706,50 + host_guard 250 + selector 1,92.
- **Độ phủ R live:** Icarus 88/115 SWAP (76,5%), T-Rex 10/23 (43,5%), Demon 240/240. Ở mọi fallback
  Mega, job R đã được nhận và chạy xong (Icarus 23 COMPLETED + 4 incumbent opaque; T-Rex 13
  COMPLETED). Nhưng lần đọc mới nhất trước khi gửi có read span trên 100 ms (ROOT
  `OBSERVATION_REJECTED`), nên kết quả R bị bỏ và BASIC được gửi. Gate giữ nguyên; nguyên nhân gốc
  UNKNOWN. BASIC control cùng source có 0/14 mẫu trên 100 ms.
- **Nhịp input:** SWAP đi qua nhánh R có I 626–662 ms vì
  [`win32_input.py`](../../../src/pokiguard_v2/win32_input.py) đặt reaction delay và jitter giữa hai click
  bằng 0 khi `reasoned` (dòng 584, 632). SWAP BASIC/fallback vẫn ngẫu nhiên (I tới 2,7 s). Reserve
  đang lấy theo nhánh BASIC chậm hơn. U1 không đổi gì ở đây, chỉ ghi lại.
- **Native so với offline cùng bàn** (n=336 bàn, compute worker / `plan_common` offline): p50 1,085,
  p95 1,21, p99 1,30, max 1,53. Như vậy worker chạy trong lúc có game chậm hơn bench offline khoảng
  9% ở trung vị và tới 1,3× ở p99. Số liệu này lấy từ phân tích phụ
  `temp/reasoning/u1_bench_20261124/pair_compute.py` (local), không qua tool chính.

Đường per-pet đồng bộ (Galaxy/G4) không có QPC. Bảng dưới lấy theo dấu thời gian log, độ phân giải
ms: từ `idle_readiness` cuối → `policy_decision` (có cả thời gian chờ provider), `policy_decision` →
`action_sent` (gồm randomization input), `action_sent` → `action_result`.

| Cohort | SWAP | remaining (s) | readiness → policy p50 / p95 / max | policy → gửi p50 / max | gửi → kết quả p50 / max |
|---|---:|---|---|---|---|
| G1 | 21 | 13 | 111 / 170 / 502 | 2418 / 3200 | 528 / 1553 |
| G2 | 16 | 13 | 105 / 600 / 600 | 2219 / 2911 | 783 / 1425 |
| G2 BASIC | 18 | 13 | 75 / 173 / 173 | 2215 / 2817 | 646 / 1409 |
| G3 | 22 | 13 | 103 / 149 / 381 | 2127 / 3253 | 525 / 1417 |
| G4 | 9 | 13 | 90 / 134 / 134 | 2107 / 2790 | 909 / **9126** (3 terminal: trận kết thúc, không phải độ trễ) |
| Icarus (tất cả) | 115 | 11–13 | 257 / 669 / 864 (n=87) | 830 / 2940 | 677 / 1184 |
| T-Rex (tất cả) | 23 | 12–13 | 70 / 286 / 286 (n=17) | 1590 / 3228 | 648 / 1415 |
| G1 Nightsilver (riêng) | 17 | 13 | 81 / 425 / 425 | 2375 / 3202 | 527 / 1432 |

## 8. Micro-benchmark offline (host tham chiếu, 3 lần/bàn, lấy trung vị)

| Nhóm | n | `plan_common` p50 / p95 / p99 / max | one-step p50 / p99 / max | `evaluate_all_moves` p50 / p99 / max | nodes p50 / max |
|---|---:|---|---|---|---|
| Icarus SWAP | 88 | 98,6 / 188,4 / 287,5 / 287,5 | 92,9 / 276,0 / 276,0 | 26,0 / 93,1 / 93,1 | 1582 / 3390 |
| T-Rex SWAP | 10 | 71,0 / 75,4 / 75,4 / 75,4 | 57,9 / 70,8 / 70,8 | 15,1 / 22,5 / 22,5 | 1243 / 1356 |
| G1 SWAP (chạy thử lõi chung) | 21 | 309,7 / 474,7 / 529,4 / 529,4 | 89,6 / 145,4 / 145,4 | 26,7 / 49,3 / 49,3 | 6172 / 12451 |
| G2 SWAP (chạy thử) | 16 | 122,3 / 773,0 / 773,0 / 773,0 | 61,0 / 152,4 / 152,4 | 16,5 / 49,5 / 49,5 | 3374 / 16483 |
| G3 SWAP (chạy thử) | 22 | 247,1 / 494,8 / 577,2 / 577,2 | 77,0 / 123,8 / 123,8 | 23,2 / 38,9 / 38,9 | 5834 / 11439 |
| Demon local | 231 | 119,9 / 204,5 / 242,3 / 320,4 | 88,1 / 211,2 / 235,2 | 24,6 / 68,2 / 74,9 | 5713 / 16374 |
| Tất cả CommonProblem | 438 | 111,3 / 313,1 / 483,9 / 773,0 | 81,9 / 216,8 / 276,0 | 24,1 / 69,0 / 93,1 | 3989 / 16483 |
| G4 `plan_g4` R (gồm evaluate) | 9 | 28,0 / 46,2 / 46,2 / 46,2 | BASIC 27,3 / 37,7 / 37,7 | — | — |

- 0 lần chạm DEADLINE/NODE_CAP trên 438 bàn với `CommonLimits` mặc định (4000 ms, 18000 node).
- Chi phí compute phụ thuộc lookahead: ở trung vị, full gấp 2,0–3,5 lần one-step trên bàn Galaxy chạy
  thử và 1,4 lần trên Demon. Với Mega, full ≈ one-step vì future UNKNOWN.
- Chỉ đo **1 máy**. Máy thứ hai là GAP. Lệnh để đo trên máy khác (chỉ cần corpus portable, không cần
  log): `python tools/reasoning_u1_bench.py corpus --out <dir>` rồi
  `python tools/reasoning_u1_bench.py timing --corpus <dir>/corpus_portable.json --out <file> --repeats 3`.

Toàn bộ phân phối có số mẫu: [`timing_summary.json`](../artifacts/u1_20261124/timing_summary.json).

## 9. Đề xuất D-U1

### 9.1 KPI (D-U1a)

**Đã chốt 24/11/2026**, nguyên văn ở [DECISIONS.md — D-U1](../../DECISIONS.md). Bảng dưới là bản
đã chốt; cột phải là mốc U1 tính theo đúng luật đã chốt.

**Gate.** Áp cho mọi thay đổi lõi/phase sau, đo trên corpus U1 cùng dữ liệu mới. Vi phạm thì
không được promote lối chơi đó:

| # | Gate | Baseline U1 |
|---|---|---|
| K1 | Tái lập: 2 process/hash seed cho cùng digest | 447/447 |
| K2 | Tắt tính năng mới thì quyết định từng case trùng U1 (action, reason, stage, nodes) | digest toàn bộ `f35e6991…` khi tool chưa đổi format |
| K3 | Replay native cùng source = quyết định đã live | Mega 122/122; G4 9/9 |
| K4 | Demon, Chịu đấm ăn xôi, Bú win được chừa Kiếm cho boss. Lối chơi khác: không chừa, hoặc chừa ít nhất và không hơn BASIC; ngoại lệ S01 | 0 ca chừa hơn BASIC (Mega, Galaxy, G4) |
| K5 | Hazard refill 1 ô tăng so với BASIC không vượt baseline; liệt kê từng ca | Icarus 1, G1 1 |
| K6 | Pet có skill cần Nộ (Galaxy G1–G3, Mega): không ăn Kiếm khi Nộ ≥ 100; ngoại lệ Nộ 250 và mọi nước không ăn Kiếm đều để boss trên 6 Kiếm hiệu dụng, hoặc máu dưới ngưỡng Tự bảo vệ | BASIC 0; Galaxy per-pet 0; **Mega R đang chạy: Icarus 14/88, T-Rex 2/10 (FAIL)**; lõi chung chạy thử Galaxy 6/59 (FAIL) |
| K7 | G4 schema riêng, replay khớp, tách ACK/terminal; Suy luận chỉ bảo vệ khi cài đặt Tự bảo vệ cho phép và máu dưới ngưỡng, áp mọi lối chơi | G4 9/9, 6 ACK + 3 terminal; G4 bảo vệ sớm được giữ cho Galaxy không tiến hóa hoặc chưa tiến hóa thành công (đúng route cohort U1: 5 bước ở máu 70–75%, 2 nước đổi); lõi chung chấm điểm bảo vệ ở mọi mức máu (chưa đạt) |
| K8 | REVIEW_IMMEDIATE_COST_WITHOUT_MEASURED_GAIN không tăng, mọi ca có ghi chú rà | 1 (G1 `M_50670e26` lượt 3) |
| K9 | Thời gian trong envelope §9.2, 0 kết quả dở do DEADLINE/NODE_CAP trên corpus | 0 |

**Mô tả.** Báo theo cohort, không gộp thành một điểm số: tỷ lệ đổi; phân loại; Δ viên hiệu dụng
từng loại; Mana/Nộ thu khi thiếu (UNKNOWN nếu thiếu cost); tài nguyên thu khi đã đầy; Khiên còn
(Galaxy); combo hiệu dụng; độ phủ R live. WIN và số lượt chỉ là KPI cohort.

### 9.2 Envelope ngân sách (D-U1b)

Giữ nguyên công thức runtime hiện có (`reasoning_runner.deadline_ns`, reserve, gate read span 100 ms):

```text
deadline = min(read_end + B_cfg, read_end + 6000, observed + R_ms − 150 − reserve − 100)
reserve  = max(1000, command_wait + controller_tail + final_input + host_guard + selector_extra)
job chỉ tạo khi deadline − now ≥ 50 ms; ROOT/FRESH/FINAL cần R_ms > reserve + 250
```

Với số đo Mega cùng source (R = 13 s, min quan sát 11 s; reserve 6228,86 ms), cửa sổ từ lúc quan
sát là 6521 ms (11 s → 4521 ms). Vì vậy **B_cfg = 4000 ms đang là giới hạn ràng buộc** (100% mẫu được
cấp đủ 4000 ms). Đề xuất:

| Mức | Đề xuất | Căn cứ |
|---|---|---|
| E1 — compute một lần `plan_common`, offline trên host tham chiếu, corpus U1 | p95 ≤ 500 ms, p99 ≤ 750 ms, max ≤ 1000 ms; node cap 18000 giữ nguyên | Dự báo native: × 1,30 (p99) tới 1,53 (max) rồi chờ = 30,5 + 1,93·c + dư → p99 ≈ 2,0 s, max ≈ 3,1 s < 4000 ms. R1 hiện tại 484 / 773 ms (p99/max) nằm trong |
| E2 — live, đường worker R | chờ worker p95 ≤ 1500 ms, max ≤ 3000 ms; 0 fallback do DEADLINE; quan sát → quyết định p95 ≤ 2000 ms | Hiện tại 390–455 / 613 ms; còn ≥ 9,7 s lượt sau input |
| E3 — đường đồng bộ G4/Galaxy | budget 1..250 ms giữ nguyên; `plan_g4` p99 ≤ 150 ms | Hiện tại 46 ms (gồm evaluate) |
| E4 — bản đóng gói (ứng viên cho D-U8, chưa triển khai) | kiểm trong phiên: sau 8 job R, nếu chờ p95 > 1500 ms hoặc có DEADLINE thì cả phiên về BASIC có lý do, không dừng tool | Chỉ có số đo 1 host; cần máy thứ hai |

So với R1 hiện tại, E1 để lại headroom cho U5 (2-ply) như sau: 2,6× ở p99 bàn Mega (288 → 750),
1,55× ở p99 toàn corpus (484 → 750), 1,3× ở max (773 → 1000, bàn Galaxy chạy thử). Muốn vượt thì phải
đo lại và user chốt lại envelope, không tự nâng `CommonLimits`.

### 9.3 Kết quả chốt D-U1 (24/11/2026)

User đã duyệt K1–K3, K5, K8, K9, E1–E3 (E4 sang D-U8), giữ nhịp input của nhánh R tới U8, và máy
thứ hai không bắt buộc. K4, K6, K7 được chốt theo câu trả lời của user như bảng §9.1. G4 giữ bảo vệ
sớm khi Galaxy không tiến hóa, hoặc tiến hóa pet thường nhưng chưa thành công. Danh sách câu hỏi gốc
giữ lại bên dưới để đối chiếu.

1. Duyệt bộ gate K1–K9 và chọn digest `f35e6991…` làm mốc parity cho U4?
2. Duyệt E1–E3? E4 để sang D-U8?
3. Luật "không ăn Kiếm khi Nộ > 0" hiện chỉ có trong tài liệu Galaxy per-pet, chưa có trong
   DECISIONS. Có lấy nó làm ràng buộc cứng (K6) khi Galaxy chuyển sang lõi chung không?
4. Nhánh R bỏ reaction delay/jitter giữa hai click (code hiện có). Giữ nguyên, hay đưa vào rà soát
   input ở phase host/admission (U8)?
5. Có đo máy thứ hai không? Nếu có, máy nào (VM hoặc máy khách yếu hơn)?

## 10. Phần thiếu, giới hạn, UNKNOWN

- 1 host đo. Số liệu máy khách chậm hơn là UNKNOWN.
- BASIC của Galaxy là replay nhánh production đã đóng băng trong fixture (AST `70884546…`, parity
  18/18 ở gói bàn giao). U1 không tính lại từ raw. R per-pet Galaxy là action đã ghi, không replay
  (planner có trạng thái phiên như chu kỳ G2, lịch sử pha G1/G3).
- Tầng local chưa join input/ACK. Demon chạy trên source cũ, nên chỉ dùng cho hồi quy/độ trễ.
- Cost skill thiếu trong 54/60 snapshot Mega đổi nước, nên Mana/Nộ cần là UNKNOWN.
- Không có refill, damage, hồi máu, pha hay RNG trong phép so. Binding skill UNBOUND giữ nguyên.
  Cap/floor quan sát ở gói bàn giao không thành công thức. Kiếm chừa = 0 không phải an toàn sau refill.
- Nguyên nhân read span > 100 ms (Icarus 27/115, T-Rex 13/23) là UNKNOWN.
- Galaxy/G4 không có QPC, chỉ log ms.
- Giả thuyết "boss có Khiên thì Hút không lấy được" chưa kiểm ở U1, chuyển sang U2.
- S02 (dùng sát thương quan sát trong trận) vẫn chờ user chốt.

## 11. Thay đổi file và tác động

| File | Thay đổi |
|---|---|
| `tools/reasoning_u1_bench.py` | Mới: `corpus`, `run`, `compare`, `timing`, `freeze`; chỉ đọc file, không có input authority |
| `tests/test_reasoning_u1_bench.py` | Mới: 7 test (đếm/kind, G4 schema + ACK, nhãn, replay Mega, Galaxy opaque, SHA đóng băng) |
| `scripts/ci_offline.py` | Thêm module `test_reasoning_u1_bench` |
| `docs/opus/artifacts/u1_20261124/` | `corpus_manifest.json`, `bench_summary.json`, `timing_summary.json` |
| `docs/opus/reports/U1_report.md`, `STATUS.md`, `README.md`, `knowledge_audit.md` | Tài liệu U1 |

- `src/` không đổi file nào. Fingerprint source (gồm `src/`, `tools/`, `tests/`) đổi từ `ace28cad…`
  sang `6beb3b40…` vì có tool/test mới. **Hệ quả:** các profile Suy luận chế độ source gắn fingerprint
  (`common.json` của worker Mega; acceptance Demon nếu còn dùng) sẽ không nạp được, ví dụ báo
  `UI_REASONING_COMMON_DEPLOYMENT_CHANGED`, và phiên chạy BASIC cho tới khi chuẩn bị lại profile. Không
  ảnh hưởng BASIC, EXE hay nhánh Galaxy/G4 per-pet. Theo plan, U2 cũng sẽ đổi source.
- Kiểm thử: `scripts/ci_offline.py` **624/624 PASS** (99,4 s; trước U1 là 617) và test U1 7/7. Log
  local ở `temp/reasoning/u1_bench_20261124/ci_offline.log`.

## 12. Điểm dừng

U1 dừng ở D-U1. Không tự sang U2. Bước kế tiếp sau khi user chốt: U2 thu dữ liệu v2 (projection
SPAWN/FALL/DESTROY, khóa player context mới, định danh boss, kiểm STEAL khi Khiên boss > 0), L0 tối
đa 2 BASIC theo plan, chỉ khi user cho bắt đầu.
