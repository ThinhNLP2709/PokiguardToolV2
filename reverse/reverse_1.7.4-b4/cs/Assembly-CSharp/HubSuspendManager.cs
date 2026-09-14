/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class HubSuspendManager // TypeDefIndex: 1950
{
	// Fields
	private static readonly List<IHubSuspendable> _items; // 0x00
	[CompilerGenerated]
	private static bool _IsSuspended_k__BackingField; // 0x08
	private static readonly List<Tween> _pausedTweens; // 0x10
	private static readonly List<Tween> _tweenScratch; // 0x18

	// Properties
	public static bool IsSuspended { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180943EB0-0x0000000180943F10 0x0000000180943F10-0x0000000180943F70

	// Constructors
	static HubSuspendManager(); // 0x0000000180945350-0x0000000180945590

	// Methods
	public static void Register(IHubSuspendable item); // 0x0000000180943F70-0x00000001809441C0
	public static void Unregister(IHubSuspendable item); // 0x00000001809441C0-0x0000000180944290
	public static void SuspendAll(); // 0x0000000180944290-0x0000000180944740
	public static void ResumeAll(); // 0x0000000180944740-0x0000000180944C70
	private static void PauseHubLoopTweens(); // 0x0000000180944C70-0x0000000180945050
	private static int ResumeHubLoopTweens(); // 0x0000000180945050-0x00000001809451D0
	private static GameObject TargetGameObject(object target); // 0x00000001809451D0-0x0000000180945350
}

