/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.ResourceManagement.Util;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.AsyncOperations
{
	internal class GroupOperation : AsyncOperationBase<IList<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>>, ICachable // TypeDefIndex: 13799
	{
		// Fields
		private Action<AsyncOperationHandle> m_InternalOnComplete; // 0x98
		private int m_LoadedCount; // 0xA0
		private GroupOperationSettings m_Settings; // 0xA4
		private string debugName; // 0xA8
		private const int k_MaxDisplayedLocationLength = 45; // Metadata: 0x006A7E91
		private const int k_MaxDebugNameLength = 2000; // Metadata: 0x006A7E92
		[CompilerGenerated]
		private IOperationCacheKey _UnityEngine_ResourceManagement_AsyncOperations_ICachable_Key_k__BackingField; // 0xB0
		private HashSet<string> m_CachedDependencyLocations; // 0xB8
	
		// Properties
		IOperationCacheKey ICachable.Key { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806BAE60-0x00000001806BAE70 0x00000001806C0C00-0x00000001806C0C20
		protected override string DebugName { get; } // 0x000000018205EFE0-0x000000018205F2B0 
		protected override float Progress { get; } // 0x000000018205F2B0-0x000000018205F4E0 
	
		// Nested types
		[Flags]
		public enum GroupOperationSettings // TypeDefIndex: 13800
		{
			None = 0,
			ReleaseDependenciesOnFailure = 1,
			AllowFailedDependencies = 2
		}
	
		// Constructors
		public GroupOperation(); // 0x000000018205EEB0-0x000000018205EFE0
	
		// Methods
		protected override bool InvokeWaitForCompletion(); // 0x000000018205E9A0-0x000000018205EC60
		internal IList<AsyncOperationHandle> GetDependentOps(); // 0x0000000180377550-0x0000000180377560
		public override void GetDependencies(List<AsyncOperationHandle> deps); // 0x000000018205E560-0x000000018205E5C0
		internal override void ReleaseDependencies(); // 0x000000018205EC70-0x000000018205EEB0
		internal override DownloadStatus GetDownloadStatus(HashSet<object> visited); // 0x000000018205E5C0-0x000000018205E840
		private bool DependenciesAreUnchanged(List<AsyncOperationHandle> deps); // 0x000000018205E180-0x000000018205E2E0
		protected override void Execute(); // 0x000000018205E320-0x000000018205E560
		private void CompleteIfDependenciesComplete(); // 0x000000018205DF80-0x000000018205E180
		protected override void Destroy(); // 0x000000018205E2E0-0x000000018205E320
		public void Init(List<AsyncOperationHandle> operations, bool releaseDependenciesOnFailure = true /* Metadata: 0x006A7E8F */, bool allowFailedDependencies = false /* Metadata: 0x006A7E90 */); // 0x000000018205E8E0-0x000000018205E9A0
		public void Init(List<AsyncOperationHandle> operations, GroupOperationSettings settings); // 0x000000018205E840-0x000000018205E8E0
		private void OnOperationCompleted(AsyncOperationHandle op); // 0x000000018205EC60-0x000000018205EC70
	}
}
