/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Profiling;
using Unity.Properties;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class RenderTreeManager : IDisposable // TypeDefIndex: 5139
	{
		// Fields
		private readonly ElementIdPool m_ElementIdPool; // 0x10
		private readonly List<RenderData> m_ElementInfoUpdates; // 0x18
		private RenderTreeCompositor m_Compositor; // 0x20
		private VisualChangesProcessor m_VisualChangesProcessor; // 0x28
		private LinkedPool<RenderChainCommand> m_CommandPool; // 0x30
		private LinkedPool<ExtraRenderData> m_ExtraDataPool; // 0x38
		private BasicNodePool<MeshHandle> m_MeshHandleNodePool; // 0x40
		private BasicNodePool<GraphicEntry> m_GraphicEntryPool; // 0x48
		private Dictionary<RenderData, ExtraRenderData> m_ExtraData; // 0x50
		private PerGlyphTextCoreSettings m_PerGlyphTcs; // 0x58
		internal List<ElementInsertionData> m_InsertionList; // 0x60
		private MeshGenerationDeferrer m_MeshGenerationDeferrer; // 0x68
		private Material m_DefaultMat; // 0x70
		private bool m_BlockDirtyRegistration; // 0x78
		private ChainBuilderStats m_Stats; // 0x7C
		private uint m_StatsElementsRemoved; // 0xDC
		private int m_TotalVisualElements; // 0xE0
		private TextureRegistry m_TextureRegistry; // 0xE8
		private ObjectPool<RenderData> m_RenderDataPool; // 0xF0
		private ObjectPool<RenderTree> m_RenderTreePool; // 0xF8
		[CompilerGenerated]
		private TextureSlotCount _textureSlotCount_k__BackingField; // 0x100
		[NoAutoStaticsCleanup]
		private static EntryPool s_SharedEntryPool; // 0x00
		private static readonly ProfilerMarker k_MarkerProcess; // 0x08
		private static readonly ProfilerMarker k_MarkerSerialize; // 0x10
		[CompilerGenerated]
		private bool _disposed_k__BackingField; // 0x104
		private RenderTree m_RootRenderTree; // 0x108
		[CompilerGenerated]
		private BaseVisualElementPanel _panel_k__BackingField; // 0x110
		[CompilerGenerated]
		private UIRenderDevice _device_k__BackingField; // 0x118
		[CompilerGenerated]
		private AtlasBase _atlas_k__BackingField; // 0x120
		[CompilerGenerated]
		private VectorImageManager _vectorImageManager_k__BackingField; // 0x128
		[CompilerGenerated]
		private BackgroundGradientBaker _backgroundGradientBaker_k__BackingField; // 0x130
		[CompilerGenerated]
		private TempMeshAllocatorImpl _tempMeshAllocator_k__BackingField; // 0x138
		[CompilerGenerated]
		private readonly MeshWriteDataPool _meshWriteDataPool_k__BackingField; // 0x140
		public EntryRecorder entryRecorder; // 0x148
		[CompilerGenerated]
		private MeshGenerationNodeManager _meshGenerationNodeManager_k__BackingField; // 0x150
		[CompilerGenerated]
		private JobManager _jobManager_k__BackingField; // 0x158
		internal ShaderInfoAllocator shaderInfoAllocator; // 0x160
		[CompilerGenerated]
		private readonly bool _drawInCameras_k__BackingField; // 0x168
		[CompilerGenerated]
		private readonly bool _isFlat_k__BackingField; // 0x169
		[CompilerGenerated]
		private readonly bool _forceGammaRendering_k__BackingField; // 0x16A
	
		// Properties
		internal int totalVisualElements { get; } // 0x0000000181BECC10-0x0000000181BECC20 
		internal TextureRegistry textureRegistry { get; } // 0x00000001806BAE70-0x00000001806BAE80 
		internal VisualChangesProcessor visualChangesProcessor { get; } // 0x000000018033D240-0x000000018033D250 
		internal PerGlyphTextCoreSettings perGlyphTcs { get; } // 0x00000001802F4000-0x00000001802F4010 
		public TextureSlotCount textureSlotCount { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180CDD590-0x0000000180CDD5A0 0x00000001824431B0-0x00000001824431C0
		protected bool disposed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181F64840-0x0000000181F64850 0x0000000181F65070-0x0000000181F65080
		internal ref ChainBuilderStats statsByRef { get; } // 0x0000000182443120-0x0000000182443130 
		internal RenderTree rootRenderTree { set; } // 0x0000000182443130-0x00000001824431B0
		internal BaseVisualElementPanel panel { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018170B050-0x000000018170B060 0x000000018170B160-0x000000018170B180
		internal UIRenderDevice device { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018171E0D0-0x000000018171E0E0 0x0000000180504EA0-0x0000000180504EC0
		public BaseElementBuilder elementBuilder { get; } // 0x0000000181779FC0-0x0000000181779FE0 
		internal AtlasBase atlas { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018170C2D0-0x000000018170C2E0 0x0000000181380050-0x0000000181380070
		internal VectorImageManager vectorImageManager { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181CE5BD0-0x0000000181CE5BE0 0x0000000181380070-0x0000000181380090
		internal BackgroundGradientBaker backgroundGradientBaker { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181C2D460-0x0000000181C2D470 0x00000001818418A0-0x00000001818418C0
		internal TempMeshAllocatorImpl tempMeshAllocator { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181974820-0x0000000181974830 0x0000000181C4C430-0x0000000181C4C450
		internal MeshWriteDataPool meshWriteDataPool { [CompilerGenerated] get; } // 0x0000000181C0F740-0x0000000181C0F750 
		internal EntryPool entryPool { get; } // 0x00000001824430B0-0x0000000182443100 
		public MeshGenerationDeferrer meshGenerationDeferrer { get; } // 0x0000000180316960-0x0000000180316970 
		public MeshGenerationNodeManager meshGenerationNodeManager { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181C0F6E0-0x0000000181C0F6F0 0x0000000181D8A7C0-0x0000000181D8A7E0
		internal JobManager jobManager { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181F64850-0x0000000181F64860 0x00000001813800B0-0x00000001813800D0
		internal bool drawInCameras { [CompilerGenerated] get; } // 0x00000001824430A0-0x00000001824430B0 
		internal bool isFlat { [CompilerGenerated] get; } // 0x0000000182443110-0x0000000182443120 
		public bool forceGammaRendering { [CompilerGenerated] get; } // 0x0000000182443100-0x0000000182443110 
	
		// Nested types
		internal struct ElementInsertionData // TypeDefIndex: 5140
		{
			// Fields
			public VisualElement element; // 0x00
			public bool canceled; // 0x08
		}
	
		internal class VisualChangesProcessor : IDisposable // TypeDefIndex: 5141
		{
			// Fields
			private static readonly ProfilerMarker k_GenerateEntriesMarker; // 0x00
			private static readonly ProfilerMarker k_ConvertEntriesToCommandsMarker; // 0x08
			private static readonly ProfilerMarker k_MeshModifierMarker; // 0x10
			private RenderTreeManager m_RenderTreeManager; // 0x10
			private MeshGenerationContext m_MeshGenerationContext; // 0x18
			private BaseElementBuilder m_ElementBuilder; // 0x20
			private List<EntryProcessingInfo> m_EntryProcessingList; // 0x28
			private List<EntryProcessingInfo> m_ModifierEntryProcessingList; // 0x30
			private List<EntryProcessor> m_Processors; // 0x38
			private MeshModifierScheduler m_MeshModifierScheduler; // 0x40
			private readonly MeshModifierChainCache m_ChainCache; // 0x48
			[NoAutoStaticsCleanup]
			private static readonly List<MeshModifierRegistration> k_RebuildScratch; // 0x18
			[CompilerGenerated]
			private bool _disposed_k__BackingField; // 0x50
	
			// Properties
			public BaseElementBuilder elementBuilder { get; } // 0x00000001802F8630-0x00000001802F8640 
			public MeshGenerationContext meshGenerationContext { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			protected bool disposed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180377920-0x0000000180377930 0x00000001803780E0-0x00000001803780F0
	
			// Nested types
			private enum VisualsProcessingType // TypeDefIndex: 5142
			{
				Head = 0,
				Tail = 1
			}
	
			private struct EntryProcessingInfo // TypeDefIndex: 5143
			{
				// Fields
				public RenderData renderData; // 0x00
				public VisualsProcessingType type; // 0x08
				public Entry rootEntry; // 0x10
			}
	
			// Constructors
			public VisualChangesProcessor(RenderTreeManager renderTreeManager); // 0x000000018244D7C0-0x000000018244DF90
			static VisualChangesProcessor(); // 0x000000018244D670-0x000000018244D7C0
	
			// Methods
			public void ScheduleMeshGenerationJobs(); // 0x000000018244D420-0x000000018244D460
			public void ProcessOnVisualsChanged(RenderData renderData, uint dirtyID, ref ChainBuilderStats stats); // 0x000000018244CDF0-0x000000018244CFC0
			private void DepthFirstOnVisualsChanged(RenderData renderData, uint dirtyID, bool hierarchical, List<MeshModifierRegistration> inheritedRecursive, ref ChainBuilderStats stats); // 0x000000018244C150-0x000000018244CA00
			private bool RebuildEffectiveModifiers(RenderData rd, List<MeshModifierRegistration> inheritedRecursive); // 0x000000018244CFE0-0x000000018244D230
			public void ReleaseChainRef(List<MeshModifierRegistration> chain); // 0x000000018244D230-0x000000018244D250
			public void PruneChainCache(); // 0x000000018244CFC0-0x000000018244CFE0
			private List<MeshModifierRegistration> DeriveChildModifiers(RenderData rd); // 0x000000018244CA00-0x000000018244CBA0
			private List<MeshModifierRegistration> DeriveOuterInherited(RenderData outerRd); // 0x000000018244CBA0-0x000000018244CCC0
			private static void SubtractOwnIntoScratch(List<MeshModifierRegistration> effective, List<MeshModifierRegistration> own, bool includeRecursiveOwn); // 0x000000018244D460-0x000000018244D630
			private static void UpdateWorldFlipsWinding(RenderData renderData); // 0x000000018244D630-0x000000018244D670
			public void RunMeshModifiers(); // 0x000000018244D250-0x000000018244D420
			public void ConvertEntriesToCommands(ref ChainBuilderStats stats); // 0x000000018244BE20-0x000000018244C150
			public void Dispose(); // 0x000000018244CCC0-0x000000018244CD70
			protected void Dispose(bool disposing); // 0x000000018244CD70-0x000000018244CDF0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 5144
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<RenderChainCommand> __9__49_0; // 0x08
			public static Action<RenderChainCommand> __9__49_1; // 0x10
			public static Func<ExtraRenderData> __9__49_2; // 0x18
			public static Func<RenderData> __9__49_3; // 0x20
			public static Func<RenderTree> __9__49_4; // 0x28
	
			// Constructors
			static __c(); // 0x000000018244A880-0x000000018244A8F0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal RenderChainCommand _.ctor_b__49_0(); // 0x000000018244A5F0-0x000000018244A640
			internal void _.ctor_b__49_1(RenderChainCommand cmd); // 0x000000018244A640-0x000000018244A660
			internal ExtraRenderData _.ctor_b__49_2(); // 0x000000018244A660-0x000000018244A6B0
			internal RenderData _.ctor_b__49_3(); // 0x000000018244A6B0-0x000000018244A700
			internal RenderTree _.ctor_b__49_4(); // 0x000000018244A700-0x000000018244A750
		}
	
		// Constructors
		public RenderTreeManager(BaseVisualElementPanel panel); // 0x00000001824421B0-0x00000001824430A0
		static RenderTreeManager(); // 0x00000001824420B0-0x00000001824421B0
	
		// Methods
		public bool EnsureElementId(RenderData renderData); // 0x000000018243F700-0x000000018243F890
		public void MarkElementInfoDirty(RenderData renderData); // 0x000000018243FF40-0x0000000182440000
		public void UpdateElementInfoRecords(); // 0x0000000182441EB0-0x00000001824420B0
		public void ReleaseElementId(RenderData renderData); // 0x0000000182440640-0x0000000182440690
		internal RenderData GetPooledRenderData(); // 0x000000018243FC00-0x000000018243FC40
		internal void ReturnPoolRenderData(RenderData data); // 0x0000000182441200-0x0000000182441270
		internal RenderTree GetPooledRenderTree(RenderTreeManager renderTreeManager, RenderData rootRenderData); // 0x000000018243FC40-0x000000018243FCA0
		internal void ReturnPoolRenderTree(RenderTree tree); // 0x0000000182441270-0x00000001824412E0
		public void Dispose(); // 0x000000018243EE80-0x000000018243EEE0
		protected void Dispose(bool disposing); // 0x000000018243EEE0-0x000000018243F700
		private static void ReverseDepthFirstDisposeRenderTrees(RenderTree renderTree); // 0x00000001824412E0-0x0000000182441380
		private void DepthFirstProcessChanges(RenderTree renderTree); // 0x000000018243ECE0-0x000000018243ED40
		public void ProcessChanges(); // 0x0000000182440000-0x0000000182440440
		private void SerializeRootTreeCommands(); // 0x0000000182441380-0x0000000182441720
		public void RenderRootTree(); // 0x00000001824406B0-0x00000001824408F0
		private void RenderNestedTrees(); // 0x0000000182440690-0x00000001824406B0
		public void RenderSingleTree(RenderTree renderTree, RenderTexture nestedTreeRT, RectInt nestedTreeViewport, Rect bounds); // 0x00000001824408F0-0x0000000182440FB0
		public void CancelInsertion(VisualElement ve); // 0x000000018243EBF0-0x000000018243ECE0
		public void UIEOnChildAdded(VisualElement ve); // 0x0000000182441720-0x0000000182441870
		private uint ProcessChildAdded(VisualElement ve); // 0x0000000182440440-0x0000000182440640
		public void UIEOnChildrenReordered(VisualElement ve); // 0x0000000182441970-0x0000000182441B40
		public void UIEOnChildRemoving(VisualElement ve); // 0x0000000182441870-0x0000000182441970
		public void UIEOnRenderHintsChanged(VisualElement ve); // 0x0000000182441C90-0x0000000182441E40
		private void RegisterDirty(VisualElement ve, RenderDataDirtyTypes dirtyTypes, RenderDataDirtyTypeClasses dirtyClasses); // 0x00000001824353A0-0x00000001824354B0
		public void UIEOnClippingChanged(VisualElement ve, bool hierarchical); // 0x0000000182441B40-0x0000000182441B80
		public void UIEOnOpacityChanged(VisualElement ve, bool hierarchical = false /* Metadata: 0x00660AD7 */); // 0x0000000182441C50-0x0000000182441C90
		public void UIEOnColorChanged(VisualElement ve); // 0x0000000182441B80-0x0000000182441BB0
		public void UIEOnTransformOrSizeChanged(VisualElement ve, bool transformChanged, bool clipRectSizeChanged); // 0x0000000182441E40-0x0000000182441E70
		public void UIEOnVisualsChanged(VisualElement ve, bool hierarchical); // 0x0000000182441E70-0x0000000182441EB0
		public void UIEOnDisableRenderingChanged(VisualElement ve); // 0x0000000182441BB0-0x0000000182441C50
		internal RenderChainCommand AllocCommand(); // 0x000000018243EBD0-0x000000018243EBF0
		internal void FreeCommand(RenderChainCommand cmd); // 0x000000018243F890-0x000000018243F8E0
		internal void RepaintTexturedElements(); // 0x0000000182440FB0-0x0000000182441070
		private void DepthFirstRepaintTextured(RenderTree renderTree); // 0x000000018243EDC0-0x000000018243EE80
		private void DepthFirstRepaintTextured(RenderData renderData); // 0x000000018243ED40-0x000000018243EDC0
		public ExtraRenderData GetOrAddExtraData(RenderData renderData); // 0x000000018243FB40-0x000000018243FC00
		public ExtraRenderData GetExtraData(RenderData renderData); // 0x000000018243FAE0-0x000000018243FB40
		public void FreeExtraData(RenderData renderData); // 0x000000018243F8E0-0x000000018243F9D0
		public void InsertExtraMesh(RenderData renderData, MeshHandle mesh); // 0x000000018243FCA0-0x000000018243FDC0
		public void FreeExtraMeshes(RenderData renderData); // 0x000000018243F9D0-0x000000018243FAE0
		public void InsertTexture(RenderData renderData, Texture src, TextureId id, bool isAtlas); // 0x000000018243FDC0-0x000000018243FE40
		public void InsertVectorImage(RenderData renderData, VectorImage vi); // 0x000000018243FE40-0x000000018243FF40
		public void ResetGraphicEntries(RenderData renderData); // 0x0000000182441070-0x0000000182441200
	}
}
