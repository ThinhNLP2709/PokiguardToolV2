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
using UnityEngine.Events;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	internal static class BeforeRenderHelper // TypeDefIndex: 7535
	{
		// Fields
		[AutoStaticsCleanupOnCodeReload]
		private static readonly List<OrderBlock> s_OrderBlocks; // 0x00
	
		// Nested types
		private struct OrderBlock // TypeDefIndex: 7536
		{
			// Fields
			internal int order; // 0x00
			internal UnityAction callback; // 0x08
		}
	
		// Constructors
		static BeforeRenderHelper(); // 0x000000018219CD60-0x000000018219CDF0
	
		// Methods
		private static int GetUpdateOrder(UnityAction callback); // 0x000000018219C2D0-0x000000018219C3E0
		public static void RegisterCallback(UnityAction callback); // 0x000000018219C590-0x000000018219C9D0
		public static void UnregisterCallback(UnityAction callback); // 0x000000018219C9D0-0x000000018219CD60
		public static void Invoke(); // 0x000000018219C3E0-0x000000018219C590
	}
}
