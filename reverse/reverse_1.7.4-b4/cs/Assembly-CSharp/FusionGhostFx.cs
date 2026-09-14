/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class FusionGhostFx // TypeDefIndex: 2312
{
	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass16_0 // TypeDefIndex: 2313
	{
		// Fields
		public GameObject aura; // 0x10
		public SpriteRenderer auraSr; // 0x18
		public Vector3 auraBase; // 0x20

		// Constructors
		public __c__DisplayClass16_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildAura_b__0(float k); // 0x0000000180B1CBB0-0x0000000180B1CF60
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass17_0 // TypeDefIndex: 2314
	{
		// Fields
		public FusionGhostFxNode marker; // 0x10
		public int boundPetId; // 0x18

		// Constructors
		public __c__DisplayClass17_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BuildGhost_b__0(float k); // 0x0000000180B1CF60-0x0000000180B1D1C0
		internal void _BuildGhost_b__1(AnimationClip[] clips); // 0x0000000180B1D1C0-0x0000000180B1D2D0
	}

	// Methods
	public static void Bind(SpriteRenderer host, int petId); // 0x0000000180B19D90-0x0000000180B1A570
	public static void Clear(SpriteRenderer host); // 0x0000000180B1A570-0x0000000180B1A740
	private static void BuildAura(FusionGhostFxNode marker, GameObject go, SpriteRenderer host, float hostUnits, int order); // 0x0000000180B1A740-0x0000000180B1B030
	private static void BuildGhost(FusionGhostFxNode marker, GameObject go, SpriteRenderer host, int petId, float hostUnits, int order); // 0x0000000180B1B030-0x0000000180B1BFE0
	private static void ApplyGhostClips(FusionGhostFxNode marker, AnimationClip[] clips); // 0x0000000180B1BFE0-0x0000000180B1C690
	private static FusionGhostFxNode FindNode(Transform host); // 0x0000000180B1C690-0x0000000180B1C910
	private static void SetLocalHeight(Transform t, Sprite sprite, float targetUnits); // 0x0000000180B1C910-0x0000000180B1CBB0
}

