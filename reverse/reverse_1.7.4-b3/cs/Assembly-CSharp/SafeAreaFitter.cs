/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
[RequireComponent(typeof(RectTransform))]
public class SafeAreaFitter : MonoBehaviour // TypeDefIndex: 996
{
	// Fields
	private RectTransform _rt; // 0x20
	private Rect _lastSafeArea; // 0x28
	private ScreenOrientation _lastOrientation; // 0x38
	private Vector2Int _lastResolution; // 0x3C

	// Constructors
	public SafeAreaFitter(); // 0x00000001805F5D40-0x00000001805F5D90

	// Methods
	private void Awake(); // 0x00000001805F5430-0x00000001805F5510
	private void Update(); // 0x00000001805F5510-0x00000001805F56A0
	public void Apply(); // 0x00000001805F56A0-0x00000001805F5D40
}

