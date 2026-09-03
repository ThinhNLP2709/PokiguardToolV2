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

namespace Mono.Globalization.Unicode
{
	internal class CodePointIndexer // TypeDefIndex: 2103
	{
		// Fields
		private readonly TableRange[] ranges; // 0x10
		public readonly int TotalCount; // 0x18
		private int defaultIndex; // 0x1C
		private int defaultCP; // 0x20
	
		// Nested types
		[Serializable]
		internal struct TableRange // TypeDefIndex: 2104
		{
			// Fields
			public readonly int Start; // 0x00
			public readonly int End; // 0x04
			public readonly int Count; // 0x08
			public readonly int IndexStart; // 0x0C
			public readonly int IndexEnd; // 0x10
	
			// Constructors
			public TableRange(int start, int end, int indexStart); // 0x000000018143D900-0x000000018143D920
		}
	
		// Constructors
		public CodePointIndexer(int[] starts, int[] ends, int defaultIndex, int defaultCP); // 0x000000018142DF50-0x000000018142E110
	
		// Methods
		public int ToIndex(int cp); // 0x000000018142DED0-0x000000018142DF50
	}
}
