/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Interactions
{
	[DisplayName("Hold")]
	public class HoldInteraction : IInputInteraction // TypeDefIndex: 6578
	{
		// Fields
		public float duration; // 0x10
		public float pressPoint; // 0x14
		private double m_TimePressed; // 0x18
	
		// Properties
		private float durationOrDefault { get; } // 0x0000000181CE71E0-0x0000000181CE7250 
		private float pressPointOrDefault { get; } // 0x0000000181CE7250-0x0000000181CE72B0 
	
		// Constructors
		public HoldInteraction(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void Process(ref InputInteractionContext context); // 0x0000000181CE7090-0x0000000181CE71D0
		public void Reset(); // 0x0000000181CE71D0-0x0000000181CE71E0
	}
}
