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
	internal struct PlanarGraph // TypeDefIndex: 14959
	{
		// Fields
		private static readonly double kEpsilon; // 0x00
		private static readonly int kMaxIntersectionTolerance; // 0x08
	
		// Constructors
		static PlanarGraph(); // 0x0000000181C38760-0x0000000181C387C0
	
		// Methods
		internal static void RemoveDuplicateEdges(ref Array<int2> edges, ref int edgeCount, Array<int> duplicates, int duplicateCount); // 0x0000000181C379A0-0x0000000181C37BC0
		internal static bool CheckCollinear(double2 a0, double2 a1, double2 b0, double2 b1); // 0x0000000181C36DC0-0x0000000181C36F90
		internal static bool LineLineIntersection(double2 a0, double2 a1, double2 b0, double2 b1); // 0x0000000181C373A0-0x0000000181C37820
		internal static bool LineLineIntersection(double2 p1, double2 p2, double2 p3, double2 p4, ref double2 result); // 0x0000000181C37820-0x0000000181C379A0
		internal static bool CalculateEdgeIntersections(Array<int2> edges, int edgeCount, Array<double2> points, int pointCount, ref Array<int2> results, ref Array<double2> intersects, ref int resultCount); // 0x0000000181C36530-0x0000000181C36AF0
		internal static bool CalculateTJunctions(Array<int2> edges, int edgeCount, Array<double2> points, int pointCount, Array<int2> results, ref int resultCount); // 0x0000000181C36AF0-0x0000000181C36DC0
		internal static bool CutEdges(ref Array<double2> points, ref int pointCount, ref Array<int2> edges, ref int edgeCount, ref Array<int2> tJunctions, ref int tJunctionCount, Array<int2> intersections, Array<double2> intersects, int intersectionCount); // 0x0000000181C36F90-0x0000000181C373A0
		internal static void RemoveDuplicatePoints(ref Array<double2> points, ref int pointCount, ref Array<int> duplicates, ref int duplicateCount, Allocator allocator); // 0x0000000181C37BC0-0x0000000181C38100
		internal static bool Validate(Allocator allocator, [IsReadOnly] in NativeArray<float2> inputPoints, int pointCount, [IsReadOnly] in NativeArray<int2> inputEdges, int edgeCount, ref NativeArray<float2> outputPoints, out int outputPointCount, ref NativeArray<int2> outputEdges, out int outputEdgeCount); // 0x0000000181C38100-0x0000000181C38760
	}
}
