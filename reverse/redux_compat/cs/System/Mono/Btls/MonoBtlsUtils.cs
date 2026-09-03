/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono.Btls
{
	internal static class MonoBtlsUtils // TypeDefIndex: 8614
	{
		// Fields
		private static byte[] emailOid; // 0x00
	
		// Constructors
		static MonoBtlsUtils(); // 0x0000000181B4B290-0x0000000181B4B320
	
		// Methods
		public static bool Compare(byte[] a, byte[] b); // 0x0000000181B4B0C0-0x0000000181B4B140
		private static bool AppendEntry(StringBuilder sb, MonoBtlsX509Name name, int index, string separator, bool quotes); // 0x0000000181B4AA70-0x0000000181B4B0C0
		public static string FormatName(MonoBtlsX509Name name, bool reversed, string separator, bool quotes); // 0x0000000181B4B140-0x0000000181B4B290
	}
}
