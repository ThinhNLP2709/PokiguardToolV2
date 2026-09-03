/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Jobs;
using Unity.Profiling;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.TextCore.LowLevel;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;
using UnityEngine.UIElements.UIR;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal class ATGTextJobSystem // TypeDefIndex: 4824
	{
		// Fields
		private GCHandle textJobDatasHandle; // 0x10
		private List<ManagedJobData> textJobDatas; // 0x18
		private bool hasPendingTextWork; // 0x20
		private static readonly ObjectPool<ManagedJobData> s_JobDataPool; // 0x00
		private static ObjectPool<Dictionary<EntityId, HashSet<uint>>> s_AggregatedMissingGlyphsPool; // 0x08
		internal MeshGenerationCallback m_GenerateTextJobifiedCallback; // 0x28
		internal MeshGenerationCallback m_PopulateGlyphsCallback; // 0x30
		internal MeshGenerationCallback m_AddDrawEntriesCallback; // 0x38
		private static readonly ProfilerMarker k_GenerateTextMarker; // 0x10
		private static readonly ProfilerMarker k_ATGTextJobMarker; // 0x18
		private static readonly ProfilerMarker k_PrepareShapingMarker; // 0x20
		private static readonly bool k_IsMultiThreaded; // 0x28
		private List<TextElement> m_PrepareShapingDataList; // 0x40
		private static List<uint> s_GlyphsToAddBuffer; // 0x30
		private static List<NativeTextInfo> s_TextInfoBuffer; // 0x38
	
		// Nested types
		private class ManagedJobData // TypeDefIndex: 4825
		{
			// Fields
			public TextElement textElement; // 0x10
			public MeshGenerationNode node; // 0x18
			public NativeTextInfo textInfo; // 0x20
			public bool success; // 0x38
			public List<Texture2D> atlases; // 0x40
			public List<float> sdfScales; // 0x48
			public List<NativeSlice<Vertex>> vertices; // 0x50
			public List<NativeSlice<ushort>> indices; // 0x58
			public List<GlyphRenderMode> renderModes; // 0x60
			public List<List<List<int>>> textElementIndicesByMesh; // 0x68
			public UIRQuadMap uirQuadMap; // 0x70
			public Dictionary<EntityId, HashSet<uint>> missingGlyphsPerFontAsset; // 0x78
			public bool hasMissingGlyphs; // 0x80
	
			// Constructors
			public ManagedJobData(); // 0x00000001823B8000-0x00000001823B8260
	
			// Methods
			public void Clear(); // 0x00000001823B7C90-0x00000001823B8000
		}
	
		private struct PrepareShapingJob : IJobFor // TypeDefIndex: 4826
		{
			// Fields
			public GCHandle managedJobDataHandle; // 0x00
	
			// Methods
			public void Execute(int index); // 0x00000001823B83F0-0x00000001823B86A0
		}
	
		private struct GenerateTextJobData : IJobFor // TypeDefIndex: 4827
		{
			// Fields
			public GCHandle managedJobDataHandle; // 0x00
			[ReadOnly]
			public TempMeshAllocator alloc; // 0x08
	
			// Methods
			public void Execute(int index); // 0x00000001823B77F0-0x00000001823B7AC0
		}
	
		private struct ConvertToUIRVertexJobData : IJobFor // TypeDefIndex: 4828
		{
			// Fields
			public GCHandle managedJobDataHandle; // 0x00
			[ReadOnly]
			public TempMeshAllocator alloc; // 0x08
	
			// Methods
			public void Execute(int index); // 0x00000001823B7710-0x00000001823B77F0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4829
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x00000001823C8BA0-0x00000001823C8C10
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal ManagedJobData _.cctor_b__28_0(); // 0x00000001823C8920-0x00000001823C8970
			internal void _.cctor_b__28_1(ManagedJobData inst); // 0x00000001823C8970-0x00000001823C8990
			internal Dictionary<EntityId, HashSet<uint>> _.cctor_b__28_2(); // 0x00000001823C8990-0x00000001823C89F0
			internal void _.cctor_b__28_3(Dictionary<EntityId, HashSet<uint>> dict); // 0x00000001823C89F0-0x00000001823C8AF0
		}
	
		// Constructors
		public ATGTextJobSystem(); // 0x00000001823B7580-0x00000001823B7710
		static ATGTextJobSystem(); // 0x00000001823B7140-0x00000001823B7580
	
		// Methods
		private static bool PrepareTextElementForJobsOnMainThread(TextElement textElement); // 0x00000001823B60D0-0x00000001823B61E0
		internal void PrepareShapingBeforeLayout(BaseVisualElementPanel panel); // 0x00000001823B5CA0-0x00000001823B60D0
		internal void SyncAndClearNativeMeasurePointers(); // 0x00000001823B7020-0x00000001823B7140
		public void GenerateText(MeshGenerationContext mgc, TextElement textElement); // 0x00000001823B5080-0x00000001823B5220
		private void GenerateTextJobified(MeshGenerationContext mgc, object _); // 0x00000001823B4D80-0x00000001823B5080
		private void PopulateGlyphs(MeshGenerationContext mgc, object _); // 0x00000001823B5220-0x00000001823B5CA0
		private void AddDrawEntries(MeshGenerationContext mgc, object _); // 0x00000001823B4900-0x00000001823B4D80
		private static void ProcessAndConvertToUIR(ManagedJobData jobData, TempMeshAllocator alloc); // 0x00000001823B61E0-0x00000001823B7020
	}
}
