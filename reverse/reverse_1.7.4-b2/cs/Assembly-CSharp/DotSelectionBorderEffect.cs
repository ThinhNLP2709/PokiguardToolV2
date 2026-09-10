/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class DotSelectionBorderEffect : MonoBehaviour // TypeDefIndex: 1928
{
	// Fields
	private const string FRAME_PATH = "Image/Poky/DotFramePoky"; // Metadata: 0x0068DC53
	private const float FRAME_PAD = 1.18f; // Metadata: 0x0068DC6B
	private const float PULSE_HZ = 1.6f; // Metadata: 0x0068DC6F
	private const float PULSE_SCALE = 1.03f; // Metadata: 0x0068DC73
	private static Material s_sharedLineMat; // 0x00
	private static Sprite s_frameSprite; // 0x08
	private static bool s_frameLookupDone; // 0x10
	private LineRenderer[] _edges; // 0x20
	private GameObject _fxRoot; // 0x28
	private SpriteRenderer _spriteRenderer; // 0x30
	private SpriteRenderer _frame; // 0x38
	private Vector2 _frameBaseScale; // 0x40
	private Vector2 _fitToSpriteSize; // 0x48

	// Properties
	private static Material SharedLineMaterial { get; } // 0x00000001806EC210-0x00000001806EC3E0 
	private static Sprite FrameSprite { get; } // 0x00000001806EC090-0x00000001806EC210 

	// Nested types
	[CompilerGenerated]
	private struct __c__DisplayClass24_0 // TypeDefIndex: 1929
	{
		// Fields
		public Vector3 ctr; // 0x00
		public float z; // 0x0C
	}

	// Constructors
	public DotSelectionBorderEffect(); // 0x00000001806EC010-0x00000001806EC090

	// Methods
	public static void Prewarm(); // 0x00000001806EB790-0x00000001806EB7B0
	public static void StartOn(Dot dot); // 0x00000001806EBD10-0x00000001806EBDD0
	public static void StopOn(GameObject dotRoot); // 0x00000001806EBDD0-0x00000001806EBE80
	private void Build(Dot dot); // 0x00000001806EAF60-0x00000001806EB240
	private void BuildFrame(Sprite frame); // 0x00000001806EAD10-0x00000001806EAF60
	private void FitFrame(); // 0x00000001806EB4B0-0x00000001806EB6C0
	private LineRenderer CreateEdge(int index); // 0x00000001806EB240-0x00000001806EB4B0
	private void RefreshGeometry(); // 0x00000001806EB7B0-0x00000001806EBD10
	private void LateUpdate(); // 0x00000001806EB6C0-0x00000001806EB780
	private void AnimateFrame(); // 0x00000001806EAAF0-0x00000001806EAD10
	private void AnimateFallbackEdges(); // 0x00000001806EA780-0x00000001806EAAF0
	private void Teardown(); // 0x00000001806EBE80-0x00000001806EBF90
	private void OnDestroy(); // 0x00000001806EB780-0x00000001806EB790
	[CompilerGenerated]
	internal static Vector3 _RefreshGeometry_g__Corner_24_0(float x, float y, ref __c__DisplayClass24_0 param_000025d2); // 0x00000001806EBF90-0x00000001806EC010
}

