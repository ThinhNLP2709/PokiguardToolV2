/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeHeader("Runtime/Camera/Camera.h")]
	internal class CameraRaycastHelper // TypeDefIndex: 7835
	{
		// Methods
		[FreeFunction("CameraScripting::RaycastTry")]
		internal static GameObject RaycastTry(Camera cam, Ray ray, float distance, int layerMask); // 0x0000000182201520-0x00000001822015C0
		[FreeFunction("CameraScripting::RaycastTry2D")]
		internal static GameObject RaycastTry2D(Camera cam, Ray ray, float distance, int layerMask); // 0x0000000182201410-0x00000001822014B0
		private static IntPtr RaycastTry_Injected(IntPtr cam, in Ray ray, float distance, int layerMask); // 0x00000001822014B0-0x0000000182201520
		private static IntPtr RaycastTry2D_Injected(IntPtr cam, in Ray ray, float distance, int layerMask); // 0x00000001822013A0-0x0000000182201410
	}
}
