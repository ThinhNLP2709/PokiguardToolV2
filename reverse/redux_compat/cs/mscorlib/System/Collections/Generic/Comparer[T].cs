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
	[TypeDependency("System.Collections.Generic.ObjectComparer`1")]
	public abstract class Comparer<T> : IComparer, IComparer<T> // TypeDefIndex: 3608
	{
		// Fields
		private static Comparer<T> defaultComparer;
	
		// Properties
		public static Comparer<T> Default { get; }
	
		// Constructors
		protected Comparer();
	
		// Methods
		private static Comparer<T> CreateComparer();
		public abstract int Compare(T x, T y);
		int IComparer.Compare(object x, object y);
	}
}
