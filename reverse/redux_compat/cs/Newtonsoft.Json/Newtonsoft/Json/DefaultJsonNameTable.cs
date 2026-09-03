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

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json
{
	[Nullable(0)]
	[NullableContext(1)]
	public class DefaultJsonNameTable : JsonNameTable // TypeDefIndex: 9959
	{
		// Fields
		private static readonly int HashCodeRandomizer; // 0x00
		private int _count; // 0x10
		private Entry[] _entries; // 0x18
		private int _mask; // 0x20
	
		// Nested types
		[Nullable(0)]
		private class Entry // TypeDefIndex: 9960
		{
			// Fields
			internal readonly string Value; // 0x10
			internal readonly int HashCode; // 0x18
			internal Entry Next; // 0x20
	
			// Constructors
			internal Entry(string value, int hashCode, Entry next); // 0x0000000181696D70-0x0000000181696DD0
		}
	
		// Constructors
		static DefaultJsonNameTable(); // 0x0000000181696CD0-0x0000000181696D10
		public DefaultJsonNameTable(); // 0x0000000181696D10-0x0000000181696D70
	
		// Methods
		public override string Get(char[] key, int start, int length); // 0x00000001816968D0-0x0000000181696AC0
		public string Add(string key); // 0x0000000181696710-0x00000001816968D0
		private string AddEntry(string str, int hashCode); // 0x0000000181696490-0x0000000181696710
		private void Grow(); // 0x0000000181696AC0-0x0000000181696C30
		private static bool TextEquals(string str1, char[] str2, int str2Start, int str2Length); // 0x0000000181696C30-0x0000000181696CD0
	}
}
