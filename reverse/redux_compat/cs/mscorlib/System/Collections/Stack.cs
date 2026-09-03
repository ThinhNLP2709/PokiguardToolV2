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
	[DebuggerTypeProxy(typeof(StackDebugView))]
	public class Stack : ICollection, ICloneable // TypeDefIndex: 3519
	{
		// Fields
		private object[] _array; // 0x10
		private int _size; // 0x18
		private int _version; // 0x1C
		[NonSerialized]
		private object _syncRoot; // 0x20
	
		// Properties
		public virtual int Count { get; } // 0x0000000180B23260-0x0000000180B23270 
		public virtual bool IsSynchronized { get; } // 0x00000001802E7840-0x00000001802E7850 
		public virtual object SyncRoot { get; } // 0x0000000180B5B970-0x0000000180B5B9E0 
	
		// Nested types
		[Serializable]
		private class StackEnumerator : IEnumerator, ICloneable // TypeDefIndex: 3520
		{
			// Fields
			private Stack _stack; // 0x10
			private int _index; // 0x18
			private int _version; // 0x1C
			private object _currentElement; // 0x20
	
			// Properties
			public virtual object Current { get; } // 0x00000001815A05E0-0x00000001815A0690 
	
			// Constructors
			internal StackEnumerator(Stack stack); // 0x00000001815A0580-0x00000001815A05E0
	
			// Methods
			public object Clone(); // 0x0000000181560410-0x0000000181560420
			public virtual bool MoveNext(); // 0x00000001815A03B0-0x00000001815A04F0
			public virtual void Reset(); // 0x00000001815A04F0-0x00000001815A0580
		}
	
		internal class StackDebugView // TypeDefIndex: 3521
		{
		}
	
		// Constructors
		public Stack(); // 0x00000001815A27D0-0x00000001815A2830
		public Stack(int initialCapacity); // 0x00000001815A2700-0x00000001815A27D0
	
		// Methods
		public virtual void Clear(); // 0x0000000180DF0F20-0x0000000180DF0F50
		public virtual object Clone(); // 0x00000001815A2020-0x00000001815A2150
		public virtual void CopyTo(Array array, int index); // 0x00000001815A2150-0x00000001815A2410
		public virtual IEnumerator GetEnumerator(); // 0x00000001815A2410-0x00000001815A24A0
		public virtual object Peek(); // 0x00000001815A24A0-0x00000001815A2530
		public virtual object Pop(); // 0x00000001815A2530-0x00000001815A25F0
		public virtual void Push(object obj); // 0x00000001815A25F0-0x00000001815A2700
	}
}
