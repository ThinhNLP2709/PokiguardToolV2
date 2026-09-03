/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI
{
	public class VertexHelper : IDisposable // TypeDefIndex: 13138
	{
		// Fields
		private NativeArray<UIVertex> m_Verts; // 0x10
		private NativeArray<ushort> m_Indices; // 0x20
		private int m_VertCount; // 0x30
		private int m_VertCapacity; // 0x34
		private int m_IndexCount; // 0x38
		private int m_IndexCapacity; // 0x3C
		private Allocator m_Allocator; // 0x40
		private const int k_InitialVertCapacity = 64; // Metadata: 0x006A77A2
		private const int k_InitialIndexCapacity = 96; // Metadata: 0x006A77A4
		private const int k_MaxVertCount = 65000; // Metadata: 0x006A77A6
		private static readonly Vector4 s_DefaultTangent; // 0x00
		private static readonly Vector3 s_DefaultNormal; // 0x10
		private static readonly VertexAttributeDescriptor[] s_VertexLayout; // 0x20
	
		// Properties
		public int currentVertCount { get; } // 0x000000018033D100-0x000000018033D110 
		public int currentIndexCount { get; } // 0x000000018047EDE0-0x000000018047EDF0 
	
		// Constructors
		public VertexHelper(); // 0x00000001825C5AE0-0x00000001825C5B00
		internal VertexHelper(Allocator allocator); // 0x00000001825C4D00-0x00000001825C4D30
		public VertexHelper(Mesh m); // 0x00000001825C4D30-0x00000001825C5AE0
		static VertexHelper(); // 0x00000001825C4A00-0x00000001825C4D00
	
		// Methods
		private void InitializeIfRequired(int vertCapacityHint = 64 /* Metadata: 0x006A779E */, int indexCapacityHint = 96 /* Metadata: 0x006A77A0 */); // 0x00000001825C4640-0x00000001825C4780
		private void EnsureVertCapacity(int needed); // 0x00000001825C41F0-0x00000001825C4280
		private void EnsureIndexCapacity(int needed); // 0x00000001825C4160-0x00000001825C41F0
		private void GrowNativeArray<T>(ref NativeArray<T> arr, int newCapacity, int liveCount)
			where T : struct;
		internal int ReserveVerts(int count); // 0x00000001825C4880-0x00000001825C48D0
		internal int ReserveIndices(int count); // 0x00000001825C4830-0x00000001825C4880
		public void Dispose(); // 0x00000001825C40F0-0x00000001825C4160
		public void Clear(); // 0x00000001825C40E0-0x00000001825C40F0
		public void PopulateUIVertex(ref UIVertex vertex, int i); // 0x00000001825C4780-0x00000001825C4830
		public void SetUIVertex(UIVertex vertex, int i); // 0x00000001825C48D0-0x00000001825C4960
		public void FillMesh(Mesh mesh); // 0x00000001825C4280-0x00000001825C4520
		public void AddVert(Vector3 position, Color32 color, Vector4 uv0, Vector4 uv1, Vector4 uv2, Vector4 uv3, Vector3 normal, Vector4 tangent, Vector4 prevPosition); // 0x00000001825C3F90-0x00000001825C40E0
		public void AddVert(Vector3 position, Color32 color, Vector4 uv0, Vector4 uv1, Vector4 uv2, Vector4 uv3, Vector3 normal, Vector4 tangent); // 0x00000001825C3E30-0x00000001825C3F90
		public void AddVert(Vector3 position, Color32 color, Vector4 uv0, Vector4 uv1, Vector3 normal, Vector4 tangent); // 0x00000001825C3C20-0x00000001825C3D90
		public void AddVert(Vector3 position, Color32 color, Vector4 uv0); // 0x00000001825C3A40-0x00000001825C3C20
		public void AddVert(UIVertex v); // 0x00000001825C3D90-0x00000001825C3E30
		public void AddTriangle(int idx0, int idx1, int idx2); // 0x00000001825C34D0-0x00000001825C3560
		public void AddUIVertexQuad(UIVertex[] verts); // 0x00000001825C3560-0x00000001825C3880
		public void AddUIVertexStream(List<UIVertex> verts, List<int> indices); // 0x00000001825C3880-0x00000001825C3980
		public void AddUIVertexTriangleStream(List<UIVertex> verts); // 0x00000001825C3980-0x00000001825C3A40
		public void GetUIVertexStream(List<UIVertex> stream); // 0x00000001825C4520-0x00000001825C4640
		[CompilerGenerated]
		internal static NativeArray<Vector4> _.ctor_g__ReadUVChannel_14_0(int channel, int vertexCount, Mesh.MeshData data); // 0x00000001825C4960-0x00000001825C4A00
	}
}
