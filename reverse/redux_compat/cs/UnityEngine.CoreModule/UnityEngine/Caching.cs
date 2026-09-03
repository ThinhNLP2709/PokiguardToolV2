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
	[NativeHeader("Runtime/Misc/CachingManager.h")]
	[StaticAccessor("GetCachingManager()", StaticAccessorType.Dot)]
	public sealed class Caching // TypeDefIndex: 7496
	{
		// Properties
		public static bool compressionEnabled { set; } // 0x000000018217C710-0x000000018217C750
		public static bool ready { [NativeName("GetIsReady")] get; } // 0x000000018217C6E0-0x000000018217C710 
		[StaticAccessor("CachingManagerWrapper", StaticAccessorType.DoubleColon)]
		public static Cache defaultCache { [NativeName("Caching_GetDefaultCacheHandle")] get; } // 0x000000018217C6A0-0x000000018217C6E0 
		[StaticAccessor("CachingManagerWrapper", StaticAccessorType.DoubleColon)]
		public static Cache currentCacheForWriting { [NativeName("Caching_GetCurrentCacheHandle")] get; [NativeMethod(ThrowsException = true)] [NativeName("Caching_SetCurrentCacheByHandle")] set; } // 0x000000018217C620-0x000000018217C660 0x000000018217C790-0x000000018217C7D0
	
		// Methods
		public static bool ClearCachedVersion(string assetBundleName, Hash128 hash); // 0x000000018217BDC0-0x000000018217BE50
		[NativeName("ClearCachedVersion")]
		internal static bool ClearCachedVersionInternal(string assetBundleName, Hash128 hash); // 0x000000018217BC60-0x000000018217BDC0
		public static bool ClearOtherCachedVersions(string assetBundleName, Hash128 hash); // 0x000000018217C020-0x000000018217C0B0
		public static bool ClearAllCachedVersions(string assetBundleName); // 0x000000018217BB90-0x000000018217BC10
		internal static bool ClearCachedVersions(string assetBundleName, Hash128 hash, bool keepInputVersion); // 0x000000018217BEB0-0x000000018217C020
		public static bool IsVersionCached(CachedAssetBundle cachedBundle); // 0x000000018217C530-0x000000018217C5E0
		[NativeName("IsCached")]
		internal static bool IsVersionCached(string url, string assetBundleName, Hash128 hash); // 0x000000018217C2E0-0x000000018217C530
		public static Cache AddCache(string cachePath); // 0x000000018217B950-0x000000018217BB90
		[NativeName("AddCachePath")]
		internal static Cache AddCache(string cachePath, bool isReadonly); // 0x000000018217B7D0-0x000000018217B950
		[NativeMethod(ThrowsException = true)]
		[NativeName("Caching_GetCacheHandleByPath")]
		[StaticAccessor("CachingManagerWrapper", StaticAccessorType.DoubleColon)]
		public static Cache GetCacheByPath(string cachePath); // 0x000000018217C100-0x000000018217C280
		private static bool ClearCachedVersionInternal_Injected(ref ManagedSpanWrapper assetBundleName, in Hash128 hash); // 0x000000018217BC10-0x000000018217BC60
		private static bool ClearCachedVersions_Injected(ref ManagedSpanWrapper assetBundleName, in Hash128 hash, bool keepInputVersion); // 0x000000018217BE50-0x000000018217BEB0
		private static bool IsVersionCached_Injected(ref ManagedSpanWrapper url, ref ManagedSpanWrapper assetBundleName, in Hash128 hash); // 0x000000018217C280-0x000000018217C2E0
		private static void AddCache_Injected(ref ManagedSpanWrapper cachePath, bool isReadonly, ); // 0x000000018217B770-0x000000018217B7D0
		private static void GetCacheByPath_Injected(ref ManagedSpanWrapper cachePath, ); // 0x000000018217C0B0-0x000000018217C100
		private static void get_defaultCache_Injected(); // 0x000000018217C660-0x000000018217C6A0
		private static void get_currentCacheForWriting_Injected(); // 0x000000018217C5E0-0x000000018217C620
		private static void set_currentCacheForWriting_Injected(in Cache value); // 0x000000018217C750-0x000000018217C790
	}
}
