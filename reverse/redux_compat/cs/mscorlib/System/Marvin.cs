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

namespace System
{
	internal static class Marvin // TypeDefIndex: 2297
	{
		// Fields
		[CompilerGenerated]
		private static readonly ulong _DefaultSeed_k__BackingField; // 0x00
	
		// Properties
		public static ulong DefaultSeed { [CompilerGenerated] get; } // 0x00000001815FF320-0x00000001815FF370 
	
		// Constructors
		static Marvin(); // 0x00000001815FF2E0-0x00000001815FF320
	
		// Methods
		public static int ComputeHash32(ReadOnlySpan<byte> data, ulong seed); // 0x00000001815FECD0-0x00000001815FED50
		public static int ComputeHash32(ref byte data, int count, ulong seed); // 0x00000001815FED50-0x00000001815FF2D0
		private static void Block(ref uint rp0, ref uint rp1); // 0x00000001815FEC30-0x00000001815FECD0
		private static uint _rotl(uint value, int shift); // 0x00000001815FB690-0x00000001815FB6B0
		private static ulong GenerateSeed(); // 0x00000001815FF2D0-0x00000001815FF2E0
	}
}
