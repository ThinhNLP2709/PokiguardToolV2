/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

// Image 36: Unity.2D.Common.Runtime.dll - Assembly: Unity.2D.Common.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14954-14996

namespace UnityEngine.U2D.Common.UTess
{
	internal struct ConvexHull2D // TypeDefIndex: 14969
	{
		// Fields
		private static readonly float kEpsilon; // 0x00
	
		// Nested types
		private struct F3Compare : IComparer<float3> // TypeDefIndex: 14970
		{
			// Methods
			public int Compare(float3 x, float3 y); // 0x0000000181C325D0-0x0000000181C32600
		}
	
		// Constructors
		static ConvexHull2D(); // 0x0000000181C32560-0x0000000181C325A0
	
		// Methods
		private static float DistancePointToLine(float2 pq, float2 p0, float2 p1); // 0x0000000181C30E20-0x0000000181C30F60
		private static float Sign(float2 p1, float2 p2, float2 p3); // 0x0000000181C32500-0x0000000181C32560
		private static bool PointInTriangle(float2 pt, float2 v1, float2 v2, float2 v3); // 0x0000000181C323B0-0x0000000181C32500
		private static void FetchPointsOutsideTriangle(ref NativeArray<float2> input, int inputCount, ref NativeArray<float2> output, ref int outputCount, float2 lp, float2 p, float2 rp); // 0x0000000181C31000-0x0000000181C31170
		private static void FetchPointsOnRight(ref NativeArray<float2> input, int inputCount, ref NativeArray<float2> output, ref int outputCount, float2 l, float2 r); // 0x0000000181C30F60-0x0000000181C31000
		private static unsafe void FetchPoints(float2* input, int inputCount, ref NativeArray<float2> lp, ref int lpCount, ref NativeArray<float2> rp, ref int rpCount, float2 l, float2 r); // 0x0000000181C31170-0x0000000181C31260
		private static void Generate(ref NativeArray<float2> output, ref int outputCount, ref NativeArray<float2> input, int inputCount, float2 l, float2 r); // 0x0000000181C31260-0x0000000181C31850
		private static unsafe int CheckSide(float2* convex, int start, int end, float2 p, float2 d); // 0x0000000181C30D60-0x0000000181C30E20
		public static bool CheckCollisionSeparatingAxis(ref NativeArray<float2> convex1_, int start1, int end1, ref NativeArray<float2> convex2_, int start2, int end2); // 0x0000000181C30B60-0x0000000181C30D60
		internal static bool LineLineIntersection(float2 p1, float2 p2, float2 p3, float2 p4, ref float2 result); // 0x0000000181C32220-0x0000000181C323B0
		public static unsafe float3 Generate(ref NativeArray<float2> result, ref float4 aabb, ref int pointCount, int seed, Vector2* vertexInput, int vertexCount, float extrude); // 0x0000000181C31850-0x0000000181C32220
	}
}
