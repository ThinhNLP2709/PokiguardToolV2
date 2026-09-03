/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	internal class CaseInsensitiveAscii : IEqualityComparer, IComparer // TypeDefIndex: 9058
	{
		// Fields
		internal static readonly CaseInsensitiveAscii StaticInstance; // 0x00
		internal static readonly byte[] AsciiToLower; // 0x08
	
		// Constructors
		public CaseInsensitiveAscii(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static CaseInsensitiveAscii(); // 0x0000000181BDEF70-0x0000000181BDF0A0
	
		// Methods
		public int GetHashCode(object myObject); // 0x0000000181BDEE60-0x0000000181BDEF70
		public int Compare(object firstObject, object secondObject); // 0x0000000181BDEA70-0x0000000181BDEBF0
		private int FastGetHashCode(string myString); // 0x0000000181BDED70-0x0000000181BDEE60
		public new bool Equals(object firstObject, object secondObject); // 0x0000000181BDEBF0-0x0000000181BDED70
	}
}
