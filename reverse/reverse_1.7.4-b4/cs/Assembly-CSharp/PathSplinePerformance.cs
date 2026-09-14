/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class PathSplinePerformance : MonoBehaviour // TypeDefIndex: 293
{
	// Fields
	public GameObject trackTrailRenderers; // 0x20
	public GameObject car; // 0x28
	public GameObject carInternal; // 0x30
	public float circleLength; // 0x38
	public float randomRange; // 0x3C
	public int trackNodes; // 0x40
	public float carSpeed; // 0x44
	public float tracerSpeed; // 0x48
	private LTSpline track; // 0x50
	private int trackIter; // 0x58
	private float carAdd; // 0x5C
	private float trackPosition; // 0x60

	// Constructors
	public PathSplinePerformance(); // 0x0000000180D8BBB0-0x0000000180D8BC20

	// Methods
	private void Start(); // 0x0000000180D8AF20-0x0000000180D8B550
	private void Update(); // 0x0000000180D8B550-0x0000000180D8B750
	private void OnDrawGizmos(); // 0x0000000180D8B750-0x0000000180D8B780
	private void playSwish(); // 0x0000000180D8B780-0x0000000180D8BBB0
}

