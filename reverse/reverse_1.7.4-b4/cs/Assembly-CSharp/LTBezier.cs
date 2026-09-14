/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class LTBezier // TypeDefIndex: 325
{
	// Fields
	public float length; // 0x10
	private Vector3 a; // 0x14
	private Vector3 aa; // 0x20
	private Vector3 bb; // 0x2C
	private Vector3 cc; // 0x38
	private float len; // 0x44
	private float[] arcLengths; // 0x48

	// Constructors
	public LTBezier(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float precision); // 0x00000001802F5FE0-0x00000001802F64A0

	// Methods
	private float map(float u); // 0x00000001802F64A0-0x00000001802F65C0
	private Vector3 bezierPoint(float t); // 0x00000001802F65C0-0x00000001802F6670
	public Vector3 point(float t); // 0x00000001802F6670-0x00000001802F6860
}

