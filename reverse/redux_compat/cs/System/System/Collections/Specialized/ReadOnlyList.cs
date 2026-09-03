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
	internal sealed class ReadOnlyList : IList // TypeDefIndex: 8959
	{
		// Fields
		private readonly IList _list; // 0x10
	
		// Properties
		public int Count { get; } // 0x0000000181BD3F70-0x0000000181BD3FC0 
		public bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public bool IsFixedSize { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public bool IsSynchronized { get; } // 0x0000000181BD3FC0-0x0000000181BD4010 
		public object this[int index] { get => default; set {} } // 0x0000000181BD4010-0x0000000181BD4070 0x0000000181BD40C0-0x0000000181BD4110
		public object SyncRoot { get; } // 0x0000000181BD4070-0x0000000181BD40C0 
	
		// Constructors
		internal ReadOnlyList(IList list); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public int Add(object value); // 0x0000000181BD3BF0-0x0000000181BD3C40
		public void Clear(); // 0x0000000181BD3C40-0x0000000181BD3C90
		public bool Contains(object value); // 0x0000000181BD3C90-0x0000000181BD3D60
		public void CopyTo(Array array, int index); // 0x0000000181BD3D60-0x0000000181BD3DD0
		public IEnumerator GetEnumerator(); // 0x0000000181BD3DD0-0x0000000181BD3E20
		public int IndexOf(object value); // 0x0000000181BD3E20-0x0000000181BD3E80
		public void Insert(int index, object value); // 0x0000000181BD3E80-0x0000000181BD3ED0
		public void Remove(object value); // 0x0000000181BD3F20-0x0000000181BD3F70
		public void RemoveAt(int index); // 0x0000000181BD3ED0-0x0000000181BD3F20
	}
}
