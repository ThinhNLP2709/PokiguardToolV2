/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.U2D
{
	[NativeHeader("Runtime/2D/Common/SpriteDataAccess.h")]
	[NativeHeader("Runtime/Graphics/Mesh/SpriteRenderer.h")]
	public static class SpriteRendererDataAccessExtensions // TypeDefIndex: 8466
	{
		// Methods
		internal static void SetBatchDeformableBufferAndLocalAABBArray(SpriteRenderer[] spriteRenderers, NativeArray<IntPtr> buffers, NativeArray<int> bufferSizes, NativeArray<Bounds> bounds); // 0x000000018226D680-0x000000018226D760
		internal static void SetBatchBoneTransformIndexAndLocalAABBArray(SpriteRenderer[] spriteRenderers, NativeArray<int> boneTransformIndices, NativeArray<Bounds> bounds); // 0x000000018226D5B0-0x000000018226D680
		private static unsafe void SetDeformableBuffer([NotNull] SpriteRenderer spriteRenderer, void* src, int count); // 0x000000018226DA90-0x000000018226DB40
		private static unsafe void SetBatchDeformableBufferAndLocalAABBArray(SpriteRenderer[] spriteRenderers, void* buffers, void* bufferSizes, void* bounds, int count); // 0x000000018226D760-0x000000018226D7D0
		private static unsafe bool IsUsingDeformableBuffer([NotNull] SpriteRenderer spriteRenderer, void* buffer); // 0x000000018226D4A0-0x000000018226D540
		private static unsafe void SetBatchBoneTransformIndexAndLocalAABBArray(SpriteRenderer[] spriteRenderers, void* boneTransformIndices, void* bounds, int count); // 0x000000018226D540-0x000000018226D5B0
		internal static void SetupMaterialProperties([NotNull] SpriteRenderer spriteRenderer); // 0x000000018226DC70-0x000000018226DD00
		internal static bool IsGPUSkinningEnabled(SpriteRenderer spriteRenderer); // 0x000000018226D290-0x000000018226D2D0
		private static void DeactivateDeformableBuffer_Injected(IntPtr renderer); // 0x000000018226D180-0x000000018226D1C0
		private static void SetLocalAABB_Injected(IntPtr renderer, in Bounds aabb); // 0x000000018226DB40-0x000000018226DB90
		private static unsafe void SetDeformableBuffer_Injected(IntPtr spriteRenderer, void* src, int count); // 0x000000018226D7D0-0x000000018226D830
		private static unsafe bool IsUsingDeformableBuffer_Injected(IntPtr spriteRenderer, void* buffer); // 0x000000018226D3A0-0x000000018226D3F0
		private static void SetupMaterialProperties_Injected(IntPtr spriteRenderer); // 0x000000018226DC30-0x000000018226DC70
		private static bool IsGPUSkinningEnabled_Injected(IntPtr spriteRenderer); // 0x000000018226D250-0x000000018226D290
		private static bool IsSRPBatchingEnabled_Injected(IntPtr spriteRenderer); // 0x000000018226D2D0-0x000000018226D310
	
		// Extension methods
		internal static void SetDeformableBuffer(this SpriteRenderer spriteRenderer, NativeArray<byte> src); // 0x000000018226D830-0x000000018226DA90
		internal static bool IsUsingDeformableBuffer(this SpriteRenderer spriteRenderer, IntPtr buffer); // 0x000000018226D3F0-0x000000018226D4A0
		public static void DeactivateDeformableBuffer([NotNull] this SpriteRenderer renderer); // 0x000000018226D1C0-0x000000018226D250
		internal static void SetLocalAABB([NotNull] this SpriteRenderer renderer, Bounds aabb); // 0x000000018226DB90-0x000000018226DC30
		internal static bool IsSRPBatchingEnabled([NotNull] this SpriteRenderer spriteRenderer); // 0x000000018226D310-0x000000018226D3A0
	}
}
