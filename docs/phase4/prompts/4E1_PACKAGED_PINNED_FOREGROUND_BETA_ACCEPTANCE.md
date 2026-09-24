# Phase 4E.1 — Packaged Pinned Foreground Beta Acceptance

Implement and validate **Phase 4E.1 ONLY**.

Entry gate: 4D.2 `PASS STRONG`, exact accepted source and no remediation mở.

Build dưới `D:\PokiguardToolV2\build\<version>\`. Verify tests, compileall,
diff-check, version/labels, bundle imports, fresh-data self-check và offline UI.
Package không chứa logs/reverse/user preferences.

Một artifact/hash duy nhất phải pass foreground smoke, Beta one-match, bounded
multi-match, Pet Skill QTE, graceful/emergency stop, checkpoint/resume và
navigation/re-entry. UI/release notes phải mô tả đúng visible/topmost + bounded
foreground takeover; không quảng bá background/minimized.

Tag/push/release chỉ khi user yêu cầu chốt. Sau PASS STRONG, Phase 4 complete và
STOP.

