/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Controls
{
	[InputControlLayout(stateType = typeof(TouchState))]
	public class TouchControl : InputControl<TouchState> // TypeDefIndex: 6573
	{
		// Fields
		[CompilerGenerated]
		private TouchPressControl _press_k__BackingField; // 0x170
		[CompilerGenerated]
		private IntegerControl _displayIndex_k__BackingField; // 0x178
		[CompilerGenerated]
		private IntegerControl _touchId_k__BackingField; // 0x180
		[CompilerGenerated]
		private Vector2Control _position_k__BackingField; // 0x188
		[CompilerGenerated]
		private DeltaControl _delta_k__BackingField; // 0x190
		[CompilerGenerated]
		private AxisControl _pressure_k__BackingField; // 0x198
		[CompilerGenerated]
		private Vector2Control _radius_k__BackingField; // 0x1A0
		[CompilerGenerated]
		private TouchPhaseControl _phase_k__BackingField; // 0x1A8
		[CompilerGenerated]
		private ButtonControl _indirectTouch_k__BackingField; // 0x1B0
		[CompilerGenerated]
		private ButtonControl _tap_k__BackingField; // 0x1B8
		[CompilerGenerated]
		private IntegerControl _tapCount_k__BackingField; // 0x1C0
		[CompilerGenerated]
		private DoubleControl _startTime_k__BackingField; // 0x1C8
		[CompilerGenerated]
		private Vector2Control _startPosition_k__BackingField; // 0x1D0
	
		// Properties
		public TouchPressControl press { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181974700-0x0000000181974710 0x00000001813800D0-0x00000001813800F0
		public IntegerControl displayIndex { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181CF6CA0-0x0000000181CF6CB0 0x00000001813800F0-0x0000000181380110
		public IntegerControl touchId { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181C4BCD0-0x0000000181C4BCE0 0x0000000181CF6CF0-0x0000000181CF6D10
		public Vector2Control position { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D500-0x000000018033D510 0x000000018033EA90-0x000000018033EAB0
		public DeltaControl delta { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181C4BDF0-0x0000000181C4BE00 0x0000000181380110-0x0000000181380130
		public AxisControl pressure { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181CC2A40-0x0000000181CC2A50 0x0000000181CC2A60-0x0000000181CC2A80
		public Vector2Control radius { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181CC2A50-0x0000000181CC2A60 0x0000000181CC2A80-0x0000000181CC2AA0
		public TouchPhaseControl phase { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180E224F0-0x0000000180E22500 0x000000018033A5B0-0x000000018033A5D0
		public ButtonControl indirectTouch { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181CB22F0-0x0000000181CB2300 0x0000000181380130-0x0000000181380150
		public ButtonControl tap { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D6C0-0x000000018033D6D0 0x000000018033ECB0-0x000000018033ECD0
		public IntegerControl tapCount { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181CB22C0-0x0000000181CB22D0 0x0000000181975200-0x0000000181975220
		public DoubleControl startTime { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181CB2300-0x0000000181CB2310 0x0000000181CB2390-0x0000000181CB23B0
		public Vector2Control startPosition { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181CB22D0-0x0000000181CB22E0 0x0000000181380150-0x0000000181380170
		public bool isInProgress { get; } // 0x0000000181CF6CB0-0x0000000181CF6CF0 
	
		// Constructors
		public TouchControl(); // 0x0000000181CF6C40-0x0000000181CF6CA0
	
		// Methods
		protected override void FinishSetup(); // 0x0000000181CF67B0-0x0000000181CF6B30
		public override unsafe TouchState ReadUnprocessedValueFromState(void* statePtr); // 0x0000000181CF6B30-0x0000000181CF6BC0
		public override unsafe void WriteValueIntoState(TouchState value, void* statePtr); // 0x0000000181CF6BC0-0x0000000181CF6C40
	}
}
