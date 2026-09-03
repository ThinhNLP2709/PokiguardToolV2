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
	internal abstract class Base64Encoder // TypeDefIndex: 6679
	{
		// Fields
		private byte[] leftOverBytes; // 0x10
		private int leftOverBytesCount; // 0x18
		private char[] charsLine; // 0x20
	
		// Constructors
		internal Base64Encoder(); // 0x000000018193DA10-0x000000018193DA70
	
		// Methods
		internal abstract void WriteChars(char[] chars, int index, int count);
		internal void Encode(byte[] buffer, int index, int count); // 0x000000018193D580-0x000000018193D940
		internal void Flush(); // 0x000000018193D940-0x000000018193DA10
	}
}
