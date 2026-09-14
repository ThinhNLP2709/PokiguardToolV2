/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class PathSplineEndless : MonoBehaviour // TypeDefIndex: 292
{
	// Fields
	public GameObject trackTrailRenderers; // 0x20
	public GameObject car; // 0x28
	public GameObject carInternal; // 0x30
	public GameObject[] cubes; // 0x38
	private int cubesIter; // 0x40
	public GameObject[] trees; // 0x48
	private int treesIter; // 0x50
	public float randomIterWidth; // 0x54
	private LTSpline track; // 0x58
	private List<Vector3> trackPts; // 0x60
	private int zIter; // 0x68
	private float carIter; // 0x6C
	private float carAdd; // 0x70
	private int trackMaxItems; // 0x74
	private int trackIter; // 0x78
	private float pushTrackAhead; // 0x7C
	private float randomIter; // 0x80

	// Constructors
	public PathSplineEndless(); // 0x0000000180D7D030-0x0000000180D7D140

	// Methods
	private void Start(); // 0x0000000180D7BD90-0x0000000180D7BF90
	private void Update(); // 0x0000000180D7BF90-0x0000000180D7C2E0
	private GameObject objectQueue(GameObject[] arr, ref int lastIter); // 0x0000000180D7C2E0-0x0000000180D7C4A0
	private void addRandomTrackPoint(); // 0x0000000180D7C4A0-0x0000000180D7C8E0
	private void refreshSpline(); // 0x0000000180D7C8E0-0x0000000180D7CC00
	private void playSwish(); // 0x0000000180D7CC00-0x0000000180D7D030
	[CompilerGenerated]
	private void _Start_b__17_0(float val); // 0x0000000180C04AF0-0x0000000180C04B00
}

