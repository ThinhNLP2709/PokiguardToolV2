/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Collections
{
	[Serializable]
	internal class ListDictionaryInternal : IDictionary // TypeDefIndex: 3500
	{
		// Fields
		private DictionaryNode head; // 0x10
		private int version; // 0x18
		private int count; // 0x1C
		[NonSerialized]
		private object _syncRoot; // 0x20
	
		// Properties
		public object this[object key] { get => default; set {} } // 0x000000018159BCE0-0x000000018159BDB0 0x000000018159BE90-0x000000018159C020
		public int Count { get; } // 0x0000000180B232F0-0x0000000180B23300 
		public ICollection Keys { get; } // 0x000000018159BDB0-0x000000018159BE20 
		public bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
		public bool IsFixedSize { get; } // 0x00000001802E7840-0x00000001802E7850 
		public bool IsSynchronized { get; } // 0x00000001802E7840-0x00000001802E7850 
		public object SyncRoot { get; } // 0x0000000180B5B970-0x0000000180B5B9E0 
		public ICollection Values { get; } // 0x000000018159BE20-0x000000018159BE90 
	
		// Nested types
		private class NodeEnumerator : IDictionaryEnumerator // TypeDefIndex: 3501
		{
			// Fields
			private ListDictionaryInternal list; // 0x10
			private DictionaryNode current; // 0x18
			private int version; // 0x20
			private bool start; // 0x24
	
			// Properties
			public object Current { get; } // 0x000000018159C1E0-0x000000018159C2B0 
			public DictionaryEntry Entry { get; } // 0x000000018159C2B0-0x000000018159C350 
			public object Key { get; } // 0x000000018159C350-0x000000018159C3C0 
			public object Value { get; } // 0x000000018159C3C0-0x000000018159C430 
	
			// Constructors
			public NodeEnumerator(ListDictionaryInternal list); // 0x000000018159C180-0x000000018159C1E0
	
			// Methods
			public bool MoveNext(); // 0x000000018159C020-0x000000018159C0F0
			public void Reset(); // 0x000000018159C0F0-0x000000018159C180
		}
	
		private class NodeKeyValueCollection : ICollection // TypeDefIndex: 3502
		{
			// Fields
			private ListDictionaryInternal list; // 0x10
			private bool isKeys; // 0x18
	
			// Properties
			int ICollection.Count { get; } // 0x000000018159C640-0x000000018159C680 
			bool ICollection.IsSynchronized { get; } // 0x00000001802E7840-0x00000001802E7850 
			object ICollection.SyncRoot { get; } // 0x000000018159C680-0x000000018159C6F0 
	
			// Nested types
			private class NodeKeyValueEnumerator : IEnumerator // TypeDefIndex: 3503
			{
				// Fields
				private ListDictionaryInternal list; // 0x10
				private DictionaryNode current; // 0x18
				private int version; // 0x20
				private bool isKeys; // 0x24
				private bool start; // 0x25
	
				// Properties
				public object Current { get; } // 0x000000018159C960-0x000000018159C9E0 
	
				// Constructors
				public NodeKeyValueEnumerator(ListDictionaryInternal list, bool isKeys); // 0x000000018159C8F0-0x000000018159C960
	
				// Methods
				public bool MoveNext(); // 0x000000018159C790-0x000000018159C860
				public void Reset(); // 0x000000018159C860-0x000000018159C8F0
			}
	
			// Constructors
			public NodeKeyValueCollection(ListDictionaryInternal list, bool isKeys); // 0x0000000181237140-0x0000000181237190
	
			// Methods
			void ICollection.CopyTo(Array array, int index); // 0x000000018159C430-0x000000018159C640
			IEnumerator IEnumerable.GetEnumerator(); // 0x000000018159C6F0-0x000000018159C790
		}
	
		[Serializable]
		private class DictionaryNode // TypeDefIndex: 3504
		{
			// Fields
			public object key; // 0x10
			public object value; // 0x18
			public DictionaryNode next; // 0x20
	
			// Constructors
			public DictionaryNode(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		// Constructors
		public ListDictionaryInternal(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void Add(object key, object value); // 0x000000018159B570-0x000000018159B750
		public void Clear(); // 0x000000018159B750-0x000000018159B780
		public bool Contains(object key); // 0x000000018159B780-0x000000018159B850
		public void CopyTo(Array array, int index); // 0x000000018159B850-0x000000018159BAA0
		public IDictionaryEnumerator GetEnumerator(); // 0x000000018159BAA0-0x000000018159BB30
		IEnumerator IEnumerable.GetEnumerator(); // 0x000000018159BC50-0x000000018159BCE0
		public void Remove(object key); // 0x000000018159BB30-0x000000018159BC50
	}
}
