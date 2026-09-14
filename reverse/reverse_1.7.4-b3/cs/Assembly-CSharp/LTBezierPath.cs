/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class LTBezierPath // TypeDefIndex: 326
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
	public float distance { get; } // 0x00000001802F6E00-0x00000001802F6E10 

	// Constructors
	public LTBezierPath(); // 0x000000018028A320-0x000000018028A330
	public LTBezierPath(Vector3[] pts_); // 0x00000001802F6830-0x00000001802F6840

	// Methods
	public void setPoints(Vector3[] pts_); // 0x00000001802F6840-0x00000001802F6E00
	public Vector3 point(float ratio); // 0x00000001802F6E10-0x00000001802F6F10
	public void place2d(Transform transform, float ratio); // 0x00000001802F6F10-0x00000001802F70D0
	public void placeLocal2d(Transform transform, float ratio); // 0x00000001802F70D0-0x00000001802F7290
	public void place(Transform transform, float ratio); // 0x00000001802F7290-0x00000001802F7430
	public void place(Transform transform, float ratio, Vector3 worldUp); // 0x00000001802F7430-0x00000001802F75B0
	public void placeLocal(Transform transform, float ratio); // 0x00000001802F75B0-0x00000001802F75F0
	public void placeLocal(Transform transform, float ratio, Vector3 worldUp); // 0x00000001802F75F0-0x00000001802F7860
	public void gizmoDraw(float t = -1f /* Metadata: 0x005EDB0C */); // 0x00000001802F7860-0x00000001802F7A10
	public float ratioAtPoint(Vector3 pt, float precision = 0.01f /* Metadata: 0x005EDB10 */); // 0x00000001802F7A10-0x00000001802F7C00
}

