/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokiGuard.Audition
{
	public static class AuditionArt // TypeDefIndex: 2543
	{
		// Fields
		private static readonly Dictionary<string, Sprite> _cache; // 0x00
		private static readonly Dictionary<string, Sprite> _raw; // 0x08
		private static Sprite _fallback; // 0x10
	
		// Properties
		public static Sprite Fallback { get; } // 0x0000000180BC66A0-0x0000000180BC6C80 
	
		// Constructors
		static AuditionArt(); // 0x0000000180BC6C80-0x0000000180BC6F10
	
		// Methods
		public static Sprite Get(string path); // 0x0000000180BC5E80-0x0000000180BC6150
		public static Sprite GetOrNull(string path); // 0x0000000180BC6150-0x0000000180BC6400
		public static Sprite LegacyWait(string dir); // 0x0000000180BC6400-0x0000000180BC6550
		public static Sprite LegacyDone(string dir); // 0x0000000180BC6550-0x0000000180BC66A0
	}
}
