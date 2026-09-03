/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;
using Unity.Collections;
using UnityEngine;

// Image 29: Unity.2D.Animation.Runtime.dll - Assembly: Unity.2D.Animation.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14331-14427

namespace UnityEngine.U2D.Animation
{
	[BurstCompile]
	internal static class BurstedSpriteSkinUtilities // TypeDefIndex: 14419
	{
		// Nested types
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate bool ValidateBoneWeights_000001BC_PostfixBurstDelegate([IsReadOnly] in NativeCustomSlice<BoneWeight> boneWeights, int bindPoseCount); // TypeDefIndex: 14420; 0x0000000180A70FB0-0x0000000180A70FC0
	
		internal static class ValidateBoneWeights_000001BC_BurstDirectCall // TypeDefIndex: 14421
		{
			// Fields
			private static IntPtr Pointer; // 0x00
	
			// Methods
			private static void ClearFunctionPointer(); // 0x0000000181C30400-0x0000000181C30440
			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr param_0001b6dd); // 0x0000000181C30440-0x0000000181C305B0
			private static IntPtr GetFunctionPointer(); // 0x0000000181C305B0-0x0000000181C30710
			public static bool Invoke([IsReadOnly] in NativeCustomSlice<BoneWeight> boneWeights, int bindPoseCount); // 0x0000000181C2FD10-0x0000000181C2FEE0
		}
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void SetVertexPositionFromByteBuffer_000001BD_PostfixBurstDelegate([IsReadOnly] in NativeArray<byte> buffer, [IsReadOnly] in NativeArray<int> indices, ref NativeArray<Vector3> vertices, int stride); // TypeDefIndex: 14422; 0x000000018043A200-0x000000018043A220
	
		internal static class SetVertexPositionFromByteBuffer_000001BD_BurstDirectCall // TypeDefIndex: 14423
		{
			// Fields
			private static IntPtr Pointer; // 0x00
	
			// Methods
			private static void ClearFunctionPointer(); // 0x0000000181C2FEE0-0x0000000181C2FF20
			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr param_0001b6ed); // 0x0000000181C2FF20-0x0000000181C30090
			private static IntPtr GetFunctionPointer(); // 0x0000000181C30090-0x0000000181C301F0
			public static void Invoke([IsReadOnly] in NativeArray<byte> buffer, [IsReadOnly] in NativeArray<int> indices, ref NativeArray<Vector3> vertices, int stride); // 0x0000000181C2FB10-0x0000000181C2FD10
		}
	
		// Methods
		[BurstCompile]
		internal static bool ValidateBoneWeights([IsReadOnly] in NativeCustomSlice<BoneWeight> boneWeights, int bindPoseCount); // 0x0000000181C2FD10-0x0000000181C2FEE0
		[BurstCompile]
		internal static void SetVertexPositionFromByteBuffer([IsReadOnly] in NativeArray<byte> buffer, [IsReadOnly] in NativeArray<int> indices, ref NativeArray<Vector3> vertices, int stride); // 0x0000000181C2FB10-0x0000000181C2FD10
		[BurstCompile]
		[MonoPInvokeCallback(typeof(ValidateBoneWeights_000001BC_PostfixBurstDelegate))]
		internal static bool ValidateBoneWeights_BurstManaged([IsReadOnly] in NativeCustomSlice<BoneWeight> boneWeights, int bindPoseCount); // 0x0000000181C2FA60-0x0000000181C2FB10
		[BurstCompile]
		[MonoPInvokeCallback(typeof(SetVertexPositionFromByteBuffer_000001BD_PostfixBurstDelegate))]
		internal static void SetVertexPositionFromByteBuffer_BurstManaged([IsReadOnly] in NativeArray<byte> buffer, [IsReadOnly] in NativeArray<int> indices, ref NativeArray<Vector3> vertices, int stride); // 0x0000000181C2F9D0-0x0000000181C2FA60
	}
}
