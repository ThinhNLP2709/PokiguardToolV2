/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	internal sealed class Operators // TypeDefIndex: 11289
	{
		// Fields
		private static readonly int[] s_priority; // 0x00
		private static readonly string[] s_looks; // 0x08
	
		// Constructors
		static Operators(); // 0x000000018189B800-0x000000018189C070
	
		// Methods
		internal static bool IsArithmetical(int op); // 0x000000018189B6A0-0x000000018189B6C0
		internal static bool IsLogical(int op); // 0x000000018189B6C0-0x000000018189B6E0
		internal static bool IsRelational(int op); // 0x000000018189B6E0-0x000000018189B6F0
		internal static int Priority(int op); // 0x000000018189B6F0-0x000000018189B770
		internal static string ToString(int op); // 0x000000018189B770-0x000000018189B800
	}
}
