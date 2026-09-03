/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Profiling;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	internal class InputManager // TypeDefIndex: 6214
	{
		// Fields
		private static readonly ProfilerMarker k_InputUpdateProfilerMarker; // 0x00
		private static readonly ProfilerMarker k_InputTryFindMatchingControllerMarker; // 0x08
		private static readonly ProfilerMarker k_InputAddDeviceMarker; // 0x10
		private static readonly ProfilerMarker k_InputRestoreDevicesAfterReloadMarker; // 0x18
		private static readonly ProfilerMarker k_InputRegisterCustomTypesMarker; // 0x20
		private static readonly ProfilerMarker k_InputOnBeforeUpdateMarker; // 0x28
		private static readonly ProfilerMarker k_InputOnAfterUpdateMarker; // 0x30
		private static readonly ProfilerMarker k_InputOnSettingsChangeMarker; // 0x38
		private static readonly ProfilerMarker k_InputOnDeviceSettingsChangeMarker; // 0x40
		private static readonly ProfilerMarker k_InputOnEventMarker; // 0x48
		private static readonly ProfilerMarker k_InputOnLayoutChangeMarker; // 0x50
		private static readonly ProfilerMarker k_InputOnDeviceChangeMarker; // 0x58
		private static readonly ProfilerMarker k_InputOnActionsChangeMarker; // 0x60
		private bool m_CustomTypesRegistered; // 0x10
		internal int m_LayoutRegistrationVersion; // 0x14
		private InputEventHandledPolicy m_InputEventHandledPolicy; // 0x18
		internal InputControlLayout.Collection m_Layouts; // 0x20
		private TypeTable m_Processors; // 0x60
		private TypeTable m_Interactions; // 0x70
		private TypeTable m_Composites; // 0x80
		private int m_DevicesCount; // 0x90
		private InputDevice[] m_Devices; // 0x98
		private Dictionary<int, InputDevice> m_DevicesById; // 0xA0
		internal int m_AvailableDeviceCount; // 0xA8
		internal AvailableDevice[] m_AvailableDevices; // 0xB0
		internal int m_DisconnectedDevicesCount; // 0xB8
		internal InputDevice[] m_DisconnectedDevices; // 0xC0
		internal InputUpdateType m_UpdateMask; // 0xC8
		private InputUpdateType m_CurrentUpdate; // 0xCC
		internal InputStateBuffers m_StateBuffers; // 0xD0
		private InputSettings.ScrollDeltaBehavior m_ScrollDeltaBehavior; // 0x108
		private CallbackArray<Action<InputDevice, InputDeviceChange>> m_DeviceChangeListeners; // 0x110
		private CallbackArray<Action<InputDevice, InputEventPtr>> m_DeviceStateChangeListeners; // 0x160
		private CallbackArray<InputDeviceFindControlLayoutDelegate> m_DeviceFindLayoutCallbacks; // 0x1B0
		internal CallbackArray<InputDeviceCommandDelegate> m_DeviceCommandCallbacks; // 0x200
		private CallbackArray<Action<string, InputControlLayoutChange>> m_LayoutChangeListeners; // 0x250
		private CallbackArray<Action<InputEventPtr, InputDevice>> m_EventListeners; // 0x2A0
		private CallbackArray<Action> m_BeforeUpdateListeners; // 0x2F0
		private CallbackArray<Action> m_AfterUpdateListeners; // 0x340
		private CallbackArray<Action> m_SettingsChangedListeners; // 0x390
		private CallbackArray<Action> m_ActionsChangedListeners; // 0x3E0
		private bool m_NativeBeforeUpdateHooked; // 0x430
		private bool m_HaveDevicesWithStateCallbackReceivers; // 0x431
		private bool m_HasFocus; // 0x432
		private bool m_DiscardOutOfFocusEvents; // 0x433
		private double m_FocusRegainedTime; // 0x438
		private InputEventStream m_InputEventStream; // 0x440
		private InputDeviceExecuteCommandDelegate m_DeviceFindExecuteCommandDelegate; // 0x4B8
		private int m_DeviceFindExecuteCommandDeviceId; // 0x4C0
		internal IInputRuntime m_Runtime; // 0x4C8
		internal InputMetrics m_Metrics; // 0x4D0
		internal InputSettings m_Settings; // 0x508
		private bool m_OptimizedControlsFeatureEnabled; // 0x510
		private bool m_ReadValueCachingFeatureEnabled; // 0x511
		private bool m_ParanoidReadValueCachingChecksEnabled; // 0x512
		private InputActionAsset m_Actions; // 0x518
		private bool m_ShouldMakeCurrentlyUpdatingDeviceCurrent; // 0x520
		internal StateChangeMonitorsForDevice[] m_StateChangeMonitors; // 0x528
		private InlinedArray<StateChangeMonitorTimeout> m_StateChangeMonitorTimeouts; // 0x530
	
		// Properties
		public ReadOnlyArray<InputDevice> devices { get; } // 0x0000000181D7F280-0x0000000181D7F2C0 
		public TypeTable processors { get; } // 0x00000001816A56A0-0x00000001816A56B0 
		public TypeTable interactions { get; } // 0x000000018172A380-0x000000018172A390 
		public TypeTable composites { get; } // 0x0000000181D7F250-0x0000000181D7F260 
		public InputMetrics metrics { get; } // 0x0000000181D7F340-0x0000000181D7F4A0 
		public InputSettings settings { get; set; } // 0x0000000181D7F5B0-0x0000000181D7F5C0 0x0000000181D7FBA0-0x0000000181D7FC80
		public InputActionAsset actions { get; set; } // 0x0000000181D7F240-0x0000000181D7F250 0x0000000181D7F8E0-0x0000000181D7F910
		public InputUpdateType updateMask { get; set; } // 0x000000018158B020-0x000000018158B030 0x0000000181D7FC80-0x0000000181D7FCA0
		public InputUpdateType defaultUpdateType { get; } // 0x0000000181D7F260-0x0000000181D7F280 
		public InputSettings.ScrollDeltaBehavior scrollDeltaBehavior { get; set; } // 0x0000000181D7F5A0-0x0000000181D7F5B0 0x0000000181D7FAB0-0x0000000181D7FBA0
		public float pollingFrequency { get; set; } // 0x0000000181D7F4C0-0x0000000181D7F590 0x0000000181D7F9D0-0x0000000181D7FAA0
		internal InputEventHandledPolicy inputEventHandledPolicy { get; set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000181D7F910-0x0000000181D7F9B0
		public bool isProcessingEvents { get; } // 0x0000000181D7F330-0x0000000181D7F340 
		private bool gameIsPlaying { get; } // 0x00000001802E7990-0x00000001802E79A0 
		private bool gameHasFocus { get; } // 0x0000000181D7F2C0-0x0000000181D7F300 
		private bool gameShouldGetInputRegardlessOfFocus { get; } // 0x0000000181D7F300-0x0000000181D7F330 
		internal bool optimizedControlsFeatureEnabled { get; set; } // 0x0000000181D7F4A0-0x0000000181D7F4B0 0x0000000181D7F9B0-0x0000000181D7F9C0
		internal bool readValueCachingFeatureEnabled { get; set; } // 0x0000000181D7F590-0x0000000181D7F5A0 0x0000000181D7FAA0-0x0000000181D7FAB0
		internal bool paranoidReadValueCachingChecksEnabled { get; set; } // 0x0000000181D7F4B0-0x0000000181D7F4C0 0x0000000181D7F9C0-0x0000000181D7F9D0
	
		// Events
		public event Action<InputDevice, InputDeviceChange> onDeviceChange {
			add; // 0x0000000181D7F000-0x0000000181D7F050
			remove; // 0x0000000181D7F6B0-0x0000000181D7F700
		}
		public event Action<InputDevice, InputEventPtr> onDeviceStateChange {
			add; // 0x0000000181D7F0A0-0x0000000181D7F0F0
			remove; // 0x0000000181D7F750-0x0000000181D7F7A0
		}
		public event InputDeviceCommandDelegate onDeviceCommand {
			add; // 0x0000000181D7F050-0x0000000181D7F0A0
			remove; // 0x0000000181D7F700-0x0000000181D7F750
		}
		public event InputDeviceFindControlLayoutDelegate onFindControlLayoutForDevice {
			add; // 0x0000000181D7F140-0x0000000181D7F1A0
			remove; // 0x0000000181D7F7F0-0x0000000181D7F840
		}
		public event Action<string, InputControlLayoutChange> onLayoutChange {
			add; // 0x0000000181D7F1A0-0x0000000181D7F1F0
			remove; // 0x0000000181D7F840-0x0000000181D7F890
		}
		public event Action<InputEventPtr, InputDevice> onEvent {
			add; // 0x0000000181D7F0F0-0x0000000181D7F140
			remove; // 0x0000000181D7F7A0-0x0000000181D7F7F0
		}
		public event Action onBeforeUpdate {
			add; // 0x0000000181D7EFA0-0x0000000181D7F000
			remove; // 0x0000000181D7F660-0x0000000181D7F6B0
		}
		public event Action onAfterUpdate {
			add; // 0x0000000181D7EF50-0x0000000181D7EFA0
			remove; // 0x0000000181D7F610-0x0000000181D7F660
		}
		public event Action onSettingsChange {
			add; // 0x0000000181D7F1F0-0x0000000181D7F240
			remove; // 0x0000000181D7F890-0x0000000181D7F8E0
		}
		public event Action onActionsChange {
			add; // 0x0000000181D7EF00-0x0000000181D7EF50
			remove; // 0x0000000181D7F5C0-0x0000000181D7F610
		}
	
		// Nested types
		internal enum DeviceDisableScope // TypeDefIndex: 6215
		{
			Everywhere = 0,
			InFrontendOnly = 1,
			TemporaryWhilePlayerIsInBackground = 2
		}
	
		[Serializable]
		internal struct AvailableDevice // TypeDefIndex: 6216
		{
			// Fields
			public InputDeviceDescription description; // 0x00
			public int deviceId; // 0x38
			public bool isNative; // 0x3C
			public bool isRemoved; // 0x3D
		}
	
		private struct StateChangeMonitorTimeout // TypeDefIndex: 6217
		{
			// Fields
			public InputControl control; // 0x00
			public double time; // 0x08
			public IInputStateChangeMonitor monitor; // 0x10
			public long monitorIndex; // 0x18
			public int timerIndex; // 0x20
		}
	
		internal struct StateChangeMonitorListener // TypeDefIndex: 6218
		{
			// Fields
			public InputControl control; // 0x00
			public IInputStateChangeMonitor monitor; // 0x08
			public long monitorIndex; // 0x10
			public uint groupIndex; // 0x18
		}
	
		internal struct StateChangeMonitorsForDevice // TypeDefIndex: 6219
		{
			// Fields
			public MemoryHelpers.BitRegion[] memoryRegions; // 0x00
			public StateChangeMonitorListener[] listeners; // 0x08
			public DynamicBitfield signalled; // 0x10
			public bool needToUpdateOrderingOfMonitors; // 0x30
			public bool needToCompactArrays; // 0x31
	
			// Properties
			public int count { get; } // 0x0000000180377930-0x0000000180377940 
	
			// Methods
			public void Add(InputControl control, IInputStateChangeMonitor monitor, long monitorIndex, uint groupIndex); // 0x0000000181D9FA40-0x0000000181D9FC10
			public void Remove(IInputStateChangeMonitor monitor, long monitorIndex, bool deferRemoval); // 0x0000000181D9FDA0-0x0000000181D9FE80
			public void Clear(); // 0x0000000181D9FC10-0x0000000181D9FC80
			public void CompactArrays(); // 0x0000000181D9FC80-0x0000000181D9FD00
			private void RemoveAt(int i); // 0x0000000181D9FD00-0x0000000181D9FDA0
			public void SortMonitorsByIndex(); // 0x0000000181D9FE80-0x0000000181D9FFC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 6220
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<InputDevice, string> __9__191_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181DA2750-0x0000000181DA27C0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal string _MakeDeviceNameUnique_b__191_0(InputDevice x); // 0x0000000181DA2700-0x0000000181DA2730
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c__85<TDevice> // TypeDefIndex: 6221
			where TDevice : InputDevice, new()
		{
			// Fields
			public static readonly __c__85<TDevice> __9;
			public static Func<InputDevice> __9__85_0;
	
			// Constructors
			static __c__85();
			public __c__85();
	
			// Methods
			internal InputDevice _RegisterPrecompiledLayout_b__85_0();
		}
	
		[CompilerGenerated]
		private sealed class _ListControlLayouts_d__100 : IEnumerable<string>, IEnumerator<string> // TypeDefIndex: 6222
		{
			// Fields
			private int __1__state; // 0x10
			private string __2__current; // 0x18
			private int __l__initialThreadId; // 0x20
			private string basedOn; // 0x28
			public string __3__basedOn; // 0x30
			public InputManager __4__this; // 0x38
			private InternedString _internedBasedOn_5__2; // 0x40
			private Dictionary<InternedString, Type> __7__wrap2; // 0x50
			private Dictionary<InternedString, string> __7__wrap3; // 0x80
			private Dictionary<InternedString, Func<InputControlLayout>> __7__wrap4; // 0xB0
	
			// Properties
			string IEnumerator<System.String>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _ListControlLayouts_d__100(int __1__state); // 0x0000000180A5D530-0x0000000180A5D560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000181DA2390-0x0000000181DA26A0
			private bool MoveNext(); // 0x0000000181DA1920-0x0000000181DA22A0
			private void __m__Finally1(); // 0x0000000181DA26A0-0x0000000181DA26C0
			private void __m__Finally2(); // 0x0000000181DA26C0-0x0000000181DA26E0
			private void __m__Finally3(); // 0x0000000181DA26E0-0x0000000181DA2700
			private void __m__Finally4(); // 0x0000000181DA26A0-0x0000000181DA26C0
			private void __m__Finally5(); // 0x0000000181DA26C0-0x0000000181DA26E0
			private void __m__Finally6(); // 0x0000000181DA26E0-0x0000000181DA2700
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000181DA2350-0x0000000181DA2390
			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator(); // 0x0000000181DA22A0-0x0000000181DA2350
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181DA22A0-0x0000000181DA2350
		}
	
		// Constructors
		public InputManager(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static InputManager(); // 0x0000000181D7EBE0-0x0000000181D7EF00
	
		// Methods
		public void RegisterControlLayout(string name, Type type); // 0x0000000181D7A5E0-0x0000000181D7AC40
		public void RegisterControlLayout(string json, string name = null, bool isOverride = false /* Metadata: 0x00698CFF */); // 0x0000000181D7AC40-0x0000000181D7B1B0
		public void RegisterControlLayoutBuilder(Func<InputControlLayout> method, string name, string baseLayout = null); // 0x0000000181D7A020-0x0000000181D7A220
		private void PerformLayoutPostRegistration(InternedString layoutName, InlinedArray<InternedString> baseLayouts, bool isReplacement, bool isKnownToBeDeviceLayout = false /* Metadata: 0x00698D00 */, bool isOverride = false /* Metadata: 0x00698D01 */); // 0x0000000181D78B20-0x0000000181D79050
		public void RegisterPrecompiledLayout<TDevice>(string metadata)
			where TDevice : InputDevice, new();
		private void RecreateDevicesUsingLayout(InternedString layout, bool isKnownToBeDeviceLayout = false /* Metadata: 0x00698D02 */); // 0x0000000181D79E20-0x0000000181D7A020
		private bool IsControlOrChildUsingLayoutRecursive(InputControl control, InternedString layout); // 0x0000000181D76520-0x0000000181D76630
		private bool IsControlUsingLayout(InputControl control, InternedString layout); // 0x0000000181D76630-0x0000000181D76730
		public void RegisterControlLayoutMatcher(string layoutName, InputDeviceMatcher matcher); // 0x0000000181D7A450-0x0000000181D7A5E0
		public void RegisterControlLayoutMatcher(Type type, InputDeviceMatcher matcher); // 0x0000000181D7A220-0x0000000181D7A450
		private void RecreateDevicesUsingLayoutWithInferiorMatch(InputDeviceMatcher deviceMatcher); // 0x0000000181D79B20-0x0000000181D79E20
		private void RecreateDevice(InputDevice oldDevice, InternedString newLayout); // 0x0000000181D79980-0x0000000181D79B20
		private void AddAvailableDevicesMatchingDescription(InputDeviceMatcher matcher, InternedString layout); // 0x0000000181D70C80-0x0000000181D710A0
		public void RemoveControlLayout(string name); // 0x0000000181D7B840-0x0000000181D7BBA0
		public InputControlLayout TryLoadControlLayout(Type type); // 0x0000000181D7D910-0x0000000181D7DB60
		public InputControlLayout TryLoadControlLayout(InternedString name); // 0x0000000181D7D8E0-0x0000000181D7D910
		public InternedString TryFindMatchingControlLayout(ref InputDeviceDescription deviceDescription, int deviceId = 0 /* Metadata: 0x00698D03 */); // 0x0000000181D7D230-0x0000000181D7D680
		private InternedString FindOrRegisterDeviceLayoutForType(Type type); // 0x0000000181D73AA0-0x0000000181D73B60
		private bool IsDeviceLayoutMarkedAsSupportedInSettings(InternedString layoutName); // 0x0000000181D76730-0x0000000181D76870
		[IteratorStateMachine(typeof(_ListControlLayouts_d__100))]
		public IEnumerable<string> ListControlLayouts(string basedOn = null); // 0x0000000181D76870-0x0000000181D76900
		public int GetControls<TControl>(string path, ref InputControlList<TControl> controls)
			where TControl : InputControl;
		public void SetDeviceUsage(InputDevice device, InternedString usage); // 0x0000000181D7CE40-0x0000000181D7CFE0
		public void AddDeviceUsage(InputDevice device, InternedString usage); // 0x0000000181D712F0-0x0000000181D71430
		public void RemoveDeviceUsage(InputDevice device, InternedString usage); // 0x0000000181D7BBA0-0x0000000181D7BCE0
		private void NotifyUsageChanged(InputDevice device); // 0x0000000181D76DD0-0x0000000181D76EE0
		internal bool HasDevice(InputDevice device); // 0x0000000181D74450-0x0000000181D744A0
		public InputDevice AddDevice(Type type, string name = null); // 0x0000000181D717D0-0x0000000181D71950
		public InputDevice AddDevice(string layout, string name = null, InternedString variants = default); // 0x0000000181D71950-0x0000000181D71AC0
		private InputDevice AddDevice(InternedString layout, int deviceId, string deviceName = null, InputDeviceDescription deviceDescription = default, InputDevice.DeviceFlags deviceFlags =  /* Metadata: 0x00698D04 */, InternedString variants = default); // 0x0000000181D72310-0x0000000181D724F0
		public void AddDevice(InputDevice device); // 0x0000000181D71AC0-0x0000000181D72310
		public InputDevice AddDevice(InputDeviceDescription description); // 0x0000000181D724F0-0x0000000181D72550
		public InputDevice AddDevice(InputDeviceDescription description, bool throwIfNoLayoutFound, string deviceName = null, int deviceId = 0 /* Metadata: 0x00698D05 */, InputDevice.DeviceFlags deviceFlags =  /* Metadata: 0x00698D06 */); // 0x0000000181D71550-0x0000000181D717D0
		public InputDevice AddDevice(InputDeviceDescription description, InternedString layout, string deviceName = null, int deviceId = 0 /* Metadata: 0x00698D07 */, InputDevice.DeviceFlags deviceFlags =  /* Metadata: 0x00698D08 */); // 0x0000000181D71430-0x0000000181D71550
		public void RemoveDevice(InputDevice device, bool keepOnListOfAvailableDevices = false /* Metadata: 0x00698D09 */); // 0x0000000181D7BCE0-0x0000000181D7C320
		public void FlushDisconnectedDevices(); // 0x0000000181D741A0-0x0000000181D741D0
		public void ResetDevice(InputDevice device, bool alsoResetDontResetControls = false /* Metadata: 0x00698D0A */, bool? issueResetCommand = default); // 0x0000000181D7C960-0x0000000181D7CE40
		public InputDevice TryGetDevice(string nameOrLayout); // 0x0000000181D7D700-0x0000000181D7D870
		public InputDevice GetDevice(string nameOrLayout); // 0x0000000181D741D0-0x0000000181D74270
		public InputDevice TryGetDevice(Type layoutType); // 0x0000000181D7D870-0x0000000181D7D8E0
		public InputDevice TryGetDeviceById(int id); // 0x0000000181D7D680-0x0000000181D7D700
		public int GetUnsupportedDevices(List<InputDeviceDescription> descriptions); // 0x0000000181D74270-0x0000000181D74450
		public void EnableOrDisableDevice(InputDevice device, bool enable, DeviceDisableScope scope = DeviceDisableScope.Everywhere /* Metadata: 0x00698D0B */); // 0x0000000181D73690-0x0000000181D73AA0
		private unsafe void QueueEvent(InputEvent* eventPtr); // 0x0000000181D79580-0x0000000181D79670
		public void QueueEvent(InputEventPtr ptr); // 0x0000000181D79670-0x0000000181D79760
		public void QueueEvent<TEvent>(ref ref TEvent inputEvent)
			where TEvent : struct, IInputEventTypeInfo;
		public void Update(); // 0x0000000181D7E920-0x0000000181D7EA00
		public void Update(InputUpdateType updateType); // 0x0000000181D7E860-0x0000000181D7E920
		internal void Initialize(IInputRuntime runtime, InputSettings settings); // 0x0000000181D75900-0x0000000181D75D10
		internal void Destroy(); // 0x0000000181D73570-0x0000000181D73680
		private void InitializeActions(); // 0x0000000181D744A0-0x0000000181D74550
		internal void InitializeData(); // 0x0000000181D74550-0x0000000181D75450
		private static void RegisterCustomTypes(Type[] types); // 0x0000000181D7B5B0-0x0000000181D7B840
		internal bool RegisterCustomTypes(); // 0x0000000181D7B1B0-0x0000000181D7B5B0
		internal void InstallRuntime(IInputRuntime runtime); // 0x0000000181D76070-0x0000000181D76490
		internal void InstallGlobals(); // 0x0000000181D75DD0-0x0000000181D76070
		internal void UninstallGlobals(); // 0x0000000181D7DEB0-0x0000000181D7E0E0
		private void MakeDeviceNameUnique(InputDevice device); // 0x0000000181D76900-0x0000000181D76AC0
		private static void ResetControlPathsRecursive(InputControl control); // 0x0000000181D7C7C0-0x0000000181D7C8B0
		private void AssignUniqueDeviceId(InputDevice device); // 0x0000000181D73230-0x0000000181D733F0
		private void ReallocateStateBuffers(); // 0x0000000181D79760-0x0000000181D79980
		private void InitializeDefaultState(InputDevice device); // 0x0000000181D75450-0x0000000181D75640
		private void InitializeDeviceState(InputDevice device); // 0x0000000181D75640-0x0000000181D75900
		private void OnNativeDeviceDiscovered(int deviceId, string deviceDescriptor); // 0x0000000181D77550-0x0000000181D779A0
		private JsonParser.JsonString MakeEscapedJsonString(string theString); // 0x0000000181D76AC0-0x0000000181D76C70
		private InputDevice TryMatchDisconnectedDevice(string deviceDescriptor); // 0x0000000181D7DB60-0x0000000181D7DE40
		private void InstallBeforeUpdateHookIfNecessary(); // 0x0000000181D75D10-0x0000000181D75DD0
		private void RestoreDevicesAfterDomainReloadIfNecessary(); // 0x00000001802E76C0-0x00000001802E76D0
		private void WarnAboutDevicesFailingToRecreateAfterDomainReload(); // 0x00000001802E76C0-0x00000001802E76D0
		private void OnBeforeUpdate(InputUpdateType updateType); // 0x0000000181D76EE0-0x0000000181D770E0
		internal void ApplySettings(); // 0x0000000181D72830-0x0000000181D73000
		internal void ApplyActions(); // 0x0000000181D727B0-0x0000000181D72830
		internal long ExecuteGlobalCommand<TCommand>(ref ref TCommand command)
			where TCommand : struct, IInputDeviceCommandInfo;
		internal void AddAvailableDevicesThatAreNowRecognized(); // 0x0000000181D710A0-0x0000000181D712F0
		private bool ShouldRunDeviceInBackground(InputDevice device); // 0x0000000181D7D060-0x0000000181D7D0A0
		internal void OnFocusChanged(bool focus); // 0x0000000181D770E0-0x0000000181D77550
		internal bool ShouldRunUpdate(InputUpdateType updateType); // 0x0000000181D7D0A0-0x0000000181D7D0C0
		private void OnUpdate(InputUpdateType updateType, ref InputEventBuffer eventBuffer); // 0x0000000181D779A0-0x0000000181D78B20
		private bool ShouldFlushEventBuffer(); // 0x0000000181D7CFE0-0x0000000181D7D060
		private bool ShouldExitEarlyFromEventProcessing(InputUpdateType updateType); // 0x00000001802E7840-0x00000001802E7850
		private bool AreMaximumEventBytesPerUpdateExceeded(uint totalEventBytesProcessed); // 0x0000000181D73000-0x0000000181D73230
		private string MakeStringWithEventsProcessedByDevice(); // 0x0000000181D76C70-0x0000000181D76DD0
		private void ResetCurrentProcessedEventBytesForDevices(); // 0x0000000181D7C8B0-0x0000000181D7C960
		[Conditional("UNITY_EDITOR")]
		private void CheckAllDevicesOptimizedControlsHaveValidState(); // 0x0000000181D733F0-0x0000000181D73570
		private void InvokeAfterUpdateCallback(InputUpdateType updateType); // 0x0000000181D76490-0x0000000181D76520
		internal void DontMakeCurrentlyUpdatingDeviceCurrent(); // 0x0000000181D73680-0x0000000181D73690
		internal unsafe bool UpdateState(InputDevice device, InputEvent* eventPtr, InputUpdateType updateType); // 0x0000000181D7E0E0-0x0000000181D7E250
		internal unsafe bool UpdateState(InputDevice device, InputUpdateType updateType, void* statePtr, uint stateOffsetInDevice, uint stateSize, double internalTime, InputEventPtr eventPtr = default); // 0x0000000181D7E250-0x0000000181D7E860
		private unsafe void WriteStateChange(InputStateBuffers.DoubleBuffers buffers, int deviceIndex, ref InputStateBlock deviceStateBlock, uint stateOffsetInDevice, void* statePtr, uint stateSizeInBytes, bool flippedBuffers); // 0x0000000181D7EA00-0x0000000181D7EBE0
		private bool FlipBuffersForDeviceIfNecessary(InputDevice device, InputUpdateType updateType); // 0x0000000181D740F0-0x0000000181D741A0
		public void AddStateChangeMonitor(InputControl control, IInputStateChangeMonitor monitor, long monitorIndex, uint groupIndex); // 0x0000000181D72640-0x0000000181D727B0
		private void RemoveStateChangeMonitors(InputDevice device); // 0x0000000181D7C670-0x0000000181D7C7C0
		public void RemoveStateChangeMonitor(InputControl control, IInputStateChangeMonitor monitor, long monitorIndex); // 0x0000000181D7C4B0-0x0000000181D7C670
		public void AddStateChangeMonitorTimeout(InputControl control, IInputStateChangeMonitor monitor, double time, long monitorIndex, int timerIndex); // 0x0000000181D72550-0x0000000181D72640
		public void RemoveStateChangeMonitorTimeout(IInputStateChangeMonitor monitor, long monitorIndex, int timerIndex); // 0x0000000181D7C320-0x0000000181D7C4B0
		private void SortStateChangeMonitorsIfNecessary(int deviceIndex); // 0x0000000181D7D1E0-0x0000000181D7D230
		public void SignalStateChangeMonitor(InputControl control, IInputStateChangeMonitor monitor); // 0x0000000181D7D0C0-0x0000000181D7D1E0
		public void FireStateChangeNotifications(); // 0x0000000181D74000-0x0000000181D740F0
		private unsafe bool ProcessStateChangeMonitors(int deviceIndex, void* newStateFromEvent, void* oldStateOfDevice, uint newStateSizeInBytes, uint newStateOffsetInBytes); // 0x0000000181D792F0-0x0000000181D79580
		internal unsafe void FireStateChangeNotifications(int deviceIndex, double internalTime, InputEvent* eventPtr); // 0x0000000181D73B60-0x0000000181D74000
		private void ProcessStateChangeMonitorTimeouts(); // 0x0000000181D79050-0x0000000181D792F0
		[CompilerGenerated]
		private long _TryFindMatchingControlLayout_b__97_0(ref InputDeviceCommand commandRef); // 0x0000000181D7DE40-0x0000000181D7DEB0
	}
}
