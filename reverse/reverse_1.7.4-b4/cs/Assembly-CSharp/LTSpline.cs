/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

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
	public LTSpline(Vector3[] pts); // 0x00000001802F7C30-0x00000001802F7C40
	static LTSpline(); // 0x00000001802F9CD0-0x00000001802F9D30

	// Methods
	private void init(Vector3[] pts, bool constantSpeed); // 0x00000001802F7C40-0x00000001802F82B0
	public Vector3 map(float u); // 0x00000001802F82B0-0x00000001802F8420
	public Vector3 interp(float t); // 0x00000001802F8420-0x00000001802F8890
	public float ratioAtPoint(Vector3 pt); // 0x00000001802F8890-0x00000001802F8A10
	public Vector3 point(float ratio); // 0x00000001802F8A10-0x00000001802F8BC0
	public void place2d(Transform transform, float ratio); // 0x00000001802F8BC0-0x00000001802F8D80
	public void placeLocal2d(Transform transform, float ratio); // 0x00000001802F8D80-0x00000001802F9030
	public void place(Transform transform, float ratio); // 0x00000001802F9030-0x00000001802F91D0
	public void place(Transform transform, float ratio, Vector3 worldUp); // 0x00000001802F91D0-0x00000001802F9350
	public void placeLocal(Transform transform, float ratio); // 0x00000001802F9350-0x00000001802F9390
	public void placeLocal(Transform transform, float ratio, Vector3 worldUp); // 0x00000001802F9390-0x00000001802F95C0
	public void gizmoDraw(float t = -1f /* Metadata: 0x005EEEE4 */); // 0x00000001802F95C0-0x00000001802F96D0
	public void drawGizmo(Color color); // 0x00000001802F96D0-0x00000001802F9910
	public static void drawGizmo(Transform[] arr, Color color); // 0x00000001802F9910-0x00000001802F9CD0
}

