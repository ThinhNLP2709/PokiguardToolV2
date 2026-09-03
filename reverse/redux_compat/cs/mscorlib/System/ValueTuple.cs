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
	public struct ValueTuple : IEquatable<System.ValueTuple>, IStructuralEquatable, IStructuralComparable, IComparable, IComparable<System.ValueTuple>, IValueTupleInternal // TypeDefIndex: 2367
	{
		// Properties
		int ITuple.Length { get; } // 0x00000001802E7860-0x00000001802E7870 
	
		// Methods
		public override bool Equals(object obj); // 0x0000000181628F70-0x0000000181628FC0
		public bool Equals(ValueTuple other); // 0x00000001802E7990-0x00000001802E79A0
		bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer); // 0x00000001816290D0-0x0000000181629120
		int IComparable.CompareTo(object other); // 0x0000000181629120-0x0000000181629230
		public int CompareTo(ValueTuple other); // 0x00000001802E7860-0x00000001802E7870
		int IStructuralComparable.CompareTo(object other, IComparer comparer); // 0x0000000181628FC0-0x00000001816290D0
		public override int GetHashCode(); // 0x00000001802E7860-0x00000001802E7870
		int IStructuralEquatable.GetHashCode(IEqualityComparer comparer); // 0x00000001802E7860-0x00000001802E7870
		int IValueTupleInternal.GetHashCode(IEqualityComparer comparer); // 0x00000001802E7860-0x00000001802E7870
		public override string ToString(); // 0x0000000181629260-0x0000000181629290
		string IValueTupleInternal.ToStringEnd(); // 0x0000000181629230-0x0000000181629260
		public static ValueTuple<T1, T2> Create<T1, T2>(T1 item1, T2 item2);
		internal static int CombineHashCodes(int h1, int h2); // 0x0000000181628670-0x00000001816286E0
		internal static int CombineHashCodes(int h1, int h2, int h3); // 0x0000000181628CA0-0x0000000181628D60
		internal static int CombineHashCodes(int h1, int h2, int h3, int h4); // 0x0000000181628B90-0x0000000181628CA0
		internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5); // 0x00000001816286E0-0x0000000181628830
		internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6); // 0x0000000181628830-0x00000001816289C0
		internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6, int h7); // 0x00000001816289C0-0x0000000181628B90
		internal static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6, int h7, int h8); // 0x0000000181628D60-0x0000000181628F70
	}
}
