/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class PetUiAnimLoader // TypeDefIndex: 1443
{
	// Fields
	private static readonly Dictionary<EntityId, long> _requested; // 0x00
	private static RuntimeAnimatorController _sharedIdle; // 0x08
	private static int _lastIdleScanFrame; // 0x10

	// Properties
	private static bool Live { get; } // 0x00000001807D5DC0-0x00000001807D5E40 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass6_0 // TypeDefIndex: 1444
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
		internal void _Show_b__0(AnimationClip[] clips); // 0x00000001807D8700-0x00000001807D8B90
	}

	// Constructors
	static PetUiAnimLoader(); // 0x00000001807D85A0-0x00000001807D8700

	// Methods
	public static void Show(Animator anim, Image img, PetImageFit fit, long petId, float targetW, float targetH, Action<bool> done = null); // 0x00000001807D5E40-0x00000001807D6510
	public static void Release(Animator anim, Image img); // 0x00000001807D6510-0x00000001807D6880
	public static RuntimeAnimatorController FindSharedIdleController(); // 0x00000001807D6880-0x00000001807D6F40
	public static bool EnsureRig(Transform node, out Animator anim, out Image img, out PetImageFit fit); // 0x00000001807D6F40-0x00000001807D7B00
	private static void CenterAnchors(RectTransform rt); // 0x00000001807D7B00-0x00000001807D7F90
	public static void ApplyStaticIcon(Animator anim, Image img, long petId); // 0x00000001807D7F90-0x00000001807D85A0
}

