/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace PokiGuard.StatusFx
{
	public static class StatusFxCatalog // TypeDefIndex: 1838
	{
		// Fields
		private static readonly Dictionary<string, Meta> _map; // 0x00
		private static readonly Dictionary<string, Sprite> _iconCache; // 0x08
		private static readonly Dictionary<string, Sprite[]> _frameCache; // 0x10
		private const int FRAME_START_PROBE = 20; // Metadata: 0x0064DC54
		private const int FRAME_MAX_COUNT = 300; // Metadata: 0x0064DC55
	
		// Nested types
		public struct Meta // TypeDefIndex: 1839
		{
			// Fields
			public string label; // 0x00
			public string iconName; // 0x08
			public Color color; // 0x10
			public bool isDebuff; // 0x20
			public bool showTurns; // 0x21
		}
	
		// Constructors
		static StatusFxCatalog(); // 0x0000000180602F30-0x0000000180603A00
	
		// Methods
		private static Color C(float r, float g, float b); // 0x0000000180602420-0x0000000180602440
		public static bool TryGet(string type, out Meta meta); // 0x0000000180602DD0-0x0000000180602F30
		public static string PopupText(string type, string action, double value); // 0x0000000180602B00-0x0000000180602DD0
		public static Sprite LoadIcon(string iconName); // 0x0000000180602890-0x0000000180602B00
		public static Sprite[] LoadFrames(string prefix); // 0x00000001806025E0-0x0000000180602890
		private static Sprite LoadFrame(string prefix, int index); // 0x0000000180602440-0x00000001806025E0
	}
}
