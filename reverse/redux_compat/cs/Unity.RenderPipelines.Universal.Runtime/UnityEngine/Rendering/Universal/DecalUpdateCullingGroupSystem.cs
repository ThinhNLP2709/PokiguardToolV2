/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal class DecalUpdateCullingGroupSystem // TypeDefIndex: 9438
	{
		// Fields
		private float[] m_BoundingDistance; // 0x10
		private Camera m_Camera; // 0x18
		private DecalEntityManager m_EntityManager; // 0x20
		private ProfilingSampler m_Sampler; // 0x28
	
		// Properties
		public float boundingDistance { get; set; } // 0x0000000181F7EF40-0x0000000181F7EF70 0x0000000181F7EF70-0x0000000181F7EFA0
	
		// Constructors
		public DecalUpdateCullingGroupSystem(DecalEntityManager entityManager, float drawDistance); // 0x0000000181F7EE50-0x0000000181F7EF40
	
		// Methods
		public void Execute(Camera camera); // 0x0000000181F7EA00-0x0000000181F7ECE0
		public void Execute(DecalCachedChunk cachedChunk, DecalCulledChunk culledChunk, int count); // 0x0000000181F7ECE0-0x0000000181F7EE50
		internal static ulong GetSceneCullingMaskFromCamera(Camera camera); // 0x00000001802E7860-0x00000001802E7870
	}
}
