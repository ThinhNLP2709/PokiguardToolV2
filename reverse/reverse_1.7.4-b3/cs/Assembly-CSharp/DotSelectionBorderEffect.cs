/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class DotSelectionBorderEffect : MonoBehaviour // TypeDefIndex: 2294
{
	// Fields
	private const string FRAME_PATH = "Image/Poky/DotFramePoky"; // Metadata: 0x005F0A7E
	private const float FRAME_PAD = 1.18f; // Metadata: 0x005F0A96
	private const float PULSE_HZ = 1.6f; // Metadata: 0x005F0A9A
	private const float PULSE_SCALE = 1.03f; // Metadata: 0x005F0A9E
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
	private static Material SharedLineMaterial { get; } // 0x0000000180AE4E30-0x0000000180AE51D0 
	private static Sprite FrameSprite { get; } // 0x0000000180AE51D0-0x0000000180AE5430 

	// Nested types
	[CompilerGenerated]
	private struct __c__DisplayClass24_0 // TypeDefIndex: 2295
	{
		// Fields
		public Vector3 ctr; // 0x00
		public float z; // 0x0C
	}

	// Constructors
	public DotSelectionBorderEffect(); // 0x0000000180AE8C00-0x0000000180AE8D00

	// Methods
	public static void Prewarm(); // 0x0000000180AE5430-0x0000000180AE5450
	public static void StartOn(Dot dot); // 0x0000000180AE5450-0x0000000180AE5590
	public static void StopOn(GameObject dotRoot); // 0x0000000180AE5590-0x0000000180AE5730
	private void Build(Dot dot); // 0x0000000180AE5730-0x0000000180AE5E00
	private void BuildFrame(Sprite frame); // 0x0000000180AE5E00-0x0000000180AE64E0
	private void FitFrame(); // 0x0000000180AE64E0-0x0000000180AE69F0
	private LineRenderer CreateEdge(int index); // 0x0000000180AE69F0-0x0000000180AE7240
	private void RefreshGeometry(); // 0x0000000180AE7240-0x0000000180AE7D30
	private void LateUpdate(); // 0x0000000180AE7D30-0x0000000180AE7F80
	private void AnimateFrame(); // 0x0000000180AE7F80-0x0000000180AE8400
	private void AnimateFallbackEdges(); // 0x0000000180AE8400-0x0000000180AE8910
	private void Teardown(); // 0x0000000180AE8910-0x0000000180AE8BF0
	private void OnDestroy(); // 0x0000000180AE8BF0-0x0000000180AE8C00
	[CompilerGenerated]
	internal static Vector3 _RefreshGeometry_g__Corner_24_0(float x, float y, ref __c__DisplayClass24_0 param_000030aa); // 0x0000000180AE8D00-0x0000000180AE8D80
}

