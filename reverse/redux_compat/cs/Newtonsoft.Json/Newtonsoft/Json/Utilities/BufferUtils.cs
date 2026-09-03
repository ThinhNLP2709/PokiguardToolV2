/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Newtonsoft.Json;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Utilities
{
	[Nullable(0)]
	[NullableContext(2)]
	internal static class BufferUtils // TypeDefIndex: 10151
	{
		// Methods
		[NullableContext(1)]
		public static char[] RentBuffer([Nullable(2)] IArrayPool<char> bufferPool, int minSize); // 0x00000001816E49D0-0x00000001816E4A50
		public static void ReturnBuffer(IArrayPool<char> bufferPool, char[] buffer); // 0x00000001816E4A50-0x00000001816E4AB0
		public static char[] EnsureBufferSize(IArrayPool<char> bufferPool, int size, char[] buffer); // 0x00000001816E4930-0x00000001816E49D0
	}
}
