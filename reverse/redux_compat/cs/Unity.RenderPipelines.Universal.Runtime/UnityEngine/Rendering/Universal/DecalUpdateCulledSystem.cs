/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal class DecalUpdateCulledSystem // TypeDefIndex: 9436
	{
		// Fields
		private DecalEntityManager m_EntityManager; // 0x10
		private ProfilingSampler m_Sampler; // 0x18
	
		// Constructors
		public DecalUpdateCulledSystem(DecalEntityManager entityManager); // 0x0000000181F7E970-0x0000000181F7EA00
	
		// Methods
		public void Execute(); // 0x0000000181F7E780-0x0000000181F7E900
		private void Execute(DecalCulledChunk culledChunk, int count); // 0x0000000181F7E900-0x0000000181F7E970
	}
}
