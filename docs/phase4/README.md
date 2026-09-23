# Phase 4 — Background Input Beta

Thư mục này là nguồn điều phối cục bộ cho toàn bộ Phase 4. Sau khi Phase 4 bắt
đầu, không cần sao chép prompt từ một cuộc trò chuyện bên ngoài. Khi người dùng
nói `tiếp tục`, agent phải đọc theo thứ tự:

1. `AGENTS.md`;
2. `docs/phase4/STATUS.md`;
3. `docs/phase4/ROUTER.md`;
4. báo cáo mới nhất được ghi trong `STATUS.md`;
5. prompt mà router chọn trong `docs/phase4/prompts/`;
6. các tài liệu canonical được prompt đó liệt kê.

## Mục tiêu sản phẩm

Phase 4 đánh giá và, nếu bằng chứng cho phép, bổ sung **Click nền (Beta)** cho
V2. `Click nền` có nghĩa là gửi input tới đúng HWND/PID của game mà không di
chuyển con trỏ hệ thống và không bắt buộc game là foreground.

Không được tự động diễn giải `Click nền` thành:

- hỗ trợ cửa sổ minimized;
- hỗ trợ mọi cửa sổ bị che;
- hỗ trợ QTE keyboard;
- hỗ trợ navigation/re-entry;
- chạy hoàn toàn không bao giờ lấy foreground.

Mỗi khả năng trên chỉ được bật sau khi phase tương ứng có bằng chứng live và
đạt `PASS STRONG`.

## Trạng thái kỹ thuật đã biết khi tạo roadmap

- V1 Beta dùng `PostMessageW` với `WM_MOUSEMOVE`, `WM_LBUTTONDOWN` và
  `WM_LBUTTONUP`; không có delivery ACK riêng và README của V1 nói Unity có thể
  không nhận trên mọi máy.
- V2 đọc board/lượt/tài nguyên/ACK từ memory read-only nên combat có nền tảng
  tốt hơn V1 để kiểm chứng input nền.
- V2 mặc định swap bằng drag; hai-click vẫn tồn tại như một option.
- Card/QTE dùng click thẻ, các phím hướng và Space. Game đọc hướng qua
  `UnityEngine.Input.GetKeyDown`; background keyboard hiện là `UNKNOWN`.
- V2 hiện chặn input khi mất foreground tại nhiều tầng. Không được bỏ hàng loạt
  các gate này trước khi có contract thay thế.
- Một số route entry/recovery/re-entry dùng ảnh lấy từ desktop screen DC. Khi
  game bị che, ảnh đó có thể là nội dung cửa sổ đang che game.
- Minimized hiện bị backend xem là window không hợp lệ.

## Nguồn sự thật

Ưu tiên khi có xung đột:

```text
chỉ dẫn hiện tại của người dùng
→ AGENTS.md
→ docs/DECISIONS.md
→ docs/CURRENT_STATE.md
→ báo cáo/log mới nhất của Phase 4
→ STATUS.md và ROADMAP.md trong thư mục này
→ tài liệu Phase 3 được dùng làm mẫu
```

Các tài liệu Phase 3 trong `Downloads` chỉ là mẫu cấu trúc. Dữ kiện cũ như
version, commit, số test, roadmap Pet Skill hoặc quy tắc đã bị repository mới
thay thế không được coi là chỉ dẫn hiện tại.

## Biên kỹ thuật

Giữ nguyên các biên hiện tại của dự án:

```text
PokiguardToolV2 = writable
PokiguardAuto   = reference only
pc              = strict read only
```

Không dùng:

- process-memory write;
- injection/hook/remote thread;
- patch game;
- gọi trực tiếp method gameplay IL2CPP;
- gọi trực tiếp `RequestSwap`, `SendMove`, QTE hoặc skill method;
- packet/WebSocket manipulation;
- sửa/giả protocol sequence.

Input Phase 4 phải đi qua API Windows bình thường tới đúng HWND đã bind. Mọi
state và ACK vẫn phải đến từ đường read-only hiện có.

## Quy tắc live test

- Người dùng điều khiển Windows/game và chuẩn bị trạng thái live.
- Agent hướng dẫn từng bài, khởi động tool/harness khi được yêu cầu và đọc log.
- Không dùng computer-use để tự điều khiển game.
- Không gửi thử nhiều input transport trong cùng một action chưa xác nhận.
- `PostMessageW == success` chỉ chứng minh message được queue, không chứng minh
  Unity hoặc server đã nhận.
- Một input không có ACK phải fail closed; không spam/retry mù.
- Không minimize game trong phase nào trừ khi prompt đó ghi rõ đã có entry gate
  cho minimized.

## Các mode có thể xuất hiện

```text
FOREGROUND
  Toàn bộ input dùng đường foreground hiện tại. Đây luôn là mặc định.

BACKGROUND_MOUSE_BETA
  Chỉ những mouse domain đã được live-prove mới chạy nền.

BACKGROUND_FULL_BETA
  Mouse + QTE direction + Space đều đã được live-prove và ACK.

HYBRID_QTE_FOREGROUND
  Mouse/board chạy nền; skill QTE dùng bounded foreground handoff.
```

Không được hiển thị hoặc lưu một mode nếu capability tương ứng chưa được đóng
bằng `PASS STRONG`.

## Quy tắc tiến phase

- Chỉ `PASS STRONG` mới tự động tiến tới phase roadmap kế tiếp.
- `PASS`: giữ nguyên phase và tạo một closure/remediation nhỏ cho bằng chứng còn
  thiếu.
- `PARTIAL`: tiếp tục đúng phase hiện tại, không mở scope mới.
- `BLOCKED`: dùng nhánh thay thế trong `ROUTER.md` hoặc dừng để chờ quyết định
  người dùng khi thật sự cần.
- `FAIL`: sửa regression/safety trước; không tiến roadmap.
- Remediation dùng `prompts/REMEDIATION_TEMPLATE.md`, đặt tên `4X.Y-Rn`.

## Git/checkpoint chung

Mỗi prompt phải bắt đầu bằng status/HEAD/upstream/diff inspection. Không commit
trước khi offline/live boundary bắt buộc hoàn tất. Khi phase đạt `PASS STRONG`
và được chốt theo workflow hiện tại:

1. stage đúng code/tests/docs/artifacts của phase;
2. giữ nguyên mọi file unrelated/user-owned;
3. chạy diff-check cuối;
4. commit focused;
5. push đúng branch/upstream hiện tại;
6. verify HEAD/upstream equality;
7. cập nhật `STATUS.md` và report với trạng thái Git thực tế.

Nếu unrelated files làm worktree không hoàn toàn sạch, báo chính xác và yêu cầu
`phase-owned diff = clean`; không xóa/stage chúng để tạo một clean claim giả.

## Bản đồ file

- `STATUS.md`: con trỏ phase/prompt hiện tại và capability matrix đã chấp nhận.
- `ROADMAP.md`: mục tiêu/gate của từng phase.
- `ROUTER.md`: chọn prompt tiếp theo từ kết quả thực tế.
- `HANDOFF_TEMPLATE.md`: mẫu báo cáo chung.
- `prompts/`: prompt triển khai đầy đủ.

## Điểm bắt đầu

Điểm bắt đầu khi tạo bộ tài liệu này là:

```text
Phase 4A.0 — Background Input Transport Audit
docs/phase4/prompts/4A0_BACKGROUND_INPUT_TRANSPORT_AUDIT.md
```

Không build package mới trước Phase 4E.1.
