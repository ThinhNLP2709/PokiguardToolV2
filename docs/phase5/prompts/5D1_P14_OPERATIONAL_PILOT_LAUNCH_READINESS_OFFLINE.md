# 5D.1-P14 — Chuẩn bị đường kích hoạt pilot operational, offline

**SELECTED ONLY / NOT EXECUTED / NO LIVE ACTIVATION.**
Parent: [P13](../reports/5d1_p13_report.md). Chỉ thực hiện khi người dùng yêu cầu
bước tiếp. Đọc AGENTS/STATUS/ROUTER/EXECUTION_CONTRACT/capability, accepted P9,
P10/P11/P12/P13 và package review/qualification/source freeze hiện hành.

## Mục tiêu và giới hạn

P13 có review calibration v2 và loader; production desktop hiện chỉ expose
request BASIC calibration, chưa expose một operational request độc lập. P14
hoàn thiện đúng đường setup/launch có request tường minh và runbook, kiểm bằng
fake runtime/input. Không mở game, query process, attach/read/capture/input,
network, tạo accepted live activation, consume claim thật hoặc tự chạy trận.
Không yêu cầu người dùng mở game để giải quyết thiếu sót setup offline này.

Không thay gameplay, reader, BASIC, simulator, memory/screenshot order,
executor/random/pacing/ACK, room/result/entry/recovery, deadline, equality hay
finite-U loader. Nếu cần seam mới, dùng factory/session hiện có ở desktop
manager và FarmRunner. Không mở UI REASONING đại trà hoặc đổi preferences thật.
Không build/version/Git mutation. Bú win chỉ xử lý song song khi có yêu cầu riêng.

## Thực hiện

1. Kiểm đúng P13 final gates/source/host/build. Không relabel calibration native
   284 hoặc historical tests. Source thay đổi phải có exact successor review và
   benchmark/regression phù hợp trước khi xuất allowance pin source mới; không
   dùng source P13 allowance trực tiếp cho source đã sửa ở P14.
2. Hoàn thiện explicit source-only operational request/launcher: file SHA,
   contract/decision, reviewed calibration, fresh allowance, full config,
   account/boss/loadout, expiry/run ID/cap và independent activation review.
   Dùng OperationalPilotSession/factory có sẵn; lỗi setup giữ BASIC hoặc từ chối
   request minh bạch trước Start, không âm thầm chạy pilot thiếu proof.
3. Request review offline phải **accepted=false**, chưa tạo expiry/claim live.
   Một draft scope duy nhất: SIMPLE/SOLO/normal→normal/default_attack,
   foreground/two_click, cùng native P11 account/Starburst1289/Phoenix structural
   fusion và full observed Attack witness. Target3/max3 TOTAL attempts kể cả
   invalid/abort; chưa activate. Không mở CAREFUL/Demon/Mega hoặc batch D1 cap12.
   Nếu người dùng muốn cohort khác, không đoán compatibility; ghi thiếu evidence.
4. Opening cards[] giữ BASIC; full exact witness mới eligible. No added CardUI
   wait/read. R từ all26 + fresh allowance +3060ms +guard≥250; margin≥100ms;
   max_read_span100ms là veto policy. U/transport/alignment vẫn null.
5. Đọc limitation P13: completed benchmark dùng worker hoàn tất rồi RETAIN_BASELINE.
   Bổ sung một fixture **thực sự qua CompletedProposal.prepare và nhận accepted
   receipt** cho đường override nếu readiness cần claim latency của nhánh đó.
   Không fill unknown effects, forge model/proposal hoặc sửa BASIC để ép override.
   Nếu không có supported candidate, giữ limitation và không claim efficacy.
6. Fake tests: valid/invalid request, missing approval, stale source/host/config,
   cap/expiry/consumed claim, setup error, private preferences, same source state,
   Stop/cleanup, no second-input, disabled parity và native surfaces never called.
   Requalification pin final source; không sửa source giữa final run, không nới
   thresholds hay lặp phép đo chỉ để có PASS. Preserve mọi failure.
7. Tạo hướng dẫn thao tác ngắn để user chạy future pilot bằng manual Start sau
   khi đã review package. Không tự launch/activate ở P14.

## Closure

Report `reports/5d1_p14_report.md`, exact changed files/tests/qualification,
readiness draft và limitations; update STATUS/router/capability. Khi gates đủ,
chọn đúng một next **bounded SIMPLE operational pilot activation** với cohort/
request trình user trước; chưa thực thi, chưa D1draft12/D2. Nếu còn thiếu thì
next là remediation đúng thiếu sót. **STOP P14.**
