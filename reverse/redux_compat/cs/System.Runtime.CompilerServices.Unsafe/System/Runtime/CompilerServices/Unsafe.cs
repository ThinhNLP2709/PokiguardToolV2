/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

// Image 83: System.Runtime.CompilerServices.Unsafe.dll - Assembly: System.Runtime.CompilerServices.Unsafe, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a - Types 15957-15961

namespace System.Runtime.CompilerServices
{
	public static class Unsafe // TypeDefIndex: 15958
	{
		// Methods
		[NonVersionable]
		public static unsafe T ReadUnaligned<T>(void* source);
		[NonVersionable]
		public static T ReadUnaligned<T>(ref byte source);
		[NonVersionable]
		public static unsafe void WriteUnaligned<T>(void* destination, T value);
		[NonVersionable]
		public static void WriteUnaligned<T>(ref byte destination, T value);
		[NonVersionable]
		public static unsafe void* AsPointer<T>(ref ref T value);
		[NonVersionable]
		public static int SizeOf<T>();
		[NonVersionable]
		public static unsafe void InitBlockUnaligned(void* startAddress, byte value, uint byteCount); // 0x000000018151C2B0-0x000000018151C2C0
		[NonVersionable]
		public static T As<T>(object o)
			where T : class;
		[NonVersionable]
		public static unsafe ref ref T AsRef<T>(void* source);
		[NonVersionable]
		public static ref ref TTo As<TFrom, TTo>(ref ref TFrom source);
		[NonVersionable]
		public static ref ref T AddByteOffset<T>(ref ref T source, IntPtr byteOffset);
		public static ref ref T AddByteOffset<T>(ref ref T source, [NonVersionable] [NativeInteger] UIntPtr byteOffset);
	}
}
