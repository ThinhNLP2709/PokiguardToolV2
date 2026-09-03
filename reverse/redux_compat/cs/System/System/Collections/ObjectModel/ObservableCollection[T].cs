/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Collections.ObjectModel
{
	[Serializable]
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(CollectionDebugView<T>))]
	public class ObservableCollection<T> : Collection<T>, INotifyCollectionChanged, INotifyPropertyChanged // TypeDefIndex: 8946
	{
		// Fields
		private SimpleMonitor _monitor;
		[NonSerialized]
		private int _blockReentrancyCount;
		[NonSerialized]
		[CompilerGenerated]
		private NotifyCollectionChangedEventHandler CollectionChanged;
		[NonSerialized]
		[CompilerGenerated]
		private PropertyChangedEventHandler PropertyChanged;
	
		// Events
		public virtual event NotifyCollectionChangedEventHandler CollectionChanged {
			add; // 0x00000000-0x00000000
			remove; // 0x00000000-0x00000000
		}
	
		// Nested types
		[Serializable]
		private sealed class SimpleMonitor : IDisposable // TypeDefIndex: 8947
		{
			// Fields
			internal int _busyCount;
			[NonSerialized]
			internal ObservableCollection<T> _collection;
	
			// Constructors
			public SimpleMonitor(ObservableCollection<T> collection);
	
			// Methods
			public void Dispose();
		}
	
		// Constructors
		public ObservableCollection();
		public ObservableCollection(List<T> list);
	
		// Methods
		private static List<T> CreateCopy(IEnumerable<T> collection, string paramName);
		protected override void ClearItems();
		protected override void RemoveItem(int index);
		protected override void InsertItem(int index, T item);
		protected override void SetItem(int index, T item);
		protected virtual void OnPropertyChanged(PropertyChangedEventArgs e);
		protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e);
		protected void CheckReentrancy();
		private void OnCountPropertyChanged();
		private void OnIndexerPropertyChanged();
		private void OnCollectionChanged(NotifyCollectionChangedAction action, object item, int index);
		private void OnCollectionChanged(NotifyCollectionChangedAction action, object oldItem, object newItem, int index);
		private void OnCollectionReset();
		private SimpleMonitor EnsureMonitorInitialized();
		[OnSerializing]
		private void OnSerializing(StreamingContext context);
		[OnDeserialized]
		private void OnDeserialized(StreamingContext context);
	}
}
