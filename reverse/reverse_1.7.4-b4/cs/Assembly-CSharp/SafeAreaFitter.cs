/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
[RequireComponent(typeof(RectTransform))]
public class SafeAreaFitter : MonoBehaviour // TypeDefIndex: 998
{
	// Fields
	private RectTransform _rt; // 0x20
	private Rect _lastSafeArea; // 0x28
	private ScreenOrientation _lastOrientation; // 0x38
	private Vector2Int _lastResolution; // 0x3C

	// Constructors
	public SafeAreaFitter(); // 0x00000001805F7730-0x00000001805F7780

	// Methods
	private void Awake(); // 0x00000001805F6E20-0x00000001805F6F00
	private void Update(); // 0x00000001805F6F00-0x00000001805F7090
	public void Apply(); // 0x00000001805F7090-0x00000001805F7730
}

