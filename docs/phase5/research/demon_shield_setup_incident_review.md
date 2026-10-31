# Demon Shield setup — targeted incident review

Ngày review: **2026-10-09 (Asia/Saigon)**.
Yêu cầu: rà log sẵn có để tìm hiện tượng setup Khiên lặp lại, hoặc test mới nếu
không tìm được. Kết quả: **FOUND_OBSERVED_PATTERN + EXISTING_CORE_REPLAY_MATCH**.
Không code runtime, không live/game attach/input, không chạy test suite/build/
commit/push. Không mở5A.3/5B.1/5B.3 hoặc đổi tiến độ roadmap.

## 1. Kết luận và phạm vi claim

Có case thực tế đủ để dựng kiểm chứng offline: setup được ghi là có cơ hội
passive đủ Kiếm ở lượt tới, nhưng cơ hội đó không còn ở lượt ta tiếp theo.
Trong các cặp tiêu biểu, Khiên boss tăng và số ô Khiên trên board giảm.

Đã xác nhận **forecast/setup không được bảo đảm qua lượt boss**. Dấu hiệu phù
hợp lời người dùng thấy boss ăn Khiên. **Chưa có record xác nhận exact boss
swap/ô Khiên boss consume**, nên không gọi mọi cặp là boss-steal đã chứng minh,
không loại trừ refill/cascade/effect chưa modeled. Chưa chứng minh một phương
án thay thế tối ưu hơn hoặc REASONING đã sửa được hiện tượng.

Không cần chạy test mới chỉ để tìm ví dụ: đã có actual snapshots và một chuỗi
lặp nhiều lượt. Nếu sau này cần kiểm chứng chính xác boss policy/consumption,
đó là targeted evidence riêng trong protocol bounded; không chạy tới khi gặp
mà không có cap. Chỉ dùng state/log sẵn từ flow accepted hoặc bằng chứng người
vận hành cung cấp; thiếu observation không thêm read/capture/flow.

## 2. Cohort đã rà

| Run | Combat files thực có trong run | Profile/config |
|---|---:|---|
|3c96b9b33cd54ada96a5350ce95f4cba|300|Demon BASIC, Sword3, Lieyun|
|72df987dba2143e4b35c9e7cd1d2917d|68|Demon BASIC continuation, Sword3, Lieyun|
|4542ea9da01f4923a03661504a50c3f2|77|Demon BASIC, Sword3, Lieyun|

Tổng **445 combat files /445 unique MatchId**; không cộng145 và77 từ summary
thành222 vì run continuation chỉ có68 combat files mới. Raw log date08/10/2026.
Không dùng các timestamp trộn nguồn làm protocol timing/performance evidence.

**950 executed decisions** ghép policy_decision với action_sent theo
MatchId/turn/boardHash/move; unmatched0, relevant JSON lines corrupt0.
Branch counts: passive fire489, setup308, setup-risk-accepted153. Một trận có
thể fire nhiều lần; không dùng489 làm số trận hoặc tỷ lệ thắng.

- 451 cặp executed setup→executed local decision liền sau, turn tăng2.
- 73 cặp forecast nextBestBlastSwordCells>=3 nhưng next decision không fire và
  trace ghi không có Shield match đạt3.
- 26 trong73 cặp còn đồng thời có bossShield tăng, board Shield count giảm,
  own known root Shield tally0; nằm trong25 trận.
- Một trận có2 cặp đạt đầy đủ filter. Đây là filter tìm incident, không
  probability, prevalence toàn farm hoặc26 boss actions đã observed.

## 3. Case lặp rõ nhất — M_7d274339, attempt142

Source: [combat.jsonl](../../../logs/farm_runs/3c96b9b33cd54ada96a5350ce95f4cba/matches/attempt_142/combat.jsonl).
Policy lines45/74 và192/220; đều có action_sent tương ứng.

| Cặp game turn | Forecast Sword physical sau root, chưa qua boss | Best Shield burst ở next local board, không ordinary Sword | Boss Shield | Board Shield cells |
|---|---:|---:|---|---|
|3→5|3|0|0→569|10→8|
|13→15|4|0|0→1327|8→6|

Turn3 ta ăn3 Mana, turn13 ta ăn3 Rage /6 effective units; known root không ăn
Shield. Next local states đều quay lại setup. Trận có10 local actions, gồm9
setup rồi passive fire ở game turn19. Không có board hash loop y hệt: đây là
**lặp cơ chế mất cơ hội**, không phải bằng chứng controller treo hoặc input lặp.

Turn17→19 là control tốt trong cùng trận: forecast4, next local board còn
burst4 và BASIC fire. Không được biến kết quả này thành ban setup Khiên.

## 4. Case độc lập và control

| Match / source | Cặp turn | Forecast→next best | Boss Shield | Ý nghĩa |
|---|---|---|---|---|
|M_bdaf6d3b /4542... attempt029|13→15|4→0|0→1327|Trận12 local actions; setup tốt trong forecast mất ở next local board|
|M_632f0563 /3c96... attempt007|1→3|6→0|0→569|Forecast lớn vẫn không đảm bảo còn cơ hội sau boss|
|M_632f0563 /3c96... attempt007|5→7|4→3|0→0|Forecast đổi nhưng vẫn đủ setting3, BASIC fire; không gắn mọi geometry change thành failure|

Sources:
[attempt029](../../../logs/farm_runs/4542ea9da01f4923a03661504a50c3f2/matches/attempt_029/combat.jsonl),
[attempt007](../../../logs/farm_runs/3c96b9b33cd54ada96a5350ce95f4cba/matches/attempt_007/combat.jsonl).

## 5. Offline replay đã thực hiện

Dùng **primitive có sẵn**, không viết planner/solver mới:
board_simulator.simulate_move/evaluate_all_moves và evaluate_demon_aegis_move.
Khôi phục BoardState từ64 ô boardSnapshot, đúng order screen rows top-to-bottom;
dùng swap row/col đã ghi trong decision, không lấy native row như screen row.

Ba trận trên có26 policy roots:

- 26/26 root legal theo simulator hiện tại.
- 26/26 direct/cascade resource tally khớp log.
- 23/23 setup forecast field khớp recomputation;3 passive-fire roots không có
  forecast field nên N/A, không tính thành matched forecast.
- Best next-board Shield burst tính lại trên **actual next local snapshot**,
  không transplant refill của nước đã chọn vào một counterfactual root.

Resource/forecast checks không phải full BASIC engine decision parity, không
validate damage/gain conversion, không full boss/refill simulation và không
test50 design cases/planner tương lai. No-ordinary-Sword filter ở bảng là scope
để đối chiếu BASIC passive fire, không hard ban mới cho REASONING. Lấy max blast
trên mọi ordinary-Sword root có thể tạo false claim BASIC bỏ nước fire hợp lệ.

Current offline source HEAD:
`c646acfa5e895732bbdade553f9d7bd61171cd29`.
Core file hashes và source-log SHA256 nằm trong
[artifact](artifacts/demon_shield_incident_evidence_20261009.json).
Runtime binary/source fingerprint của log cũ chưa được bind trong review này;
không tự lấy legacy phase2d4BaseCommit làm version executable. Match replay ở
phạm vi trên không chứng minh toàn bộ source/binary đồng nhất.

## 6. Evidence được lưu và giới hạn

[Incident evidence JSON](artifacts/demon_shield_incident_evidence_20261009.json)
chứa aggregate scan,3 replay timelines, source paths/line/hash và10 selected
source snapshots (board64 + selected root + actor resources + explanation).
Đây là **incident schema**, không phải completed immutable DTO/replay runner
của5B.1. Không chứa raw screenshot/process handle/pointer hoặc username.

Phân lớp:

- OBSERVED: local board/state, policy reason, action_sent, next local state.
- DERIVED: known root simulation, next-board burst counts và incident filter.
- CONDITIONAL: boss lấy Khiên là cơ chế phù hợp dữ liệu, chưa có exact boss
  action/consumption record.
- NOT_IMPLEMENTED/NOT_TESTED: new planner ranking, worker/fallback/log sink,
  proposed utilities, counterfactual superiority, production parity.

LOCAL_TURN_RETURNED.runtime.last_move_sequence/coordinates có thể vẫn phản ánh
nước local trước đó. Không dùng trường tên “last_move” như observed boss action.
Trong3 replay logs,23/23 LOCAL_TURN_RETURNED records có last_move coordinates
khớp prior local swap sau native Y-flip; đây là negative source-owner check,
không boss policy evidence.
Full post-root pre-boss board/refill và boss move chưa được archive; không
reconstruct bằng cách bịa favorable/recorded refill cho action khác.

## 7. Bổ sung acceptance cho chuỗi nhiều lượt

Giữ50 design cases5A.2 là design, thêm incident-chain requirements:

| ID | Dataset/control | Expected cho B1/B2/B3 sau |
|---|---|---|
|DSI01|M_7d274339 turns3/5 và13/15|Giữ cả2 losses trong cùng match; H phải phản ánh opportunity sau boss, không chỉ nextBest trước boss|
|DSI02|M_bdaf6d3b turns13/15|Đối chiếu forecast4 với actual next-board0, giữ cause UNKNOWN khi thiếu boss action|
|DSI03|M_632f0563 turns1/3|Không coi forecast6 là guarantee; comparison phải hiện refill/boss coverage|
|DSI04|M_632f0563 turns5/7 vàM_7d274339 turns17/19|Control: setup còn usable thì có thể tiếp tục/fire; không ban mọi setup hoặc mọi forecast change|
|DSI05|M_7d274339 full timeline|Đo số lần opportunity bị mất, turns-to-first-passive, resource/protection/damage progress; semantic loop không yêu cầu hash lặp|
|DSI06|LOCAL_TURN_RETURNED last_move|Source-owner check; thiếu actual boss action vẫn missing, không gán nhãn fake observed boss swap|
|DSI07|Alternative root/bait cùng state|Chỉ model-supported known transition + UNKNOWN/stress; không ép winner khi counterfactual chưa được chứng minh|

Chưa ép hành động thay thế cụ thể hoặc ngưỡng “sau N lần luôn phá setup”.
History nếu dùng chỉ same-match/session và state đã published; không thêm
reader/capture, không sửa BASIC/default để tránh làm control đẹp hơn.

## 8. Handoff và STOP

Artifact QA:10/10 snapshots khớp source line/MatchId/turn/boardHash/board/move,
3 source-log hashes và2 core hashes khớp;5 report links tồn tại. JSON hợp lệ,
Git diff --check -- docs exit0; warnings LF→CRLF không phải gameplay change.
Git status vẫn chỉ docs, prior work được giữ. Các checks này thuộc data/docs
consistency, không test worker/runtime/fallback hoặc full BASIC parity.

5A.3 nhận incident schema/coverage và diagnostics cần có: expected vs retained
setup, repeated loss, actual progress, boss action source/missingness. Chốt
protocol targeted/bounded nếu cần observation hẹp; chưa thực hiện5A.3.

B1 map10 snapshots và nguyên chuỗi source thành fixture/replay có provenance,
split cùng match không leak. B2/B3 kiểm utility/retained setup/ties/bait và
positive/negative chain. D3 kiểm boss policy/calibration trong scope live riêng.
REASONING hiệu quả hơn vẫn cầnE1, không suy từ mất forecast của BASIC.

STATUS giữ5A.2 CLOSED, next5A.3; targeted review này không advance roadmap.
Chỉ bổ sung docs/data, bảo toàn prior work. **STOP sau log review**.
