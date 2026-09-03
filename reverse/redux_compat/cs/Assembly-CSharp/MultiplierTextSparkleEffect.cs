/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[RequireComponent(typeof(TextMesh))]
public class MultiplierTextSparkleEffect : MonoBehaviour // TypeDefIndex: 1697
{
	// Fields
	private TextMesh _main; // 0x20
	private TextMesh _outline; // 0x28
	private Transform _mainTr; // 0x30
	private Transform _outlineTr; // 0x38
	private Vector3 _baseMainScale; // 0x40
	private Vector3 _baseOutlineScale; // 0x4C
	private Color _mainA; // 0x58
	private Color _mainB; // 0x68
	private Color _outlineA; // 0x78
	private Color _outlineB; // 0x88
	private int _tier; // 0x98

	// Constructors
	public MultiplierTextSparkleEffect(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	private static bool TryHex(string hex, out Color c); // 0x00000001805E0D70-0x00000001805E0D80
	public void Setup(int multiplier, TextMesh outlineMesh, Transform outlineTransform); // 0x00000001805E0A60-0x00000001805E0D70
	private void ApplyTierColors(); // 0x00000001805E0360-0x00000001805E0650
	private void Update(); // 0x00000001805E0D80-0x00000001805E0EA0
	private void ApplyTwinkle(float t, float colorHz, float scaleHz, float mainScaleAmp, float outlineScaleAmp); // 0x00000001805E0650-0x00000001805E0A60
}

