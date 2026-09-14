/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class PathSplineTrack : MonoBehaviour // TypeDefIndex: 294
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
	public PathSplineTrack(); // 0x0000000180D8C900-0x0000000180D8C950

	// Methods
	private void Start(); // 0x0000000180D8BC20-0x0000000180D8C230
	private void Update(); // 0x0000000180D8C230-0x0000000180D8C450
	private void OnDrawGizmos(); // 0x0000000180D8C450-0x0000000180D8C4D0
	private void playSwish(); // 0x0000000180D8C4D0-0x0000000180D8C900
}

