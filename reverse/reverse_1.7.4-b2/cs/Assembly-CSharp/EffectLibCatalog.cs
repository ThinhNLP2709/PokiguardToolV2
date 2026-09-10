/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class EffectLibCatalog // TypeDefIndex: 1767
{
	// Fields
	public const string ICON_DIR = "Image/StatusLib/"; // Metadata: 0x0068D7BA
	private const string ICON_DIR_FALLBACK = "Image/Status/"; // Metadata: 0x0068D7CB
	private static readonly string[][] SPEC; // 0x00
	private static List<Entry> _entries; // 0x08

	// Properties
	public static IList<Entry> Entries { get; } // 0x0000000180673390-0x00000001806736E0 

	// Nested types
	public struct Entry // TypeDefIndex: 1768
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
	static EffectLibCatalog(); // 0x0000000180672AC0-0x0000000180673390

	// Methods
	public static Sprite LoadIcon(string iconName); // 0x00000001806729C0-0x0000000180672AC0
}

