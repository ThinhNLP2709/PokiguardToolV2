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
	internal struct Refinery // TypeDefIndex: 15058
	{
		// Fields
		private static readonly float kMinAreaFactor; // 0x00
		private static readonly float kMaxAreaFactor; // 0x04
		private static readonly int kMaxSteinerCount; // 0x08
	
		// Constructors
		static Refinery(); // 0x000000018235B360-0x000000018235B3D0
	
		// Methods
		private static bool RequiresRefining(UTriangle tri, float maxArea); // 0x0000000181C39DB0-0x0000000181C39DC0
		private static void FetchEncroachedSegments(NativeArray<float2> pgPoints, int pgPointCount, NativeArray<int2> pgEdges, int pgEdgeCount, ref Array<UEncroachingSegment> encroach, ref int encroachCount, UCircle c); // 0x000000018235AED0-0x000000018235B170
		private static void InsertVertex(ref NativeArray<float2> pgPoints, ref int pgPointCount, float2 newVertex, ref int nid); // 0x0000000181C39D90-0x0000000181C39DB0
		private static void SplitSegments(ref NativeArray<float2> pgPoints, ref int pgPointCount, ref NativeArray<int2> pgEdges, ref int pgEdgeCount, UEncroachingSegment es); // 0x000000018235B170-0x000000018235B360
		internal static bool Condition(Allocator allocator, float factorArea, float targetArea, ref NativeArray<float2> pgPoints, ref int pgPointCount, ref NativeArray<int2> pgEdges, ref int pgEdgeCount, ref NativeArray<float2> vertices, ref int vertexCount, ref NativeArray<int> indices, ref int indexCount, ref float maxArea); // 0x000000018235A8D0-0x000000018235AED0
	}
}
