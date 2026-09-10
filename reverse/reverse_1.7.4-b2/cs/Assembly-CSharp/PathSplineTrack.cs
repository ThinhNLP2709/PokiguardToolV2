/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class PathSplineTrack : MonoBehaviour // TypeDefIndex: 295
{
	// Fields
	public GameObject car; // 0x20
	public GameObject carInternal; // 0x28
	public GameObject trackTrailRenderers; // 0x30
	public Transform[] trackOnePoints; // 0x38
	private LTSpline track; // 0x40
	private int trackIter; // 0x48
	private float trackPosition; // 0x4C

	// Constructors
	public PathSplineTrack(); // 0x000000018086E790-0x000000018086E7A0

	// Methods
	private void Start(); // 0x000000018086E2D0-0x000000018086E600
	private void Update(); // 0x000000018086E600-0x000000018086E790
	private void OnDrawGizmos(); // 0x000000018086E260-0x000000018086E2D0
	private void playSwish(); // 0x000000018086E7A0-0x000000018086EBE0
}

