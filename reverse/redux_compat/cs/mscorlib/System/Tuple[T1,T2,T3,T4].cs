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
using System.Text;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[Serializable]
	public class Tuple<T1, T2, T3, T4> : IStructuralEquatable, IStructuralComparable, IComparable, ITupleInternal // TypeDefIndex: 2355
	{
		// Fields
		private readonly T1 m_Item1;
		private readonly T2 m_Item2;
		private readonly T3 m_Item3;
		private readonly T4 m_Item4;
	
		// Properties
		public T1 Item1 { get; }
		public T2 Item2 { get; }
		public T3 Item3 { get; }
		public T4 Item4 { get; }
		int ITuple.Length { get; }
	
		// Constructors
		public Tuple(T1 item1, T2 item2, T3 item3, T4 item4);
	
		// Methods
		public override bool Equals(object obj);
		bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer);
		int IComparable.CompareTo(object obj);
		int IStructuralComparable.CompareTo(object other, IComparer comparer);
		public override int GetHashCode();
		int IStructuralEquatable.GetHashCode(IEqualityComparer comparer);
		public override string ToString();
		string ITupleInternal.ToString(StringBuilder sb);
	}
}
