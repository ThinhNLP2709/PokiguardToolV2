/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.XR;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.XR
{
	[Serializable]
	public class XRDeviceDescriptor // TypeDefIndex: 6261
	{
		// Fields
		public string deviceName; // 0x10
		public string manufacturer; // 0x18
		public string serialNumber; // 0x20
		public InputDeviceCharacteristics characteristics; // 0x28
		public int deviceId; // 0x2C
		public List<XRFeatureDescriptor> inputFeatures; // 0x30
	
		// Constructors
		public XRDeviceDescriptor(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public string ToJson(); // 0x0000000181DA5FC0-0x0000000181DA5FD0
		public static XRDeviceDescriptor FromJson(string json); // 0x0000000181DA5F80-0x0000000181DA5FC0
	}
}
