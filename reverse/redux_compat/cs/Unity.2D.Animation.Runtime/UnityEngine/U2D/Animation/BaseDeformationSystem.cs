/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

// Image 29: Unity.2D.Animation.Runtime.dll - Assembly: Unity.2D.Animation.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14331-14427

namespace UnityEngine.U2D.Animation
{
	internal abstract class BaseDeformationSystem // TypeDefIndex: 14333
	{
		// Fields
		protected ulong m_ObjectId; // 0x10
		protected readonly HashSet<SpriteSkin> m_SpriteSkins; // 0x18
		protected SpriteRenderer[] m_SpriteRenderers; // 0x20
		private readonly HashSet<SpriteSkin> m_SpriteSkinsToAdd; // 0x28
		private readonly HashSet<SpriteSkin> m_SpriteSkinsToRemove; // 0x30
		private readonly List<EntityId> m_TransformIdsToRemove; // 0x38
		protected NativeByteArray m_DeformedVerticesBuffer; // 0x40
		protected NativeByteArray m_PreviousDeformedVerticesBuffer; // 0x48
		protected NativeArray<float4x4> m_FinalBoneTransforms; // 0x50
		protected NativeArray<bool> m_IsSpriteSkinActiveForDeform; // 0x60
		protected NativeArray<SpriteSkinData> m_SpriteSkinData; // 0x70
		protected NativeArray<bool> m_IsOutlineDataRequired; // 0x80
		protected NativeArray<PerSkinJobData> m_PerSkinJobData; // 0x90
		protected NativeArray<Bounds> m_BoundsData; // 0xA0
		protected NativeArray<IntPtr> m_Buffers; // 0xB0
		protected NativeArray<int> m_BufferSizes; // 0xC0
		protected NativeArray<int2> m_BoneLookupData; // 0xD0
		protected NativeArray<PerSkinJobData> m_SkinBatchArray; // 0xE0
		protected NativeArray<bool> m_HasBoneTransformsChanged; // 0xF0
		protected NativeArray<int> m_LastDeformedFrame; // 0x100
		protected TransformAccessJob m_LocalToWorldTransformAccessJob; // 0x110
		protected TransformAccessJob m_WorldToLocalTransformAccessJob; // 0x118
		protected JobHandle m_DeformJobHandle; // 0x120
	
		// Properties
		public abstract DeformationMethods deformationMethod { get; }
	
		// Nested types
		protected static class Profiling // TypeDefIndex: 14334
		{
			// Fields
			public static readonly ProfilerMarker transformAccessJob; // 0x00
			public static readonly ProfilerMarker boneTransformsChangeDetection; // 0x08
			public static readonly ProfilerMarker getSpriteSkinBatchData; // 0x10
			public static readonly ProfilerMarker scheduleJobs; // 0x18
			public static readonly ProfilerMarker setBatchDeformableBufferAndLocalAABB; // 0x20
			public static readonly ProfilerMarker setBatchBoneTransformIndexAndLocalAABB; // 0x28
			public static readonly ProfilerMarker validateSpriteSkinData; // 0x30
	
			// Constructors
			static Profiling(); // 0x0000000181C1F780-0x0000000181C1F940
		}
	
		// Constructors
		protected BaseDeformationSystem(); // 0x0000000181C18FF0-0x0000000181C19140
	
		// Methods
		internal void RemoveBoneTransforms(SpriteSkin spriteSkin); // 0x0000000181C18100-0x0000000181C18220
		internal void AddBoneTransforms(SpriteSkin spriteSkin); // 0x0000000181C16560-0x0000000181C16690
		internal virtual void UpdateMaterial(SpriteSkin spriteSkin); // 0x00000001802E76C0-0x00000001802E76D0
		internal virtual bool AddSpriteSkin(SpriteSkin spriteSkin); // 0x0000000181C16690-0x0000000181C16760
		internal void CopyToSpriteSkinData(SpriteSkin spriteSkin); // 0x0000000181C170C0-0x0000000181C17370
		internal void RemoveSpriteSkin(SpriteSkin spriteSkin); // 0x0000000181C18220-0x0000000181C183B0
		internal HashSet<SpriteSkin> GetSpriteSkins(); // 0x00000001802F8EC0-0x00000001802F8ED0
		internal void Initialize(ulong objectId); // 0x0000000181C17740-0x0000000181C17930
		protected virtual void InitializeArrays(); // 0x0000000181C174F0-0x0000000181C17740
		protected void BatchRemoveSpriteSkins(); // 0x0000000181C16AC0-0x0000000181C16ED0
		protected void BatchAddSpriteSkins(); // 0x0000000181C16760-0x0000000181C16AC0
		protected virtual void ResizeAndCopyArrays(int updatedCount); // 0x0000000181C183B0-0x0000000181C18580
		protected virtual void ResizeBuffers(int vertexBufferSize, [IsReadOnly] in PerSkinJobData skinBatch); // 0x0000000181C18580-0x0000000181C18690
		internal virtual void Cleanup(); // 0x0000000181C16ED0-0x0000000181C170C0
		internal abstract void Update();
		protected void PrepareDataForDeformation(out JobHandle localToWorldJobHandle, out JobHandle worldToLocalJobHandle); // 0x0000000181C17960-0x0000000181C18100
		private void ValidateSpriteSkinData(); // 0x0000000181C18DD0-0x0000000181C18FF0
		protected bool GotVerticesToDeform(out int vertexBufferSize); // 0x0000000181C174D0-0x0000000181C174F0
		protected JobHandle SchedulePrepareJob(int batchCount); // 0x0000000181C18930-0x0000000181C189F0
		protected JobHandle ScheduleBoneJobBatched(JobHandle jobHandle, PerSkinJobData skinBatch); // 0x0000000181C18690-0x0000000181C187F0
		protected JobHandle ScheduleSkinDeformBatchedJobCpu(JobHandle jobHandle, PerSkinJobData skinBatch, int spriteCount, int frameCount); // 0x0000000181C189F0-0x0000000181C18BE0
		protected JobHandle ScheduleSkinDeformBatchedJobGpu(JobHandle jobHandle, PerSkinJobData skinBatch, int spriteCount, int frameCount); // 0x0000000181C18BE0-0x0000000181C18DD0
		protected JobHandle ScheduleCopySpriteRendererBuffersJob(JobHandle jobHandle, int batchCount); // 0x0000000181C187F0-0x0000000181C18930
		internal bool IsSpriteSkinActiveForDeformation(SpriteSkin spriteSkin); // 0x0000000181C17930-0x0000000181C17960
		internal int GetLastDeformedFrame(SpriteSkin spriteSkin); // 0x0000000181C174A0-0x0000000181C174D0
		internal NativeArray<byte> GetDeformableBufferForSpriteSkin(SpriteSkin spriteSkin); // 0x0000000181C17370-0x0000000181C174A0
	}
}
