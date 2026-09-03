/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngineInternal.Input;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.LowLevel
{
	internal class NativeInputRuntime : IInputRuntime // TypeDefIndex: 6489
	{
		// Fields
		public static readonly NativeInputRuntime instance; // 0x00
		private bool m_RunInBackground; // 0x10
		private Action m_ShutdownMethod; // 0x18
		private InputUpdateDelegate m_OnUpdate; // 0x20
		private Action<InputUpdateType> m_OnBeforeUpdate; // 0x28
		private Func<InputUpdateType, bool> m_OnShouldRunUpdate; // 0x30
		private bool m_DidCallOnShutdown; // 0x38
		private Action<bool> m_FocusChangedMethod; // 0x40
	
		// Properties
		public InputUpdateDelegate onUpdate { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x0000000181DE67D0-0x0000000181DE6910
		public Action<InputUpdateType> onBeforeUpdate { get; set; } // 0x000000018033D240-0x000000018033D250 0x0000000181DE6300-0x0000000181DE6440
		public Func<InputUpdateType, bool> onShouldRunUpdate { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000181DE6590-0x0000000181DE66D0
		public Action<int, string> onDeviceDiscovered { get; set; } // 0x0000000181DE60E0-0x0000000181DE6170 0x0000000181DE6440-0x0000000181DE6490
		public Action onShutdown { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x0000000181DE66D0-0x0000000181DE67D0
		public Action<bool> onPlayerFocusChanged { get; set; } // 0x0000000180377940-0x0000000180377950 0x0000000181DE6490-0x0000000181DE6590
		public bool isPlayerFocused { get; } // 0x0000000181DE6060-0x0000000181DE60A0 
		public float pollingFrequency { get; set; } // 0x0000000181DE6170-0x0000000181DE61B0 0x0000000181DE6910-0x0000000181DE6960
		public double currentTime { get; } // 0x0000000181DE6020-0x0000000181DE6060 
		public double currentTimeForFixedUpdate { get; } // 0x0000000181DE5F80-0x0000000181DE5FE0 
		public double currentTimeOffsetToRealtimeSinceStartup { get; } // 0x0000000181DE5FE0-0x0000000181DE6020 
		public float unscaledGameTime { get; } // 0x0000000181DE62A0-0x0000000181DE62B0 
		public bool runInBackground { get; set; } // 0x0000000181DE61B0-0x0000000181DE6210 0x00000001804C2E20-0x00000001804C2E30
		public Vector2 screenSize { get; } // 0x0000000181DE6220-0x0000000181DE6260 
		public ScreenOrientation screenOrientation { get; } // 0x0000000181DE6210-0x0000000181DE6220 
		public bool normalizeScrollWheelDelta { get; set; } // 0x0000000181DE60A0-0x0000000181DE60E0 0x0000000181DE62B0-0x0000000181DE6300
		public float scrollWheelDeltaPerTick { get; } // 0x0000000181DE6260-0x0000000181DE62A0 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass10_0 // TypeDefIndex: 6490
		{
			// Fields
			public Action<InputUpdateType> value; // 0x10
	
			// Constructors
			public __c__DisplayClass10_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _set_onBeforeUpdate_b__0(NativeInputUpdateType updateType); // 0x0000000181DEA130-0x0000000181DEA160
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass13_0 // TypeDefIndex: 6491
		{
			// Fields
			public Func<InputUpdateType, bool> value; // 0x10
	
			// Constructors
			public __c__DisplayClass13_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _set_onShouldRunUpdate_b__0(NativeInputUpdateType updateType); // 0x0000000181DEA130-0x0000000181DEA160
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass7_0 // TypeDefIndex: 6492
		{
			// Fields
			public InputUpdateDelegate value; // 0x10
	
			// Constructors
			public __c__DisplayClass7_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal unsafe void _set_onUpdate_b__0(NativeInputUpdateType updateType, NativeInputEventBuffer* eventBufferPtr); // 0x0000000181DEA160-0x0000000181DEA320
		}
	
		// Constructors
		public NativeInputRuntime(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static NativeInputRuntime(); // 0x0000000181DE5F10-0x0000000181DE5F80
	
		// Methods
		public int AllocateDeviceId(); // 0x0000000181DE5CD0-0x0000000181DE5D10
		public void Update(InputUpdateType updateType); // 0x0000000181DE5EC0-0x0000000181DE5F10
		public unsafe void QueueEvent(InputEvent* ptr); // 0x0000000181DE5E60-0x0000000181DE5EC0
		public unsafe long DeviceCommand(int deviceId, InputDeviceCommand* commandPtr); // 0x0000000181DE5D10-0x0000000181DE5DF0
		private void OnShutdown(); // 0x00000001804EAA50-0x00000001804EAA80
		private bool OnWantsToShutdown(); // 0x0000000181DE5E20-0x0000000181DE5E60
		private void OnFocusChanged(bool focus); // 0x0000000181DE5DF0-0x0000000181DE5E20
	}
}
