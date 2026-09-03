/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal class DecalDrawErrorSystem : DecalDrawSystem // TypeDefIndex: 9410
	{
		// Fields
		private DecalTechnique m_Technique; // 0x40
	
		// Constructors
		public DecalDrawErrorSystem(DecalEntityManager entityManager, DecalTechnique technique); // 0x0000000181F73DF0-0x0000000181F73E70
	
		// Methods
		protected override int GetPassIndex(DecalCachedChunk decalCachedChunk); // 0x0000000181F73D80-0x0000000181F73DF0
		protected override Material GetMaterial(DecalEntityChunk decalEntityChunk); // 0x0000000181F73D60-0x0000000181F73D80
	}
}
