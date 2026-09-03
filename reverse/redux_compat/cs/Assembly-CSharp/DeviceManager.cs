/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class DeviceManager : MonoBehaviour // TypeDefIndex: 1309
{
	// Fields
	private static DeviceManager _instance; // 0x00

	// Properties
	public static DeviceManager Instance { get; } // 0x00000001804EF500-0x00000001804EF610 

	// Constructors
	public DeviceManager(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	public static string GetDeviceId(); // 0x00000001804B9950-0x00000001804B9960
	public static string GetDeviceName(); // 0x00000001804EF3D0-0x00000001804EF440
	public static void SaveDeviceInfo(); // 0x00000001804EF440-0x00000001804EF500
}

