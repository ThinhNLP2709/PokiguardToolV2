/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.ResourceManagement.Util;

// Image 25: Unity.Addressables.dll - Assembly: Unity.Addressables, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14023-14125

namespace UnityEngine.AddressableAssets.Initialization
{
	internal class InitializationOperation : AsyncOperationBase<IResourceLocator> // TypeDefIndex: 14119
	{
		// Fields
		private AsyncOperationHandle<ResourceManagerRuntimeData> m_rtdOp; // 0x98
		private AsyncOperationHandle<IResourceLocator> m_loadCatalogOp; // 0xB0
		private string m_ProviderSuffix; // 0xC8
		private AddressablesImpl m_Addressables; // 0xD0
		private InitalizationObjectsOperation m_InitGroupOps; // 0xD8
	
		// Properties
		protected override float Progress { get; } // 0x0000000181C87FE0-0x0000000181C88040 
		protected override string DebugName { get; } // 0x0000000181C87FB0-0x0000000181C87FE0 
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 14120
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<IResourceProvider, bool> __9__12_0; // 0x08
			public static Action<AsyncOperationHandle<IList<string>>> __9__16_0; // 0x10
	
			// Constructors
			static __c(); // 0x0000000181C88750-0x0000000181C887C0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _Execute_b__12_0(IResourceProvider rp); // 0x0000000181C88170-0x0000000181C881C0
			internal void _LoadTypeTreeData_b__16_0(AsyncOperationHandle<IList<string>> op); // 0x0000000181C881C0-0x0000000181C88430
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass14_0 // TypeDefIndex: 14121
		{
			// Fields
			public AddressablesImpl addressables; // 0x10
			public IResourceLocator locMap; // 0x18
	
			// Constructors
			public __c__DisplayClass14_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal AsyncOperationHandle<IResourceLocator> _OnCatalogDataLoaded_b__0(AsyncOperationHandle res); // 0x0000000181C88430-0x0000000181C884C0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass16_0 // TypeDefIndex: 14122
		{
			// Fields
			public AddressablesImpl addressables; // 0x10
	
			// Constructors
			public __c__DisplayClass16_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal AsyncOperationHandle<bool> _LoadTypeTreeData_b__1(AsyncOperationHandle res); // 0x0000000181C884C0-0x0000000181C88540
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass17_0 // TypeDefIndex: 14123
		{
			// Fields
			public AddressablesImpl addressables; // 0x10
			public string providerSuffix; // 0x18
			public IResourceLocation remoteHashLocation; // 0x20
	
			// Constructors
			public __c__DisplayClass17_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal AsyncOperationHandle<IResourceLocator> _LoadContentCatalog_b__0(AsyncOperationHandle res); // 0x0000000181C88540-0x0000000181C885A0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass18_0 // TypeDefIndex: 14124
		{
			// Fields
			public InitializationOperation __4__this; // 0x10
			public IList<IResourceLocation> catalogs; // 0x18
			public ResourceLocationMap locMap; // 0x20
			public int index; // 0x28
			public IResourceLocation remoteHashLocation; // 0x30
	
			// Constructors
			public __c__DisplayClass18_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _LoadContentCatalogInternal_b__0(AsyncOperationHandle<IResourceLocator> op); // 0x0000000181C885A0-0x0000000181C88600
		}
	
		// Constructors
		public InitializationOperation(AddressablesImpl aa); // 0x0000000181C87F50-0x0000000181C87FB0
	
		// Methods
		internal static AsyncOperationHandle<IResourceLocator> CreateInitializationOperation(AddressablesImpl aa, string playerSettingsLocation, string providerSuffix); // 0x0000000181C85850-0x0000000181C85D60
		protected override bool InvokeWaitForCompletion(); // 0x0000000181C86720-0x0000000181C86890
		protected override void Execute(); // 0x0000000181C85D60-0x0000000181C86720
		private static void LoadProvider(AddressablesImpl addressables, ObjectInitializationData providerData, string providerSuffix); // 0x0000000181C872D0-0x0000000181C875C0
		private static AsyncOperationHandle<IResourceLocator> OnCatalogDataLoaded(AddressablesImpl addressables, AsyncOperationHandle genOp, string providerSuffix, IResourceLocation remoteHashLocation); // 0x0000000181C878F0-0x0000000181C87F50
		public AsyncOperationHandle<IResourceLocator> LoadContentCatalog(IResourceLocation loc, string providerSuffix, IResourceLocation remoteHashLocation); // 0x0000000181C86F50-0x0000000181C87110
		private static AsyncOperationHandle<bool> LoadTypeTreeData(AddressablesImpl addressables); // 0x0000000181C875C0-0x0000000181C878F0
		public static AsyncOperationHandle<IResourceLocator> LoadContentCatalog(AddressablesImpl addressables, IResourceLocation loc, string providerSuffix, IResourceLocation remoteHashLocation = null); // 0x0000000181C87110-0x0000000181C872D0
		internal AsyncOperationHandle<IResourceLocator> LoadContentCatalogInternal(IList<IResourceLocation> catalogs, int index, ResourceLocationMap locMap, IResourceLocation remoteHashLocation); // 0x0000000181C86BF0-0x0000000181C86F50
		private void LoadContentCatalogComplete(AsyncOperationHandle<IResourceLocator> op, IList<IResourceLocation> catalogs, ResourceLocationMap locMap, int index, IResourceLocation remoteHashLocation); // 0x0000000181C86890-0x0000000181C86BF0
	}
}
