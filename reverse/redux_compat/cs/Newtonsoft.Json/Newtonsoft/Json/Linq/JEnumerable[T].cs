/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Linq
{
	[IsReadOnly]
	[Nullable(0)]
	[NullableContext(1)]
	public struct JEnumerable<T> : IJEnumerable<T>, IEquatable<Newtonsoft.Json.Linq.JEnumerable<T>> // TypeDefIndex: 10307
		where T : JToken
	{
		// Fields
		[Nullable(new byte[2] {0, 1 })]
		public static readonly JEnumerable<T> Empty;
		private readonly IEnumerable<T> _enumerable;
	
		// Properties
		public IJEnumerable<JToken> this[object key] { get => default; }
	
		// Constructors
		public JEnumerable(IEnumerable<T> enumerable);
		static JEnumerable();
	
		// Methods
		public IEnumerator<T> GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
		public bool Equals([Nullable(new byte[2] {0, 1 })] JEnumerable<T> other);
		[NullableContext(2)]
		public override bool Equals(object obj);
		public override int GetHashCode();
	}
}
