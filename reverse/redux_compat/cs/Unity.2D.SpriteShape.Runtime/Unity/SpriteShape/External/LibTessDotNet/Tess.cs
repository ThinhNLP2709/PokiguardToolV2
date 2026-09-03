/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 24: Unity.2D.SpriteShape.Runtime.dll - Assembly: Unity.2D.SpriteShape.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13957-14022

namespace Unity.SpriteShape.External.LibTessDotNet
{
	internal class Tess // TypeDefIndex: 13978
	{
		// Fields
		private Mesh _mesh; // 0x10
		private Vec3 _normal; // 0x18
		private Vec3 _sUnit; // 0x24
		private Vec3 _tUnit; // 0x30
		private float _bminX; // 0x3C
		private float _bminY; // 0x40
		private float _bmaxX; // 0x44
		private float _bmaxY; // 0x48
		private WindingRule _windingRule; // 0x4C
		private Dict<ActiveRegion> _dict; // 0x50
		private PriorityQueue<MeshUtils.Vertex> _pq; // 0x58
		private MeshUtils.Vertex _event; // 0x60
		private CombineCallback _combineCallback; // 0x68
		private ContourVertex[] _vertices; // 0x70
		private int _vertexCount; // 0x78
		private int[] _elements; // 0x80
		private int _elementCount; // 0x88
		public float SUnitX; // 0x8C
		public float SUnitY; // 0x90
		public float SentinelCoord; // 0x94
		public bool NoEmptyPolygons; // 0x98
		public bool UsePooling; // 0x99
	
		// Properties
		public Vec3 Normal { get; set; } // 0x00000001806CCBE0-0x00000001806CCC00 0x00000001806CCE70-0x00000001806CCE80
		public ContourVertex[] Vertices { get; } // 0x000000018033D4D0-0x000000018033D4E0 
		public int VertexCount { get; } // 0x000000018169BB50-0x000000018169BB60 
		public int[] Elements { get; } // 0x000000018033D4A0-0x000000018033D4B0 
		public int ElementCount { get; } // 0x000000018033D620-0x000000018033D630 
	
		// Nested types
		internal class ActiveRegion // TypeDefIndex: 13979
		{
			// Fields
			internal MeshUtils.Edge _eUp; // 0x10
			internal Dict<ActiveRegion> _nodeUp; // 0x18
			internal int _windingNumber; // 0x20
			internal bool _inside; // 0x24
			internal bool _sentinel; // 0x25
			internal bool _dirty; // 0x26
			internal bool _fixUpperEdge; // 0x27
	
			// Constructors
			public ActiveRegion(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		// Constructors
		public Tess(); // 0x0000000181C605F0-0x0000000181C606C0
	
		// Methods
		private ActiveRegion RegionBelow(ActiveRegion reg); // 0x0000000181C5F280-0x0000000181C5F2B0
		private ActiveRegion RegionAbove(ActiveRegion reg); // 0x0000000181C5F250-0x0000000181C5F280
		private bool EdgeLeq(ActiveRegion reg1, ActiveRegion reg2); // 0x0000000181C5D5D0-0x0000000181C5D9A0
		private void DeleteRegion(ActiveRegion reg); // 0x0000000181C5D460-0x0000000181C5D4C0
		private void FixUpperEdge(ActiveRegion reg, MeshUtils.Edge newEdge); // 0x0000000181C5DBC0-0x0000000181C5DC30
		private ActiveRegion TopLeftRegion(ActiveRegion reg); // 0x0000000181C5FEE0-0x0000000181C60020
		private ActiveRegion TopRightRegion(ActiveRegion reg); // 0x0000000181C60020-0x0000000181C60090
		private ActiveRegion AddRegionBelow(ActiveRegion regAbove, MeshUtils.Edge eNewUp); // 0x0000000181C59820-0x0000000181C59910
		private void ComputeWinding(ActiveRegion reg); // 0x0000000181C5CA90-0x0000000181C5CAF0
		private void FinishRegion(ActiveRegion reg); // 0x0000000181C5DB40-0x0000000181C5DBC0
		private MeshUtils.Edge FinishLeftRegions(ActiveRegion regFirst, ActiveRegion regLast); // 0x0000000181C5D9A0-0x0000000181C5DB40
		private void AddRightEdges(ActiveRegion regUp, MeshUtils.Edge eFirst, MeshUtils.Edge eLast, MeshUtils.Edge eTopLeft, bool cleanUp); // 0x0000000181C59910-0x0000000181C59C20
		private void SpliceMergeVertices(MeshUtils.Edge e1, MeshUtils.Edge e2); // 0x0000000181C5F670-0x0000000181C5F690
		private void VertexWeights(MeshUtils.Vertex isect, MeshUtils.Vertex org, MeshUtils.Vertex dst, out float w0, out float w1); // 0x0000000181C60090-0x0000000181C60270
		private void GetIntersectData(MeshUtils.Vertex isect, MeshUtils.Vertex orgUp, MeshUtils.Vertex dstUp, MeshUtils.Vertex orgLo, MeshUtils.Vertex dstLo); // 0x0000000181C5DC30-0x0000000181C5DFD0
		private bool CheckForRightSplice(ActiveRegion regUp); // 0x0000000181C5AA70-0x0000000181C5AD40
		private bool CheckForLeftSplice(ActiveRegion regUp); // 0x0000000181C5A7C0-0x0000000181C5AA70
		private bool CheckForIntersect(ActiveRegion regUp); // 0x0000000181C59DC0-0x0000000181C5A7C0
		private void WalkDirtyRegions(ActiveRegion regUp); // 0x0000000181C60270-0x0000000181C605F0
		private void ConnectRightVertex(ActiveRegion regUp, MeshUtils.Edge eBottomLeft); // 0x0000000181C5D140-0x0000000181C5D460
		private void ConnectLeftDegenerate(ActiveRegion regUp, MeshUtils.Vertex vEvent); // 0x0000000181C5CAF0-0x0000000181C5CCA0
		private void ConnectLeftVertex(MeshUtils.Vertex vEvent); // 0x0000000181C5CCA0-0x0000000181C5D140
		private void SweepEvent(MeshUtils.Vertex vEvent); // 0x0000000181C5F690-0x0000000181C5F7B0
		private void AddSentinel(float smin, float smax, float t); // 0x0000000181C59C20-0x0000000181C59DC0
		private void InitEdgeDict(); // 0x0000000181C5E010-0x0000000181C5E110
		private void DoneEdgeDict(); // 0x0000000181C5D530-0x0000000181C5D5D0
		private void RemoveDegenerateEdges(); // 0x0000000181C5F2B0-0x0000000181C5F430
		private void InitPriorityQ(); // 0x0000000181C5E110-0x0000000181C5E330
		private void DonePriorityQ(); // 0x000000018043AE10-0x000000018043AE30
		private void RemoveDegenerateFaces(); // 0x0000000181C5F430-0x0000000181C5F4F0
		protected void ComputeInterior(); // 0x0000000181C5AE90-0x0000000181C5C160
		private void ComputeNormal(ref Vec3 norm); // 0x0000000181C5C160-0x0000000181C5CA90
		private void CheckOrientation(); // 0x0000000181C5AD40-0x0000000181C5AE90
		private void ProjectPolygon(); // 0x0000000181C5EB10-0x0000000181C5F250
		private void TessellateMonoRegion(MeshUtils.Face face); // 0x0000000181C5F820-0x0000000181C5FC60
		private void TessellateInterior(); // 0x0000000181C5F7B0-0x0000000181C5F820
		private void DiscardExterior(); // 0x0000000181C5D4C0-0x0000000181C5D530
		private void SetWindingNumber(int value, bool keepOnlyBoundary); // 0x0000000181C5F4F0-0x0000000181C5F5E0
		private int GetNeighbourFace(MeshUtils.Edge edge); // 0x0000000181C5DFD0-0x0000000181C5E010
		private void OutputPolymesh(ElementType elementType, int polySize); // 0x0000000181C5E5F0-0x0000000181C5EB10
		private void OutputContours(); // 0x0000000181C5E330-0x0000000181C5E5F0
		private float SignedArea(ContourVertex[] vertices); // 0x0000000181C5F5E0-0x0000000181C5F670
		public void AddContour(ContourVertex[] vertices); // 0x0000000181C595B0-0x0000000181C595C0
		public void AddContour(ContourVertex[] vertices, ContourOrientation forceOrientation); // 0x0000000181C595C0-0x0000000181C59820
		public void Tessellate(WindingRule windingRule, ElementType elementType, int polySize); // 0x0000000181C5FEC0-0x0000000181C5FEE0
		public void Tessellate(WindingRule windingRule, ElementType elementType, int polySize, CombineCallback combineCallback); // 0x0000000181C5FC60-0x0000000181C5FEC0
	}
}
