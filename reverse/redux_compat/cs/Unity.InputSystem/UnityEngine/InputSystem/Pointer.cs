/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	[InputControlLayout(stateType = typeof(PointerState), isGenericTypeOfDevice = true)]
	public class Pointer : InputDevice, IInputStateCallbackReceiver // TypeDefIndex: 6168
	{
		// Fields
		[CompilerGenerated]
		private Vector2Control _position_k__BackingField; // 0x190
		[CompilerGenerated]
		private DeltaControl _delta_k__BackingField; // 0x198
		[CompilerGenerated]
		private Vector2Control _radius_k__BackingField; // 0x1A0
		[CompilerGenerated]
		private AxisControl _pressure_k__BackingField; // 0x1A8
		[CompilerGenerated]
		private ButtonControl _press_k__BackingField; // 0x1B0
		[CompilerGenerated]
		private IntegerControl _displayIndex_k__BackingField; // 0x1B8
		[CompilerGenerated]
		private static Pointer _current_k__BackingField; // 0x00
	
		// Properties
		public Vector2Control position { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181C4BDF0-0x0000000181C4BE00 0x0000000181380110-0x0000000181380130
		public DeltaControl delta { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CC2A40-0x0000000181CC2A50 0x0000000181CC2A60-0x0000000181CC2A80
		public Vector2Control radius { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CC2A50-0x0000000181CC2A60 0x0000000181CC2A80-0x0000000181CC2AA0
		public AxisControl pressure { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000180E224F0-0x0000000180E22500 0x000000018033A5B0-0x000000018033A5D0
		public ButtonControl press { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22F0-0x0000000181CB2300 0x0000000181380130-0x0000000181380150
		public IntegerControl displayIndex { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x000000018033D6C0-0x000000018033D6D0 0x000000018033ECB0-0x000000018033ECD0
		public static Pointer current { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x0000000181D86820-0x0000000181D86860 0x0000000181D86860-0x0000000181D868C0
	
		// Constructors
		public Pointer(); // 0x0000000181CC2A30-0x0000000181CC2A40
	
		// Methods
		public override void MakeCurrent(); // 0x0000000181D86660-0x0000000181D866C0
		protected override void OnRemoved(); // 0x0000000181D86730-0x0000000181D867C0
		protected override void FinishSetup(); // 0x0000000181D864A0-0x0000000181D86660
		protected void OnNextUpdate(); // 0x0000000181D866C0-0x0000000181D86730
		protected void OnStateEvent(InputEventPtr eventPtr); // 0x0000000181D867C0-0x0000000181D86820
		void IInputStateCallbackReceiver.OnNextUpdate(); // 0x0000000181D866C0-0x0000000181D86730
		void IInputStateCallbackReceiver.OnStateEvent(InputEventPtr eventPtr); // 0x0000000181D867C0-0x0000000181D86820
		bool IInputStateCallbackReceiver.GetStateOffsetForEvent(InputControl control, InputEventPtr eventPtr, ref uint offset); // 0x00000001802E7840-0x00000001802E7850
	}
}
