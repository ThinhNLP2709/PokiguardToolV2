/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

// Image 25: Unity.Addressables.dll - Assembly: Unity.Addressables, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14023-14125

namespace UnityEngine.AddressableAssets
{
	internal class UpdateCatalogsOperation : AsyncOperationBase<List<IResourceLocator>> // TypeDefIndex: 14079
	{
		// Fields
		private AddressablesImpl m_Addressables; // 0x98
		private List<ResourceLocatorInfo> m_LocatorInfos; // 0xA0
		internal AsyncOperationHandle<IList<AsyncOperationHandle>> m_DepOp; // 0xA8
		private AsyncOperationHandle<bool> m_CleanCacheOp; // 0xC0
		private bool m_AutoCleanBundleCache; // 0xD8
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 14080
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<IResourceProvider, bool> __9__6_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181C84110-0x0000000181C84180
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _Start_b__6_0(IResourceProvider rp); // 0x0000000181C83180-0x0000000181C831D0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass11_0 // TypeDefIndex: 14081
		{
			// Fields
			public UpdateCatalogsOperation __4__this; // 0x10
			public List<IResourceLocator> catalogs; // 0x18
	
			// Constructors
			public __c__DisplayClass11_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _OnCleanCacheCompleted_b__0(AsyncOperationHandle<bool> obj); // 0x0000000181C83590-0x0000000181C836F0
		}
	
		// Constructors
		public UpdateCatalogsOperation(AddressablesImpl aa); // 0x0000000181C851F0-0x0000000181C85250
	
		// Methods
		public AsyncOperationHandle<List<IResourceLocator>> Start(IEnumerable<string> catalogIds, bool autoCleanBundleCache); // 0x0000000181C84C20-0x0000000181C851F0
		protected override bool InvokeWaitForCompletion(); // 0x0000000181C849D0-0x0000000181C84B30
		protected override void Destroy(); // 0x0000000181C84180-0x0000000181C841C0
		public override void GetDependencies(List<AsyncOperationHandle> dependencies); // 0x0000000181C848C0-0x0000000181C849D0
		protected override void Execute(); // 0x0000000181C841C0-0x0000000181C848C0
		private void OnCleanCacheCompleted(AsyncOperationHandle<bool> handle, List<IResourceLocator> catalogs); // 0x0000000181C84B30-0x0000000181C84C20
	}
}
