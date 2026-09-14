/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome
{
	public static class HubAvatarConfig // TypeDefIndex: 2619
	{
		// Fields
		private static Cfg _cfg; // 0x00
		private static bool _loaded; // 0x08
	
		// Properties
		public static Cfg Current { get; } // 0x0000000180C10BB0-0x0000000180C10C60 
	
		// Nested types
		[Serializable]
		public class Cfg // TypeDefIndex: 2620
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
			public Cfg(); // 0x0000000180C11EE0-0x0000000180C11F90
		}
	
		// Constructors
		static HubAvatarConfig(); // 0x0000000180C11E20-0x0000000180C11EE0
	
		// Methods
		public static void Reload(); // 0x0000000180C10C60-0x0000000180C10F00
		private static void EnsureLoaded(); // 0x0000000180C10F00-0x0000000180C10F70
		public static void ApplyJson(string raw); // 0x0000000180C10F70-0x0000000180C11060
		private static void ApplyRemote(); // 0x0000000180C11060-0x0000000180C11750
		private static void Sanitize(); // 0x0000000180C11750-0x0000000180C11AB0
		private static float Clamp(float v, float lo, float hi, float fallback); // 0x0000000180C11AB0-0x0000000180C11AF0
		private static bool Get(string prop, out string val); // 0x0000000180C11AF0-0x0000000180C11BE0
		private static float ParseFloat(string v, float fallback); // 0x000000018032D260-0x000000018032D340
		private static int ParseInt(string v, int fallback); // 0x000000018032D340-0x000000018032D450
		private static bool ParseBool(string v, bool fallback); // 0x0000000180C11BE0-0x0000000180C11E20
	}
}
