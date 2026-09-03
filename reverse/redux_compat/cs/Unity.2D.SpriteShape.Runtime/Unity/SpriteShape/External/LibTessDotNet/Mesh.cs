/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 24: Unity.2D.SpriteShape.Runtime.dll - Assembly: Unity.2D.SpriteShape.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13957-14022

namespace Unity.SpriteShape.External.LibTessDotNet
{
	internal class Mesh : MeshUtils.Pooled<Mesh> // TypeDefIndex: 13964
	{
		// Fields
		internal MeshUtils.Vertex _vHead; // 0x10
		internal MeshUtils.Face _fHead; // 0x18
		internal MeshUtils.Edge _eHead; // 0x20
		internal MeshUtils.Edge _eHeadSym; // 0x28
	
		// Constructors
		public Mesh(); // 0x0000000181C46280-0x0000000181C46580
	
		// Methods
		[RuntimeInitializeOnLoadMethod]
		private static void InitializeStack(); // 0x0000000181C45530-0x0000000181C455C0
		public override void Reset(); // 0x0000000181C459D0-0x0000000181C45A30
		public override void OnFree(); // 0x0000000181C458D0-0x0000000181C459D0
		public MeshUtils.Edge MakeEdge(); // 0x0000000181C455C0-0x0000000181C45630
		public void Splice(MeshUtils.Edge eOrg, MeshUtils.Edge eDst); // 0x0000000181C45A30-0x0000000181C45BA0
		public void Delete(MeshUtils.Edge eDel); // 0x0000000181C452B0-0x0000000181C45530
		public MeshUtils.Edge AddEdgeVertex(MeshUtils.Edge eOrg); // 0x0000000181C44EA0-0x0000000181C44FE0
		public MeshUtils.Edge SplitEdge(MeshUtils.Edge eOrg); // 0x0000000181C45BA0-0x0000000181C45E90
		public MeshUtils.Edge Connect(MeshUtils.Edge eOrg, MeshUtils.Edge eDst); // 0x0000000181C45090-0x0000000181C452B0
		public void ZapFace(MeshUtils.Face fZap); // 0x0000000181C45E90-0x0000000181C46280
		public void MergeConvexFaces(int maxVertsPerFace); // 0x0000000181C45630-0x0000000181C458D0
		[Conditional("DEBUG")]
		public void Check(); // 0x0000000181C44FE0-0x0000000181C45090
	}
}
