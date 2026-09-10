/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class AppRuntimeConfig // TypeDefIndex: 1499
{
	// Fields
	private const string KeyRenderScale = "tun.device.renderScale"; // Metadata: 0x0068D170
	private const string KeyQualityLevel = "tun.device.qualityLevel"; // Metadata: 0x0068D187
	private const string KeyTargetFps = "tun.frame.targetFps"; // Metadata: 0x0068D19F
	private static readonly float[] DefaultRenderScale; // 0x00
	private static readonly int[] DefaultQualityLevel; // 0x08
	private static readonly int[] DefaultTargetFps; // 0x10

	// Constructors
	static AppRuntimeConfig(); // 0x00000001805D98C0-0x00000001805D9A30

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void Apply(); // 0x00000001805D9780-0x00000001805D98C0
	private static void ApplyDeviceTier(); // 0x00000001805D8E60-0x00000001805D95E0
	private static void ApplyTweenPoolSize(); // 0x00000001805D96C0-0x00000001805D9780
	private static void ApplyLogStackTracePolicy(); // 0x00000001805D9630-0x00000001805D96C0
	private static void ApplyFrameRateCap(); // 0x00000001805D95E0-0x00000001805D9630
}

