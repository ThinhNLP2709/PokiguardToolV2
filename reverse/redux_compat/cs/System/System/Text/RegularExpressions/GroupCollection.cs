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

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Text.RegularExpressions
{
	[Serializable]
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(CollectionDebuggerProxy<Group>))]
	public class GroupCollection : IList<Group>, IReadOnlyList<Group>, IList // TypeDefIndex: 8694
	{
		// Fields
		private readonly Match _match; // 0x10
		private readonly Hashtable _captureMap; // 0x18
		private Group[] _groups; // 0x20
	
		// Properties
		public bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public int Count { get; } // 0x0000000181B5F0C0-0x0000000181B5F0F0 
		public Group this[int groupnum] { get => default; } // 0x0000000181B5EC50-0x0000000181B5EC60 
		public Group this[string groupname] { get => default; } // 0x0000000181B5F0F0-0x0000000181B5F2A0 
		public bool IsSynchronized { get; } // 0x00000001802E7840-0x00000001802E7850 
		public object SyncRoot { get; } // 0x0000000180377550-0x0000000180377560 
		Group IList<System.Text.RegularExpressions.Group>.this[int index] { get => default; set {} } // 0x0000000181B5EC50-0x0000000181B5EC60 0x0000000181B5EC60-0x0000000181B5ECB0
		bool IList.IsFixedSize { get; } // 0x00000001802E7990-0x00000001802E79A0 
		object IList.this[int index] { get => default; set {} } // 0x0000000181B5EC50-0x0000000181B5EC60 0x0000000181B5F040-0x0000000181B5F090
	
		// Nested types
		private sealed class Enumerator : IEnumerator<Group> // TypeDefIndex: 8695
		{
			// Fields
			private readonly GroupCollection _collection; // 0x10
			private int _index; // 0x18
	
			// Properties
			public Group Current { get; } // 0x0000000181B5DA70-0x0000000181B5DB10 
			object IEnumerator.Current { get; } // 0x0000000181B5DA70-0x0000000181B5DB10 
	
			// Constructors
			internal Enumerator(GroupCollection collection); // 0x0000000181560590-0x00000001815605D0
	
			// Methods
			public bool MoveNext(); // 0x0000000181B5D9D0-0x0000000181B5DA20
			void IEnumerator.Reset(); // 0x00000001810FCE00-0x00000001810FCE10
			void IDisposable.Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
		}
	
		// Constructors
		internal GroupCollection(Match match, Hashtable caps); // 0x0000000180CB0730-0x0000000180CB0780
		internal GroupCollection(); // 0x0000000181B5F090-0x0000000181B5F0C0
	
		// Methods
		public IEnumerator GetEnumerator(); // 0x0000000181B5DFA0-0x0000000181B5E010
		IEnumerator<Group> IEnumerable<Group>.GetEnumerator(); // 0x0000000181B5EA10-0x0000000181B5EA80
		private Group GetGroup(int groupnum); // 0x0000000181B5E400-0x0000000181B5E8C0
		private Group GetGroupImpl(int groupnum); // 0x0000000181B5E010-0x0000000181B5E400
		public void CopyTo(Array array, int arrayIndex); // 0x0000000181B5DCD0-0x0000000181B5DDB0
		public void CopyTo(Group[] array, int arrayIndex); // 0x0000000181B5DDB0-0x0000000181B5DFA0
		int IList<Group>.IndexOf(Group item); // 0x0000000181B5EA80-0x0000000181B5EBB0
		void IList<Group>.Insert(int index, Group item); // 0x0000000181B5EBB0-0x0000000181B5EC00
		void IList<Group>.RemoveAt(int index); // 0x0000000181B5EC00-0x0000000181B5EC50
		void ICollection<Group>.Add(Group item); // 0x0000000181B5E8C0-0x0000000181B5E910
		void ICollection<Group>.Clear(); // 0x0000000181B5E910-0x0000000181B5E960
		bool ICollection<Group>.Contains(Group item); // 0x0000000181B5E960-0x0000000181B5E9C0
		bool ICollection<Group>.Remove(Group item); // 0x0000000181B5E9C0-0x0000000181B5EA10
		int IList.Add(object value); // 0x0000000181B5ECB0-0x0000000181B5ED00
		void IList.Clear(); // 0x0000000181B5ED00-0x0000000181B5ED50
		bool IList.Contains(object value); // 0x0000000181B5ED50-0x0000000181B5EE80
		int IList.IndexOf(object value); // 0x0000000181B5EE80-0x0000000181B5EF50
		void IList.Insert(int index, object value); // 0x0000000181B5EF50-0x0000000181B5EFA0
		void IList.Remove(object value); // 0x0000000181B5EFF0-0x0000000181B5F040
		void IList.RemoveAt(int index); // 0x0000000181B5EFA0-0x0000000181B5EFF0
	}
}
