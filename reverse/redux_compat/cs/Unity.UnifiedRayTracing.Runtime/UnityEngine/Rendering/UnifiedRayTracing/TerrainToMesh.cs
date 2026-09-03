/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 28: Unity.UnifiedRayTracing.Runtime.dll - Assembly: Unity.UnifiedRayTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14228-14330

namespace UnityEngine.Rendering.UnifiedRayTracing
{
	internal static class TerrainToMesh // TypeDefIndex: 14289
	{
		// Methods
		private static AsyncTerrainToMeshRequest MakeAsyncTerrainToMeshRequest(int width, int height, Vector3 heightmapScale, float[,] heightmap, bool[,] holes); // 0x0000000182123E00-0x0000000182124240
		public static AsyncTerrainToMeshRequest ConvertAsync(int heightmapWidth, int heightmapHeight, short[] heightmapData, Vector3 heightmapScale, int holeWidth, int holeHeight, byte[] holedata); // 0x00000001821235F0-0x0000000182123940
		public static Mesh Convert(int heightmapWidth, int heightmapHeight, short[] heightmapData, Vector3 heightmapScale, int holeWidth, int holeHeight, byte[] holedata); // 0x0000000182123B00-0x0000000182123C00
		public static AsyncTerrainToMeshRequest ConvertAsync(Terrain terrain); // 0x0000000182123940-0x0000000182123B00
		public static Mesh Convert(Terrain terrain); // 0x0000000182123C00-0x0000000182123E00
	}
}
