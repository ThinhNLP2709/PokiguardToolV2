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

public static class PetAnimatorBinder // TypeDefIndex: 1426
{
	// Fields
	private static readonly Dictionary<AocKey, AocEntry> _aocCache; // 0x00
	private static readonly HashSet<AnimatorOverrideController> _cachedAocs; // 0x08
	private static readonly HashSet<AnimatorOverrideController> _ownedAocs; // 0x10
	private static readonly string[] IDLE_CLIP_NAMES; // 0x18

	// Nested types
	[IsReadOnly]
	private struct AocKey : IEquatable<AocKey> // TypeDefIndex: 1427
	{
		// Fields
		private readonly RuntimeAnimatorController _base; // 0x00
		private readonly AnimationClip[] _clips; // 0x08

		// Constructors
		public AocKey(RuntimeAnimatorController baseController, AnimationClip[] clips); // 0x00000001807C8D90-0x00000001807C8E40

		// Methods
		public bool Equals(AocKey other); // 0x00000001807C8E40-0x00000001807C8E60
		public override bool Equals(object obj); // 0x00000001807C8E60-0x00000001807C8EF0
		public override int GetHashCode(); // 0x00000001807C8EF0-0x00000001807C8F10
	}

	[IsReadOnly]
	private struct AocEntry // TypeDefIndex: 1428
	{
		// Fields
		public readonly AnimatorOverrideController Controller; // 0x00
		public readonly bool Complete; // 0x08

		// Constructors
		public AocEntry(AnimatorOverrideController c, bool complete); // 0x00000001807C8F10-0x00000001807C8F70
	}

	// Constructors
	static PetAnimatorBinder(); // 0x00000001807A4400-0x00000001807A4830

	// Methods
	public static RuntimeAnimatorController ResolveBase(Animator animator); // 0x00000001807A1500-0x00000001807A1B10
	private static void TrackOwned(AnimatorOverrideController aoc); // 0x00000001807A1B10-0x00000001807A1C90
	public static void ClearAocCache(); // 0x00000001807A1C90-0x00000001807A1D60
	public static bool Bind(Animator animator, AnimationClip[] clips, string debugLabel = null); // 0x00000001807A1D60-0x00000001807A1DF0
	public static bool Bind(Animator animator, AnimationClip[] clips, out bool complete, string debugLabel = null); // 0x00000001807A1DF0-0x00000001807A2E60
	public static bool BindSingle(Animator animator, string clipName, AnimationClip clip); // 0x00000001807A2E60-0x00000001807A3280
	public static bool BindOrFallback(Animator animator, AnimationClip[] clips, string petId, Image fallbackImage = null, SpriteRenderer fallbackRenderer = null); // 0x00000001807A3280-0x00000001807A3330
	public static void ApplyStaticFallback(Animator animator, string petId, Image image = null, SpriteRenderer renderer = null); // 0x00000001807A3330-0x00000001807A3A20
	private static void UseAnimatedRenderer(Animator animator); // 0x00000001807A3A20-0x00000001807A3D00
	private static void ApplyController(Animator animator, AnimatorOverrideController controller); // 0x00000001807A3D00-0x00000001807A4130
	private static bool HasIntParam(Animator animator, string name); // 0x00000001807A4130-0x00000001807A4400
}

