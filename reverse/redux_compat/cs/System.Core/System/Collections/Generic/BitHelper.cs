/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Collections.Generic
{
	internal sealed class BitHelper // TypeDefIndex: 12596
	{
		// Fields
		private readonly int _length; // 0x10
		private readonly unsafe int* _arrayPtr; // 0x18
		private readonly int[] _array; // 0x20
		private readonly bool _useStackAlloc; // 0x28
	
		// Constructors
		internal unsafe BitHelper(int* bitArrayPtr, int length); // 0x0000000181802C90-0x0000000181802CD0
		internal BitHelper(int[] bitArray, int length); // 0x0000000181802CD0-0x0000000181802D20
	
		// Methods
		internal void MarkBit(int bitPosition); // 0x0000000181802C00-0x0000000181802C70
		internal bool IsMarked(int bitPosition); // 0x0000000181802B80-0x0000000181802C00
		internal static int ToIntArrayLength(int n); // 0x0000000181802C70-0x0000000181802C90
	}
}
