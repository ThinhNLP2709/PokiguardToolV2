# 5D.1-P11 — Bounded BASIC reserve calibration

2026-10-15 (Asia/Saigon). **BASIC LIVE BATCH CLOSED / RESERVE INCONCLUSIVE / PARTIAL D1.**
[Prompt P11](../prompts/5D1_P11_BOUNDED_BASIC_RESERVE_CALIBRATION.md), parent
[P10](5d1_p10_report.md). Đã đóng batch user yêu cầu Starburst73/Phoenix3trận.
Chưa có REASONING input hoặc operational authority; không tự chạy thêm trận.

## Kết quả live

Cohort **Starburst cấp73, boss1289 / Phoenix do user xác nhận**; SIMPLE/SOLO/
BASIC, normal→normal/default_attack, foreground/two_click, shadowOFF. User tự
bấm Start trong TOOL lúc01:29:53 ngày15/10. Request `bfd50030618547598269a91650606acc`,
FarmRun `6f600539556e45af9c43acf2859b9012`, target3/max3 TOTAL attempts.

**3/3 WIN**, cả3 terminal HP/UI nhất quán,3result-confirm,3normal returns về boss
lobby,0technical recovery. Dừng `FARM_TARGET_COMPLETED`, phase FINISHED,
controller inactive, game BOSS_LOBBY. Farm duration456.075s.

| Attempt | Match | Kết quả | Local turns | Thời gian combat |
|---|---|---|---:|---:|
| 1 | M_07438a01 | WIN | 7 | 103.863s |
| 2 | M_58b2fde3 | WIN | 5 | 65.471s |
| 3 | M_4e303a66 | WIN | 14 | 186.794s |

26local turns là proxy năng lượng của tool, không account-energy delta.
26SWAP gửi,23ACK;3nước cuối mỗi trận trả `ACTION_ABORTED_STATE_CHANGED` với
`COMBAT_LIFECYCLE_ENDED` trước ordinary swap ACK, sau đó terminal WIN được
xác nhận. Giữ cả3 trong raw logs, không gọi chúng là ACK hoặc tự retry nước.
EVOLVE có3success/1failed; failure turn7 trận3 rồi success turn11, không làm
farm dừng. Nguyên nhân EVOLVE_FAILED chưa được đánh giá trong scope SWAP timing.
0CAST/PASS trong batch. Không suy live coverage cho các nhánh chưa xuất hiện.

## Entry correction và các lần trước

Trước batch này có2run Issylt SAFE_STOP trước trận, native match_attempts0 và
input0. Hai claims đã consumed; giữ nguyên requests/export/logs, không reset.
User tự thêm Attack, sau đó yêu cầu sửa lỗi rồi trực tiếp yêu cầu batch mới
3ván với boss/pet mới. Fixed Issylt draft cap1 chưa claim/zero starts được
supersede; Small Blue draft trước đó cũng chưa claim. Không giấu failed launches
trong kết quả3/3 của cohort mới. [Lịch sử preparation/diagnosis](../artifacts/5d1_basic_reserve_p11_starburst_20261015_v1/report_before_closure.md).

[Scoped entry fix](../../attack_selected_entry_fix_20261015.md) đổi đúng3runtime
files và thêm6tests;102focused checks PASS. ALREADY_SELECTED giữ3s settle rồi
existing runtime read xác nhận cùng room/boss/card; không cần artwork proof của
Toggle khi không click Toggle. Nhánh actual Toggle click giữ strict visual proof,
Start giữ riêng visual/runtime preflight. Thêm cause trên UI và tối đa2failure
PNGs từ buffers hiện có, disk failure không mask stop. Routine PNG vẫn tắt;
capture/recognition không bị tắt bởi PNG persistence flag.

Cả3entry trong batch mới có ALREADY_SELECTED, artwork proof false, selected
identity sau settle hợp lệ, Toggle clicks0, Start clicks3. Đây là native evidence
cho corrected selected-card branch trên Starburst/Phoenix; không claim native
retest Issylt hoặc coverage của actual Toggle-click branch. Thiếu thông báo trên
UI đã có offline test; batch này không tạo stop lỗi mới để test message live.

## Timing và provenance

[Export](../artifacts/5d1_basic_reserve_p11_starburst_20261015_v1/basic_calibration_export.json),
[analysis](../artifacts/5d1_basic_reserve_p11_starburst_20261015_v1/closure_analysis.json),
[diagnostics](../artifacts/5d1_basic_reserve_p11_starburst_20261015_v1/closure_diagnostics.json).
30records gồm26SWAP timing +4decision timing SUPERSEDED_BEFORE_PREFLIGHT; sequence
1..30 đầy đủ. Writer eligible/enqueued/written30/30/30, dropped/failed/queued0,
flushed/closed true, collector dropped0/disabledFalse. All-attempt ledger3/3 và
claim/config/cap/source/host/build pin giữ; không discard failure/terminal rows.

| Host measurement | ACK-joined N | p50 | p95 | Maximum |
|---|---:|---:|---:|---:|
| H: decision-exit→final-preflight | 23 | 129.0037ms | 160.1032ms | 164.4290ms |
| I: final-preflight→executor-return | 23 | 1964.8482ms | 2718.9480ms | 2972.3250ms |
| Full tail | 23 | 2110.1074ms | 2834.7742ms | 3132.4282ms |
| Root read span | 23 | 36.5542ms | 45.9165ms | 49.7245ms |
| Final read span | 23 | 2.7068ms | 3.5040ms | 4.9305ms |

Cả26physical-return intervals đều giữ; maxima của cả26 bằng maxima ở bảng,
không cherry-pick3terminal rows để giảm reserve. N23 chỉ là subset có exact
sent/ACK join. Đây là small-N descriptive measurements, không future hard bound.
Executor-return chỉ upper bound cho hoàn tất input, first click timestamp
NOT_MEASURED. Input settle0.06s/hold0.075s, BASIC random/pacing giữ; command
ceiling3060ms. Không có compute wait/planner trong batch BASIC.

**Reserve chưa được accepted** vì:

1. Export lỗi `MISSING_OR_MIXED_RUNTIME_WITNESS`:3opening samples có cards[],
   23samples sau có Attack64647/card4; account/boss/fusion/config giữ giống nhau.
   Preentry xác nhận selected Attack trong cả3trận. Đây là thay đổi representation
   đã quan sát; chưa chứng minh một actual loadout change hoặc nguyên nhân cache.
   Không tự normalize/xóa samples để bỏ gate.
2. P10 selector allowance còn pin source3bf1e69f…, current source sau entry fix
   làbb69e4c5…; chưa có allowance qualified cho current overall fingerprint.

Tính số học tham khảo theo công thức P9:
`164.429 + 2972.325 + 9.9283 + 3060 + 250 = 6456.6823ms`.
Minimum action floor3000ms nhỏ hơn tổng này.9.9283ms là **old-source P10
allowance**, vì vậy6456.6823ms chưa là reserve được phép activation; không tạo
operational package/authority từ số này. Read-span rejection threshold còn
PENDING. Native U/transport age/Unity-host alignment vẫn UNKNOWN, không U=0.

## Bảo toàn và phạm vi

Current source284 fingerprint:
`bb69e4c5b6d8d027f86047c4752aee4a90cbb5e470e9f8558bc79c221c2d772f`.
Source frozen suốt Starburst batch, host unchanged.2,336parent artifacts và4game
files giữ SHA; ordinary preferences giữ SHA, không restore/write cấu hình thường.
HEAD `c646acfa5e895732bbdade553f9d7bd61171cd29` giữ. Package/versionv1.2.5 không
build lại. Entry fix có [successor source manifest](../../artifacts/attack_selected_entry_fix_20261015/successor_source_manifest.json);
P10 full2179 tests vẫn là historical offline acceptance cho parent source,
không relabel thành full-suite acceptance của source284. Không chạy tests/benchmark
song song trong native timing batch.0agent computer-use/capture/input; game
capture/input của normal tool chỉ chạy sau user manual Start.

Kết quả: **BASIC batch và corrected selected-Attack entry được quan sát thành
công; native reserve INCONCLUSIVE; D1 PARTIAL.** Không efficacy promotion,
không AI input/D1draft12/D2. Tool hiện dừng đúng3/3 ở boss lobby.

## Next duy nhất

[P12 — offline native-calibration binding review](../prompts/5D1_P12_NATIVE_CALIBRATION_BINDING_REVIEW_OFFLINE.md)
**SELECTED ONLY / NOT EXECUTED**. Rà mixed witness và successor selector binding
bằng artifact sẵn có, không thêm trận/observer hoặc tự hạ loader gate.
**STOP P11.**
