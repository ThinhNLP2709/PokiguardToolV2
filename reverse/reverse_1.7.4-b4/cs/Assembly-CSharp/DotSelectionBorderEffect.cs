/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class DotSelectionBorderEffect : MonoBehaviour // TypeDefIndex: 2301
{
	// Fields
	private const string FRAME_PATH = "Image/Poky/DotFramePoky"; // Metadata: 0x005F1E95
	private const float FRAME_PAD = 1.18f; // Metadata: 0x005F1EAD
	private const float PULSE_HZ = 1.6f; // Metadata: 0x005F1EB1
	private const float PULSE_SCALE = 1.03f; // Metadata: 0x005F1EB5
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
	private static Material SharedLineMaterial { get; } // 0x0000000180AF20A0-0x0000000180AF2440 
	private static Sprite FrameSprite { get; } // 0x0000000180AF2440-0x0000000180AF26A0 

	// Nested types
	[CompilerGenerated]
	private struct __c__DisplayClass24_0 // TypeDefIndex: 2302
	{
		// Fields
		public Vector3 ctr; // 0x00
		public float z; // 0x0C
	}

	// Constructors
	public DotSelectionBorderEffect(); // 0x0000000180AF5E70-0x0000000180AF5F70

	// Methods
	public static void Prewarm(); // 0x0000000180AF26A0-0x0000000180AF26C0
	public static void StartOn(Dot dot); // 0x0000000180AF26C0-0x0000000180AF2800
	public static void StopOn(GameObject dotRoot); // 0x0000000180AF2800-0x0000000180AF29A0
	private void Build(Dot dot); // 0x0000000180AF29A0-0x0000000180AF3070
	private void BuildFrame(Sprite frame); // 0x0000000180AF3070-0x0000000180AF3750
	private void FitFrame(); // 0x0000000180AF3750-0x0000000180AF3C60
	private LineRenderer CreateEdge(int index); // 0x0000000180AF3C60-0x0000000180AF44B0
	private void RefreshGeometry(); // 0x0000000180AF44B0-0x0000000180AF4FA0
	private void LateUpdate(); // 0x0000000180AF4FA0-0x0000000180AF51F0
	private void AnimateFrame(); // 0x0000000180AF51F0-0x0000000180AF5670
	private void AnimateFallbackEdges(); // 0x0000000180AF5670-0x0000000180AF5B80
	private void Teardown(); // 0x0000000180AF5B80-0x0000000180AF5E60
	private void OnDestroy(); // 0x0000000180AF5E60-0x0000000180AF5E70
	[CompilerGenerated]
	internal static Vector3 _RefreshGeometry_g__Corner_24_0(float x, float y, ref __c__DisplayClass24_0 param_000030ec); // 0x0000000180AF5F70-0x0000000180AF5FF0
}

