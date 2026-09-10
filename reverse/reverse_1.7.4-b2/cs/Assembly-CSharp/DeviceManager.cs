/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class DeviceManager : MonoBehaviour // TypeDefIndex: 1543
{
	// Fields
	private static DeviceManager _instance; // 0x00

	// Properties
	public static DeviceManager Instance { get; } // 0x00000001805F0E10-0x00000001805F0F20 

	// Constructors
	public DeviceManager(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	public static string GetDeviceId(); // 0x00000001805B5470-0x00000001805B5480
	public static string GetDeviceName(); // 0x00000001805F0CE0-0x00000001805F0D50
	public static void SaveDeviceInfo(); // 0x00000001805F0D50-0x00000001805F0E10
}

