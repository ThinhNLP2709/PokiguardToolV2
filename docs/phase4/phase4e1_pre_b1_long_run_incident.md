# Phase 4E.1 — Pre-B1 long-run incident 94e0d693

Ngày phân tích và remediation: 2026-09-30 (Asia/Saigon).

## Phạm vi bằng chứng

- FarmRun: `94e0d6932b104a759c31a83f08563aca`.
- Cấu hình: target 200, max attempts 300, pinned foreground beta,
  `skill_rush / legendary / none / pet_skill / audition_v3`.
- Kết quả trước sự cố: 124/200 trận hoàn thành, 124 thắng; attempt 125 là
  technical abort.
- Phiên lỗi: `M_e40f3730`, lifecycle epoch 125, Board
  `0x175BED84000`.

## Kết luận về ba lượt bỏ

Tool không chọn hoặc gửi lệnh Pass trong attempt 125:

- `passProposals=0`;
- `passExecuted=0`;
- `auto_pass_started=0`;
- `passCoordinator.confirmedPasses=0`;
- `thirdPassCount=0`, `wrongThirdPassCount=0`;
- 5 swap trước đó đều `sent=5`, `acknowledged=5`.

Ở local turn 11, policy vẫn tìm được một swap tài nguyên hợp lệ. Preflight hủy
swap này vì trạng thái thay đổi, rồi ActionabilityGate báo `RECONNECTING`. Ảnh
failure chụp lúc recovery bắt đầu chỉ hiển thị cảnh báo **Bỏ lượt 1/3**. Hai lượt
không thao tác tiếp theo xảy ra khi gameplay đã bị khóa để recovery, không phải
do policy quyết định Pass.

## Lỗi đã xác định

Recovery đã có bằng chứng đúng phiên ACTIVE qua `poll.session_key`, nhưng
preflight click `Exit` và `Confirm leave` lại yêu cầu thêm
`poll.combat_lifecycle.state == ACTIVE`. Provider có chủ ý trả sớm với
`session_key` đã được phát hành từ chính mẫu ACTIVE trong lúc chờ board batch ổn
định; ở nhánh này lifecycle chi tiết có thể rỗng. Điều kiện trùng khiến click
Exit bị từ chối với `STALE_ACTION` dù đúng MatchId, Board.Instance và lifecycle
epoch. Game vì thế tiếp tục đếm các lượt không thao tác và đẩy người chơi ra.

## Sửa đổi

- `tools/technical_recovery.py`: Exit/Confirm chấp nhận bằng chứng phiên ACTIVE
  chuẩn hóa từ `_failed_session_still_active`, không đòi lại lifecycle chi tiết
  lần hai. Ràng buộc exact session, MatchId, Board.Instance và epoch vẫn giữ
  nguyên; stale/foreign session vẫn bị chặn.
- `src/pokiguard_v2/actionability.py`: log `RECONNECTING` ghi riêng ba tín hiệu
  `reconnecting`, `matchResyncing`, `boardIsResuming` để lần live sau xác định
  chính xác nguồn reconnect mà không suy đoán.
- Thêm regression cho early-return ACTIVE hợp lệ và stale epoch bị từ chối.

## Xác minh offline

- Focused recovery/actionability/farm/lease: **216/216 PASS**.
- Full repository: **1611/1611 PASS**.
- `python -m compileall -q src tools tests`: **PASS**.
- `git diff --check`: **PASS**; chỉ có cảnh báo CRLF hiện hữu.
- Package self-check sau rebuild: **PASS**, exit code 0.
- Packaged offline UI smoke: **PASS**, không Start/Resume/input tự động.

## Trạng thái acceptance

Fix này cần một live reproduction hoặc long-run soak riêng để chứng minh recovery
thoát ở cảnh báo đầu tiên; chưa dùng log cũ để tự tuyên bố live PASS. Phase 4E.1
B1 được reset về pending và phải dùng artifact mới sau remediation.
