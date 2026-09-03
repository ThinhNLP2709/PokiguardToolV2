/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

// Image 38: UnityEngine.U2DRuntimeModule.dll - Assembly: UnityEngine.U2DRuntimeModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15050-15086

namespace UnityEngine.U2D.UTess
{
	internal struct Smoothen // TypeDefIndex: 15059
	{
		// Fields
		private static readonly float kMaxAreaTolerance; // 0x00
		private static readonly float kMaxEdgeTolerance; // 0x04
	
		// Constructors
		static Smoothen(); // 0x000000018235BF90-0x000000018235BFE0
	
		// Methods
		private static void RefineEdges(ref NativeArray<int4> refinedEdges, ref NativeArray<int4> delaEdges, ref int delaEdgeCount, ref NativeArray<int4> voronoiEdges); // 0x000000018235BDF0-0x000000018235BF90
		private static void GetAffectingEdges(int pointIndex, NativeArray<int4> edges, int edgeCount, ref NativeArray<int> resultSet, ref NativeArray<int> checkSet, ref int resultCount); // 0x0000000181C3AE00-0x0000000181C3AE70
		private static void CentroidByPolygon(int4 e, NativeArray<UTriangle> triangles, ref float2 centroid, ref float area, ref float distance); // 0x0000000181C3A0C0-0x0000000181C3A1F0
		private static bool ConnectTriangles(ref NativeArray<int4> connectedTri, ref NativeArray<int> affectEdges, ref NativeArray<int> checkSet, NativeArray<int4> voronoiEdges, int triangleCount); // 0x0000000181C3AC00-0x0000000181C3AE00
		internal static bool Condition(Allocator allocator, ref NativeArray<float2> pgPoints, int pgPointCount, NativeArray<int2> pgEdges, int pgEdgeCount, ref NativeArray<float2> vertices, ref int vertexCount, ref NativeArray<int> indices, ref int indexCount); // 0x000000018235B3D0-0x000000018235BDF0
	}
}
