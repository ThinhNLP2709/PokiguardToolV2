/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 37: UnityEngine.BurstModule.dll - Assembly: UnityEngine.BurstModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14997-15049

namespace Unity.Burst.LowLevel
{
	[NativeHeader("Modules/Burst/Include/Burst/Burst.h")]
	[NativeHeader("Modules/Burst/Include/Burst/BurstDelegateCache.h")]
	[StaticAccessor("BurstCompilerService::Get()", StaticAccessorType.Arrow)]
	[VisibleToOtherModules]
	internal static class BurstCompilerService // TypeDefIndex: 15041
	{
		// Nested types
		public delegate bool ExtractCompilerFlags(Type jobType, out string flags); // TypeDefIndex: 15042; 0x0000000180A70FB0-0x0000000180A70FC0
	
		public enum BurstLogType // TypeDefIndex: 15043
		{
			Info = 0,
			Warning = 1,
			Error = 2
		}
	
		[CompilerGenerated]
		private static class __O // TypeDefIndex: 15044
		{
			// Fields
			public static Action _0___ClearCacheBetweenCodeLoads; // 0x00
		}
	
		// Methods
		[NativeMethod("ReloadAssemblySearchPathsForBurst", ThrowsException = true)]
		public static void ReloadAssemblySearchPathsForBurstInternal(); // 0x000000018216EAA0-0x000000018216EAD0
		private static void ClearCacheBetweenCodeLoads(); // 0x000000018216EAA0-0x000000018216EAD0
		[FreeFunction(IsThreadSafe = true)]
		public static int CompileAsyncDelegateMethod(object delegateMethod, string compilerOptions); // 0x000000018216EB20-0x000000018216EC80
		[FreeFunction(IsThreadSafe = true)]
		public static unsafe void* GetAsyncCompiledAsyncDelegateMethod(int userID); // 0x000000018216EC80-0x000000018216ECC0
		[NativeMethod(IsThreadSafe = true)]
		public static unsafe void* GetOrCreateSharedMemory(long keyLow, long keyHigh, uint size_of, uint alignment); // 0x000000018216ECC0-0x000000018216ED30
		[FreeFunction("DefaultBurstLogCallback", true)]
		public static unsafe void Log(void* userData, BurstLogType logType, byte* message, byte* filename, int lineNumber); // 0x000000018216F210-0x000000018216F270
		[FreeFunction("DefaultBurstRuntimeLogCallback", true)]
		public static unsafe void RuntimeLog(void* userData, BurstLogType logType, byte* message, byte* filename, int lineNumber); // 0x000000018216F270-0x000000018216F2D0
		[RequiredByNativeCode]
		private static MethodInfo GetMethodInfoForDelegate(Delegate targetMethod); // 0x000000018171CD10-0x000000018171CD30
		[RequiredByNativeCode]
		private static void InvokeReset([UnityMarshalAs(NativeType.GCHandle)] object instance, MethodInfo methodHandlePtr); // 0x000000018216F0F0-0x000000018216F120
		[RequiredByNativeCode]
		private static void InvokeCompileInternal([UnityMarshalAs(NativeType.GCHandle)] object instance, MethodInfo methodHandlePtr, string fullMethodName, string assemblyPaths, IntPtr userdata, int dumpFlags, IntPtr compilerCallbackPointer, IntPtr logCallBack, string compilerFlags); // 0x000000018216ED30-0x000000018216F030
		[RequiredByNativeCode]
		private static void InvokeSetNativeGetExternalFunctionPointer([UnityMarshalAs(NativeType.GCHandle)] object instance, MethodInfo methodHandlePtr, IntPtr externalFunctionCallback); // 0x000000018216F120-0x000000018216F210
		[RequiredByNativeCode]
		private static string InvokeExtractCompilerFlags(Delegate extractCompilerFlagsDelegate, IntPtr jobTypeHandle, ref bool didGetFlags); // 0x000000018216F030-0x000000018216F0F0
		[CompilerGenerated]
		internal static void Unity_Burst_LowLevel_BurstCompilerService_ClearCacheBetweenCodeLoads_RegisterLifecycleMethod(); // 0x000000018216F2D0-0x000000018216F420
		private static int CompileAsyncDelegateMethod_Injected(object delegateMethod, ref ManagedSpanWrapper compilerOptions); // 0x000000018216EAD0-0x000000018216EB20
	}
}
