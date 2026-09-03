/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Linq
{
	[Nullable(0)]
	[NullableContext(1)]
	public abstract class JContainer : JToken, IList<JToken>, ITypedList, IBindingList, INotifyCollectionChanged // TypeDefIndex: 10303
	{
		// Fields
		[Nullable(2)]
		internal ListChangedEventHandler _listChanged; // 0x30
		[Nullable(2)]
		internal AddingNewEventHandler _addingNew; // 0x38
		[Nullable(2)]
		internal NotifyCollectionChangedEventHandler _collectionChanged; // 0x40
		[Nullable(2)]
		private object _syncRoot; // 0x48
		private bool _busy; // 0x50
	
		// Properties
		protected abstract IList<JToken> ChildrenTokens { get; }
		public override bool HasValues { get; } // 0x000000018173E620-0x000000018173E690 
		[Nullable(2)]
		public override JToken First { [NullableContext(2)] get; } // 0x000000018173E590-0x000000018173E620 
		[Nullable(2)]
		public override JToken Last { [NullableContext(2)] get; } // 0x000000018173E690-0x000000018173E720 
		JToken IList<Newtonsoft.Json.Linq.JToken>.this[int index] { get => default; set {} } // 0x000000018171F980-0x000000018171F9A0 0x000000018171F9A0-0x000000018171F9C0
		bool ICollection<Newtonsoft.Json.Linq.JToken>.IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
		bool IList.IsFixedSize { get; } // 0x00000001802E7840-0x00000001802E7850 
		bool IList.IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
		[Nullable(2)]
		object IList.this[int index] { [NullableContext(2)] get => default; [NullableContext(2)] set {} } // 0x000000018171F980-0x000000018171F9A0 0x000000018173D5B0-0x000000018173D600
		public int Count { get; } // 0x000000018173E530-0x000000018173E590 
		bool ICollection.IsSynchronized { get; } // 0x00000001802E7840-0x00000001802E7850 
		object ICollection.SyncRoot { get; } // 0x00000001810CC750-0x00000001810CC7C0 
		bool IBindingList.AllowEdit { get; } // 0x00000001802E7990-0x00000001802E79A0 
		bool IBindingList.AllowNew { get; } // 0x00000001802E7990-0x00000001802E79A0 
		bool IBindingList.AllowRemove { get; } // 0x00000001802E7990-0x00000001802E79A0 
		bool IBindingList.IsSorted { get; } // 0x00000001802E7840-0x00000001802E7850 
		ListSortDirection IBindingList.SortDirection { get; } // 0x00000001802E7860-0x00000001802E7870 
		[Nullable(2)]
		PropertyDescriptor IBindingList.SortProperty { [NullableContext(2)] get; } // 0x00000001802E7860-0x00000001802E7870 
		bool IBindingList.SupportsChangeNotification { get; } // 0x00000001802E7990-0x00000001802E79A0 
		bool IBindingList.SupportsSearching { get; } // 0x00000001802E7840-0x00000001802E7850 
		bool IBindingList.SupportsSorting { get; } // 0x00000001802E7840-0x00000001802E7850 
	
		// Events
		public event ListChangedEventHandler ListChanged {
			add; // 0x000000018173E490-0x000000018173E530
			remove; // 0x000000018173E860-0x000000018173E900
		}
		public event AddingNewEventHandler AddingNew {
			add; // 0x000000018173E350-0x000000018173E3F0
			remove; // 0x000000018173E720-0x000000018173E7C0
		}
		[Nullable(2)]
		public event NotifyCollectionChangedEventHandler CollectionChanged {
			add; // 0x000000018173E3F0-0x000000018173E490
			remove; // 0x000000018173E7C0-0x000000018173E860
		}
	
		// Nested types
		[CompilerGenerated]
		private sealed class _GetDescendants_d__36 : IEnumerable<JToken>, IEnumerator<JToken> // TypeDefIndex: 10304
		{
			// Fields
			private int __1__state; // 0x10
			private JToken __2__current; // 0x18
			private int __l__initialThreadId; // 0x20
			private bool self; // 0x24
			public bool __3__self; // 0x25
			[Nullable(0)]
			public JContainer __4__this; // 0x28
			[Nullable(new byte[2] {0, 1 })]
			private IEnumerator<JToken> __7__wrap1; // 0x30
			[Nullable(0)]
			private JToken _o_5__3; // 0x38
			[Nullable(new byte[2] {0, 1 })]
			private IEnumerator<JToken> __7__wrap3; // 0x40
	
			// Properties
			JToken IEnumerator<Newtonsoft.Json.Linq.JToken>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _GetDescendants_d__36(int __1__state); // 0x0000000180A5D530-0x0000000180A5D560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000181751950-0x0000000181751AD0
			private bool MoveNext(); // 0x0000000181751440-0x0000000181751860
			private void __m__Finally1(); // 0x0000000181751AD0-0x0000000181751B20
			private void __m__Finally2(); // 0x0000000181751B20-0x0000000181751B70
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000181751910-0x0000000181751950
			[DebuggerHidden]
			IEnumerator<JToken> IEnumerable<JToken>.GetEnumerator(); // 0x0000000181751860-0x0000000181751910
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181751860-0x0000000181751910
		}
	
		[CompilerGenerated]
		private struct _ReadContentFromAsync_d__1 : IAsyncStateMachine // TypeDefIndex: 10305
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public JsonReader reader; // 0x20
			[Nullable(0)]
			public JContainer __4__this; // 0x28
			[Nullable(0)]
			public JsonLoadSettings settings; // 0x30
			public CancellationToken cancellationToken; // 0x38
			[Nullable(0)]
			private IJsonLineInfo _lineInfo_5__2; // 0x40
			[Nullable(0)]
			private JContainer _parent_5__3; // 0x48
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x50
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__2; // 0x60
	
			// Methods
			private void MoveNext(); // 0x00000001817532B0-0x0000000181753C40
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x0000000181753C40-0x0000000181753CA0
		}
	
		[CompilerGenerated]
		private struct _ReadTokenFromAsync_d__0 : IAsyncStateMachine // TypeDefIndex: 10306
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public JsonReader reader; // 0x20
			public CancellationToken cancellationToken; // 0x28
			[Nullable(0)]
			public JContainer __4__this; // 0x30
			[Nullable(0)]
			public JsonLoadSettings options; // 0x38
			private int _startDepth_5__2; // 0x40
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__1; // 0x48
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__2; // 0x58
	
			// Methods
			private void MoveNext(); // 0x0000000181754600-0x0000000181754B60
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x0000000181754B60-0x0000000181754BC0
		}
	
		// Constructors
		internal JContainer(); // 0x000000018173DFF0-0x000000018173E040
		internal JContainer(JContainer other, [Nullable(2)] JsonCloneSettings settings); // 0x000000018173E040-0x000000018173E350
	
		// Methods
		internal async Task ReadTokenFromAsync(JsonReader reader, [Nullable(2)] JsonLoadSettings options, CancellationToken cancellationToken = default); // 0x000000018173C860-0x000000018173C9A0
		private async Task ReadContentFromAsync(JsonReader reader, [Nullable(2)] JsonLoadSettings settings, CancellationToken cancellationToken = default); // 0x000000018173BEF0-0x000000018173C030
		internal void CheckReentrancy(); // 0x000000018173A030-0x000000018173A0E0
		internal virtual IList<JToken> CreateChildrenCollection(); // 0x000000018173AAC0-0x000000018173AB20
		protected virtual void OnAddingNew(AddingNewEventArgs e); // 0x000000018136EEF0-0x000000018136EF10
		protected virtual void OnListChanged(ListChangedEventArgs e); // 0x000000018173BE70-0x000000018173BEF0
		protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e); // 0x000000018173BDF0-0x000000018173BE70
		internal bool ContentsEqual(JContainer container); // 0x000000018173A460-0x000000018173A5C0
		public override JEnumerable<JToken> Children(); // 0x000000018173A0E0-0x000000018173A120
		[NullableContext(2)]
		public override IEnumerable<T> Values<T>();
		public IEnumerable<JToken> Descendants(); // 0x000000018173AC30-0x000000018173AC40
		public IEnumerable<JToken> DescendantsAndSelf(); // 0x000000018173AC20-0x000000018173AC30
		[IteratorStateMachine(typeof(_GetDescendants_d__36))]
		internal IEnumerable<JToken> GetDescendants(bool self); // 0x000000018173AE00-0x000000018173AE90
		[NullableContext(2)]
		internal bool IsMultiContent([NotNullWhen(true)] object content); // 0x000000018173B1D0-0x000000018173B290
		internal JToken EnsureParentToken([Nullable(2)] JToken item, bool skipParentCheck, bool copyAnnotations); // 0x000000018173AC40-0x000000018173AD50
		[NullableContext(2)]
		internal abstract int IndexOfItem(JToken item);
		[NullableContext(2)]
		internal virtual bool InsertItem(int index, JToken item, bool skipParentCheck, bool copyAnnotations); // 0x000000018173AF00-0x000000018173B1D0
		internal virtual void RemoveItemAt(int index); // 0x000000018173CB60-0x000000018173CEC0
		[NullableContext(2)]
		internal virtual bool RemoveItem(JToken item); // 0x000000018173CEC0-0x000000018173CF10
		internal virtual JToken GetItem(int index); // 0x000000018173AE90-0x000000018173AF00
		[NullableContext(2)]
		internal virtual void SetItem(int index, JToken item); // 0x000000018173CFC0-0x000000018173D430
		internal virtual void ClearItems(); // 0x000000018173A120-0x000000018173A430
		internal virtual void ReplaceItem(JToken existing, JToken replacement); // 0x000000018173CF60-0x000000018173CFC0
		[NullableContext(2)]
		internal virtual bool ContainsItem(JToken item); // 0x000000018173A430-0x000000018173A460
		internal virtual void CopyItemsTo(Array array, int arrayIndex); // 0x000000018173A7C0-0x000000018173AAC0
		internal static bool IsTokenUnchanged(JToken currentValue, [Nullable(2)] JToken newValue); // 0x000000018173B290-0x000000018173B340
		internal virtual void ValidateToken(JToken o, [Nullable(2)] JToken existing); // 0x000000018173DEC0-0x000000018173DFF0
		[NullableContext(2)]
		public virtual void Add(object content); // 0x0000000181739FA0-0x000000018173A030
		[NullableContext(2)]
		internal bool TryAdd(object content); // 0x000000018173DCE0-0x000000018173DD70
		internal void AddAndSkipParentCheck(JToken token); // 0x0000000181739EE0-0x0000000181739F70
		[NullableContext(2)]
		public void AddFirst(object content); // 0x0000000181739F70-0x0000000181739FA0
		[NullableContext(2)]
		internal bool TryAddInternal(int index, object content, bool skipParentCheck, bool copyAnnotations); // 0x000000018173DA30-0x000000018173DCE0
		internal static JToken CreateFromContent([Nullable(2)] object content); // 0x000000018173AB20-0x000000018173ABC0
		public JsonWriter CreateWriter(); // 0x000000018173ABC0-0x000000018173AC20
		public void ReplaceAll(object content); // 0x000000018173CF10-0x000000018173CF60
		public void RemoveAll(); // 0x000000018171E750-0x000000018171E770
		internal abstract void MergeItem(object content, [Nullable(2)] JsonMergeSettings settings);
		[NullableContext(2)]
		public void Merge(object content); // 0x000000018173BDA0-0x000000018173BDF0
		[NullableContext(2)]
		public void Merge(object content, JsonMergeSettings settings); // 0x000000018173BD40-0x000000018173BDA0
		private void ValidateContent(object content); // 0x000000018173DD70-0x000000018173DEC0
		internal void ReadTokenFrom(JsonReader reader, [Nullable(2)] JsonLoadSettings options); // 0x000000018173C9A0-0x000000018173CB60
		internal void ReadContentFrom(JsonReader r, [Nullable(2)] JsonLoadSettings settings); // 0x000000018173C030-0x000000018173C5E0
		[NullableContext(2)]
		private static JProperty ReadProperty([Nullable(1)] JsonReader r, JsonLoadSettings settings, IJsonLineInfo lineInfo, [Nullable(1)] JContainer parent); // 0x000000018173C5E0-0x000000018173C860
		internal int ContentsHashCode(); // 0x000000018173A5C0-0x000000018173A7C0
		string ITypedList.GetListName(PropertyDescriptor[] listAccessors); // 0x00000001815B1550-0x00000001815B1570
		PropertyDescriptorCollection ITypedList.GetItemProperties(PropertyDescriptor[] listAccessors); // 0x000000018173D8D0-0x000000018173DA30
		int IList<JToken>.IndexOf(JToken item); // 0x000000018171ECE0-0x000000018171ED00
		void IList<JToken>.Insert(int index, JToken item); // 0x000000018171ED00-0x000000018171ED30
		void IList<JToken>.RemoveAt(int index); // 0x000000018171F3D0-0x000000018171F3F0
		void ICollection<JToken>.Add(JToken item); // 0x000000018171E730-0x000000018171E750
		void ICollection<JToken>.Clear(); // 0x000000018171E750-0x000000018171E770
		bool ICollection<JToken>.Contains(JToken item); // 0x000000018171E840-0x000000018171E860
		void ICollection<JToken>.CopyTo(JToken[] array, int arrayIndex); // 0x000000018171E860-0x000000018171E880
		bool ICollection<JToken>.Remove(JToken item); // 0x000000018171F3F0-0x000000018171F410
		[NullableContext(2)]
		private JToken EnsureValue(object value); // 0x000000018173AD50-0x000000018173AE00
		[NullableContext(2)]
		int IList.Add(object value); // 0x000000018173D430-0x000000018173D4C0
		void IList.Clear(); // 0x000000018171E750-0x000000018171E770
		[NullableContext(2)]
		bool IList.Contains(object value); // 0x000000018173D4C0-0x000000018173D4F0
		[NullableContext(2)]
		int IList.IndexOf(object value); // 0x000000018173D4F0-0x000000018173D520
		[NullableContext(2)]
		void IList.Insert(int index, object value); // 0x000000018173D520-0x000000018173D580
		[NullableContext(2)]
		void IList.Remove(object value); // 0x000000018173D580-0x000000018173D5B0
		void IList.RemoveAt(int index); // 0x000000018171F3D0-0x000000018171F3F0
		void ICollection.CopyTo(Array array, int index); // 0x000000018171E860-0x000000018171E880
		void IBindingList.AddIndex(PropertyDescriptor property); // 0x00000001802E76C0-0x00000001802E76D0
		object IBindingList.AddNew(); // 0x000000018173D600-0x000000018173D810
		void IBindingList.ApplySort(PropertyDescriptor property, ListSortDirection direction); // 0x000000018173D810-0x000000018173D850
		int IBindingList.Find(PropertyDescriptor property, object key); // 0x000000018173D850-0x000000018173D890
		void IBindingList.RemoveIndex(PropertyDescriptor property); // 0x00000001802E76C0-0x00000001802E76D0
		void IBindingList.RemoveSort(); // 0x000000018173D890-0x000000018173D8D0
		internal static void MergeEnumerableContent(JContainer target, IEnumerable content, [Nullable(2)] JsonMergeSettings settings); // 0x000000018173B340-0x000000018173BD40
	}
}
