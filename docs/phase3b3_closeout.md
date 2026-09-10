# Phase 3B.3 — Báo cáo chốt

**Ngày:** 2026-09-10, Asia/Saigon.

**Phase:** Full Automated Pet Skill Action + PERFECT QTE Execution.

**Kết quả kỹ thuật:** **PASS STRONG — v1.0.43**, theo completion contract cuối
cùng do user chốt. Không còn test live bắt buộc của phase này.

**Base commit:** `b9164c557cfc055aa13f9a5d5499b367b6e594ab`.

## 1. Những gì đã hoàn tất và giới hạn kết luận

Tool tự xác định/click đúng thẻ HT7 hiện hành, hoàn tất hướng QTE bằng phản hồi
RAM từng phím, gửi đúng một Space trong cửa sổ Perfect hiện hành và xác nhận
runtime PERFECT của chính action đó. B4 chứng minh thẻ có thể dùng lần hai
trong cùng trận, không cần khởi động lại observer hay đổi trận.

Đây là chốt **primitive thực thi Pet Skill**, không phải chốt tích hợp skill
vào auto farm. BASIC policy/FarmRunner chưa tự chọn skill, tích tài nguyên hay
tự đi bàn cờ sau skill. Không sửa Step 1, không bỏ ManaPriority, không thêm
pet preferences, không đóng gói và không tạo release tag trong phase này.

Các bổ sung/điều chỉnh so với prompt gốc được giữ rõ ràng:

- **Completion contract:** sau 7/7 RAM ACK, một Space đúng cửa sổ và current
  runtime PERFECT, action thành công ngay. Không bắt buộc bắt
  `MATCH_SKILL_USE_RES`, board sau skill, mana/nộ sau skill hoặc animation xong.
  Đây là sửa đổi được user yêu cầu, không phải hạ tiêu chí âm thầm. Game vẫn
  xử lý kết quả server nội bộ; tool không xác nhận damage/reward bằng Perfect.
- B2 action 1 có raw `POST_SKILL_REREAD_UNCONFIRMED` được chấp nhận theo
  contract mới nhờ đủ evidence input/current PERFECT. Raw log không bị sửa.
- B3 attempt 11 được user loại khỏi điểm vì thao tác tay thẻ mana ngoài kịch
  bản. Không PASS, không FAIL, không reset chuỗi; không áp dụng ngoại lệ này
  cho lỗi automation thông thường.
- Thêm B4 được cấp quyền rõ ràng: tối đa **hai** skill trong cùng trận, giữ
  observer, chờ inactive edge/lượt sau và generation/challenge mới. Vẫn chỉ
  một action hoạt động tại một thời điểm; không có lần ba.
- Hỗ trợ reverse **1.7.4-b2** với hash/layout đã xác minh; game build khác
  không được đoán offset để chạy. Native hand/geometry và fast QTE reads được
  dùng để tránh full scan trong đường gửi phím.
- Sửa v1.0.43: `Board.isUsingLegendCard` có thể vẫn true sau skill, không dùng
  riêng flag này để giấu thẻ khi rediscovery. Không xóa các gate QTE/readiness.

Quyết định chuẩn: [DECISIONS.md](DECISIONS.md). Nhật ký đầy đủ, kể cả các lần
thất bại trước khi sửa: [phase3b3_report.md](phase3b3_report.md).

## 2. Full action executor / ownership

Implementation: `src/pokiguard_v2/pet_skill_action.py`; harness
`tools/pet_skill_action.py`; bounded coordinator `tools/pet_skill_b4.py`.

Luồng hiện hành:

`PREFLIGHT -> CARD_CLICK -> WAIT_QTE_GENERATION -> DIRECTIONS ->`
`WAIT_PERFECT_TARGET -> CONFIRM_PREFLIGHT -> SPACE_SENT -> WAIT_RESULT -> COMPLETE`.

Mọi nhánh lỗi/abort dừng quyền input. Các enum/decoder post-state cũ còn giữ
cho tương thích/diagnostics, không tạo lại gate bắt buộc cho success hiện hành.

- ActionId riêng, gắn MatchId/epoch/Board/local actor/source turn/skillCardId.
- Một lease input chung với controller hiện có; không chạy hai input workers.
- Card lấy từ native hand hiện tại, đối chiếu CardUI/Board/Active/CardData,
  Button và RectTransform; không dựa vào slot cố định hay chỉ metadata.
- Geometry dùng ownership/native UI hiện hành, transform/Canvas và client
  geometry; kiểm tra lại foreground/HWND/PID/geometry trước input.
- Mỗi phím hướng phải có index/correct/prefix RAM ACK trước phím kế tiếp.
  Mẫu cũ, lẫn actor/session/challenge hoặc progress bất nhất đều fail closed.
- Một transient challenge-read failure chỉ được bridge với exact current
  CardUI/prefix đã bind; không đoán phím, không bỏ RAM ACK, lỗi lặp lại dừng.
- Abort/Emergency flag được kiểm tra tại các input boundaries; tests chứng
  minh không thêm input sau khi revoke. Harness có Ctrl+C/SIGTERM và read-stall
  watchdog. **F9/nút Emergency của desktop UI chưa phải điều khiển harness CLI
  này**; không tuyên bố đã tích hợp giao diện khi chưa làm.
- B4 lần hai chỉ bắt đầu sau inactive-QTE edge, lượt local muộn hơn, readiness,
  resources/card mới được xác minh và challenge/generation mới trong session cũ.

## 3. Capability / chi phí / card

Pet full-auto được kiểm chứng: **Huyền Thoại 7, skillCardId 7**.
Chi phí hiện hành đọc được: **200 Mana / 200 Rage**.
HT2 fixtures: **200 Mana / 150 Rage**, có regression; full-auto HT2 ở phase
này **NOT_OBSERVED (B5 tùy chọn)**.

Với hai shape Dot-QTE đã chứng minh, CardData `conditionUse: long +0x48` là
Mana và `power: long +0x50` là Rage, trong khi raw `manaCost/powerCost` vẫn 0.
Không hard-code số 200, 150 hay identity HT7 vào cost resolver. Shape ngoài
bằng chứng trả UNKNOWN. Giữ raw fields và gross cost riêng; net resource delta
sau ăn gem/cascade không được dùng để sửa cost. Deltas muộn/concurrent có thể
AMBIGUOUS. Test fixtures bảo vệ cả HT7, HT2, unknown và raw-zero handling.

Trong tập acceptance 17 action bên dưới: **17 card clicks**, không duplicate
hay blind retry. Native-read torn geometry trước B4 action 2 bị từ chối với
zero input rồi fresh rearm; không phải click lần ba hoặc retry sau input.

## 4. Timing và result

Sequence, active/index/correct, elapsed và Perfect interval đều thuộc current
CardUI/challenge. Target là midpoint **cửa sổ hiện hành**, không constant 3.15 s.
Polling ngắn được điều chỉnh theo khoảng cách tới target, dùng RAM elapsed
kèm monotonic estimate; không sleep nguyên deadline rồi gửi, không tiến timer
bằng wall clock để bắn Space khi game đang frozen trước Perfect.

Final preflight: đúng identity/generation, 7/7 correct, current valid window,
mẫu còn fresh, foreground/geometry đúng; Space đúng một lần. Current runtime
PERFECT hoàn tất ngay, không dispatcher callback scan trong production hook.
Không giữ success chờ post-state hoặc đổi kết quả cũ bởi callback tới trễ.

Tập thống kê chốt có **17 accepted actions / 16 MatchIds**: B1 mới nhất,
B2 ba actions, B3 final streak mười, B4 first success và retry hai successes.
Đây là tập acceptance được chỉ rõ, **không** là toàn bộ lịch sử đều thành công.

| Metric | Min | Max | Mean | Median |
|---|---:|---:|---:|---:|
| Click -> first QTE observed (s) | 1.015000 | 1.094000 | 1.053235 | 1.047000 |
| 7/7 direction completion (QTE s) | 1.050251 | 1.284190 | 1.165935 | 1.167758 |
| Space elapsed estimate (s) | 3.151786 | 3.201961 | 3.165102 | 3.154792 |
| Margin from Perfect start (ms) | 151.786 | 201.961 | 165.102 | 154.792 |
| Margin to Perfect end (ms) | 98.039 | 148.214 | 134.898 | 145.208 |
| Error after midpoint (ms) | 1.786 | 51.961 | 15.102 | 4.792 |

Observed windows all [3.0, 3.299999952] s; these are observed values, not a
hard-coded deadline. `qteElapsedMs` telemetry: 3136..3187 ms, mean 3164.647 ms;
it is **not proof of an externally captured server result** in the final hook.
All 17 predicted/current runtime results are PERFECT; 119/119 directions
confirmed. Wrong/skipped/duplicate/stale/unconfirmed directions, blind retries,
duplicate/stale/out-of-window Space and wrong-generation result acceptance:
**0 in this acceptance sample**. Space count 17. Later gameplay must still read
its own fresh ready board; current PERFECT does not authorize that next input.

## 5. Live B1 — PASS

Log: `logs/phase3b3_pet_skill_action_20260909_012152.jsonl`.
ActionId `e7ea05db917a46d0aae9547cbb983d47`; Match `M_702266cf`, turn 49.
HT7, resources 238 Mana / 250 Rage; resolved cost 200/200.
Sequence `RIGHT LEFT DOWN RIGHT UP LEFT LEFT`, 7/7 in 1.167871 s.
Perfect window [3.0, 3.299999952], target 3.149999976, Space 3.153660 s,
qteElapsedMs 3170, current runtime PERFECT. Historical v1.0.40 trace also has
response correlation (semantic server result null), post resources 140/150,
turn 51. That delayed delta does not establish gross cost or global
turn-consumption semantics. These post fields are no longer needed for success.

## 6. Live B2 — PASS 3/3

| Action | ActionId | MatchId | Result under final contract |
|---|---|---|---|
| 1 | 530143a332e24f7fb584b7fee275ca11 | M_a04f76c1 | PERFECT; old post-state-only failure reclassified explicitly |
| 2 | da95a2ef9a574277b30a29456ee6b2e4 | M_bea34652 | SUCCESS_PERFECT |
| 3 | c6bc1d4de62040f991dd21351b1f48d9 | M_76c33a56 | SUCCESS_PERFECT |

Three consecutive accepted full actions, 21/21 ACKs, 3 clicks, 3 Spaces,
PERFECT 3 / GOOD 0 / BAD 0; critical violations 0.

## 7. Live B3 — PASS STRONG

Final ledger: **15 full attempts = 13 accepted + 1 scored unconfirmed +
1 operator-excluded**. Fourteen scored; B2 supplies the first three accepted
actions in this ledger. Genuine attempt 4 card-click/no-QTE failure is retained.
Attempt 11 is excluded only by the user's explicit consumable-interference
decision; its raw unconfirmed result is retained.

Final scored streak: **5, 6, 7, 8, 9, 10, 12, 13 retry1, 14, 15 = 10/10**.
Ten PERFECT, zero GOOD/BAD; 70/70 ACKs, 10 clicks/Spaces, direction and confirm
violations zero. Minimum start margin **151.786 ms**, end margin **116.737 ms**.
Final attempt 15 ended at 2026-09-10 01:36:59 ICT. B3 across its 13 accepted
actions has 91/91 directions. Do not label the ledger 15/15 or all trials PASS.

Audit of all 63 local Phase 3B.3 action JSONL files found zero JSON parse errors.
There are 42 unique result records reporting actual input: 19 raw SUCCESS_PERFECT,
7 POST_SKILL_REREAD_UNCONFIRMED, 6 SPACE_SENT_RESULT_UNCONFIRMED, 4 INVALIDATED,
3 QTE_STALE_OR_AMBIGUOUS, 3 CARD_CLICK_SENT_QTE_UNCONFIRMED. This raw historical
inventory spans earlier code/contracts, excludes zero-input refusals, and may
omit interrupted runs without a result record; it is not the B3 scoring ledger.
No blanket retroactive conversion of old failures was performed.

## 8. Live B4 — PASS, retained same-match isolation

Final log:
`logs/phase3b3_pet_skill_action_20260910_124435_b4_retry1_two_same_match_v1043.jsonl`.
Match **M_60410580**, epoch 1, local actor 1, game PID 23784.

| Action | Turn | Before Mana/Rage | Generation / challenge | 7/7 elapsed | Space elapsed |
|---|---:|---:|---|---:|---:|
| 5ae06813a7a3472185fd52530d4e7474 | 13 | 270/200 | 1 / 315118874137065403 | 1.152945 s | 3.154792 s |
| 7ca4565446dd40f5b601e30bf2731cb1 | 21 | 240/225 | 2 / 3212872392316864696 | 1.150411 s | 3.167089 s |

Both current PERFECT; same CardUI/arrows-list objects reused by the game, but
different challenge/current sequence/generation. Inactive edge at 13:13:42.110
separates them. This proves isolation by current identity, not by assuming a
new pointer. Preflight geometry tear before action 2 produced zero input;
the fresh safe rearm succeeded. No stale CardUI/sequence/window/result accepted.

Final `B4_SUCCESS_TWO_CURRENT_PERFECT`, accepted 2/2, exit **0**.
Second result 13:14:33.700, observer stopped 13:14:33.727 (27 ms later).
Two card clicks, 14/14 directions, two Spaces, no third action.
`completedQtes=0` is the optional callback-correlated counter, **not** the count
of accepted full actions. Requiring it would reintroduce the rejected contract.

Earlier B4 v1.0.42 achieved only its first Perfect (M_8718fdf8) then could not
rediscover the second card because of the latched legend flag. That incomplete
run is preserved; v1.0.43 fixes the proven discovery cause and retry validates it.
B3's different matches additionally supply cross-match isolation evidence.

## 9. Offline verification / safety audit

Final commands (PowerShell, `PYTHONPATH=src;.`):

```powershell
python -m unittest tests.test_pet_skill_action tests.test_pet_skill_b4 tests.test_qte_control_poll tests.test_native_card_ui tests.test_qte_direction_assist tests.test_pet_skill_shadow tests.test_pet_qte_observer tests.test_desktop_runtime tests.test_farm_cycle_input_hooks -q
python -m unittest discover -s tests -q
python -m compileall -q src tools tests
git diff --check
git diff --cached --check
```

Results: focused **282 PASS** (1.184 s), full **1083 PASS** (13.440 s), compileall
PASS, unstaged/staged `git diff --check` PASS. The generated C# evidence keeps
the dumper's whitespace under a narrowly scoped `.gitattributes` rule, as for
the older reverse trees; source/tests/docs still receive normal checks.
Expected fail-closed messages printed by simulated failure tests are not live
game failures. No live game input was sent during this audit.

Max simultaneous PetSkill actions: **1**. No new input after abort/revoke in
input-boundary tests. No process-memory writes, direct gameplay calls, injected
code or network manipulation. Existing BASIC policy/solver/farm orchestration
was not rewritten to add Pet Skill. CV remains available as fallback/audit;
Pet Skill state/QTE decisions do not use OCR. Existing screenshot-based geometry
sanity checks are distinct from reading the board/QTE from RAM.

## 10. Files / archive / Git receipt

The phase commit includes the accumulated executor, native card discovery,
QTE observer/control, read-only diagnostic roots/tap, b2 layout compatibility,
normal-input/geometry support and their regression tests. Version remains
1.0.43; the closeout adds documentation/archive rules, not another input change.

Canonical docs: this closeout; `phase3b3_report.md`, `phase3b3_runbook.md`,
`phase3b3_native_card_evidence.md`, `phase3b3_qte_timing_evidence.md`,
`CURRENT_STATE.md`, `DECISIONS.md`, `il2cpp_symbols.md`, `board_resolution.md`,
`pokiguard_1.7.4_compatibility.md`, `pokiguard_pet_skill_qte_reverse_report.md`.

The exact changed-path inventory is the phase commit's `git show --name-status`:
58 project/support files plus 1,062 generated declaration files. Staged artifact
audit found no runtime/binary paths, no standard credential-pattern flags and
no file above GitHub's size limit (largest staged blob about 234 KB).
Compact user-supplied b2 `cs/Assembly-CSharp` declarations (1,062 files) and a
provenance README are retained in Git. The remaining 389 MB-class generated dump
is kept locally, ignored rather than deleted; `il2cpp.json` alone exceeds
GitHub's file limit. Runtime logs/screenshots/checkpoints remain local and ignored.
No real game binary, runtime log, credential or packaged artifact is published.

One focused phase commit on main, no release tag. Its SHA is the commit that
contains this closeout; the final task response supplies the actual SHA and
push/clean-worktree receipt after those operations succeed, rather than guessing
a self-referential hash here. Verify the publication with:

```powershell
git log -1 --format="%H %s"
git rev-parse HEAD origin/main
git ls-remote origin refs/heads/main
git status --porcelain
```

## 11. Final process state / known unknowns / next phase

PetSkill executor, observer, Python controller/UI/poller: **STOPPED / no active
Python controller observed** at final audit. B4 stopped cleanly with exit 0.
Game `Pokiguard-1.7.4.exe` PID 23784 remained open; no game input or game-file
modification was performed during closeout. No next test was auto-started.

Known unknowns and deferred work (not hidden mandatory acceptance failures):

- Exact automatic gem destruction count, net resource gain, cascade/reward or
  global turn-consumption semantics are not inferred from runtime PERFECT.
- Other skill-family semantics and HT2 full-auto are NOT_OBSERVED here.
- Unknown future GameAssembly builds remain unsupported until reverse-verified.
- `Board.isUsingLegendCard` full-game reset semantics remain UNKNOWN. The
  generic board-policy/modal path still treats it as busy; **audit this before
  continuous Pet Skill integration**, or it could block later board play. The
  bounded B4 fix only removes its misuse in fast hand rediscovery.
- Pet preferences, cost/capability UI, auto resource policy, continuous farming
  with skill and desktop stop integration are outside this primitive phase.

**Next safe phase:** **3A.2 — Pet Configuration + Capability Model** (deferred
prerequisite), before **3C.1 — BASIC Pet-Skill Policy**. Wait for review/new
prompt. Phase 3B.3 requires no additional mandatory live match. Stop here.
