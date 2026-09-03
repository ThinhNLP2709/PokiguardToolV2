/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class HubSuspendManager // TypeDefIndex: 1324
{
	// Fields
	private static readonly List<IHubSuspendable> _items; // 0x00
	[CompilerGenerated]
	private static bool _IsSuspended_k__BackingField; // 0x08
	private static readonly List<Tween> _pausedTweens; // 0x10
	private static readonly List<Tween> _tweenScratch; // 0x18

	// Properties
	public static bool IsSuspended { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001804F58C0-0x00000001804F5910 0x00000001804F5910-0x00000001804F5970

	// Constructors
	static HubSuspendManager(); // 0x00000001804F5790-0x00000001804F58C0

	// Methods
	public static void Register(IHubSuspendable item); // 0x00000001804F4900-0x00000001804F4B50
	public static void Unregister(IHubSuspendable item); // 0x00000001804F5700-0x00000001804F5790
	public static void SuspendAll(); // 0x00000001804F51B0-0x00000001804F5600
	public static void ResumeAll(); // 0x00000001804F4B50-0x00000001804F5060
	private static void PauseHubLoopTweens(); // 0x00000001804F4640-0x00000001804F4900
	private static int ResumeHubLoopTweens(); // 0x00000001804F5060-0x00000001804F51B0
	private static GameObject TargetGameObject(object target); // 0x00000001804F5600-0x00000001804F5700
}

