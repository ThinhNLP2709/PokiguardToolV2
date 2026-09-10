# Pokiguard 1.7.4-b2 reverse evidence

User-supplied Il2CppInspector output, used by the Phase 3B.3 compatibility and
QTE audits. The original generated files have not been edited or deleted.

Git contains `cs/Assembly-CSharp/`: 1,062 generated C# declaration files
(3,320,760 original bytes, including namespaced subdirectories). These retain
declared types, field offsets and method address ranges; dummy declarations
are not evidence of a method's implementation. The preferred VA values in
the output must be converted to RVAs, not used as runtime addresses.

The remaining generated output stays local and is ignored by Git: other
assemblies, `cpp/`, `dll/`, `il2cpp.h`, `il2cpp.json`, and `il2cpp.py`.
`il2cpp.json` alone is 160,986,713 bytes and exceeds GitHub's per-file limit.
None of these generated files is required to execute the accepted Python
tests or runtime; further reverse investigation may require the original dump.

Exact build used for the accepted evidence:

- GameAssembly.dll: 53,603,328 bytes; SHA-256
  `7E001DA2DCBD196474E4B5D05AB4673ACB2D7B7FE4534383E930E6878E8E6991`.
- Metadata: 15,394,348 bytes; SHA-256
  `F011F33763C6451CA2E84EBC61CC1F1F02F7BA077C7F0F1DE04297C6C64B50A6`;
  header magic `0xFAB11BAF`, version 110.

Verified findings and native-body evidence are recorded in
[`il2cpp_symbols.md`](../../docs/il2cpp_symbols.md),
[`phase3b3_native_card_evidence.md`](../../docs/phase3b3_native_card_evidence.md)
and [`phase3b3_qte_timing_evidence.md`](../../docs/phase3b3_qte_timing_evidence.md).
See the [phase closeout](../../docs/phase3b3_closeout.md) for acceptance limits.
