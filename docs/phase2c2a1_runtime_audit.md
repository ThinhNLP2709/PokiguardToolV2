# Phase 2C.2A.1 — runtime BASIC policy audit

## Acceptance result

**PARTIAL. Không bật full autonomous BASIC.** Board/stats/Fusion và phần lớn
swap policy có evidence tốt, nhưng game-owned consecutive idle state vẫn chưa
resolve, first-turn rule không được quan sát, log cũ không đủ để re-run engine,
và CardUI discovery bị thiếu trong chính ván acceptance. PASS tiếp tục disabled
fail-closed.

## Đúng log/session được audit

- Log: `logs/basic_policy_shadow_20260812_154814.jsonl`.
- Không dùng `logs/phase2c2a_smoke.jsonl`.
- Start `2026-08-12T08:48:17.154Z`; board found
  `08:48:25.390Z`; board lost `08:54:28.101Z`.
- PID `6284`, x64; GameAssembly base `0x00007FFB46330000`, size
  `64,139,264`; process access chỉ query + VM read; `noInput=true`.
- `Board.Instance = 0x000002877F213A80`.
- `srvSeq 7..115`; highest ACK 115.
- 21 stable published GameState / 21 `DecisionTrace`; 20 distinct local turn
  numbers có actionable snapshot, cộng một end-state không actionable ở cùng
  turn 53.
- Server-numbered local turns có thể là odd `1..53` (27 lượt), nhưng log không
  publish turn `1,7,21,23,25,41,45`. Không điền giả các lượt thiếu.
- Provider: 695 polls, 53 server transitions, 148 duplicate skips, 502 unstable
  skips, **0 stale**, **0 ambiguous latest**, **0 read error**, **0 DTO reject**.
- `matchId`, `boardHash`, và `CombatSessionKey` không được serializer của bản
  shadow cũ ghi vào decision event. Một post-match heap residue có chuỗi
  `M_5c99df47`, nhưng DTO không còn proven reachable nên không được nâng thành
  session evidence. Session key chính xác: **UNKNOWN**.

## Audit từng decision

Tọa độ là zero-based `rNcN`. Risk compact:
`S=Sword effective`, `C=known cascade rounds`, `L=deterministic Sword
potentials left`, `D=danger score`, `U=unknown cells exposed`.

| Turn | Seq | s | Player | Boss | Policy/action | Expected resource | Selected risk | Blocker |
|---:|---:|---:|---|---|---|---|---|---|
| 3 | 7 | 13 | 60351/83385 M0/1563 R0/250 Sh0 | 58926/84180 M0/445 R5/250 Sh1383 | STEP_3_MANA; SWAP r0c6-r1c6 | Mana 3 | S0/C0/L0/D0/U3 | - |
| 5 | 11 | 13 | 57585/83385 M105 R15 Sh0 | 58926/84180 M84 R10 Sh0 | UNDEFINED; NONE | 9 safe candidates | - | intermediate resource |
| 9 | 20 | 13 | 55741/83385 M210 R40 Sh0 | 59618/84180 M36 R10 Sh0 | STEP_1; EVOLVE | non-consuming proposal | - | - |
| 11 | 25 | 11 | 55741/83385 M50 R100 Sh0 | 60540/84180 M36 R15 Sh0 | STEP_5_SHIELD; SWAP r5c3-r6c3 | Shield 4 | S0/C0/L0/D0/U3 | - |
| 13 | 29 | 12 | 55741/83385 M50 R100 Sh0 | 60540/84180 M120 R20 Sh0 | UNDEFINED; NONE | 7 safe candidates | - | intermediate resource |
| 15 | 33 | 13 | 55741/83385 M50 R220 Sh0 | 60540/84180 M120 R5 Sh692 | UNDEFINED; NONE | 4 safe candidates | - | intermediate resource |
| 17 | 37 | 13 | 55617/83385 M170 R235 Sh0 | 61232/84180 M140 R67 Sh1153 | STEP_1; EVOLVE | non-consuming proposal | - | - |
| 19 | 41 | 13 | 48241/83385 M310 R250 Sh0 | 61232/84180 M0 R72 Sh0 | STEP_1; EVOLVE | non-consuming proposal | - | - |
| 27 | 59 | 13 | 48241/83385 M340 R250 Sh0 | 62385/84180 M0 R250 Sh0 | STEP_1; EVOLVE | non-consuming proposal | - | - |
| 29 | 63 | 10 | 48241/83385 M340 R250 Sh0 | 63768/84180 M252 R250 Sh0 | STEP_1; EVOLVE | non-consuming proposal | - | - |
| 31 | 68 | 13 | 45844/83385 M515 R180 Sh0 | 34045/84180 M92 R150 Sh0 | STEP_1; EVOLVE | non-consuming proposal | - | - |
| 33 | 72 | 13 | 45844/83385 M515 R240 Sh0 | 34045/84180 M92 R212 Sh692 | STEP_1; EVOLVE | non-consuming proposal | - | - |
| 35 | 77 | 13 | 56623/105228 M565/1741 R250 Sh0 | 34045/84180 M92 R117 Sh0 | UNDEFINED; NONE | 2 safe candidates | - | intermediate + no card |
| 37 | 81 | 12 | 62265/105228 M565 R250 Sh0 | 34967/84180 M92 R122 Sh0 | STEP_2_SWORD; SWAP r2c5-r2c6 | Mana 7 + cascade Sword 3 | S3/C1/L0/D215/U6 | - |
| 39 | 85 | 11 | 52869/105228 M565 R180 Sh0 | 67344/84180 M92 R27 Sh0 | STEP_3_MANA; SWAP r3c3-r3c4 | Mana 8 | S0/C0/L0/D15/U4 | - |
| 43 | 93 | 12 | 46605/105228 M685 R195 Sh0 | 59406/84180 M92 R37 Sh0 | UNDEFINED; NONE | 1 safe candidate | - | intermediate + no card |
| 47 | 101 | 10 | 46605/105228 M700 R195 Sh0 | 52643/84180 M92 R187 Sh2349 | UNDEFINED; NONE | 2 safe candidates | - | intermediate + no card |
| 49 | 105 | 12 | 46605/105228 M540 R195 Sh0 | 45488/84180 M92 R192 Sh0 | STEP_6; NONE | 7 dangerous, 0 safe | - | skip state UNKNOWN |
| 51 | 109 | 12 | 44325/105228 M785 R250 Sh0 | 47054/84180 M92 R5 Sh0 | UNDEFINED; NONE | 8 safe candidates | - | intermediate + no card |
| 53 | 113 | 13 | 44325/105228 M625 R250 Sh0 | 37550/84180 M92 R10 Sh1958 | STEP_2_SWORD; SWAP r2c0-r2c1 | Sword 9 | S9/C0/L0/D135/U3 | - |
| 53 | 115 | 11 | 44325/105228 M625 R250 Sh0 | 0/84180 M92 R10 Sh0 | ACTIONABILITY_GATE; NONE | end-state | - | local turn not actionable |

Player/Boss max Rage luôn 250; Boss max Mana 445. Các row đã rút gọn vẫn giữ
max HP/max Mana khi thay đổi. Card state là empty tuple ở **21/21** decisions.

Fusion timeline:

- T3/T5/T9: available, unused, `lastAttempt=-1`.
- T11..T19: available, unused, `lastAttempt=9`.
- T27..T33: available, unused, `lastAttempt=23`.
- T35..end: unavailable, used, `lastAttempt=33`.

## Exact branch explanations

- T3/S7: EVOLVE thiếu mana; không Sword; Rage <100 nhưng không safe Rage; chọn
  safe Mana.
- T5/S11: EVOLVE thiếu mana; không Sword/Rage/Mana; HP condition false; CAST
  threshold false; Boss `(84,10)` là intermediate; NONE.
- T9/S20: chưa fused và mana `210 >= 160`; EVOLVE.
- T11/S25: EVOLVE thiếu mana; không Sword/Mana; Rage đã 100; HP false; CAST
  false; Boss Mana/Rage đều <50; chọn safe Shield.
- T13/S29: không Sword/Mana; Rage đã 100; HP false; CAST false; Boss `(120,20)`
  intermediate; NONE.
- T15/S33: không Sword/Mana; Rage 220; HP false; CAST false; Boss `(120,5)`
  intermediate; NONE.
- T17/S37, T19/S41, T27/S59, T29/S63, T31/S68, T33/S72: chưa fused và mana
  tương ứng `170,310,340,340,515,515 >=160`; EVOLVE luôn thắng priority.
- T35/S77: fusion đã xong; không Sword/Mana; Rage full; HP false; mana >480
  nhưng không có proven Attack Card; Boss `(92,117)` intermediate; NONE.
- T37/S81: fusion xong; có deterministic Sword; STEP 2 dừng các branch sau.
- T39/S85: fusion xong; không Sword; Rage >=100; chọn safe Mana.
- T43/S93: fusion xong; không Sword/Mana; HP false; mana >480 nhưng không card;
  Boss `(92,37)` intermediate; NONE.
- T47/S101: tương tự, Boss `(92,187)` intermediate; NONE.
- T49/S105: tương tự, 0 safe move; game-owned skip UNKNOWN nên PASS bị chặn.
- T51/S109: tương tự, Boss `(92,5)` intermediate; NONE.
- T53/S113: fusion xong; STEP 2 có Sword; chọn Sword 9.
- T53/S115: boss HP 0 làm `client_move_allowed=false`; actionability gate dừng
  trước policy.

## Branch coverage

| Branch | Count/result |
|---|---:|
| STEP 1 EVOLVE | 7 |
| STEP 2 SWORD | 2 |
| STEP 3 RAGE | NOT OBSERVED |
| STEP 3 MANA | 2 |
| STEP 4 HEALTH | NOT OBSERVED |
| STEP 5 CAST | NOT OBSERVED / invalidated by CardUI discovery gap |
| STEP 5 DRAIN | NOT OBSERVED |
| STEP 5 SHIELD | 1 |
| STEP 6 PASS action | NOT OBSERVED; 1 blocked candidate |
| STEP 7 MANDATORY | NOT OBSERVED |
| EXIT_MATCH | NOT OBSERVED |
| UNDEFINED BASIC NONE | 7 |
| ACTIONABILITY NONE | 1 end-state |

Không tạo state giả để lấy coverage.

## Policy proposal so với actual user action

Log cũ không chứa `LastMove*`, cells/card events hay server operation payload,
vì vậy không thể reconstruct mọi manual swap/cast. Tool replay phân loại:

- `MATCH=2`: T9 và T33 EVOLVE; adjacent durable
  `LocalFusionLastAttemptTurn` đổi đúng turn.
- `DIFFERENT=4`: proposal EVOLVE tại T17, T27, T29, T31; adjacent next local
  snapshot chứng minh `lastAttempt` không đổi thành turn đó. Consuming action
  user dùng thay thế vẫn UNKNOWN.
- `UNKNOWN=6`: các proposal SWAP và T19 EVOLVE (gap đến T27 làm attempt mới ở
  T23 có thể overwrite evidence).
- `NOT_COMPARABLE=9`: policy đề xuất NONE; actual consuming action không được
  log nên không dùng để chấm policy.

T23 có actual EVOLVE attempt (`lastAttempt` đổi 9 -> 23) nhưng không có
published policy snapshot, nên không có proposal để compare.

Sau trận, rooted `MatchService` vẫn còn ở `0x00000286240F7240` và đọc được:
`_localSeqNum=22`, `LastMoveSeqNum=22`, last sent move
`(fromCol=1,fromRow=5)->(toCol=0,toRow=5)`. `CurrentMatchId` đã null và field
không lưu turn/timestamp, nên nước này **không được gán** cho một decision cụ
thể.

Mana giảm đúng 160 ở khoảng T47->T49 và T51->T53 kèm Boss HP giảm là dấu hiệu
phù hợp với CAST, nhưng không có CardUI/server response; đây chỉ là heuristic,
không được ghi actual CAST authoritative.

## Sword audit

T37 có sáu Sword candidates. Candidate được chọn là regression case quan trọng:

```text
SWAP r2c5-r2c6
direct: Mana effective 7
known cascade round 1: Sword effective 3
deterministic Sword potentials left: 0
unknown exposure: 6
danger score: 215
```

Nó chứng minh `non-Sword immediate -> deterministic cascade -> Sword` vẫn được
STEP 2 nhận diện runtime. Một direct Sword candidate có danger 210 nhưng không
combo; rank ưu tiên no-leftover, Sword, cascade/combo trước danger nên chọn
Mana+Sword. Bốn candidate khác để lại 1-2 deterministic Sword potential; chúng
bị xếp sau. Kết quả phù hợp rule ăn mục tiêu qua combo và tránh chừa Sword xác
định, dù collapse/UNKNOWN khiến nước vẫn classified dangerous.

T53 có hai direct Sword candidates, cả hai `L=0`, danger 135 và unknown 3;
policy chọn Sword effective 9 thay vì 6. Không có evidence actual swap để so với
manual user.

## Safe/danger audit

Trong 56 candidate traces mà các branch đã lưu:

- safe 41; dangerous 15;
- horizontal 26; vertical 30;
- calculable 31;
- có known deterministic cascade: 8;
- tổng unknown exposed cells: 196;
- hypothetical unknown Sword completions: 10;
- tổng Sword danger regions: 135.

Đây là statistics của **branch candidate sets được log**, không phải toàn bộ
mọi legal move ở mọi EVOLVE snapshot. Toàn bộ 15 dangerous traces nằm trong hai
Sword branch (6+2) và T49 no-safe set (7). Bảy UNDEFINED states đều có safe
moves nhưng user rule chưa định nghĩa priority cho intermediate boss resources;
engine đúng khi không tự tạo rule. T49 có legal moves nhưng tất cả dangerous;
PASS không được proposal vì skip source UNKNOWN.

## Intermediate Boss resource cases

Các state thực tế trả NONE vì không thỏa cả high `(mana>160 && rage>100)` lẫn
low `(mana<50 && rage<50)`:

| Turn | Boss M/R | Safe candidates/resources |
|---:|---:|---|
| 5 | 84/10 | 9 safe; Drain 7, Shield 2, Health 1 |
| 13 | 120/20 | 7 safe; Drain 4, Shield 1, Rage 4 |
| 15 | 120/5 | 4 safe; Drain 2, Rage 1, Health 1 |
| 35 | 92/117 | 2 safe; Drain 1, Rage 1 |
| 43 | 92/37 | 1 safe Health |
| 47 | 92/187 | 2 safe; Drain 1, Shield 1 |
| 51 | 92/5 | 8 safe; Shield 7, Health 1 |

Không thêm priority mới; các case này cần user quyết định ở phase sau. Các
intermediate state khác vẫn được branch cao hơn chọn EVOLVE/Sword/Mana hoặc bị
no-safe gate nên không trả UNDEFINED.

## EVOLVE, CAST, first turn và no-move

EVOLVE:

- T9 proposal MATCH actual attempt nhưng fail: mana 210 -> 50,
  `lastAttempt=9`, `used=false`.
- T33 proposal MATCH actual success: ở T35 `used=true`, max HP
  `83,385 -> 105,228`, max Mana `1,563 -> 1,741`.
- Policy object đánh dấu EVOLVE `consumes_turn=false` và
  `requires_state_reread=true`. Ván này không publish post-EVOLVE state trong
  cùng turn 33; snapshot tiếp theo là turn 35. “Policy tiếp tục same turn” là
  **NOT OBSERVED**, không phải failed.

CAST:

- Điều kiện mana >480 xuất hiện tại T35, T43, T47, T49, T51.
- `cards=[]` ở mọi snapshot, nên engine ghi “no proven usable Attack card” và
  không thể audit CAST đúng/sai. Đây là instrumentation regression: provider
  khởi tạo `scan_matches["card_ui"]` rỗng nhưng không đưa class vào scan.
- Provider đã được sửa để scan/retry `CardUI` read-only và shadow logger mới ghi
  complete GameState. Acceptance hiện tại vẫn **NOT OBSERVED**, không retroactively
  coi fix là evidence của ván cũ.

First turn:

- Exact signal của engine là `is_local_turn == true` và server
  `TurnNumber in {0,1}`; Board appearance không được dùng.
- Board found ở turn đầu, nhưng provider chưa có current ACK-attested stable DTO.
  First decision chỉ xuất hiện ở turn 3 và `first_local_turn=false`.
- First-turn mandatory proposal của ván này: **NOT OBSERVED**. Không được claim
  pass prohibition acceptance chỉ từ unit test.

No-legal-move:

- **NOT OBSERVED**. T49 vẫn có 7 legal match-producing moves (đều dangerous).
  Không có runtime `EXIT_MATCH`.

## Offline replay và determinism

Chạy:

```powershell
python tools\replay_basic_policy.py logs\basic_policy_shadow_20260812_154814.jsonl --repeat 5
```

Tool audit đủ 21 stored decisions và actual Fusion comparisons, nhưng trả
`replay=NOT_COMPARABLE`: log cũ thiếu `gameState.cells`, `boardHash`, session key
và `LastMove*`, nên không thể feed cùng GameState trở lại engine. Chỉ hash/re-read
stored DecisionTrace không được gọi là policy replay.

`basic_policy_shadow.py` từ bây giờ log full `gameState`; `BattleState` cũng có
verified `LastMove*`/sequence. Với complete synthetic record, replay 5 lần cho
cùng canonical decision/hash và bằng logged decision. Runtime acceptance replay
cần một ván log mới, không cần thay policy.

Tie-break hiện deterministic và kết thúc bằng immutable `SwapMove` coordinates;
không dùng set iteration để chọn nước. Tuy nhiên determinism của **ván cũ** vẫn
được phân loại NOT_COMPARABLE đúng evidence.

## Blockers trước autonomous

1. Game-owned current idle count/reset semantics chưa resolve; PASS disabled.
2. First local turn chưa được capture ở stable policy state.
3. CAST/CardUI và full offline replay cần một log mới sau instrumentation fix.
4. Intermediate Boss resource priority cố ý UNKNOWN, chờ user rule.
5. Actual per-turn swap/card response của ván cũ không reconstruct được.

Không có input, process write, injection, direct game call hoặc network action
trong phase này.
