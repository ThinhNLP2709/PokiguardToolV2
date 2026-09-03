/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

// Image 25: Unity.Addressables.dll - Assembly: Unity.Addressables, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14023-14125

namespace UnityEngine.AddressableAssets
{
	internal class CheckCatalogsOperation : AsyncOperationBase<List<string>> // TypeDefIndex: 14076
	{
		// Fields
		private AddressablesImpl m_Addressables; // 0x98
		private List<string> m_LocalHashes; // 0xA0
		private List<ResourceLocatorInfo> m_LocatorInfos; // 0xA8
		private AsyncOperationHandle<IList<AsyncOperationHandle>> m_DepOp; // 0xB0
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 14077
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<IResourceProvider, bool> __9__5_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181C840A0-0x0000000181C84110
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _Start_b__5_0(IResourceProvider rp); // 0x0000000181C83130-0x0000000181C83180
		}
	
		// Constructors
		public CheckCatalogsOperation(AddressablesImpl aa); // 0x0000000181C76760-0x0000000181C767C0
	
		// Methods
		public AsyncOperationHandle<List<string>> Start(List<ResourceLocatorInfo> locatorInfos); // 0x0000000181C761D0-0x0000000181C76760
		protected override bool InvokeWaitForCompletion(); // 0x0000000181C75C30-0x0000000181C75D20
		protected override void Destroy(); // 0x0000000181C75A30-0x0000000181C75A70
		public override void GetDependencies(List<AsyncOperationHandle> dependencies); // 0x0000000181C75B20-0x0000000181C75C30
		internal static List<string> ProcessDependentOpResults(IList<AsyncOperationHandle> results, List<ResourceLocatorInfo> locatorInfos, List<string> localHashes, out string errorString, out bool success); // 0x0000000181C75D20-0x0000000181C761D0
		protected override void Execute(); // 0x0000000181C75A70-0x0000000181C75B20
	}
}
