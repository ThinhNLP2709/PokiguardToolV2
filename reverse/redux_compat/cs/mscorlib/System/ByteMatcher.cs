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

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	internal class ByteMatcher // TypeDefIndex: 2488
	{
		// Fields
		private Hashtable map; // 0x10
		private Hashtable starts; // 0x18
	
		// Constructors
		public ByteMatcher(); // 0x000000018164C240-0x000000018164C2D0
	
		// Methods
		public void AddMapping(TermInfoStrings key, byte[] val); // 0x000000018164BDF0-0x000000018164BF00
		public void Sort(); // 0x00000001802E76C0-0x00000001802E76D0
		public bool StartsWith(int c); // 0x000000018164C1F0-0x000000018164C240
		public TermInfoStrings Match(char[] buffer, int offset, int length, out int used); // 0x000000018164BF00-0x000000018164C1F0
	}
}
