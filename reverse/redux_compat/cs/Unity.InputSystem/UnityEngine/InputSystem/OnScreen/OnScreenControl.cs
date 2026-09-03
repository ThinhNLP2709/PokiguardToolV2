/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.OnScreen
{
	public abstract class OnScreenControl : MonoBehaviour // TypeDefIndex: 6331
	{
		// Fields
		private InputControl m_Control; // 0x20
		private OnScreenControl m_NextControlOnDevice; // 0x28
		private InputEventPtr m_InputEventPtr; // 0x30
		private static int s_nbActiveInstances; // 0x00
		private static InlinedArray<OnScreenDeviceInfo> s_OnScreenDevices; // 0x08
	
		// Properties
		public string controlPath { get; set; } // 0x00000001816197C0-0x00000001816197E0 0x0000000181DB6EB0-0x0000000181DB6EF0
		public InputControl control { get; } // 0x00000001802F8630-0x00000001802F8640 
		protected abstract string controlPathInternal { get; set; }
		internal static bool HasAnyActive { get; } // 0x0000000181DB6E70-0x0000000181DB6EB0 
	
		// Nested types
		private struct OnScreenDeviceInfo // TypeDefIndex: 6332
		{
			// Fields
			public InputEventPtr eventPtr; // 0x00
			public NativeArray<byte> buffer; // 0x08
			public InputDevice device; // 0x18
			public OnScreenControl firstControl; // 0x20
	
			// Methods
			public OnScreenDeviceInfo AddControl(OnScreenControl control); // 0x0000000181DB6EF0-0x0000000181DB6F60
			public OnScreenDeviceInfo RemoveControl(OnScreenControl control); // 0x0000000181DB7000-0x0000000181DB7140
			public void Destroy(); // 0x0000000181DB6F60-0x0000000181DB7000
		}
	
		// Constructors
		protected OnScreenControl(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		private void SetupInputControl(); // 0x0000000181DB6550-0x0000000181DB6E70
		protected void SendValueToControl<TValue>(TValue value)
			where TValue : struct;
		protected void SentDefaultValueToControl(); // 0x0000000181DB6490-0x0000000181DB6550
		protected virtual void OnEnable(); // 0x0000000181DB61E0-0x0000000181DB6490
		protected virtual void OnDisable(); // 0x0000000181DB5F30-0x0000000181DB61E0
		internal string GetWarningMessage(); // 0x0000000181DB5EE0-0x0000000181DB5F30
	}
}
