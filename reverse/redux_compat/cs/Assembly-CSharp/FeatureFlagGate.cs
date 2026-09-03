/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[AddComponentMenu("Pokiguard/Feature Flag Gate")]
[DisallowMultipleComponent]
public class FeatureFlagGate : MonoBehaviour // TypeDefIndex: 822
{
	// Fields
	[Tooltip("Kho\u00E1 t\u00EDnh n\u0103ng, kh\u1EDBp c\u1ED9t flag_key tr\u00EAn web admin. V\u00ED d\u1EE5: wheel, shop, eventFest.")]
	public string flagKey; // 0x20
	[Tooltip("Gi\u00E1 tr\u1ECB d\u00F9ng khi CH\u01AFA c\u00F3 d\u1EEF li\u1EC7u (offline l\u1EA7n \u0111\u1EA7u, server h\u1ECFng, flag ch\u01B0a khai).\nB\u1EACT cho t\u00EDnh n\u0103ng \u0111ang ch\u1EA1y \u1ED5n \u0111\u1ECBnh; T\u1EAET cho t\u00EDnh n\u0103ng m\u1EDBi \u0111ang rollout.")]
	public bool defaultOn; // 0x28
	[Tooltip("\u1EA8n h\u1EB3n, hay v\u1EABn hi\u1EC7n nh\u01B0ng kho\u00E1 l\u1EA1i. Kho\u00E1 l\u1EA1i th\u01B0\u1EDDng t\u1ED1t h\u01A1n cho t\u00EDnh n\u0103ng t\u1EA1m b\u1EA3o tr\u00EC: n\u00FAt bi\u1EBFn m\u1EA5t khi\u1EBFn ng\u01B0\u1EDDi ch\u01A1i t\u01B0\u1EDFng m\u1EA5t t\u00EDnh n\u0103ng v\u0129nh vi\u1EC5n.")]
	public GateMode mode; // 0x2C
	private Selectable _selectable; // 0x30
	private bool _baseActive; // 0x38
	private bool _baseInteractable; // 0x39
	private bool _captured; // 0x3A

	// Nested types
	public enum GateMode // TypeDefIndex: 823
	{
		Hide = 0,
		Disable = 1
	}

	// Constructors
	public FeatureFlagGate(); // 0x0000000180425F50-0x0000000180425F60

	// Methods
	private void Awake(); // 0x0000000180425D10-0x0000000180425DC0
	private void OnEnable(); // 0x0000000180425F40-0x0000000180425F50
	private void OnDestroy(); // 0x0000000180425EB0-0x0000000180425F40
	private void Capture(); // 0x0000000180425DC0-0x0000000180425EB0
	private void Apply(); // 0x0000000180425BB0-0x0000000180425D10
}

