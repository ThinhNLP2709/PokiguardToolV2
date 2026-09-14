/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

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
	public void reset(); // 0x00000001802D98E0-0x00000001802D9990
	public void init(uint id, uint global_counter); // 0x00000001802D9990-0x00000001802D9A20
	private LTSeq addOn(); // 0x00000001802D9A20-0x00000001802D9B70
	private float addPreviousDelays(); // 0x00000001802D9B70-0x00000001802D9BC0
	public LTSeq append(float delay); // 0x00000001802D9BC0-0x00000001802D9BF0
	public LTSeq append(Action callback); // 0x00000001802D9BF0-0x00000001802D9C60
	public LTSeq append(Action<object> callback, object obj); // 0x00000001802D9C60-0x00000001802D9D00
	public LTSeq append(LTDescr tween); // 0x00000001802D9D00-0x00000001802D9DC0
	public LTSeq insert(LTDescr tween); // 0x00000001802D9DC0-0x00000001802D9E80
	public LTSeq setScale(float timeScale); // 0x00000001802D9E80-0x00000001802D9F30
	private void setScaleRecursive(LTSeq seq, float timeScale, int count); // 0x00000001802D9F30-0x00000001802D9FC0
}

