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
	internal struct Tessellator // TypeDefIndex: 15060
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
		private struct TestHullPointL : ICondition2<UHull, float2> // TypeDefIndex: 15061
		{
			// Methods
			public bool Test(UHull h, float2 p, ref float t); // 0x000000018235F5E0-0x000000018235F6D0
		}
	
		private struct TestHullPointU : ICondition2<UHull, float2> // TypeDefIndex: 15062
		{
			// Methods
			public bool Test(UHull h, float2 p, ref float t); // 0x000000018235F6D0-0x000000018235F7C0
		}
	
		private struct TestHullEventLe : ICondition2<UHull, UEvent> // TypeDefIndex: 15063
		{
			// Methods
			public bool Test(UHull h, UEvent p, ref float t); // 0x000000018235F570-0x000000018235F5E0
		}
	
		private struct TestHullEventE : ICondition2<UHull, UEvent> // TypeDefIndex: 15064
		{
			// Methods
			public bool Test(UHull h, UEvent p, ref float t); // 0x000000018235F4F0-0x000000018235F570
		}
	
		private struct TestEdgePointE : ICondition2<int2, int2> // TypeDefIndex: 15065
		{
			// Methods
			public bool Test(int2 h, int2 p, ref float t); // 0x0000000181C3F1D0-0x0000000181C3F210
		}
	
		private struct TestCellE : ICondition2<int3, int3> // TypeDefIndex: 15066
		{
			// Methods
			public bool Test(int3 h, int3 p, ref float t); // 0x0000000181C3F150-0x0000000181C3F1D0
		}
	
		// Methods
		private static float FindSplit(UHull hull, UEvent edge); // 0x000000018235D6C0-0x000000018235D930
		private void SetAllocator(Allocator allocator); // 0x00000001806342C0-0x00000001806342D0
		private bool AddPoint(NativeArray<UHull> hulls, int hullCount, NativeArray<float2> points, float2 p, int idx); // 0x000000018235C260-0x000000018235C670
		private static void InsertHull(NativeArray<UHull> Hulls, int Pos, ref int Count, UHull Value); // 0x0000000181C3D330-0x0000000181C3D3F0
		private static void EraseHull(NativeArray<UHull> Hulls, int Pos, ref int Count); // 0x0000000181C3CAE0-0x0000000181C3CB50
		private bool SplitHulls(NativeArray<UHull> hulls, ref int hullCount, NativeArray<float2> points, UEvent evt); // 0x000000018235E560-0x000000018235E910
		private bool MergeHulls(NativeArray<UHull> hulls, ref int hullCount, NativeArray<float2> points, UEvent evt); // 0x000000018235DD10-0x000000018235DF70
		private static void InsertUniqueEdge(NativeArray<int2> edges, int2 e, ref int edgeCount); // 0x0000000181C3D3F0-0x0000000181C3D480
		private void PrepareDelaunay(NativeArray<int2> edges, int edgeCount); // 0x000000018235DF70-0x000000018235E410
		private int OppositeOf(int a, int b); // 0x0000000181C3D6E0-0x0000000181C3D7A0
		private int FindConstraint(int a, int b); // 0x000000018235D530-0x000000018235D5D0
		private void AddTriangle(int i, int j, int k); // 0x0000000181C3B970-0x0000000181C3BB10
		private void RemovePair(int r, int j, int k); // 0x0000000181C3DEE0-0x0000000181C3E010
		private void RemoveTriangle(int i, int j, int k); // 0x0000000181C3E010-0x0000000181C3E090
		private void EdgeFlip(int i, int j); // 0x0000000181C3C9D0-0x0000000181C3CAE0
		private bool Flip(NativeArray<float2> points, ref Array<int> stack, ref int stackCount, int a, int b, int x); // 0x000000018235D930-0x000000018235DB60
		private Array<int3> GetCells(ref int count); // 0x000000018235DB60-0x000000018235DD10
		internal bool ApplyDelaunay(NativeArray<float2> points, NativeArray<int2> edges); // 0x000000018235C670-0x000000018235CD30
		private int FindNeighbor(Array<int3> cells, int count, int a, int b, int c); // 0x000000018235D5D0-0x000000018235D6C0
		private Array<int3> Constrain(ref int count); // 0x000000018235CE70-0x000000018235D530
		internal NativeArray<int3> RemoveExterior(ref int cellCount); // 0x000000018235E410-0x000000018235E560
		internal bool Triangulate(NativeArray<float2> points, int pointCount, NativeArray<int2> edges, int edgeCount); // 0x000000018235ED70-0x000000018235F4F0
		internal static bool Tessellate(Allocator allocator, NativeArray<float2> pgPoints, int pgPointCount, NativeArray<int2> pgEdges, int pgEdgeCount, ref NativeArray<float2> outputVertices, ref int vertexCount, ref NativeArray<int> outputIndices, ref int indexCount); // 0x000000018235E910-0x000000018235ED70
		internal void Cleanup(); // 0x000000018235CD30-0x000000018235CE70
	}
}
