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

namespace UnityEngine.Pool
{
	internal static class PoolManager // TypeDefIndex: 8172
	{
		// Fields
		[NoAutoStaticsCleanup]
		private static readonly List<WeakReference<IPool>> s_WeakPoolReferences; // 0x00
	
		// Constructors
		static PoolManager(); // 0x000000018224E1F0-0x000000018224E280
	
		// Methods
		public static void Register(IPool pool); // 0x000000018224E0E0-0x000000018224E1F0
	}
}
