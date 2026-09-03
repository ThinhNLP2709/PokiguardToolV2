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
	[Serializable]
	internal class FixupHolderList // TypeDefIndex: 3037
	{
		// Fields
		internal FixupHolder[] m_values; // 0x10
		internal int m_count; // 0x18
	
		// Constructors
		internal FixupHolderList(); // 0x00000001814F3850-0x00000001814F38B0
		internal FixupHolderList(int startingSize); // 0x00000001814F37E0-0x00000001814F3850
	
		// Methods
		internal virtual void Add(FixupHolder fixup); // 0x00000001814F3640-0x00000001814F3750
		private void EnlargeArray(); // 0x00000001814F3750-0x00000001814F37E0
	}
}
