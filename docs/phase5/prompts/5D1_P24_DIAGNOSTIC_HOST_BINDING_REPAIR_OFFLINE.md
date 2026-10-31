# 5D.1-P24 — Sửa host binding của diagnostic harness, offline

**SELECTED ONLY / NOT EXECUTED.** Chưa cần mở game.
Đọc AGENTS, STATUS/ROUTER/capability, EXECUTION_CONTRACT,
[P23 report](../reports/5d1_p23_report.md),
[entry failure proof](../artifacts/5d1_pipeline_diagnostic_p23_v1/entry_failure_review.json),
[repair proposal](../artifacts/5d1_pipeline_diagnostic_p23_v1/repair_proposal.json),
[P23 frozen protocol](../artifacts/5d1_pipeline_diagnostic_p23_v1/protocol.json)
và [P22 diagnostic plan](../artifacts/5d1_pipeline_tail_review_p22_v1/diagnostic_measurement_proposal.json).

## Entry

P23 dựng harness và fake8cases PASS nhưng `--measure` một lần exit1 trước
claim/raw: guard chặn local `socket.gethostname`, stdlib trả hostname rỗng,
host hash lệch. **0measured records**, không performance dataset; current
source/actual host vẫn khớp. Source297 bab0145d… và P21 qualification31/32FAIL
giữ nguyên. Không gọi lỗi harness là latency FAIL hoặc P21 regression.

## Scope

Chỉ copy harness sang **artifact directory P24 mới**, sửa host acquisition/
invocation receipt, fake validation và đúng một diagnostic attempt mới.
P23 folder/frozen bytes/logs giữ nguyên. Không sửa src/tools/tests, production
collector/BASIC/qualifier/loader/verifier/model/flow/input/reader/ACK/Stop.
Không game attach/read/capture/input, UI/observer/worker launch, game files,
preferences/claims, build/version/Git hoặc network requests.
Không rerun full regression/qualification/soak để tìm PASS.

## Công việc

1. Verify P23 final manifest và original frozen harness/protocol, P22/P21
   lineage, current source297/host bằng file/local metadata. Snapshot parent
   artifacts/6claims/preferences/4static game hashes/HEAD/idle UI prefix.
   P23 có external prior-UI closure: stdout append/new summary, preferences
   đổi6config fields. Dùng current settings làm baseline; không restore
   prefs cũ. Historical stdout kiểm archived exact prefix, không giả rằng
   current stdout còn nguyên hash trước closure. Không dùng append làm
   native evidence mới.
   Existing P21 full2316PASS đọc từ footer, không chạy tests cũ.

2. Giữ nguyên fingerprint algorithm và actual host fields. Capture
   `host_record()` thực tế ở setup **trước Guard.install và trước imports
   project**, rồi freeze detached canonical record trong harness. Guarded
   preflight dùng record đó, ghi rõ provenance/timing; không gọi lại hostname/
   platform helpers dưới guard rồi âm thầm lấy fallback. Final preservation
   trong process riêng phải recompute actual host theo cùng algorithm;
   frozen record không phải independent after-run evidence.

   Không hardcode hostname hoặc thay expected host bằng artifact tùy ý, bỏ
   equality, sửa actual host fields hoặc mở toàn `socket.*`. Giữ mọi game/
   DLL/input/network/process/worker guards trong project imports và execution.
   Metadata setup chỉ đọc local host identity/clock; không dùng game/window,
   network request hoặc UI/worker để lấy identity. Receipt phân biệt local
   setup và guarded execution, ghi failures thật.

3. Persist exclusive **attempt receipt cho --measure trước preflight**;
   claim actual measurement riêng sau bindings hợp lệ. Attempt fail trước
   claim cũng consume attempt; không tự retry hoặc resume. Freeze harness/
   protocol/SHA sau fake validation trước attempt duy nhất.

   Bổ sung fake cases: captured host dưới guard khớp actual trước guard;
   missing/tampered/wrong-host record và wrong source bị reject; host capture
   không bypass native/socket/input guards; binding failure có attempt
   receipt nhưng không claim/raw và lần gọi lại bị chặn. Giữ8fake-clock
   coverage/GC/fault/restore/deadline/schedule cases P23. Không đo latency
   trong validation. Nếu cần sửa thêm ngoài host/attempt receipts, ghi rõ
   scope/limitation; không sửa runtime cho tiện.

4. Đúng **một attempt**, cap120s, theo nguyên frozen plan:
   A6000/B6000, fixed blocks `A1500,B1500,B1500,A1500,A1500,B1500,B1500,A1500`;
   profile current6000; empty instrumentation1000. Total19,000records;
   pipeline indices0..5999, warmup0..999 mỗi mode, không reset mỗi block.
   A/B/control sequence AST phải giữ; B metadata omission chỉ counterfactual
   giả, không hợp lệ cho authority. Không retry, pool, trim, đổi threshold,
   affinity/priority/tắt GC hoặc subtract overhead để lấy PASS.

   Lưu all raw same-sample absolute wall/thread/process CPU endpoints,
   payload bytes/count/fault, profiled nested parent spans/GC trace và empty
   wrapper overhead. Record actual clock info/coarseness; CPU enclosure và
   instrumentation perturbation rõ. Custom formatting/IO ngoài timer.
   Giữ partial sample/error/cleanup receipts khi fault/timeout; không bù mẫu.

5. Recompute coverage/quantiles/CPU/stage distributions, GC joins, every
   large-sample raw window, A/B block differences và overhead riêng. Max10ms
   nguyên; diagnostic không thay qualification/accepted allowance/reserve.
   Thiếu causal evidence hoặc không reproduce thì INCONCLUSIVE/UNKNOWN;
   không xóa failure P21 hoặc suy future hard bound. Không hồi tố nguyên nhân
   sample2789 bằng trace mới. Chọn đúng một next proposal từ evidence;
   chưa tối ưu runtime/SLO/qualification/live trong P24.

## Output và STOP

Viết `reports/5d1_p24_report.md`, separate harness/source/protocol/freeze,
fake validation, attempt/claim/raw/timeout/cleanup, recomputation/UNKNOWN/
decision và preservation. Thiếu dữ liệu phải ghi đúng số0/partial và stats
null; không tự tạo receipt như thể measured loop đã chạy.
Accepted/live/input/activation=false; S/R accepted null. Native U/transport/
alignment null; legacy/finite-U/root250/final100/one-t0/deadline/budget/
guard/margin/Stop/ACK giữ; normal BASIC retention, không quota đổi nước.

Update STATUS/README/ROUTER/capability/index; chọn **exactly one next prompt**,
không thực thi tiếp. Không resume P19/general SIMPLE/CAREFUL/Demon/Mega/
D1cap12/D2 hoặc Phase5 completion. **STOP P24.**
