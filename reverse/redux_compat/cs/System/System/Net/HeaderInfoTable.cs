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
	internal class HeaderInfoTable // TypeDefIndex: 9066
	{
		// Fields
		private static Hashtable HeaderHashTable; // 0x00
		private static HeaderInfo UnknownHeaderInfo; // 0x08
		private static HeaderParser SingleParser; // 0x10
		private static HeaderParser MultiParser; // 0x18
	
		// Properties
		internal HeaderInfo this[string name] { get => default; } // 0x0000000181BEFF70-0x0000000181BF0050 
	
		// Constructors
		static HeaderInfoTable(); // 0x0000000181BED830-0x0000000181BEFF70
		public HeaderInfoTable(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		private static string[] ParseSingleValue(string value); // 0x0000000181BED7B0-0x0000000181BED830
		private static string[] ParseMultiValue(string value); // 0x0000000181BED5A0-0x0000000181BED7B0
	}
}
