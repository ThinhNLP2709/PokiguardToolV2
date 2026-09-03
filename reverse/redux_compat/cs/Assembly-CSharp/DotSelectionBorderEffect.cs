/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class DotSelectionBorderEffect : MonoBehaviour // TypeDefIndex: 1655
{
	// Fields
	private static Material s_sharedLineMat; // 0x00
	private LineRenderer[] _edges; // 0x20
	private GameObject _fxRoot; // 0x28
	private SpriteRenderer _spriteRenderer; // 0x30

	// Properties
	private static Material SharedLineMaterial { get; } // 0x00000001805C3BC0-0x00000001805C3D90 

	// Nested types
	[CompilerGenerated]
	private struct __c__DisplayClass10_0 // TypeDefIndex: 1656
	{
		// Fields
		public Vector3 ctr; // 0x00
		public float z; // 0x0C
	}

	// Constructors
	public DotSelectionBorderEffect(); // 0x00000001805C3B60-0x00000001805C3BC0

	// Methods
	public static void StartOn(Dot dot); // 0x00000001805C38B0-0x00000001805C3970
	public static void StopOn(GameObject dotRoot); // 0x00000001805C3970-0x00000001805C3A20
	private void Build(Dot dot); // 0x00000001805C28A0-0x00000001805C2B50
	private LineRenderer CreateEdge(int index); // 0x00000001805C2B50-0x00000001805C2F50
	private void RefreshGeometry(); // 0x00000001805C3350-0x00000001805C38B0
	private void LateUpdate(); // 0x00000001805C2F50-0x00000001805C3340
	private void Teardown(); // 0x00000001805C3A20-0x00000001805C3AE0
	private void OnDestroy(); // 0x00000001805C3340-0x00000001805C3350
	[CompilerGenerated]
	internal static Vector3 _RefreshGeometry_g__Corner_10_0(float x, float y, ref __c__DisplayClass10_0 param_00001dd1); // 0x00000001805C3AE0-0x00000001805C3B60
}

