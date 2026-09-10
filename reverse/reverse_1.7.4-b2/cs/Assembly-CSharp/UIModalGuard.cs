/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class UIModalGuard // TypeDefIndex: 1034
{
	// Fields
	public const int BlockerOrder = 60; // Metadata: 0x0068C1C3
	public const int ContentOrder = 61; // Metadata: 0x0068C1C4
	private const string BlockerName = "modalBlocker"; // Metadata: 0x0068C1C5
	private const float Overscan = 3000f; // Metadata: 0x0068C1D2

	// Methods
	public static void MakeModal(GameObject popup, Transform content = null); // 0x000000018050FD50-0x000000018050FFA0
	private static void SetCanvasOrder(GameObject go, int order); // 0x000000018050FFA0-0x00000001805100C0
	private static Transform FindContentRoot(Transform popup); // 0x000000018050FBE0-0x000000018050FD50
	private static void EnsureBlocker(Transform popup); // 0x000000018050F6D0-0x000000018050FBE0
}

