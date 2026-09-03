/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 49: UnityEngine.ScriptingModule.dll - Assembly: UnityEngine.ScriptingModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15445-15504

namespace Unity.Collections.LowLevel.Unsafe
{
	[VisibleToOtherModules]
	internal static class UnsafeUtilityInternal // TypeDefIndex: 15452
	{
		// Nested types
		private struct AlignOfHelper<T> // TypeDefIndex: 15453
			where T : struct
		{
			// Fields
			public byte dummy;
			public T data;
		}
	
		// Methods
		public static unsafe void CopyPtrToStructure<T>(void* ptr, out ref T output)
			where T : struct;
		private static unsafe void InternalCopyPtrToStructure<T>(void* ptr, out ref T output)
			where T : struct;
		public static unsafe void CopyStructureToPtr<T>(ref ref T input, void* ptr)
			where T : struct;
		private static unsafe void InternalCopyStructureToPtr<T>(ref ref T input, void* ptr)
			where T : struct;
		public static unsafe T ReadArrayElement<T>(void* source, int index);
		public static unsafe T ReadArrayElementWithStride<T>(void* source, int index, int stride);
		public static unsafe void WriteArrayElement<T>(void* destination, int index, T value);
		public static unsafe void WriteArrayElementWithStride<T>(void* destination, int index, int stride, T value);
		public static unsafe void* AddressOf<T>(ref ref T output)
			where T : struct;
		public static int SizeOf<T>()
			where T : struct;
		[VisibleToOtherModules]
		internal static int AlignOf<T>()
			where T : struct;
		public static ref ref T As<U, T>(ref ref U from);
		[VisibleToOtherModules]
		internal static T As<T>(object from)
			where T : class;
		public static unsafe ref ref T AsRef<T>(void* ptr)
			where T : struct;
		public static unsafe ref ref T ArrayElementAsRef<T>(void* ptr, int index)
			where T : struct;
		public static int EnumToInt<T>(T enumValue)
			where T : struct, IConvertible;
		private static void InternalEnumToInt<T>(ref ref T enumValue, ref int intValue);
		public static bool EnumEquals<T>(T lhs, T rhs)
			where T : struct, IConvertible;
		[VisibleToOtherModules]
		internal static ref ref T Add<T>(ref ref T source, int elementOffset)
			where T : struct;
	}
}
