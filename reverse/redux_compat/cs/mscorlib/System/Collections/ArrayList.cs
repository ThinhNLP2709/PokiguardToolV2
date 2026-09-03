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
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(ArrayListDebugView))]
	public class ArrayList : IList, ICloneable // TypeDefIndex: 3524
	{
		// Fields
		private object[] _items; // 0x10
		private int _size; // 0x18
		private int _version; // 0x1C
		[NonSerialized]
		private object _syncRoot; // 0x20
	
		// Properties
		public virtual int Capacity { set; } // 0x00000001815A68B0-0x00000001815A69E0
		public virtual int Count { get; } // 0x0000000180B23260-0x0000000180B23270 
		public virtual bool IsFixedSize { get; } // 0x00000001802E7840-0x00000001802E7850 
		public virtual bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
		public virtual bool IsSynchronized { get; } // 0x00000001802E7840-0x00000001802E7850 
		public virtual object SyncRoot { get; } // 0x0000000180B5B970-0x0000000180B5B9E0 
		public virtual object this[int index] { get => default; set {} } // 0x00000001815A6800-0x00000001815A68B0 0x00000001815A69E0-0x00000001815A6AE0
	
		// Nested types
		[Serializable]
		private class IListWrapper : ArrayList // TypeDefIndex: 3525
		{
			// Fields
			private IList _list; // 0x28
	
			// Properties
			public override int Capacity { set; } // 0x00000001815AE380-0x00000001815AE410
			public override int Count { get; } // 0x00000001815AE190-0x00000001815AE1E0 
			public override bool IsReadOnly { get; } // 0x00000001815AE230-0x00000001815AE280 
			public override bool IsFixedSize { get; } // 0x00000001815AE1E0-0x00000001815AE230 
			public override bool IsSynchronized { get; } // 0x00000001815AE280-0x00000001815AE2D0 
			public override object this[int index] { get => default; set {} } // 0x00000001815AE2D0-0x00000001815AE330 0x00000001815AE410-0x00000001815AE480
			public override object SyncRoot { get; } // 0x00000001815AE330-0x00000001815AE380 
	
			// Constructors
			internal IListWrapper(IList list); // 0x00000001815AE150-0x00000001815AE190
	
			// Methods
			public override int Add(object obj); // 0x00000001815AD000-0x00000001815AD060
			public override void AddRange(ICollection c); // 0x00000001815ACFB0-0x00000001815AD000
			public override void Clear(); // 0x00000001815AD060-0x00000001815AD120
			public override object Clone(); // 0x00000001815AD120-0x00000001815AD190
			public override bool Contains(object obj); // 0x00000001815AD190-0x00000001815AD260
			public override void CopyTo(Array array, int index); // 0x00000001815AD260-0x00000001815AD2D0
			public override void CopyTo(int index, Array array, int arrayIndex, int count); // 0x00000001815AD2D0-0x00000001815AD5F0
			public override IEnumerator GetEnumerator(); // 0x00000001815AD5F0-0x00000001815AD640
			public override int IndexOf(object value); // 0x00000001815AD640-0x00000001815AD6A0
			public override void Insert(int index, object obj); // 0x00000001815AD9E0-0x00000001815ADA50
			public override void InsertRange(int index, ICollection c); // 0x00000001815AD6A0-0x00000001815AD9E0
			public override void Remove(object value); // 0x00000001815A6140-0x00000001815A6190
			public override void RemoveAt(int index); // 0x00000001815ADA50-0x00000001815ADAB0
			public override void RemoveRange(int index, int count); // 0x00000001815ADAB0-0x00000001815ADCA0
			public override void Sort(int index, int count, IComparer comparer); // 0x00000001815ADCA0-0x00000001815ADF50
			public override object[] ToArray(); // 0x00000001815ADF50-0x00000001815AE050
			public override Array ToArray(Type type); // 0x00000001815AE050-0x00000001815AE150
		}
	
		[Serializable]
		private class ReadOnlyArrayList : ArrayList // TypeDefIndex: 3526
		{
			// Fields
			private ArrayList _list; // 0x28
	
			// Properties
			public override int Count { get; } // 0x00000001815B2D80-0x00000001815B2DB0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
			public override bool IsFixedSize { get; } // 0x00000001802E7990-0x00000001802E79A0 
			public override bool IsSynchronized { get; } // 0x00000001815B2DB0-0x00000001815B2DE0 
			public override object this[int index] { get => default; set {} } // 0x00000001815B2DE0-0x00000001815B2E10 0x00000001815B2E90-0x00000001815B2EE0
			public override object SyncRoot { get; } // 0x00000001815B2E10-0x00000001815B2E40 
			public override int Capacity { set; } // 0x00000001815B2E40-0x00000001815B2E90
	
			// Constructors
			internal ReadOnlyArrayList(ArrayList l); // 0x00000001815B2D40-0x00000001815B2D80
	
			// Methods
			public override int Add(object obj); // 0x00000001815B2840-0x00000001815B2890
			public override void AddRange(ICollection c); // 0x00000001815B27F0-0x00000001815B2840
			public override void Clear(); // 0x00000001815B2890-0x00000001815B28E0
			public override object Clone(); // 0x00000001815B28E0-0x00000001815B2A10
			public override bool Contains(object obj); // 0x00000001815B2A10-0x00000001815B2A40
			public override void CopyTo(Array array, int index); // 0x00000001815B2A70-0x00000001815B2AA0
			public override void CopyTo(int index, Array array, int arrayIndex, int count); // 0x00000001815B2A40-0x00000001815B2A70
			public override IEnumerator GetEnumerator(); // 0x00000001815B2AA0-0x00000001815B2AD0
			public override int IndexOf(object value); // 0x00000001815B2AD0-0x00000001815B2B00
			public override void Insert(int index, object obj); // 0x00000001815B2B50-0x00000001815B2BA0
			public override void InsertRange(int index, ICollection c); // 0x00000001815B2B00-0x00000001815B2B50
			public override void Remove(object value); // 0x00000001815B2C40-0x00000001815B2C90
			public override void RemoveAt(int index); // 0x00000001815B2BA0-0x00000001815B2BF0
			public override void RemoveRange(int index, int count); // 0x00000001815B2BF0-0x00000001815B2C40
			public override void Sort(int index, int count, IComparer comparer); // 0x00000001815B2C90-0x00000001815B2CE0
			public override object[] ToArray(); // 0x00000001815B2D10-0x00000001815B2D40
			public override Array ToArray(Type type); // 0x00000001815B2CE0-0x00000001815B2D10
		}
	
		[Serializable]
		private sealed class ArrayListEnumeratorSimple : IEnumerator, ICloneable // TypeDefIndex: 3527
		{
			// Fields
			private ArrayList _list; // 0x10
			private int _index; // 0x18
			private int _version; // 0x1C
			private object _currentElement; // 0x20
			private bool _isArrayList; // 0x28
			private static object s_dummyObject; // 0x00
	
			// Properties
			public object Current { get; } // 0x00000001815A51E0-0x00000001815A52E0 
	
			// Constructors
			internal ArrayListEnumeratorSimple(ArrayList list); // 0x00000001815A5120-0x00000001815A51E0
			static ArrayListEnumeratorSimple(); // 0x00000001815A50B0-0x00000001815A5120
	
			// Methods
			public object Clone(); // 0x0000000181560410-0x0000000181560420
			public bool MoveNext(); // 0x00000001815A4DD0-0x00000001815A4FE0
			public void Reset(); // 0x00000001815A4FE0-0x00000001815A50B0
		}
	
		internal class ArrayListDebugView // TypeDefIndex: 3528
		{
		}
	
		// Constructors
		public ArrayList(); // 0x00000001815A64D0-0x00000001815A6560
		public ArrayList(int capacity); // 0x00000001815A6560-0x00000001815A66A0
		public ArrayList(ICollection c); // 0x00000001815A66A0-0x00000001815A6800
	
		// Methods
		public static ArrayList Adapter(IList list); // 0x00000001815A52E0-0x00000001815A53A0
		public virtual int Add(object value); // 0x00000001815A53C0-0x00000001815A54C0
		public virtual void AddRange(ICollection c); // 0x00000001815A53A0-0x00000001815A53C0
		public virtual void Clear(); // 0x0000000180BE0470-0x0000000180BE04B0
		public virtual object Clone(); // 0x00000001815A54C0-0x00000001815A5670
		public virtual bool Contains(object item); // 0x00000001815A5670-0x00000001815A5750
		public virtual void CopyTo(Array array); // 0x00000001815A58F0-0x00000001815A5910
		public virtual void CopyTo(Array array, int arrayIndex); // 0x00000001815A5840-0x00000001815A58F0
		public virtual void CopyTo(int index, Array array, int arrayIndex, int count); // 0x00000001815A5750-0x00000001815A5840
		private void EnsureCapacity(int min); // 0x00000001815A5910-0x00000001815A5970
		public virtual IEnumerator GetEnumerator(); // 0x00000001815A5970-0x00000001815A5A60
		public virtual int IndexOf(object value); // 0x00000001815A5A60-0x00000001815A5A90
		public virtual void Insert(int index, object value); // 0x00000001815A5C70-0x00000001815A5DD0
		public virtual void InsertRange(int index, ICollection c); // 0x00000001815A5A90-0x00000001815A5C70
		public static ArrayList ReadOnly(ArrayList list); // 0x00000001815A5DD0-0x00000001815A5E80
		public virtual void Remove(object obj); // 0x00000001815A6140-0x00000001815A6190
		public virtual void RemoveAt(int index); // 0x00000001815A5E80-0x00000001815A5F60
		public virtual void RemoveRange(int index, int count); // 0x00000001815A5F60-0x00000001815A6140
		public virtual void Sort(IComparer comparer); // 0x00000001815A6190-0x00000001815A61F0
		public virtual void Sort(int index, int count, IComparer comparer); // 0x00000001815A61F0-0x00000001815A6340
		public virtual object[] ToArray(); // 0x00000001815A6340-0x00000001815A6410
		public virtual Array ToArray(Type type); // 0x00000001815A6410-0x00000001815A64D0
	}
}
