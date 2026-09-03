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
	public static class Monitor // TypeDefIndex: 2581
	{
		// Methods
		public static void Enter(object obj); // 0x00000001816719C0-0x00000001816719D0
		public static void Enter(object obj, ref bool lockTaken); // 0x0000000181671940-0x00000001816719C0
		private static void ThrowLockTakenException(); // 0x0000000181671E70-0x0000000181671EE0
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static void Exit(object obj); // 0x00000001816719D0-0x00000001816719E0
		public static void TryEnter(object obj, ref bool lockTaken); // 0x0000000181671EE0-0x0000000181671F60
		public static bool Wait(object obj, int millisecondsTimeout, bool exitContext); // 0x0000000181671F60-0x0000000181672080
		public static bool Wait(object obj, int millisecondsTimeout); // 0x0000000181671F60-0x0000000181672080
		public static void Pulse(object obj); // 0x0000000181671C90-0x0000000181671D50
		public static void PulseAll(object obj); // 0x0000000181671BD0-0x0000000181671C90
		private static bool Monitor_test_synchronised(object obj); // 0x0000000181671A00-0x0000000181671A10
		private static void Monitor_pulse(object obj); // 0x00000001816719F0-0x0000000181671A00
		private static void ObjPulse(object obj); // 0x0000000181671A90-0x0000000181671B00
		private static void Monitor_pulse_all(object obj); // 0x00000001816719E0-0x00000001816719F0
		private static void ObjPulseAll(object obj); // 0x0000000181671A20-0x0000000181671A90
		private static bool Monitor_wait(object obj, int ms); // 0x0000000181671A10-0x0000000181671A20
		private static bool ObjWait(bool exitContext, int millisecondsTimeout, object obj); // 0x0000000181671B00-0x0000000181671BD0
		private static void try_enter_with_atomic_var(object obj, int millisecondsTimeout, ref bool lockTaken); // 0x0000000181672080-0x0000000181672090
		private static void ReliableEnterTimeout(object obj, int timeout, ref bool lockTaken); // 0x0000000181671D50-0x0000000181671E00
		private static void ReliableEnter(object obj, ref bool lockTaken); // 0x0000000181671E00-0x0000000181671E70
	}
}
