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
	[DebuggerTypeProxy(typeof(QueueDebugView))]
	public class Queue : ICollection, ICloneable // TypeDefIndex: 3509
	{
		// Fields
		private object[] _array; // 0x10
		private int _head; // 0x18
		private int _tail; // 0x1C
		private int _size; // 0x20
		private int _growFactor; // 0x24
		private int _version; // 0x28
		[NonSerialized]
		private object _syncRoot; // 0x30
	
		// Properties
		public virtual int Count { get; } // 0x0000000180C4F680-0x0000000180C4F690 
		public virtual bool IsSynchronized { get; } // 0x00000001802E7840-0x00000001802E7850 
		public virtual object SyncRoot { get; } // 0x000000018159DB30-0x000000018159DBA0 
	
		// Nested types
		[Serializable]
		private class QueueEnumerator : IEnumerator, ICloneable // TypeDefIndex: 3510
		{
			// Fields
			private Queue _q; // 0x10
			private int _index; // 0x18
			private int _version; // 0x1C
			private object _currentElement; // 0x20
	
			// Properties
			public virtual object Current { get; } // 0x000000018159CD20-0x000000018159CDE0 
	
			// Constructors
			internal QueueEnumerator(Queue q); // 0x000000018159CCA0-0x000000018159CD20
	
			// Methods
			public object Clone(); // 0x0000000181560410-0x0000000181560420
			public virtual bool MoveNext(); // 0x000000018159CB10-0x000000018159CC00
			public virtual void Reset(); // 0x000000018159CC00-0x000000018159CCA0
		}
	
		internal class QueueDebugView // TypeDefIndex: 3511
		{
		}
	
		// Constructors
		public Queue(); // 0x000000018159DB10-0x000000018159DB30
		public Queue(int capacity); // 0x000000018159DB00-0x000000018159DB10
		public Queue(int capacity, float growFactor); // 0x000000018159D6A0-0x000000018159D850
		public Queue(ICollection col); // 0x000000018159D850-0x000000018159DB00
	
		// Methods
		public virtual object Clone(); // 0x000000018159CDE0-0x000000018159CEF0
		public virtual void CopyTo(Array array, int index); // 0x000000018159CEF0-0x000000018159D140
		public virtual void Enqueue(object obj); // 0x000000018159D230-0x000000018159D410
		public virtual IEnumerator GetEnumerator(); // 0x000000018159D450-0x000000018159D500
		public virtual object Dequeue(); // 0x000000018159D140-0x000000018159D230
		public virtual object Peek(); // 0x000000018159D500-0x000000018159D5A0
		internal object GetElement(int i); // 0x000000018159D410-0x000000018159D450
		private void SetCapacity(int capacity); // 0x000000018159D5A0-0x000000018159D6A0
	}
}
