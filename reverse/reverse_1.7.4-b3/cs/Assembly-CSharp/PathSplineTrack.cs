/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

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
	public PathSplineTrack(); // 0x0000000180D7EB20-0x0000000180D7EB70

	// Methods
	private void Start(); // 0x0000000180D7DE40-0x0000000180D7E450
	private void Update(); // 0x0000000180D7E450-0x0000000180D7E670
	private void OnDrawGizmos(); // 0x0000000180D7E670-0x0000000180D7E6F0
	private void playSwish(); // 0x0000000180D7E6F0-0x0000000180D7EB20
}

