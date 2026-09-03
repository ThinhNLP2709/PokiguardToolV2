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
	internal class ObjectEqualityComparer<T> : EqualityComparer<T> // TypeDefIndex: 3615
	{
		// Constructors
		public ObjectEqualityComparer();
	
		// Methods
		public override bool Equals(T x, T y);
		public override int GetHashCode(T obj);
		internal override int IndexOf(T[] array, T value, int startIndex, int count);
		internal override int LastIndexOf(T[] array, T value, int startIndex, int count);
		public override bool Equals(object obj);
		public override int GetHashCode();
	}
}
