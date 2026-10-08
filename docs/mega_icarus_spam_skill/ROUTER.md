# Mega Icarus mini-plan router

Router chọn prompt kế tiếp từ kết quả thực tế, không từ kỳ vọng.

| Kết quả hiện tại | Prompt tiếp theo |
|---|---|
| MI.1 `PASS STRONG` | `MI2_POLICY_AND_CLICK_ONLY_INTEGRATION.md` |
| MI.1 khác `PASS STRONG` | sửa hẹp trong MI.1, rerun gate MI.1 |
| MI.2 `PASS STRONG` | `MI3_FOCUSED_ACCEPTANCE.md` |
| MI.2 khác `PASS STRONG` | remediation hẹp, rerun gate MI.2 |
| MI.3 `PASS STRONG` | MINI-PLAN COMPLETE; chờ user yêu cầu chốt/commit/push |
| MI.3 có lỗi live | ghi run/log, sửa đúng lỗi và chỉ retry bài live bị lỗi |

## Phân loại

- `PASS STRONG`: toàn bộ contract, targeted tests, regression bắt buộc và bằng
  chứng live (nếu prompt yêu cầu) đều sạch.
- `PASS`: logic chính đúng nhưng thiếu một bằng chứng bắt buộc; không advance.
- `PARTIAL`: implementation/test của chính prompt chưa xong.
- `FAIL`: có config leakage, policy sai vùng Kết Ấn, click/QTE sai hoặc
  regression; phải remediation.

## Quy tắc remediation

Remediation phải ghi:

1. prompt cha và gate quay lại;
2. expected/actual từ test hoặc run cụ thể;
3. root cause `PROVEN`, `INFERRED` hoặc `UNKNOWN`;
4. thay đổi nhỏ nhất;
5. test tái hiện trước fix và pass sau fix;
6. không mở rộng sang vận hành FarmRunner.

Không build/package/tag/push trong router này. Chỉ chốt khi user yêu cầu sau
MI.3.
