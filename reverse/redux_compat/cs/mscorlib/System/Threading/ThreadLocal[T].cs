/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Threading
{
	[DebuggerDisplay("IsValueCreated={IsValueCreated}, Value={ValueForDebugDisplay}, Count={ValuesCountForDebugDisplay}")]
	[DebuggerTypeProxy(typeof(SystemThreading_ThreadLocalDebugView<T>))]
	public class ThreadLocal<T> : IDisposable // TypeDefIndex: 2568
	{
		// Fields
		private Func<T> m_valueFactory;
		[ThreadStatic]
		private static LinkedSlotVolatile[] ts_slotArray;
		[ThreadStatic]
		private static FinalizationHelper ts_finalizationHelper;
		private int m_idComplement;
		private bool m_initialized;
		private static IdManager s_idManager;
		private LinkedSlot m_linkedSlot;
		private bool m_trackAllValues;
	
		// Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public T Value { get; set; }
		public bool IsValueCreated { get; }
	
		// Nested types
		private struct LinkedSlotVolatile // TypeDefIndex: 2569
		{
			// Fields
			internal LinkedSlot<T> Value;
		}
	
		private sealed class LinkedSlot // TypeDefIndex: 2570
		{
			// Fields
			internal LinkedSlot<T> Next;
			internal LinkedSlot<T> Previous;
			internal LinkedSlotVolatile<T>[] SlotArray;
			internal T Value;
	
			// Constructors
			internal LinkedSlot(LinkedSlotVolatile<T>[] slotArray);
		}
	
		private class IdManager // TypeDefIndex: 2571
		{
			// Fields
			private int m_nextIdToTry;
			private List<bool> m_freeIds;
	
			// Constructors
			public IdManager();
	
			// Methods
			internal int GetId();
			internal void ReturnId(int id);
		}
	
		private class FinalizationHelper // TypeDefIndex: 2572
		{
			// Fields
			internal LinkedSlotVolatile<T>[] SlotArray;
			private bool m_trackAllValues;
	
			// Constructors
			internal FinalizationHelper(LinkedSlotVolatile<T>[] slotArray, bool trackAllValues);
	
			// Methods
			~FinalizationHelper();
		}
	
		// Constructors
		public ThreadLocal(Func<T> valueFactory);
		static ThreadLocal();
	
		// Methods
		private void Initialize(Func<T> valueFactory, bool trackAllValues);
		~ThreadLocal();
		public void Dispose();
		protected virtual void Dispose(bool disposing);
		public override string ToString();
		private T GetValueSlow();
		private void SetValueSlow(T value, LinkedSlotVolatile[] slotArray);
		private void CreateLinkedSlot(LinkedSlotVolatile[] slotArray, int id, T value);
		private void GrowTable(ref LinkedSlotVolatile[] table, int minLength);
		private static int GetNewTableSize(int minSize);
	}
}
