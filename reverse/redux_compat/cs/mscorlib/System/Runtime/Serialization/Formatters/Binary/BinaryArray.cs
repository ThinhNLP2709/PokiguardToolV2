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
	internal sealed class BinaryArray // TypeDefIndex: 3084
	{
		// Fields
		internal int objectId; // 0x10
		internal int rank; // 0x14
		internal int[] lengthA; // 0x18
		internal int[] lowerBoundA; // 0x20
		internal BinaryTypeEnum binaryTypeEnum; // 0x28
		internal object typeInformation; // 0x30
		internal int assemId; // 0x38
		private BinaryHeaderEnum binaryHeaderEnum; // 0x3C
		internal BinaryArrayTypeEnum binaryArrayTypeEnum; // 0x40
	
		// Constructors
		internal BinaryArray(); // 0x00000001802E5CB0-0x00000001802E5CC0
		internal BinaryArray(BinaryHeaderEnum binaryHeaderEnum); // 0x00000001814EDCC0-0x00000001814EDCF0
	
		// Methods
		internal void Set(int objectId, int rank, int[] lengthA, int[] lowerBoundA, BinaryTypeEnum binaryTypeEnum, object typeInformation, BinaryArrayTypeEnum binaryArrayTypeEnum, int assemId); // 0x00000001814ED890-0x00000001814ED950
		public void Write(__BinaryWriter sout); // 0x00000001814ED950-0x00000001814EDCC0
		public void Read(__BinaryParser input); // 0x00000001814ED340-0x00000001814ED890
	}
}
