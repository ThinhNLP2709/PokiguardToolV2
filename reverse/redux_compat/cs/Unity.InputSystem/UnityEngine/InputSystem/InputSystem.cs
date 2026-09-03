/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	public static class InputSystem // TypeDefIndex: 6125
	{
		// Fields
		internal const string kAssemblyVersion = "1.19.0"; // Metadata: 0x006989A2
		internal const string kDocUrl = "https://docs.unity3d.com/Packages/com.unity.inputsystem@1.19"; // Metadata: 0x006989A9
		private static readonly ProfilerMarker k_InputResetMarker; // 0x00
		internal static InputManager s_Manager; // 0x08
		internal static InputRemoting s_Remote; // 0x10
	
		// Properties
		public static ReadOnlyArray<InputDevice> devices { get; } // 0x0000000181D15E70-0x0000000181D15EF0 
		public static ReadOnlyArray<InputDevice> disconnectedDevices { get; } // 0x0000000181D15EF0-0x0000000181D15F80 
		public static float pollingFrequency { get; set; } // 0x0000000181D16250-0x0000000181D162B0 0x0000000181D16F30-0x0000000181D16FB0
		internal static bool isProcessingEvents { get; } // 0x0000000181D15F80-0x0000000181D15FE0 
		public static InputEventListener onEvent { get; set; } // 0x00000001802E7840-0x00000001802E7850 0x00000001802E76C0-0x00000001802E76D0
		public static IObservable<InputControl> onAnyButtonPress { get; } // 0x0000000181D16070-0x0000000181D16250 
		public static InputSettings settings { get; set; } // 0x0000000181D16470-0x0000000181D164E0 0x0000000181D170C0-0x0000000181D171E0
		public static InputActionAsset actions { get; set; } // 0x0000000181D15E10-0x0000000181D15E70 0x0000000181D16DF0-0x0000000181D16F30
		public static InputRemoting remoting { get; } // 0x0000000181D162B0-0x0000000181D16300 
		public static Version version { get; } // 0x0000000181D164E0-0x0000000181D16530 
		public static bool runInBackground { get; set; } // 0x0000000181D16300-0x0000000181D16390 0x0000000181D16FB0-0x0000000181D170C0
		internal static float scrollWheelDeltaPerTick { get; } // 0x0000000181D16390-0x0000000181D16470 
		public static InputMetrics metrics { get; } // 0x0000000181D15FE0-0x0000000181D16070 
	
		// Events
		public static event Action<string, InputControlLayoutChange> onLayoutChange {
			add; // 0x0000000181D15C90-0x0000000181D15DA0
			remove; // 0x0000000181D16C70-0x0000000181D16D80
		}
		public static event Action<InputDevice, InputDeviceChange> onDeviceChange {
			add; // 0x0000000181D158A0-0x0000000181D15A10
			remove; // 0x0000000181D16880-0x0000000181D169F0
		}
		public static event InputDeviceCommandDelegate onDeviceCommand {
			add; // 0x0000000181D15A10-0x0000000181D15B80
			remove; // 0x0000000181D169F0-0x0000000181D16B60
		}
		public static event InputDeviceFindControlLayoutDelegate onFindLayoutForDevice {
			add; // 0x0000000181D15B80-0x0000000181D15C90
			remove; // 0x0000000181D16B60-0x0000000181D16C70
		}
		public static event Action onBeforeUpdate {
			add; // 0x0000000181D15790-0x0000000181D158A0
			remove; // 0x0000000181D16770-0x0000000181D16880
		}
		public static event Action onAfterUpdate {
			add; // 0x0000000181D15680-0x0000000181D15790
			remove; // 0x0000000181D16660-0x0000000181D16770
		}
		public static event Action onSettingsChange {
			add; // 0x0000000181D15DA0-0x0000000181D15E10
			remove; // 0x0000000181D16D80-0x0000000181D16DF0
		}
		public static event Action onActionsChange {
			add; // 0x0000000181D15610-0x0000000181D15680
			remove; // 0x0000000181D165F0-0x0000000181D16660
		}
		public static event Action<object, InputActionChange> onActionChange {
			add; // 0x0000000181D15550-0x0000000181D15610
			remove; // 0x0000000181D16530-0x0000000181D165F0
		}
	
		// Nested types
		private struct StateEventBuffer // TypeDefIndex: 6126
		{
			// Fields
			public StateEvent stateEvent; // 0x00
			public const int kMaxSize = 512; // Metadata: 0x006989E6
			public unsafe fixed /* 0x00000000-0x00000000 */ byte data[0]; // 0x19
	
			// Nested types
			[CompilerGenerated]
			[UnsafeValueType]
			public struct _data_e__FixedBuffer // TypeDefIndex: 6127
			{
				// Fields
				public byte FixedElementField; // 0x00
			}
		}
	
		private struct DeltaStateEventBuffer // TypeDefIndex: 6128
		{
			// Fields
			public DeltaStateEvent stateEvent; // 0x00
			public const int kMaxSize = 512; // Metadata: 0x006989E8
			public unsafe fixed /* 0x00000000-0x00000000 */ byte data[0]; // 0x1D
	
			// Nested types
			[CompilerGenerated]
			[UnsafeValueType]
			public struct _data_e__FixedBuffer // TypeDefIndex: 6129
			{
				// Fields
				public byte FixedElementField; // 0x00
			}
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 6130
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<InputEventPtr, InputControl> __9__80_0; // 0x08
			public static Func<InputControl, bool> __9__80_1; // 0x10
	
			// Constructors
			static __c(); // 0x0000000181D1A600-0x0000000181D1A670
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal InputControl _get_onAnyButtonPress_b__80_0(InputEventPtr e); // 0x0000000181D1A500-0x0000000181D1A520
			internal bool _get_onAnyButtonPress_b__80_1(InputControl c); // 0x000000018052BB00-0x000000018052BB10
		}
	
		// Constructors
		static InputSystem(); // 0x0000000181D154E0-0x0000000181D15550
	
		// Methods
		public static void RegisterLayout(Type type, string name = null, InputDeviceMatcher? matches = default); // 0x0000000181D14050-0x0000000181D141C0
		public static void RegisterLayout<T>(string name = null, InputDeviceMatcher? matches = default)
			where T : InputControl;
		public static void RegisterLayout(string json, string name = null, InputDeviceMatcher? matches = default); // 0x0000000181D141C0-0x0000000181D14290
		public static void RegisterLayoutOverride(string json, string name = null); // 0x0000000181D13FC0-0x0000000181D14050
		public static void RegisterLayoutMatcher(string layoutName, InputDeviceMatcher matcher); // 0x0000000181D13F40-0x0000000181D13FC0
		public static void RegisterLayoutMatcher<TDevice>(InputDeviceMatcher matcher)
			where TDevice : InputDevice;
		public static void RegisterLayoutBuilder(Func<InputControlLayout> buildMethod, string name, string baseLayout = null, InputDeviceMatcher? matches = default); // 0x0000000181D13DB0-0x0000000181D13F40
		public static void RegisterPrecompiledLayout<TDevice>(string metadata)
			where TDevice : InputDevice, new();
		public static void RemoveLayout(string name); // 0x0000000181D14830-0x0000000181D148A0
		public static string TryFindMatchingLayout(InputDeviceDescription deviceDescription); // 0x0000000181D14E30-0x0000000181D14EC0
		public static IEnumerable<string> ListLayouts(); // 0x0000000181D132B0-0x0000000181D13320
		public static IEnumerable<string> ListLayoutsBasedOn(string baseLayout); // 0x0000000181D131E0-0x0000000181D132B0
		public static InputControlLayout LoadLayout(string name); // 0x0000000181D133A0-0x0000000181D134A0
		public static InputControlLayout LoadLayout<TControl>()
			where TControl : InputControl;
		public static string GetNameOfBaseLayout(string layoutName); // 0x0000000181D128F0-0x0000000181D12A20
		public static bool IsFirstLayoutBasedOnSecond(string firstLayoutName, string secondLayoutName); // 0x0000000181D12E10-0x0000000181D12FC0
		public static void RegisterProcessor(Type type, string name = null); // 0x0000000181D14290-0x0000000181D14680
		public static void RegisterProcessor<T>(string name = null);
		public static Type TryGetProcessor(string name); // 0x0000000181D15080-0x0000000181D15160
		public static IEnumerable<string> ListProcessors(); // 0x0000000181D13320-0x0000000181D133A0
		public static InputDevice AddDevice(string layout, string name = null, string variants = null); // 0x0000000181D11DE0-0x0000000181D11F10
		public static TDevice AddDevice<TDevice>(string name = null)
			where TDevice : InputDevice;
		public static InputDevice AddDevice(InputDeviceDescription description); // 0x0000000181D11F10-0x0000000181D12020
		public static void AddDevice(InputDevice device); // 0x0000000181D11D20-0x0000000181D11DE0
		public static void RemoveDevice(InputDevice device); // 0x0000000181D147C0-0x0000000181D14830
		public static void FlushDisconnectedDevices(); // 0x0000000181D12560-0x0000000181D125C0
		public static InputDevice GetDevice(string nameOrLayout); // 0x0000000181D12880-0x0000000181D128F0
		public static TDevice GetDevice<TDevice>()
			where TDevice : InputDevice;
		public static InputDevice GetDevice(Type type); // 0x0000000181D12630-0x0000000181D12880
		public static TDevice GetDevice<TDevice>(InternedString usage)
			where TDevice : InputDevice;
		public static TDevice GetDevice<TDevice>(string usage)
			where TDevice : InputDevice;
		public static InputDevice GetDeviceById(int deviceId); // 0x0000000181D125C0-0x0000000181D12630
		public static List<InputDeviceDescription> GetUnsupportedDevices(); // 0x0000000181D12A20-0x0000000181D12B00
		public static int GetUnsupportedDevices(List<InputDeviceDescription> descriptions); // 0x0000000181D12B00-0x0000000181D12B70
		public static void EnableDevice(InputDevice device); // 0x0000000181D122E0-0x0000000181D12360
		public static void DisableDevice(InputDevice device, bool keepSendingEvents = false /* Metadata: 0x0069897F */); // 0x0000000181D12160-0x0000000181D121F0
		public static bool TrySyncDevice(InputDevice device); // 0x0000000181D15200-0x0000000181D15310
		public static void ResetDevice(InputDevice device, bool alsoResetDontResetControls = false /* Metadata: 0x00698980 */); // 0x0000000181D148A0-0x0000000181D14920
		[Obsolete("Use \'ResetDevice\' instead.", false)]
		public static bool TryResetDevice(InputDevice device); // 0x0000000181D15160-0x0000000181D15200
		public static void PauseHaptics(); // 0x0000000181D134A0-0x0000000181D135E0
		public static void ResumeHaptics(); // 0x0000000181D14A60-0x0000000181D14BA0
		public static void ResetHaptics(); // 0x0000000181D14920-0x0000000181D14A60
		public static void SetDeviceUsage(InputDevice device, string usage); // 0x0000000181D14CB0-0x0000000181D14DA0
		public static void SetDeviceUsage(InputDevice device, InternedString usage); // 0x0000000181D14DA0-0x0000000181D14E30
		public static void AddDeviceUsage(InputDevice device, string usage); // 0x0000000181D11C70-0x0000000181D11D20
		public static void AddDeviceUsage(InputDevice device, InternedString usage); // 0x0000000181D11BE0-0x0000000181D11C70
		public static void RemoveDeviceUsage(InputDevice device, string usage); // 0x0000000181D14710-0x0000000181D147C0
		public static void RemoveDeviceUsage(InputDevice device, InternedString usage); // 0x0000000181D14680-0x0000000181D14710
		public static InputControl FindControl(string path); // 0x0000000181D12360-0x0000000181D124E0
		public static InputControlList<InputControl> FindControls(string path); // 0x0000000181D124E0-0x0000000181D12560
		public static InputControlList<TControl> FindControls<TControl>(string path)
			where TControl : InputControl;
		public static int FindControls<TControl>(string path, ref InputControlList<TControl> controls)
			where TControl : InputControl;
		public static void QueueEvent(InputEventPtr eventPtr); // 0x0000000181D137D0-0x0000000181D138C0
		public static void QueueEvent<TEvent>(ref ref TEvent inputEvent)
			where TEvent : struct, IInputEventTypeInfo;
		public static void QueueStateEvent<TState>(InputDevice device, TState state, double time = -1 /* Metadata: 0x00698981 */)
			where TState : struct, IInputStateTypeInfo;
		public static void QueueDeltaStateEvent<TDelta>(InputControl control, TDelta delta, double time = -1 /* Metadata: 0x00698989 */)
			where TDelta : struct;
		public static void QueueConfigChangeEvent(InputDevice device, double time = -1 /* Metadata: 0x00698991 */); // 0x0000000181D13620-0x0000000181D137D0
		public static void QueueTextEvent(InputDevice device, char character, double time = -1 /* Metadata: 0x00698999 */); // 0x0000000181D138C0-0x0000000181D13A90
		public static void Update(); // 0x0000000181D15480-0x0000000181D154E0
		internal static void Update(InputUpdateType updateType); // 0x0000000181D15310-0x0000000181D15480
		private static void EnableActions(); // 0x0000000181D121F0-0x0000000181D122E0
		private static void DisableActions(bool triggerSetupChanged = false /* Metadata: 0x006989A1 */); // 0x0000000181D12020-0x0000000181D12120
		public static void RegisterInteraction(Type type, string name = null); // 0x0000000181D13C20-0x0000000181D13DB0
		public static void RegisterInteraction<T>(string name = null);
		public static Type TryGetInteraction(string name); // 0x0000000181D14FA0-0x0000000181D15080
		public static IEnumerable<string> ListInteractions(); // 0x0000000181D13160-0x0000000181D131E0
		public static void RegisterBindingComposite(Type type, string name); // 0x0000000181D13A90-0x0000000181D13C20
		public static void RegisterBindingComposite<T>(string name = null);
		public static Type TryGetBindingComposite(string name); // 0x0000000181D14EC0-0x0000000181D14FA0
		public static void DisableAllEnabledActions(); // 0x0000000181D12120-0x0000000181D12160
		public static List<InputAction> ListEnabledActions(); // 0x0000000181D13060-0x0000000181D13160
		public static int ListEnabledActions(List<InputAction> actions); // 0x0000000181D12FC0-0x0000000181D13060
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RunInitializeInPlayer(); // 0x0000000181D14C40-0x0000000181D14CB0
		internal static void EnsureInitialized(); // 0x00000001802E76C0-0x00000001802E76D0
		private static void InitializeInPlayer(IInputRuntime runtime = null, InputSettings settings = null); // 0x0000000181D12B70-0x0000000181D12E10
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void RunInitialUpdate(); // 0x0000000181D14BA0-0x0000000181D14C40
		private static void PerformDefaultPluginInitialization(); // 0x0000000181D135E0-0x0000000181D13620
	}
}
