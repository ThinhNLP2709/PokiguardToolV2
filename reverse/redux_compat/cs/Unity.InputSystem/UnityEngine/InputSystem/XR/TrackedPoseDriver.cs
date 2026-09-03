/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.XR
{
	[Serializable]
	[AddComponentMenu("XR/Tracked Pose Driver (Input System)")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.inputsystem@1.19/manual/TrackedInputDevices.html#tracked-pose-driver")]
	public class TrackedPoseDriver : MonoBehaviour, ISerializationCallbackReceiver // TypeDefIndex: 6251
	{
		// Fields
		[SerializeField]
		[Tooltip("Which Transform properties to update.")]
		private TrackingType m_TrackingType; // 0x20
		[SerializeField]
		[Tooltip("Updates the Transform properties after these phases of Input System event processing.")]
		private UpdateType m_UpdateType; // 0x24
		[SerializeField]
		[Tooltip("Ignore Tracking State and always treat the input pose as valid.")]
		private bool m_IgnoreTrackingState; // 0x28
		[SerializeField]
		[Tooltip("The input action to read the position value of a tracked device. Must be a Vector 3 control type.")]
		private InputActionProperty m_PositionInput; // 0x30
		[SerializeField]
		[Tooltip("The input action to read the rotation value of a tracked device. Must be a Quaternion control type.")]
		private InputActionProperty m_RotationInput; // 0x48
		[SerializeField]
		[Tooltip("The input action to read the tracking state value of a tracked device. Identifies if position and rotation have valid data. Must be an Integer control type.")]
		private InputActionProperty m_TrackingStateInput; // 0x60
		private Vector3 m_CurrentPosition; // 0x78
		private Quaternion m_CurrentRotation; // 0x84
		private TrackingStates m_CurrentTrackingState; // 0x94
		private bool m_RotationBound; // 0x98
		private bool m_PositionBound; // 0x99
		private bool m_TrackingStateBound; // 0x9A
		private bool m_IsFirstUpdate; // 0x9B
		[HideInInspector]
		[Obsolete]
		[SerializeField]
		private InputAction m_PositionAction; // 0xA0
		[HideInInspector]
		[Obsolete]
		[SerializeField]
		private InputAction m_RotationAction; // 0xA8
	
		// Properties
		public TrackingType trackingType { get; set; } // 0x0000000180C4F680-0x0000000180C4F690 0x0000000180E332D0-0x0000000180E332E0
		public UpdateType updateType { get; set; } // 0x0000000180D17D10-0x0000000180D17D20 0x0000000180E02560-0x0000000180E02570
		public bool ignoreTrackingState { get; set; } // 0x0000000180327270-0x0000000180327280 0x00000001804AE490-0x00000001804AE4A0
		public InputActionProperty positionInput { get; set; } // 0x0000000181C2D300-0x0000000181C2D320 0x0000000181DA1670-0x0000000181DA1710
		public InputActionProperty rotationInput { get; set; } // 0x0000000181DA1560-0x0000000181DA1580 0x0000000181DA17E0-0x0000000181DA1880
		public InputActionProperty trackingStateInput { get; set; } // 0x0000000181DA1580-0x0000000181DA15A0 0x0000000181DA1880-0x0000000181DA1920
		public InputAction positionAction { get; set; } // 0x0000000181DA1540-0x0000000181DA1550 0x0000000181DA15A0-0x0000000181DA1670
		public InputAction rotationAction { get; set; } // 0x0000000181DA1550-0x0000000181DA1560 0x0000000181DA1710-0x0000000181DA17E0
	
		// Nested types
		public enum TrackingType // TypeDefIndex: 6252
		{
			RotationAndPosition = 0,
			RotationOnly = 1,
			PositionOnly = 2
		}
	
		[Flags]
		private enum TrackingStates // TypeDefIndex: 6253
		{
			None = 0,
			Position = 1,
			Rotation = 2
		}
	
		public enum UpdateType // TypeDefIndex: 6254
		{
			UpdateAndBeforeRender = 0,
			Update = 1,
			BeforeRender = 2
		}
	
		// Constructors
		public TrackedPoseDriver(); // 0x0000000181DA14F0-0x0000000181DA1540
	
		// Methods
		private void BindActions(); // 0x0000000181D9FFC0-0x0000000181D9FFF0
		private void UnbindActions(); // 0x0000000181DA0E30-0x0000000181DA0E60
		private void BindPosition(); // 0x0000000181D9FFF0-0x0000000181DA0170
		private void BindRotation(); // 0x0000000181DA0170-0x0000000181DA02F0
		private void BindTrackingState(); // 0x0000000181DA02F0-0x0000000181DA0470
		private static void RenameAndEnable(InputAction action, string name); // 0x0000000181DA0AD0-0x0000000181DA0B00
		private void UnbindPosition(); // 0x0000000181DA0E60-0x0000000181DA0F90
		private void UnbindRotation(); // 0x0000000181DA0F90-0x0000000181DA10C0
		private void UnbindTrackingState(); // 0x0000000181DA10C0-0x0000000181DA11F0
		private void OnPositionPerformed(InputAction.CallbackContext context); // 0x0000000181DA07C0-0x0000000181DA0820
		private void OnPositionCanceled(InputAction.CallbackContext context); // 0x0000000181DA0790-0x0000000181DA07C0
		private void OnRotationPerformed(InputAction.CallbackContext context); // 0x0000000181DA0840-0x0000000181DA08A0
		private void OnRotationCanceled(InputAction.CallbackContext context); // 0x0000000181DA0820-0x0000000181DA0840
		private void OnTrackingStatePerformed(InputAction.CallbackContext context); // 0x0000000181DA08B0-0x0000000181DA0900
		private void OnTrackingStateCanceled(InputAction.CallbackContext context); // 0x0000000181DA08A0-0x0000000181DA08B0
		protected void Reset(); // 0x0000000181DA0B00-0x0000000181DA0D10
		protected virtual void Awake(); // 0x00000001802E76C0-0x00000001802E76D0
		protected void OnEnable(); // 0x0000000181DA0690-0x0000000181DA0790
		protected void OnDisable(); // 0x0000000181DA0590-0x0000000181DA0690
		protected virtual void OnDestroy(); // 0x00000001802E76C0-0x00000001802E76D0
		protected void UpdateCallback(); // 0x0000000181DA12C0-0x0000000181DA14F0
		private void OnDeviceChanged(InputDevice inputDevice, InputDeviceChange inputDeviceChange); // 0x0000000181DA0570-0x0000000181DA0590
		private void ReadTrackingStateWithoutTrackingAction(); // 0x0000000181DA0980-0x0000000181DA0A20
		private void ReadTrackingState(); // 0x0000000181DA0A20-0x0000000181DA0AD0
		protected virtual void OnUpdate(); // 0x0000000181DA0900-0x0000000181DA0930
		protected virtual void OnBeforeRender(); // 0x0000000181DA0540-0x0000000181DA0570
		protected virtual void PerformUpdate(); // 0x0000000181DA0930-0x0000000181DA0980
		protected virtual void SetLocalTransform(Vector3 newPosition, Quaternion newRotation); // 0x0000000181DA0D10-0x0000000181DA0E30
		private static bool HasResolvedControl(InputAction action); // 0x0000000181DA0470-0x0000000181DA0540
		void ISerializationCallbackReceiver.OnBeforeSerialize(); // 0x00000001802E76C0-0x00000001802E76D0
		void ISerializationCallbackReceiver.OnAfterDeserialize(); // 0x0000000181DA11F0-0x0000000181DA12C0
	}
}
