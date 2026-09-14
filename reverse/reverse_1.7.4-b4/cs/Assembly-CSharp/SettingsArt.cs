/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class SettingsArt // TypeDefIndex: 1209
{
	// Fields
	private static readonly Dictionary<string, Sprite> _borrowed; // 0x00
	private static bool _scanned; // 0x08
	private static readonly HashSet<string> _warned; // 0x10
	private static readonly Dictionary<string, Sprite> _resolved; // 0x18
	private static readonly List<Pending> _pending; // 0x20

	// Nested types
	private struct Pending // TypeDefIndex: 1210
	{
		// Fields
		public Image img; // 0x00
		public string name; // 0x08
		public Image.Type type; // 0x10
		public Color waiting; // 0x14
		public Color ready; // 0x24
		public bool preserve; // 0x34
	}

	// Constructors
	static SettingsArt(); // 0x00000001806D5DD0-0x00000001806D6220

	// Methods
	public static Sprite Load(string name); // 0x00000001806D3DA0-0x00000001806D3F40
	private static Sprite Borrow(string name); // 0x00000001806D3F40-0x00000001806D40E0
	private static Sprite Harvest(string name); // 0x00000001806D40E0-0x00000001806D44B0
	private static void ScanPrefab(); // 0x00000001806D44B0-0x00000001806D4920
	public static void Bind(MonoBehaviour host, Image img, string name, Image.Type type, Color waiting, Color ready, bool preserveAspect = false /* Metadata: 0x005F0953 */); // 0x00000001806D4920-0x00000001806D4DD0
	private static void Remember(Image img, string name, Image.Type type, Color waiting, Color ready, bool preserve); // 0x00000001806D4DD0-0x00000001806D5290
	public static void Refresh(Transform root, MonoBehaviour host); // 0x00000001806D5290-0x00000001806D5BC0
	public static Color ButtonFallback(Color tint); // 0x00000001806D5BC0-0x00000001806D5C00
	private static void WarnOnce(string name, string why); // 0x00000001806D5C00-0x00000001806D5DD0
}

