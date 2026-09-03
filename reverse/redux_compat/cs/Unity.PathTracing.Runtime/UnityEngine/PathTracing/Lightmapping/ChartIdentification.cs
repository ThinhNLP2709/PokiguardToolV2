/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Mathematics;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Lightmapping
{
	internal static class ChartIdentification // TypeDefIndex: 13648
	{
		// Methods
		private static uint FindRepWithPathCompression(Span<uint> reps, uint vertexIdx); // 0x0000000181E05D00-0x0000000181E05D60
		private static uint FindRepresentative(Span<uint> reps, uint vertexIdx); // 0x0000000181E05D60-0x0000000181E05DB0
		private static void Union(Span<uint> reps, uint vertexIdx0, uint vertexIdx1); // 0x0000000181E06300-0x0000000181E063C0
		public static void UnionTriangleEdges(ReadOnlySpan<uint> triangleIndices, Span<uint> vertexChartIds); // 0x0000000181E060C0-0x0000000181E06300
		public static void UnionDuplicateVertices(ReadOnlySpan<float2> vertexUvs, ReadOnlySpan<float3> vertexPositions, ReadOnlySpan<float3> vertexNormals, Span<uint> vertexChartIds, bool respectNormals); // 0x0000000181E05E90-0x0000000181E060C0
		public static void FindRepresentatives(Span<uint> vertexChartIds); // 0x0000000181E05DB0-0x0000000181E05E50
		public static void InitializeRepresentatives(Span<uint> vertexChartIds); // 0x0000000181E05E50-0x0000000181E05E90
		public static void Compact(Span<uint> vertexChartIds, out uint chartCount); // 0x0000000181E05BB0-0x0000000181E05D00
	}
}
