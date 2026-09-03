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

namespace System.Collections.Specialized
{
	[Serializable]
	public class StringCollection : IList // TypeDefIndex: 8954
	{
		// Fields
		private readonly ArrayList data; // 0x10
	
		// Properties
		public string this[int index] { get => default; set {} } // 0x0000000181BD4DD0-0x0000000181BD4E20 0x0000000181BD4EF0-0x0000000181BD4F20
		public int Count { get; } // 0x0000000181592F20-0x0000000181592F50 
		bool IList.IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
		bool IList.IsFixedSize { get; } // 0x00000001802E7840-0x00000001802E7850 
		public bool IsSynchronized { get; } // 0x00000001802E7840-0x00000001802E7850 
		public object SyncRoot { get; } // 0x0000000181592730-0x0000000181592760 
		object IList.this[int index] { get => default; set {} } // 0x0000000181BD4DD0-0x0000000181BD4E20 0x0000000181BD4E20-0x0000000181BD4E80
	
		// Constructors
		public StringCollection(); // 0x0000000181BD4E80-0x0000000181BD4EF0
	
		// Methods
		public int Add(string value); // 0x0000000181BD4B30-0x0000000181BD4B60
		public void Clear(); // 0x00000001818C1620-0x00000001818C1650
		public bool Contains(string value); // 0x0000000181592870-0x00000001815928A0
		public void CopyTo(string[] array, int index); // 0x0000000181592700-0x0000000181592730
		public int IndexOf(string value); // 0x00000001815928A0-0x00000001815928D0
		public void Insert(int index, string value); // 0x0000000181BD4B60-0x0000000181BD4B90
		public void Remove(string value); // 0x0000000181BD4BC0-0x0000000181BD4BF0
		public void RemoveAt(int index); // 0x0000000181BD4B90-0x0000000181BD4BC0
		int IList.Add(object value); // 0x0000000181BD4BF0-0x0000000181BD4C50
		bool IList.Contains(object value); // 0x0000000181BD4C50-0x0000000181BD4CB0
		int IList.IndexOf(object value); // 0x0000000181BD4CB0-0x0000000181BD4D10
		void IList.Insert(int index, object value); // 0x0000000181BD4D10-0x0000000181BD4D70
		void IList.Remove(object value); // 0x0000000181BD4D70-0x0000000181BD4DD0
		void ICollection.CopyTo(Array array, int index); // 0x0000000181592700-0x0000000181592730
		IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181411FF0-0x0000000181412020
	}
}
