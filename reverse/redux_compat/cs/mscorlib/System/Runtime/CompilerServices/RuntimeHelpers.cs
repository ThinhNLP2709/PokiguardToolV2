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

namespace System.Runtime.CompilerServices
{
	public static class RuntimeHelpers // TypeDefIndex: 3249
	{
		// Properties
		public static int OffsetToStringData { get; } // 0x0000000181518E70-0x0000000181518E80 
	
		// Methods
		private static void InitializeArray(Array array, IntPtr fldHandle); // 0x0000000181518DD0-0x0000000181518DE0
		public static void InitializeArray(Array array, RuntimeFieldHandle fldHandle); // 0x0000000181518D70-0x0000000181518DD0
		public static int GetHashCode(object o); // 0x0000000181474D40-0x0000000181474D50
		public static object GetObjectValue(object obj); // 0x0000000181518D10-0x0000000181518D20
		private static void RunClassConstructor(IntPtr type); // 0x0000000181518DE0-0x0000000181518DF0
		public static void RunClassConstructor(RuntimeTypeHandle type); // 0x0000000181518DF0-0x0000000181518E70
		private static bool SufficientExecutionStack(); // 0x000000018150C960-0x000000018150C970
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static void EnsureSufficientExecutionStack(); // 0x0000000181518CB0-0x0000000181518D10
		public static bool TryEnsureSufficientExecutionStack(); // 0x000000018150C960-0x000000018150C970
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static void PrepareConstrainedRegions(); // 0x00000001802E76C0-0x00000001802E76D0
		public static void PrepareMethod(RuntimeMethodHandle method); // 0x00000001802E76C0-0x00000001802E76D0
		public static bool IsReferenceOrContainsReferences<T>();
		public static object GetUninitializedObject(Type type); // 0x0000000181518D20-0x0000000181518D70
	}
}
