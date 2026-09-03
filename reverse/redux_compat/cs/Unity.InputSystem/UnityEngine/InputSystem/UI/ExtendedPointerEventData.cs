/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.UI
{
	public class ExtendedPointerEventData : PointerEventData // TypeDefIndex: 6299
	{
		// Fields
		[CompilerGenerated]
		private InputControl _control_k__BackingField; // 0x1C0
		[CompilerGenerated]
		private InputDevice _device_k__BackingField; // 0x1C8
		[CompilerGenerated]
		private int _touchId_k__BackingField; // 0x1D0
		[CompilerGenerated]
		private UIPointerType _pointerType_k__BackingField; // 0x1D4
		[CompilerGenerated]
		private int _uiToolkitPointerId_k__BackingField; // 0x1D8
		[CompilerGenerated]
		private Vector3 _trackedDevicePosition_k__BackingField; // 0x1DC
		[CompilerGenerated]
		private Quaternion _trackedDeviceOrientation_k__BackingField; // 0x1E8
	
		// Properties
		public InputControl control { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181CB22C0-0x0000000181CB22D0 0x0000000181975200-0x0000000181975220
		public InputDevice device { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181CB2300-0x0000000181CB2310 0x0000000181CB2390-0x0000000181CB23B0
		public int touchId { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181DAAA10-0x0000000181DAAA20 0x0000000181DAAA60-0x0000000181DAAA70
		public UIPointerType pointerType { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181DAAA00-0x0000000181DAAA10 0x0000000181DAAA50-0x0000000181DAAA60
		public int uiToolkitPointerId { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D440-0x000000018033D450 0x000000018033E9D0-0x000000018033E9E0
		public Vector3 trackedDevicePosition { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181DAAA30-0x0000000181DAAA50 0x0000000181DAAA80-0x0000000181DAAAA0
		public Quaternion trackedDeviceOrientation { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181DAAA20-0x0000000181DAAA30 0x0000000181DAAA70-0x0000000181DAAA80
	
		// Constructors
		public ExtendedPointerEventData(EventSystem eventSystem); // 0x0000000181DAA9F0-0x0000000181DAAA00
	
		// Methods
		public override string ToString(); // 0x0000000181DAA3E0-0x0000000181DAA9F0
		internal static int MakePointerIdForTouch(int deviceId, int touchId); // 0x0000000181DAA0B0-0x0000000181DAA0C0
		internal static int TouchIdFromPointerId(int pointerId); // 0x0000000180815D60-0x0000000180815D70
		internal void ReadDeviceState(); // 0x0000000181DAA0C0-0x0000000181DAA3E0
		private static int GetPenPointerId(Pen pen); // 0x0000000181DA9DB0-0x0000000181DA9FC0
		private static int GetTouchPointerId(TouchControl touchControl); // 0x0000000181DA9FC0-0x0000000181DAA0B0
	}
}
