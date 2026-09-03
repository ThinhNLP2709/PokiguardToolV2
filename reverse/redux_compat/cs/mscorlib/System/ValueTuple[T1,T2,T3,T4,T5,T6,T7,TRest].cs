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
	public struct ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest> : IEquatable<System.ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest>>, IStructuralEquatable, IStructuralComparable, IComparable, IComparable<System.ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest>>, IValueTupleInternal // TypeDefIndex: 2373
		where TRest : struct
	{
		// Fields
		public T1 Item1;
		public T2 Item2;
		public T3 Item3;
		public T4 Item4;
		public T5 Item5;
		public T6 Item6;
		public T7 Item7;
		public TRest Rest;
	
		// Properties
		int ITuple.Length { get; }
	
		// Constructors
		public ValueTuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, TRest rest);
	
		// Methods
		public override bool Equals(object obj);
		public bool Equals(ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest> other);
		bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer);
		int IComparable.CompareTo(object other);
		public int CompareTo(ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest> other);
		int IStructuralComparable.CompareTo(object other, IComparer comparer);
		public override int GetHashCode();
		int IStructuralEquatable.GetHashCode(IEqualityComparer comparer);
		private int GetHashCodeCore(IEqualityComparer comparer);
		int IValueTupleInternal.GetHashCode(IEqualityComparer comparer);
		public override string ToString();
		string IValueTupleInternal.ToStringEnd();
	}
}
