/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	internal class MeshGizmo : IDisposable // TypeDefIndex: 5785
	{
		// Fields
		public static readonly int vertexCountPerCube; // 0x00
		public Mesh mesh; // 0x10
		private List<Vector3> vertices; // 0x18
		private List<int> indices; // 0x20
		private List<Color> colors; // 0x28
		private Material wireMaterial; // 0x30
		private Material dottedWireMaterial; // 0x38
		private Material solidMaterial; // 0x40
	
		// Nested types
		[CompilerGenerated]
		private struct __c__DisplayClass10_0 // TypeDefIndex: 5786
		{
			// Fields
			public MeshGizmo __4__this; // 0x00
			public Color color; // 0x08
		}
	
		// Constructors
		public MeshGizmo(int capacity = 0 /* Metadata: 0x00661B11 */); // 0x0000000181EC2F60-0x0000000181EC30E0
		static MeshGizmo(); // 0x0000000181EC2F20-0x0000000181EC2F60
	
		// Methods
		public void Clear(); // 0x0000000181EC27F0-0x0000000181EC2840
		public void AddWireCube(Vector3 center, Vector3 size, Color color); // 0x0000000181EC2000-0x0000000181EC27F0
		private void DrawMesh(Matrix4x4 trs, Material mat, MeshTopology topology, CompareFunction depthTest, string gizmoName); // 0x0000000181EC2890-0x0000000181EC2A70
		public void RenderWireframe(Matrix4x4 trs, CompareFunction depthTest = CompareFunction.LessEqual /* Metadata: 0x00661B12 */, string gizmoName = null); // 0x0000000181EC2A70-0x0000000181EC2C40
		public void Dispose(); // 0x0000000181EC2840-0x0000000181EC2890
		[CompilerGenerated]
		private void _AddWireCube_g__AddEdge_10_0(Vector3 p1, Vector3 p2, ref __c__DisplayClass10_0 param_00009dcf); // 0x0000000181EC2C40-0x0000000181EC2F20
	}
}
