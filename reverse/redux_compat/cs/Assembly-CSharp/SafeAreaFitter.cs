/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[DisallowMultipleComponent]
[RequireComponent(typeof(RectTransform))]
public class SafeAreaFitter : MonoBehaviour // TypeDefIndex: 633
{
	// Fields
	private RectTransform _rt; // 0x20
	private Rect _lastSafeArea; // 0x28
	private ScreenOrientation _lastOrientation; // 0x38
	private Vector2Int _lastResolution; // 0x3C

	// Constructors
	public SafeAreaFitter(); // 0x00000001803BC8D0-0x00000001803BC8E0

	// Methods
	private void Awake(); // 0x00000001803BC750-0x00000001803BC7F0
	private void Update(); // 0x00000001803BC7F0-0x00000001803BC8D0
	public void Apply(); // 0x00000001803BC440-0x00000001803BC750
}

