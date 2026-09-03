/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Interactions
{
	public class MultiTapInteraction : IInputInteraction<float> // TypeDefIndex: 6579
	{
		// Fields
		[Tooltip("The maximum time (in seconds) allowed to elapse between pressing and releasing a control for it to register as a tap.")]
		public float tapTime; // 0x10
		[Tooltip("The maximum delay (in seconds) allowed between each tap. If this time is exceeded, the multi-tap is canceled.")]
		public float tapDelay; // 0x14
		[Tooltip("How many taps need to be performed in succession. Two means double-tap, three means triple-tap, and so on.")]
		public int tapCount; // 0x18
		public float pressPoint; // 0x1C
		private TapPhase m_CurrentTapPhase; // 0x20
		private int m_CurrentTapCount; // 0x24
		private double m_CurrentTapStartTime; // 0x28
		private double m_LastTapReleaseTime; // 0x30
	
		// Properties
		private float tapTimeOrDefault { get; } // 0x0000000181CF56D0-0x0000000181CF5740 
		internal float tapDelayOrDefault { get; } // 0x0000000181CF5660-0x0000000181CF56D0 
		private float pressPointOrDefault { get; } // 0x0000000181CF5580-0x0000000181CF55E0 
		private float releasePointOrDefault { get; } // 0x0000000181CF55E0-0x0000000181CF5660 
	
		// Nested types
		private enum TapPhase // TypeDefIndex: 6580
		{
			None = 0,
			WaitingForNextRelease = 1,
			WaitingForNextPress = 2
		}
	
		// Constructors
		public MultiTapInteraction(); // 0x0000000181CF5570-0x0000000181CF5580
	
		// Methods
		public void Process(ref InputInteractionContext context); // 0x0000000181CF52D0-0x0000000181CF5560
		public void Reset(); // 0x0000000181CF5560-0x0000000181CF5570
	}
}
