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
	[DisplayName("Long Tap")]
	public class SlowTapInteraction : IInputInteraction // TypeDefIndex: 6583
	{
		// Fields
		public float duration; // 0x10
		public float pressPoint; // 0x14
		private double m_SlowTapStartTime; // 0x18
	
		// Properties
		private float durationOrDefault { get; } // 0x0000000181CF62F0-0x0000000181CF6360 
		private float pressPointOrDefault { get; } // 0x0000000181CF6360-0x0000000181CF63C0 
	
		// Constructors
		public SlowTapInteraction(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void Process(ref InputInteractionContext context); // 0x0000000181CF6140-0x0000000181CF62F0
		public void Reset(); // 0x0000000181CE71D0-0x0000000181CE71E0
	}
}
