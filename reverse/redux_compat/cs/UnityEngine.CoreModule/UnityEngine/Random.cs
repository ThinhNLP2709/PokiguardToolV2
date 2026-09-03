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
	[NativeHeader("Runtime/Export/Random/Random.bindings.h")]
	public static class Random // TypeDefIndex: 7695
	{
		// Properties
		[StaticAccessor("GetScriptingRand()", StaticAccessorType.Dot)]
		public static State state { get; set; } // 0x00000001821F7C40-0x00000001821F7C80 0x00000001821F7CF0-0x00000001821F7D30
		public static float value { [FreeFunction] get; } // 0x00000001821F7C80-0x00000001821F7CB0 
	
		// Nested types
		[Serializable]
		public struct State // TypeDefIndex: 7696
		{
			// Fields
			[SerializeField]
			private int s0; // 0x00
			[SerializeField]
			private int s1; // 0x04
			[SerializeField]
			private int s2; // 0x08
			[SerializeField]
			private int s3; // 0x0C
		}
	
		// Methods
		[NativeMethod("SetSeed")]
		[StaticAccessor("GetScriptingRand()", StaticAccessorType.Dot)]
		public static void InitState(int seed); // 0x00000001821F7B30-0x00000001821F7B70
		[FreeFunction]
		public static float Range(float minInclusive, float maxInclusive); // 0x00000001821F7BB0-0x00000001821F7C00
		public static int Range(int minInclusive, int maxExclusive); // 0x00000001821F7B70-0x00000001821F7BB0
		[FreeFunction]
		private static int RandomRangeInt(int minInclusive, int maxExclusive); // 0x00000001821F7B70-0x00000001821F7BB0
		private static void get_state_Injected(); // 0x00000001821F7C00-0x00000001821F7C40
		private static void set_state_Injected(in State value); // 0x00000001821F7CB0-0x00000001821F7CF0
	}
}
