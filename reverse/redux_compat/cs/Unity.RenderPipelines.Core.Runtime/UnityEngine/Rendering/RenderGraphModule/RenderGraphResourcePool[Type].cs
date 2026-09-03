/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule
{
	internal abstract class RenderGraphResourcePool<Type> : IRenderGraphResourcePool // TypeDefIndex: 5949
		where Type : class
	{
		// Fields
		protected Dictionary<int, SortedList<ulong, PooledResourceEntry<Type>>> m_ResourcePool;
		private List<ValueTuple<int, Type>> m_FrameAllocatedResources;
		private const int kStaleResourceLifetime = 10; // Metadata: 0x00662C28
		private static readonly List<ulong> s_ToRemoveList;
	
		// Constructors
		protected RenderGraphResourcePool();
		static RenderGraphResourcePool();
	
		// Methods
		protected abstract void ReleaseInternalResource(Type res);
		protected abstract string GetResourceName([IsReadOnly] in ref Type res);
		protected abstract long GetResourceSize([IsReadOnly] in ref Type res);
		protected abstract string GetResourceTypeName();
		protected abstract ulong GetSortIndex(Type res);
		public void ReleaseResource(int hash, Type resource, int currentFrameIndex, int currentExecutionCount);
		public bool TryGetResource(int hashCode, out ref Type resource, int currentFrameIndex, int currentExecutionCount);
		public override void Cleanup();
		[Conditional("UNITY_ENABLE_CHECKS")]
		public void RegisterFrameAllocation(int hash, Type value);
		[Conditional("UNITY_ENABLE_CHECKS")]
		public void UnregisterFrameAllocation(int hash, Type value);
		public override void CheckFrameAllocation(bool onException, int frameIndex);
		public float GetMemorySizeInMB();
		public int GetNumResourcesAvailable();
		public override void PurgeUnusedResources(int currentFrameIndex);
	}
}
