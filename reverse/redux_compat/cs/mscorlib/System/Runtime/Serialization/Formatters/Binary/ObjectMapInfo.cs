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
	internal sealed class ObjectMapInfo // TypeDefIndex: 3094
	{
		// Fields
		internal int objectId; // 0x10
		private int numMembers; // 0x14
		private string[] memberNames; // 0x18
		private Type[] memberTypes; // 0x20
	
		// Constructors
		internal ObjectMapInfo(int objectId, int numMembers, string[] memberNames, Type[] memberTypes); // 0x00000001814F5360-0x00000001814F53D0
	
		// Methods
		internal bool isCompatible(int numMembers, string[] memberNames, Type[] memberTypes); // 0x00000001814F53D0-0x00000001814F5510
	}
}
