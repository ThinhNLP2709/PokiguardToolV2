/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Controls
{
	public class ButtonControl : AxisControl // TypeDefIndex: 6561
	{
		// Fields
		private bool m_NeedsToCheckFramePress; // 0x130
		private uint m_UpdateCountLastPressed; // 0x134
		private uint m_UpdateCountLastReleased; // 0x138
		private bool m_LastUpdateWasPress; // 0x13C
		[CompilerGenerated]
		private bool _needsToCheckFramePress_k__BackingField; // 0x13D
		public float pressPoint; // 0x140
		internal static float s_GlobalDefaultButtonPressPoint; // 0x00
		internal static float s_GlobalDefaultButtonReleaseThreshold; // 0x04
		internal const float kMinButtonPressPoint = 0.0001f; // Metadata: 0x00699180
	
		// Properties
		internal bool needsToCheckFramePress { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181CE4E50-0x0000000181CE4E60 0x0000000181CE50A0-0x0000000181CE50B0
		public float pressPointOrDefault { get; } // 0x0000000181CE4E60-0x0000000181CE4EC0 
		public bool isPressed { get; } // 0x0000000181CE4E10-0x0000000181CE4E50 
		public bool wasPressedThisFrame { get; } // 0x0000000181CE4EC0-0x0000000181CE4FB0 
		public bool wasReleasedThisFrame { get; } // 0x0000000181CE4FB0-0x0000000181CE50A0 
	
		// Constructors
		public ButtonControl(); // 0x0000000181CE4D10-0x0000000181CE4E10
	
		// Methods
		public new bool IsValueConsideredPressed(float value); // 0x0000000181CE38E0-0x0000000181CE3A00
		private void BeginTestingForFramePresses(bool currentlyPressed, bool pressedLastFrame); // 0x0000000181CE4B80-0x0000000181CE4CA0
		internal void UpdateWasPressed(); // 0x0000000181CE4CA0-0x0000000181CE4D10
	}
}
