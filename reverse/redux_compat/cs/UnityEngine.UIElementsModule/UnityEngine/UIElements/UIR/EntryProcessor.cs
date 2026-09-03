/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class EntryProcessor // TypeDefIndex: 5056
	{
		// Fields
		private EntryPreProcessor m_PreProcessor; // 0x10
		private RenderTreeManager m_RenderTreeManager; // 0x18
		private RenderData m_CurrentRenderData; // 0x20
		private ExtraVertexChannels m_PanelExtras; // 0x28
		private IntPtr m_NoUserExtrasTemplatePtr; // 0x30
		private int m_MaskDepth; // 0x38
		private int m_MaskDepthPopped; // 0x3C
		private int m_MaskDepthPushed; // 0x40
		private int m_StencilRef; // 0x44
		private int m_StencilRefPopped; // 0x48
		private int m_StencilRefPushed; // 0x4C
		private BMPAlloc m_ClipRectId; // 0x50
		private BMPAlloc m_ClipRectIdPopped; // 0x58
		private BMPAlloc m_ClipRectIdPushed; // 0x60
		private bool m_IsDrawingMask; // 0x68
		private Stack<MaskMesh> m_MaskMeshes; // 0x70
		private bool m_RequestedElementId; // 0x78
		private bool m_ElementIdValid; // 0x79
		private ushort m_TextCoreId; // 0x7A
		private MeshHandle m_Mesh; // 0x80
		private RawSlice m_Verts; // 0x88
		private NativeSlice<ushort> m_Indices; // 0x98
		private ushort m_IndexOffset; // 0xA8
		private int m_AllocVertexCount; // 0xAC
		private int m_AllocIndex; // 0xB0
		private int m_VertsFilled; // 0xB4
		private int m_IndicesFilled; // 0xB8
		private VertexFlags m_RenderType; // 0xBC
		private bool m_RemapUVs; // 0xBE
		private Rect m_AtlasRect; // 0xC0
		private ushort m_GradientSettingIndexOffset; // 0xD0
		private bool m_IsTail; // 0xD2
		private RenderChainCommand m_FirstCommand; // 0xD8
		private RenderChainCommand m_LastCommand; // 0xE0
		[CompilerGenerated]
		private RenderChainCommand _firstHeadCommand_k__BackingField; // 0xE8
		[CompilerGenerated]
		private RenderChainCommand _lastHeadCommand_k__BackingField; // 0xF0
		[CompilerGenerated]
		private RenderChainCommand _firstTailCommand_k__BackingField; // 0xF8
		[CompilerGenerated]
		private RenderChainCommand _lastTailCommand_k__BackingField; // 0x100
	
		// Properties
		public RenderChainCommand firstHeadCommand { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806BAE70-0x00000001806BAE80 0x00000001806C0C20-0x00000001806C0C40
		public RenderChainCommand lastHeadCommand { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180CC3740-0x0000000180CC3750 0x0000000180CC3C60-0x0000000180CC3C80
		public RenderChainCommand firstTailCommand { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180CDCEE0-0x0000000180CDCEF0 0x00000001816A2DA0-0x00000001816A2DC0
		public RenderChainCommand lastTailCommand { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001816A28C0-0x00000001816A28D0 0x00000001816A2D50-0x00000001816A2D70
	
		// Nested types
		private struct MaskMesh // TypeDefIndex: 5057
		{
			// Fields
			public RawSlice vertices; // 0x00
			public NativeSlice<ushort> indices; // 0x10
			public int indexOffset; // 0x20
		}
	
		// Constructors
		public EntryProcessor(); // 0x000000018240E560-0x000000018240E740
	
		// Methods
		public void Init(Entry root, RenderTreeManager renderTreeManager, RenderData renderData); // 0x000000018240C640-0x000000018240C9B0
		public void ClearReferences(); // 0x000000018240C040-0x000000018240C150
		public void ProcessHead(); // 0x000000018240CBD0-0x000000018240CCA0
		public void ProcessTail(); // 0x000000018240E2E0-0x000000018240E440
		private void ProcessRange(int first, int last); // 0x000000018240D7F0-0x000000018240E2E0
		private void ProcessMeshEntry(Entry entry, TextureId textureId); // 0x000000018240CCA0-0x000000018240D580
		private static void FillExtrasChannel<T>(ref IntPtr src, ref int stride, ref int dstOffset, NativeSlice<T> slice, ExtraVertexChannels channel, ExtraVertexChannels panelMask)
			where T : struct;
		private void DrawReverseMask(); // 0x000000018240C2E0-0x000000018240C640
		private RenderChainCommand CreateMeshDrawCommand(MeshHandle mesh, int indexCount, int indexOffset, Material material, TextureId texture); // 0x000000018240C150-0x000000018240C2E0
		private void AppendCommand(RenderChainCommand next); // 0x0000000182407780-0x000000018240A270
		private void ProcessFirstAlloc(List<EntryPreProcessor.AllocSize> allocList, ref MeshHandle mesh); // 0x000000018240C9B0-0x000000018240CBD0
		private void ProcessNextAlloc(); // 0x000000018240D580-0x000000018240D7F0
		private static void UpdateOrAllocate(ref MeshHandle data, int vertexCount, int indexCount, UIRenderDevice device, out RawSlice verts, out NativeSlice<ushort> indices, out ushort indexOffset, ref ChainBuilderStats stats); // 0x000000018240E440-0x000000018240E560
	}
}
