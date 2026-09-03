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
	internal struct PlanarGraph // TypeDefIndex: 15057
	{
		// Fields
		private static readonly double kEpsilon; // 0x00
		private static readonly int kMaxIntersectionTolerance; // 0x08
	
		// Constructors
		static PlanarGraph(); // 0x000000018235A870-0x000000018235A8D0
	
		// Methods
		internal static void RemoveDuplicateEdges(ref Array<int2> edges, ref int edgeCount, Array<int> duplicates, int duplicateCount); // 0x0000000182359AD0-0x0000000182359CD0
		internal static bool CheckCollinear(double2 a0, double2 a1, double2 b0, double2 b1); // 0x0000000182358EF0-0x00000001823590C0
		internal static bool LineLineIntersection(double2 a0, double2 a1, double2 b0, double2 b1); // 0x00000001823594D0-0x0000000182359950
		internal static bool LineLineIntersection(double2 p1, double2 p2, double2 p3, double2 p4, ref double2 result); // 0x0000000182359950-0x0000000182359AD0
		internal static bool CalculateEdgeIntersections(Array<int2> edges, int edgeCount, Array<double2> points, int pointCount, ref Array<int2> results, ref Array<double2> intersects, ref int resultCount); // 0x0000000182358660-0x0000000182358C20
		internal static bool CalculateTJunctions(Array<int2> edges, int edgeCount, Array<double2> points, int pointCount, Array<int2> results, ref int resultCount); // 0x0000000182358C20-0x0000000182358EF0
		internal static bool CutEdges(ref Array<double2> points, ref int pointCount, ref Array<int2> edges, ref int edgeCount, ref Array<int2> tJunctions, ref int tJunctionCount, Array<int2> intersections, Array<double2> intersects, int intersectionCount); // 0x00000001823590C0-0x00000001823594D0
		internal static void RemoveDuplicatePoints(ref Array<double2> points, ref int pointCount, ref Array<int> duplicates, ref int duplicateCount, Allocator allocator); // 0x0000000182359CD0-0x000000018235A210
		internal static bool Validate(Allocator allocator, [IsReadOnly] in NativeArray<float2> inputPoints, int pointCount, [IsReadOnly] in NativeArray<int2> inputEdges, int edgeCount, ref NativeArray<float2> outputPoints, out int outputPointCount, ref NativeArray<int2> outputEdges, out int outputEdgeCount); // 0x000000018235A210-0x000000018235A870
	}
}
