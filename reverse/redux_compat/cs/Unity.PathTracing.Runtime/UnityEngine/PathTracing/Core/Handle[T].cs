/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Core
{
	[IsReadOnly]
	internal struct Handle<T> // TypeDefIndex: 13576
	{
		// Fields
		public readonly ulong Value;
		public static readonly Handle<T> Invalid;
	
		// Constructors
		public Handle(ulong value);
		static Handle();
	
		// Methods
		public bool IsValid();
		internal int ToInt();
		public override int GetHashCode();
		public override bool Equals(object obj);
		public override string ToString();
		public static bool operator ==(Handle<T> a, Handle<T> b);
		public static bool operator !=(Handle<T> a, Handle<T> b);
	}
}
