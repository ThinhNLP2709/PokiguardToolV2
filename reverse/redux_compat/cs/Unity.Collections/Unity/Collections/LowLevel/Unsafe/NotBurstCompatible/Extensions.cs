/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections.LowLevel.Unsafe.NotBurstCompatible
{
	public static class Extensions // TypeDefIndex: 11755
	{
		// Extension methods
		public static T[] ToArray<T>(this UnsafeParallelHashSet<T> set)
			where T : struct, IEquatable<T>;
		[ExcludeFromBurstCompatTesting("Takes managed string")]
		public static void AddNBC(this ref UnsafeAppendBuffer buffer, string value); // 0x0000000181CA1560-0x0000000181CA15F0
		[ExcludeFromBurstCompatTesting("Returns managed array")]
		public static byte[] ToBytesNBC(this ref UnsafeAppendBuffer buffer); // 0x0000000181CA16C0-0x0000000181CA1740
		[ExcludeFromBurstCompatTesting("Managed string out argument")]
		public static void ReadNextNBC(this ref UnsafeAppendBuffer.Reader reader, out string value); // 0x0000000181CA15F0-0x0000000181CA16C0
	}
}
