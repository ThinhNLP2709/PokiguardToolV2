/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting.Messaging
{
	[Serializable]
	internal class MessageDictionary : IDictionary // TypeDefIndex: 2993
	{
		// Fields
		private IDictionary _internalProperties; // 0x10
		protected IMethodMessage _message; // 0x18
		private string[] _methodKeys; // 0x20
		private bool _ownProperties; // 0x28
	
		// Properties
		internal IDictionary InternalDictionary { get; } // 0x00000001814E01F0-0x00000001814E02A0 
		public string[] MethodKeys { set; } // 0x000000018033E830-0x000000018033E840
		public bool IsFixedSize { get; } // 0x00000001802E7840-0x00000001802E7850 
		public bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
		public object this[object key] { get => default; set {} } // 0x00000001814E02A0-0x00000001814E03C0 0x00000001814DF350-0x00000001814DF4B0
		public ICollection Keys { get; } // 0x00000001814E03C0-0x00000001814E0790 
		public ICollection Values { get; } // 0x00000001814E0790-0x00000001814E0BC0 
		public int Count { get; } // 0x00000001814E0180-0x00000001814E01F0 
		public bool IsSynchronized { get; } // 0x00000001802E7840-0x00000001802E7850 
		public object SyncRoot { get; } // 0x0000000180370C60-0x0000000180370C70 
	
		// Nested types
		private class DictionaryEnumerator : IDictionaryEnumerator // TypeDefIndex: 2994
		{
			// Fields
			private MessageDictionary _methodDictionary; // 0x10
			private IDictionaryEnumerator _hashtableEnum; // 0x18
			private int _posMethod; // 0x20
	
			// Properties
			public object Current { get; } // 0x00000001814D9A90-0x00000001814D9AF0 
			public DictionaryEntry Entry { get; } // 0x00000001814D9AF0-0x00000001814D9CB0 
			public object Key { get; } // 0x00000001814D9CB0-0x00000001814D9CD0 
			public object Value { get; } // 0x00000001814D9CD0-0x00000001814D9CF0 
	
			// Constructors
			public DictionaryEnumerator(MessageDictionary methodDictionary); // 0x00000001814D99F0-0x00000001814D9A90
	
			// Methods
			public bool MoveNext(); // 0x00000001814D9880-0x00000001814D9990
			public void Reset(); // 0x00000001814D9990-0x00000001814D99F0
		}
	
		// Constructors
		public MessageDictionary(IMethodMessage message); // 0x0000000180D9D6B0-0x0000000180D9D6F0
	
		// Methods
		internal bool HasUserData(); // 0x00000001814DFB40-0x00000001814DFC20
		protected virtual IDictionary AllocInternalProperties(); // 0x00000001814DF4B0-0x00000001814DF500
		public IDictionary GetInternalProperties(); // 0x00000001814DF730-0x00000001814DF780
		private bool IsOverridenKey(string key); // 0x00000001814DFC20-0x00000001814DFCA0
		protected virtual object GetMethodProperty(string key); // 0x00000001814DF780-0x00000001814DFB40
		protected virtual void SetMethodProperty(string key, object value); // 0x00000001814DFDF0-0x00000001814E0120
		public void Add(object key, object value); // 0x00000001814DF350-0x00000001814DF4B0
		public void Clear(); // 0x00000001814DF500-0x00000001814DF550
		public bool Contains(object key); // 0x00000001814DF550-0x00000001814DF650
		public void Remove(object key); // 0x00000001814DFCA0-0x00000001814DFDF0
		public void CopyTo(Array array, int index); // 0x00000001814DF650-0x00000001814DF6D0
		IEnumerator IEnumerable.GetEnumerator(); // 0x00000001814E0120-0x00000001814E0180
		public IDictionaryEnumerator GetEnumerator(); // 0x00000001814DF6D0-0x00000001814DF730
	}
}
