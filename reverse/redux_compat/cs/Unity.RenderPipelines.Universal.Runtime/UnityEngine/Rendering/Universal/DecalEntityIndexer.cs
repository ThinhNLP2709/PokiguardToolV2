/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal class DecalEntityIndexer // TypeDefIndex: 9425
	{
		// Fields
		private List<DecalEntityItem> m_Entities; // 0x10
		private Queue<int> m_FreeIndices; // 0x18
	
		// Nested types
		public struct DecalEntityItem // TypeDefIndex: 9426
		{
			// Fields
			public int chunkIndex; // 0x00
			public int arrayIndex; // 0x04
			public int version; // 0x08
		}
	
		// Constructors
		public DecalEntityIndexer(); // 0x0000000181F75DE0-0x0000000181F75EA0
	
		// Methods
		public bool IsValid(DecalEntity decalEntity); // 0x0000000181F75C10-0x0000000181F75C60
		public DecalEntity CreateDecalEntity(int arrayIndex, int chunkIndex); // 0x0000000181F75980-0x0000000181F75B30
		public void DestroyDecalEntity(DecalEntity decalEntity); // 0x0000000181F75B30-0x0000000181F75BD0
		public DecalEntityItem GetItem(DecalEntity decalEntity); // 0x0000000181F75BD0-0x0000000181F75C10
		public void UpdateIndex(DecalEntity decalEntity, int newArrayIndex); // 0x0000000181F75D50-0x0000000181F75DE0
		public void RemapChunkIndices(List<int> remaper); // 0x0000000181F75C60-0x0000000181F75D50
		public void Clear(); // 0x0000000181F75940-0x0000000181F75980
	}
}
