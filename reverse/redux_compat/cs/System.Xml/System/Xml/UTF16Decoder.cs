/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	internal class UTF16Decoder : Decoder // TypeDefIndex: 6877
	{
		// Fields
		private bool bigEndian; // 0x20
		private int lastByte; // 0x24
	
		// Constructors
		public UTF16Decoder(bool bigEndian); // 0x0000000181A93FB0-0x0000000181A93FE0
	
		// Methods
		public override int GetCharCount(byte[] bytes, int index, int count); // 0x00000001814767C0-0x00000001814767F0
		public override int GetCharCount(byte[] bytes, int index, int count, bool flush); // 0x0000000181A93C90-0x0000000181A93D80
		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex); // 0x0000000181A93D80-0x0000000181A93FB0
		public override void Convert(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex, int charCount, bool flush, out int bytesUsed, out int charsUsed, out bool completed); // 0x0000000181A939F0-0x0000000181A93C90
	}
}
