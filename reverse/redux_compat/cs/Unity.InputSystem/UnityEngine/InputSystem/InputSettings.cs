/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem
{
	public class InputSettings : ScriptableObject // TypeDefIndex: 6223
	{
		// Fields
		[SerializeField]
		[Tooltip("Determine which type of devices are used by the application. By default, this is empty meaning that all devices recognized by Unity will be used. Restricting the set of supported devices will make only those devices appear in the input system.")]
		private string[] m_SupportedDevices; // 0x18
		[SerializeField]
		[Tooltip("Determine when Unity processes events. By default, accumulated input events are flushed out before each fixed update and before each dynamic update. This setting can be used to restrict event processing to only where the application needs it.")]
		private UpdateMode m_UpdateMode; // 0x20
		[SerializeField]
		private ScrollDeltaBehavior m_ScrollDeltaBehavior; // 0x24
		[SerializeField]
		private int m_MaxEventBytesPerUpdate; // 0x28
		[SerializeField]
		private int m_MaxQueuedEventsPerUpdate; // 0x2C
		[SerializeField]
		private bool m_CompensateForScreenOrientation; // 0x30
		[SerializeField]
		private BackgroundBehavior m_BackgroundBehavior; // 0x34
		[SerializeField]
		private EditorInputBehaviorInPlayMode m_EditorInputBehaviorInPlayMode; // 0x38
		[SerializeField]
		private InputActionPropertyDrawerMode m_InputActionPropertyDrawerMode; // 0x3C
		[SerializeField]
		private float m_DefaultDeadzoneMin; // 0x40
		[SerializeField]
		private float m_DefaultDeadzoneMax; // 0x44
		[Min(0.0001f)]
		[SerializeField]
		private float m_DefaultButtonPressPoint; // 0x48
		[SerializeField]
		private float m_ButtonReleaseThreshold; // 0x4C
		[SerializeField]
		private float m_DefaultTapTime; // 0x50
		[SerializeField]
		private float m_DefaultSlowTapTime; // 0x54
		[SerializeField]
		private float m_DefaultHoldTime; // 0x58
		[SerializeField]
		private float m_TapRadius; // 0x5C
		[SerializeField]
		private float m_MultiTapDelayTime; // 0x60
		[SerializeField]
		private bool m_DisableRedundantEventsMerging; // 0x64
		[SerializeField]
		private bool m_ShortcutKeysConsumeInputs; // 0x65
		[NonSerialized]
		internal HashSet<string> m_FeatureFlags; // 0x68
		internal const int s_OldUnsupportedFixedAndDynamicUpdateSetting = 0; // Metadata: 0x00698D0F
	
		// Properties
		public UpdateMode updateMode { get; set; } // 0x0000000180C4F680-0x0000000180C4F690 0x0000000181D8D000-0x0000000181D8D010
		public ScrollDeltaBehavior scrollDeltaBehavior { get; set; } // 0x0000000180D17D10-0x0000000180D17D20 0x0000000181D8CE50-0x0000000181D8CE60
		public bool compensateForScreenOrientation { get; set; } // 0x00000001802E8950-0x00000001802E8960 0x0000000181D8CCF0-0x0000000181D8CD00
		[Obsolete("filterNoiseOnCurrent is deprecated, filtering of noise is always enabled now.", false)]
		public bool filterNoiseOnCurrent { get; set; } // 0x00000001802E7840-0x00000001802E7850 0x00000001802E76C0-0x00000001802E76D0
		public float defaultDeadzoneMin { get; set; } // 0x0000000181D8CC60-0x0000000181D8CC70 0x0000000181D8CD60-0x0000000181D8CD80
		public float defaultDeadzoneMax { get; set; } // 0x0000000180349420-0x0000000180349430 0x0000000181D8CD40-0x0000000181D8CD60
		public float defaultButtonPressPoint { get; set; } // 0x000000018047EDF0-0x000000018047EE00 0x0000000181D8CD00-0x0000000181D8CD40
		public float buttonReleaseThreshold { get; set; } // 0x0000000181D8CC50-0x0000000181D8CC60 0x0000000181D8CCD0-0x0000000181D8CCF0
		public float defaultTapTime { get; set; } // 0x0000000181D8CC80-0x0000000181D8CC90 0x0000000181D8CDC0-0x0000000181D8CDE0
		public float defaultSlowTapTime { get; set; } // 0x0000000181D8CC70-0x0000000181D8CC80 0x0000000181D8CDA0-0x0000000181D8CDC0
		public float defaultHoldTime { get; set; } // 0x000000018042C5E0-0x000000018042C5F0 0x0000000181D8CD80-0x0000000181D8CDA0
		public float tapRadius { get; set; } // 0x0000000181D8CCB0-0x0000000181D8CCC0 0x0000000181D8CFE0-0x0000000181D8D000
		public float multiTapDelayTime { get; set; } // 0x0000000181D8CCA0-0x0000000181D8CCB0 0x0000000181D8CE30-0x0000000181D8CE50
		public BackgroundBehavior backgroundBehavior { get; set; } // 0x000000018033D0F0-0x000000018033D100 0x0000000181D8CCC0-0x0000000181D8CCD0
		public EditorInputBehaviorInPlayMode editorInputBehaviorInPlayMode { get; set; } // 0x000000018047EDE0-0x000000018047EDF0 0x0000000181D8CDF0-0x0000000181D8CE00
		public InputActionPropertyDrawerMode inputActionPropertyDrawerMode { get; set; } // 0x00000001804EFAC0-0x00000001804EFAD0 0x0000000181D8CE00-0x0000000181D8CE10
		public int maxEventBytesPerUpdate { get; set; } // 0x0000000180377930-0x0000000180377940 0x0000000181D8CE10-0x0000000181D8CE20
		public int maxQueuedEventsPerUpdate { get; set; } // 0x00000001803B5DE0-0x00000001803B5DF0 0x0000000181D8CE20-0x0000000181D8CE30
		public ReadOnlyArray<string> supportedDevices { get; set; } // 0x0000000181CB4D50-0x0000000181CB4D80 0x0000000181D8CE70-0x0000000181D8CFE0
		public bool disableRedundantEventsMerging { get; set; } // 0x0000000181D8CC90-0x0000000181D8CCA0 0x0000000181D8CDE0-0x0000000181D8CDF0
		public bool shortcutKeysConsumeInput { get; set; } // 0x000000018188A570-0x000000018188A580 0x0000000181D8CE60-0x0000000181D8CE70
	
		// Nested types
		public enum UpdateMode // TypeDefIndex: 6224
		{
			ProcessEventsInDynamicUpdate = 1,
			ProcessEventsInFixedUpdate = 2,
			ProcessEventsManually = 3
		}
	
		public enum ScrollDeltaBehavior // TypeDefIndex: 6225
		{
			UniformAcrossAllPlatforms = 0,
			KeepPlatformSpecificInputRange = 1
		}
	
		public enum BackgroundBehavior // TypeDefIndex: 6226
		{
			ResetAndDisableNonBackgroundDevices = 0,
			ResetAndDisableAllDevices = 1,
			IgnoreFocus = 2
		}
	
		public enum EditorInputBehaviorInPlayMode // TypeDefIndex: 6227
		{
			PointersAndKeyboardsRespectGameViewFocus = 0,
			AllDevicesRespectGameViewFocus = 1,
			AllDeviceInputAlwaysGoesToGameView = 2
		}
	
		public enum InputActionPropertyDrawerMode // TypeDefIndex: 6228
		{
			Compact = 0,
			MultilineEffective = 1,
			MultilineBoth = 2
		}
	
		// Constructors
		public InputSettings(); // 0x0000000181D8CBF0-0x0000000181D8CC50
	
		// Methods
		public void SetInternalFeatureFlag(string featureName, bool enabled); // 0x0000000181D8CA70-0x0000000181D8CBF0
		internal bool IsFeatureEnabled(string featureName); // 0x0000000181D8C940-0x0000000181D8C9C0
		internal void OnChange(); // 0x0000000181D8C9C0-0x0000000181D8CA70
		private static bool CompareFloats(float a, float b); // 0x0000000181D8C920-0x0000000181D8C940
		private static bool CompareSets<T>(ReadOnlyArray<T> a, ReadOnlyArray<T> b);
		private static bool CompareFeatureFlag(InputSettings a, InputSettings b, string featureName); // 0x0000000181D8C830-0x0000000181D8C920
		internal static bool AreEqual(InputSettings a, InputSettings b); // 0x0000000181D8C1A0-0x0000000181D8C830
	}
}
