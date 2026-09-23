# Phase 4D.1 — Bounded Foreground vs Background A/B Acceptance

Implement and validate **Phase 4D.1 ONLY**.

Entry gate: 4C.2 `PASS STRONG`.

## 1. Goal

So sánh correctness/reliability của cùng một gameplay configuration trên cùng
game build:

```text
A = FOREGROUND
B = accepted BACKGROUND_FULL_BETA hoặc HYBRID_QTE_FOREGROUND
```

Không đổi pet/policy/loadout giữa A và B. Đây không phải performance benchmark
gameplay và không dùng để tuyên bố energy saving.

## 2. Controlled design

Trước run, ghi manifest:

- source commit/version/build hash;
- game fingerprint;
- config/pet/evolution/action/playstyle;
- target/attempt limit;
- order A/B;
- focus/cover schedule;
- accepted navigation/QTE branch.

Đề xuất 5 completed matches cho A và 5 cho B. Điều chỉnh chỉ khi report giải
thích lý do; không tự tăng thành soak.

## 3. Metrics

Tối thiểu:

- completed/attempt/W/L/U;
- queued/ACK/unconfirmed input theo domain;
- ACK latency;
- partial/duplicate/stale/wrong-turn;
- focus takeover count/duration;
- cursor movement in background mode;
- technical abort/recovery;
- cycle duration chỉ như telemetry;
- final lifecycle/controller state.

## 4. Acceptance

PASS STRONG yêu cầu:

- cả A và B đạt exact target;
- zero unexplained UNKNOWN;
- zero critical safety violation;
- no extra attempt;
- mode B chỉ lấy focus theo branch đã công bố;
- background input có authoritative ACK;
- foreground regression sạch;
- manifest/analyzer/report reproducible;
- STATUS/router -> 4D.2.

Nếu B fail do một domain cụ thể, tạo 4D.1-Rn và quay lại đúng integration phase
nếu cần; không tiến soak.

## 5. Validation and docs

Không nhất thiết sửa production code. Nếu có narrow fix, rerun affected sample và
full regression/compileall/diff-check. Tạo artifacts JSON + analysis Markdown và
report theo handoff template.

## 6. Explicit stop

STOP sau A/B report/checkpoint. Không bắt đầu soak hoặc build.
