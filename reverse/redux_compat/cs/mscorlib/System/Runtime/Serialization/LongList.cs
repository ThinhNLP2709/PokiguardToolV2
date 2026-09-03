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
	internal class LongList // TypeDefIndex: 3038
	{
		// Fields
		private long[] m_values; // 0x10
		private int m_count; // 0x18
		private int m_totalItems; // 0x1C
		private int m_currentItem; // 0x20
	
		// Properties
		internal int Count { get; } // 0x0000000180B23260-0x0000000180B23270 
		internal long Current { get; } // 0x00000001814F3DF0-0x00000001814F3E20 
	
		// Constructors
		internal LongList(); // 0x00000001814F3D20-0x00000001814F3D80
		internal LongList(int startingSize); // 0x00000001814F3D80-0x00000001814F3DF0
	
		// Methods
		internal void Add(long value); // 0x00000001814F3AF0-0x00000001814F3BC0
		internal void StartEnumeration(); // 0x0000000181109DA0-0x0000000181109DB0
		internal bool MoveNext(); // 0x00000001814F3C50-0x00000001814F3CA0
		internal bool RemoveElement(long value); // 0x00000001814F3CA0-0x00000001814F3D20
		private void EnlargeArray(); // 0x00000001814F3BC0-0x00000001814F3C50
	}
}
