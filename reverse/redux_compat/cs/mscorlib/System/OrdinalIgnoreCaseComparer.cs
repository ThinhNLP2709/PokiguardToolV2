/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[Serializable]
	internal sealed class OrdinalIgnoreCaseComparer : OrdinalComparer, ISerializable // TypeDefIndex: 2342
	{
		// Constructors
		public OrdinalIgnoreCaseComparer(); // 0x0000000181617570-0x00000001816175C0
	
		// Methods
		public override int Compare(string x, string y); // 0x0000000181617420-0x0000000181617440
		public override bool Equals(string x, string y); // 0x0000000181617440-0x0000000181617460
		public override int GetHashCode(string obj); // 0x0000000181617460-0x00000001816174C0
		public void GetObjectData(SerializationInfo info, StreamingContext context); // 0x00000001816174C0-0x0000000181617570
	}
}
