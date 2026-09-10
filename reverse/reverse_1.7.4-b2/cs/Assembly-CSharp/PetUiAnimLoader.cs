/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class PetUiAnimLoader // TypeDefIndex: 1062
{
	// Fields
	public const string PET_ADDR_PREFIX = "Pets/"; // Metadata: 0x0068C37C
	public const string PET_ICON_PREFIX = "Image/IconsPet/"; // Metadata: 0x0068C382
	public const string IDLE_CONTROLLER_NAME = "EIdleT"; // Metadata: 0x0068C392
	private static readonly Dictionary<EntityId, long> _requested; // 0x00
	private static RuntimeAnimatorController _sharedIdle; // 0x08
	private static int _lastIdleScanFrame; // 0x10

	// Properties
	private static bool Live { get; } // 0x00000001805127E0-0x0000000180512820 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass6_0 // TypeDefIndex: 1063
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
		public __c__DisplayClass6_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Show_b__0(AnimationClip[] clips); // 0x0000000180520EA0-0x0000000180521110
	}

	// Constructors
	static PetUiAnimLoader(); // 0x0000000180512740-0x00000001805127E0

	// Methods
	public static void Show(Animator anim, Image img, PetImageFit fit, long petId, float targetW, float targetH, Action<bool> done = null); // 0x0000000180512250-0x0000000180512740
	public static void Release(Animator anim, Image img); // 0x00000001805120F0-0x0000000180512250
	public static RuntimeAnimatorController FindSharedIdleController(); // 0x0000000180511E50-0x00000001805120F0
	public static bool EnsureRig(Transform node, out Animator anim, out Image img, out PetImageFit fit); // 0x0000000180511AA0-0x0000000180511E50
	private static void CenterAnchors(RectTransform rt); // 0x00000001805117A0-0x0000000180511AA0
	public static void ApplyStaticIcon(Animator anim, Image img, long petId); // 0x00000001805115B0-0x00000001805117A0
}

