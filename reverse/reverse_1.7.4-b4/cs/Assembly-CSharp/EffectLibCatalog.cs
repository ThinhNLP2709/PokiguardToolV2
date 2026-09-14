/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class EffectLibCatalog // TypeDefIndex: 2132
{
	// Fields
	private static readonly string[][] SPEC; // 0x00
	private static List<Entry> _entries; // 0x08

	// Properties
	public static IList<Entry> Entries { get; } // 0x0000000180A10AC0-0x0000000180A10ED0 

	// Nested types
	public struct Entry // TypeDefIndex: 2133
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
	static EffectLibCatalog(); // 0x0000000180A11060-0x0000000180A11860

	// Methods
	public static Sprite LoadIcon(string iconName); // 0x0000000180A10ED0-0x0000000180A11060
}

