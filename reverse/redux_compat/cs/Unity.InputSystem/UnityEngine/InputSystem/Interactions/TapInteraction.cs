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
	[DisplayName("Tap")]
	public class TapInteraction : IInputInteraction // TypeDefIndex: 6584
	{
		// Fields
		public float duration; // 0x10
		public float pressPoint; // 0x14
		private double m_TapStartTime; // 0x18
		private bool canceledFromTimerExpired; // 0x20
	
		// Properties
		private float durationOrDefault { get; } // 0x0000000181CF6660-0x0000000181CF66D0 
		private float pressPointOrDefault { get; } // 0x0000000181CF66D0-0x0000000181CF6730 
		private float releasePointOrDefault { get; } // 0x0000000181CF6730-0x0000000181CF67B0 
	
		// Constructors
		public TapInteraction(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void Process(ref InputInteractionContext context); // 0x0000000181CF64E0-0x0000000181CF6660
		public void Reset(); // 0x0000000181CE71D0-0x0000000181CE71E0
	}
}
