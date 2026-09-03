/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Serialization.Formatters.Binary
{
	internal sealed class SerializationHeaderRecord // TypeDefIndex: 3072
	{
		// Fields
		internal int binaryFormatterMajorVersion; // 0x10
		internal int binaryFormatterMinorVersion; // 0x14
		internal BinaryHeaderEnum binaryHeaderEnum; // 0x18
		internal int topId; // 0x1C
		internal int headerId; // 0x20
		internal int majorVersion; // 0x24
		internal int minorVersion; // 0x28
	
		// Constructors
		internal SerializationHeaderRecord(); // 0x0000000181501E90-0x0000000181501EA0
		internal SerializationHeaderRecord(BinaryHeaderEnum binaryHeaderEnum, int topId, int headerId, int majorVersion, int minorVersion); // 0x0000000181501EA0-0x0000000181501F00
	
		// Methods
		public void Write(__BinaryWriter sout); // 0x0000000181501DB0-0x0000000181501E90
		private static int GetInt32(byte[] buffer, int index); // 0x0000000181501B00-0x0000000181501B70
		public void Read(__BinaryParser input); // 0x0000000181501B70-0x0000000181501DB0
		public void Dump(); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
