/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace Mono.Globalization.Unicode
{
	internal class SortKeyBuffer // TypeDefIndex: 2118
	{
		// Fields
		private byte[] l1b; // 0x10
		private byte[] l2b; // 0x18
		private byte[] l3b; // 0x20
		private byte[] l4sb; // 0x28
		private byte[] l4tb; // 0x30
		private byte[] l4kb; // 0x38
		private byte[] l4wb; // 0x40
		private byte[] l5b; // 0x48
		private string source; // 0x50
		private int l1; // 0x58
		private int l2; // 0x5C
		private int l3; // 0x60
		private int l4s; // 0x64
		private int l4t; // 0x68
		private int l4k; // 0x6C
		private int l4w; // 0x70
		private int l5; // 0x74
		private int lcid; // 0x78
		private CompareOptions options; // 0x7C
		private bool processLevel2; // 0x80
		private bool frenchSort; // 0x81
		private bool frenchSorted; // 0x82
	
		// Constructors
		public SortKeyBuffer(int lcid); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void Reset(); // 0x000000018143D780-0x000000018143D7A0
		internal void Initialize(CompareOptions options, int lcid, string s, bool frenchSort); // 0x000000018143D580-0x000000018143D780
		internal void AppendCJKExtension(byte lv1msb, byte lv1lsb); // 0x000000018143C9F0-0x000000018143CAC0
		internal void AppendKana(byte category, byte lv1, byte lv2, byte lv3, bool isSmallKana, byte markType, bool isKatakana, bool isHalfWidth); // 0x000000018143CAC0-0x000000018143CB90
		internal void AppendNormal(byte category, byte lv1, byte lv2, byte lv3); // 0x000000018143CC70-0x000000018143CE60
		private void AppendLevel5(byte category, byte lv1); // 0x000000018143CB90-0x000000018143CC70
		private void AppendBufferPrimitive(byte value, ref byte[] buf, ref int bidx); // 0x000000018143C930-0x000000018143C9F0
		public SortKey GetResultAndReset(); // 0x000000018143CEB0-0x000000018143CEE0
		private int GetOptimizedLength(byte[] data, int len, byte defaultValue); // 0x000000018143CE60-0x000000018143CEB0
		public SortKey GetResult(); // 0x000000018143CEE0-0x000000018143D580
	}
}
