/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.LowLevel
{
	public struct InputEventBuffer : IEnumerable<UnityEngine.InputSystem.LowLevel.InputEventPtr>, IDisposable, ICloneable // TypeDefIndex: 6462
	{
		// Fields
		public const long BufferSizeUnknown = -1; // Metadata: 0x0069906F
		private NativeArray<byte> m_Buffer; // 0x00
		private long m_SizeInBytes; // 0x10
		private int m_EventCount; // 0x18
		private bool m_WeOwnTheBuffer; // 0x1C
	
		// Properties
		public int eventCount { get; } // 0x0000000180B23260-0x0000000180B23270 
		public long sizeInBytes { get; } // 0x0000000180377550-0x0000000180377560 
		public long capacityInBytes { get; } // 0x0000000181DCB380-0x0000000181DCB390 
		public NativeArray<byte> data { get; } // 0x000000018092E600-0x000000018092E610 
		public InputEventPtr bufferPtr { get; } // 0x00000001808BADD0-0x00000001808BADE0 
	
		// Nested types
		private struct Enumerator : IEnumerator<InputEventPtr> // TypeDefIndex: 6463
		{
			// Fields
			private readonly unsafe InputEvent* m_Buffer; // 0x00
			private readonly int m_EventCount; // 0x08
			private unsafe InputEvent* m_CurrentEvent; // 0x10
			private int m_CurrentIndex; // 0x18
	
			// Properties
			public InputEventPtr Current { get; } // 0x0000000180377550-0x0000000180377560 
			object IEnumerator.Current { get; } // 0x0000000181DC3990-0x0000000181DC39E0 
	
			// Constructors
			public unsafe Enumerator(InputEventBuffer buffer); // 0x0000000181DC3B40-0x0000000181DC3B60
	
			// Methods
			public bool MoveNext(); // 0x0000000181DC38E0-0x0000000181DC3930
			public void Reset(); // 0x0000000181DC3960-0x0000000181DC3970
			public void Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
		}
	
		// Constructors
		public unsafe InputEventBuffer(InputEvent* eventPtr, int eventCount, int sizeInBytes = -1 /* Metadata: 0x00699065 */, int capacityInBytes = -1 /* Metadata: 0x00699066 */); // 0x0000000181DCB0F0-0x0000000181DCB290
		public InputEventBuffer(NativeArray<byte> buffer, int eventCount, int sizeInBytes = -1 /* Metadata: 0x00699067 */, bool transferNativeArrayOwnership = false /* Metadata: 0x00699068 */); // 0x0000000181DCB290-0x0000000181DCB380
	
		// Methods
		public unsafe void AppendEvent(InputEvent* eventPtr, int capacityIncrementInBytes = 2048 /* Metadata: 0x00699069 */, Allocator allocator = Allocator.Persistent /* Metadata: 0x0069906B */); // 0x0000000181DCADC0-0x0000000181DCAE50
		public unsafe InputEvent* AllocateEvent(int sizeInBytes, int capacityIncrementInBytes = 2048 /* Metadata: 0x0069906C */, Allocator allocator = Allocator.Persistent /* Metadata: 0x0069906E */); // 0x0000000181DCABB0-0x0000000181DCADC0
		public unsafe bool Contains(InputEvent* eventPtr); // 0x0000000181DCAEE0-0x0000000181DCAF10
		public void Reset(); // 0x0000000181DCAFF0-0x0000000181DCB010
		internal unsafe void AdvanceToNextEvent(ref InputEvent* currentReadPos, ref InputEvent* currentWritePos, ref int numEventsRetainedInBuffer, ref int numRemainingEvents, bool leaveEventInBuffer); // 0x0000000181DCAB00-0x0000000181DCABB0
		public IEnumerator<InputEventPtr> GetEnumerator(); // 0x0000000181DCAF60-0x0000000181DCAFF0
		IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181DCB010-0x0000000181DCB020
		public void Dispose(); // 0x0000000181DCAF10-0x0000000181DCAF60
		public InputEventBuffer Clone(); // 0x0000000181DCAE50-0x0000000181DCAEE0
		object ICloneable.Clone(); // 0x0000000181DCB020-0x0000000181DCB0F0
	}
}
