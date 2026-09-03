/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.LowLevel;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.EnhancedTouch
{
	[AddComponentMenu("Input/Debug/Touch Simulation")]
	[ExecuteInEditMode]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.inputsystem@1.19/manual/Touch.html#touch-simulation")]
	public class TouchSimulation : MonoBehaviour, IInputStateChangeMonitor // TypeDefIndex: 6367
	{
		// Fields
		[CompilerGenerated]
		private Touchscreen _simulatedTouchscreen_k__BackingField; // 0x20
		[NonSerialized]
		private int m_NumPointers; // 0x28
		[NonSerialized]
		private Pointer[] m_Pointers; // 0x30
		[NonSerialized]
		private Vector2[] m_CurrentPositions; // 0x38
		[NonSerialized]
		private int[] m_CurrentDisplayIndices; // 0x40
		[NonSerialized]
		private ButtonControl[] m_Touches; // 0x48
		[NonSerialized]
		private int[] m_TouchIds; // 0x50
		[NonSerialized]
		private int m_LastTouchId; // 0x58
		[NonSerialized]
		private Action<InputDevice, InputDeviceChange> m_OnDeviceChange; // 0x60
		[NonSerialized]
		private Action<InputEventPtr, InputDevice> m_OnEvent; // 0x68
		internal static TouchSimulation s_Instance; // 0x00
	
		// Properties
		public Touchscreen simulatedTouchscreen { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public static TouchSimulation instance { get; } // 0x0000000181DD2470-0x0000000181DD24B0 
	
		// Constructors
		public TouchSimulation(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		public static void Enable(); // 0x0000000181DD10E0-0x0000000181DD1290
		public static void Disable(); // 0x0000000181DD1010-0x0000000181DD10E0
		public static void Destroy(); // 0x0000000181DD0F40-0x0000000181DD1010
		protected void AddPointer(Pointer pointer); // 0x0000000181DD0E00-0x0000000181DD0F40
		protected void RemovePointer(Pointer pointer); // 0x0000000181DD2010-0x0000000181DD21E0
		private void OnEvent(InputEventPtr eventPtr, InputDevice device); // 0x0000000181DD1A00-0x0000000181DD2010
		private void OnDeviceChange(InputDevice device, InputDeviceChange change); // 0x0000000181DD1290-0x0000000181DD1490
		protected void OnEnable(); // 0x0000000181DD15F0-0x0000000181DD1A00
		protected void OnDisable(); // 0x0000000181DD1490-0x0000000181DD15F0
		private void UpdateTouch(int touchIndex, int pointerIndex, UnityEngine.InputSystem.TouchPhase phase, InputEventPtr eventPtr = default); // 0x0000000181DD21E0-0x0000000181DD2470
		void IInputStateChangeMonitor.NotifyControlStateChanged(InputControl control, double time, InputEventPtr eventPtr, long monitorIndex); // 0x00000001802E76C0-0x00000001802E76D0
		void IInputStateChangeMonitor.NotifyTimerExpired(InputControl control, double time, long monitorIndex, int timerIndex); // 0x00000001802E76C0-0x00000001802E76D0
		protected void InstallStateChangeMonitors(int startIndex = 0 /* Metadata: 0x00698F87 */); // 0x00000001802E76C0-0x00000001802E76D0
		protected void OnSourceControlChangedValue(InputControl control, double time, InputEventPtr eventPtr, long sourceDeviceAndButtonIndex); // 0x00000001802E76C0-0x00000001802E76D0
		protected void UninstallStateChangeMonitors(int startIndex = 0 /* Metadata: 0x00698F88 */); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
