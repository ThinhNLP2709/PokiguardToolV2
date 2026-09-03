/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using AOT;
using UnityEngine;

// Image 37: UnityEngine.BurstModule.dll - Assembly: UnityEngine.BurstModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14997-15049

namespace Unity.Burst
{
	public static class BurstCompiler // TypeDefIndex: 15005
	{
		// Fields
		internal static bool _IsEnabled; // 0x00
		public static readonly BurstCompilerOptions Options; // 0x08
		private static readonly MethodInfo DummyMethodInfo; // 0x10
	
		// Properties
		public static bool IsEnabled { get; } // 0x000000018216FF30-0x000000018216FFC0 
	
		// Nested types
		[BurstCompile]
		internal static class BurstCompilerHelper // TypeDefIndex: 15006
		{
			// Fields
			private static readonly IsBurstEnabledDelegate IsBurstEnabledImpl; // 0x00
			public static readonly bool IsBurstGenerated; // 0x08
	
			// Nested types
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			private delegate bool IsBurstEnabledDelegate(); // TypeDefIndex: 15007; 0x0000000180313920-0x00000001803139C0
	
			// Constructors
			static BurstCompilerHelper(); // 0x000000018216DEA0-0x000000018216E010
	
			// Methods
			[BurstCompile]
			[MonoPInvokeCallback(typeof(IsBurstEnabledDelegate))]
			private static bool IsBurstEnabled(); // 0x000000018216DE10-0x000000018216DE50
			[BurstDiscard]
			private static void DiscardedMethod(ref bool value); // 0x000000018071CA50-0x000000018071CA60
			private static bool IsCompiledByBurst(Delegate del); // 0x000000018216DE50-0x000000018216DEA0
		}
	
		private class FakeDelegate // TypeDefIndex: 15008
		{
			// Fields
			[CompilerGenerated]
			private readonly MethodInfo _Method_k__BackingField; // 0x10
	
			// Properties
			public MethodInfo Method { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
		}
	
		// Constructors
		static BurstCompiler(); // 0x000000018216FCF0-0x000000018216FF30
	
		// Methods
		public static FunctionPointer<T> CompileFunctionPointer<T>(T delegateMethod)
			where T : class;
		private static unsafe void* Compile(object delegateObj); // 0x000000018216FBC0-0x000000018216FCF0
		private static unsafe void* Compile(object delegateObj, MethodInfo methodInfo); // 0x000000018216F420-0x000000018216FBC0
		private static void DummyMethod(); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
