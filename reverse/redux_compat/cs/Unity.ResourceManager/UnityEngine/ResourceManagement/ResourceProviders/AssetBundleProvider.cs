/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.Util;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.ResourceProviders
{
	[DisplayName("AssetBundle Provider")]
	public class AssetBundleProvider : ResourceProviderBase // TypeDefIndex: 13737
	{
		// Fields
		internal static Dictionary<string, AssetBundleUnloadOperation> m_UnloadingBundles; // 0x00
		internal static Dictionary<string, AssetBundleResource> m_LoadingRemoteBundles; // 0x08
	
		// Properties
		protected internal static Dictionary<string, AssetBundleUnloadOperation> UnloadingBundles { get; internal set; } // 0x0000000182042B40-0x0000000182042B90 0x0000000182042C00-0x0000000182042C70
		internal static Dictionary<string, AssetBundleResource> LoadingRemoteBundles { get; set; } // 0x0000000182042A90-0x0000000182042AE0 0x0000000182042B90-0x0000000182042C00
		internal static int UnloadingAssetBundleCount { get; } // 0x0000000182042AE0-0x0000000182042B40 
		internal static int AssetBundleCount { get; } // 0x00000001820429C0-0x0000000182042A90 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass14_0 // TypeDefIndex: 13738
		{
			// Fields
			public ProvideHandle providerInterface; // 0x10
			public AssetBundleProvider __4__this; // 0x28
	
			// Constructors
			public __c__DisplayClass14_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Provide_b__0(AssetBundleResource completedResource); // 0x000000018205AA20-0x000000018205AAB0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass16_0 // TypeDefIndex: 13739
		{
			// Fields
			public IResourceLocation location; // 0x10
	
			// Constructors
			public __c__DisplayClass16_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Release_b__0(AsyncOperation op); // 0x000000018205AAB0-0x000000018205AB60
		}
	
		// Constructors
		public AssetBundleProvider(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static AssetBundleProvider(); // 0x00000001820428D0-0x00000001820429C0
	
		// Methods
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void Init(); // 0x0000000182041BC0-0x0000000182041CC0
		internal static void WaitForAllUnloadingBundlesToComplete(); // 0x0000000182042780-0x00000001820428D0
		public override void Provide(ProvideHandle providerInterface); // 0x0000000182041CC0-0x00000001820422E0
		public override Type GetDefaultType(IResourceLocation location); // 0x0000000182041B80-0x0000000182041BC0
		public override void Release(IResourceLocation location, object asset); // 0x00000001820422E0-0x0000000182042680
		public virtual bool ShouldRetryDownloadError(UnityWebRequestResult uwrResult); // 0x0000000182042760-0x0000000182042780
		internal virtual IOperationCacheKey CreateCacheKeyForLocation(ResourceManager rm, IResourceLocation location, Type desiredType); // 0x0000000182041A80-0x0000000182041B80
		internal void RemoveLoadRemoteBundle(string internalId, AssetBundleResource resource); // 0x0000000182042680-0x0000000182042760
	}
}
