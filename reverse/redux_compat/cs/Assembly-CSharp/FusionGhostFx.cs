/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class FusionGhostFx // TypeDefIndex: 1666
{
	// Fields
	private const string NODE_NAME = "FusionGhostFx"; // Metadata: 0x0064D882
	private const string DEAD_NODE_NAME = "FusionGhostFx_dead"; // Metadata: 0x0064D890
	private const int FX_ORDER_BELOW_HOST = 1; // Metadata: 0x0064D8A3
	private const float AURA_Z_TOWARD_CAM = -1f; // Metadata: 0x0064D8A4
	private const float GHOST_Z_TOWARD_CAM = -2f; // Metadata: 0x0064D8A8
	private const float GHOST_ALPHA = 0.55f; // Metadata: 0x0064D8AC
	private const float GHOST_HEIGHT_SCALE = 1.45f; // Metadata: 0x0064D8B0
	private const float GHOST_CENTER_LIFT = 0.3f; // Metadata: 0x0064D8B4
	private const float GHOST_BREATH = 0.04f; // Metadata: 0x0064D8B8
	private const float AURA_HEIGHT_SCALE = 1f; // Metadata: 0x0064D8BC
	private const float AURA_ALPHA_MIN = 0.45f; // Metadata: 0x0064D8C0
	private const float AURA_ALPHA_MAX = 0.85f; // Metadata: 0x0064D8C4
	private const float AURA_SPIN_SECONDS = 12f; // Metadata: 0x0064D8C8
	private const float FALLBACK_SPRITE_UNITS = 0.8f; // Metadata: 0x0064D8CC

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass16_0 // TypeDefIndex: 1667
	{
		// Fields
		public GameObject aura; // 0x10
		public SpriteRenderer auraSr; // 0x18
		public Vector3 auraBase; // 0x20

		// Constructors
		public __c__DisplayClass16_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _BuildAura_b__0(float k); // 0x00000001805E8A80-0x00000001805E8C20
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass17_0 // TypeDefIndex: 1668
	{
		// Fields
		public FusionGhostFxNode marker; // 0x10
		public int boundPetId; // 0x18

		// Constructors
		public __c__DisplayClass17_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _BuildGhost_b__0(float k); // 0x00000001805E8C60-0x00000001805E8D60
		internal void _BuildGhost_b__1(AnimationClip[] clips); // 0x00000001805E8D60-0x00000001805E8DF0
	}

	// Methods
	public static void Bind(SpriteRenderer host, int petId); // 0x00000001805CC280-0x00000001805CC660
	public static void Clear(SpriteRenderer host); // 0x00000001805CD200-0x00000001805CD2D0
	private static void BuildAura(FusionGhostFxNode marker, GameObject go, SpriteRenderer host, float hostUnits, int order); // 0x00000001805CC660-0x00000001805CCB00
	private static void BuildGhost(FusionGhostFxNode marker, GameObject go, SpriteRenderer host, int petId, float hostUnits, int order); // 0x00000001805CCB00-0x00000001805CD200
	private static void ApplyGhostClips(FusionGhostFxNode marker, AnimationClip[] clips); // 0x00000001805CBF90-0x00000001805CC280
	private static FusionGhostFxNode FindNode(Transform host); // 0x00000001805CD2D0-0x00000001805CD3E0
	private static void SetLocalHeight(Transform t, Sprite sprite, float targetUnits); // 0x00000001805CD3E0-0x00000001805CD4E0
}

