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
	internal class DecalSkipCulledSystem // TypeDefIndex: 9432
	{
		// Fields
		private DecalEntityManager m_EntityManager; // 0x10
		private ProfilingSampler m_Sampler; // 0x18
		private Camera m_Camera; // 0x20
	
		// Constructors
		public DecalSkipCulledSystem(DecalEntityManager entityManager); // 0x0000000181F7E1B0-0x0000000181F7E240
	
		// Methods
		public void Execute(Camera camera); // 0x0000000181F7DEF0-0x0000000181F7E0E0
		private void Execute(DecalCulledChunk culledChunk, int count); // 0x0000000181F7E0E0-0x0000000181F7E1B0
		internal static ulong GetSceneCullingMaskFromCamera(Camera camera); // 0x00000001802E7860-0x00000001802E7870
	}
}
