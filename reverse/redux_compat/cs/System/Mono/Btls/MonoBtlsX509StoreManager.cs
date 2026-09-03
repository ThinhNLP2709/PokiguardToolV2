/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono.Btls
{
	internal static class MonoBtlsX509StoreManager // TypeDefIndex: 8636
	{
		// Fields
		private static bool initialized; // 0x00
		private static string machineTrustedRootPath; // 0x08
		private static string machineIntermediateCAPath; // 0x10
		private static string machineUntrustedPath; // 0x18
		private static string userTrustedRootPath; // 0x20
		private static string userIntermediateCAPath; // 0x28
		private static string userUntrustedPath; // 0x30
	
		// Methods
		private static void Initialize(); // 0x0000000181B4FA90-0x0000000181B4FD80
		private static void DoInitialize(); // 0x0000000181B4F750-0x0000000181B4F950
		public static string GetStorePath(MonoBtlsX509StoreType type); // 0x0000000181B4F950-0x0000000181B4FA90
	}
}
