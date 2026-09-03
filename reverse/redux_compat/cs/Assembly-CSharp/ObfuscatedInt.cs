/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[Serializable]
public struct ObfuscatedInt // TypeDefIndex: 750
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
	public int Value { get; set; } // 0x00000001803FB120-0x00000001803FB1A0 0x00000001803FB320-0x00000001803FB450

	// Constructors
	public ObfuscatedInt(int value); // 0x00000001803FAFF0-0x00000001803FB120
	static ObfuscatedInt(); // 0x00000001803FAF70-0x00000001803FAFF0

	// Methods
	private static int RotateLeft(int v, int n); // 0x00000001803FAEC0-0x00000001803FAEE0
	private static int RotateRight(int v, int n); // 0x00000001803FAEE0-0x00000001803FAF00
	public static implicit operator int(ObfuscatedInt o); // 0x00000001803FB2D0-0x00000001803FB320
	public static implicit operator ObfuscatedInt(int v); // 0x00000001803FB1A0-0x00000001803FB2D0
	public override string ToString(); // 0x00000001803FAF00-0x00000001803FAF70
	public override int GetHashCode(); // 0x00000001803FAE50-0x00000001803FAEC0
	public override bool Equals(object obj); // 0x00000001803FAD20-0x00000001803FAE50
}

