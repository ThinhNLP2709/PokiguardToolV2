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
	internal sealed class BinaryAssembly // TypeDefIndex: 3073
	{
		// Fields
		internal int assemId; // 0x10
		internal string assemblyString; // 0x18
	
		// Constructors
		internal BinaryAssembly(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal void Set(int assemId, string assemblyString); // 0x00000001814EDE70-0x00000001814EDE90
		public void Write(__BinaryWriter sout); // 0x00000001814EDE90-0x00000001814EDF20
		public void Read(__BinaryParser input); // 0x00000001814EDE20-0x00000001814EDE70
		public void Dump(); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
