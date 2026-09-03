/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	public struct TMP_MeshInfo // TypeDefIndex: 11862
	{
		// Fields
		private static readonly Color32 s_DefaultColor; // 0x00
		private static readonly Vector3 s_DefaultNormal; // 0x04
		private static readonly Vector4 s_DefaultTangent; // 0x10
		private static readonly Bounds s_DefaultBounds; // 0x20
		public Mesh mesh; // 0x00
		public int vertexCount; // 0x08
		public Vector3[] vertices; // 0x10
		public Vector3[] normals; // 0x18
		public Vector4[] tangents; // 0x20
		public Vector4[] uvs0; // 0x28
		public Vector2[] uvs2; // 0x30
		public Color32[] colors32; // 0x38
		public int[] triangles; // 0x40
		public Material material; // 0x48
	
		// Constructors
		public TMP_MeshInfo(Mesh mesh, int size); // 0x00000001820C6C30-0x00000001820C7290
		public TMP_MeshInfo(Mesh mesh, int size, bool isVolumetric); // 0x00000001820C7290-0x00000001820C7D80
		static TMP_MeshInfo(); // 0x00000001820C6B90-0x00000001820C6C30
	
		// Methods
		public void ResizeMeshInfo(int size); // 0x00000001820C5110-0x00000001820C5620
		public void ResizeMeshInfo(int size, bool isVolumetric); // 0x00000001820C5620-0x00000001820C6180
		public void Clear(); // 0x00000001820C4F10-0x00000001820C4FC0
		public void Clear(bool uploadChanges); // 0x00000001820C4FC0-0x00000001820C5110
		public void ClearUnusedVertices(); // 0x00000001820C4ED0-0x00000001820C4F10
		public void ClearUnusedVertices(int startIndex); // 0x00000001820C4DE0-0x00000001820C4E20
		public void ClearUnusedVertices(int startIndex, bool updateMesh); // 0x00000001820C4E20-0x00000001820C4ED0
		public void SortGeometry(VertexSortingOrder order); // 0x00000001820C6180-0x00000001820C6240
		public void SortGeometry(IList<int> sortingOrder); // 0x00000001820C6240-0x00000001820C63E0
		public void SwapVertexData(int src, int dst); // 0x00000001820C63E0-0x00000001820C6B90
	}
}
