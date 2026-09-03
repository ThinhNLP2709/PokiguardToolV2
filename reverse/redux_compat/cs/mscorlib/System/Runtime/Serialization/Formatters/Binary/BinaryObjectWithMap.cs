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
	internal sealed class BinaryObjectWithMap // TypeDefIndex: 3082
	{
		// Fields
		internal BinaryHeaderEnum binaryHeaderEnum; // 0x10
		internal int objectId; // 0x14
		internal string name; // 0x18
		internal int numMembers; // 0x20
		internal string[] memberNames; // 0x28
		internal int assemId; // 0x30
	
		// Constructors
		internal BinaryObjectWithMap(); // 0x00000001802E5CB0-0x00000001802E5CC0
		internal BinaryObjectWithMap(BinaryHeaderEnum binaryHeaderEnum); // 0x00000001802F9040-0x00000001802F9070
	
		// Methods
		internal void Set(int objectId, string name, int numMembers, string[] memberNames, int assemId); // 0x00000001814F08F0-0x00000001814F0950
		public void Write(__BinaryWriter sout); // 0x00000001814F0950-0x00000001814F0A90
		public void Read(__BinaryParser input); // 0x00000001814F07C0-0x00000001814F08F0
		public void Dump(); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
