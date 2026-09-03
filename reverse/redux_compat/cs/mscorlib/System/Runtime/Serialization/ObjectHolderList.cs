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

namespace System.Runtime.Serialization
{
	internal class ObjectHolderList // TypeDefIndex: 3039
	{
		// Fields
		internal ObjectHolder[] m_values; // 0x10
		internal int m_count; // 0x18
	
		// Properties
		internal int Version { get; } // 0x0000000180B23260-0x0000000180B23270 
		internal int Count { get; } // 0x0000000180B23260-0x0000000180B23270 
	
		// Constructors
		internal ObjectHolderList(); // 0x00000001814F4350-0x00000001814F43B0
		internal ObjectHolderList(int startingSize); // 0x00000001814F43B0-0x00000001814F4420
	
		// Methods
		internal virtual void Add(ObjectHolder value); // 0x00000001814F4160-0x00000001814F4240
		internal ObjectHolderListEnumerator GetFixupEnumerator(); // 0x00000001814F42D0-0x00000001814F4350
		private void EnlargeArray(); // 0x00000001814F4240-0x00000001814F42D0
	}
}
