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
	internal class UITKTextJobSystem // TypeDefIndex: 4842
	{
		// Fields
		private static readonly ProfilerMarker k_ExecuteMarker; // 0x00
		private static readonly ProfilerMarker k_UpdateMainThreadMarker; // 0x08
		private static readonly ProfilerMarker k_PrepareMainThreadMarker; // 0x10
		private static readonly ProfilerMarker k_PrepareJobifiedMarker; // 0x18
		private GCHandle textJobDatasHandle; // 0x10
		private List<ManagedJobData> textJobDatas; // 0x18
		private bool hasPendingTextWork; // 0x20
		private static ObjectPool<ManagedJobData> s_JobDataPool; // 0x20
		private static ObjectPool<List<Material>> s_MaterialsPool; // 0x28
		private static ObjectPool<List<GlyphRenderMode>> s_RenderModesPool; // 0x30
		private static ObjectPool<List<NativeSlice<Vertex>>> s_VerticesPool; // 0x38
		private static ObjectPool<List<NativeSlice<ushort>>> s_IndicesPool; // 0x40
		internal MeshGenerationCallback m_PrepareTextJobifiedCallback; // 0x28
		internal MeshGenerationCallback m_GenerateTextJobifiedCallback; // 0x30
		internal MeshGenerationCallback m_AddDrawEntriesCallback; // 0x38
	
		// Nested types
		private class ManagedJobData // TypeDefIndex: 4843
		{
			// Fields
			public TextElement visualElement; // 0x10
			public MeshGenerationNode node; // 0x18
			public List<Material> materials; // 0x20
			public List<GlyphRenderMode> renderModes; // 0x28
			public List<NativeSlice<Vertex>> vertices; // 0x30
			public List<NativeSlice<ushort>> indices; // 0x38
			public bool prepareSuccess; // 0x40
	
			// Constructors
			public ManagedJobData(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public void Release(); // 0x00000001823CEDA0-0x00000001823CEF10
		}
	
		private struct PrepareTextJobData : IJobParallelFor // TypeDefIndex: 4844
		{
			// Fields
			public GCHandle managedJobDataHandle; // 0x00
	
			// Methods
			public void Execute(int index); // 0x00000001823CF080-0x00000001823CF250
		}
	
		private struct GenerateTextJobData : IJobParallelFor // TypeDefIndex: 4845
		{
			// Fields
			public GCHandle managedJobDataHandle; // 0x00
			[ReadOnly]
			public TempMeshAllocator alloc; // 0x08
	
			// Methods
			public void Execute(int index); // 0x00000001823CE3D0-0x00000001823CE6B0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4846
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x00000001823D3A60-0x00000001823D3AD0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal ManagedJobData _.cctor_b__25_0(); // 0x00000001823D3520-0x00000001823D3570
			internal void _.cctor_b__25_1(ManagedJobData inst); // 0x00000001823D3570-0x00000001823D35A0
			internal List<Material> _.cctor_b__25_2(); // 0x00000001823D35A0-0x00000001823D3600
			internal void _.cctor_b__25_3(List<Material> list); // 0x00000001823D3600-0x00000001823D3640
			internal List<GlyphRenderMode> _.cctor_b__25_4(); // 0x00000001823D3640-0x00000001823D36A0
			internal void _.cctor_b__25_5(List<GlyphRenderMode> list); // 0x00000001823D36A0-0x00000001823D36C0
			internal List<NativeSlice<Vertex>> _.cctor_b__25_6(); // 0x00000001823D36C0-0x00000001823D3720
			internal void _.cctor_b__25_7(List<NativeSlice<Vertex>> list); // 0x00000001823D36A0-0x00000001823D36C0
			internal List<NativeSlice<ushort>> _.cctor_b__25_8(); // 0x00000001823D3720-0x00000001823D3780
			internal void _.cctor_b__25_9(List<NativeSlice<ushort>> list); // 0x00000001823D36A0-0x00000001823D36C0
		}
	
		// Constructors
		public UITKTextJobSystem(); // 0x00000001823DF590-0x00000001823DF6E0
		static UITKTextJobSystem(); // 0x00000001823DEE40-0x00000001823DF590
	
		// Methods
		private static void OnGetManagedJob(ManagedJobData managedJobData); // 0x00000001823DEB90-0x00000001823DEC00
		internal void GenerateText(MeshGenerationContext mgc, TextElement textElement); // 0x00000001823DEA00-0x00000001823DEB90
		internal void PrepareTextJobified(MeshGenerationContext mgc, object _); // 0x00000001823DEC00-0x00000001823DEE40
		private void GenerateTextJobified(MeshGenerationContext mgc, object _); // 0x00000001823DE550-0x00000001823DEA00
		private static void ConvertMeshInfoToUIRVertex(MeshInfo[] meshInfos, TempMeshAllocator alloc, TextElement visualElement, ref List<Material> materials, ref List<NativeSlice<Vertex>> verticesArray, ref List<NativeSlice<ushort>> indicesArray, ref List<GlyphRenderMode> renderModes); // 0x00000001823DD6F0-0x00000001823DE550
		private void AddDrawEntries(MeshGenerationContext mgc, object _); // 0x00000001823DD300-0x00000001823DD6F0
	}
}
