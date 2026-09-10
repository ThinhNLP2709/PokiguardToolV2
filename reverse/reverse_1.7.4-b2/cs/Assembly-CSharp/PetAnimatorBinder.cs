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

public static class PetAnimatorBinder // TypeDefIndex: 1045
{
	// Fields
	private const string ICON_PATH = "Image/IconsPet/"; // Metadata: 0x0068C31F
	private static readonly Dictionary<AocKey, AocEntry> _aocCache; // 0x00
	private static readonly HashSet<AnimatorOverrideController> _cachedAocs; // 0x08
	private static readonly HashSet<AnimatorOverrideController> _ownedAocs; // 0x10
	private const int AOC_OWNED_MAX = 256; // Metadata: 0x0068C32F
	private const int AOC_CACHE_MAX = 64; // Metadata: 0x0068C331
	private static readonly string[] IDLE_CLIP_NAMES; // 0x18

	// Nested types
	[IsReadOnly]
	private struct AocKey : IEquatable<AocKey> // TypeDefIndex: 1046
	{
		// Fields
		private readonly RuntimeAnimatorController _base; // 0x00
		private readonly AnimationClip[] _clips; // 0x08

		// Constructors
		public AocKey(RuntimeAnimatorController baseController, AnimationClip[] clips); // 0x00000001804F8D40-0x00000001804F8D80

		// Methods
		public bool Equals(AocKey other); // 0x00000001804F8C50-0x00000001804F8C70
		public override bool Equals(object obj); // 0x00000001804F8C70-0x00000001804F8D00
		public override int GetHashCode(); // 0x00000001804F8D00-0x00000001804F8D40
	}

	[IsReadOnly]
	private struct AocEntry // TypeDefIndex: 1047
	{
		// Fields
		public readonly AnimatorOverrideController Controller; // 0x00
		public readonly bool Complete; // 0x08

		// Constructors
		public AocEntry(AnimatorOverrideController c, bool complete); // 0x00000001804F8C20-0x00000001804F8C50
	}

	// Constructors
	static PetAnimatorBinder(); // 0x0000000180500D60-0x0000000180500F40

	// Methods
	public static RuntimeAnimatorController ResolveBase(Animator animator); // 0x00000001805009C0-0x0000000180500B80
	private static void TrackOwned(AnimatorOverrideController aoc); // 0x0000000180500B80-0x0000000180500C60
	public static void ClearAocCache(); // 0x0000000180500830-0x00000001805008B0
	public static bool Bind(Animator animator, AnimationClip[] clips, string debugLabel = null); // 0x00000001805007B0-0x0000000180500830
	public static bool Bind(Animator animator, AnimationClip[] clips, out bool complete, string debugLabel = null); // 0x00000001804FFDB0-0x00000001805007B0
	public static bool BindSingle(Animator animator, string clipName, AnimationClip clip); // 0x00000001804FFBD0-0x00000001804FFDB0
	public static bool BindOrFallback(Animator animator, AnimationClip[] clips, string petId, Image fallbackImage = null, SpriteRenderer fallbackRenderer = null); // 0x00000001804FFA00-0x00000001804FFBD0
	public static void ApplyStaticFallback(Animator animator, string petId, Image image = null, SpriteRenderer renderer = null); // 0x00000001804FF7E0-0x00000001804FFA00
	private static void UseAnimatedRenderer(Animator animator); // 0x0000000180500C60-0x0000000180500D60
	private static void ApplyController(Animator animator, AnimatorOverrideController controller); // 0x00000001804FF560-0x00000001804FF7E0
	private static bool HasIntParam(Animator animator, string name); // 0x00000001805008B0-0x00000001805009C0
}

