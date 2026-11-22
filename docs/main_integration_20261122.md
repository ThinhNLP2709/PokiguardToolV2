# Chốt Demon và tích hợp updater/migration vào main — 22/11/2026

Checkpoint Demon: `72604edfd92eb069117de8aa4063d47af666a5c0`.
Nhánh updater/migration: `codex/self-service-compatibility`, đầu nhánh
`3a0df30dad96986644f35755b39ff74c7b8b580c`.

Đã fetch origin và xác minh đầu nhánh updater là tổ tiên của `main`; lệnh
merge trả `Already up to date`. Không tạo merge rỗng hoặc thay lịch sử.
Checkpoint Demon được commit riêng trước phần kiểm tra tích hợp này.

## Phạm vi đã ghép

- Demon adviser/capture/replay và cách hiển thị thiếu state/timer, profile hết
  hạn hoặc config thay đổi. Damage predictor vẫn chỉ nghiên cứu offline.
- Cập nhật tool từ GitHub Releases bằng manifest có chữ ký; helper thay cả
  bundle, health-check, rollback và bảo toàn dữ liệu người dùng.
- Migration game tự phục vụ giới hạn ở thay đổi địa chỉ trong contract B17;
  audit tĩnh và probe chỉ đọc trước activation. Không tự nhận mọi game mới.
- Workflow Windows kiểm offline, build, kiểm ZIP. Push nhánh chạy verify;
  tag/manual dispatch mới tạo Draft. Publish vẫn là bước phát hành riêng.

Không đổi version1.3.6, tạo tag/release, sửa ZIP cũ, ký manifest hoặc Publish
trong tác vụ commit/push này. Build tự động của CI là gói kiểm tra, không tự
chuyển thành bản stable. Không mở game, gửi input hoặc mở lại cap live cũ.

## Xử lý kiểm tra giao nhau

Baseline migration trước tính năng chứa240 module. Giữ nguyên file
`tests/fixtures/compatibility/b17_gameplay_manifest.json` và checkpoint gốc.
Fixture bổ sung `demon_integration_20261122.json` pin exact before/after cho
9 file đã thay trong commit Demon;231 file còn lại phải khớp baseline.
Danh sách9 file cố định, mỗi hash mới lấy từ commit đã chốt, không tự quét
và chấp nhận source tùy ý ở lúc chạy test. Fixture không là runtime authority.

Test AST worker cũ được cập nhật cho helper health-prefix diagnostic đã kiểm
20/11: pin toàn bộ AST helper và exact try/except call; sau projection vẫn
so toàn bộ worker/admission AST với fixture03/11. Không bỏ kiểm validator
hoặc sửa runtime để làm xanh test.

CI bổ sung8 nhóm test thuần offline cho UI status, common native/selection,
strategy intent, health-prefix, refill risk và uncertainty. Không thêm nhóm
legacy profile review cần bằng chứng cá nhân vào CI portable, không chế tạo
native proof để chạy trên clone mới.

## Kết quả trước push

`python scripts/ci_offline.py`: **375 test PASS**,70,718s trên máy phát triển.
Hai test giao nhau về manifest/AST cũng đạt riêng. Lượt CI trước tích hợp
294 test có1 lỗi manifest cũ được giữ log, không tính là pass.

Diff `src/pokiguard_v2/` và `tools/` so với checkpoint Demon rỗng: không đổi
production/gameplay trong bước tích hợp. Chỉ CI, test fixture và docs đổi.
Các profile reasoning/timing lịch sử không được rebind theo fingerprint mới
của tests; kiểm offline không thay native acceptance của source mới.

Raw evidence, screenshots, activation/profile và log cá nhân tiếp tục ở máy,
ngoài Git và ZIP. Báo cáo nghiên cứu được commit; các đường artifact trong
báo cáo dẫn tới evidence local đã giải thích trong storage note.

CI trên GitHub phải được theo dõi theo đúng SHA của commit tích hợp sau push;
kết quả375 test local không tự là bằng chứng build/EXE trên runner từ xa.
Biên bản local: `temp/reasoning/main_integration_20261122/`.

Lần GitHub run44987164658 dừng trước build: một test review timing lịch sử
cần archive native cá nhân đã chủ động loại khỏi Git. Bổ sung skip có điều kiện
cho đúng test đó khi archive gốc không tồn tại, giống nhóm audit B17 chỉ chạy
khi có game/reverse local. Archive hiện hữu nhưng hỏng/hash sai vẫn phải fail;
không tạo proof giả, skip cả common-native group hoặc nới runtime validator.
Các kiểm tra synthetic/native-IO giả vẫn chạy trên CI. Log lỗi lần đầu giữ
riêng và CI phải chạy lại trên commit sửa.

[Demon/Highsion closeout](phase5/HIGHSION_REASONING_UI_VALIDATION_20261122.md),
[updater](tool_update_release.md),
[migration](self_service_compatibility.md),
[quy tắc evidence local](phase5/artifacts/README.md).
