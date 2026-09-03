/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

// Image 29: Unity.2D.Animation.Runtime.dll - Assembly: Unity.2D.Animation.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14331-14427

namespace UnityEngine.U2D.Animation
{
	internal class GpuDeformationSystem : BaseDeformationSystem // TypeDefIndex: 14351
	{
		// Fields
		private const string k_GpuSkinningShaderKeyword = "SKINNED_SPRITE"; // Metadata: 0x006A9660
		private const string k_GlobalSpriteBoneBufferId = "_SpriteBoneTransforms"; // Metadata: 0x006A966F
		private readonly Dictionary<EntityId, Material> m_KeywordEnabledMaterials; // 0x130
		private NativeArray<int> m_BoneTransformIndices; // 0x138
		private ComputeBuffer m_BoneTransformsComputeBuffer; // 0x148
		private static ComputeBuffer s_FallbackBuffer; // 0x00
	
		// Properties
		public override DeformationMethods deformationMethod { get; } // 0x0000000180472790-0x00000001804727A0 
	
		// Constructors
		public GpuDeformationSystem(); // 0x0000000181C1E840-0x0000000181C1E8C0
	
		// Methods
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		private static void CreateFallbackBuffer(); // 0x0000000181C1D970-0x0000000181C1DA40
		private static void ClearFallbackBuffer(); // 0x0000000181C1D840-0x0000000181C1D8B0
		internal static bool DoesShaderSupportGpuDeformation(Material material); // 0x0000000181C1DA40-0x0000000181C1DB60
		private static bool IsComputeBufferValid(ComputeBuffer buffer); // 0x0000000181C1DC70-0x0000000181C1DC80
		protected override void InitializeArrays(); // 0x0000000181C1DB60-0x0000000181C1DC70
		internal override void Cleanup(); // 0x0000000181C1D780-0x0000000181C1D840
		protected override void ResizeAndCopyArrays(int updatedCount); // 0x0000000181C1DC80-0x0000000181C1DEA0
		private void CleanupComputeResources(); // 0x0000000181C1D5B0-0x0000000181C1D780
		internal override void UpdateMaterial(SpriteSkin spriteSkin); // 0x0000000181C1E1C0-0x0000000181C1E240
		internal override bool AddSpriteSkin(SpriteSkin spriteSkin); // 0x0000000181C1D430-0x0000000181C1D5B0
		internal override void Update(); // 0x0000000181C1E240-0x0000000181C1E840
		protected override void ResizeBuffers(int vertexBufferSize, [IsReadOnly] in PerSkinJobData skinBatch); // 0x0000000181C1DEA0-0x0000000181C1E080
		private void CreateComputeBuffer(int bufferSize); // 0x0000000181C1D8B0-0x0000000181C1D970
		private void SetComputeBuffer(); // 0x0000000181C1E130-0x0000000181C1E1C0
		protected JobHandle ScheduleCalculateBoneTransformIndicesJob(JobHandle jobHandle); // 0x0000000181C1E080-0x0000000181C1E130
	}
}
