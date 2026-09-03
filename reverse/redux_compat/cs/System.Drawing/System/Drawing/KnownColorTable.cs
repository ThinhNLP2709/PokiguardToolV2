/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 39: System.Drawing.dll - Assembly: System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a - Types 15087-15098

namespace System.Drawing
{
	internal static class KnownColorTable // TypeDefIndex: 15091
	{
		// Fields
		private static int[] s_colorTable; // 0x00
		private static string[] s_colorNameTable; // 0x08
	
		// Methods
		private static void EnsureColorTable(); // 0x000000018192A620-0x000000018192A670
		private static void InitColorTable(); // 0x000000018192C7F0-0x000000018192D3F0
		private static void EnsureColorNameTable(); // 0x000000018192A5D0-0x000000018192A620
		private static void InitColorNameTable(); // 0x000000018192A670-0x000000018192C7F0
		public static int KnownColorToArgb(KnownColor color); // 0x000000018192D3F0-0x000000018192D480
		public static string KnownColorToName(KnownColor color); // 0x000000018192D480-0x000000018192D510
		private static void UpdateSystemColors(int[] colorTable); // 0x000000018192D510-0x000000018192D780
	}
}
