/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class LTBezierPath // TypeDefIndex: 303
{
	// Fields
	public Vector3[] pts; // 0x10
	public float length; // 0x18
	public bool orientToPath; // 0x1C
	public bool orientToPath2d; // 0x1D
	private LTBezier[] beziers; // 0x20
	private float[] lengthRatio; // 0x28
	private int currentBezier; // 0x30
	private int previousBezier; // 0x34

	// Properties
	public float distance { get; } // 0x00000001806CB0A0-0x00000001806CB0B0 

	// Constructors
	public LTBezierPath(); // 0x00000001802E5CB0-0x00000001802E5CC0
	public LTBezierPath(Vector3[] pts_); // 0x00000001806CB070-0x00000001806CB0A0

	// Methods
	public void setPoints(Vector3[] pts_); // 0x00000001806CBC60-0x00000001806CC0E0
	public Vector3 point(float ratio); // 0x00000001806CB8D0-0x00000001806CB9D0
	public void place2d(Transform transform, float ratio); // 0x00000001806CB1D0-0x00000001806CB2F0
	public void placeLocal2d(Transform transform, float ratio); // 0x00000001806CB2F0-0x00000001806CB410
	public void place(Transform transform, float ratio); // 0x00000001806CB700-0x00000001806CB7F0
	public void place(Transform transform, float ratio, Vector3 worldUp); // 0x00000001806CB7F0-0x00000001806CB8D0
	public void placeLocal(Transform transform, float ratio); // 0x00000001806CB580-0x00000001806CB700
	public void placeLocal(Transform transform, float ratio, Vector3 worldUp); // 0x00000001806CB410-0x00000001806CB580
	public void gizmoDraw(float t = -1f /* Metadata: 0x0064C1D4 */); // 0x00000001806CB0B0-0x00000001806CB1D0
	public float ratioAtPoint(Vector3 pt, float precision = 0.01f /* Metadata: 0x0064C1D8 */); // 0x00000001806CB9D0-0x00000001806CBC60
}

