/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[Serializable]
public class LTSpline // TypeDefIndex: 327
{
	// Fields
	public static int DISTANCE_COUNT; // 0x00
	public static int SUBLINE_COUNT; // 0x04
	public float distance; // 0x10
	public bool constantSpeed; // 0x14
	public Vector3[] pts; // 0x18
	[NonSerialized]
	public Vector3[] ptsAdj; // 0x20
	public int ptsAdjLength; // 0x28
	public bool orientToPath; // 0x2C
	public bool orientToPath2d; // 0x2D
	private int numSections; // 0x30
	private int currPt; // 0x34

	// Constructors
	public LTSpline(Vector3[] pts); // 0x00000001802F7C00-0x00000001802F7C10
	static LTSpline(); // 0x00000001802F9CA0-0x00000001802F9D00

	// Methods
	private void init(Vector3[] pts, bool constantSpeed); // 0x00000001802F7C10-0x00000001802F8280
	public Vector3 map(float u); // 0x00000001802F8280-0x00000001802F83F0
	public Vector3 interp(float t); // 0x00000001802F83F0-0x00000001802F8860
	public float ratioAtPoint(Vector3 pt); // 0x00000001802F8860-0x00000001802F89E0
	public Vector3 point(float ratio); // 0x00000001802F89E0-0x00000001802F8B90
	public void place2d(Transform transform, float ratio); // 0x00000001802F8B90-0x00000001802F8D50
	public void placeLocal2d(Transform transform, float ratio); // 0x00000001802F8D50-0x00000001802F9000
	public void place(Transform transform, float ratio); // 0x00000001802F9000-0x00000001802F91A0
	public void place(Transform transform, float ratio, Vector3 worldUp); // 0x00000001802F91A0-0x00000001802F9320
	public void placeLocal(Transform transform, float ratio); // 0x00000001802F9320-0x00000001802F9360
	public void placeLocal(Transform transform, float ratio, Vector3 worldUp); // 0x00000001802F9360-0x00000001802F9590
	public void gizmoDraw(float t = -1f /* Metadata: 0x005EDB14 */); // 0x00000001802F9590-0x00000001802F96A0
	public void drawGizmo(Color color); // 0x00000001802F96A0-0x00000001802F98E0
	public static void drawGizmo(Transform[] arr, Color color); // 0x00000001802F98E0-0x00000001802F9CA0
}

