/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class HubSuspendManager // TypeDefIndex: 1948
{
	// Fields
	private static readonly List<IHubSuspendable> _items; // 0x00
	[CompilerGenerated]
	private static bool _IsSuspended_k__BackingField; // 0x08
	private static readonly List<Tween> _pausedTweens; // 0x10
	private static readonly List<Tween> _tweenScratch; // 0x18

	// Properties
	public static bool IsSuspended { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001809408B0-0x0000000180940910 0x0000000180940910-0x0000000180940970

	// Constructors
	static HubSuspendManager(); // 0x0000000180941D50-0x0000000180941F90

	// Methods
	public static void Register(IHubSuspendable item); // 0x0000000180940970-0x0000000180940BC0
	public static void Unregister(IHubSuspendable item); // 0x0000000180940BC0-0x0000000180940C90
	public static void SuspendAll(); // 0x0000000180940C90-0x0000000180941140
	public static void ResumeAll(); // 0x0000000180941140-0x0000000180941670
	private static void PauseHubLoopTweens(); // 0x0000000180941670-0x0000000180941A50
	private static int ResumeHubLoopTweens(); // 0x0000000180941A50-0x0000000180941BD0
	private static GameObject TargetGameObject(object target); // 0x0000000180941BD0-0x0000000180941D50
}

