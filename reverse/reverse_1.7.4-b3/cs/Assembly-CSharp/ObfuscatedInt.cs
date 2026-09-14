/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[Serializable]
public struct ObfuscatedInt // TypeDefIndex: 1198
{
	// Fields
	[SerializeField]
	private int _stored; // 0x00
	[SerializeField]
	private int _keyA; // 0x04
	[SerializeField]
	private int _keyB; // 0x08
	[SerializeField]
	private int _noise; // 0x0C
	private static readonly System.Random _rng; // 0x00

	// Properties
	public int Value { get; } // 0x00000001806D0170-0x00000001806D01F0 

	// Constructors
	public ObfuscatedInt(int value); // 0x00000001806D0040-0x00000001806D0170
	static ObfuscatedInt(); // 0x00000001806D0600-0x00000001806D0710

	// Methods
	private static int RotateLeft(int v, int n); // 0x00000001806D01F0-0x00000001806D0210
	private static int RotateRight(int v, int n); // 0x00000001806D0210-0x00000001806D0230
	public static implicit operator int(ObfuscatedInt o); // 0x00000001806D0230-0x00000001806D0290
	public static implicit operator ObfuscatedInt(int v); // 0x00000001806D0290-0x00000001806D03D0
	public override string ToString(); // 0x00000001806D03D0-0x00000001806D0480
	public override int GetHashCode(); // 0x00000001806D0480-0x00000001806D04D0
	public override bool Equals(object obj); // 0x00000001806D04D0-0x00000001806D0600
}

