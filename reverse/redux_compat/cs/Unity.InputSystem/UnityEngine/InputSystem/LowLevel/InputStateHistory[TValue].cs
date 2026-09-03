/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.LowLevel
{
	public class InputStateHistory<TValue> : InputStateHistory, IReadOnlyList<InputStateHistory<TValue>> // TypeDefIndex: 6507
		where TValue : struct
	{
		// Properties
		public new Record this[int index] { get => default; set {} }
	
		// Nested types
		private struct Enumerator : IEnumerator<Record> // TypeDefIndex: 6508
		{
			// Fields
			private readonly InputStateHistory<TValue> m_History;
			private int m_Index;
	
			// Properties
			public Record<TValue> Current { get; }
			object IEnumerator.Current { get; }
	
			// Constructors
			public Enumerator(InputStateHistory<TValue> history);
	
			// Methods
			public bool MoveNext();
			public void Reset();
			public void Dispose();
		}
	
		public struct Record : IEquatable<Record> // TypeDefIndex: 6509
		{
			// Fields
			private readonly InputStateHistory<TValue> m_Owner;
			private readonly int m_IndexPlusOne;
			private uint m_Version;
	
			// Properties
			internal unsafe InputStateHistory.RecordHeader* header { get; }
			internal int recordIndex { get; }
			public bool valid { get; }
			public InputStateHistory<TValue> owner { get; }
			public int index { get; }
			public double time { get; }
			public InputControl<TValue> control { get; }
			public Record<TValue> next { get; }
			public Record<TValue> previous { get; }
	
			// Constructors
			internal unsafe Record(InputStateHistory<TValue> owner, int index, InputStateHistory.RecordHeader* header);
			internal Record(InputStateHistory<TValue> owner, int index);
	
			// Methods
			public TValue ReadValue();
			public unsafe void* GetUnsafeMemoryPtr();
			internal unsafe void* GetUnsafeMemoryPtrUnchecked();
			public unsafe void* GetUnsafeExtraMemoryPtr();
			internal unsafe void* GetUnsafeExtraMemoryPtrUnchecked();
			public void CopyFrom(Record<TValue> record);
			private void CheckValid();
			public bool Equals(Record<TValue> other);
			public override bool Equals(object obj);
			public override int GetHashCode();
			public override string ToString();
		}
	
		// Constructors
		public InputStateHistory(int? maxStateSizeInBytes = default);
		public InputStateHistory(InputControl<TValue> control);
		public InputStateHistory(string path);
	
		// Methods
		~InputStateHistory();
		public Record AddRecord(Record record);
		public Record RecordStateChange(InputControl<TValue> control, TValue value, double time = -1 /* Metadata: 0x0069915A */);
		public new IEnumerator<Record> GetEnumerator();
		new IEnumerator IEnumerable.GetEnumerator();
	}
}
