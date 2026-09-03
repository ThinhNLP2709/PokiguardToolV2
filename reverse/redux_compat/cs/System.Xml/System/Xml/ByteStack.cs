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
	internal class ByteStack // TypeDefIndex: 6698
	{
		// Fields
		private byte[] stack; // 0x10
		private int growthRate; // 0x18
		private int top; // 0x1C
		private int size; // 0x20
	
		// Constructors
		public ByteStack(int growthRate); // 0x00000001819428D0-0x0000000181942940
	
		// Methods
		public void Push(byte data); // 0x0000000181942800-0x00000001819428D0
		public byte Pop(); // 0x00000001819427B0-0x0000000181942800
	}
}
