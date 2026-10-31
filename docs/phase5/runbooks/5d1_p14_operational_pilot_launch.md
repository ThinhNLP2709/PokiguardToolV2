# P14 — Runbook cho future SIMPLE operational pilot

P14 chỉ chuẩn bị offline. Draft `accepted=false`, chưa có run ID/expiry/claim
hoặc live activation. Chỉ dùng runbook này khi bước P15 được người dùng kích hoạt.
Không tự mở tool/game hoặc phát input chỉ vì có file draft.

## Kết quả suy luận

Suy luận đánh giá cùng snapshot, mục tiêu PlayStyle và incumbent BASIC. Có thể
giữ nguyên nước BASIC hoặc chọn nước khác hợp lệ theo evidence. **Không quota
đổi nước**, không yêu cầu một trận nhất định phải có override. Completed
`RETAIN_BASELINE` là kết quả bình thường; phân loại riêng timeout/error/unsupported.
Không gọi vài trận hoặc giữ/đổi nước là bằng chứng global optimum/win-rate.

## Scope đã chuẩn bị

- SIMPLE / SOLO / BASIC incumbent, shadowOFF; reasoning chỉ qua request độc lập.
- Cùng P11 account, Starburst ID1289 cấp73, Phoenix do user khai báo,
  normal→normal/default_attack; structural fusion254767/2102, observed Attack64647/card4.
- Foreground/two_click; target3/max3 **TOTAL attempts**, kể cả invalid/abort.
- Budget4000ms tối đa, absolute deadline từ observation và reserve hiện hành.
  Opening cards[] hoặc witness khác giữ BASIC; không đợi/đọc CardUI thêm.
- Native U/transport/alignment UNKNOWN. Reserve từ26host intervals, fresh
  current-source selector allowance, command ceiling3060ms, guard250ms và
  margin100ms. Read-span100ms chỉ operational veto policy.

## Khi tới P15

1. Trình đúng cohort/cấu hình/cap cho user. User giữ auto cũ tắt, vào phòng
   Starburst73 cùng account/Phoenix/Attack như P11, chưa Bắt đầu trong game.
   Nếu cohort đổi, không chuyển nhãn calibration cũ hoặc tự farm thêm.
2. Kiểm source/host/build/config và P14 final checks bằng file/command. Không
   computer-use. Chưa có quyền chạy live thì chỉ trình draft, không claim.
3. Sau khi user yêu cầu kích hoạt bounded batch này, tạo request mới từ
   `pilot_draft.json.request_template`: run ID mới, created/expiry tối đa2giờ,
   independent bounded activation review pin run/cap/config/source/host/contract/
   decision. Pin review SHA vào request rồi pin request SHA ở launch command.
   Không sửa old consumed claims, không copy request để reset cap/resume.
4. Mở source UI bằng command chỉ khi user yêu cầu, giữ session preferences
   riêng. UI không auto-Start. User bấm **Bắt đầu trong TOOL một lần**;
   existing Start gate verify rồi claim, existing FarmRunner chạy tối đa3attempts.
5. Chờ target/Stop/critical gate. Mọi non-SWAP/card/evolution/QTE/ACK/result/room
   vẫn do flow hiện có. Planner lỗi chỉ giữ BASIC còn hợp lệ; đã dispatch thì
   không gửi nước thay thế. Stop không chờ flush/worker cleanup.
6. Thu toàn bộ attempts, timing/fallback/normal retention/override/outcomes,
   final watermarks và cleanup. Override0 vẫn là một kết quả kỹ thuật hợp lệ;
   không chạy thêm để tìm khác biệt. Không tự mở CAREFUL/Demon/Mega/D1cap12/D2.

Command future activation (chỉ template; các placeholder chưa là request hợp lệ):

```powershell
python tools/desktop_ui.py --operational-pilot-request <absolute-current-request.json> --operational-pilot-sha256 <verified-sha256> --artifacts <new-private-session-directory>
```

Request thiếu approval/expiry/source/cohort hoặc bị dùng rồi bị từ chối trước
runtime/Tk. Preview hợp lệ chưa tạo worker/claim; claim thuộc manual Start.
Private preferences nằm trong artifact directory; không ghi ordinary preferences.

## Giới hạn phép đo

Benchmark completed hiện đo worker trả giữ BASIC. Đường accepted override đã có
software tests trên synthetic evidence trong suite, nhưng latency của nhánh đó
chưa được đo riêng trên native cohort. Không fabricate effects/proposal hoặc
sửa BASIC để ép nhánh này. Công bố limitation trong activation review; không
claim whole-app/native/VM soak hoặc superiority từ scoped method benchmark.

Rollback: đóng phiên request riêng sau Stop theo flow hiện có; mở tool thường
không có operational flags thì vẫn BASIC/ordinary preferences như trước.
