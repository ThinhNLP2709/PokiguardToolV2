/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 60: UnityEngine.InputLegacyModule.dll - Assembly: UnityEngine.InputLegacyModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15737-15751

namespace UnityEngine.Internal
{
	[NativeHeader("Runtime/Input/InputBindings.h")]
	internal static class InputUnsafeUtility // TypeDefIndex: 15751
	{
		// Methods
		[NativeMethod(ThrowsException = true)]
		internal static unsafe bool GetKeyString__Unmanaged(byte* name, int nameLen); // 0x00000001822ACF40-0x00000001822ACF80
		[NativeMethod(ThrowsException = true)]
		internal static unsafe bool GetKeyUpString__Unmanaged(byte* name, int nameLen); // 0x00000001822ACF80-0x00000001822ACFC0
		[NativeMethod(ThrowsException = true)]
		internal static unsafe bool GetKeyDownString__Unmanaged(byte* name, int nameLen); // 0x00000001822ACF00-0x00000001822ACF40
		[NativeMethod(ThrowsException = true)]
		internal static float GetAxis(string axisName); // 0x00000001822ACB50-0x00000001822ACCB0
		[NativeMethod(ThrowsException = true)]
		internal static unsafe float GetAxis__Unmanaged(byte* axisName, int axisNameLen); // 0x00000001822ACB10-0x00000001822ACB50
		[NativeMethod(ThrowsException = true)]
		internal static float GetAxisRaw(string axisName); // 0x00000001822AC970-0x00000001822ACAD0
		[NativeMethod(ThrowsException = true)]
		internal static unsafe float GetAxisRaw__Unmanaged(byte* axisName, int axisNameLen); // 0x00000001822AC930-0x00000001822AC970
		[NativeMethod(ThrowsException = true)]
		internal static unsafe bool GetButton__Unmanaged(byte* buttonName, int buttonNameLen); // 0x00000001822ACEC0-0x00000001822ACF00
		[NativeMethod(ThrowsException = true)]
		internal static bool GetButtonDown(string buttonName); // 0x00000001822ACD30-0x00000001822ACE80
		[NativeMethod(ThrowsException = true)]
		internal static unsafe byte GetButtonDown__Unmanaged(byte* buttonName, int buttonNameLen); // 0x00000001822ACCF0-0x00000001822ACD30
		[NativeMethod(ThrowsException = true)]
		internal static unsafe bool GetButtonUp__Unmanaged(byte* buttonName, int buttonNameLen); // 0x00000001822ACE80-0x00000001822ACEC0
		private static float GetAxis_Injected(ref ManagedSpanWrapper axisName); // 0x00000001822ACAD0-0x00000001822ACB10
		private static float GetAxisRaw_Injected(ref ManagedSpanWrapper axisName); // 0x00000001822AC8F0-0x00000001822AC930
		private static bool GetButtonDown_Injected(ref ManagedSpanWrapper buttonName); // 0x00000001822ACCB0-0x00000001822ACCF0
	}
}
