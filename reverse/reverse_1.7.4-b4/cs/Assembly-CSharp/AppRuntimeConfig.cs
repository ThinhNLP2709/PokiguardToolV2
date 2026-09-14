/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class AppRuntimeConfig // TypeDefIndex: 1884
{
	// Fields
	private static readonly float[] DefaultRenderScale; // 0x00
	private static readonly int[] DefaultQualityLevel; // 0x08
	private static readonly int[] DefaultTargetFps; // 0x10

	// Constructors
	static AppRuntimeConfig(); // 0x0000000180921080-0x00000001809212E0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void Apply(); // 0x0000000180920010-0x0000000180920300
	private static void ApplyDeviceTier(); // 0x0000000180920300-0x0000000180920CE0
	private static void ApplyTweenPoolSize(); // 0x0000000180920CE0-0x0000000180920E00
	private static void ApplyLogStackTracePolicy(); // 0x0000000180920E00-0x0000000180920FB0
	private static void ApplyFrameRateCap(); // 0x0000000180920FB0-0x0000000180921080
}

