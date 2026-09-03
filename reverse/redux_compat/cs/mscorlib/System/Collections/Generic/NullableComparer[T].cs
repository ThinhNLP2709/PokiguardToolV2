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

namespace System.Collections.Generic
{
	[Serializable]
	internal class NullableComparer<T> : Comparer<T?> // TypeDefIndex: 3610
		where T : struct, IComparable<T>
	{
		// Constructors
		public NullableComparer();
	
		// Methods
		public override int Compare(T? x, T? y);
		public override bool Equals(object obj);
		public override int GetHashCode();
	}
}
