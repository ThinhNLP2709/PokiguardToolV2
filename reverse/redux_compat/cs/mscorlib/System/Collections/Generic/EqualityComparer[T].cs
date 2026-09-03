/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Collections.Generic
{
	[Serializable]
	[TypeDependency("System.Collections.Generic.ObjectEqualityComparer`1")]
	public abstract class EqualityComparer<T> : IEqualityComparer, IEqualityComparer<T> // TypeDefIndex: 3612
	{
		// Fields
		private static EqualityComparer<T> defaultComparer;
	
		// Properties
		public static EqualityComparer<T> Default { get; }
	
		// Constructors
		protected EqualityComparer();
	
		// Methods
		private static EqualityComparer<T> CreateComparer();
		public abstract bool Equals(T x, T y);
		public abstract int GetHashCode(T obj);
		internal virtual int IndexOf(T[] array, T value, int startIndex, int count);
		internal virtual int LastIndexOf(T[] array, T value, int startIndex, int count);
		int IEqualityComparer.GetHashCode(object obj);
		bool IEqualityComparer.Equals(object x, object y);
	}
}
