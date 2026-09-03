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
	internal class Ucs4Encoding : Encoding // TypeDefIndex: 6879
	{
		// Fields
		internal Ucs4Decoder ucs4Decoder; // 0x38
	
		// Properties
		public override string WebName { get; } // 0x0000000181624290-0x00000001816242B0 
		public override int CodePage { get; } // 0x00000001802E7860-0x00000001802E7870 
		internal static Encoding UCS4_Littleendian { get; } // 0x0000000181A95840-0x0000000181A95910 
		internal static Encoding UCS4_Bigendian { get; } // 0x0000000181A95770-0x0000000181A95840 
		internal static Encoding UCS4_2143 { get; } // 0x0000000181A955D0-0x0000000181A956A0 
		internal static Encoding UCS4_3412 { get; } // 0x0000000181A956A0-0x0000000181A95770 
	
		// Constructors
		public Ucs4Encoding(); // 0x0000000181A955C0-0x0000000181A955D0
	
		// Methods
		public override Decoder GetDecoder(); // 0x00000001803272A0-0x00000001803272B0
		public override int GetByteCount(char[] chars, int index, int count); // 0x0000000181A954D0-0x0000000181A95540
		public override byte[] GetBytes(string s); // 0x00000001802E7860-0x00000001802E7870
		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex); // 0x00000001802E7860-0x00000001802E7870
		public override int GetMaxByteCount(int charCount); // 0x00000001802E7860-0x00000001802E7870
		public override int GetCharCount(byte[] bytes, int index, int count); // 0x0000000181A95540-0x0000000181A95570
		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex); // 0x0000000181A95570-0x0000000181A955B0
		public override int GetMaxCharCount(int byteCount); // 0x0000000181A955B0-0x0000000181A955C0
		public override Encoder GetEncoder(); // 0x00000001802E7860-0x00000001802E7870
	}
}
