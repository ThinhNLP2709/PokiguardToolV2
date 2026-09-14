/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[RequireComponent(typeof(TextMesh))]
public class MultiplierTextSparkleEffect : MonoBehaviour // TypeDefIndex: 2367
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
	[CompilerGenerated]
	private float _ExternalScale_k__BackingField; // 0x9C
	private const float SparkleHz = 20f; // Metadata: 0x005F1F72
	private float _nextSparkleAt; // 0xA0

	// Properties
	public float ExternalScale { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180B557B0-0x0000000180B557C0 0x0000000180B557C0-0x0000000180B557D0

	// Constructors
	public MultiplierTextSparkleEffect(); // 0x0000000180B56DA0-0x0000000180B56DF0

	// Methods
	private static bool TryHex(string hex, out Color c); // 0x0000000180B557D0-0x0000000180B557E0
	public void Setup(int multiplier, TextMesh outlineMesh, Transform outlineTransform); // 0x0000000180B557E0-0x0000000180B56020
	private void ApplyTierColors(); // 0x0000000180B56020-0x0000000180B56480
	private void Update(); // 0x0000000180B56480-0x0000000180B56670
	private void ApplyTwinkle(float t, float colorHz, float scaleHz, float mainScaleAmp, float outlineScaleAmp); // 0x0000000180B56670-0x0000000180B56DA0
}

