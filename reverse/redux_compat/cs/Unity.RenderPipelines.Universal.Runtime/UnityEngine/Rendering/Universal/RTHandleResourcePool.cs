/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal class RTHandleResourcePool // TypeDefIndex: 9686
	{
		// Fields
		[TupleElementNames(new string[2] {"resource", "frameIndex" })]
		protected Dictionary<int, SortedList<ulong, ValueTuple<RTHandle, int>>> m_ResourcePool; // 0x10
		protected List<ulong> m_RemoveList; // 0x18
		protected static int s_CurrentStaleResourceCount; // 0x00
		protected const int k_StaleResourceLifetime = 3; // Metadata: 0x0069EEA1
		private const int k_StaleResourceMaxCapacityDefault = 32; // Metadata: 0x0069EEA2
		protected static int s_StaleResourceMaxCapacity; // 0x04
	
		// Properties
		internal int staleResourceCapacity { get; set; } // 0x0000000181FC8B70-0x0000000181FC8BC0 0x0000000181FC8BC0-0x0000000181FC8C30
	
		// Constructors
		public RTHandleResourcePool(); // 0x0000000181FC8AA0-0x0000000181FC8B70
		static RTHandleResourcePool(); // 0x0000000181FC8A50-0x0000000181FC8AA0
	
		// Methods
		internal bool AddResourceToPool([IsReadOnly] in TextureDesc texDesc, RTHandle resource, int currentFrameIndex); // 0x0000000181FC7870-0x0000000181FC7A60
		internal bool TryGetResource([IsReadOnly] in TextureDesc texDesc, out RTHandle resource, bool usepool = true /* Metadata: 0x0069EE97 */); // 0x0000000181FC88B0-0x0000000181FC8A50
		internal void Cleanup(); // 0x0000000181FC7A60-0x0000000181FC7D20
		protected static bool ShouldReleaseResource(int lastUsedFrameIndex, int currentFrameIndex); // 0x0000000181FC88A0-0x0000000181FC88B0
		internal void PurgeUnusedResources(int currentFrameIndex); // 0x0000000181FC84C0-0x0000000181FC88A0
		internal void LogDebugInfo(); // 0x0000000181FC7F20-0x0000000181FC84C0
		internal int GetHashCodeWithNameHash([IsReadOnly] in TextureDesc texDesc); // 0x0000000181FC7E80-0x0000000181FC7F20
		internal static TextureDesc CreateTextureDesc(RenderTextureDescriptor desc, TextureSizeMode textureSizeMode = TextureSizeMode.Explicit /* Metadata: 0x0069EE98 */, int anisoLevel = 1 /* Metadata: 0x0069EE99 */, float mipMapBias = 0f /* Metadata: 0x0069EE9A */, FilterMode filterMode = FilterMode.Point /* Metadata: 0x0069EE9E */, TextureWrapMode wrapMode = TextureWrapMode.Clamp /* Metadata: 0x0069EE9F */, string name = "" /* Metadata: 0x0069EEA0 */); // 0x0000000181FC7D20-0x0000000181FC7E80
	}
}
