/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Profiling;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	[InputControlLayout(stateType = typeof(TouchscreenState), isGenericTypeOfDevice = true)]
	public class Touchscreen : Pointer, IInputStateCallbackReceiver, IEventMerger, ICustomDeviceReset // TypeDefIndex: 6210
	{
		// Fields
		[CompilerGenerated]
		private TouchControl _primaryTouch_k__BackingField; // 0x1C0
		[CompilerGenerated]
		private ReadOnlyArray<TouchControl> _touches_k__BackingField; // 0x1C8
		private static readonly ProfilerMarker k_TouchscreenUpdateMarker; // 0x00
		private static readonly ProfilerMarker k_TouchAllocateMarker; // 0x08
		[CompilerGenerated]
		private static Touchscreen _current_k__BackingField; // 0x10
		internal static float s_TapTime; // 0x18
		internal static float s_TapDelayTime; // 0x1C
		internal static float s_TapRadiusSquared; // 0x20
	
		// Properties
		public TouchControl primaryTouch { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181CB22C0-0x0000000181CB22D0 0x0000000181975200-0x0000000181975220
		public ReadOnlyArray<TouchControl> touches { [CompilerGenerated] get; [CompilerGenerated] protected set; } // 0x0000000181D89E60-0x0000000181D89E70 0x0000000181D89F20-0x0000000181D89F40
		protected TouchControl[] touchControlArray { get; set; } // 0x0000000181CB2300-0x0000000181CB2310 0x0000000181D89EE0-0x0000000181D89F20
		public static new Touchscreen current { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x0000000181D89E10-0x0000000181D89E60 0x0000000181D89E70-0x0000000181D89EE0
	
		// Constructors
		public Touchscreen(); // 0x0000000181CC2A30-0x0000000181CC2A40
		static Touchscreen(); // 0x0000000181D89D70-0x0000000181D89E10
	
		// Methods
		public override void MakeCurrent(); // 0x0000000181D88690-0x0000000181D88790
		protected override void OnRemoved(); // 0x0000000181D88C60-0x0000000181D88D60
		protected override void FinishSetup(); // 0x0000000181D88300-0x0000000181D88690
		protected new void OnNextUpdate(); // 0x0000000181D888B0-0x0000000181D88C60
		protected new void OnStateEvent(InputEventPtr eventPtr); // 0x0000000181D88D60-0x0000000181D89580
		new void IInputStateCallbackReceiver.OnNextUpdate(); // 0x0000000181D89D50-0x0000000181D89D60
		new void IInputStateCallbackReceiver.OnStateEvent(InputEventPtr eventPtr); // 0x0000000181D89D60-0x0000000181D89D70
		new bool IInputStateCallbackReceiver.GetStateOffsetForEvent(InputControl control, InputEventPtr eventPtr, ref uint offset); // 0x0000000181D89B00-0x0000000181D89D50
		void ICustomDeviceReset.Reset(); // 0x0000000181D89640-0x0000000181D899A0
		internal static bool MergeForward(InputEventPtr currentEventPtr, InputEventPtr nextEventPtr); // 0x0000000181D88790-0x0000000181D888B0
		bool IEventMerger.MergeForward(InputEventPtr currentEventPtr, InputEventPtr nextEventPtr); // 0x0000000181D899A0-0x0000000181D89B00
		private static void TriggerTap(TouchControl control, ref TouchState state, InputEventPtr eventPtr); // 0x0000000181D89580-0x0000000181D89640
	}
}
