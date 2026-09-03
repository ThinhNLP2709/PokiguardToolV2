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

namespace System.Reflection
{
	internal sealed class SignatureArrayType : SignatureHasElementType // TypeDefIndex: 3319
	{
		// Fields
		private readonly int _rank; // 0x20
		private readonly bool _isMultiDim; // 0x24
	
		// Properties
		public sealed override bool IsSZArray { get; } // 0x000000018153BC40-0x000000018153BC50 
		public sealed override bool IsVariableBoundArray { get; } // 0x000000018153BC50-0x000000018153BC60 
		protected sealed override string Suffix { get; } // 0x000000018153BC60-0x000000018153BD10 
	
		// Constructors
		internal SignatureArrayType(SignatureType elementType, int rank, bool isMultiDim); // 0x000000018153BBD0-0x000000018153BC40
	
		// Methods
		protected sealed override bool IsArrayImpl(); // 0x00000001802E7990-0x00000001802E79A0
		protected sealed override bool IsByRefImpl(); // 0x00000001802E7840-0x00000001802E7850
		protected sealed override bool IsPointerImpl(); // 0x00000001802E7840-0x00000001802E7850
		public sealed override int GetArrayRank(); // 0x0000000180C4F680-0x0000000180C4F690
	}
}
