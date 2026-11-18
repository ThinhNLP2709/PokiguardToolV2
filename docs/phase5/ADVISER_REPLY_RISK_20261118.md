# Adviser: phản hồi boss và dữ liệu để học tiếp — 18/11/2026

Đã hoàn tất phần offline kiểm được trong đợt tự làm khi user tắt game.
Hai thay đổi ở source: mở rộng coverage rủi ro phản hồi boss và ghi lại chính
problem mà adviser nhận, để những lần nghiên cứu sau không phải đoán lại dữ kiện.
Chưa build, nghiệm thu native hoặc fit damage; version hiện tại vẫn1.3.6.

## Rủi ro không chỉ nằm ở nước nhiều Kiếm nhất

Probe2.736 root từ205 snapshot đã lưu tìm được10 root mà một nước ít Kiếm
hơn có threat proxy cao hơn vì còn lấy Mana/Nộ/hồi máu hoặc Hút. Ví dụ Demon
development41: phản hồi5 Kiếm có proxy0,678884; một phản hồi4 Kiếm kèm tiến
triển tài nguyên0,6 có proxy0,693107. Đây là phép tính theo model cấu trúc
hiện có, không phải số damage hay bằng chứng boss sẽ chọn nước đó.

Giữ Sword-first như tham chiếu có điều kiện. Feature T nay là khoảng từ
worst-single-reply trong tập tham chiếu đến worst-single-reply trong toàn bộ
phản hồi **trên ô đã biết**. Không trộn Kiếm của một nước với Mana/Hút/Máu
của nước khác. Không suy xác suất boss hoặc gem refill.

T thiếu conversion/effect hoặc local residual chưa giải quyết vẫn UNKNOWN;
khoảng tham chiếu mới không ghi đè trạng thái đó. Policy boss chưa biết thì
tập tham chiếu vốn là tất cả các phản hồi, không có phần chênh do giả định
Sword-first. Trọng số, margin, budget, shortlist và luật PASS giữ nguyên.
Summary của worker giữ cả khoảng và nước phản ví dụ có giới hạn để đọc log.

## Đối chiếu và giới hạn dữ liệu

| Tập | Ca | Đổi lựa chọn | Nhìn trước hoàn tất trước → sau |
|---|---:|---:|---:|
| Demon nhiều lượt đã lưu |100|0|95 →95|
| Hồi quy nhiều lối chơi đã lưu |105|0|92 →92|
| Mega sau tiến hóa, có loại ấn trong snapshot hiện tại |334|0|331 →331|
| Galaxy, swap đã ACK |27|0|25 →25|
| Tổng |566|0|543 →543|

566 lựa chọn đều hợp lệ.23 ca còn lại dùng kết quả một bước hoàn tất ở cả
hai phía. **Không đổi lựa chọn trong corpus này, chưa chứng minh tăng tỷ lệ
thắng.** Thay đổi giúp phản ánh rủi ro ở các nhánh chưa thành nước tối ưu trong
các mẫu hiện có; không tune trọng số để ép tạo override.

- 205 snapshot cũ giữ SHA, gồm24 ca Khủng long dùng lại bàn Đơn giản.87 combat
  gốc của phần Demon cũ không còn tại đường dẫn trước đây; không tái attestation
  raw hay ACK cho tập đó. “Holdout” trong metadata là cách chia cũ, không phải
  một tập nghiệm thu mới chưa từng được xem.
- 361 ca bổ sung trích từ8 combat còn tồn tại. Đối chiếu SHA file, thứ tự
  action/ACK và toàn bộ identity. Chỉ dùng stats/board/cardDiagnostics tại
  `action_sent` và sự kiện tiến hóa thành công **đã xảy ra trước đó**.
  Loại55 lượt chưa chứng minh giai đoạn tiến hóa,7 lượt thiếu/không rõ loại
  ấn,1 lượt không có ACK đúng thứ tự.
- Các ca bổ sung chỉ đánh giá swap. Không dựng giả quyền skill/PASS hoặc chi
  phí Nộ còn thiếu; không mượn dữ kiện thẻ ở lượt sau. Các giới hạn này nằm
  ngay trong intent scope của snapshot. Không dùng kết quả cuối trận làm nhãn
  cho các nước counterfactual chưa từng được gửi.
- Tỷ lệ conversion trong replay là model hiện có, không được fit lại từ log.
  Không suy rộng damage giữa account/pet/loadout/boss/game build.

[Probe](artifacts/adviser_reply_risk_20261118/probe.json),
[replay205](artifacts/adviser_reply_risk_20261118/paired_summary.json),
[replay361](artifacts/adviser_reply_risk_20261118/extra_summary.json).
Kết quả chi tiết và input361 được nén gzip, có SHA bản nén/lẫn bản gốc trong
[manifest](artifacts/adviser_reply_risk_20261118/compressed_manifest.json).

Thời gian planner trên máy này, một lượt đo xen kẽ trước/sau, không phải SLO:
205 ca p50 124,12→126,82 ms; p95 455,67→468,99 ms.361 ca p50
111,98→113,78 ms; p95 332,66→285,41 ms. Dao động max/p95 không đủ kết luận
tăng tốc; không cộng phép đo offline thành timing authority native.

## Lưu đúng đầu vào adviser cho các lần test sau

`reasoning.common_snapshot` ghi problem bất biến sau khi admission dựng xong,
ở background owner hiện có, trước submit worker. Có source/config hash,
stats, setting viên mục tiêu, trạng thái tiến hóa, chi phí và action/effect
được owner công bố tại thời điểm đó. Không đọc thêm game hay dựng lại state.
Nếu một chi phí/capability thiếu từ nguồn, snapshot vẫn giữ thiếu.

- Chỉ chạy khi bridge suy luận được bật và đã nhận request. AI tắt không tạo
  bridge, queue hoặc thread mới. Không thêm worker/writer riêng.
- Dùng writer/buffer hiện có, enqueue không đợi, noncritical, không retry.
  Giữ cap32768 byte/event và các cap queue/retention hiện tại. Payload quá
  lớn thành record `truncated`, không thành snapshot một phần hợp lệ.
- Lỗi encode/queue riêng của snapshot chỉ tăng counter queued/dropped/error;
  không làm `disabled=true`, không dừng farm, không sửa deadline hay cấp input.
  Guard cũ của một writer đã hỏng vẫn giữ hành vi fallback như trước.
- Hash/correlation/version/provenance không khớp hoặc truncation bị decoder
  từ chối. Snapshot không chứng minh đã gửi action, ACK, win hay damage;
  cần join các log đó riêng. Không dùng nó để cài native profile.
- Đã có test worker và host thật khi sink cố tình ném lỗi riêng cho snapshot:
  quyết định vẫn hoàn tất, AI không bị disable và worker được dọn.

1000 phép encode packet giả lập đầy đủ:6694 byte/event, p50 0,273 ms,
p95 0,474 ms, max1,641 ms. Đây chỉ là encode ở background, không phải độ trễ
native hay flush đĩa. [Receipt](artifacts/adviser_reply_risk_20261118/snapshot_benchmark.json).
Smoke export1 snapshot là dữ liệu **SYNTHETIC**, không cộng vào566 ca hoặc
coi là một trận thật mới.

```powershell
$env:PYTHONPATH = Join-Path (Get-Location) 'src'
python -B tools/extract_common_snapshots.py --logs <thu-muc-log-suy-luan-cua-run> --out temp/reasoning/common-snapshots-new.json
python -B docs/phase5/artifacts/adviser_reply_risk_20261118/replay.py --out temp/reasoning/reply-risk-replay-new
```

Replayer đọc snapshot đã pin SHA; không tái xác minh raw native còn tồn tại
ở lần tái chạy. `--limit 3` chỉ smoke-test script, không thay phép đối chiếu
566 ca đã hoàn tất ở hai receipt trên. Output phải mới để giữ bằng chứng cũ.

## Kiểm thử, phạm vi source và điểm dừng

**Bộ kiểm cuối154/154 PASS**, gồm adviser/worker/host, capture, diagnostics,
control, projection compatibility và lựa chọn Tự bảo vệ. Không gọi đây là
toàn bộ test repository. Lỗi lịch sử `calibration_projection()` đã được sửa
ở công cụ đối chiếu offline sau khi kiểm đúng thay đổi tương thích.
SHA file runtime calibration vẫn là
`de85959c3d9b7d07eab624352b5793532ba1f7c473cbddb33914023832108fd9`, đúng SHA
đã ghi khi lỗi xuất hiện17/11. Runtime decoder không bị sửa.

Review chỉ nhận đúng đoạn backfill khi cấu hình cũ thiếu **một** trường
`mega_self_protection`, đúng toàn bộ SHA trên, và default còn là
`hp_below_30` như hành vi Mega cũ. Gỡ đúng đoạn migration được nhận diện để
so sánh AST còn lại, không bỏ qua cả hàm decoder. Sửa đoạn migration,
default, field khác, control/timing code hoặc SHA chưa review vẫn bị từ chối.
Test xác minh thiếu field khác/field lạ/enum sai đều reject; các lựa chọn
Không/30%/10% đã ghi tường minh vẫn được giữ. Không đổi raw timing proof,
native loader, reserve, cap, source binding hay tự tạo authority mới.
[Review](artifacts/adviser_reply_risk_20261118/calibration_compatibility_review.json).

Chỉ4 method của các file runtime có sẵn thay đổi trong đợt này:
`_score`, `evaluate_context`, `_decision_summary`, `_execute`, cộng1 module
capture mới. AST ngoài4 method và import capture mới khớp baseline đã lưu.
Thay đổi qualification nêu trên chỉ nằm ở `tools/qualify_common_reasoning.py`;
AST ngoài phép projection và helper mới của file này cũng khớp baseline.
BASIC, luật bỏ lượt do game, solver/geometry, read/input/ACK/QTE, FarmRunner,
native admission, version và các quyền hiện có không đổi. Không sửa game,
khởi động farm, repin profile hay build mới.

[Receipt cuối và log test](artifacts/adviser_reply_risk_20261118/verification.json),
[patch của đợt này](artifacts/adviser_reply_risk_20261118/change.patch).
Baseline, input hashes và source hashes được giữ cùng thư mục. Scratch và
bản phân tích dùng một lần vẫn ở `temp/reasoning/adviser_reply_risk_20261118/`.

Điểm dừng là kiểm native trên source mới và dữ liệu hiệu ứng có attribution.
Hai quan sát damage không terminal vừa thu đã chuẩn hóa ở
[báo cáo riêng](COMBAT_NORMALIZATION_20261118.md), còn thiếu dmgSrc/context
và đủ biến thiên để hiệu chuẩn. Không thể xác nhận thắng tốt hơn hoặc fit
damage/skill chắc chắn bằng việc sửa trọng số trên các board cũ. Khi user
quay lại, cần chuẩn bị kiểm source/transport với cap mới, rồi thu trận đủ
nhiều lượt và skill đã xác nhận. Các cap1 BASIC trước đây đã dùng hết.
