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
	internal struct Refinery // TypeDefIndex: 14960
	{
		// Fields
		private static readonly float kMinAreaFactor; // 0x00
		private static readonly float kMaxAreaFactor; // 0x04
		private static readonly int kMaxSteinerCount; // 0x08
	
		// Constructors
		static Refinery(); // 0x0000000181C39FB0-0x0000000181C3A020
	
		// Methods
		private static bool RequiresRefining(UTriangle tri, float maxArea); // 0x0000000181C39DB0-0x0000000181C39DC0
		private static void FetchEncroachedSegments(NativeArray<float2> pgPoints, int pgPointCount, NativeArray<int2> pgEdges, int pgEdgeCount, ref Array<UEncroachingSegment> encroach, ref int encroachCount, UCircle c); // 0x0000000181C39AF0-0x0000000181C39D90
		private static void InsertVertex(ref NativeArray<float2> pgPoints, ref int pgPointCount, float2 newVertex, ref int nid); // 0x0000000181C39D90-0x0000000181C39DB0
		private static void SplitSegments(ref NativeArray<float2> pgPoints, ref int pgPointCount, ref NativeArray<int2> pgEdges, ref int pgEdgeCount, UEncroachingSegment es); // 0x0000000181C39DC0-0x0000000181C39FB0
		internal static bool Condition(Allocator allocator, float factorArea, float targetArea, ref NativeArray<float2> pgPoints, ref int pgPointCount, ref NativeArray<int2> pgEdges, ref int pgEdgeCount, ref NativeArray<float2> vertices, ref int vertexCount, ref NativeArray<int> indices, ref int indexCount, ref float maxArea); // 0x0000000181C394F0-0x0000000181C39AF0
	}
}
