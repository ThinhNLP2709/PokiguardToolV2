/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[Serializable]
public class LTSpline // TypeDefIndex: 330
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
	public LTSpline(Vector3[] pts); // 0x000000018031A9F0-0x000000018031AA30
	public LTSpline(Vector3[] pts, bool constantSpeed); // 0x000000018031AA30-0x000000018031AA80
	static LTSpline(); // 0x000000018031A9A0-0x000000018031A9F0

	// Methods
	private void init(Vector3[] pts, bool constantSpeed); // 0x000000018031B2F0-0x000000018031B7E0
	public Vector3 map(float u); // 0x000000018031BC70-0x000000018031BDE0
	public Vector3 interp(float t); // 0x000000018031B7E0-0x000000018031BC70
	public float ratioAtPoint(Vector3 pt); // 0x000000018031C720-0x000000018031C8A0
	public Vector3 point(float ratio); // 0x000000018031C570-0x000000018031C720
	public void place2d(Transform transform, float ratio); // 0x000000018031BDE0-0x000000018031BF00
	public void placeLocal2d(Transform transform, float ratio); // 0x000000018031BF00-0x000000018031C150
	public void place(Transform transform, float ratio); // 0x000000018031C480-0x000000018031C570
	public void place(Transform transform, float ratio, Vector3 worldUp); // 0x000000018031C3A0-0x000000018031C480
	public void placeLocal(Transform transform, float ratio); // 0x000000018031C150-0x000000018031C280
	public void placeLocal(Transform transform, float ratio, Vector3 worldUp); // 0x000000018031C280-0x000000018031C3A0
	public void gizmoDraw(float t = -1f /* Metadata: 0x0068AEF4 */); // 0x000000018031B220-0x000000018031B2F0
	public void drawGizmo(Color color); // 0x000000018031AA80-0x000000018031ABB0
	public static void drawGizmo(Transform[] arr, Color color); // 0x000000018031ABB0-0x000000018031ADE0
	public static void drawLine(Transform[] arr, float width, Color color); // 0x000000018031ADE0-0x000000018031AE00
	public void drawLinesGLLines(Material outlineMaterial, Color color, float width); // 0x000000018031AE00-0x000000018031B010
	public Vector3[] generateVectors(); // 0x000000018031B010-0x000000018031B220
}

