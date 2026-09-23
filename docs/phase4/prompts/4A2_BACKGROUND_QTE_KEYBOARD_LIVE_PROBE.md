# Phase 4A.2 — Isolated Background QTE Keyboard Live Probe

Implement and validate **Phase 4A.2 ONLY**.

Entry gate: 4A.1 `PASS STRONG` với background single click và ít nhất một board
transport accepted. Nếu card/skill trigger cần một mouse primitive chưa proven,
phase phải stop trước input.

## 0. Goal

Dùng harness bounded để xác định QTE direction và Space có thể được gửi tới game
khi game không foreground hay không. Không nối policy/FarmRunner/Desktop UI.

Kết quả bắt buộc phải chọn một nhánh:

```text
FULL_BACKGROUND_CAPABLE
HYBRID_REQUIRED
BLOCKED
```

## 1. Ownership and preflight

Mọi QTE input phải gắn với:

- exact PID/HWND và unchanged geometry;
- current MatchId/session/local turn;
- current skillCardId/CardUI/Button identity;
- current QTE generation/sequence/currentIndex/correctCount;
- active input authority;
- game non-foreground but non-minimized;
- no emergency/graceful stop conflict;
- no stale previous-session/card/QTE state.

Ambiguous ownership = zero input.

## 2. Transport candidates

Chỉ dùng các candidate đã được 4A.0 mô tả. Mỗi candidate phải là typed arrow hoặc
Space API, không expose arbitrary key.

Một prepared QTE không được dùng để thử liên tiếp nhiều transport khi candidate
đầu không ACK. Mỗi candidate mới cần một fresh QTE do người dùng chuẩn bị và xác
nhận.

`PostMessageW/SendMessage` return không phải acceptance. Acceptance direction
đòi `currentIndex/correctCount` tiến đúng; Space đòi runtime/server timing result
và skill response tương quan.

## 3. Offline tests

Cover:

- exact WM_KEYDOWN/UP or selected candidate sequence;
- arrow vocabulary closed to Up/Down/Left/Right;
- Space executor separated;
- stale MatchId/QTE generation;
- wrong expected direction;
- per-direction no-ACK stop;
- emergency stop between directions;
- no Space before all directions and proven Perfect interval;
- no duplicate Space;
- no focus steal in full-background candidate.

Chạy focused/full/compileall/diff-check phù hợp mọi code bị chạm.

## 4. Live stages — user controls the game

### B1 — background QTE observation

Người dùng chuẩn bị skill/actionable resources. Prove game background, QTE fresh,
zero harness input.

### B2 — direction delivery

Gửi từng direction, chờ ACK sau từng phím. Dừng ngay tại first missing/wrong ACK.
Không Space nếu sequence chưa hoàn tất.

### B3 — Space delivery

Chỉ sau fresh full sequence và timing state proven. Gửi đúng một Space trong
Perfect interval. Correlate server/runtime result.

Ưu tiên 2–3 fresh skill uses nếu lần đầu thành công để loại false positive;
không biến phase thành farm run.

## 5. Classification

`FULL_BACKGROUND_CAPABLE` chỉ khi:

- mọi direction được ACK đúng;
- Space accepted;
- timing result phù hợp, PASS STRONG yêu cầu PERFECT cho tested path;
- game không foreground trong toàn input interval;
- zero duplicate/stale/wrong input.

`HYBRID_REQUIRED` khi:

- mouse background đã accepted;
- direction hoặc Space background được kiểm tra đúng contract và bị từ chối;
- foreground QTE path hiện tại vẫn sạch;
- không có safety regression.

Thiếu evidence chưa đủ để kết luận rejected thì phase là `PARTIAL/BLOCKED`, không
được chọn Hybrid rồi tiến roadmap.

`BLOCKED` khi QTE test không thể sở hữu/quan sát current state an toàn hoặc mouse
skill trigger cũng không được prove.

## 6. Routing

Sau report:

- PASS STRONG/full capability: update STATUS, next 4B.1, giữ branch Full;
- PASS STRONG/hybrid required: update STATUS, next 4B.1, giữ branch Hybrid;
- khác PASS STRONG: giữ 4A.2 hoặc remediation; không tiến 4B.1;
- safety failure: 4A.2-Rn;
- blocked entirely: STOP.

## 7. Do not implement

- production background executor wiring;
- policy/FarmRunner/UI;
- focus handoff implementation;
- re-entry/navigation;
- package.

## 8. Explicit stop

STOP sau capability conclusion/report/checkpoint. Không bắt đầu 4B.1 trong cùng
phase.
