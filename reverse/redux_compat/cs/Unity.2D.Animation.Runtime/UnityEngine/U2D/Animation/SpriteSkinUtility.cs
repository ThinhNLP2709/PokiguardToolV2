/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.U2D;

// Image 29: Unity.2D.Animation.Runtime.dll - Assembly: Unity.2D.Animation.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14331-14427

namespace UnityEngine.U2D.Animation
{
	internal static class SpriteSkinUtility // TypeDefIndex: 14418
	{
		// Methods
		internal static bool CanUseGpuDeformation(); // 0x0000000181C27440-0x0000000181C27450
		internal static bool IsUsingGpuDeformation(); // 0x0000000181C29B40-0x0000000181C29C40
		internal static bool IsGpuDeformationActive(SpriteRenderer spriteRenderer); // 0x0000000181C29B00-0x0000000181C29B40
		internal static bool CanSpriteSkinUseGpuDeformation(SpriteSkin spriteSkin); // 0x0000000181C272E0-0x0000000181C27440
		private static void CreateGameObject(int index, SpriteBone[] spriteBones, Transform[] transforms, Transform root); // 0x0000000181C276E0-0x0000000181C27940
		private static int GetHash(Matrix4x4 matrix); // 0x0000000181C299F0-0x0000000181C29A10
		internal static void Deform(Sprite sprite, Matrix4x4 rootInv, NativeSlice<Vector3> vertices, NativeSlice<Vector4> tangents, NativeSlice<BoneWeight> boneWeights, NativeArray<Matrix4x4> boneTransforms, NativeSlice<Matrix4x4> bindPoses, NativeArray<byte> deformableVertices); // 0x0000000181C28490-0x0000000181C289D0
		internal static void Deform(float4x4 rootInv, NativeSlice<float3> vertices, NativeSlice<BoneWeight> boneWeights, NativeArray<float4x4> boneTransforms, NativeSlice<float4x4> bindPoses, NativeSlice<float3> deformed); // 0x0000000181C27BF0-0x0000000181C28490
		internal static void Deform(float4x4 rootInv, NativeSlice<float3> vertices, NativeSlice<float4> tangents, NativeSlice<BoneWeight> boneWeights, NativeArray<float4x4> boneTransforms, NativeSlice<float4x4> bindPoses, NativeSlice<float3> deformed, NativeSlice<float4> deformedTangents); // 0x0000000181C289D0-0x0000000181C299F0
		internal static void Deform(Sprite sprite, Matrix4x4 invRoot, Transform[] boneTransformsArray, NativeArray<byte> deformVertexData); // 0x0000000181C27940-0x0000000181C27BF0
		internal static Bounds CalculateSpriteSkinBounds(NativeSlice<float3> deformablePositions); // 0x0000000181C26F50-0x0000000181C27180
	
		// Extension methods
		internal static SpriteSkinState Validate(this SpriteSkin spriteSkin); // 0x0000000181C29D70-0x0000000181C29F60
		internal static void CreateBoneHierarchy(this SpriteSkin spriteSkin); // 0x0000000181C27450-0x0000000181C276E0
		internal static int GetVertexStreamSize(this Sprite sprite); // 0x0000000181C29AB0-0x0000000181C29B00
		internal static int GetVertexStreamOffset(this Sprite sprite, VertexAttribute channel); // 0x0000000181C29A10-0x0000000181C29AB0
		internal static int CalculateTransformHash(this SpriteSkin spriteSkin); // 0x0000000181C27180-0x0000000181C272E0
		internal static void Bake(this SpriteSkin spriteSkin, NativeArray<byte> deformVertexData); // 0x0000000181C26B10-0x0000000181C26C00
		internal static void CalculateBounds(this SpriteSkin spriteSkin); // 0x0000000181C26C00-0x0000000181C26F50
		internal static void UpdateBounds(this SpriteSkin spriteSkin, NativeArray<byte> deformedVertices); // 0x0000000181C29C40-0x0000000181C29D70
	}
}
