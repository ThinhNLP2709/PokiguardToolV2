/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	[IsReadOnly]
	internal struct IndexField // TypeDefIndex: 11314
	{
		// Fields
		public readonly DataColumn Column; // 0x00
		public readonly bool IsDescending; // 0x08
	
		// Constructors
		internal IndexField(DataColumn column, bool isDescending); // 0x0000000180DE29B0-0x0000000180DE29E0
	
		// Methods
		public static bool operator ==(IndexField if1, IndexField if2); // 0x0000000181894C00-0x0000000181894C20
		public override bool Equals(object obj); // 0x0000000181894B10-0x0000000181894BA0
		public override int GetHashCode(); // 0x0000000181894BA0-0x0000000181894C00
	}
}
