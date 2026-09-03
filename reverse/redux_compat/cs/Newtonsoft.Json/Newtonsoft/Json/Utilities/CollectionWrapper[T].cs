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

namespace Newtonsoft.Json.Utilities
{
	[Nullable(0)]
	[NullableContext(1)]
	internal class CollectionWrapper<T> : ICollection<T>, IWrappedCollection // TypeDefIndex: 10101
	{
		// Fields
		[Nullable(2)]
		private readonly IList _list;
		[Nullable(new byte[2] {2, 1 })]
		private readonly ICollection<T> _genericCollection;
		[Nullable(2)]
		private object _syncRoot;
	
		// Properties
		public virtual int Count { get; }
		public virtual bool IsReadOnly { get; }
		bool IList.IsFixedSize { get; }
		[Nullable(2)]
		object IList.this[int index] { [NullableContext(2)] get => default; [NullableContext(2)] set {} }
		bool ICollection.IsSynchronized { get; }
		object ICollection.SyncRoot { get; }
		public object UnderlyingCollection { get; }
	
		// Constructors
		public CollectionWrapper(IList list);
		public CollectionWrapper(ICollection<T> list);
	
		// Methods
		public virtual void Add(T item);
		public virtual void Clear();
		public virtual bool Contains(T item);
		public virtual void CopyTo(T[] array, int arrayIndex);
		public virtual bool Remove(T item);
		public virtual IEnumerator<T> GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
		[NullableContext(2)]
		int IList.Add(object value);
		[NullableContext(2)]
		bool IList.Contains(object value);
		[NullableContext(2)]
		int IList.IndexOf(object value);
		void IList.RemoveAt(int index);
		[NullableContext(2)]
		void IList.Insert(int index, object value);
		[NullableContext(2)]
		void IList.Remove(object value);
		void ICollection.CopyTo(Array array, int arrayIndex);
		[NullableContext(2)]
		private static void VerifyValueType(object value);
		[NullableContext(2)]
		private static bool IsCompatibleObject(object value);
	}
}
