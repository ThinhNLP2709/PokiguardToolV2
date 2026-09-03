/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting;

// Image 33: UnityEngine.AndroidJNIModule.dll - Assembly: UnityEngine.AndroidJNIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14765-14805

namespace UnityEngine
{
	[UsedByNativeCode]
	internal sealed class _AndroidJNIHelper // TypeDefIndex: 14777
	{
		// Methods
		public static IntPtr CreateJavaProxy(IntPtr player, IntPtr delegateHandle, AndroidJavaProxy proxy); // 0x0000000182153250-0x00000001821533E0
		public static IntPtr CreateJavaRunnable(AndroidJavaRunnable jrunnable); // 0x0000000182148760-0x0000000182148870
		[RequiredByNativeCode]
		public static IntPtr InvokeJavaProxyMethod(AndroidJavaProxy proxy, IntPtr jmethodName, IntPtr jargs); // 0x00000001821545B0-0x0000000182154630
		public static void CreateJNIArgArray(object[] args, Span<jvalue> ret); // 0x0000000182152AA0-0x0000000182153250
		public static object UnboxArray(AndroidJavaObject obj); // 0x0000000182154630-0x0000000182154DB0
		public static object Unbox(AndroidJavaObject obj); // 0x0000000182154DB0-0x0000000182155840
		public static AndroidJavaObject Box(object obj); // 0x0000000182151030-0x0000000182151E80
		public static void DeleteJNIArgArray(object[] args, Span<jvalue> jniArgs); // 0x00000001821533E0-0x0000000182153520
		public static IntPtr ConvertToJNIArray(Array array); // 0x0000000182151E80-0x0000000182152AA0
		public static ArrayType ConvertFromJNIArray<ArrayType>(IntPtr array);
		public static IntPtr GetConstructorID(IntPtr jclass, object[] args); // 0x00000001821489D0-0x0000000182148B00
		public static IntPtr GetMethodID<ReturnType>(IntPtr jclass, string methodName, object[] args, bool isStatic);
		public static IntPtr GetConstructorID(IntPtr jclass, string signature); // 0x0000000182153520-0x0000000182153680
		public static IntPtr GetMethodID(IntPtr jclass, string methodName, string signature, bool isStatic); // 0x00000001821536B0-0x0000000182153830
		private static IntPtr GetMethodIDFallback(IntPtr jclass, string methodName, string signature, bool isStatic); // 0x0000000182153680-0x00000001821536B0
		public static string GetSignature(object obj); // 0x0000000182153940-0x00000001821545B0
		public static string GetSignature(object[] args); // 0x0000000182153830-0x0000000182153940
		public static string GetSignature<ReturnType>(object[] args);
	}
}
