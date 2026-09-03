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

namespace System.Text
{
	internal static class EncodingHelper // TypeDefIndex: 2741
	{
		// Fields
		private static Encoding utf8EncodingWithoutMarkers; // 0x00
		private static readonly object lockobj; // 0x08
		private static Assembly i18nAssembly; // 0x10
		private static bool i18nDisabled; // 0x18
	
		// Properties
		internal static Encoding UTF8Unmarked { get; } // 0x0000000181478320-0x00000001814784D0 
	
		// Constructors
		static EncodingHelper(); // 0x00000001814782B0-0x0000000181478320
	
		// Methods
		internal static string InternalCodePage(ref int code_page); // 0x0000000181477DB0-0x0000000181477DC0
		internal static Encoding GetDefaultEncoding(); // 0x0000000181477CB0-0x0000000181477DB0
		internal static object InvokeI18N(string name, params object[] args); // 0x0000000181477DC0-0x00000001814782B0
	}
}
