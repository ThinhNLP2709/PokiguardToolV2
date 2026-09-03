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

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Diagnostics
{
	public class TraceListenerCollection : IList // TypeDefIndex: 8735
	{
		// Fields
		private ArrayList list; // 0x10
	
		// Properties
		public int Count { get; } // 0x0000000181592F20-0x0000000181592F50 
		object IList.this[int index] { get => default; set {} } // 0x0000000181B873D0-0x0000000181B87400 0x0000000181B87400-0x0000000181B87520
		bool IList.IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
		bool IList.IsFixedSize { get; } // 0x00000001802E7840-0x00000001802E7850 
		object ICollection.SyncRoot { get; } // 0x0000000180370C60-0x0000000180370C70 
		bool ICollection.IsSynchronized { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
		// Constructors
		internal TraceListenerCollection(); // 0x0000000181B87520-0x0000000181B87590
	
		// Methods
		public int Add(TraceListener listener); // 0x0000000181B86980-0x0000000181B86AC0
		public void Clear(); // 0x0000000181B86AC0-0x0000000181B86B20
		public IEnumerator GetEnumerator(); // 0x0000000181411FF0-0x0000000181412020
		internal void InitializeListener(TraceListener listener); // 0x0000000181B86B20-0x0000000181B86C70
		public void RemoveAt(int index); // 0x0000000181B86C70-0x0000000181B86D90
		int IList.Add(object value); // 0x0000000181B86EC0-0x0000000181B870C0
		bool IList.Contains(object value); // 0x0000000181592870-0x00000001815928A0
		int IList.IndexOf(object value); // 0x00000001815928A0-0x00000001815928D0
		void IList.Insert(int index, object value); // 0x0000000181B870C0-0x0000000181B872B0
		void IList.Remove(object value); // 0x0000000181B872B0-0x0000000181B873D0
		void ICollection.CopyTo(Array array, int index); // 0x0000000181B86D90-0x0000000181B86EC0
	}
}
