/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.Util
{
	[AutoStaticsCleanup]
	internal static class GlobalLinkedListNodeCache<T> // TypeDefIndex: 13720
	{
		// Fields
		private static LinkedListNodeCache<T> s_GlobalCache;
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_UnityEngine_PlayModeScope_Both;
	
		// Properties
		public static bool CacheExists { get; }
	
		// Constructors
		static GlobalLinkedListNodeCache();
	
		// Methods
		public static void SetCacheSize(int length);
		public static LinkedListNode<T> Acquire(T val);
		public static void Release(LinkedListNode<T> node);
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_UnityEngine_PlayModeScope_Both();
	}
}
