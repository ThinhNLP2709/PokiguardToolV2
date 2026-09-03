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
	internal class BinHexDecoder : IncrementalReadDecoder // TypeDefIndex: 6682
	{
		// Fields
		private byte[] buffer; // 0x10
		private int curIndex; // 0x18
		private int endIndex; // 0x1C
		private bool hasHalfByteCached; // 0x20
		private byte cachedHalfByte; // 0x21
	
		// Properties
		internal override bool IsFull { get; } // 0x000000018193E040-0x000000018193E050 
	
		// Methods
		internal override int Decode(char[] chars, int startPos, int len); // 0x000000018193DE20-0x000000018193E040
		public static byte[] Decode(char[] chars, bool allowOddChars); // 0x000000018193DA70-0x000000018193DC90
		private static unsafe void Decode(char* pChars, char* pCharsEndPos, byte* pBytes, byte* pBytesEndPos, ref bool hasHalfByteCached, ref byte cachedHalfByte, out int charsDecoded, out int bytesDecoded); // 0x000000018193DC90-0x000000018193DE20
	}
}
