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

namespace System
{
	[Serializable]
	public struct ValueTuple<T1> : IEquatable<System.ValueTuple<T1>>, IStructuralEquatable, IStructuralComparable, IComparable, IComparable<System.ValueTuple<T1>>, IValueTupleInternal // TypeDefIndex: 2368
	{
		// Fields
		public T1 Item1;
	
		// Properties
		int ITuple.Length { get; }
	
		// Constructors
		public ValueTuple(T1 item1);
	
		// Methods
		public override bool Equals(object obj);
		public bool Equals(ValueTuple<T1> other);
		bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer);
		int IComparable.CompareTo(object other);
		public int CompareTo(ValueTuple<T1> other);
		int IStructuralComparable.CompareTo(object other, IComparer comparer);
		public override int GetHashCode();
		int IStructuralEquatable.GetHashCode(IEqualityComparer comparer);
		int IValueTupleInternal.GetHashCode(IEqualityComparer comparer);
		public override string ToString();
		string IValueTupleInternal.ToStringEnd();
	}
}
