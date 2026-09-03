/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Collections.ObjectModel
{
	[Serializable]
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(CollectionDebugView<T>))]
	public abstract class KeyedCollection<TKey, TItem> : Collection<TItem> // TypeDefIndex: 3553
	{
		// Fields
		private readonly IEqualityComparer<TKey> comparer;
		private Dictionary<TKey, TItem> dict;
		private int keyCount;
		private readonly int threshold;
	
		// Properties
		private new List<TItem> Items { get; }
		public TItem this[TKey key] { get => default; }
		protected IDictionary<TKey, TItem> Dictionary { get; }
	
		// Constructors
		protected KeyedCollection();
		protected KeyedCollection(IEqualityComparer<TKey> comparer);
		protected KeyedCollection(IEqualityComparer<TKey> comparer, int dictionaryCreationThreshold);
	
		// Methods
		public bool Contains(TKey key);
		public bool TryGetValue(TKey key, out ref TItem item);
		protected override void ClearItems();
		protected abstract TKey GetKeyForItem(TItem item);
		protected override void InsertItem(int index, TItem item);
		protected override void RemoveItem(int index);
		protected override void SetItem(int index, TItem item);
		private void AddKey(TKey key, TItem item);
		private void CreateDictionary();
		private void RemoveKey(TKey key);
	}
}
