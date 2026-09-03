/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

// Image 28: Unity.UnifiedRayTracing.Runtime.dll - Assembly: Unity.UnifiedRayTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14228-14330

namespace UnityEngine.Rendering.UnifiedRayTracing
{
	internal static class GraphicsHelpers // TypeDefIndex: 14296
	{
		// Properties
		public static long MaxGraphicsBufferSizeInBytes { get; } // 0x000000018211E240-0x000000018211E250 
		public static float MaxGraphicsBufferSizeInGigaBytes { get; } // 0x000000018211E250-0x000000018211E280 
	
		// Methods
		public static void CopyBuffer(ComputeShader copyShader, CommandBuffer cmd, GraphicsBuffer src, int srcOffsetInDWords, GraphicsBuffer dst, int dstOffsetInDwords, int sizeInDWords); // 0x000000018211DA50-0x000000018211DC00
		public static void CopyBuffer(ComputeShader copyShader, GraphicsBuffer src, int srcOffsetInDWords, GraphicsBuffer dst, int dstOffsetInDwords, int sizeInDwords); // 0x000000018211DC00-0x000000018211DE10
		public static bool ReallocateBuffer(ComputeShader copyShader, int oldCapacity, int newCapacity, int elementSizeInBytes, ref GraphicsBuffer buffer); // 0x000000018211DF80-0x000000018211E240
		public static int MaxElementCount(long maxBufferSizeInBytes, int elementSizeInBytes); // 0x000000018211DF60-0x000000018211DF80
		public static int MaxElementCount(int elementSizeInBytes); // 0x000000018211DF30-0x000000018211DF60
		public static int DivUp(int x, int y); // 0x0000000181E58550-0x0000000181E58560
		public static int DivUp(int x, uint y); // 0x0000000181E58550-0x0000000181E58560
		public static uint DivUp(uint x, uint y); // 0x0000000182114920-0x0000000182114930
		public static uint3 DivUp(uint3 x, uint3 y); // 0x000000018211DE10-0x000000018211DEC0
		public static void Flush(CommandBuffer cmd); // 0x000000018211DEC0-0x000000018211DF30
	}
}
