/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class PetUiAnimLoader // TypeDefIndex: 861
{
	// Fields
	public const string PET_ADDR_PREFIX = "Pets/"; // Metadata: 0x0064CBE6
	public const string PET_ICON_PREFIX = "Image/IconsPet/"; // Metadata: 0x0064CBEC
	private static readonly Dictionary<EntityId, long> _requested; // 0x00

	// Properties
	private static bool Live { get; } // 0x000000018043DDF0-0x000000018043DE30 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass5_0 // TypeDefIndex: 862
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
		public __c__DisplayClass5_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _Show_b__0(AnimationClip[] clips); // 0x0000000180449F60-0x000000018044A1D0
	}

	// Constructors
	static PetUiAnimLoader(); // 0x000000018043DD60-0x000000018043DDF0

	// Methods
	public static void Show(Animator anim, Image img, PetImageFit fit, long petId, float targetW, float targetH, Action<bool> done = null); // 0x000000018043D870-0x000000018043DD60
	public static void Release(Animator anim, Image img); // 0x000000018043D710-0x000000018043D870
	public static void ApplyStaticIcon(Animator anim, Image img, long petId); // 0x000000018043D520-0x000000018043D710
}

