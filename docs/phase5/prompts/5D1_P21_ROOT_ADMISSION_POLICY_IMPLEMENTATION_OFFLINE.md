# 5D.1-P21 — Root admission policy implementation OFFLINE

**SELECTED ONLY / NOT EXECUTED.** Thực hiện một milestone khi user yêu cầu.
Đọc AGENTS, STATUS, ROUTER, EXECUTION_CONTRACT, capability, parent
[P20 report](../reports/5d1_p20_report.md),
[policy review](../research/5d1_p20_root_admission_policy_review.md),
[decision/cases](../artifacts/5d1_admission_coverage_review_p20_v1/review_decision.json)
và P18/P19 exact source/raw lineage. STOP ở milestone này.

## Entry và mục tiêu

P20 file-only review xác định100ms root policy veto là nguyên nhân trực tiếp
của19/30 P19 SWAP không submit worker; deeper provider substage cause UNKNOWN.
Boundary không bao gồm BASIC/worker compute. Current `max_read_span_ms` dùng
chung root/final, nên không được đổi100 thành250 một cách toàn cục.

Verify P20/P19 manifests và source294
`b673eab28dfcb1c5d32116d264789b7e5d8b2d9bdc7a2df7dfc469012e2740a9`,
host `3a0ab45d64462c647ccc713c18bdb7ba64d666ddac4822a1c31789f5378a88a9`.
Nếu drift, giải thích compatibility trước khi làm; không sửa pin để che khác biệt.

Triển khai riêng `OPERATIONAL_ROOT250_FINAL100_V1` cho successor opt-in review:
**root cap250ms; final direct-runtime cap100ms**. Chỉ thay admission policy và
binding/verification/diagnostics cần thiết. Không tối ưu provider hoặc đổi flow.

## Ranh giới bắt buộc

- OFFLINE ONLY; không cần mở game. Không game attach/read/capture/input, UI/
  observer launch, network hoặc sửa game files. Existing idle log append chỉ
  archive prefix, không coi là native evidence mới.
- Không đổi BASIC, solver, policy weights, model, source identity, provider/read
  order, controller flow, executor/delays, mandatory pacing, ACK/result/room/
  Stop/recovery. Không quota đổi nước; completed RETAIN_BASELINE hợp lệ.
- Không finite-U bypass, native U/transport/alignment vẫn null. Không root
  time reset, không reuse vetoed snapshot/completed offer, không thêm read/poll/
  capture/sleep để chờ planner. Không replay BASIC sau bất kỳ input.
- Old consumed claims giữ nguyên. Không request/activation/claim live mới,
  preferences thật, build/version/Git changes hoặc mở CAREFUL/Demon/Mega/D1cap12.

## Công việc

1. Snapshot và pin parent artifacts/source/host/game hashes/ordinary prefs/claims/
   HEAD. Thiết kế versioned successor review/request tương thích; reviewed-v2/v3
   và strict finite-U giữ100ms semantics. Reject old document đổi field/cap để
   xin250. Pin root250/final100/policy version xuyên authority, review, exporter,
   false draft và future activation. Default/legacy vẫn100; không UI setting mới.

2. Root bridge dùng cap đã verify, không thêm game work. Final preflight vẫn
   kiểm100ms. Root reject phải chặn prior completed offer kể cả cùng source;
   invalid timestamps hoặc missing policy fail về BASIC qua gate hiện có.
   Logging reuse bounded sink và timestamps hiện có; ghi rõ policy/span,
   không synchronous disk IO hoặc new provider instrumentation.

3. Giữ nguyên one-t0 deadline và50ms remaining budget floor. Root elapsed đã
   tiêu trong budget; cap250 không cộng thêm thời gian. Veto/timeout/log lỗi chỉ
   disable AI khi cần; BASIC/ACK/FarmRun/Stop và healthy successor retirement giữ.

4. Thực thi meaningful planned cases trong P20. Test fake game/executor/provider;
   source-state changes, boundary+1ns, missing/malformed/tampered proof, source
   pairs, legacy100, successor250, final100, Stop/cleanup và no-second-input.
   Không tạo fixture ép override để suy hiệu quả gameplay. Log arithmetic từ
   P19 chỉ là counterfactual, không gán submitted/completed/ACK giả.

5. Freeze exact source pair và methods/dependencies. Qualification phù hợp phần
   thay đổi: completed retention, timeout/error/veto, pipeline/monitor, overhead
   CPU/Stop/bounded writer; giữ raw samples/warmups/outliers và gates đã công bố,
   không rerun đến khi PASS. Full regression một lần ở integration boundary;
   rerun chỉ khi sửa code/failure cần thiết. Không mở whole-app/native soak mới.

6. Verify original P11 native26returns/20anchors và P15 supplement7/16missing,
   source lineage P16/P18, P19 source29430returns riêng. Không đổi raw/native
   counts hoặc dùng hypothetical27roots làm calibration samples. Current-source
   allowance và reserve phải recompute từ fresh qualified costs; guard≥250,
   margin≥100, command ceiling3120ms/two settles giữ. Native sample maxima không
   phải future server/OS bounds. Không tự hạ reserve từ P19 nhỏ hơn.

7. Khi gates đủ, xuất successor draft accepted=false/live=false/input=false,
   pin full config/cohort/source/host/build/root-final policy, monitor và current
   R. Không run ID/expiry/activation/claim. Draft không thể mở UI hoặc farm.

## Đầu ra và STOP

Report `reports/5d1_p21_report.md`, exact source diffs, tests/qualification/raw
artifacts, false draft và preservation proof. Update STATUS/README/ROUTER/
capability. Nếu gates đủ, chọn đúng một bounded successor pilot prompt cần
user chuẩn bị room và activation/manual Start riêng, tối đa3TOTAL attempts;
nếu thiếu, chọn targeted offline remediation/evidence có câu hỏi rõ.
Chỉ chọn prompt, không tự chạy. Chưa general SIMPLE/CAREFUL/Demon/Mega/D2 hoặc
đóng Phase5. **STOP P21.**
