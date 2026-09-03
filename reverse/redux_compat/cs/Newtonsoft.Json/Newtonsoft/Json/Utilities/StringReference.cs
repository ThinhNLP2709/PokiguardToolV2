/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Utilities
{
	[IsReadOnly]
	[Nullable(0)]
	[NullableContext(1)]
	internal struct StringReference // TypeDefIndex: 10182
	{
		// Fields
		private readonly char[] _chars; // 0x00
		private readonly int _startIndex; // 0x08
		private readonly int _length; // 0x0C
	
		// Properties
		public char this[int i] { get => default; } // 0x000000018171B440-0x000000018171B470 
		public char[] Chars { get; } // 0x00000001808BADD0-0x00000001808BADE0 
		public int StartIndex { get; } // 0x0000000180732D20-0x0000000180732D30 
		public int Length { get; } // 0x0000000180732D30-0x0000000180732D40 
	
		// Constructors
		public StringReference(char[] chars, int startIndex, int length); // 0x0000000180BE46C0-0x0000000180BE4700
	
		// Methods
		public override string ToString(); // 0x000000018171B410-0x000000018171B440
	}
}
