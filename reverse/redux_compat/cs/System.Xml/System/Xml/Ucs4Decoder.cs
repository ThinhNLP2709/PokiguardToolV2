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
	internal abstract class Ucs4Decoder : Decoder // TypeDefIndex: 6884
	{
		// Fields
		internal byte[] lastBytes; // 0x20
		internal int lastBytesCount; // 0x28
	
		// Constructors
		protected Ucs4Decoder(); // 0x0000000181A942A0-0x0000000181A94300
	
		// Methods
		public override int GetCharCount(byte[] bytes, int index, int count); // 0x0000000181A94D90-0x0000000181A94DA0
		internal abstract int GetFullChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex);
		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex); // 0x0000000181A94DA0-0x0000000181A94F60
		public override void Convert(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex, int charCount, bool flush, out int bytesUsed, out int charsUsed, out bool completed); // 0x0000000181A94B40-0x0000000181A94D90
		internal void Ucs4ToUTF16(uint code, char[] chars, int charIndex); // 0x0000000181A94F60-0x0000000181A94FD0
	}
}
