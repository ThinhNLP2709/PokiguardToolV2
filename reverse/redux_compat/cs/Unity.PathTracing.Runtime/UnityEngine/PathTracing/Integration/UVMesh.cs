/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Integration
{
	internal class UVMesh : IDisposable // TypeDefIndex: 13560
	{
		// Fields
		public Mesh Mesh; // 0x10
		public float UVAspectRatio; // 0x18
	
		// Nested types
		private struct OutputVertex // TypeDefIndex: 13561
		{
			// Fields
			public Vector3 Position; // 0x00
		}
	
		// Constructors
		public UVMesh(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void Dispose(); // 0x0000000181E009C0-0x0000000181E00A10
		public bool Build(Mesh mesh); // 0x0000000181E002A0-0x0000000181E004F0
		private static bool Build(Mesh.MeshData outputMesh, Mesh.MeshData inputMesh, NativeArray<Vector2> tmpVtxArray0, out float uvAspectRatio); // 0x0000000181E004F0-0x0000000181E009C0
	}
}
