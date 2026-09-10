/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class HubSuspendManager // TypeDefIndex: 1564
{
	// Fields
	private static readonly List<IHubSuspendable> _items; // 0x00
	[CompilerGenerated]
	private static bool _IsSuspended_k__BackingField; // 0x08
	private static readonly List<Tween> _pausedTweens; // 0x10
	private static readonly List<Tween> _tweenScratch; // 0x18

	// Properties
	public static bool IsSuspended { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805F90E0-0x00000001805F9130 0x00000001805F9130-0x00000001805F9190

	// Constructors
	static HubSuspendManager(); // 0x00000001805F8FB0-0x00000001805F90E0

	// Methods
	public static void Register(IHubSuspendable item); // 0x00000001805F8120-0x00000001805F8370
	public static void Unregister(IHubSuspendable item); // 0x00000001805F8F20-0x00000001805F8FB0
	public static void SuspendAll(); // 0x00000001805F89D0-0x00000001805F8E20
	public static void ResumeAll(); // 0x00000001805F8370-0x00000001805F8880
	private static void PauseHubLoopTweens(); // 0x00000001805F7E60-0x00000001805F8120
	private static int ResumeHubLoopTweens(); // 0x00000001805F8880-0x00000001805F89D0
	private static GameObject TargetGameObject(object target); // 0x00000001805F8E20-0x00000001805F8F20
}

