# Pokiguard 1.7.4-b4 reverse provenance

This directory contains the user-supplied Il2CppInspector output used for the
1.7.4-b4 compatibility update. The associated installed artifacts were read
without modification on 2026-09-14 (Asia/Saigon).

| Artifact | Bytes | SHA-256 |
|---|---:|---|
| `Pokiguard-1.7.4.exe` | 575,488 | `EBF152BDFAF14391EED67FBC6755B6E62814C370404C3E657AFB9D5D7D3DD887` |
| `GameAssembly.dll` | 58,770,944 | `D55BDE20918F65E84700736E0EDE33AA8EE50A10956590D28FB8E53D185B28D6` |
| `UnityPlayer.dll` | 38,201,768 | `BB93AA060395C4ACE3561B4CEAFE06CFAEBD5DFB883C451058B9CCB74B50B6D2` |
| `global-metadata.dat` | 13,312,528 | `C90F02A5AD34726CD2B89951A21C82F19BECF88EC7D7697605D70BD2AF1BE575` |

`GameAssembly.dll` is the runtime compatibility key. Its PE identity is x64,
timestamp `0x6AA6926D`, preferred image base `0x180000000`, and `SizeOfImage
0x03AC8000`. The metadata header has magic `0xFAB11BAF` and version `110`.

The full generated reverse output remains local. Source control keeps this note
and the compact `cs/Assembly-CSharp` declarations used as field-layout evidence.
See `docs/pokiguard_1.7.4_b4_compatibility_report.md` for the complete audit.
