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

namespace System.Numerics
{
	[Intrinsic]
	public struct Vector<T> : IEquatable<Vector<T>>, IFormattable // TypeDefIndex: 3385
		where T : struct
	{
		// Fields
		private Register register;
		private static readonly int s_count;
		private static readonly Vector<T> s_zero;
		private static readonly Vector<T> s_one;
		private static readonly Vector<T> s_allOnes;
	
		// Properties
		public static int Count { [Intrinsic] get; }
		public static Vector<T> Zero { [Intrinsic] get; }
		public T this[int index] { [Intrinsic] get => default; }
	
		// Nested types
		private struct VectorSizeHelper // TypeDefIndex: 3386
		{
			// Fields
			internal Vector<T> _placeholder;
			internal byte _byte;
		}
	
		// Constructors
		[Intrinsic]
		public Vector(T value);
		internal unsafe Vector(void* dataPointer);
		internal unsafe Vector(void* dataPointer, int offset);
		private Vector(ref Register existingRegister);
		static Vector();
	
		// Methods
		private static int InitializeCount();
		public override bool Equals(object obj);
		[Intrinsic]
		public bool Equals(Vector<T> other);
		public override int GetHashCode();
		public override string ToString();
		public string ToString(string format, IFormatProvider formatProvider);
		public static bool operator ==(Vector<T> left, Vector<T> right);
		public static bool operator !=(Vector<T> left, Vector<T> right);
		[CLSCompliant(false)]
		[Intrinsic]
		public static explicit operator Numerics.Vector<ulong>(Vector<T> value);
		[Intrinsic]
		internal static Vector<T> Equals(Vector<T> left, Vector<T> right);
		private static bool ScalarEquals(T left, T right);
		private static T GetOneValue();
		private static T GetAllBitsSetValue();
	}
}
