/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.InfoPlayer
{
	public static class LegacyWeaponLayer // TypeDefIndex: 2433
	{
		// Fields
		public const float FRAME = 512f; // Metadata: 0x0068F45B
		public const float BOX_CENTER_X = 222f; // Metadata: 0x0068F45F
		public const float BOX_CENTER_Y = 318f; // Metadata: 0x0068F463
		public const float BOX_SIDE = 240f; // Metadata: 0x0068F467
		public const bool MIRROR = true; // Metadata: 0x0068F46B
	
		// Methods
		public static bool IsLegacyIcon(long iconId); // 0x00000001807CE820-0x00000001807CE840
		public static string PathOf(long iconId); // 0x0000000180804DC0-0x0000000180804DD0
		public static bool IsLegacyWeaponPath(string resourcePath); // 0x0000000180804D50-0x0000000180804DC0
		public static Rect FitBox(Sprite icon); // 0x0000000180804B50-0x0000000180804D50
	}
}
