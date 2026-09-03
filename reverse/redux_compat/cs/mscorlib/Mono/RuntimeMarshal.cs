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

namespace Mono
{
	internal static class RuntimeMarshal // TypeDefIndex: 2080
	{
		// Methods
		internal static string PtrToUtf8String(IntPtr ptr); // 0x0000000181433540-0x0000000181433640
		internal static SafeStringMarshal MarshalString(string str); // 0x0000000181433510-0x0000000181433540
		private static int DecodeBlobSize(IntPtr in_ptr, out IntPtr out_ptr); // 0x0000000181433480-0x0000000181433500
		internal static byte[] DecodeBlobArray(IntPtr ptr); // 0x0000000181433390-0x0000000181433480
		internal static int AsciHexDigitValue(int c); // 0x0000000181433360-0x0000000181433390
		internal static void FreeAssemblyName(ref MonoAssemblyName name, bool freeStruct); // 0x0000000181433500-0x0000000181433510
	}
}
