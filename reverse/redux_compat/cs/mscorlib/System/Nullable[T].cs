/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[Serializable]
	[NonVersionable]
	public struct Nullable<T> // TypeDefIndex: 2312
		where T : struct
	{
		// Fields
		private readonly bool hasValue;
		internal T value;
	
		// Properties
		public bool HasValue { [NonVersionable] get; }
		public T Value { get; }
	
		// Constructors
		[NonVersionable]
		public Nullable(T value);
	
		// Methods
		[NonVersionable]
		public T GetValueOrDefault();
		[NonVersionable]
		public T GetValueOrDefault(T defaultValue);
		public override bool Equals(object other);
		public override int GetHashCode();
		public override string ToString();
		private static object Box(T? o);
		private static T? Unbox(object o);
		private static T? UnboxExact(object o);
	}
}
