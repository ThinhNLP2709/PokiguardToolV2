/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.EnhancedTouch
{
	public static class EnhancedTouchSupport // TypeDefIndex: 6358
	{
		// Fields
		private static int s_Enabled; // 0x00
		private static InputSettings.UpdateMode s_UpdateMode; // 0x04
	
		// Properties
		public static bool enabled { get; } // 0x0000000181DC3880-0x0000000181DC38C0 
	
		// Methods
		public static void Enable(); // 0x0000000181DC2FD0-0x0000000181DC3120
		public static void Disable(); // 0x0000000181DC2E50-0x0000000181DC2FD0
		internal static void Reset(); // 0x0000000181DC3410-0x0000000181DC34D0
		private static void SetUpState(); // 0x0000000181DC34D0-0x0000000181DC3670
		internal static void TearDownState(); // 0x0000000181DC3670-0x0000000181DC3880
		private static void OnDeviceChange(InputDevice device, InputDeviceChange change); // 0x0000000181DC3120-0x0000000181DC3390
		private static void OnSettingsChange(); // 0x0000000181DC3390-0x0000000181DC3410
		[Conditional("DEVELOPMENT_BUILD")]
		[Conditional("UNITY_EDITOR")]
		internal static void CheckEnabled(); // 0x0000000181DC2DC0-0x0000000181DC2E50
	}
}
