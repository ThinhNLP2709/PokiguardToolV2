# Pokiguard 1.7.4-b3 reverse provenance

This directory contains the user-supplied Cpp2IL/Il2CppInspector output used
for the 1.7.4-b3 compatibility update. The associated installed artifacts were
read without modification on 2026-09-12/13 (Asia/Saigon).

| Artifact | Bytes | SHA-256 |
|---|---:|---|
| `Pokiguard-1.7.4.exe` | 575,488 | `EBF152BDFAF14391EED67FBC6755B6E62814C370404C3E657AFB9D5D7D3DD887` |
| `GameAssembly.dll` | 58,686,976 | `BD504AF095F825864C963B10C9F62ADA1B8BD7B18E13FF1F0C87B04CD4B5B02D` |
| `UnityPlayer.dll` | 38,201,768 | `BB93AA060395C4ACE3561B4CEAFE06CFAEBD5DFB883C451058B9CCB74B50B6D2` |
| `global-metadata.dat` | 13,303,076 | `6A6FC8D0E761D33C2EC882A3E01C3516CDFCBB9F5885477E3FE35819A861F751` |

`GameAssembly.dll` is the runtime compatibility key. Its PE identity is x64,
timestamp `0x6AA53310`, and `SizeOfImage 0x03AB3000`. The metadata header has
magic `0xFAB11BAF` and version `110`.

The full generated reverse output remains local. Source control keeps this note
and the compact `cs/Assembly-CSharp` declarations used as field-layout evidence.
See `docs/pokiguard_1.7.4_b3_compatibility_plan.md` for the complete audit.
