/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[RequireComponent(typeof(TextMesh))]
public class MultiplierTextSparkleEffect : MonoBehaviour // TypeDefIndex: 1975
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
	private const float SparkleHz = 20f; // Metadata: 0x0068DDDF
	private float _nextSparkleAt; // 0x9C

	// Constructors
	public MultiplierTextSparkleEffect(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	private static bool TryHex(string hex, out Color c); // 0x000000018070B7C0-0x000000018070B7D0
	public void Setup(int multiplier, TextMesh outlineMesh, Transform outlineTransform); // 0x000000018070B4B0-0x000000018070B7C0
	private void ApplyTierColors(); // 0x000000018070ADB0-0x000000018070B0A0
	private void Update(); // 0x000000018070B7D0-0x000000018070B910
	private void ApplyTwinkle(float t, float colorHz, float scaleHz, float mainScaleAmp, float outlineScaleAmp); // 0x000000018070B0A0-0x000000018070B4B0
}

