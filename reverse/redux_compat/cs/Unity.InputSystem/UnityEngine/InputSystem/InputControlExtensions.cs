/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	public static class InputControlExtensions // TypeDefIndex: 6135
	{
		// Nested types
		[Flags]
		public enum Enumerate // TypeDefIndex: 6136
		{
			IgnoreControlsInDefaultState = 1,
			IgnoreControlsInCurrentState = 2,
			IncludeSyntheticControls = 4,
			IncludeNoisyControls = 8,
			IncludeNonLeafControls = 16
		}
	
		public struct InputEventControlCollection : IEnumerable<InputControl> // TypeDefIndex: 6137
		{
			// Fields
			internal InputDevice m_Device; // 0x00
			internal InputEventPtr m_EventPtr; // 0x08
			internal Enumerate m_Flags; // 0x10
			internal float m_MagnitudeThreshold; // 0x14
	
			// Properties
			public InputEventPtr eventPtr { get; } // 0x0000000180C5CF90-0x0000000180C5CFA0 
	
			// Methods
			public InputEventControlEnumerator GetEnumerator(); // 0x0000000181D10960-0x0000000181D109C0
			IEnumerator<InputControl> IEnumerable<InputControl>.GetEnumerator(); // 0x0000000181D109C0-0x0000000181D10AC0
			IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181D10AC0-0x0000000181D10BC0
		}
	
		public struct InputEventControlEnumerator : IEnumerator<InputControl> // TypeDefIndex: 6138
		{
			// Fields
			private Enumerate m_Flags; // 0x00
			private readonly InputDevice m_Device; // 0x08
			private readonly uint[] m_StateOffsetToControlIndex; // 0x10
			private readonly int m_StateOffsetToControlIndexLength; // 0x18
			private readonly InputControl[] m_AllControls; // 0x20
			private unsafe byte* m_DefaultState; // 0x28
			private unsafe byte* m_CurrentState; // 0x30
			private unsafe byte* m_NoiseMask; // 0x38
			private InputEventPtr m_EventPtr; // 0x40
			private InputControl m_CurrentControl; // 0x48
			private int m_CurrentIndexInStateOffsetToControlIndexMap; // 0x50
			private uint m_CurrentControlStateBitOffset; // 0x54
			private unsafe byte* m_EventState; // 0x58
			private uint m_CurrentBitOffset; // 0x60
			private uint m_EndBitOffset; // 0x64
			private float m_MagnitudeThreshold; // 0x68
	
			// Properties
			public InputControl Current { get; } // 0x00000001803272B0-0x00000001803272C0 
			object IEnumerator.Current { get; } // 0x00000001803272B0-0x00000001803272C0 
	
			// Constructors
			internal unsafe InputEventControlEnumerator(InputEventPtr eventPtr, InputDevice device, Enumerate flags, float magnitudeThreshold = 0f /* Metadata: 0x00698A1E */); // 0x0000000181D11540-0x0000000181D11730
	
			// Methods
			private bool CheckDefault(uint numBits); // 0x0000000181D10BF0-0x0000000181D10C20
			private bool CheckCurrent(uint numBits); // 0x0000000181D10BC0-0x0000000181D10BF0
			public bool MoveNext(); // 0x0000000181D10C20-0x0000000181D11090
			public void Reset(); // 0x0000000181D11090-0x0000000181D11540
			public void Dispose(); // 0x0000000180D90600-0x0000000180D90610
		}
	
		public struct ControlBuilder // TypeDefIndex: 6139
		{
			// Fields
			[CompilerGenerated]
			private InputControl _control_k__BackingField; // 0x00
	
			// Properties
			public InputControl control { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x00000001808BADD0-0x00000001808BADE0 0x0000000180E02C90-0x0000000180E02CA0
	
			// Methods
			public ControlBuilder At(InputDevice device, int index); // 0x0000000181D02D70-0x0000000181D02E30
			public ControlBuilder WithParent(InputControl parent); // 0x0000000181D03150-0x0000000181D03180
			public ControlBuilder WithName(string name); // 0x0000000181D030F0-0x0000000181D03150
			public ControlBuilder WithDisplayName(string displayName); // 0x0000000181D03000-0x0000000181D03070
			public ControlBuilder WithShortDisplayName(string shortDisplayName); // 0x0000000181D03180-0x0000000181D031F0
			public ControlBuilder WithLayout(InternedString layout); // 0x0000000181D03070-0x0000000181D030B0
			public ControlBuilder WithUsages(int startIndex, int count); // 0x0000000181D03220-0x0000000181D03250
			public ControlBuilder WithAliases(int startIndex, int count); // 0x0000000181D02F60-0x0000000181D02F90
			public ControlBuilder WithChildren(int startIndex, int count); // 0x0000000181D02F90-0x0000000181D02FC0
			public ControlBuilder WithStateBlock(InputStateBlock stateBlock); // 0x0000000181D031F0-0x0000000181D03220
			public ControlBuilder WithDefaultState(PrimitiveValue value); // 0x0000000181D02FC0-0x0000000181D03000
			public ControlBuilder WithMinAndMax(PrimitiveValue min, PrimitiveValue max); // 0x0000000181D030B0-0x0000000181D030F0
			public ControlBuilder WithProcessor<TProcessor, TValue>(TProcessor processor)
				where TProcessor : InputProcessor<TValue>
				where TValue : struct;
			public ControlBuilder IsNoisy(bool value); // 0x0000000181D02EF0-0x0000000181D02F20
			public ControlBuilder IsSynthetic(bool value); // 0x0000000181D02F20-0x0000000181D02F60
			public ControlBuilder DontReset(bool value); // 0x0000000181D02E30-0x0000000181D02E90
			public ControlBuilder IsButton(bool value); // 0x0000000181D02EB0-0x0000000181D02EF0
			public void Finish(); // 0x0000000181D02E90-0x0000000181D02EB0
		}
	
		public struct DeviceBuilder // TypeDefIndex: 6140
		{
			// Fields
			[CompilerGenerated]
			private InputDevice _device_k__BackingField; // 0x00
	
			// Properties
			public InputDevice device { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x00000001808BADD0-0x00000001808BADE0 0x0000000180E02C90-0x0000000180E02CA0
	
			// Methods
			public DeviceBuilder WithName(string name); // 0x0000000181D030F0-0x0000000181D03150
			public DeviceBuilder WithDisplayName(string displayName); // 0x0000000181D03000-0x0000000181D03070
			public DeviceBuilder WithShortDisplayName(string shortDisplayName); // 0x0000000181D03180-0x0000000181D031F0
			public DeviceBuilder WithLayout(InternedString layout); // 0x0000000181D03070-0x0000000181D030B0
			public DeviceBuilder WithChildren(int startIndex, int count); // 0x0000000181D02F90-0x0000000181D02FC0
			public DeviceBuilder WithStateBlock(InputStateBlock stateBlock); // 0x0000000181D031F0-0x0000000181D03220
			public DeviceBuilder IsNoisy(bool value); // 0x0000000181D02EF0-0x0000000181D02F20
			public DeviceBuilder WithControlUsage(int controlIndex, InternedString usage, InputControl control); // 0x0000000181D03670-0x0000000181D03750
			public DeviceBuilder WithControlAlias(int controlIndex, InternedString alias); // 0x0000000181D034B0-0x0000000181D03510
			public DeviceBuilder WithStateOffsetToControlIndexMap(uint[] map); // 0x0000000181D03750-0x0000000181D03790
			public DeviceBuilder WithControlTree(byte[] controlTreeNodes, ushort[] controlTreeIndicies); // 0x0000000181D03510-0x0000000181D03670
			public void Finish(); // 0x0000000181D03250-0x0000000181D034B0
		}
	
		[CompilerGenerated]
		private sealed class _GetAllButtonPresses_d__43 : IEnumerable<InputControl>, IEnumerator<InputControl> // TypeDefIndex: 6141
		{
			// Fields
			private int __1__state; // 0x10
			private InputControl __2__current; // 0x18
			private int __l__initialThreadId; // 0x20
			private InputEventPtr eventPtr; // 0x28
			public InputEventPtr __3__eventPtr; // 0x30
			private float magnitude; // 0x38
			public float __3__magnitude; // 0x3C
			private bool buttonControlsOnly; // 0x40
			public bool __3__buttonControlsOnly; // 0x41
			private InputEventControlEnumerator __7__wrap1; // 0x48
	
			// Properties
			InputControl IEnumerator<UnityEngine.InputSystem.InputControl>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _GetAllButtonPresses_d__43(int __1__state); // 0x0000000180A5D530-0x0000000180A5D560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000181D19D90-0x0000000181D19E30
			private bool MoveNext(); // 0x0000000181D19980-0x0000000181D19CA0
			private void __m__Finally1(); // 0x0000000181D19E30-0x0000000181D19E50
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000181D19D50-0x0000000181D19D90
			[DebuggerHidden]
			IEnumerator<InputControl> IEnumerable<InputControl>.GetEnumerator(); // 0x0000000181D19CA0-0x0000000181D19D50
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181D19CA0-0x0000000181D19D50
		}
	
		// Extension methods
		public static TControl FindInParentChain<TControl>(this InputControl control)
			where TControl : InputControl;
		public static bool IsPressed(this InputControl control, float buttonPressPoint = 0f /* Metadata: 0x006989F2 */); // 0x0000000181D09320-0x0000000181D09440
		public static bool IsActuated(this InputControl control, float threshold = 0f /* Metadata: 0x006989F6 */); // 0x0000000181D09130-0x0000000181D09320
		public static object ReadValueAsObject(this InputControl control); // 0x0000000181D094E0-0x0000000181D09570
		public static unsafe void ReadValueIntoBuffer(this InputControl control, void* buffer, int bufferSize); // 0x0000000181D09640-0x0000000181D09740
		public static object ReadDefaultValueAsObject(this InputControl control); // 0x0000000181D09440-0x0000000181D094E0
		public static TValue ReadValueFromEvent<TValue>(this InputControl<TValue> control, InputEventPtr inputEvent)
			where TValue : struct;
		public static bool ReadValueFromEvent<TValue>(this InputControl<TValue> control, InputEventPtr inputEvent, out ref TValue value)
			where TValue : struct;
		public static object ReadValueFromEventAsObject(this InputControl control, InputEventPtr inputEvent); // 0x0000000181D09570-0x0000000181D09640
		public static TValue ReadUnprocessedValueFromEvent<TValue>(this InputControl<TValue> control, InputEventPtr eventPtr)
			where TValue : struct;
		public static bool ReadUnprocessedValueFromEvent<TValue>(this InputControl<TValue> control, InputEventPtr inputEvent, out ref TValue value)
			where TValue : struct;
		public static void WriteValueFromObjectIntoEvent(this InputControl control, InputEventPtr eventPtr, object value); // 0x0000000181D09D00-0x0000000181D09DA0
		public static unsafe void WriteValueIntoState(this InputControl control, void* statePtr); // 0x0000000181D09DA0-0x0000000181D09F60
		public static unsafe void WriteValueIntoState<TValue>(this InputControl control, TValue value, void* statePtr)
			where TValue : struct;
		public static unsafe void WriteValueIntoState<TValue>(this InputControl<TValue> control, TValue value, void* statePtr)
			where TValue : struct;
		public static unsafe void WriteValueIntoState<TValue>(this InputControl<TValue> control, void* statePtr)
			where TValue : struct;
		public static void WriteValueIntoState<TValue, TState>(this InputControl<TValue> control, TValue value, ref ref TState state)
			where TValue : struct
			where TState : struct, IInputStateTypeInfo;
		public static void WriteValueIntoEvent<TValue>(this InputControl control, TValue value, InputEventPtr eventPtr)
			where TValue : struct;
		public static void WriteValueIntoEvent<TValue>(this InputControl<TValue> control, TValue value, InputEventPtr eventPtr)
			where TValue : struct;
		public static unsafe void CopyState(this InputDevice device, void* buffer, int bufferSizeInBytes); // 0x0000000181D08210-0x0000000181D083B0
		public static void CopyState<TState>(this InputDevice device, out ref TState state)
			where TState : struct, IInputStateTypeInfo;
		public static bool CheckStateIsAtDefault(this InputControl control); // 0x0000000181D07DD0-0x0000000181D07EE0
		public static unsafe bool CheckStateIsAtDefault(this InputControl control, void* statePtr, void* maskPtr = null); // 0x0000000181D07CC0-0x0000000181D07DD0
		public static bool CheckStateIsAtDefaultIgnoringNoise(this InputControl control); // 0x0000000181D07A30-0x0000000181D07B80
		public static unsafe bool CheckStateIsAtDefaultIgnoringNoise(this InputControl control, void* statePtr); // 0x0000000181D07B80-0x0000000181D07CC0
		public static unsafe bool CompareStateIgnoringNoise(this InputControl control, void* statePtr); // 0x0000000181D07EE0-0x0000000181D08000
		public static unsafe bool CompareState(this InputControl control, void* firstStatePtr, void* secondStatePtr, void* maskPtr = null); // 0x0000000181D08100-0x0000000181D08210
		public static unsafe bool CompareState(this InputControl control, void* statePtr, void* maskPtr = null); // 0x0000000181D08000-0x0000000181D08100
		public static unsafe bool HasValueChangeInState(this InputControl control, void* statePtr); // 0x0000000181D09040-0x0000000181D09130
		public static bool HasValueChangeInEvent(this InputControl control, InputEventPtr eventPtr); // 0x0000000181D08F20-0x0000000181D09040
		public static unsafe void* GetStatePtrFromStateEvent(this InputControl control, InputEventPtr eventPtr); // 0x0000000181D08E10-0x0000000181D08F00
		internal static unsafe void* GetStatePtrFromStateEventUnchecked(this InputControl control, InputEventPtr eventPtr, FourCC eventType); // 0x0000000181D08B00-0x0000000181D08E10
		public static bool ResetToDefaultStateInEvent(this InputControl control, InputEventPtr eventPtr); // 0x0000000181D09740-0x0000000181D09940
		public static void QueueValueChange<TValue>(this InputControl<TValue> control, TValue value, double time = -1 /* Metadata: 0x006989FA */)
			where TValue : struct;
		public static unsafe void AccumulateValueInEvent(this InputControl<float> control, void* currentStatePtr, InputEventPtr newState); // 0x0000000181D074C0-0x0000000181D075C0
		internal static unsafe void AccumulateValueInEvent(this InputControl<Vector2> control, void* currentStatePtr, InputEventPtr newState); // 0x0000000181D075C0-0x0000000181D076D0
		public static void FindControlsRecursive<TControl>(this InputControl parent, IList<TControl> controls, Func<TControl, bool> predicate)
			where TControl : InputControl;
		internal static string BuildPath(this InputControl control, string deviceLayout, StringBuilder builder = null); // 0x0000000181D076D0-0x0000000181D07A30
		public static InputEventControlCollection EnumerateControls(this InputEventPtr eventPtr, Enumerate flags, InputDevice device = null, float magnitudeThreshold = 0f /* Metadata: 0x00698A02 */); // 0x0000000181D08400-0x0000000181D086C0
		public static InputEventControlCollection EnumerateChangedControls(this InputEventPtr eventPtr, InputDevice device = null, float magnitudeThreshold = 0f /* Metadata: 0x00698A06 */); // 0x0000000181D083B0-0x0000000181D08400
		public static bool HasButtonPress(this InputEventPtr eventPtr, float magnitude = -1f /* Metadata: 0x00698A0A */, bool buttonControlsOnly = true /* Metadata: 0x00698A0E */); // 0x0000000181D08F00-0x0000000181D08F20
		public static InputControl GetFirstButtonPressOrNull(this InputEventPtr eventPtr, float magnitude = -1f /* Metadata: 0x00698A0F */, bool buttonControlsOnly = true /* Metadata: 0x00698A13 */); // 0x0000000181D08750-0x0000000181D08B00
		[IteratorStateMachine(typeof(_GetAllButtonPresses_d__43))]
		public static IEnumerable<InputControl> GetAllButtonPresses(this InputEventPtr eventPtr, float magnitude = -1f /* Metadata: 0x00698A14 */, bool buttonControlsOnly = true /* Metadata: 0x00698A18 */); // 0x0000000181D086C0-0x0000000181D08750
		public static ControlBuilder Setup(this InputControl control); // 0x0000000181D09C20-0x0000000181D09D00
		public static DeviceBuilder Setup(this InputDevice device, int controlCount, int usageCount, int aliasCount); // 0x0000000181D09940-0x0000000181D09C20
	}
}
