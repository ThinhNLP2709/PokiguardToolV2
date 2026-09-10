/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class FusionGhostFx // TypeDefIndex: 1939
{
	// Fields
	private const string NODE_NAME = "FusionGhostFx"; // Metadata: 0x0068DCB1
	private const string DEAD_NODE_NAME = "FusionGhostFx_dead"; // Metadata: 0x0068DCBF
	private const int FX_ORDER_BELOW_HOST = 1; // Metadata: 0x0068DCD2
	private const float AURA_Z_TOWARD_CAM = -1f; // Metadata: 0x0068DCD3
	private const float GHOST_Z_TOWARD_CAM = -2f; // Metadata: 0x0068DCD7
	private const float GHOST_ALPHA = 0.55f; // Metadata: 0x0068DCDB
	private const float GHOST_HEIGHT_SCALE = 1.45f; // Metadata: 0x0068DCDF
	private const float GHOST_CENTER_LIFT = 0.3f; // Metadata: 0x0068DCE3
	private const float GHOST_BREATH = 0.04f; // Metadata: 0x0068DCE7
	private const float AURA_HEIGHT_SCALE = 1f; // Metadata: 0x0068DCEB
	private const float AURA_ALPHA_MIN = 0.45f; // Metadata: 0x0068DCEF
	private const float AURA_ALPHA_MAX = 0.85f; // Metadata: 0x0068DCF3
	private const float AURA_SPIN_SECONDS = 12f; // Metadata: 0x0068DCF7
	private const float FALLBACK_SPRITE_UNITS = 0.8f; // Metadata: 0x0068DCFB

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass16_0 // TypeDefIndex: 1940
	{
		// Fields
		public GameObject aura; // 0x10
		public SpriteRenderer auraSr; // 0x18
		public Vector3 auraBase; // 0x20

		// Constructors
		public __c__DisplayClass16_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _BuildAura_b__0(float k); // 0x0000000180710110-0x00000001807102B0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass17_0 // TypeDefIndex: 1941
	{
		// Fields
		public FusionGhostFxNode marker; // 0x10
		public int boundPetId; // 0x18

		// Constructors
		public __c__DisplayClass17_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _BuildGhost_b__0(float k); // 0x00000001807102B0-0x00000001807103B0
		internal void _BuildGhost_b__1(AnimationClip[] clips); // 0x00000001807103B0-0x0000000180710440
	}

	// Methods
	public static void Bind(SpriteRenderer host, int petId); // 0x00000001806FE200-0x00000001806FE5E0
	public static void Clear(SpriteRenderer host); // 0x00000001806FF180-0x00000001806FF250
	private static void BuildAura(FusionGhostFxNode marker, GameObject go, SpriteRenderer host, float hostUnits, int order); // 0x00000001806FE5E0-0x00000001806FEA80
	private static void BuildGhost(FusionGhostFxNode marker, GameObject go, SpriteRenderer host, int petId, float hostUnits, int order); // 0x00000001806FEA80-0x00000001806FF180
	private static void ApplyGhostClips(FusionGhostFxNode marker, AnimationClip[] clips); // 0x00000001806FDF10-0x00000001806FE200
	private static FusionGhostFxNode FindNode(Transform host); // 0x00000001806FF250-0x00000001806FF360
	private static void SetLocalHeight(Transform t, Sprite sprite, float targetUnits); // 0x00000001806FF360-0x00000001806FF460
}

