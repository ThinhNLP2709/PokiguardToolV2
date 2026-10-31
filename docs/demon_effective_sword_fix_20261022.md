# Demon Farm BASIC — ngưỡng Kiếm hiệu dụng, 2026-10-22

Cập nhật sau sửa: live2 Darksoul lv100, target Máu, WIN2/2;15 SWAP/13 ACK/
2 terminal,0 pass/read error/technical abort/recovery/safety fault. Có7ô/tổng11
và5ô/tổng6; không gặp đúng3ô/tổng4 trong phiên này. Đã phát hành
[v1.2.7](v1.2.7_release_report.md),200 release tests và ZIP/EXE self-check PASS.
[Closure raw-pinned](artifacts/demon_effective_sword_20261022/live2_20261022_015301/closure.json).
Các mốc “chưa live/build” bên dưới là trạng thái ngay khi hoàn tất sửa offline.

Người dùng yêu cầu đổi BASIC từ4 ô Kiếm thành **4 Kiếm hiệu dụng**. Trường
multiplier không đổi trong reverse b10; [audit](multiplier_b10_review_20261022.md)
đã tái hiện việc bỏ nước tại M_86c91873/turn7 do so số ô thay vì tổng hệ số.

Điều kiện mới trong vùng phá của Viên mục tiêu:

- Tổng multiplier của Kiếm đã biết `>= pet_skill_fire_value`.
- Tối thiểu2 ô Kiếm thực tế, giữ giới hạn người dùng đã chốt cho Demon.
- Không lấy Kiếm ngoài vùng phá, không cộng UNKNOWN hoặc match/cascade Kiếm
  thông thường vào bằng chứng kích hoạt nội tại.

Với setting4: x2+x1+x1 đạt4; x3+x1 đạt4; 3viên x1 chỉ đạt3.
Một ô x4/x7 vẫn không vượt giới hạn2ô thực tế. Xếp hạng nước kích hoạt và
forecast/setup cùng ưu tiên hiệu dụng trước số ô; không chỉ đổi một phép so.
Áp dụng cho cả Khiên/Máu/Mana/Hút/Nộ. Giá trị cấu hình được lưu không đổi;
UI bổ sung giải thích ngắn về đơn vị và giới hạn2ô.

Replay turn7 hiện chọn PASSIVE_FIRE với3ô/tổng4, thay vì SETUP. Đây là chứng
minh quyết định theo ngưỡng mới, không phải bằng chứng nước chưa đánh sẽ WIN.
159 kiểm thử PASS (30.594s): replay thật, cả5 target, x2/x3, giới hạn2ô, thứ tự
xếp hạng/forecast, mandatory fallback, giao diện, BASIC, D3 và b10/source gates.
Historical tests dùng đúng counterfactual cũ; source/calibration cũ không được
đổi nhãn. Test controller hiện cho phép AI giữ BASIC mới đã tốt nhất.

Chỉ3 module runtime đổi: basic_policy (3hàm quyết định Demon), demon_aegis
(forecast và hằng số giới hạn), desktop_ui (câu giải thích). Các src/tools khác
giữ nguyên byte, gồm reader, simulator, flow/input, QTE, ACK và recovery.
Không phát input game, không sửa file game, không build package hoặc live lại.
Phiên tool đang mở cần khởi động lại để nạp logic mới.

Source349file:
`966bd63d41342b955223f815edd21767128efe537408959e340a63b4cd0e2ed9`.
[Verification](artifacts/demon_effective_sword_20261022/verification.json),
[test log](artifacts/demon_effective_sword_20261022/focused_tests.log),
[before source](artifacts/demon_effective_sword_20261022/before_source.json).
