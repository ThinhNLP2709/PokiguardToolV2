/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public class ObservableList<T> : IList<T> // TypeDefIndex: 5394
	{
		// Fields
		private readonly List<T> m_List;
		private readonly Comparison<T> m_Comparison;
		[CompilerGenerated]
		private ListChangedEventHandler<T> ItemAdded;
		[CompilerGenerated]
		private ListChangedEventHandler<T> ItemRemoved;
	
		// Properties
		public T this[int index] { get => default; set {} }
		public int Count { get; }
		public bool IsReadOnly { get; }
	
		// Events
		public event ListChangedEventHandler<T> ItemAdded {
			add; // 0x00000000-0x00000000
			remove; // 0x00000000-0x00000000
		}
		public event ListChangedEventHandler<T> ItemRemoved {
			add; // 0x00000000-0x00000000
			remove; // 0x00000000-0x00000000
		}
	
		// Constructors
		public ObservableList();
		public ObservableList(int capacity, Comparison<T> comparison = null);
		public ObservableList(IEnumerable<T> collection, Comparison<T> comparison = null);
	
		// Methods
		private void OnEvent(ListChangedEventHandler<T> e, int index, T item);
		public bool Contains(T item);
		public int IndexOf(T item);
		public void Add(T item);
		public void Add(params T[] items);
		public void AddRange(IEnumerable<T> items);
		public void Insert(int index, T item);
		public void InsertRange(int index, IEnumerable<T> items);
		private void OnItemsAdded(IList<T> items);
		public bool Remove(T item);
		public int Remove(params T[] items);
		public void RemoveAt(int index);
		public void Clear();
		public void CopyTo(T[] array, int arrayIndex);
		public IEnumerator<T> GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator();
		private void Sort();
	}
}
