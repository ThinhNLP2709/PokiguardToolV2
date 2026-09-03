/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	public struct InputInteractionContext // TypeDefIndex: 6123
	{
		// Fields
		internal InputActionState m_State; // 0x00
		internal Flags m_Flags; // 0x08
		internal InputActionState.TriggerState m_TriggerState; // 0x0C
	
		// Properties
		public InputAction action { get; } // 0x0000000181D11A60-0x0000000181D11A90 
		public InputControl control { get; } // 0x0000000181D11AA0-0x0000000181D11AD0 
		public InputActionPhase phase { get; } // 0x0000000181D11B10-0x0000000181D11B20 
		public double time { get; } // 0x0000000181D11B30-0x0000000181D11B40 
		public double startTime { get; } // 0x0000000181D11B20-0x0000000181D11B30 
		public bool timerHasExpired { get; internal set; } // 0x0000000181D03AF0-0x0000000181D03B00 0x0000000181D03C00-0x0000000181D03C20
		public bool isWaiting { get; } // 0x0000000181D11AF0-0x0000000181D11B00 
		public bool isStarted { get; } // 0x0000000181D11AE0-0x0000000181D11AF0 
		internal int mapIndex { get; } // 0x0000000181D11B00-0x0000000181D11B10 
		internal int controlIndex { get; } // 0x0000000181D11A90-0x0000000181D11AA0 
		internal int bindingIndex { get; } // 0x000000018172A360-0x000000018172A370 
		internal int interactionIndex { get; } // 0x0000000181D11AD0-0x0000000181D11AE0 
	
		// Nested types
		[Flags]
		internal enum Flags // TypeDefIndex: 6124
		{
			TimerHasExpired = 2
		}
	
		// Methods
		public float ComputeMagnitude(); // 0x0000000180F99790-0x0000000180F997A0
		public bool ControlIsActuated(float threshold = 0f /* Metadata: 0x0069897A */); // 0x0000000181D11780-0x0000000181D117E0
		public void Started(); // 0x0000000181D119C0-0x0000000181D11A10
		public void Performed(); // 0x0000000181D11890-0x0000000181D118F0
		public void PerformedAndStayStarted(); // 0x0000000181D11830-0x0000000181D11890
		public void PerformedAndStayPerformed(); // 0x0000000181D117E0-0x0000000181D11830
		public void Canceled(); // 0x0000000181D11730-0x0000000181D11780
		public void Waiting(); // 0x0000000181D11A10-0x0000000181D11A60
		public void SetTimeout(float seconds); // 0x0000000181D118F0-0x0000000181D11920
		public void SetTotalTimeoutCompletionTime(float seconds); // 0x0000000181D11920-0x0000000181D119C0
		public TValue ReadValue<TValue>()
			where TValue : struct;
	}
}
