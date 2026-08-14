# Báo cáo Phase 2B.5 — Memory Board Hardening

Kết luận: **PASS STRONG**. Hai trận chơi tay ngày 2026-08-12 đã tạo 48
snapshot hợp lệ qua hai lifecycle độc lập. Không có read error, stale state,
DTO rejection hay sequence/hash ambiguity. Phase 2B.5 dừng tại đây; chưa triển
khai Phase 2C hay bất kỳ input tự động nào.

## 1. Production source

Nguồn GemType/multiplier dùng cho production là
`WsCombatBatch.board : BoardCellDTO[][]` kết hợp với currentness witness
`MatchService._ackedSeqs : HashSet<Int64>`:

- batch phải xuất hiện sau lobby baseline;
- `srvSeq` phải thuộc ACK set hiện tại và phải là ACK cao nhất;
- ACK set được native code xóa khi khởi tạo match mới;
- Board, match ID, BoardWsApplier idle, queue/PendingCombat rỗng, flags và
  `allDots` phải ổn định trước/sau lần đọc;
- cùng state phải qua hai confirmation liên tiếp.

Tất cả 48 snapshot có source chính xác là
`MatchService._ackedSeqs+postLobbyHeap`.

`PendingCombat` và `_pendingBatches` không được dùng làm production source vì
chúng tồn tại quá ngắn: watcher 2.1-2.5 giây lẫn fast poll 0-16 ms đều không bắt
được owner batch. Chúng vẫn là bằng chứng luồng xử lý. BoardWsApplier hiện tại
vẫn là presentation-stability gate.

## 2. Dot có bắt buộc không?

Không. Dot được phân loại là validator/telemetry tùy chọn.

- `allDots` chứa `GameObject`, không phải direct `Dot`.
- `Dot` không có field tag/gem type.
- Phase 2B chỉ tìm tối đa 58/64 bằng bounded anchor scan.
- Acceptance cuối cố ý không chạy Dot anchor scan nhưng DTO vẫn đạt 48 board
  hoàn chỉnh.

Kết luận: bắt buộc Dot sẽ tạo dependency không ổn định mà không tăng tính đúng
của board source.

## 3. CombatSessionKey

Khóa session chính xác:

`(lifecycle_epoch, Board.Instance, MatchService.CurrentMatchId)`

Epoch cục bộ ngăn một địa chỉ managed Board được tái sử dụng sau restart trở
thành cùng session. `srvSeq` chỉ có ý nghĩa sắp thứ tự bên trong session, không
được dùng làm session identity.

## 4. Chống stale state

- Scan ở lobby fingerprint toàn bộ complete batch cũ.
- Session mới sao chép baseline và loại mọi identity cũ.
- Board loss xóa tracked/ACK batches, sequence/hash, publish keys, object caches,
  Dot/Card candidates và stability gate.
- Chỉ chấp nhận ACK set hiện tại đã được clear theo match.
- Sequence thấp hơn bị stale; cùng sequence nhưng khác hash bị ambiguous;
  publication yêu cầu sequence tăng nghiêm ngặt.

Kết quả runtime: `stale_skips=0`, `ambiguous_latest_skips=0`. Session 2 bắt đầu
từ seq 5 dù session 1 đã kết thúc ở seq 101, chứng minh reset scope hoạt động.

## 5. Accepted và rejected

| Chỉ số | Kết quả |
|---|---:|
| Provider polls | 3,735 |
| Accepted/published | **48** |
| Valid duplicate bị suppress | 1,014 |
| Unstable/precondition skips | 1,928 |
| Stale skips | 0 |
| Ambiguous-latest skips | 0 |
| DTO rejections | 0 |
| Read errors | 0 |

Các `provider_status` record trong log gồm: duplicate 1,014;
presentation busy/pending 78; chờ stability confirmation 67; latest ACK batch
chưa resolve 36; presentation owner unavailable 7; board absent 3; chưa có ACK
batch hoàn chỉnh 2; current match ID unavailable 2; accepted 48. Những state
chưa ổn định chỉ fail closed, không feed vào solver.

## 6. Completeness

- 48/48 board có đúng 64 cell.
- 3,072/3,072 cell decode thành công.
- Mỗi board có đủ 64 tọa độ unique trong `0..7 × 0..7`.
- Không missing coordinate, duplicate coordinate hay malformed jagged array.
- 48 accepted hash đều unique theo các transition được publish.

## 7. Gem và multiplier validity

Mọi tag đều map exact vào sáu gem đã có bằng chứng; không fuzzy inference.

| Gem | Số cell |
|---|---:|
| shield | 589 |
| rage | 570 |
| mana | 549 |
| health | 499 |
| drain | 462 |
| sword | 403 |

| Multiplier | Số cell |
|---|---:|
| x1 | 2,517 |
| x2 | 291 |
| x3 | 122 |
| x4 | 142 |

Không có multiplier ngoài `{1,2,3,4}`. Trận acceptance có đầy đủ x2/x3/x4.

## 8. Dot statistics

Acceptance cuối: `dot_anchor_scans=0`, `dot_anchor_bytes=0`,
`dot_complete_polls=0`, `dot_incomplete_polls=2,795`; audit report 0/64 vì
production path không chạy scanner đắt và không phụ thuộc Dot.

Đối chiếu lịch sử Phase 2B đạt tối đa 58/64. Nguyên nhân đầy đủ của sáu Dot còn
thiếu vẫn là PARTIAL/UNKNOWN; không được suy đoán Unity native pointer chain.

## 9. Visual overlay audit

Mỗi accepted state tạo một PNG overlay và một JSON audit: tổng 48 PNG + 48 JSON.

Đã kiểm tra tay 20 mẫu phân bố trên hai session:

- Session 1 seq: 11, 15, 19, 24, 28, 32, 36, 40, 45, 49.
- Session 2 seq: 5, 7, 9, 11, 15, 17, 19, 23, 25, 52.

Kết quả 20/20: tâm cell, biên lưới, top/bottom, nhãn gem và multiplier khớp
hình game. Một số mẫu session 2 có banner cảnh báo ba lượt phủ trong suốt nhưng
cell vẫn kiểm tra được. Hai ảnh cuối seq 101/98 bị end-of-battle UI che đáng kể;
geometry vẫn thẳng hàng nhưng không được tính vào 20 mẫu human-visible. Đây là
hạn chế timing của ảnh audit, không phải mismatch đã quan sát.

## 10. Coordinate validation

Quy ước duy nhất:

`screenRow = 7 - runtimeRow`, cột giữ nguyên.

Toàn bộ 3,072 cell thỏa phép biến đổi và đủ unique trong cả runtime/screen
space. Cả 37 move đều ghi `from/to` ở hai hệ tọa độ và thỏa đúng phép inverse;
không có transformation error.

## 11. Shadow solver decision

V1 solver hiện tại được gọi qua adapter, chỉ shadow mode:

- 37 move hợp lệ;
- 11 quyết định skip;
- maximum consecutive skip là 2 ở cả hai session;
- watcher không chứa/call input executor, không click và không gửi game method.

Giới hạn hai skip liên tiếp phải tiếp tục được giữ ở executor boundary trong
phase input sau này vì game out ở lượt bỏ thứ ba.

## 12. Hai lifecycle runtime

| Thuộc tính | Session 1 | Session 2 |
|---|---|---|
| Epoch | 1 | 2 |
| Match ID | `M_b8d05886` | `M_9c4568a8` |
| Board.Instance | `0x000002877F168540` | `0x0000028624181540` |
| Accepted boards | 21 | 27 |
| Seq range | 11 → 101 | 5 → 98 |
| Unique hashes | 21 | 27 |
| Moves / skips | 19 / 2 | 18 / 9 |
| Max consecutive skips | 2 | 2 |

Hai lần `board_lost` được quan sát và watcher tự dừng sau khi đạt 2 match cùng
tối thiểu 20 snapshot.

## 13. Blocker trước Phase 2C

Memory board không còn blocker cho shadow integration. Trước khi cho phép input
cần giải quyết riêng:

1. actionability gate: còn combat, đúng local turn, player/boss còn sống, không
   modal/game-over và board có thể nhận thao tác;
2. executor policy giữ hard ceiling tối đa hai skip liên tiếp;
3. xác nhận rõ quyền bắt đầu Phase 2C. Hiện chưa có input implementation.

Dot 64/64 không phải blocker. Overlay capture có thể rơi đúng modal cuối trận;
nên lọc modal để artifact audit sạch hơn nhưng điều này không ảnh hưởng board
memory đã publish.

## 14. File đã tạo/sửa

Tạo mới:

- `src/pokiguard_v2/acked_sequences.py`
- `src/pokiguard_v2/audit_overlay.py`
- `tools/memory_board_overlay.py`
- `tests/test_acked_sequences.py`
- `tests/test_phase2b5_hardening.py`
- `docs/memory_board_hardening.md`
- `docs/phase2b5_report.md`

Sửa:

- `src/pokiguard_v2/state.py`
- `src/pokiguard_v2/live_state.py`
- `src/pokiguard_v2/il2cpp_external.py`
- `src/pokiguard_v2/memory_board_provider.py`
- `docs/board_data_sources.md`
- `docs/il2cpp_symbols.md`

Evidence chính được tạo:

- `logs/phase2b5_ack_acceptance_20260812_101533.jsonl`
- `logs/phase2b5_ack_20260812_101533.stdout.log`
- `logs/phase2b5_ack_20260812_101533.stderr.log`
- `logs/audit/session_001_M_b8d05886/` (21 PNG + 21 JSON)
- `logs/audit/session_002_M_9c4568a8/` (27 PNG + 27 JSON)

Các exploratory log `phase2b5_acceptance_20260812_092401*` và
`phase2b5_acceptance_fast_20260812_095053*` được giữ làm bằng chứng vì sao
transient owner không thể là production source.

Không sửa `D:/PokiguardAuto` hay `D:/pc`.

## 15. Tests và verification

- Unit suite: **58/58 PASS**.
- `compileall` cho `src`, `tools`, `tests`: PASS.
- Runtime: 2 manual matches, 48 accepted boards, 96 artifacts, zero read error.
- Quyền process: chỉ `PROCESS_QUERY_INFORMATION | PROCESS_VM_READ`.
- Không `WriteProcessMemory`, injection, hook, patch, direct RequestSwap,
  SendMove, network manipulation hay input tự động.
