/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class LTSeq // TypeDefIndex: 307
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

	// Constructors
	public LTSeq(); // 0x000000018028A320-0x000000018028A330

	// Methods
	public void reset(); // 0x00000001802D98B0-0x00000001802D9960
	public void init(uint id, uint global_counter); // 0x00000001802D9960-0x00000001802D99F0
	private LTSeq addOn(); // 0x00000001802D99F0-0x00000001802D9B40
	private float addPreviousDelays(); // 0x00000001802D9B40-0x00000001802D9B90
	public LTSeq append(float delay); // 0x00000001802D9B90-0x00000001802D9BC0
	public LTSeq append(Action callback); // 0x00000001802D9BC0-0x00000001802D9C30
	public LTSeq append(Action<object> callback, object obj); // 0x00000001802D9C30-0x00000001802D9CD0
	public LTSeq append(LTDescr tween); // 0x00000001802D9CD0-0x00000001802D9D90
	public LTSeq insert(LTDescr tween); // 0x00000001802D9D90-0x00000001802D9E50
	public LTSeq setScale(float timeScale); // 0x00000001802D9E50-0x00000001802D9F00
	private void setScaleRecursive(LTSeq seq, float timeScale, int count); // 0x00000001802D9F00-0x00000001802D9F90
}

