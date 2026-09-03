/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;

// Image 86: Unity.InternalAPIEngineBridge.001.dll - Assembly: Unity.InternalAPIEngineBridge.001, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15973-15975

namespace UnityEngine.U2D.Common
{
	internal static class InternalEngineBridge // TypeDefIndex: 15975
	{
		// Methods
		public static void SetLocalAABB(SpriteRenderer spriteRenderer, Bounds aabb); // 0x0000000181DEA6A0-0x0000000181DEA6D0
		public static void SetDeformableBuffer(SpriteRenderer spriteRenderer, NativeArray<byte> src); // 0x0000000181DEA680-0x0000000181DEA6A0
		public static bool IsUsingDeformableBuffer(SpriteRenderer spriteRenderer, IntPtr buffer); // 0x0000000181DEA5E0-0x0000000181DEA5F0
		public static void SetupMaterialProperties(SpriteRenderer spriteRenderer); // 0x0000000181DEA6D0-0x0000000181DEA6E0
		public static Vector2 GUIUnclip(Vector2 v); // 0x0000000181DEA520-0x0000000181DEA530
		public static Rect GetGUIClipTopMostRect(); // 0x0000000181DEA530-0x0000000181DEA560
		public static Rect GetGUIClipTopRect(); // 0x0000000181DEA560-0x0000000181DEA590
		public static Rect GetGUIClipVisibleRect(); // 0x0000000181DEA590-0x0000000181DEA5C0
		public static bool IsGPUSkinningEnabled(SpriteRenderer spriteRenderer); // 0x0000000181DEA5C0-0x0000000181DEA5D0
		public static bool IsSRPBatchingEnabled(SpriteRenderer spriteRenderer); // 0x0000000181DEA5D0-0x0000000181DEA5E0
		public static void SetBatchDeformableBufferAndLocalAABBArray(SpriteRenderer[] spriteRenderers, NativeArray<IntPtr> buffers, NativeArray<int> bufferSizes, NativeArray<Bounds> bounds); // 0x0000000181DEA640-0x0000000181DEA680
		public static void SetBatchBoneTransformIndexAndLocalAABBArray(SpriteRenderer[] spriteRenderers, NativeArray<int> boneTransformIndices, NativeArray<Bounds> bounds); // 0x0000000181DEA610-0x0000000181DEA640
		public static int ConvertFloatToInt(float f); // 0x0000000181DEA500-0x0000000181DEA510
		public static float ConvertIntToFloat(int i); // 0x0000000181DEA510-0x0000000181DEA520
	
		// Extension methods
		public static void MarkDirty(this UnityEngine.Object obj); // 0x0000000181DEA5F0-0x0000000181DEA610
	}
}
