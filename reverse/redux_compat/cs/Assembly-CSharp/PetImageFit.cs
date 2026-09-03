/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[AddComponentMenu("Pokiguard/Pet Image Fit")]
[DefaultExecutionOrder(50)]
[DisallowMultipleComponent]
public class PetImageFit : MonoBehaviour // TypeDefIndex: 849
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
	private Image _img; // 0x40
	private RectTransform _rt; // 0x48
	private Sprite _baseline; // 0x50
	private float _fit; // 0x58
	private Vector2 _size; // 0x5C
	private Vector2 _pivot; // 0x64
	private Vector2 _offset; // 0x6C
	private Vector2 _contentRatio; // 0x74
	private Vector2 _home; // 0x7C
	private bool _homeSaved; // 0x84
	private float _pop; // 0x88
	private float _popFrom; // 0x8C
	private float _popTime; // 0x90
	private float _popDuration; // 0x94
	private float _punchPeak; // 0x98
	private float _punchTime; // 0x9C
	private float _punchDuration; // 0xA0
	private bool _warnedStretch; // 0xA4

	// Properties
	public Vector2 Home { get; } // 0x000000018042C5F0-0x000000018042C610 
	public float Fit { get; } // 0x000000018042C5E0-0x000000018042C5F0 

	// Nested types
	public enum Anchor // TypeDefIndex: 850
	{
		Center = 0,
		Bottom = 1,
		None = 2
	}

	// Constructors
	public PetImageFit(); // 0x000000018042C560-0x000000018042C5E0

	// Methods
	private void Awake(); // 0x000000018042B420-0x000000018042B430
	private void OnEnable(); // 0x000000018042BA50-0x000000018042BAA0
	private void OnDisable(); // 0x000000018042B9A0-0x000000018042BA50
	public void Refit(); // 0x000000018042BF40-0x000000018042BF60
	public void SetTarget(float width, float height); // 0x000000018042BF70-0x000000018042BFA0
	public void RecaptureHome(); // 0x000000018042BB50-0x000000018042BBF0
	public void SetHome(Vector2 home); // 0x000000018042BF60-0x000000018042BF70
	public void PlayPop(float from = 0.8f /* Metadata: 0x0064CB9E */, float duration = 0.3f /* Metadata: 0x0064CBA2 */); // 0x000000018042BAA0-0x000000018042BB00
	public void PlayPunch(float peak = 1.15f /* Metadata: 0x0064CBA6 */, float duration = 0.4f /* Metadata: 0x0064CBAA */); // 0x000000018042BB00-0x000000018042BB50
	public void Apply(Sprite sp); // 0x000000018042B350-0x000000018042B420
	private void EnsureParts(); // 0x000000018042B430-0x000000018042B6B0
	private void LateUpdate(); // 0x000000018042B6B0-0x000000018042B860
	private void TickPop(); // 0x000000018042BFA0-0x000000018042C140
	private void WriteRect(); // 0x000000018042C3E0-0x000000018042C560
	private bool NeedsRefit(Sprite sp); // 0x000000018042B860-0x000000018042B9A0
	private void Recompute(Sprite sp); // 0x000000018042BBF0-0x000000018042BF40
	private bool TryContentBounds(Sprite sp, out Vector2 min, out Vector2 max); // 0x000000018042C140-0x000000018042C3E0
}

