/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class PetUiAnimLoader // TypeDefIndex: 1441
{
	// Fields
	private static readonly Dictionary<EntityId, long> _requested; // 0x00
	private static RuntimeAnimatorController _sharedIdle; // 0x08
	private static int _lastIdleScanFrame; // 0x10

	// Properties
	private static bool Live { get; } // 0x00000001807D3D50-0x00000001807D3DD0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass6_0 // TypeDefIndex: 1442
	{
		// Fields
		public Animator anim; // 0x10
		public Image img; // 0x18
		public EntityId key; // 0x20
		public long requested; // 0x28
		public PetImageFit fit; // 0x30
		public float targetW; // 0x38
		public float targetH; // 0x3C
		public Action<bool> done; // 0x40

		// Constructors
		public __c__DisplayClass6_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Show_b__0(AnimationClip[] clips); // 0x00000001807D6690-0x00000001807D6B20
	}

	// Constructors
	static PetUiAnimLoader(); // 0x00000001807D6530-0x00000001807D6690

	// Methods
	public static void Show(Animator anim, Image img, PetImageFit fit, long petId, float targetW, float targetH, Action<bool> done = null); // 0x00000001807D3DD0-0x00000001807D44A0
	public static void Release(Animator anim, Image img); // 0x00000001807D44A0-0x00000001807D4810
	public static RuntimeAnimatorController FindSharedIdleController(); // 0x00000001807D4810-0x00000001807D4ED0
	public static bool EnsureRig(Transform node, out Animator anim, out Image img, out PetImageFit fit); // 0x00000001807D4ED0-0x00000001807D5A90
	private static void CenterAnchors(RectTransform rt); // 0x00000001807D5A90-0x00000001807D5F20
	public static void ApplyStaticIcon(Animator anim, Image img, long petId); // 0x00000001807D5F20-0x00000001807D6530
}

