/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[Serializable]
public class LTSpline // TypeDefIndex: 304
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
	public LTSpline(Vector3[] pts); // 0x00000001806CDB80-0x00000001806CDBC0
	public LTSpline(Vector3[] pts, bool constantSpeed); // 0x00000001806CDBC0-0x00000001806CDC10
	static LTSpline(); // 0x00000001806CDB30-0x00000001806CDB80

	// Methods
	private void init(Vector3[] pts, bool constantSpeed); // 0x00000001806CE480-0x00000001806CE970
	public Vector3 map(float u); // 0x00000001806CEE00-0x00000001806CEF70
	public Vector3 interp(float t); // 0x00000001806CE970-0x00000001806CEE00
	public float ratioAtPoint(Vector3 pt); // 0x00000001806CF8B0-0x00000001806CFA30
	public Vector3 point(float ratio); // 0x00000001806CF700-0x00000001806CF8B0
	public void place2d(Transform transform, float ratio); // 0x00000001806CEF70-0x00000001806CF090
	public void placeLocal2d(Transform transform, float ratio); // 0x00000001806CF090-0x00000001806CF2E0
	public void place(Transform transform, float ratio); // 0x00000001806CF610-0x00000001806CF700
	public void place(Transform transform, float ratio, Vector3 worldUp); // 0x00000001806CF530-0x00000001806CF610
	public void placeLocal(Transform transform, float ratio); // 0x00000001806CF2E0-0x00000001806CF410
	public void placeLocal(Transform transform, float ratio, Vector3 worldUp); // 0x00000001806CF410-0x00000001806CF530
	public void gizmoDraw(float t = -1f /* Metadata: 0x0064C1DC */); // 0x00000001806CE3B0-0x00000001806CE480
	public void drawGizmo(Color color); // 0x00000001806CDC10-0x00000001806CDD40
	public static void drawGizmo(Transform[] arr, Color color); // 0x00000001806CDD40-0x00000001806CDF70
	public static void drawLine(Transform[] arr, float width, Color color); // 0x00000001806CDF70-0x00000001806CDF90
	public void drawLinesGLLines(Material outlineMaterial, Color color, float width); // 0x00000001806CDF90-0x00000001806CE1A0
	public Vector3[] generateVectors(); // 0x00000001806CE1A0-0x00000001806CE3B0
}

