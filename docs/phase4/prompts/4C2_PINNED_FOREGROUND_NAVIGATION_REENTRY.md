# Phase 4C.2 — Pinned Foreground Navigation/Re-entry Closure

Implement and validate **Phase 4C.2 ONLY**.

Entry gate: 4C.1 `PASS STRONG`.

Audit từng transition postmatch, empty room, boss map, game lobby, Chinh Phục,
island, boss room và Start. Giữ target pet/island/boss động từ runtime/config,
không fix cứng đảo. Mỗi transition dùng fresh proof cũ sau bounded foreground
acquire, một click permit và authoritative post-state ACK; stale/unknown dừng.

Game vẫn pinned visible/topmost. Visual proof phải được lấy sau acquire; không
dùng ảnh desktop bị che. Release cursor/guard sạch; focus return best effort.
Replay cover rare routes; live cần ít nhất hai complete re-entry cycles, còn
nhánh hiếm tự nhiên có thể `NOT_OBSERVED` nếu replay đầy đủ.

PASS STRONG -> `4D1_PINNED_FOREGROUND_AB_ACCEPTANCE.md`; STOP.

