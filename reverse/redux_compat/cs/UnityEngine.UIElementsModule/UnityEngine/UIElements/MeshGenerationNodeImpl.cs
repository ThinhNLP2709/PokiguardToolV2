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
	internal class MeshGenerationNodeImpl : IDisposable // TypeDefIndex: 4327
	{
		// Fields
		private GCHandle m_SelfHandle; // 0x10
		private Entry m_ParentEntry; // 0x18
		private EntryRecorder m_EntryRecorder; // 0x20
		[CompilerGenerated]
		private bool _disposed_k__BackingField; // 0x28
	
		// Properties
		protected bool disposed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180327270-0x0000000180327280 0x00000001804AE490-0x00000001804AE4A0
	
		// Constructors
		public MeshGenerationNodeImpl(); // 0x00000001824D6E70-0x00000001824D6EA0
	
		// Methods
		public void Init(Entry parentEntry, EntryRecorder entryRecorder, bool safe); // 0x00000001824D6D30-0x00000001824D6DE0
		public void Reset(); // 0x00000001824D6DE0-0x00000001824D6E70
		public void GetNode(out MeshGenerationNode node); // 0x00000001824D6D20-0x00000001824D6D30
		public void GetUnsafeNode(out UnsafeMeshGenerationNode node); // 0x00000001824D6D20-0x00000001824D6D30
		public Entry GetParentEntry(); // 0x00000001802F8EC0-0x00000001802F8ED0
		public void DrawMesh(NativeSlice<Vertex> vertices, NativeSlice<ushort> indices, Texture texture = null, TextureOptions textureOptions = TextureOptions.None /* Metadata: 0x00660717 */, DrawPhase phase = DrawPhase.Content /* Metadata: 0x00660718 */); // 0x00000001824D6C20-0x00000001824D6CA0
		public void DrawMesh(NativeSlice<Vertex> vertices, NativeSlice<ushort> indices, Texture texture, TextureOptions textureOptions, int userData); // 0x00000001824D6CA0-0x00000001824D6D20
		public void DrawGradients(NativeSlice<Vertex> vertices, NativeSlice<ushort> indices, VectorImage gradientsOwner, DrawPhase phase = DrawPhase.Content /* Metadata: 0x00660719 */, int userData = 0 /* Metadata: 0x0066071A */); // 0x00000001824D6B40-0x00000001824D6C20
		public void Dispose(); // 0x00000001824D6AD0-0x00000001824D6B40
		protected void Dispose(bool disposing); // 0x00000001824D6A90-0x00000001824D6AD0
	}
}
