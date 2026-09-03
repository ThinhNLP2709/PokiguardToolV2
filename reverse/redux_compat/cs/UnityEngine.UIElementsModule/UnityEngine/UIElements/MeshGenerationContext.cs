/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Jobs;
using Unity.Profiling;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.UIR;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	public class MeshGenerationContext // TypeDefIndex: 4323
	{
		// Fields
		[CompilerGenerated]
		private VisualElement _visualElement_k__BackingField; // 0x10
		[CompilerGenerated]
		private RenderData _renderData_k__BackingField; // 0x18
		private Painter2D m_Painter2D; // 0x20
		private MeshWriteDataPool m_MeshWriteDataPool; // 0x28
		private TempMeshAllocatorImpl m_Allocator; // 0x30
		private MeshGenerationDeferrer m_MeshGenerationDeferrer; // 0x38
		private MeshGenerationNodeManager m_MeshGenerationNodeManager; // 0x40
		[CompilerGenerated]
		private IMeshGenerator _meshGenerator_k__BackingField; // 0x48
		[CompilerGenerated]
		private EntryRecorder _entryRecorder_k__BackingField; // 0x50
		[CompilerGenerated]
		private Entry _parentEntry_k__BackingField; // 0x58
		private static readonly ProfilerMarker k_AllocateMarker; // 0x00
		private static readonly ProfilerMarker k_DrawVectorImageMarker; // 0x08
		[CompilerGenerated]
		private bool _disposed_k__BackingField; // 0x60
	
		// Properties
		public VisualElement visualElement { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		internal RenderData renderData { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public Painter2D painter2D { get; } // 0x00000001824D6850-0x00000001824D6A90 
		internal bool hasPainter2D { get; } // 0x00000001817D1AF0-0x00000001817D1B00 
		internal IMeshGenerator meshGenerator { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803272B0-0x00000001803272C0 0x00000001803780C0-0x00000001803780D0
		internal EntryRecorder entryRecorder { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
		internal Entry parentEntry { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F4000-0x00000001802F4010 0x00000001802F4050-0x00000001802F4060
		internal bool disposed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D4F0-0x000000018033D500 0x000000018033EA80-0x000000018033EA90
	
		// Nested types
		[Flags]
		internal enum MeshFlags // TypeDefIndex: 4324
		{
			None = 0,
			SkipDynamicAtlas = 2,
			IsUsingVectorImageGradients = 4,
			SliceTiled = 8
		}
	
		// Constructors
		internal MeshGenerationContext(MeshWriteDataPool meshWriteDataPool, EntryRecorder entryRecorder, TempMeshAllocatorImpl allocator, MeshGenerationDeferrer meshGenerationDeferrer, MeshGenerationNodeManager meshGenerationNodeManager); // 0x00000001824D6770-0x00000001824D6850
		static MeshGenerationContext(); // 0x00000001824D66C0-0x00000001824D6770
	
		// Methods
		public void AllocateTempMesh(int vertexCount, int indexCount, out NativeSlice<Vertex> vertices, out NativeSlice<ushort> indices); // 0x00000001824D6060-0x00000001824D6090
		public void GetTempMeshAllocator(out TempMeshAllocator allocator); // 0x00000001824D65E0-0x00000001824D6600
		public void InsertMeshGenerationNode(out MeshGenerationNode node); // 0x00000001824D6600-0x00000001824D6660
		internal void InsertUnsafeMeshGenerationNode(out UnsafeMeshGenerationNode node); // 0x00000001824D6660-0x00000001824D66C0
		public void AddMeshGenerationJob(JobHandle jobHandle); // 0x00000001824D6030-0x00000001824D6060
		internal void AddMeshGenerationCallback(MeshGenerationCallback callback, object userData, MeshGenerationCallbackType callbackType, bool isJobDependent); // 0x00000001824D6000-0x00000001824D6030
		internal void Begin(Entry parentEntry, VisualElement ve, RenderData renderData); // 0x00000001824D6090-0x00000001824D6230
		internal void End(); // 0x00000001824D6500-0x00000001824D65E0
		internal void Dispose(); // 0x00000001824D6230-0x00000001824D63B0
		private void Dispose(bool disposing); // 0x00000001824D63B0-0x00000001824D6500
	}
}
