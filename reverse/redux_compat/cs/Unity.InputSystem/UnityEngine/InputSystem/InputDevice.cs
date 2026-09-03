/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	public class InputDevice : InputControl // TypeDefIndex: 6157
	{
		// Fields
		public const int InvalidDeviceId = 0; // Metadata: 0x00698A55
		internal const int kLocalParticipantId = 0; // Metadata: 0x00698A56
		internal const int kInvalidDeviceIndex = -1; // Metadata: 0x00698A57
		internal DeviceFlags m_DeviceFlags; // 0xE0
		internal int m_DeviceId; // 0xE4
		internal int m_ParticipantId; // 0xE8
		internal int m_DeviceIndex; // 0xEC
		internal uint m_CurrentProcessedEventBytesOnUpdate; // 0xF0
		internal InputDeviceDescription m_Description; // 0xF8
		internal double m_LastUpdateTimeInternal; // 0x130
		internal uint m_CurrentUpdateStepCount; // 0x138
		internal InternedString[] m_AliasesForEachControl; // 0x140
		internal InternedString[] m_UsagesForEachControl; // 0x148
		internal InputControl[] m_UsageToControl; // 0x150
		internal InputControl[] m_ChildrenForEachControl; // 0x158
		internal HashSet<int> m_UpdatedButtons; // 0x160
		internal List<ButtonControl> m_ButtonControlsCheckingPressState; // 0x168
		internal bool m_UseCachePathForButtonPresses; // 0x170
		internal uint[] m_StateOffsetToControlMap; // 0x178
		internal ControlBitRangeNode[] m_ControlTreeNodes; // 0x180
		internal ushort[] m_ControlTreeIndices; // 0x188
		internal const int kControlIndexBits = 10; // Metadata: 0x00698A58
		internal const int kStateOffsetBits = 13; // Metadata: 0x00698A59
		internal const int kStateSizeBits = 9; // Metadata: 0x00698A5A
	
		// Properties
		public InputDeviceDescription description { get; } // 0x0000000181D10540-0x0000000181D10580 
		public bool enabled { get; } // 0x0000000181D105B0-0x0000000181D10660 
		public bool canRunInBackground { get; } // 0x0000000181D104A0-0x0000000181D10540 
		internal bool canDeviceRunInBackground { get; } // 0x0000000181D104A0-0x0000000181D10540 
		public bool added { get; } // 0x0000000181D103A0-0x0000000181D103B0 
		public bool remote { get; } // 0x0000000181D10710-0x0000000181D10720 
		public bool native { get; } // 0x0000000181D10700-0x0000000181D10710 
		public bool updateBeforeRender { get; } // 0x0000000181D10720-0x0000000181D10730 
		public int deviceId { get; } // 0x0000000180910090-0x00000001809100A0 
		public double lastUpdateTime { get; } // 0x0000000181D106B0-0x0000000181D10700 
		public bool wasUpdatedThisFrame { get; } // 0x0000000181D107C0-0x0000000181D10810 
		public ReadOnlyArray<InputControl> allControls { get; } // 0x0000000181D103B0-0x0000000181D103E0 
		public override Type valueType { get; } // 0x0000000181D10780-0x0000000181D107C0 
		public override int valueSizeInBytes { get; } // 0x0000000181D10730-0x0000000181D10780 
		[Obsolete("Use \'InputSystem.devices\' instead. (UnityUpgradable) -> InputSystem.devices", false)]
		public static ReadOnlyArray<InputDevice> all { get; } // 0x0000000181D103E0-0x0000000181D104A0 
		internal bool disabledInFrontend { get; set; } // 0x0000000181D10580-0x0000000181D10590 0x0000000181D10810-0x0000000181D10830
		internal bool disabledInRuntime { get; set; } // 0x0000000181D10590-0x0000000181D105A0 0x0000000181D10830-0x0000000181D10860
		internal bool disabledWhileInBackground { get; set; } // 0x0000000181D105A0-0x0000000181D105B0 0x0000000181D10860-0x0000000181D10890
		internal bool hasControlsWithDefaultState { get; set; } // 0x0000000181D10660-0x0000000181D10670 0x0000000181D10890-0x0000000181D108B0
		internal bool hasDontResetControls { get; set; } // 0x0000000181D10670-0x0000000181D10680 0x0000000181D108B0-0x0000000181D108E0
		internal bool hasStateCallbacks { get; set; } // 0x0000000181D106A0-0x0000000181D106B0 0x0000000181D10940-0x0000000181D10960
		internal bool hasEventMerger { get; set; } // 0x0000000181D10680-0x0000000181D10690 0x0000000181D108E0-0x0000000181D10910
		internal bool hasEventPreProcessor { get; set; } // 0x0000000181D10690-0x0000000181D106A0 0x0000000181D10910-0x0000000181D10940
	
		// Nested types
		[Serializable]
		[Flags]
		internal enum DeviceFlags // TypeDefIndex: 6158
		{
			UpdateBeforeRender = 1,
			HasStateCallbacks = 2,
			HasControlsWithDefaultState = 4,
			Remote = 8,
			Native = 16,
			DisabledInFrontend = 32,
			DisabledStateHasBeenQueriedFromRuntime = 64,
			DisabledInRuntime = 128,
			DisabledWhileInBackground = 256,
			HasDontResetControls = 1024,
			CanRunInBackground = 2048,
			CanRunInBackgroundHasBeenQueried = 4096,
			HasEventMerger = 8192,
			HasEventPreProcessor = 16384
		}
	
		internal struct ControlBitRangeNode // TypeDefIndex: 6159
		{
			// Fields
			public ushort endBitOffset; // 0x00
			public short leftChildIndex; // 0x02
			public ushort controlStartIndex; // 0x04
			public byte controlCount; // 0x06
	
			// Constructors
			public ControlBitRangeNode(ushort endOffset); // 0x0000000181D69CD0-0x0000000181D69CE0
		}
	
		// Constructors
		public InputDevice(); // 0x0000000181D04390-0x0000000181D04400
	
		// Methods
		public override unsafe object ReadValueFromBufferAsObject(void* buffer, int bufferSize); // 0x0000000181D0F330-0x0000000181D0F370
		public override unsafe object ReadValueFromStateAsObject(void* statePtr); // 0x0000000181D0F370-0x0000000181D0F450
		public override unsafe void ReadValueFromStateIntoBuffer(void* statePtr, void* bufferPtr, int bufferSize); // 0x0000000181D0F450-0x0000000181D0F630
		public override unsafe bool CompareValue(void* firstStatePtr, void* secondStatePtr); // 0x0000000181D0E7B0-0x0000000181D0E8E0
		internal void NotifyConfigurationChanged(); // 0x0000000181D0F210-0x0000000181D0F2A0
		public virtual void MakeCurrent(); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void OnAdded(); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void OnRemoved(); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void OnConfigurationChanged(); // 0x00000001802E76C0-0x00000001802E76D0
		public long ExecuteCommand<TCommand>(ref ref TCommand command)
			where TCommand : struct, IInputDeviceCommandInfo;
		protected virtual unsafe long ExecuteCommand(InputDeviceCommand* commandPtr); // 0x0000000181D0F010-0x0000000181D0F100
		internal bool QueryEnabledStateFromRuntime(); // 0x0000000181D0F2A0-0x0000000181D0F330
		internal static uint EncodeStateOffsetToControlMapEntry(uint controlIndex, uint stateOffsetInBits, uint stateSizeInBits); // 0x0000000181D0F000-0x0000000181D0F010
		internal static void DecodeStateOffsetToControlMapEntry(uint entry, out uint controlIndex, out uint stateOffset, out uint stateSize); // 0x0000000181D0E8E0-0x0000000181D0E900
		internal void AddDeviceUsage(InternedString usage); // 0x0000000181D0E6A0-0x0000000181D0E740
		internal void RemoveDeviceUsage(InternedString usage); // 0x0000000181D0F630-0x0000000181D0F6D0
		internal void ClearDeviceUsages(); // 0x0000000181D0E740-0x0000000181D0E7B0
		internal bool RequestSync(); // 0x0000000181D0F720-0x0000000181D0F770
		internal bool RequestReset(); // 0x0000000181D0F6D0-0x0000000181D0F720
		internal bool ExecuteEnableCommand(); // 0x0000000181D0F150-0x0000000181D0F1A0
		internal bool ExecuteDisableCommand(); // 0x0000000181D0F100-0x0000000181D0F150
		internal void NotifyAdded(); // 0x0000000181475250-0x0000000181475270
		internal void NotifyRemoved(); // 0x0000000181A8A690-0x0000000181A8A6B0
		internal static TDevice Build<TDevice>(string layoutName = null, string layoutVariants = null, InputDeviceDescription deviceDescription = default, bool noPrecompiledLayouts = false /* Metadata: 0x00698A54 */)
			where TDevice : InputDevice;
		internal unsafe void WriteChangedControlStates(byte* deviceStateBuffer, void* statePtr, uint stateSizeInBytes, uint stateOffsetInDevice); // 0x0000000181D0FE00-0x0000000181D0FF70
		private void WritePartialChangedControlStatesInternal(uint stateSizeInBits, uint stateOffsetInDeviceInBits, ControlBitRangeNode parentNode, uint startOffset); // 0x0000000181D0FF70-0x0000000181D103A0
		private void DumpControlBitRangeNode(int nodeIndex, ControlBitRangeNode node, uint startOffset, uint sizeInBits, List<string> output); // 0x0000000181D0E900-0x0000000181D0ED80
		private void DumpControlTree(ControlBitRangeNode parentNode, uint startOffset, List<string> output); // 0x0000000181D0ED80-0x0000000181D0EF30
		internal string DumpControlTree(); // 0x0000000181D0EF30-0x0000000181D0F000
		private unsafe void WriteChangedControlStatesInternal(void* statePtr, byte* deviceStatePtr, ControlBitRangeNode parentNode, uint startOffset); // 0x0000000181D0F770-0x0000000181D0FE00
		private static unsafe bool HasDataChangedInRange(byte* deviceStatePtr, void* statePtr, uint startOffset, uint sizeInBits); // 0x0000000181D0F1A0-0x0000000181D0F210
	}
}
