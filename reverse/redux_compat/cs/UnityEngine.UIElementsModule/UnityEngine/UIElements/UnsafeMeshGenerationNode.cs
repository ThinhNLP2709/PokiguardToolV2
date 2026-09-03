/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.UIR;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal struct UnsafeMeshGenerationNode // TypeDefIndex: 4326
	{
		// Fields
		private GCHandle m_Handle; // 0x00
	
		// Methods
		private MeshGenerationNodeImpl GetManaged(); // 0x00000001824E2E30-0x00000001824E2EB0
		internal static void Create(GCHandle handle, out UnsafeMeshGenerationNode node); // 0x00000001824D7560-0x00000001824D7570
		public void DrawMesh(NativeSlice<Vertex> vertices, NativeSlice<ushort> indices, Texture texture = null, TextureOptions textureOptions = TextureOptions.None /* Metadata: 0x00660713 */, DrawPhase phase = DrawPhase.Content /* Metadata: 0x00660714 */); // 0x00000001824E2CB0-0x00000001824E2D70
		public void DrawMesh(NativeSlice<Vertex> vertices, NativeSlice<ushort> indices, Texture texture, TextureOptions textureOptions, int userData); // 0x00000001824E2D70-0x00000001824E2E30
		internal void DrawGradientsInternal(NativeSlice<Vertex> vertices, NativeSlice<ushort> indices, VectorImage gradientsOwner, DrawPhase phase = DrawPhase.Content /* Metadata: 0x00660715 */, int userData = 0 /* Metadata: 0x00660716 */); // 0x00000001824E2B90-0x00000001824E2CB0
		internal Entry GetParentEntry(); // 0x00000001824D7570-0x00000001824D7590
	}
}
