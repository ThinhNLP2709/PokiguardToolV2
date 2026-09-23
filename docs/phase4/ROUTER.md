# Phase 4 Result Router

Router này chọn prompt tiếp theo từ báo cáo thực tế. Không chọn theo kỳ vọng.

## Classification

```text
PASS STRONG
  Tất cả offline/live/safety/docs/Git evidence bắt buộc của phase đã đạt.

PASS
  Logic chính đúng nhưng còn một closure nhỏ hoặc live evidence bắt buộc chưa
  đủ mạnh. Không advance roadmap.

PARTIAL
  Chưa hoàn thành chính phase hiện tại. Tiếp tục cùng prompt hoặc tạo Rn.

BLOCKED
  Transport/capability không hoạt động hoặc thiếu một quyết định/evidence không
  thể tự suy ra. Dùng nhánh thay thế nếu bảng dưới có định nghĩa.

FAIL
  Có regression/safety violation. Remediation bắt buộc trước mọi advance.
```

## Decision table

| Current phase/result | Điều kiện thêm | Next prompt |
|---|---|---|
| 4A.0 PASS STRONG | audit hoàn chỉnh | `4A1_BACKGROUND_MOUSE_LIVE_PROBE.md` |
| 4A.0 khác PASS STRONG | — | cùng 4A.0 hoặc `REMEDIATION_TEMPLATE.md` |
| 4A.1 PASS STRONG | single-click + ít nhất một board transport accepted | `4A2_BACKGROUND_QTE_KEYBOARD_LIVE_PROBE.md` |
| 4A.1 BLOCKED | mọi mouse transport bị từ chối | STOP hoặc 4A.1-Rn nếu có giả thuyết mới |
| 4A.2 PASS STRONG | arrows + Space accepted | đặt capability `FULL_BACKGROUND_CAPABLE`; next `4B1_INPUT_MODE_CONTRACT_BACKEND.md` |
| 4A.2 PASS STRONG | keyboard background được kiểm tra đầy đủ và kết luận rejected/unsupported; foreground QTE baseline sạch | đặt branch `HYBRID_REQUIRED`; next `4B1_INPUT_MODE_CONTRACT_BACKEND.md` |
| 4A.2 khác PASS STRONG | evidence còn thiếu hoặc có safety failure | giữ 4A.2, remediation hoặc STOP; không tiến 4B.1 |
| 4B.1 PASS STRONG | contract/backend tests sạch | `4B2_BACKGROUND_BOARD_INTEGRATION.md` |
| 4B.2 PASS STRONG | board ACK live sạch | `4B3_BACKGROUND_UI_CARD_INTEGRATION.md` |
| 4B.3 PASS STRONG | single-click domains sạch | nếu full capability: `4B4F_FULL_BACKGROUND_QTE_INTEGRATION.md`; nếu hybrid: `4B4H_HYBRID_QTE_FOREGROUND_HANDOFF.md` |
| 4B.4F PASS STRONG | full background QTE/Perfect accepted | `4C1_DESKTOP_FARMRUNNER_INTEGRATION.md` |
| 4B.4F không PASS STRONG | keyboard path không ổn nhưng mouse ổn | remediation; chỉ chuyển `4B4H...` sau một closure PASS STRONG kết luận Full không còn hợp lệ |
| 4B.4H PASS STRONG | bounded handoff sạch | `4C1_DESKTOP_FARMRUNNER_INTEGRATION.md` |
| 4C.1 PASS STRONG | UI/Farm config/live sạch | `4C2_NAVIGATION_REENTRY_CLOSURE.md` |
| 4C.2 PASS STRONG | native hoặc handoff route accepted | `4D1_BOUNDED_AB_ACCEPTANCE.md` |
| 4D.1 PASS STRONG | cả A và B hợp lệ | `4D2_BACKGROUND_RELIABILITY_SOAK.md` |
| 4D.2 PASS STRONG | soak đúng target, zero critical violation | `4E1_PACKAGED_BACKGROUND_BETA_ACCEPTANCE.md` |
| 4E.1 PASS STRONG | artifact/hash/live acceptance/Git complete | ROADMAP COMPLETE; STOP |

## Quy tắc branch

### Full background

Chỉ chọn khi live evidence prove cả:

- mouse/card transport;
- QTE directions với per-direction RAM ACK;
- Space với server/runtime Perfect result;
- không có foreground takeover.

### Hybrid

Chọn khi mouse nền hoạt động nhưng keyboard QTE không hoạt động hoặc không đủ
bằng chứng. Handoff phải được user nhìn thấy trong UI/config và telemetry.

### Combat-only background

Nếu navigation/re-entry không thể chạy nền an toàn, 4C.2 có thể chấp nhận route
foreground handoff. Không được quảng bá là `full background`.

## Remediation naming

Chọn phase nhỏ nhất:

```text
4A.1-R1 — <transport evidence gap>
4B.2-R1 — <board ACK regression>
4B.4F-R1 — <QTE stale/delivery issue>
4C.2-R1 — <re-entry proof issue>
```

Remediation phải ghi rõ return gate. Sau khi đạt `PASS STRONG`, router quay lại
dòng của phase cha thay vì tự nhảy xa hơn.

## Trách nhiệm cập nhật

Phase report phải dùng `HANDOFF_TEMPLATE.md`. Agent sau khi review phải cập nhật
`STATUS.md` và chỉ ra chính xác prompt kế tiếp. Nếu evidence mâu thuẫn, repository
log mới nhất thắng, nhưng mâu thuẫn phải được ghi ra chứ không chọn kết quả có
lợi hơn.
