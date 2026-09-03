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

namespace System.Collections.Generic
{
	[Serializable]
	internal class ByteEqualityComparer : EqualityComparer<byte> // TypeDefIndex: 3616
	{
		// Constructors
		public ByteEqualityComparer(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public override bool Equals(byte x, byte y); // 0x00000001815A7240-0x00000001815A7250
		public override int GetHashCode(byte b); // 0x0000000180C73770-0x0000000180C73790
		internal override int IndexOf(byte[] array, byte value, int startIndex, int count); // 0x00000001815A72D0-0x00000001815A74D0
		internal override int LastIndexOf(byte[] array, byte value, int startIndex, int count); // 0x00000001815A74D0-0x00000001815A7530
		public override bool Equals(object obj); // 0x00000001815A7250-0x00000001815A72D0
		public override int GetHashCode(); // 0x0000000180C63CE0-0x0000000180C63D30
	}
}
