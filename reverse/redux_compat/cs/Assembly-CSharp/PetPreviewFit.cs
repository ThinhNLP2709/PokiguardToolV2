/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[AddComponentMenu("Pokiguard/Pet Preview Fit")]
[DisallowMultipleComponent]
public class PetPreviewFit : MonoBehaviour // TypeDefIndex: 853
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
	[Tooltip("Tr\u1EA7n ph\u00F3ng to \u2014 ch\u1EB7n pet c\u00F3 PPU qu\u00E1 l\u1EDBn b\u1ECB k\u00E9o th\u00E0nh \u1EA3nh v\u1EE1 kh\u1ED5ng l\u1ED3.")]
	public float maxScale; // 0x30
	[Tooltip("Chi\u1EC1u cao KHUNG CHU\u1EA8N d\u00F9ng \u0111\u1EC3 canh M\u1EB6T S\u00C0N \u1EDF ch\u1EBF \u0111\u1ED9 Bottom. B\u1EB1ng 0 th\u00EC l\u1EA5y targetHeight. \u0110\u1EB7t h\u1EB1ng s\u1ED1 n\u00E0y khi khung \u0111\u00EDch co l\u1EA1i theo b\u1EADc ti\u1EBFn ho\u00E1 \u2014 n\u1EBFu kh\u00F4ng, pet con (khung nh\u1ECF) s\u1EBD \u0111\u1EE9ng CAO h\u01A1n pet d\u1EA1ng cu\u1ED1i v\u00EC m\u1EB7t s\u00E0n t\u00EDnh theo khung.")]
	public float floorHeight; // 0x34
	private float _pop; // 0x38
	private float _popFrom; // 0x3C
	private float _popTime; // 0x40
	private float _popDuration; // 0x44
	private SpriteRenderer _sr; // 0x48
	private RectTransform _rt; // 0x50
	private Sprite _baseline; // 0x58
	private float _fit; // 0x60
	private Vector2 _homeAnchored; // 0x64
	private bool _homeSaved; // 0x6C
	private Vector2 _offset; // 0x70
	private float _punchPeak; // 0x78
	private float _punchTime; // 0x7C
	private float _punchDuration; // 0x80

	// Nested types
	public enum Anchor // TypeDefIndex: 854
	{
		Center = 0,
		Bottom = 1,
		None = 2
	}

	// Constructors
	public PetPreviewFit(); // 0x000000018043AF00-0x000000018043AF50

	// Methods
	private void Awake(); // 0x000000018043A510-0x000000018043A5C0
	private void OnEnable(); // 0x000000018043AB70-0x000000018043ABB0
	private void SaveHome(); // 0x000000018043AE30-0x000000018043AED0
	public void Refit(); // 0x000000018043AE10-0x000000018043AE30
	public void PlayPop(float from = 0.8f /* Metadata: 0x0064CBB5 */, float duration = 0.3f /* Metadata: 0x0064CBB9 */); // 0x000000018043ABB0-0x000000018043ABF0
	public void PlayPunch(float peak = 1.15f /* Metadata: 0x0064CBBD */, float duration = 0.4f /* Metadata: 0x0064CBC1 */); // 0x000000018043ABF0-0x000000018043AC40
	public void SetTarget(float width, float height); // 0x000000018043AED0-0x000000018043AF00
	private void LateUpdate(); // 0x000000018043A5C0-0x000000018043AA90
	private bool NeedsRefit(Sprite sp); // 0x000000018043AA90-0x000000018043AB70
	private void Recompute(Sprite sp); // 0x000000018043AC40-0x000000018043AE10
}

