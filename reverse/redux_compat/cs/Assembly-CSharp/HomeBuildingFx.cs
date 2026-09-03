/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[DisallowMultipleComponent]
public class HomeBuildingFx : MonoBehaviour // TypeDefIndex: 601
{
	// Fields
	public HomeFxPreset preset; // 0x20
	[Tooltip("Bi\u00EAn \u0111\u1ED9: Bob = pixel, Shake = \u0111\u1ED9, Pulse = alpha th\u1EA5p nh\u1EA5t, Spin = \u0111\u1ED9/gi\u00E2y.")]
	public float amplitude; // 0x24
	[Tooltip("Chu k\u1EF3 m\u1ED9t nh\u1ECBp (gi\u00E2y). Spin b\u1ECF qua gi\u00E1 tr\u1ECB n\u00E0y.")]
	public float period; // 0x28
	[Tooltip("Tr\u1EC5 kh\u1EDFi \u0111\u1ED9ng \u2014 l\u1EC7ch pha gi\u1EEFa c\u00E1c to\u00E0 cho \u0111\u1EE1 \u0111\u1EC1u t\u0103m t\u1EAFp.")]
	public float startDelay; // 0x2C
	[Tooltip("FrameFlip: danh s\u00E1ch sprite l\u1EADt v\u00F2ng. Shine: kh\u00F4ng d\u00F9ng.")]
	public Sprite[] frames; // 0x30
	[Tooltip("FrameFlip: s\u1ED1 frame m\u1ED7i gi\u00E2y.")]
	public float fps; // 0x38
	private Vector3 _basePos; // 0x3C
	private Graphic _graphic; // 0x48
	private Image _image; // 0x50
	private float _baseAlpha; // 0x58
	private float _flipTimer; // 0x5C
	private int _flipIndex; // 0x60
	private bool _captured; // 0x64

	// Constructors
	public HomeBuildingFx(); // 0x00000001803AEEF0-0x00000001803AEF20

	// Methods
	private void Awake(); // 0x00000001803AE290-0x00000001803AE2A0
	private void OnEnable(); // 0x00000001803AE580-0x00000001803AE5A0
	private void OnDisable(); // 0x00000001803AE3D0-0x00000001803AE580
	private void Update(); // 0x00000001803AEDA0-0x00000001803AEEF0
	private void Capture(); // 0x00000001803AE2A0-0x00000001803AE3D0
	private void Restore(); // 0x00000001803AEA60-0x00000001803AEBC0
	public void Play(); // 0x00000001803AE5A0-0x00000001803AEA60
	[CompilerGenerated]
	private void _Play_b__19_0(float a); // 0x00000001803AEBC0-0x00000001803AECB0
	[CompilerGenerated]
	private void _Play_b__19_1(float a); // 0x00000001803AECB0-0x00000001803AEDA0
}

