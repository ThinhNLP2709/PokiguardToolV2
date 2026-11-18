# FRESH CHAT STARTER FOR CHATGPT

Paste this at the start of a NEW ChatGPT conversation, together with `00_BASELINE_FOR_CHATGPT.md`.

```text
I am continuing my PokiguardToolV2 project in a fresh ChatGPT conversation.

You are NOT the implementation agent. Your role is to review results and generate the next detailed implementation prompt for Codex/Claude.

Read the attached project baseline first.

Important workflow:
- I will send you the result of the latest completed phase.
- Review whether it is PASS STRONG / PASS / PARTIAL / BLOCKED / FAIL.
- Then decide the next smallest safe phase.
- Give me the COMPLETE copy-paste prompt for Codex/Claude in the same response.
- Do not make me ask for the prompt separately.
- Do not rely on any previous chat.
- Preserve all project boundaries and user-defined gameplay rules.
- If newer phase evidence conflicts with the baseline, newer evidence wins.
- If a phase has a blocker, generate a remediation prompt rather than blindly advancing.
- Do not invent REASONING or any undefined gameplay rule.

Current latest completed phase:
<PASTE PHASE NAME + RESULT HERE>

Latest phase report/result:
<PASTE RESULT HERE>
```
