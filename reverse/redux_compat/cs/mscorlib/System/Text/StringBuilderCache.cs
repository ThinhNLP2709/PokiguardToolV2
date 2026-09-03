/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Text
{
	internal static class StringBuilderCache // TypeDefIndex: 2719
	{
		// Fields
		[ThreadStatic]
		private static StringBuilder t_cachedInstance; // 0x80000000
	
		// Methods
		public static StringBuilder Acquire(int capacity = 16 /* Metadata: 0x0064EA99 */); // 0x0000000181466A50-0x0000000181466B30
		public static void Release(StringBuilder sb); // 0x0000000181466BD0-0x0000000181466C50
		public static string GetStringAndRelease(StringBuilder sb); // 0x0000000181466B30-0x0000000181466BD0
	}
}
