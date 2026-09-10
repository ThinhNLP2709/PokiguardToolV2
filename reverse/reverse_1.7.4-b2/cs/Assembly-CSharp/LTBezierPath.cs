/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class LTBezierPath // TypeDefIndex: 329
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
	public float distance { get; } // 0x0000000180317E00-0x0000000180317E10 

	// Constructors
	public LTBezierPath(); // 0x00000001802E9CB0-0x00000001802E9CC0
	public LTBezierPath(Vector3[] pts_); // 0x0000000180317DD0-0x0000000180317E00

	// Methods
	public void setPoints(Vector3[] pts_); // 0x00000001803189C0-0x0000000180318E40
	public Vector3 point(float ratio); // 0x0000000180318630-0x0000000180318730
	public void place2d(Transform transform, float ratio); // 0x0000000180317F30-0x0000000180318050
	public void placeLocal2d(Transform transform, float ratio); // 0x0000000180318050-0x0000000180318170
	public void place(Transform transform, float ratio); // 0x0000000180318460-0x0000000180318550
	public void place(Transform transform, float ratio, Vector3 worldUp); // 0x0000000180318550-0x0000000180318630
	public void placeLocal(Transform transform, float ratio); // 0x00000001803182E0-0x0000000180318460
	public void placeLocal(Transform transform, float ratio, Vector3 worldUp); // 0x0000000180318170-0x00000001803182E0
	public void gizmoDraw(float t = -1f /* Metadata: 0x0068AEEC */); // 0x0000000180317E10-0x0000000180317F30
	public float ratioAtPoint(Vector3 pt, float precision = 0.01f /* Metadata: 0x0068AEF0 */); // 0x0000000180318730-0x00000001803189C0
}

