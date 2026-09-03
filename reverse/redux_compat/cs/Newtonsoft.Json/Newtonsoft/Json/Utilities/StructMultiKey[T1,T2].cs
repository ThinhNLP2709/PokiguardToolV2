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

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Utilities
{
	[IsReadOnly]
	[Nullable(0)]
	[NullableContext(1)]
	internal struct StructMultiKey<T1, T2> : IEquatable<Newtonsoft.Json.Utilities.StructMultiKey<T1, T2>> // TypeDefIndex: 10187
	{
		// Fields
		public readonly T1 Value1;
		public readonly T2 Value2;
	
		// Constructors
		public StructMultiKey(T1 v1, T2 v2);
	
		// Methods
		public override int GetHashCode();
		[NullableContext(2)]
		public override bool Equals(object obj);
		public bool Equals([Nullable(new byte[3] {0, 1, 1 })] StructMultiKey<T1, T2> other);
	}
}
