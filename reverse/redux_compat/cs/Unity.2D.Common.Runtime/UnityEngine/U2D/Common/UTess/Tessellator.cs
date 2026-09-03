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
	internal struct Tessellator // TypeDefIndex: 14962
	{
		// Fields
		private NativeArray<int2> m_Edges; // 0x00
		private NativeArray<UStar> m_Stars; // 0x10
		private Array<int3> m_Cells; // 0x20
		private int m_CellCount; // 0x40
		private NativeArray<int> m_ILArray; // 0x48
		private NativeArray<int> m_IUArray; // 0x58
		private NativeArray<int> m_SPArray; // 0x68
		private int m_NumEdges; // 0x78
		private int m_NumHulls; // 0x7C
		private int m_NumPoints; // 0x80
		private int m_StarCount; // 0x84
		private NativeArray<int> m_Flags; // 0x88
		private NativeArray<int> m_Neighbors; // 0x98
		private NativeArray<int> m_Constraints; // 0xA8
		private Allocator m_Allocator; // 0xB8
	
		// Nested types
		private struct TestHullPointL : ICondition2<UHull, float2> // TypeDefIndex: 14963
		{
			// Methods
			public bool Test(UHull h, float2 p, ref float t); // 0x0000000181C3F300-0x0000000181C3F3F0
		}
	
		private struct TestHullPointU : ICondition2<UHull, float2> // TypeDefIndex: 14964
		{
			// Methods
			public bool Test(UHull h, float2 p, ref float t); // 0x0000000181C3F3F0-0x0000000181C3F4E0
		}
	
		private struct TestHullEventLe : ICondition2<UHull, UEvent> // TypeDefIndex: 14965
		{
			// Methods
			public bool Test(UHull h, UEvent p, ref float t); // 0x0000000181C3F290-0x0000000181C3F300
		}
	
		private struct TestHullEventE : ICondition2<UHull, UEvent> // TypeDefIndex: 14966
		{
			// Methods
			public bool Test(UHull h, UEvent p, ref float t); // 0x0000000181C3F210-0x0000000181C3F290
		}
	
		private struct TestEdgePointE : ICondition2<int2, int2> // TypeDefIndex: 14967
		{
			// Methods
			public bool Test(int2 h, int2 p, ref float t); // 0x0000000181C3F1D0-0x0000000181C3F210
		}
	
		private struct TestCellE : ICondition2<int3, int3> // TypeDefIndex: 14968
		{
			// Methods
			public bool Test(int3 h, int3 p, ref float t); // 0x0000000181C3F150-0x0000000181C3F1D0
		}
	
		// Methods
		private static float FindSplit(UHull hull, UEvent edge); // 0x0000000181C3CCE0-0x0000000181C3CF50
		private void SetAllocator(Allocator allocator); // 0x00000001806342C0-0x00000001806342D0
		private bool AddPoint(NativeArray<UHull> hulls, int hullCount, NativeArray<float2> points, float2 p, int idx); // 0x0000000181C3B560-0x0000000181C3B970
		private static void InsertHull(NativeArray<UHull> Hulls, int Pos, ref int Count, UHull Value); // 0x0000000181C3D330-0x0000000181C3D3F0
		private static void EraseHull(NativeArray<UHull> Hulls, int Pos, ref int Count); // 0x0000000181C3CAE0-0x0000000181C3CB50
		private bool SplitHulls(NativeArray<UHull> hulls, ref int hullCount, NativeArray<float2> points, UEvent evt); // 0x0000000181C3E090-0x0000000181C3E440
		private bool MergeHulls(NativeArray<UHull> hulls, ref int hullCount, NativeArray<float2> points, UEvent evt); // 0x0000000181C3D480-0x0000000181C3D6E0
		private static void InsertUniqueEdge(NativeArray<int2> edges, int2 e, ref int edgeCount); // 0x0000000181C3D3F0-0x0000000181C3D480
		private void PrepareDelaunay(NativeArray<int2> edges, int edgeCount); // 0x0000000181C3D7A0-0x0000000181C3DC40
		private int OppositeOf(int a, int b); // 0x0000000181C3D6E0-0x0000000181C3D7A0
		private int FindConstraint(int a, int b); // 0x0000000181C3CB50-0x0000000181C3CBF0
		private void AddTriangle(int i, int j, int k); // 0x0000000181C3B970-0x0000000181C3BB10
		private void RemovePair(int r, int j, int k); // 0x0000000181C3DEE0-0x0000000181C3E010
		private void RemoveTriangle(int i, int j, int k); // 0x0000000181C3E010-0x0000000181C3E090
		private void EdgeFlip(int i, int j); // 0x0000000181C3C9D0-0x0000000181C3CAE0
		private bool Flip(NativeArray<float2> points, ref Array<int> stack, ref int stackCount, int a, int b, int x); // 0x0000000181C3CF50-0x0000000181C3D180
		private Array<int3> GetCells(ref int count); // 0x0000000181C3D180-0x0000000181C3D330
		internal bool ApplyDelaunay(NativeArray<float2> points, NativeArray<int2> edges); // 0x0000000181C3BB10-0x0000000181C3C1D0
		private int FindNeighbor(Array<int3> cells, int count, int a, int b, int c); // 0x0000000181C3CBF0-0x0000000181C3CCE0
		private Array<int3> Constrain(ref int count); // 0x0000000181C3C310-0x0000000181C3C9D0
		internal NativeArray<int3> RemoveExterior(ref int cellCount); // 0x0000000181C3DC40-0x0000000181C3DD90
		internal NativeArray<int3> RemoveInterior(ref int cellCount); // 0x0000000181C3DD90-0x0000000181C3DEE0
		internal bool Triangulate(NativeArray<float2> points, int pointCount, NativeArray<int2> edges, int edgeCount); // 0x0000000181C3E9D0-0x0000000181C3F150
		internal static bool Tessellate(Allocator allocator, NativeArray<float2> pgPoints, int pgPointCount, NativeArray<int2> pgEdges, int pgEdgeCount, ref NativeArray<float2> outputVertices, ref int vertexCount, ref NativeArray<int> outputIndices, ref int indexCount); // 0x0000000181C3E780-0x0000000181C3E9D0
		internal static bool TessellateMainThread(Allocator allocator, ref NativeArray<float2> pgPoints, ref NativeArray<int2> pgEdges, out NativeArray<float2> outputVertices, out NativeArray<int> outputIndices); // 0x0000000181C3E440-0x0000000181C3E780
		internal void Cleanup(); // 0x0000000181C3C1D0-0x0000000181C3C310
	}
}
