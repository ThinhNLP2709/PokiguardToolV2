/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class LTSeq // TypeDefIndex: 310
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
	public int id { get; } // 0x000000018031A6A0-0x000000018031A6B0 

	// Constructors
	public LTSeq(); // 0x00000001802E9CB0-0x00000001802E9CC0

	// Methods
	public void reset(); // 0x000000018031A7B0-0x000000018031A7F0
	public void init(uint id, uint global_counter); // 0x000000018031A6B0-0x000000018031A720
	private LTSeq addOn(); // 0x0000000180319D00-0x0000000180319DD0
	private float addPreviousDelays(); // 0x0000000180319DD0-0x0000000180319E20
	public LTSeq append(float delay); // 0x000000018031A080-0x000000018031A0B0
	public LTSeq append(Action callback); // 0x000000018031A0B0-0x000000018031A240
	public LTSeq append(Action<object> callback, object obj); // 0x0000000180319EB0-0x000000018031A080
	public LTSeq append(GameObject gameObject, Action callback); // 0x000000018031A240-0x000000018031A4D0
	public LTSeq append(GameObject gameObject, Action<object> callback, object obj); // 0x000000018031A4D0-0x000000018031A6A0
	public LTSeq append(LTDescr tween); // 0x0000000180319E20-0x0000000180319EB0
	public LTSeq insert(LTDescr tween); // 0x000000018031A720-0x000000018031A7B0
	public LTSeq setScale(float timeScale); // 0x000000018031A8D0-0x000000018031A9A0
	private void setScaleRecursive(LTSeq seq, float timeScale, int count); // 0x000000018031A800-0x000000018031A8D0
	public LTSeq reverse(); // 0x000000018031A7F0-0x000000018031A800
}

