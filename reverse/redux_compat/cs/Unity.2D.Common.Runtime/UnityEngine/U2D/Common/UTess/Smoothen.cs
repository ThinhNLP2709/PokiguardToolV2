/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Mathematics;

// Image 36: Unity.2D.Common.Runtime.dll - Assembly: Unity.2D.Common.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14954-14996

namespace UnityEngine.U2D.Common.UTess
{
	internal struct Smoothen // TypeDefIndex: 14961
	{
		// Fields
		private static readonly float kMaxAreaTolerance; // 0x00
		private static readonly float kMaxEdgeTolerance; // 0x04
	
		// Constructors
		static Smoothen(); // 0x0000000181C3B010-0x0000000181C3B060
	
		// Methods
		private static void RefineEdges(ref NativeArray<int4> refinedEdges, ref NativeArray<int4> delaEdges, ref int delaEdgeCount, ref NativeArray<int4> voronoiEdges); // 0x0000000181C3AE70-0x0000000181C3B010
		private static void GetAffectingEdges(int pointIndex, NativeArray<int4> edges, int edgeCount, ref NativeArray<int> resultSet, ref NativeArray<int> checkSet, ref int resultCount); // 0x0000000181C3AE00-0x0000000181C3AE70
		private static void CentroidByPoints(int triIndex, NativeArray<UTriangle> triangles, ref NativeArray<int> centroidTris, ref int centroidCount, ref float2 aggregate, ref float2 point); // 0x0000000181C3A020-0x0000000181C3A0C0
		private static void CentroidByPolygon(int4 e, NativeArray<UTriangle> triangles, ref float2 centroid, ref float area, ref float distance); // 0x0000000181C3A0C0-0x0000000181C3A1F0
		private static bool ConnectTriangles(ref NativeArray<int4> connectedTri, ref NativeArray<int> affectEdges, ref NativeArray<int> checkSet, NativeArray<int4> voronoiEdges, int triangleCount); // 0x0000000181C3AC00-0x0000000181C3AE00
		internal static bool Condition(Allocator allocator, ref NativeArray<float2> pgPoints, int pgPointCount, NativeArray<int2> pgEdges, int pgEdgeCount, ref NativeArray<float2> vertices, ref int vertexCount, ref NativeArray<int> indices, ref int indexCount); // 0x0000000181C3A1F0-0x0000000181C3AC00
	}
}
