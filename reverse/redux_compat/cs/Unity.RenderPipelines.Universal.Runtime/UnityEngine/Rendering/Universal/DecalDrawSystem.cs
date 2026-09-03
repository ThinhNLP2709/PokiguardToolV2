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
	internal abstract class DecalDrawSystem // TypeDefIndex: 9424
	{
		// Fields
		internal static readonly uint MaxBatchSize; // 0x00
		protected DecalEntityManager m_EntityManager; // 0x10
		private Matrix4x4[] m_WorldToDecals; // 0x18
		private Matrix4x4[] m_NormalToDecals; // 0x20
		private float[] m_DecalLayerMasks; // 0x28
		private ProfilingSampler m_Sampler; // 0x30
		[CompilerGenerated]
		private Material _overrideMaterial_k__BackingField; // 0x38
	
		// Properties
		public Material overrideMaterial { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
	
		// Constructors
		public DecalDrawSystem(string sampler, DecalEntityManager entityManager); // 0x0000000181F755E0-0x0000000181F75730
		static DecalDrawSystem(); // 0x0000000181F755A0-0x0000000181F755E0
	
		// Methods
		public void Execute(CommandBuffer cmd); // 0x0000000181F74C10-0x0000000181F74C80
		internal void Execute(RasterCommandBuffer cmd); // 0x0000000181F75280-0x0000000181F75580
		protected virtual Material GetMaterial(DecalEntityChunk decalEntityChunk); // 0x0000000181F75580-0x0000000181F755A0
		protected abstract int GetPassIndex(DecalCachedChunk decalCachedChunk);
		private void Execute(RasterCommandBuffer cmd, DecalEntityChunk decalEntityChunk, DecalCachedChunk decalCachedChunk, DecalDrawCallChunk decalDrawCallChunk, int count); // 0x0000000181F74E00-0x0000000181F74FA0
		private void Draw(RasterCommandBuffer cmd, DecalEntityChunk decalEntityChunk, DecalCachedChunk decalCachedChunk, DecalDrawCallChunk decalDrawCallChunk, int passIndex); // 0x0000000181F74600-0x0000000181F748C0
		private void DrawInstanced(RasterCommandBuffer cmd, DecalEntityChunk decalEntityChunk, DecalCachedChunk decalCachedChunk, DecalDrawCallChunk decalDrawCallChunk, int passIndex); // 0x0000000181F74350-0x0000000181F74600
		public void Execute([IsReadOnly] in CameraData cameraData); // 0x0000000181F74FA0-0x0000000181F75280
		private void Execute([IsReadOnly] in CameraData cameraData, DecalEntityChunk decalEntityChunk, DecalCachedChunk decalCachedChunk, DecalDrawCallChunk decalDrawCallChunk, int count); // 0x0000000181F74C80-0x0000000181F74E00
		private void Draw([IsReadOnly] in CameraData cameraData, DecalEntityChunk decalEntityChunk, DecalCachedChunk decalCachedChunk, DecalDrawCallChunk decalDrawCallChunk); // 0x0000000181F748C0-0x0000000181F74C10
		private void DrawInstanced([IsReadOnly] in CameraData cameraData, DecalEntityChunk decalEntityChunk, DecalCachedChunk decalCachedChunk, DecalDrawCallChunk decalDrawCallChunk); // 0x0000000181F74020-0x0000000181F74350
	}
}
