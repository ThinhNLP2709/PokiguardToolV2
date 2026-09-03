/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Mathematics;

// Image 36: Unity.2D.Common.Runtime.dll - Assembly: Unity.2D.Common.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14954-14996

namespace UnityEngine.U2D.Common.UAi
{
	internal static class kMeans // TypeDefIndex: 14994
	{
		// Methods
		private static float CalculateDistance(MatrixMxN<float> data, int dataIndex, MatrixMxN<float> centroid, int centroidIndex); // 0x0000000181C3F9B0-0x0000000181C3FA90
		private static float CalculateClustering(MatrixMxN<float> data, NativeArray<int> clusters, ref MatrixMxN<float> means, ref NativeArray<int> centroids, int clusterCount, ref NativeArray<int> clusterItems); // 0x0000000181C3F670-0x0000000181C3F9B0
		private static bool AssignClustering(MatrixMxN<float> data, NativeArray<int> clusters, ref NativeArray<int> centroidIdx, int clusterCount); // 0x0000000181C3F500-0x0000000181C3F670
		private static void ClusterInternal(MatrixMxN<float> data, NativeArray<int> clusters, MatrixMxN<float> means, NativeArray<int> centroids, NativeArray<int> clusterItems, int clusterCount, int maxIterations); // 0x0000000181C3FD20-0x0000000181C3FF90
		public static int[] Cluster3(NativeArray<float3> items, int clusterCount, Allocator alloc, int maxIterations = 64 /* Metadata: 0x006A9C0D */); // 0x0000000181C3FA90-0x0000000181C3FD20
	}
}
