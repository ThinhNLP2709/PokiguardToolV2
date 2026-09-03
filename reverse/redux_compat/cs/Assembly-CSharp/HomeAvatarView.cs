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
public class HomeAvatarView : MonoBehaviour // TypeDefIndex: 600
{
	// Fields
	[Tooltip("\u1EA2nh \u0111\u1EA1i di\u1EC7n b\u00EAn trong m\u1EB7t n\u1EA1 tr\u00F2n (node \'Image (1)/Image\' c\u1EE7a b\u1EA3n g\u1ED1c).")]
	public RawImage avatarRaw; // 0x20
	[Tooltip("Vi\u1EC1n quanh \u1EA3nh (node \'ImageAvatarFrame\').")]
	public RawImage frameRaw; // 0x28
	[Tooltip("Ch\u1EEF c\u1EA5p (node \'TextLevel\').")]
	public UnityEngine.UI.Text levelText; // 0x30
	[Tooltip("B\u1EA5m v\u00E0o \u00F4 \u0111\u1EA1i di\u1EC7n \u2014 builder n\u1ED1i s\u1EB5n.")]
	public HomePressScale press; // 0x38
	[Tooltip("Route m\u1EDF khi b\u1EA5m (\u0111i qua HomeFeatureRouter nh\u01B0 m\u1ECDi n\u00FAt kh\u00E1c).")]
	public string routeKey; // 0x40
	private bool _hooked; // 0x48

	// Constructors
	public HomeAvatarView(); // 0x00000001803AE240-0x00000001803AE290

	// Methods
	private void Awake(); // 0x00000001803ADD80-0x00000001803ADF00
	private void OnDestroy(); // 0x00000001803AE170-0x00000001803AE240
	public void Bind(UserDTO user); // 0x00000001803ADF00-0x00000001803AE0A0
	private void HandleClick(); // 0x00000001803AE0A0-0x00000001803AE170
}

