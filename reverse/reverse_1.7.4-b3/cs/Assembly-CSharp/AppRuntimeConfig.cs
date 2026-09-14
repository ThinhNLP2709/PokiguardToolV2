/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class AppRuntimeConfig // TypeDefIndex: 1882
{
	// Fields
	private static readonly float[] DefaultRenderScale; // 0x00
	private static readonly int[] DefaultQualityLevel; // 0x08
	private static readonly int[] DefaultTargetFps; // 0x10

	// Constructors
	static AppRuntimeConfig(); // 0x000000018091DB40-0x000000018091DDA0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void Apply(); // 0x000000018091CAD0-0x000000018091CDC0
	private static void ApplyDeviceTier(); // 0x000000018091CDC0-0x000000018091D7A0
	private static void ApplyTweenPoolSize(); // 0x000000018091D7A0-0x000000018091D8C0
	private static void ApplyLogStackTracePolicy(); // 0x000000018091D8C0-0x000000018091DA70
	private static void ApplyFrameRateCap(); // 0x000000018091DA70-0x000000018091DB40
}

