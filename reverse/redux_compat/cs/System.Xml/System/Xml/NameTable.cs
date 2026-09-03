/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	public class NameTable : XmlNameTable // TypeDefIndex: 6855
	{
		// Fields
		private Entry[] entries; // 0x10
		private int count; // 0x18
		private int mask; // 0x1C
		private int hashCodeRandomizer; // 0x20
	
		// Nested types
		private class Entry // TypeDefIndex: 6856
		{
			// Fields
			internal string str; // 0x10
			internal int hashCode; // 0x18
			internal Entry next; // 0x20
	
			// Constructors
			internal Entry(string str, int hashCode, Entry next); // 0x0000000181696D70-0x0000000181696DD0
		}
	
		// Constructors
		public NameTable(); // 0x0000000181A80080-0x0000000181A800F0
	
		// Methods
		public override string Add(string key); // 0x0000000181A7FA50-0x0000000181A7FBC0
		public override string Add(char[] key, int start, int len); // 0x0000000181A7FBC0-0x0000000181A7FDB0
		public override string Get(string value); // 0x0000000181A7FDB0-0x0000000181A7FF10
		private string AddEntry(string str, int hashCode); // 0x0000000181A7F7E0-0x0000000181A7FA50
		private void Grow(); // 0x0000000181A7FF10-0x0000000181A80080
		private static bool TextEquals(string str1, char[] str2, int str2Start, int str2Length); // 0x0000000181696C30-0x0000000181696CD0
	}
}
