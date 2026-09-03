/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.AsyncOperations;

// Image 25: Unity.Addressables.dll - Assembly: Unity.Addressables, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14023-14125

namespace UnityEngine.AddressableAssets
{
	internal class CleanBundleCacheOperation : AsyncOperationBase<bool>, IUpdateReceiver // TypeDefIndex: 14078
	{
		// Fields
		private AddressablesImpl m_Addressables; // 0x98
		private AsyncOperationHandle<IList<AsyncOperationHandle>> m_DepOp; // 0xA0
		private List<string> m_CacheDirsForRemoval; // 0xB8
		private Thread m_EnumerationThread; // 0xC0
		private string m_BaseCachePath; // 0xC8
		private bool m_UseMultiThreading; // 0xD0
	
		// Constructors
		public CleanBundleCacheOperation(AddressablesImpl aa, bool forceSingleThreading); // 0x0000000181C77780-0x0000000181C77840
	
		// Methods
		public AsyncOperationHandle<bool> Start(AsyncOperationHandle<IList<AsyncOperationHandle>> depOp); // 0x0000000181C775F0-0x0000000181C77720
		public void CompleteInternal(bool result, bool success, string errorMsg); // 0x0000000181C767C0-0x0000000181C76850
		protected override bool InvokeWaitForCompletion(); // 0x0000000181C773B0-0x0000000181C77450
		protected override void Destroy(); // 0x0000000181C76850-0x0000000181C768B0
		public override void GetDependencies(List<AsyncOperationHandle> dependencies); // 0x0000000181C772A0-0x0000000181C773B0
		protected override void Execute(); // 0x0000000181C76BF0-0x0000000181C76DE0
		void IUpdateReceiver.Update(float unscaledDeltaTime); // 0x0000000181C77720-0x0000000181C77780
		private void RemoveCacheEntries(); // 0x0000000181C77450-0x0000000181C775F0
		private void DetermineCacheDirsNotInUse(object data); // 0x0000000181C76B70-0x0000000181C76BF0
		private void DetermineCacheDirsNotInUse(HashSet<string> cacheDirsInUse); // 0x0000000181C768B0-0x0000000181C76B70
		private HashSet<string> GetCacheDirsInUse(IList<AsyncOperationHandle> catalogOps); // 0x0000000181C76DE0-0x0000000181C772A0
	}
}
