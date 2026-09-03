/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 33: UnityEngine.AndroidJNIModule.dll - Assembly: UnityEngine.AndroidJNIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14765-14805

namespace UnityEngine
{
	[NativeConditional("PLATFORM_ANDROID")]
	[NativeHeader("Modules/AndroidJNI/Public/AndroidJNIBindingsHelpers.h")]
	[StaticAccessor("AndroidJNIBindingsHelpers", StaticAccessorType.DoubleColon)]
	[UsedByNativeCode]
	public static class AndroidJNIHelper // TypeDefIndex: 14779
	{
		// Methods
		public static IntPtr GetConstructorID(IntPtr javaClass, [DefaultValue("")] string signature); // 0x0000000182148B00-0x0000000182148B10
		public static IntPtr GetMethodID(IntPtr javaClass, string methodName, [DefaultValue("")] string signature, [DefaultValue("false")] bool isStatic); // 0x0000000182148B10-0x0000000182148B20
		public static IntPtr CreateJavaRunnable(AndroidJavaRunnable jrunnable); // 0x0000000182148760-0x0000000182148870
		public static IntPtr CreateJavaProxy(AndroidJavaProxy proxy); // 0x0000000182148520-0x0000000182148760
		public static void CreateJNIArgArray(object[] args, Span<jvalue> jniArgs); // 0x0000000182148420-0x0000000182148520
		public static void DeleteJNIArgArray(object[] args, Span<jvalue> jniArgs); // 0x0000000182148870-0x00000001821489D0
		public static IntPtr GetConstructorID(IntPtr jclass, object[] args); // 0x00000001821489D0-0x0000000182148B00
		public static ArrayType ConvertFromJNIArray<ArrayType>(IntPtr array);
		public static IntPtr GetMethodID<ReturnType>(IntPtr jclass, string methodName, object[] args, bool isStatic);
		private static IntPtr Box(jvalue val, string boxedClass, string signature); // 0x00000001821482E0-0x0000000182148420
		public static IntPtr Box(int value); // 0x0000000182148220-0x0000000182148280
		public static IntPtr Box(bool value); // 0x0000000182148280-0x00000001821482E0
	}
}
