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

namespace System
{
	public static class GC // TypeDefIndex: 2427
	{
		// Fields
		internal static readonly object EPHEMERON_TOMBSTONE; // 0x00
	
		// Constructors
		static GC(); // 0x000000018163B760-0x000000018163B7B0
	
		// Methods
		private static int GetCollectionCount(int generation); // 0x000000018163B490-0x000000018163B4A0
		private static void RecordPressure(long bytesAllocated); // 0x00000001814A3D40-0x00000001814A3D50
		internal static void register_ephemeron_array(Ephemeron[] array); // 0x000000018163B7C0-0x000000018163B7D0
		private static object get_ephemeron_tombstone(); // 0x000000018163B7B0-0x000000018163B7C0
		internal static void GetMemoryInfo(out uint highMemLoadThreshold, out ulong totalPhysicalMem, out uint lastRecordedMemLoad, out UIntPtr lastRecordedHeapSize, out UIntPtr lastRecordedFragmentation); // 0x000000018163B4A0-0x000000018163B4C0
		public static void AddMemoryPressure(long bytesAllocated); // 0x000000018163B290-0x000000018163B3D0
		public static void RemoveMemoryPressure(long bytesAllocated); // 0x000000018163B560-0x000000018163B6A0
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static int CollectionCount(int generation); // 0x000000018163B3D0-0x000000018163B490
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static void KeepAlive(object obj); // 0x00000001802E76C0-0x00000001802E76D0
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		private static void _SuppressFinalize(object o); // 0x000000018163B750-0x000000018163B760
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static void SuppressFinalize(object obj); // 0x000000018163B6A0-0x000000018163B740
		private static void _ReRegisterForFinalize(object o); // 0x000000018163B740-0x000000018163B750
		public static void ReRegisterForFinalize(object obj); // 0x000000018163B4C0-0x000000018163B560
	}
}
