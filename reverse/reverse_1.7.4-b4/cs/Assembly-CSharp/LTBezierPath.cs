/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

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
	public float distance { get; } // 0x00000001802F6E30-0x00000001802F6E40 

	// Constructors
	public LTBezierPath(); // 0x000000018028A320-0x000000018028A330
	public LTBezierPath(Vector3[] pts_); // 0x00000001802F6860-0x00000001802F6870

	// Methods
	public void setPoints(Vector3[] pts_); // 0x00000001802F6870-0x00000001802F6E30
	public Vector3 point(float ratio); // 0x00000001802F6E40-0x00000001802F6F40
	public void place2d(Transform transform, float ratio); // 0x00000001802F6F40-0x00000001802F7100
	public void placeLocal2d(Transform transform, float ratio); // 0x00000001802F7100-0x00000001802F72C0
	public void place(Transform transform, float ratio); // 0x00000001802F72C0-0x00000001802F7460
	public void place(Transform transform, float ratio, Vector3 worldUp); // 0x00000001802F7460-0x00000001802F75E0
	public void placeLocal(Transform transform, float ratio); // 0x00000001802F75E0-0x00000001802F7620
	public void placeLocal(Transform transform, float ratio, Vector3 worldUp); // 0x00000001802F7620-0x00000001802F7890
	public void gizmoDraw(float t = -1f /* Metadata: 0x005EEEDC */); // 0x00000001802F7890-0x00000001802F7A40
	public float ratioAtPoint(Vector3 pt, float precision = 0.01f /* Metadata: 0x005EEEE0 */); // 0x00000001802F7A40-0x00000001802F7C30
}

