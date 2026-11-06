> Cập nhật 02/11/2026: phần dưới ghi trạng thái offline trước B14. Source hiện
> đã có UI intent chung và đường native nhận proof timing mới; xem
> [COMMON_AI_ASSISTANT](COMMON_AI_ASSISTANT.md). Native vẫn PENDING, chưa bật
> bằng proof cũ. Quy tắc Nộ cùng vùng phá được dùng như tham khảo danh nghĩa
> có nguồn user, không phải kill certificate. Các receipt/source cũ giữ nguyên.

# Suy luận dùng chung sau 1.3.0 — lõi offline đã kiểm

01/11/2026. Yêu cầu gốc: [NEXT_REASONING_SCOPE](NEXT_REASONING_SCOPE.md).
Baseline giữ riêng: commit`e3e3dee90dd09ecd51961c06d0b390dbb04994b5`,
ZIP1.3.0 SHA`130a899d19b9b784678649a3acb9d5cfdfb6c262e2d883c68390664e40893b98`.
Không sửa ZIP này, không chạy thêm game hoặc dùng lại cap đã đóng.

## Những gì đã xác định từ source/reverse

- Có7lối chơi hiện tại, bao gồm Khủng long và Bú win. Legacy snapshot/worker
  chỉ liệt kê6profile, chưa có Khủng long; Dinosaur runner chưa nhận adapterR.
- `reasoning_planner` đã có bộ feature/weight chung và5targetDemon; geometry
  trong `demon_aegis` đã nhận targetGem. Tuy nhiên live D3 chỉ xét2certificate
  theo Khiên/account/Lieyun77 và không chấm setup/bait. Mở radio không giải quyết
  được phần mô hình/adapter đang thiếu.
- B3 có enumerate boss Sword-first/all ties và followup nhưng chỉ là research,
  cố ý không promote kết quả; passive residual/cascade của Demon chưa hỗ trợ.
- HT7/Mega đã có effect/capability/PASS evidence riêng. Cần đưa thành capability
  của action trong chung một chooser, không dùng PlayStyle hoặc threshold làm
  điều kiện cho phép skill. QTE/executor/source fences giữ owner hiện tại.
- Reverseb12 C# declarations mô tả Board/DTO/client; không đủ chứng minh mọi
  hiệu ứng server, refill, damage hoặc thứ tự gain/cost trong một đợt. Không
  suy RVA/offset hoặc công thức mới từ tên method.

## Thiết kế dùng chung

Một problem bất biến =source/config/board đã có +incumbent BASIC +quyền action
do owner hiện có công bố +effect facts có provenance. Một chooser dùng cùng
feature, risk/uncertainty và thứ tự so sánh cho mọi style. Style chọn mục tiêu/
trọng số; setting là reference/advisory. Skill/PASS/effect là capability có
điều kiện riêng; action không có model không được gán utility0 để làm đối thủ thắng.

Tái dùng simulator, collapse, cascade và geometry. Xét112cặp swap; lookahead
có giới hạn gồm incumbent và các root đại diện. Boss Sword-first giữ mọi tie;
không có Sword thì giữ các lựa chọn non-Sword. Setup được tính sau boss;
không cộng điểm vì trước boss còn một match mục tiêu. UNKNOWN không tạo gem,
không được tính thành Sword hoặc thành an toàn tuyệt đối.

Khi chưa đủ công thức damage, dùng proxy có nhãn và giới hạn coverage; không
chứng nhận kill/survival. Certificate cũ giữ scope cũ. Effect pet còn thiếu thì
giữ incumbent hoặc so sánh trong phần đã có model, ghi rõ phần không xét được.

Worker/budget/log/preflight/Stop dùng các ranh giới đã có. Không thêm poll,
memory read, screenshot, action hoặc QTE. Chỉ nối adapter mới khi đã có offline
matrix và fault/parity proof; live cần user chuẩn bị và cap mới đã chốt trước.

## Điểm chốt của đợt này

Hoàn tất chung offline:7styles ×action legality/missingness/fallback,
5targetDemon ×ngang/dọc/x2/x3/setup/boss contest, skill/PASS cùng chooser,
định danh/worker/deadline/log/Stop/parity. Sau đó một matrix live đại diện có
cap tổng, không mở chuỗi P hoặc model training. Chưa gọi các phần đang làm
là đã accepted hoặc tự bật chúng từ hồ sơ1.3.0.

**Đã chốt 01/11/2026:** người dùng xác nhận cả 5 viên dùng cùng phép quét
vuông góc, chỉ đổi viên kích hoạt, và có **Demon Sagui ăn Máu** để kiểm tiếp.
Xác nhận được lưu trong `reasoning_common_models.DEMON_DECLARATION`, gắn
nguồn `USER_DECLARATION`; không đổi thành chứng cứ reverse hoặc native.

## Kết quả triển khai và kiểm chứng ngày 01/11/2026

Đã thêm bốn module `reasoning_common_problem`, `reasoning_common_evidence`,
`reasoning_common_planner`, `reasoning_common_selection`. Worker cũ nhận thêm
problem bất biến của lõi chung; không tạo một executor hay flow game khác.
Controller nhận bridge mới tại đúng các điểm observation/decision/fresh/final
đã có. Khủng long có thêm tham số session tùy chọn; mặc định vẫn chạy như cũ.
Chưa có loader cấp quyền native hoặc đường UI bật lõi chung.

| Phần | Đã kiểm offline | Giới hạn thực tế |
|---|---|---|
| 7 lối chơi | Cùng chooser, giữ đúng định danh/config, legality và fallback | Chưa nghiệm thu native cả 7 lối |
| 5 viên Demon | Ngang/dọc, x2/x3, đếm ô và Kiếm hiệu dụng, boss tranh target; default model có xác nhận user | Native của Sagui ăn Máu và các pet khác chưa kiểm |
| Skill | HT7 Perfect và Mega dùng source/cost/cooldown hiện có; threshold tham khảo | Skill khác không có effect model thì không tự gán điểm 0 |
| PASS | Cùng chooser; chặn lượt đầu, lần bỏ nguy hiểm, owner hoặc proof thiếu | Không thay PASS/QTE/input owner |
| Setup | Xét mọi boss Sword tie; policy chưa biết thì giữ mọi reply đã tính được | Không giả refill; không tuyên bố tối ưu toàn cục |
| Lỗi/deadline/Stop | Dùng đúng incumbent BASIC, kiểm source/config/cap/history, dọn worker | Không cấp lại quyền input sau khi đã gửi |

Nếu phá viên để lại cascade đã biết nhưng chưa có model hiệu ứng tiếp theo,
không coi đó là bàn đã đến lượt boss. Ledger giữ first wave; các feature liên
quan mang interval UNKNOWN, và không cộng future setup từ một residual chưa
giải quyết. Tương tự, baseline CAST/EVOLVE hoặc skill chưa mô hình hóa được
giữ nguyên; missing model là fallback dự kiến, không phải lỗi gameplay.

Worker dùng tối đa 1.8 giây và không quá 45% phần budget còn lại để chừa
thời gian kiểm chứng ở host, trong cùng deadline ban đầu. Host tính lại so
sánh thuần ở luồng nền, không tin điểm/coverage do worker tự khai. ROOT,
FRESH và FINAL kiểm lại source, config, capability, history và quyền PASS;
không chạy solver ở các checkpoint này. Cache tối đa 64 mục chỉ chứa config/
capability bất biến; source và PASS vẫn được kiểm lại ở mỗi checkpoint.

Log dùng sink riêng hiện có và một hàng đợi controller tối đa 64 record,
2 KiB/record. Luồng nền chuyển theo batch có giới hạn; một record bị sink
từ chối tạm thời được giữ để thử lại tối đa 100 ms ở luồng nền. Controller
không chờ đĩa. Lỗi kéo dài chỉ vô hiệu AI và quay lại BASIC.

Evidence của đợt trước xác nhận target tại
`artifacts/common_reasoning_20261101/final_evidence/` (không sửa raw cũ):

- `../final_suite_verified.log`: **158 kiểm tra PASS** trên source cuối,
  gồm model/evidence/host/worker, Khủng long, random, full action và các test
  UI/fallback/lifecycle liên quan. Không gọi đây là toàn bộ test lịch sử.
- `qualification.json`: 42 ca tắt AI so với source controller đúng commit
  1.3.0; call order và semantic trace bằng nhau. Khi có artifact pause, chỉ
  chuẩn hóa phần đồng hồ trong tên đường dẫn chẩn đoán; không bỏ decision,
  reason, input, ACK hoặc bất kỳ field gameplay nào.
- 7 ca bật bridge giữ nguyên thứ tự transport; 5 ca boundary kiểm stale,
  pending, Stop và PID thật. Simple/Careful/Dinosaur hoàn tất suy luận ở
  fixture này. Các profile thiếu effect/capability trong fixture giữ BASIC;
  đây không phải 7 trận hoặc 7 cấu hình pet đã được nghiệm thu.
- 100 bộ ROOT/FRESH/FINAL với worker và disk writer thật: p50 **0.7223 ms**,
  p95 **1.3276 ms**, p99 **1.5390 ms**, max **2.1986 ms** cho cả ba checkpoint.
  Đây là smoke offline, không phải native timing qualification 5000 mẫu.
- 300 checkpoint record riêng biệt được ghi đủ; tổng 302 record được writer
  xác nhận, 0 mất/ghi lỗi/sai producer. Worker 1/1 reaped, writer đã đóng.
- Chỉ 4 file source cũ đổi: worker, context publisher và hai optional seams
  ở controller/Khủng long. 372 file source cũ khác giữ đúng SHA baseline,
  gồm solver, BASIC, provider, input và QTE.

Các lần đo trước và lỗi của harness vẫn giữ trong cùng thư mục artifact,
không ghi đè. Đã sửa việc tái sử dụng cùng file log của harness và việc
consumer log không theo kịp producer. Một bộ test lịch sử đối chiếu snapshot
trước các thay đổi đã phát hành từng báo 7 failure; không sửa raw proof/test
đó để tự cấp acceptance; lần chạy rộng đó không được ghi là PASS. Đối chiếu
hiện tại dùng source 1.3.0 được pin riêng
và ghi đủ giới hạn fixture bên trên.

## Điểm dừng trước native

`CommonAdmission` hiện chỉ nhận `COMMON_OFFLINE_NATIVE_FAKES`; PID thật bị
chặn. Không nới authority cũ, không relabel calibration và không tự bật radio
UI cho các ô chưa kiểm. EXE/ZIP 1.3.0 đã bàn giao không bị sửa; source phát
triển hiện đã khác source pin của profile cũ nên không được dùng profile đó
để tự mở suy luận.

Cơ chế chung cho 5 target đã được user xác nhận. Default builder áp dụng nó
khi đúng cấu hình Demon Farm + PET_PASSIVE, lấy target thực từ cấu hình. Đổi
target làm đổi config/problem identity; stale offer không được dùng lại.
Override `demon_geometry=None` vẫn giữ UNKNOWN/fallback nếu model bị tắt.
Client reverse chưa chứng minh được thứ tự gain/cost/damage server. Vì vậy
combo 3 Kiếm + 5 Nộ trong cùng đợt vẫn chưa được gọi là kill certificate;
chứng cứ cũ chỉ nghiệm thu Nộ đã có trước nước đi và Kiếm hiệu dụng theo
đúng scope cũ. Không mở rộng công thức damage của account đó cho mọi account.

Sau khi chốt effect, bước kế tiếp là một kế hoạch native có cap tổng trước,
theo nhóm effect/action và transport, rồi nối UI khi từng nhóm có chứng cứ.
Không thêm P vô hạn, không chạy thêm trận trong đợt offline này. Live mới: **0**.

## Bổ sung sau xác nhận 5 target

- **170 test focused PASS**: `artifacts/common_reasoning_20261101/confirmed_model_tests_final.log`.
- `declared_final_frozen/qualification.json` là đợt kiểm source cuối sau xác nhận,
  bổ sung 5 cấu hình Demon hợp lệ đi qua BASIC → worker → host → fresh/final,
  không chỉ đổi tên gem ở fixture thuần. Cả 5 hoàn tất model và giữ call order.
- Source **388 file**, SHA `499efbfc347c052532590998b73ea1419bc82d6ab371fbf16ffa19e800a36583`,
  giữ nguyên trong suốt đợt kiểm. 370 file cũ giữ đúng byte; 6 file cũ đổi,
  gồm 5 file runtime/optional setup và 1 helper test. Thêm 12 file đã liệt kê
  rõ trong qualification; không có exemption cho mọi file mới tùy ý.
- 100 bộ ROOT/FRESH/FINAL trên source này: p50 **0.5495 ms**, p95 **0.8461 ms**,
  p99 **1.0727 ms**, max **1.2118 ms** cho cả ba checkpoint; 300/300 checkpoint
  record được ghi đủ, worker/writer đóng sạch. Vẫn chỉ là smoke offline.
- Đã sửa duy nhất phần truyền target trong harness test: trước đó helper không
  chuyển `demon_target_gem` từ GameplayConfig vào CLI args, khiến 4 cấu hình
  ngoài Khiên bị config mismatch và fallback đúng. Production CLI đã truyền
  target; không sửa BASIC để làm fixture qua. AST projection pin đúng thay đổi.
- Thêm protocol `COMMON_DEMON_TARGET_BASIC_CONTROL_V1` cho collector BASIC
  đã có, hỗ trợ 5 target trong một cohort mới, tối đa 3 lượt thử. Các protocol
  lịch sử giữ nguyên AST sau khi bỏ đúng nhánh/constant mới; không nới D3 Shield.
- [Kế hoạch trường hợp Sagui](COMMON_SAGUI_LIVE_PLAN.md) là draft chưa active,
  không tạo request/claim hoặc tự Start. Nguồn test mới không kế thừa acceptance
  hay kill certificate của Demon Aegis ăn Khiên.
