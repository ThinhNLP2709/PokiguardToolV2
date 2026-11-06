# Sửa atomic checkpoint trên Windows — 05/11/2026

Đã sửa source, kiểm offline PASS. Chưa build, chưa mở tool hoặc phát input/trận mới.
Source hiện tại: `3badf8c5710fc22740cd20dc66d0e19d5d39d6dcd4c13a39dc587fd55a102523`.

## Chứng cứ và giới hạn kết luận

Phiên Lion Star `056123caedc5453c965f757f36682f1a` đã thắng, nhận thưởng và về phòng. Checkpoint `COMPLETED` seq3 ghi thành công lúc 00:00:27.348 ngày05/11 (+07); lần finalization kế tiếp lỗi `os.replace` lúc .358 với WinError5. Vì lỗi ghi cuối, raw `run.json` báo SAFE_STOP/NOT_PROVEN, exit2. Giữ nguyên các log/receipt lịch sử này.

Đã tái hiện **đúng WinError5 thật trên Windows** bằng cách giữ `checkpoint.json` mở qua Python `open('rb')`, rồi gọi writer trước sửa. Nội dung checkpoint trước không đổi và temp được dọn. Đây là một cơ chế gây lỗi đã chứng minh; không xác định được PID/handle nào đã giữ file trong phiên lịch sử. UI `CheckpointSummaryReader.read_latest` cũng đọc qua `load_checkpoint`/`Path.read_text`, nên có đường đọc đồng thời trong tool. Không khẳng định antivirus hoặc game gây lỗi.

[Ca tái hiện trước sửa](artifacts/checkpoint_replace_20261105/before_reproduction.json).

## Thay đổi

`farm_checkpoint.write_checkpoint` vẫn validate → ghi temp cùng thư mục → flush/fsync → đóng handle → atomic replace. Riêng replace lỗi Windows5/32/33 được thử lại tối đa7 lần; các khoảng chờ10/20/40/80/160/200ms, tổng thời gian sleep cấu hình0.51s. Không sleep khi ghi bình thường. Không xóa/truncate checkpoint cũ, không tái sinh payload/sequence trong mỗi retry, không retry JSON/fsync/lỗi khác. Lỗi dai dẳng vẫn ném exception để `_persist_checkpoint` ghi lỗi và giữ fail-closed hiện có.

135 test/7module PASS, gồm reader Windows thật nhả khóa rồi ghi thành công, giả lập cả5/32/33, khóa dai dẳng giữ file cũ/dọn temp, lỗi khác không retry, và hai lần final checkpoint qua controller/writer thật. Không sửa schema/resume validation hoặc giả thành công khi dữ liệu chưa ghi được.

Phần admission timing chỉ bổ sung đúng hash của bản checkpoint đã review; kiểm current source/host/build, raw ACK và các file input vẫn giữ nguyên. Đã chạy qualification current source14gates (42 disabled BASIC parity,100triple) và load profile source hiện tại thành công với14ACK gốc chưa đổi nhãn. Profile file-only ở `artifacts/checkpoint_replace_20261105/ready_only/`, chưa cài vào phiên chạy nào. Chiến thuật/adviser, đọc memory, click, QTE, PASS và thứ tự vòng farm giữ nguyên byte theo manifest trước task.

[Receipt](artifacts/checkpoint_replace_20261105/closure.json),
[test log](artifacts/checkpoint_replace_20261105/verified_tests.log),
[qualification](artifacts/checkpoint_replace_20261105/qualification_final/qualification.json).

Phiên tool đã mở trước bản sửa vẫn chạy code cũ; lần test kế tiếp cần mở phiên mới. Kết quả offline này chưa phải xác nhận live của bản sửa hoặc nghiệm thu Suy luận cho mọi lối chơi.
