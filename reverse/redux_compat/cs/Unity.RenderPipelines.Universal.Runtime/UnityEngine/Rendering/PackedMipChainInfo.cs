/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering
{
	internal struct PackedMipChainInfo // TypeDefIndex: 9297
	{
		// Fields
		public Vector2Int textureSize; // 0x00
		public int mipLevelCount; // 0x08
		public int mipLevelCountCheckerboard; // 0x0C
		public Vector2Int[] mipLevelSizes; // 0x10
		public Vector2Int[] mipLevelOffsets; // 0x18
		public Vector2Int[] mipLevelOffsetsCheckerboard; // 0x20
		private Vector2 cachedTextureScale; // 0x28
		private Vector2Int cachedHardwareTextureSize; // 0x30
		private int cachedCheckerboardMipCount; // 0x38
	
		// Nested types
		private enum PackDirection // TypeDefIndex: 9298
		{
			Right = 0,
			Down = 1
		}
	
		// Methods
		public void Allocate(); // 0x0000000181F5C760-0x0000000181F5C7F0
		private static Vector2Int NextMipBegin(Vector2Int prevMipBegin, Vector2Int prevMipSize, PackDirection dir); // 0x0000000181F5CCC0-0x0000000181F5CCF0
		public void ComputePackedMipChainInfo(Vector2Int viewportSize, int checkerboardMipCount); // 0x0000000181F5C7F0-0x0000000181F5CCC0
	}
}
