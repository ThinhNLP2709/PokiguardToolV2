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
	public static class Interlocked // TypeDefIndex: 2607
	{
		// Methods
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static int CompareExchange(ref int location1, int value, int comparand); // 0x0000000181681160-0x0000000181681170
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		internal static int CompareExchange(ref int location1, int value, int comparand, ref bool succeeded); // 0x0000000181681140-0x0000000181681150
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		private static void CompareExchange(ref object location1, ref object value, ref object comparand, ref object result); // 0x0000000181681130-0x0000000181681140
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static object CompareExchange(ref object location1, object value, object comparand); // 0x0000000181681170-0x00000001816811B0
		public static float CompareExchange(ref float location1, float value, float comparand); // 0x00000001816811B0-0x00000001816811D0
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static int Decrement(ref int location); // 0x00000001816811F0-0x0000000181681200
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static int Increment(ref int location); // 0x0000000181681290-0x00000001816812A0
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static long Increment(ref long location); // 0x0000000181681280-0x0000000181681290
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static int Exchange(ref int location1, int value); // 0x0000000181681220-0x0000000181681230
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		private static void Exchange(ref object location1, ref object value, ref object result); // 0x0000000181681200-0x0000000181681210
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static object Exchange(ref object location1, object value); // 0x0000000181681230-0x0000000181681260
		public static float Exchange(ref float location1, float value); // 0x0000000181681260-0x0000000181681270
		public static long CompareExchange(ref long location1, long value, long comparand); // 0x0000000181681150-0x0000000181681160
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static IntPtr CompareExchange(ref IntPtr location1, IntPtr value, IntPtr comparand); // 0x0000000181681150-0x0000000181681160
		public static double CompareExchange(ref double location1, double value, double comparand); // 0x00000001816811D0-0x00000001816811F0
		[ComVisible(false)]
		[Intrinsic]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static T CompareExchange<T>(ref ref T location1, T value, T comparand)
			where T : class;
		public static long Exchange(ref long location1, long value); // 0x0000000181681210-0x0000000181681220
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static IntPtr Exchange(ref IntPtr location1, IntPtr value); // 0x0000000181681210-0x0000000181681220
		public static double Exchange(ref double location1, double value); // 0x0000000181681270-0x0000000181681280
		[ComVisible(false)]
		[Intrinsic]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static T Exchange<T>(ref ref T location1, T value)
			where T : class;
		public static long Read(ref long location); // 0x00000001816812B0-0x00000001816812C0
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static int Add(ref int location1, int value); // 0x0000000181681110-0x0000000181681120
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static long Add(ref long location1, long value); // 0x0000000181681120-0x0000000181681130
		public static void MemoryBarrier(); // 0x00000001816812A0-0x00000001816812B0
	}
}
