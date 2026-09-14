/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome
{
	public static class HubAvatarConfig // TypeDefIndex: 2612
	{
		// Fields
		private static Cfg _cfg; // 0x00
		private static bool _loaded; // 0x08
	
		// Properties
		public static Cfg Current { get; } // 0x0000000180C03660-0x0000000180C03710 
	
		// Nested types
		[Serializable]
		public class Cfg // TypeDefIndex: 2613
		{
			// Fields
			public bool enabled; // 0x10
			public float gapLeft; // 0x14
			public float marginRight; // 0x18
			public float gapPill; // 0x1C
			public float minWidth; // 0x20
			public int minFont; // 0x24
			public int maxFont; // 0x28
			public float vipBadgeScale; // 0x2C
			public string ellipsis; // 0x30
	
			// Constructors
			public Cfg(); // 0x0000000180C04990-0x0000000180C04A40
		}
	
		// Constructors
		static HubAvatarConfig(); // 0x0000000180C048D0-0x0000000180C04990
	
		// Methods
		public static void Reload(); // 0x0000000180C03710-0x0000000180C039B0
		private static void EnsureLoaded(); // 0x0000000180C039B0-0x0000000180C03A20
		public static void ApplyJson(string raw); // 0x0000000180C03A20-0x0000000180C03B10
		private static void ApplyRemote(); // 0x0000000180C03B10-0x0000000180C04200
		private static void Sanitize(); // 0x0000000180C04200-0x0000000180C04560
		private static float Clamp(float v, float lo, float hi, float fallback); // 0x0000000180C04560-0x0000000180C045A0
		private static bool Get(string prop, out string val); // 0x0000000180C045A0-0x0000000180C04690
		private static float ParseFloat(string v, float fallback); // 0x000000018032D140-0x000000018032D220
		private static int ParseInt(string v, int fallback); // 0x000000018032D220-0x000000018032D330
		private static bool ParseBool(string v, bool fallback); // 0x0000000180C04690-0x0000000180C048D0
	}
}
