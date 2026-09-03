/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.Initialization;

// Image 25: Unity.Addressables.dll - Assembly: Unity.Addressables, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14023-14125

namespace UnityEngine.ResourceManagement.AsyncOperations
{
	internal class InitalizationObjectsOperation : AsyncOperationBase<bool> // TypeDefIndex: 14028
	{
		// Fields
		private AsyncOperationHandle<ResourceManagerRuntimeData> m_RtdOp; // 0x98
		private AddressablesImpl m_Addressables; // 0xB0
		private AsyncOperationHandle<IList<AsyncOperationHandle>> m_DepOp; // 0xB8
	
		// Properties
		protected override string DebugName { get; } // 0x0000000181C797D0-0x0000000181C79800 
	
		// Constructors
		public InitalizationObjectsOperation(); // 0x0000000181C79790-0x0000000181C797D0
	
		// Methods
		public void Init(AsyncOperationHandle<ResourceManagerRuntimeData> rtdOp, AddressablesImpl addressables); // 0x0000000181C792A0-0x0000000181C79320
		internal bool LogRuntimeWarnings(string pathToBuildLogs); // 0x0000000181C79460-0x0000000181C79620
		protected override bool InvokeWaitForCompletion(); // 0x0000000181C79320-0x0000000181C79460
		protected override void Execute(); // 0x0000000181C78C80-0x0000000181C792A0
		[CompilerGenerated]
		private void _Execute_b__8_0(AsyncOperationHandle<IList<AsyncOperationHandle>> obj); // 0x0000000181C79620-0x0000000181C79790
	}
}
