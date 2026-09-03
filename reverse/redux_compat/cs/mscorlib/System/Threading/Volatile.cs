/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Threading
{
	public static class Volatile // TypeDefIndex: 2618
	{
		// Nested types
		private struct VolatileBoolean // TypeDefIndex: 2619
		{
			// Fields
			public bool Value; // 0x00
		}
	
		private struct VolatileByte // TypeDefIndex: 2620
		{
			// Fields
			public byte Value; // 0x00
		}
	
		private struct VolatileInt32 // TypeDefIndex: 2621
		{
			// Fields
			public int Value; // 0x00
		}
	
		private struct VolatileIntPtr // TypeDefIndex: 2622
		{
			// Fields
			public IntPtr Value; // 0x00
		}
	
		private struct VolatileUInt32 // TypeDefIndex: 2623
		{
			// Fields
			public uint Value; // 0x00
		}
	
		private struct VolatileObject // TypeDefIndex: 2624
		{
			// Fields
			public object Value; // 0x00
		}
	
		// Methods
		[Intrinsic]
		public static bool Read(ref bool location); // 0x0000000181694020-0x0000000181694040
		[Intrinsic]
		public static void Write(ref bool location, bool value); // 0x00000001816940C0-0x00000001816940F0
		[Intrinsic]
		public static byte Read(ref byte location); // 0x0000000181694020-0x0000000181694040
		[Intrinsic]
		public static int Read(ref int location); // 0x0000000181694040-0x0000000181694060
		[Intrinsic]
		public static void Write(ref int location, int value); // 0x0000000181694090-0x00000001816940C0
		[Intrinsic]
		public static IntPtr Read(ref IntPtr location); // 0x0000000180A339E0-0x0000000180A33A00
		[Intrinsic]
		public static void Write(ref IntPtr location, IntPtr value); // 0x0000000181694060-0x0000000181694090
		[CLSCompliant(false)]
		[Intrinsic]
		public static uint Read(ref uint location); // 0x0000000181694040-0x0000000181694060
		[Intrinsic]
		public static T Read<T>(ref ref T location)
			where T : class;
		[Intrinsic]
		public static void Write<T>(ref ref T location, T value)
			where T : class;
		[CLSCompliant(false)]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static ulong Read(ref ulong location); // 0x0000000180A339E0-0x0000000180A33A00
		[CLSCompliant(false)]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static void Write(ref ulong location, ulong value); // 0x0000000181694060-0x0000000181694090
	}
}
