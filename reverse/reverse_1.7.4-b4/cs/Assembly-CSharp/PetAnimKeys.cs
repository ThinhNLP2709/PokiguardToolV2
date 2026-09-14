/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class PetAnimKeys // TypeDefIndex: 2373
{
	// Fields
	private static readonly Entry[] _cache; // 0x00
	private static int _writeAt; // 0x08
	private static readonly List<KeyValuePair<AnimationClip, AnimationClip>> _overrideBuf; // 0x10

	// Nested types
	private struct Entry // TypeDefIndex: 2374
	{
		// Fields
		public Animator anim; // 0x00
		public RuntimeAnimatorController ctrl; // 0x08
		public bool ok; // 0x10
	}

	// Constructors
	static PetAnimKeys(); // 0x0000000180B59080-0x0000000180B59270

	// Methods
	public static int AttackKey(Animator a, bool fullPower); // 0x0000000180B587E0-0x0000000180B58920
	private static bool HasAttackPower(Animator a); // 0x0000000180B58920-0x0000000180B58D30
	private static bool Probe(RuntimeAnimatorController ctrl); // 0x0000000180B58D30-0x0000000180B59080
}

