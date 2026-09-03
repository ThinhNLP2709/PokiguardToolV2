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
	internal class ObjectHolderListEnumerator // TypeDefIndex: 3040
	{
		// Fields
		private bool m_isFixupEnumerator; // 0x10
		private ObjectHolderList m_list; // 0x18
		private int m_startingVersion; // 0x20
		private int m_currPos; // 0x24
	
		// Properties
		internal ObjectHolder Current { get; } // 0x00000001814F4120-0x00000001814F4160 
	
		// Constructors
		internal ObjectHolderListEnumerator(ObjectHolderList list, bool isFixupEnumerator); // 0x00000001814F40C0-0x00000001814F4120
	
		// Methods
		internal bool MoveNext(); // 0x00000001814F4010-0x00000001814F40C0
	}
}
