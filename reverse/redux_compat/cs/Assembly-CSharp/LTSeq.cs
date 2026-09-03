/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class LTSeq // TypeDefIndex: 284
{
	// Fields
	public LTSeq previous; // 0x10
	public LTSeq current; // 0x18
	public LTDescr tween; // 0x20
	public float totalDelay; // 0x28
	public float timeScale; // 0x2C
	private int debugIter; // 0x30
	public uint counter; // 0x34
	public bool toggle; // 0x38
	private uint _id; // 0x3C

	// Properties
	public int id { get; } // 0x00000001806CD830-0x00000001806CD840 

	// Constructors
	public LTSeq(); // 0x00000001802E5CB0-0x00000001802E5CC0

	// Methods
	public void reset(); // 0x00000001806CD940-0x00000001806CD980
	public void init(uint id, uint global_counter); // 0x00000001806CD840-0x00000001806CD8B0
	private LTSeq addOn(); // 0x00000001806CCE90-0x00000001806CCF60
	private float addPreviousDelays(); // 0x00000001806CCF60-0x00000001806CCFB0
	public LTSeq append(float delay); // 0x00000001806CD210-0x00000001806CD240
	public LTSeq append(Action callback); // 0x00000001806CD240-0x00000001806CD3D0
	public LTSeq append(Action<object> callback, object obj); // 0x00000001806CD040-0x00000001806CD210
	public LTSeq append(GameObject gameObject, Action callback); // 0x00000001806CD3D0-0x00000001806CD660
	public LTSeq append(GameObject gameObject, Action<object> callback, object obj); // 0x00000001806CD660-0x00000001806CD830
	public LTSeq append(LTDescr tween); // 0x00000001806CCFB0-0x00000001806CD040
	public LTSeq insert(LTDescr tween); // 0x00000001806CD8B0-0x00000001806CD940
	public LTSeq setScale(float timeScale); // 0x00000001806CDA60-0x00000001806CDB30
	private void setScaleRecursive(LTSeq seq, float timeScale, int count); // 0x00000001806CD990-0x00000001806CDA60
	public LTSeq reverse(); // 0x00000001806CD980-0x00000001806CD990
}

