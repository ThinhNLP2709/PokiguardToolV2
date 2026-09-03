/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	internal static class SerializationCommandObjectTable // TypeDefIndex: 7811
	{
		// Fields
		[NoAutoStaticsCleanup]
		private static object[] s_Objects; // 0x00
		[NoAutoStaticsCleanup]
		private static int s_Count; // 0x08
		[NoAutoStaticsCleanup]
		private static readonly Dictionary<object, int> s_Dedup; // 0x10
		[NoAutoStaticsCleanup]
		private static readonly object s_GrowLock; // 0x18
	
		// Nested types
		[CompilerGenerated]
		private static class __O // TypeDefIndex: 7812
		{
			// Fields
			public static Action _0___Clear; // 0x00
		}
	
		// Constructors
		static SerializationCommandObjectTable(); // 0x000000018221D360-0x000000018221D480
	
		// Methods
		internal static int Intern(object obj); // 0x000000018221CF30-0x000000018221D210
		internal static object Get(int index); // 0x000000018221CEB0-0x000000018221CF30
		internal static void Clear(); // 0x000000018221CD70-0x000000018221CEB0
		[CompilerGenerated]
		internal static void UnityEngine_SerializationCommandObjectTable_Clear_RegisterLifecycleMethod(); // 0x000000018221D210-0x000000018221D360
	}
}
