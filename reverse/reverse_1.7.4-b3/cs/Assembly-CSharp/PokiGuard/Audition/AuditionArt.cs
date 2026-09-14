/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokiGuard.Audition
{
	public static class AuditionArt // TypeDefIndex: 2536
	{
		// Fields
		private static readonly Dictionary<string, Sprite> _cache; // 0x00
		private static readonly Dictionary<string, Sprite> _raw; // 0x08
		private static Sprite _fallback; // 0x10
	
		// Properties
		public static Sprite Fallback { get; } // 0x0000000180BB9280-0x0000000180BB9860 
	
		// Constructors
		static AuditionArt(); // 0x0000000180BB9860-0x0000000180BB9AF0
	
		// Methods
		public static Sprite Get(string path); // 0x0000000180BB8A60-0x0000000180BB8D30
		public static Sprite GetOrNull(string path); // 0x0000000180BB8D30-0x0000000180BB8FE0
		public static Sprite LegacyWait(string dir); // 0x0000000180BB8FE0-0x0000000180BB9130
		public static Sprite LegacyDone(string dir); // 0x0000000180BB9130-0x0000000180BB9280
	}
}
