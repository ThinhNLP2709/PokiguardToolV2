/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class PetAnimKeys // TypeDefIndex: 2366
{
	// Fields
	private static readonly Entry[] _cache; // 0x00
	private static int _writeAt; // 0x08
	private static readonly List<KeyValuePair<AnimationClip, AnimationClip>> _overrideBuf; // 0x10

	// Nested types
	private struct Entry // TypeDefIndex: 2367
	{
		// Fields
		public Animator anim; // 0x00
		public RuntimeAnimatorController ctrl; // 0x08
		public bool ok; // 0x10
	}

	// Constructors
	static PetAnimKeys(); // 0x0000000180B4BE00-0x0000000180B4BFF0

	// Methods
	public static int AttackKey(Animator a, bool fullPower); // 0x0000000180B4B560-0x0000000180B4B6A0
	private static bool HasAttackPower(Animator a); // 0x0000000180B4B6A0-0x0000000180B4BAB0
	private static bool Probe(RuntimeAnimatorController ctrl); // 0x0000000180B4BAB0-0x0000000180B4BE00
}

