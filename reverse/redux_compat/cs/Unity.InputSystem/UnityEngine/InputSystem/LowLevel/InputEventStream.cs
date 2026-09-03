/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.LowLevel
{
	internal struct InputEventStream // TypeDefIndex: 6469
	{
		// Fields
		private InputEventBuffer m_NativeBuffer; // 0x00
		private unsafe InputEvent* m_CurrentNativeEventReadPtr; // 0x20
		private unsafe InputEvent* m_CurrentNativeEventWritePtr; // 0x28
		private int m_RemainingNativeEventCount; // 0x30
		private readonly int m_MaxAppendedEvents; // 0x34
		private InputEventBuffer m_AppendBuffer; // 0x38
		private unsafe InputEvent* m_CurrentAppendEventReadPtr; // 0x58
		private unsafe InputEvent* m_CurrentAppendEventWritePtr; // 0x60
		private int m_RemainingAppendEventCount; // 0x68
		private int m_NumEventsRetainedInBuffer; // 0x6C
		private bool m_IsOpen; // 0x70
	
		// Properties
		public bool isOpen { get; } // 0x0000000180643BD0-0x0000000180643BE0 
		public int remainingEventCount { get; } // 0x0000000181DCC5A0-0x0000000181DCC5B0 
		public int numEventsRetainedInBuffer { get; } // 0x0000000180C55C40-0x0000000180C55C50 
		public unsafe InputEvent* currentEventPtr { get; } // 0x0000000181DCC570-0x0000000181DCC590 
		public uint numBytesRetainedInBuffer { get; } // 0x0000000181DCC590-0x0000000181DCC5A0 
	
		// Constructors
		public unsafe InputEventStream(ref InputEventBuffer eventBuffer, int maxAppendedEvents); // 0x0000000181DCC520-0x0000000181DCC570
	
		// Methods
		public void Close(ref InputEventBuffer eventBuffer); // 0x0000000181DCC0F0-0x0000000181DCC330
		public void CleanUpAfterException(); // 0x0000000181DCC070-0x0000000181DCC0F0
		public unsafe void Write(InputEvent* eventPtr); // 0x0000000181DCC370-0x0000000181DCC520
		public unsafe InputEvent* Advance(bool leaveEventInBuffer); // 0x0000000181DCBFD0-0x0000000181DCC070
		public unsafe InputEvent* Peek(); // 0x0000000181DCC330-0x0000000181DCC370
	}
}
