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

namespace System.Runtime.CompilerServices
{
	internal static class Unsafe // TypeDefIndex: 3250
	{
		// Methods
		public static ref ref T Add<T>(ref ref T source, int elementOffset);
		public static ref ref T Add<T>(ref ref T source, IntPtr elementOffset);
		public static unsafe void* Add<T>(void* source, int elementOffset);
		public static ref ref T AddByteOffset<T>(ref ref T source, IntPtr byteOffset);
		public static bool AreSame<T>(ref ref T left, ref ref T right);
		public static T As<T>(object o)
			where T : class;
		public static ref ref TTo As<TFrom, TTo>(ref ref TFrom source);
		public static unsafe void* AsPointer<T>(ref ref T value);
		public static unsafe ref ref T AsRef<T>(void* source);
		public static ref ref T AsRef<T>([IsReadOnly] in ref T source);
		public static void InitBlockUnaligned(ref byte startAddress, byte value, uint byteCount); // 0x000000018151C2B0-0x000000018151C2C0
		public static unsafe T Read<T>(void* source);
		public static T ReadUnaligned<T>(ref byte source);
		public static int SizeOf<T>();
		public static void WriteUnaligned<T>(ref byte destination, T value);
		public static bool IsAddressLessThan<T>(ref ref T left, ref ref T right);
		internal static ref ref T AddByteOffset<T>(ref ref T source, ulong byteOffset);
	}
}
