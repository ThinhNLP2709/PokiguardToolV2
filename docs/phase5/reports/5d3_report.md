# 5D.3 — Nghiệm thu suy luận cho Demon Aegis

Ngày 2026-10-18. **PASS STRONG trong phạm vi hai yêu cầu tối thiểu người dùng đã chốt.** Phiên bổ sung 20 trận hoàn thành 20/20 thắng; không còn ca minimum thiếu xác nhận live.

Setup/dụ boss nâng cao, R2 và damage formula chưa được nghiệm thu. Kết quả này không chứng minh suy luận tối ưu toàn cục hay hiệu quả hơn BASIC trên mọi bàn.

[Kết luận nghiệm thu](../artifacts/5d3_multiplier20_20261018/gate_decision.json), [closure phiên 20 trận](../artifacts/5d3_multiplier20_20261018/closure.json), [ledger tổng 29 trận](../artifacts/5d3_multiplier20_20261018/cumulative_ledger.json).

## Phạm vi và quyền chạy

Người dùng yêu cầu “theo tôi là live thêm với 20 ván để tìm kiếm x2”, xác nhận “Đã sẵn sàng, giữ nguyên cấu hình”, rồi tự Start TOOL. Cap riêng tối đa 20 gồm failed entry/loss/abort; không tái dùng claim hoặc sửa kết quả 9 trận trước.

Cùng tài khoản, Lieyun ID 1436/lv 77, Demon Aegis thường, không tiến hóa, nội tại, ngưỡng tham khảo 4 Kiếm; Solo/foreground/two_click. Static stats: maxHP 109491, maxMana 2771, maxRage 250, ATK 1819. Tên pet do người dùng xác nhận, chưa có petID độc lập từ native.

- Tool v 1.2.5; HEAD `c646acfa5e895732bbdade553f9d7bd61171cd29`, branch `codex/phase3a2-board-repair`.
- Source 328 file SHA-256 `00b19780f78fae906b84df47d4d67af6f085abc0df834822f4c9c6ce15a09702`.
- Farm run `092a2a794e184436b1047a0ac01d7f6a`; request `6f4ba71965f8499c9c8cdc0e295526e6`, SHA-256 `5aeab12ddaa9095883670216726625185c8b045ee01d1c07231a3375521905fd`.
- Protocol riêng `D3_DEMON_MULTIPLIER20_CURRENT_NATIVE_V1`; model vẫn `5d3.demon_minimum.v1`.

Trước live chỉ thay setup admission/cap ở 3module, tool chuẩn bị và 2 file test. 322 file còn lại byte-exact, gồm BASIC, solver, thuật toán Demon, provider/capture/input/QTE/ACK/farm. Các method runtime trong hai module chung cũng AST-exact; source không đổi trong hoặc sau live. Không build/version/Git/release.

## Hai ca minimum đã có bằng chứng

| Yêu cầu | Bằng chứng native | Kết quả |
|---|---|---|
| Đủ Nộ có thể chọn 3 Kiếm x1 dưới setting 4 | Phiên trước: M_f 0d 27218, turn 5, 150 Nộ trước nước, quét 3 Kiếm x1 | REASONING thay nước Hút, exactsent→same-turn WIN STRONG |
| Tính multiplier khi chưa đủ 4 ô Kiếm | Phiên 20, trận 9: M_71378ade, game turn 7/local turn 4, 30 Nộ, 3 ôKiếm→4 hiệu dụng | Certificate chỉ effective 4; đổi nước BASIC, exactsent→same-turn WIN STRONG |

[Gate parent cho minimum 1](../artifacts/5d3_lieyun_reasoning3_live_20261018_024336/gate_decision.json), [witness minimum 2 đã ghép nguồn](../artifacts/5d3_multiplier20_20261018/native_multiplier_witness.json).

Ca x2: BASIC chọn swap `(3,6)→(4,6)`; REASONING chọn `(0,1)→(0,2)`, tọa độ zero-based. Match Khiên dọc tại `(0,1),(1,1),(2,1)` phá 24 ô ở 3hàng đầu. Có 3 ôKiếm, tổng 4nhờ một viênx2. Không có match/cascade Kiếm thường. Job `79187b456a1745ed93cb7fc869a45deb` qua đủ ROOT/FRESH/FINAL, source/turn/srvSeq/board/config khớp và gửi đúng 1 swap.

Trước nước: HP 77098/109491, Nộ 30; boss HP 83362, Shield 1137. Sau nước: boss HP 0, người chơi HP 80736, WIN STRONG và UI nhất quán. Không có ACK riêng; pending được xóa theo terminal cùng lượt, không được gọi là ACK.

Certificate dùng là `OPERATOR_EFFECTIVE4_PHYSICAL_FLOOR2`; nhánh preexisting-Rage không hợp lệ ở 30 Nộ. Tuy nhiên vùng quét cũng có 5 Nộ x1,3 Mana,5 Khiên (6 hiệu dụng),4 Máu,4 Hút. Vì thứ tự cùng đợt chưa chứng minh, không suy từ trận thắng rằng multiplier là nguyên nhân damage độc lập hoặc chứng minh conversion/damage formula. Bằng chứng xác nhận cơ chế đếm và chọn nước; hiệu ứng ngoài scope vẫn UNKNOWN.

## Kết quả toàn phiên 20

| Chỉ số | Kết quả |
|---|---|
| Attempts/completed/WIN | 20/20/20; loss 0, unknown 0, abort 0, recovery 0 |
| Local turns từng trận | 2, 1, 1, 1, 9, 2, 3, 1, 4, 1, 3, 1, 1, 1, 1, 1, 2, 1, 2, 1 |
| Swap gửi/ACK/terminal pending cleared | 39/19/20; không coi terminal cleared là ACK |
| Reasoning | 39 job hoàn thành:1override,38completed retention;117 checkpoint |
| Candidate multiplier phù hợp | 1available,1selected; combined-Rage 0 |
| Diagnostics | 215 record=39 decision+117 selection+39 timing+20 summary;loss 0 |
| Worker | 20 started/20 reaped;component fault 0 |
| Provider | read error 0,DTO rejection 0;882unstable skips giữ trongreport |
| An toàn | mọi critical counter 0;không wrong-turn/stale/duplicate/post-stop input |
| Kết quả/phòng | 20 primary confirms+1bounded retry;BOSS_LOBBY/STOPPED/FARM_TARGET_COMPLETED |
| Thời lượng | 632.518 giây; actual account energy debit UNKNOWN,39 localturns chỉ làproxy |

[Đối chiếu 39 job với input](../artifacts/5d3_multiplier20_20261018/decision_dispatch_joins.json), [hình học mọi candidate](../artifacts/5d3_multiplier20_20261018/native_passive_geometry.json), [sổ multiplier](../artifacts/5d3_multiplier20_20261018/multiplier_cases.json).

Compute 39 mẫu:19.2411–132.4367 ms; decision wait 63.8612–338.9391 ms. Ca x2:compute 19.2411 ms/wait 63.8612 ms. Deadline giữ observation gốc, không resetbudget, không overrun. Native U/server-age/Unity alignment vẫn UNKNOWN; samplemax không là future bound.

Trận 16 có `POSTMATCH_CONFIRM` rồi đúng 1 `POSTMATCH_CONFIRM_RETRY` sau 0.730 giây; owner ghi retry_reserved ở WAIT_BOSS_LOBBY rồi về boss lobby. Đây là nhánh retry có sẵn, được giới hạn 1 lần và giữ preflight; duplicate_postmatch_confirm 0. Không có ảnh log riêng để phân biệt nguyên nhân vật lý của click đầu chưa đóng bảng, nên nguyên nhân đó vẫn UNKNOWN. Không sửa code vì lượt retry này.

## Offline, nguồn và fallback

Trước phiên 20:125focused tests PASS, gồm Demon, operational loader/launch, selector, control và Mega regression; có negative control cho protocol/cap 20, parent 9/auth/hash/cohort sai, và AST/source isolation. Qualification 100chu kỳ cùng source/host chạy completed/missing/expired/Stop/sink failure/guard veto và worker thật trên dữ liệu giả:PASS,loss 0,selector extra tối đa 2.0567 ms. Đây không phải input game.

[Kiểm chứng chuẩn bị](../artifacts/5d3_multiplier20_20261018/preparation_verification.json), [test log](../artifacts/5d3_multiplier20_20261018/focused_tests.log).

ReserveSWAP 6587.1822 ms và margin 100 ms giữ native H/I từ BASIC 3 có provenance, full BASIC wait ceiling và shared host guard. Không gán source mới cho native log cũ. Chưa trigger native planner-error fallback; bằng chứng lỗi/Stop/stale/deadline/sink vẫn offline. Không đồng nhất completed retention với error fallback. BASIC/default/preferences không đổi.

## Giới hạn và bước kế

Acceptance chỉ gồm hai minimum của account/boss/loadout hiện tại, sàn 2 ôKiếm cho certificate; không nội suy setting-minus-one sang tài khoản khác. Joint 3+5 ordering, setup/bait/retained-Shield sau boss, exact boss policy, refill và R2 chưa accepted. Hiệu quả tổng thể chờ 5E.1;29 trậnWIN liên tiếp trên bàn khác nhau không thay thế phép so sánh đó.

9 trận cũ và 20 trận mới đã đóng: **29/29 WIN, remaining 0**. Artifact cũ giữ nguyên PARTIAL đúng thời điểm lịch sử; gate hiện tại mới đóng missing multiplier bằng bằng chứng bổ sung. Không chạy thêm Demon để tìm ca.

Next duy nhất: [5D.4 — Mega Icarus](../prompts/5D4_MEGA_ICARUS_ADAPTIVE_SURVIVAL_ACCEPTANCE.md). Chỉ chọn next, chưa thực thi. Không thêm P.

[Lịch sử 9 trận trước](../artifacts/5d3_multiplier20_20261018/before_docs/reports/5d3_report.md).
