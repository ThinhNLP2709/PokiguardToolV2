/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[Serializable]
public struct ObfuscatedInt // TypeDefIndex: 940
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
	public int Value { get; set; } // 0x00000001804D4770-0x00000001804D47F0 0x00000001804D4970-0x00000001804D4AA0

	// Constructors
	public ObfuscatedInt(int value); // 0x00000001804D4640-0x00000001804D4770
	static ObfuscatedInt(); // 0x00000001804D45C0-0x00000001804D4640

	// Methods
	private static int RotateLeft(int v, int n); // 0x00000001804D4510-0x00000001804D4530
	private static int RotateRight(int v, int n); // 0x00000001804D4530-0x00000001804D4550
	public static implicit operator int(ObfuscatedInt o); // 0x00000001804D4920-0x00000001804D4970
	public static implicit operator ObfuscatedInt(int v); // 0x00000001804D47F0-0x00000001804D4920
	public override string ToString(); // 0x00000001804D4550-0x00000001804D45C0
	public override int GetHashCode(); // 0x00000001804D44A0-0x00000001804D4510
	public override bool Equals(object obj); // 0x00000001804D4370-0x00000001804D44A0
}

