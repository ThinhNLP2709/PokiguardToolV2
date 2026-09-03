/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Serialization.Formatters.Binary
{
	internal sealed class NameCache // TypeDefIndex: 3109
	{
		// Fields
		private static ConcurrentDictionary<string, object> ht; // 0x00
		private string name; // 0x10
	
		// Constructors
		public NameCache(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static NameCache(); // 0x0000000181511DB0-0x0000000181511E40
	
		// Methods
		internal object GetCachedValue(string name); // 0x0000000181511C60-0x0000000181511D20
		internal void SetCachedValue(object value); // 0x0000000181511D20-0x0000000181511DB0
	}
}
