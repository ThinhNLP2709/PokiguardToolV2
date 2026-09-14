/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[AddComponentMenu("Pokiguard/Pet Image Fit")]
[DefaultExecutionOrder(50)]
[DisallowMultipleComponent]
public class PetImageFit : MonoBehaviour // TypeDefIndex: 1430
{
	// Fields
	[Header("Khung \u0111\u00EDch (\u0111\u01A1n v\u1ECB canvas)")]
	[Tooltip("B\u1EC1 r\u1ED9ng t\u1ED1i \u0111a pet \u0111\u01B0\u1EE3c ph\u00E9p chi\u1EBFm.")]
	public float targetWidth; // 0x20
	[Tooltip("Chi\u1EC1u cao t\u1ED1i \u0111a pet \u0111\u01B0\u1EE3c ph\u00E9p chi\u1EBFm.")]
	public float targetHeight; // 0x24
	[Tooltip("Canh pet trong khung sau khi thu/ph\u00F3ng.")]
	public Anchor anchor; // 0x28
	[Header("Ch\u1ED1t an to\u00E0n")]
	[Range(1f, 3f)]
	[Tooltip("Frame n\u00E0o v\u1EBD ra v\u01B0\u1EE3t khung qu\u00E1 t\u1EC9 l\u1EC7 n\u00E0y th\u00EC t\u00EDnh l\u1EA1i h\u1EC7 s\u1ED1 (1,15 = cho ph\u00E9p nh\u00F4 15%).")]
	public float overflowTolerance; // 0x2C
	[Tooltip("Tr\u1EA7n ph\u00F3ng to \u2014 ch\u1EB7n sprite b\u00E9 x\u00EDu b\u1ECB k\u00E9o th\u00E0nh \u1EA3nh v\u1EE1 kh\u1ED5ng l\u1ED3.")]
	public float maxScale; // 0x30
	[Tooltip("\u0110o theo V\u00D9NG C\u00D3 H\u00CCNH c\u1EE7a frame (tight mesh) thay v\u00EC c\u1EA3 khung PNG. B\u1EADt khi nhi\u1EC1u pet kh\u00E1c nhau ph\u1EA3i hi\u1EC7n TO B\u1EB0NG NHAU trong c\u00F9ng m\u1ED9t \u00F4: khung PNG m\u1ED7i pet ch\u1EEBa l\u1EC1 r\u1ED7ng m\u1ED9t ki\u1EC3u (\u0111o th\u1EADt 01/09: 2274 ch\u1EC9 chi\u1EBFm 410/592 b\u1EC1 ngang) n\u00EAn \u0111o theo khung l\u00E0 pet nhi\u1EC1u l\u1EC1 b\u1ECB co nh\u1ECF h\u1EB3n so v\u1EDBi pet s\u00E1t vi\u1EC1n.")]
	public bool useTightBounds; // 0x34
	[Tooltip("Chi\u1EC1u cao KHUNG CHU\u1EA8N d\u00F9ng \u0111\u1EC3 canh M\u1EB6T S\u00C0N \u1EDF ch\u1EBF \u0111\u1ED9 Bottom. B\u1EB1ng 0 th\u00EC l\u1EA5y targetHeight. \u0110\u1EB7t h\u1EB1ng s\u1ED1 n\u00E0y khi khung \u0111\u00EDch co l\u1EA1i theo b\u1EADc ti\u1EBFn ho\u00E1 \u2014 n\u1EBFu kh\u00F4ng, pet con (khung nh\u1ECF) s\u1EBD \u0111\u1EE9ng CAO h\u01A1n pet d\u1EA1ng cu\u1ED1i v\u00EC m\u1EB7t s\u00E0n t\u00EDnh theo khung.")]
	public float floorHeight; // 0x38
	[Tooltip("H\u1ED8P G\u1ED0C (sizeDelta l\u00FAc thi\u1EBFt k\u1EBF) c\u1EE7a node n\u00E0y. B\u1EB1ng 0 \u21D2 t\u1EF1 ch\u1EE5p \u1EDF l\u1EA7n \u0111\u1EA7u ti\u00EAn, TR\u01AF\u1EDAC khi ph\u00E9p fit k\u1ECBp ghi sizeDelta l\u1EA7n n\u00E0o. \u0110\u1ECCC-TH\u00CC-\u0110\u01AF\u1EE2C, GHI-TH\u00CC-\u0110\u1EEANG l\u00FAc ch\u1EA1y.")]
	public Vector2 designSize; // 0x3C
	private Image _img; // 0x48
	private RectTransform _rt; // 0x50
	private Sprite _baseline; // 0x58
	private float _fit; // 0x60
	private Vector2 _size; // 0x64
	private Vector2 _pivot; // 0x6C
	private Vector2 _offset; // 0x74
	private Vector2 _contentRatio; // 0x7C
	private Vector2 _home; // 0x84
	private bool _homeSaved; // 0x8C
	private float _pop; // 0x90
	private float _popFrom; // 0x94
	private float _popTime; // 0x98
	private float _popDuration; // 0x9C
	private float _punchPeak; // 0xA0
	private float _punchTime; // 0xA4
	private float _punchDuration; // 0xA8
	private bool _warnedStretch; // 0xAC
	private bool _designSaved; // 0xAD

	// Properties
	public Vector2 Home { get; } // 0x00000001807CA1A0-0x00000001807CA1C0 
	public float Fit { get; } // 0x00000001807CA1C0-0x00000001807CA1D0 
	public Vector2 DesignSize { get; } // 0x00000001807CA1D0-0x00000001807CA310 

	// Nested types
	public enum Anchor // TypeDefIndex: 1431
	{
		Center = 0,
		Bottom = 1,
		None = 2
	}

	// Constructors
	public PetImageFit(); // 0x00000001807CC5C0-0x00000001807CC6A0

	// Methods
	private void Awake(); // 0x00000001807CA310-0x00000001807CA330
	private void CaptureDesignSize(); // 0x00000001807CA330-0x00000001807CA4C0
	public void ResetToDesignSize(); // 0x00000001807CA4C0-0x00000001807CA640
	private void OnEnable(); // 0x00000001807CA640-0x00000001807CA6E0
	private void OnDisable(); // 0x00000001807CA6E0-0x00000001807CA920
	public void Refit(); // 0x00000001807CA920-0x00000001807CA980
	public void SetTarget(float width, float height); // 0x00000001807CA980-0x00000001807CAA00
	public void RecaptureHome(); // 0x00000001807CAA00-0x00000001807CAB20
	public void SetHome(Vector2 home); // 0x00000001807CAB20-0x00000001807CAB30
	public void PlayPop(float from = 0.8f /* Metadata: 0x005F0F43 */, float duration = 0.3f /* Metadata: 0x005F0F47 */); // 0x00000001807CAB30-0x00000001807CAB90
	public void PlayPunch(float peak = 1.15f /* Metadata: 0x005F0F4B */, float duration = 0.4f /* Metadata: 0x005F0F4F */); // 0x00000001807CAB90-0x00000001807CABE0
	public void Apply(Sprite sp); // 0x00000001807CABE0-0x00000001807CAE50
	private void EnsureParts(); // 0x00000001807CAE50-0x00000001807CB2A0
	private void LateUpdate(); // 0x00000001807CB2A0-0x00000001807CB7C0
	private void TickPop(); // 0x00000001807CB7C0-0x00000001807CB9D0
	private void WriteRect(); // 0x00000001807CB9D0-0x00000001807CBB50
	private bool NeedsRefit(Sprite sp); // 0x00000001807CBB50-0x00000001807CBD70
	private void Recompute(Sprite sp); // 0x00000001807CBD70-0x00000001807CC1D0
	private bool TryContentBounds(Sprite sp, out Vector2 min, out Vector2 max); // 0x00000001807CC1D0-0x00000001807CC5C0
}

