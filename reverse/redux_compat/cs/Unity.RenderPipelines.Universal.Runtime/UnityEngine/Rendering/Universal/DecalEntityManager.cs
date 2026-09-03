/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal class DecalEntityManager : IDisposable // TypeDefIndex: 9429
	{
		// Fields
		public List<DecalEntityChunk> entityChunks; // 0x10
		public List<DecalCachedChunk> cachedChunks; // 0x18
		public List<DecalCulledChunk> culledChunks; // 0x20
		public List<DecalDrawCallChunk> drawCallChunks; // 0x28
		public int chunkCount; // 0x30
		private ProfilingSampler m_AddDecalSampler; // 0x38
		private ProfilingSampler m_ResizeChunks; // 0x40
		private ProfilingSampler m_SortChunks; // 0x48
		private DecalEntityIndexer m_DecalEntityIndexer; // 0x50
		private Dictionary<Material, int> m_MaterialToChunkIndex; // 0x58
		private List<CombinedChunks> m_CombinedChunks; // 0x60
		private List<int> m_CombinedChunkRemmap; // 0x68
		private Material m_ErrorMaterial; // 0x70
		private Mesh m_DecalProjectorMesh; // 0x78
	
		// Properties
		public Material errorMaterial { get; } // 0x0000000181F78C10-0x0000000181F78CD0 
		public Mesh decalProjectorMesh { get; } // 0x0000000181F78B20-0x0000000181F78C10 
	
		// Nested types
		private struct CombinedChunks // TypeDefIndex: 9430
		{
			// Fields
			public DecalEntityChunk entityChunk; // 0x00
			public DecalCachedChunk cachedChunk; // 0x08
			public DecalCulledChunk culledChunk; // 0x10
			public DecalDrawCallChunk drawCallChunk; // 0x18
			public int previousChunkIndex; // 0x20
			public bool valid; // 0x24
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9431
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Comparison<CombinedChunks> __9__26_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181F85CC0-0x0000000181F85D30
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal int _Update_b__26_0(CombinedChunks a, CombinedChunks b); // 0x0000000181F85940-0x0000000181F85A70
		}
	
		// Constructors
		public DecalEntityManager(); // 0x0000000181F78760-0x0000000181F78B20
	
		// Methods
		public bool IsValid(DecalEntity decalEntity); // 0x0000000181F774C0-0x0000000181F77510
		public DecalEntity CreateDecalEntity(DecalProjector decalProjector); // 0x0000000181F76460-0x0000000181F769D0
		private int CreateChunkIndex(Material material); // 0x0000000181F75EA0-0x0000000181F76460
		public void UpdateAllDecalEntitiesData(); // 0x0000000181F77510-0x0000000181F776D0
		public void UpdateDecalEntityData(DecalEntity decalEntity, DecalProjector decalProjector); // 0x0000000181F776D0-0x0000000181F77DA0
		public void DestroyDecalEntity(DecalEntity decalEntity); // 0x0000000181F769D0-0x0000000181F76CA0
		public void Update(); // 0x0000000181F77DA0-0x0000000181F78760
		public void Dispose(); // 0x0000000181F76CA0-0x0000000181F774C0
	}
}
