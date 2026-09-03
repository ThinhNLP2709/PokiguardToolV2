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

namespace System
{
	[IsByRefLike]
	[Obsolete("Types with embedded references are not supported in this version of your compiler.", true)]
	internal struct ByReference<T> // TypeDefIndex: 2399
	{
		// Fields
		private IntPtr _value;
	
		// Properties
		public ref T Value { [Intrinsic] get; }
	
		// Constructors
		[Intrinsic]
		public ByReference(ref ref T value);
	}
}
