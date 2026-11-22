# Demon — thu hẹp exclusion có bằng chứng bàn, 19/11/2026

Sau khi đóng phiên [1 BASIC + 1 R](DEMON_CAPTURE_NATIVE_20261119.md), đã sửa
một lỗi lọc dữ liệu offline: exporter chỉ cho scope `INVALID`, nên hai
`UNAVAILABLE/COMBAT_STEPS_ABSENT` dù nằm trên accepted board offer hợp lệ
vẫn bị coi là khoảng lỗi không rõ identity và chặn toàn bộ boss intervals.

**Chỉ thêm `UNAVAILABLE` vào các trạng thái có thể kiểm scope.** Vẫn bắt
buộc accepted dispatcher-board offer, đúng event/schema, đủ64 ô, board hash
tái dựng khớp, match/epoch/sequence nhất quán, không có effect evidence,
damage prediction hoặc input authority. Không tin chỉ thứ tự dòng log;
drain không có independent board scope, hash sai, unknown status, JSON lỗi
và duplicate xung đột tiếp tục fail closed. Gap trong interval tiếp tục
chặn interval đó, kể cả drain muộn; gap nằm giữa dòng vẫn chặn.

Không dùng chỉ mục summary thay effect hoặc bỏ qua các bước xác minh bàn.
Không thay `UNAVAILABLE` thành `CAPTURED`, không sửa raw log, không tạo
hiệu ứng0. Toàn bộ17 typed observations và2 capture exclusions giữ nguyên.

Kết quả trên match `M_3354d4e8`, raw combat SHA
`27c7775a61616f4aa07625862a1d8467edcbb471cc5a7b1d234183444a66b223`:

| Dữ liệu đã có | Trước | Sau |
|---|---:|---:|
| Boss intervals đủ điều kiện | 0 | 8 |
| Published resource intervals đủ điều kiện | 0 | 15 |
| Typed observations | 17 | 17 |
| Capture exclusions còn giữ | 2 | 2 |

Hai negative scopes được xác minh độc lập là response32/37. Một boss
response không có exact single swap vẫn không được biến thành boss move.
Trong15 resource intervals,36 update có32 exact và4 cap/floor;30 lastStat
khớp endpoint. Chúng là mô tả dữ liệu, không là damage/Nộ formula hoặc
nhãn nước tối ưu. Cả8 boss interval tiếp tục completeness UNKNOWN và không
được gán training eligibility.

Source trước đã live:
`b3ab48cea3da7ae0751912004650608eebabb10e75e292902ba4ed5e2042a546`.
Source sau sửa offline:
`86c22524a56d04e2fe4cea2f28d49ddc395d0bd85ba13b2f63c2218a339c4e1c`.
Manifest chỉ đổi `tools/normalize_boss_transitions.py` và test scope;
mọi file runtime dưới `src/`, adviser và input giữ nguyên byte. AST của
exporter chỉ đổi điều kiện trạng thái trên và docstring. **67 test PASS**,
bao gồm negative/in-range/late-drain và consumers resource/board/outcome.

0 trận mới sau source change, không build/train hoặc rebind profile. Native
proof và profile mới thu vẫn pin source `b3ab48ce…`; không đổi chúng sang
source mới hoặc sửa closure đã đóng. Phiên native mới2/2 đã đóng, tổng17.
Khoảng trống capture BASIC response12 và ba effect của match cũ vẫn UNKNOWN,
không bị bản sửa scope này biến thành dữ liệu có sẵn.

**Tiếp theo:** audit offline ownership/lifetime và điều kiện lọc root của
collector để thu hẹp phần response chưa được quan sát. Không chạy thêm
trận, tăng nhịp đọc hoặc nới giới hạn dựa vào suy đoán. Demon vẫn ưu tiên,
Mega/Galaxy để sau.

[Bằng chứng trước/sau, tests và SHA](artifacts/demon_unavailable_scope_20261119/verification.json) ·
[Dữ liệu sau audit](artifacts/demon_unavailable_scope_20261119/after_review.json) ·
[Script tái hiện](artifacts/demon_unavailable_scope_20261119/verify.py).
