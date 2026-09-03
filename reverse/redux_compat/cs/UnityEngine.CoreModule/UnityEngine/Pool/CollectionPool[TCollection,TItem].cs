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
	public class CollectionPool<TCollection, TItem> // TypeDefIndex: 8164
		where TCollection : class, ICollection<TItem>, new()
	{
		// Fields
		[AutoStaticsCleanupOnCodeReload]
		internal static readonly ObjectPool<TCollection> s_Pool;
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting;
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 8165
		{
			// Fields
			public static readonly __c<TCollection, TItem> __9;
	
			// Constructors
			static __c();
			public __c();
	
			// Methods
			internal TCollection _.cctor_b__7_0();
			internal void _.cctor_b__7_1(TCollection l);
		}
	
		// Constructors
		static CollectionPool();
	
		// Methods
		public static TCollection Get();
		public static PooledObject<TCollection> Get(out ref TCollection value);
		public static void Release(TCollection toRelease);
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting();
	}
}
