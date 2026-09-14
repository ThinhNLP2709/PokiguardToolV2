/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class DeviceManager : MonoBehaviour // TypeDefIndex: 1926
{
	// Fields
	private static DeviceManager _instance; // 0x00

	// Properties
	public static DeviceManager Instance { get; } // 0x00000001809320A0-0x0000000180932290 

	// Constructors
	public DeviceManager(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public static string GetDeviceId(); // 0x0000000180932290-0x00000001809322A0
	public static string GetDeviceName(); // 0x00000001809322A0-0x0000000180932320
	public static void SaveDeviceInfo(); // 0x0000000180932320-0x0000000180932440
}

