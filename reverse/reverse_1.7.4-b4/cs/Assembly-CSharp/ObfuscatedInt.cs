/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[Serializable]
public struct ObfuscatedInt // TypeDefIndex: 1200
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
	public int Value { get; } // 0x00000001806D1D90-0x00000001806D1E10 

	// Constructors
	public ObfuscatedInt(int value); // 0x00000001806D1C60-0x00000001806D1D90
	static ObfuscatedInt(); // 0x00000001806D2220-0x00000001806D2330

	// Methods
	private static int RotateLeft(int v, int n); // 0x00000001806D1E10-0x00000001806D1E30
	private static int RotateRight(int v, int n); // 0x00000001806D1E30-0x00000001806D1E50
	public static implicit operator int(ObfuscatedInt o); // 0x00000001806D1E50-0x00000001806D1EB0
	public static implicit operator ObfuscatedInt(int v); // 0x00000001806D1EB0-0x00000001806D1FF0
	public override string ToString(); // 0x00000001806D1FF0-0x00000001806D20A0
	public override int GetHashCode(); // 0x00000001806D20A0-0x00000001806D20F0
	public override bool Equals(object obj); // 0x00000001806D20F0-0x00000001806D2220
}

