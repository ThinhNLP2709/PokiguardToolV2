/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal struct StyleDataRef<T> : IEquatable<UnityEngine.UIElements.StyleDataRef<T>> // TypeDefIndex: 4662
		where T : struct, IStyleDataGroup<T>
	{
		// Fields
		private static readonly StyleDataType k_Type;
		private static readonly int k_SizeOf;
		private static readonly int k_IntDataCount;
		private unsafe RefCounted* m_Ref;
		private static readonly T k_Default;
	
		// Nested types
		private struct RefCounted // TypeDefIndex: 4663
		{
			// Fields
			private int m_RefCount;
			private uint m_Id;
			public T value;
	
			// Properties
			public int refCount { get; }
	
			// Methods
			public static unsafe RefCounted<T>* Create([IsReadOnly] in ref T value);
			public static unsafe void Dispose(RefCounted<T>* self);
			public void Acquire();
			public void Release();
			public static unsafe RefCounted<T>* Copy(RefCounted<T>* self);
			public static unsafe bool ValueEquals(RefCounted<T>* self, RefCounted<T>* other);
			public static unsafe int GetValueHashCode(RefCounted<T>* self);
		}
	
		// Constructors
		static StyleDataRef();
	
		// Methods
		public bool IsAlive();
		public StyleDataRef<T> Acquire();
		public void Release();
		public void SafeRelease();
		public void CopyFrom(StyleDataRef<T> other);
		[IsReadOnly]
		public unsafe T* GetValuePtr();
		[IsReadOnly]
		public ref ref T Read();
		public ref ref T Write();
		public static StyleDataRef<T> Create();
		public override int GetHashCode();
		public static bool operator ==(StyleDataRef<T> lhs, StyleDataRef<T> rhs);
		public bool Equals(StyleDataRef<T> other);
		public override bool Equals(object obj);
		public bool ReferenceEquals(StyleDataRef<T> other);
	}
}
