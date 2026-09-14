/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome.InfoPlayer
{
	public static class EquipPerkIcons // TypeDefIndex: 2786
	{
		// Fields
		public static readonly string[] DotTokens; // 0x00
		private static readonly Color DotVang; // 0x08
		private static readonly Color DotTim; // 0x18
		private static readonly Color DotDo; // 0x28
		private static readonly Color DotXanh; // 0x38
		private static readonly Color DotManaColor; // 0x48
		private static readonly Color DotTrang; // 0x58
		private static readonly Color LuckColor; // 0x68
		private static readonly Color CritColor; // 0x78
		private static Sprite _luck; // 0x88
		private static Sprite _tick; // 0x90
	
		// Constructors
		static EquipPerkIcons(); // 0x0000000180CD6050-0x0000000180CD65F0
	
		// Methods
		public static Sprite Resolve(string token); // 0x0000000180CD4850-0x0000000180CD4D70
		public static string OtaPathFor(string token); // 0x0000000180CD4D70-0x0000000180CD4E70
		public static Color TintFor(string token); // 0x0000000180CD4E70-0x0000000180CD53F0
		public static Sprite ProceduralLuck(); // 0x0000000180CD53F0-0x0000000180CD5920
		public static Sprite TickBadge(); // 0x0000000180CD5920-0x0000000180CD5DB0
		private static Sprite Rasterize(Color32[] px, int size, string name); // 0x0000000180CD5DB0-0x0000000180CD6050
	}
}
