/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class EffectLibCatalog // TypeDefIndex: 2130
{
	// Fields
	private static readonly string[][] SPEC; // 0x00
	private static List<Entry> _entries; // 0x08

	// Properties
	public static IList<Entry> Entries { get; } // 0x0000000180A0CED0-0x0000000180A0D2E0 

	// Nested types
	public struct Entry // TypeDefIndex: 2131
	{
		// Fields
		public string key; // 0x00
		public string label; // 0x08
		public string desc; // 0x10
		public string iconName; // 0x18
		public Color color; // 0x20
		public bool isDebuff; // 0x30
	}

	// Constructors
	static EffectLibCatalog(); // 0x0000000180A0D470-0x0000000180A0DC70

	// Methods
	public static Sprite LoadIcon(string iconName); // 0x0000000180A0D2E0-0x0000000180A0D470
}

