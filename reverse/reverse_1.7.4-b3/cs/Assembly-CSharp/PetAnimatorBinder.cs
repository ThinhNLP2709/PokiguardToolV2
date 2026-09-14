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

public static class PetAnimatorBinder // TypeDefIndex: 1424
{
	// Fields
	private static readonly Dictionary<AocKey, AocEntry> _aocCache; // 0x00
	private static readonly HashSet<AnimatorOverrideController> _cachedAocs; // 0x08
	private static readonly HashSet<AnimatorOverrideController> _ownedAocs; // 0x10
	private static readonly string[] IDLE_CLIP_NAMES; // 0x18

	// Nested types
	[IsReadOnly]
	private struct AocKey : IEquatable<AocKey> // TypeDefIndex: 1425
	{
		// Fields
		private readonly RuntimeAnimatorController _base; // 0x00
		private readonly AnimationClip[] _clips; // 0x08

		// Constructors
		public AocKey(RuntimeAnimatorController baseController, AnimationClip[] clips); // 0x00000001807C6D20-0x00000001807C6DD0

		// Methods
		public bool Equals(AocKey other); // 0x00000001807C6DD0-0x00000001807C6DF0
		public override bool Equals(object obj); // 0x00000001807C6DF0-0x00000001807C6E80
		public override int GetHashCode(); // 0x00000001807C6E80-0x00000001807C6EA0
	}

	[IsReadOnly]
	private struct AocEntry // TypeDefIndex: 1426
	{
		// Fields
		public readonly AnimatorOverrideController Controller; // 0x00
		public readonly bool Complete; // 0x08

		// Constructors
		public AocEntry(AnimatorOverrideController c, bool complete); // 0x00000001807C6EA0-0x00000001807C6F00
	}

	// Constructors
	static PetAnimatorBinder(); // 0x00000001807A2390-0x00000001807A27C0

	// Methods
	public static RuntimeAnimatorController ResolveBase(Animator animator); // 0x000000018079F490-0x000000018079FAA0
	private static void TrackOwned(AnimatorOverrideController aoc); // 0x000000018079FAA0-0x000000018079FC20
	public static void ClearAocCache(); // 0x000000018079FC20-0x000000018079FCF0
	public static bool Bind(Animator animator, AnimationClip[] clips, string debugLabel = null); // 0x000000018079FCF0-0x000000018079FD80
	public static bool Bind(Animator animator, AnimationClip[] clips, out bool complete, string debugLabel = null); // 0x000000018079FD80-0x00000001807A0DF0
	public static bool BindSingle(Animator animator, string clipName, AnimationClip clip); // 0x00000001807A0DF0-0x00000001807A1210
	public static bool BindOrFallback(Animator animator, AnimationClip[] clips, string petId, Image fallbackImage = null, SpriteRenderer fallbackRenderer = null); // 0x00000001807A1210-0x00000001807A12C0
	public static void ApplyStaticFallback(Animator animator, string petId, Image image = null, SpriteRenderer renderer = null); // 0x00000001807A12C0-0x00000001807A19B0
	private static void UseAnimatedRenderer(Animator animator); // 0x00000001807A19B0-0x00000001807A1C90
	private static void ApplyController(Animator animator, AnimatorOverrideController controller); // 0x00000001807A1C90-0x00000001807A20C0
	private static bool HasIntParam(Animator animator, string name); // 0x00000001807A20C0-0x00000001807A2390
}

