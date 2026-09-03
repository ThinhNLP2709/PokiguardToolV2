/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Resources
{
	internal sealed class FastResourceComparer : IComparer, IEqualityComparer, IComparer<string>, IEqualityComparer<string> // TypeDefIndex: 3258
	{
		// Fields
		internal static readonly FastResourceComparer Default; // 0x00
	
		// Constructors
		public FastResourceComparer(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static FastResourceComparer(); // 0x000000018150C6C0-0x000000018150C730
	
		// Methods
		public int GetHashCode(object key); // 0x000000018150C520-0x000000018150C5D0
		public int GetHashCode(string key); // 0x000000018150C5D0-0x000000018150C660
		internal static int HashFunction(string key); // 0x000000018150C660-0x000000018150C6C0
		public int Compare(object a, object b); // 0x000000018150C420-0x000000018150C490
		public int Compare(string a, string b); // 0x000000018150C400-0x000000018150C420
		public bool Equals(string a, string b); // 0x000000018150C500-0x000000018150C520
		public new bool Equals(object a, object b); // 0x000000018150C490-0x000000018150C500
		public static int CompareOrdinal(string a, byte[] bytes, int bCharLength); // 0x000000018150C330-0x000000018150C400
		public static int CompareOrdinal(byte[] bytes, int aCharLength, string b); // 0x000000018150C190-0x000000018150C280
		internal static unsafe int CompareOrdinal(byte* a, int byteLen, string b); // 0x000000018150C280-0x000000018150C330
	}
}
