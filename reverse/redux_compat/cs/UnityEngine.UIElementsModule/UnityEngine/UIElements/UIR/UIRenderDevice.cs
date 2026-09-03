/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Profiling;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class UIRenderDevice : IDisposable // TypeDefIndex: 5032
	{
		// Fields
		private IntPtr m_DefaultStencilState; // 0x10
		private IntPtr m_VertexDecl; // 0x18
		private readonly ExtraVertexChannels m_ExtraVertexChannels; // 0x20
		private readonly uint m_ExtrasStride; // 0x24
		private unsafe ConvertMeshExtrasData* m_NoUserExtrasTemplate; // 0x28
		private static readonly MemoryLabel k_NoUserExtrasLabel; // 0x00
		private List<MeshHandle> m_MeshesPendingFree; // 0x30
		private CommandListManager m_CommandListManager; // 0x38
		private uint[] m_Fences; // 0x40
		private MaterialPropertyBlock m_ConstantProps; // 0x48
		private MaterialPropertyBlock m_BatchProps; // 0x50
		private uint m_FrameIndex; // 0x58
		private MeshManager m_MeshManager; // 0x60
		private DrawStatistics m_DrawStats; // 0x68
		private bool m_RenderingInProgress; // 0x98
		private readonly DrawParams m_DrawParams; // 0xA0
		private readonly TextureSlotManager m_TextureSlotManager; // 0xA8
		private HashSet<Material> m_ScreenSpaceAlteredMaterials; // 0xB0
		private readonly UIRRenderDeviceProfiler m_Profiler; // 0xB8
		private static LinkedList<DeviceToFree> m_DeviceFreeQueue; // 0x10
		private static int m_ActiveDeviceCount; // 0x18
		private static bool m_SubscribedToNotifications; // 0x1C
		private static bool m_SynchronousFree; // 0x1D
		private static readonly int s_GradientSettingsTexID; // 0x20
		private static readonly int s_ShaderInfoTexID; // 0x24
		private static readonly int s_XformPagePosID; // 0x28
		private static readonly int s_ClipPagePosID; // 0x2C
		private static readonly int s_OpacityPagePosID; // 0x30
		private static readonly int s_ColorPagePosID; // 0x34
		private static readonly int s_TextCorePagePosID; // 0x38
		private static readonly int s_ElementInfoPagePosID; // 0x3C
		private static readonly int s_SkipGammaConversionID; // 0x40
		private static ProfilerMarker s_MarkerFree; // 0x48
		private static ProfilerMarker s_MarkerAdvanceFrame; // 0x50
		private static ProfilerMarker s_MarkerFence; // 0x58
		private static ProfilerMarker s_MarkerBeforeDraw; // 0x60
		[CompilerGenerated]
		private bool _breakBatches_k__BackingField; // 0xC0
		[CompilerGenerated]
		private readonly bool _isFlat_k__BackingField; // 0xC1
		[CompilerGenerated]
		private readonly bool _forceGammaRendering_k__BackingField; // 0xC2
		[CompilerGenerated]
		private bool _disposed_k__BackingField; // 0xC3
		private static readonly int[] s_EvaluationFlagsToTextureSlotCount; // 0x68
		private static readonly int[] s_TextureSlotCountToEvaluationFlags; // 0x70
	
		// Properties
		internal static uint maxVerticesPerPage { get; } // 0x0000000181547E70-0x0000000181547E80 
		public ExtraVertexChannels extraVertexChannels { get; } // 0x0000000180C4F680-0x0000000180C4F690 
		internal IntPtr noUserExtrasTemplatePtr { get; } // 0x00000001823FF7A0-0x00000001823FF7B0 
		public bool breakBatches { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018183E570-0x000000018183E580 0x0000000181F64A30-0x0000000181F64A40
		public bool isFlat { [CompilerGenerated] get; } // 0x00000001816A4210-0x00000001816A4220 
		public bool forceGammaRendering { [CompilerGenerated] get; } // 0x00000001816A5690-0x00000001816A56A0 
		protected bool disposed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181CE1700-0x0000000181CE1710 0x00000001823FF7B0-0x00000001823FF7C0
	
		// Nested types
		private struct DeviceToFree // TypeDefIndex: 5033
		{
			// Fields
			public uint handle; // 0x00
			public CommandListManager commandListManager; // 0x08
			public MeshManager meshManager; // 0x10
	
			// Methods
			public void Dispose(); // 0x000000018240AE90-0x000000018240AED0
		}
	
		[Flags]
		private enum EvaluationFlags // TypeDefIndex: 5034
		{
			None = 0,
			MustApplyMaterial = 1,
			MustApplyBatchProps = 2,
			ForceRenderTypeBitOffset = 3,
			MustApplyStencil = 4,
			TextureSlotCountBitOffset = 6,
			ForceRenderTypeSolid = 8,
			ForceRenderTypeTextured = 16,
			ForceRenderTypeText = 24,
			ForceRenderTypeSvgGradient = 32,
			ForceRenderTypeBits = 56,
			TextureSlotCount1 = 64,
			TextureSlotCount2 = 128,
			TextureSlotCount4 = 192,
			TextureSlotCount8 = 256,
			TextureSlotCountBits = 448,
			IsSerializing = 512,
			IsRenderingNestedTreeRT = 1024,
			SkipForceGamma = 2048
		}
	
		private struct EvaluationState // TypeDefIndex: 5035
		{
			// Fields
			public CommandList activeCommandList; // 0x00
			public MaterialPropertyBlock constantProps; // 0x08
			public MaterialPropertyBlock batchProps; // 0x10
			public MaterialPropertyBlock userProps; // 0x18
			public Material material; // 0x20
			public int stencilRef; // 0x28
			public Page curPage; // 0x30
			public EvaluationFlags flags; // 0x38
			public VisualElement commandListOwner; // 0x40
		}
	
		internal struct DrawStatistics // TypeDefIndex: 5036
		{
			// Fields
			public int currentFrameIndex; // 0x00
			public uint totalIndices; // 0x04
			public uint totalVertices; // 0x08
			public uint commandCount; // 0x0C
			public uint skippedCommandCount; // 0x10
			public uint drawCommandCount; // 0x14
			public uint disableCommandCount; // 0x18
			public uint materialSetCount; // 0x1C
			public uint drawRangeCount; // 0x20
			public uint drawRangeCallCount; // 0x24
			public uint immediateDraws; // 0x28
			public uint stencilRefChanges; // 0x2C
		}
	
		// Constructors
		static UIRenderDevice(); // 0x00000001823FE9C0-0x00000001823FF010
		public UIRenderDevice(uint initialVertexCapacity = 0 /* Metadata: 0x006609CB */, uint initialIndexCapacity = 0 /* Metadata: 0x006609CC */, bool isFlat = true /* Metadata: 0x006609CD */, bool forceGammaRendering = false /* Metadata: 0x006609CE */, ExtraVertexChannels extraVertexChannels = ExtraVertexChannels.None /* Metadata: 0x006609CF */); // 0x00000001823FF010-0x00000001823FF7A0
	
		// Methods
		private static int ReserveExtrasOffset(ExtraVertexChannels channel, ExtraVertexChannels mask, ref int cursor); // 0x00000001823FE100-0x00000001823FE120
		private static unsafe void BuildNoUserExtrasTemplate(ExtraVertexChannels mask, ConvertMeshExtrasData* extras); // 0x00000001823FB5A0-0x00000001823FB690
		private void InitVertexDeclaration(); // 0x00000001823FCE20-0x00000001823FD2F0
		public void Dispose(); // 0x00000001823FB8B0-0x00000001823FB920
		protected virtual void Dispose(bool disposing); // 0x00000001823FB690-0x00000001823FB8B0
		public MeshHandle Allocate(uint vertexCount, uint indexCount, out RawSlice vertexData, out NativeSlice<ushort> indexData, out ushort indexOffset); // 0x00000001823FA670-0x00000001823FA720
		public void Update(MeshHandle mesh, uint vertexCount, uint indexCount, out RawSlice vertexData, out NativeSlice<ushort> indexData, out ushort indexOffset); // 0x00000001823FE750-0x00000001823FE810
		public void Free(MeshHandle mesh); // 0x00000001823FCD40-0x00000001823FCE20
		public void OnFrameRenderingBegin(); // 0x00000001823FDBB0-0x00000001823FDCD0
		internal static unsafe NativeSlice<T> PtrToSlice<T>(void* p, int count)
			where T : struct;
		private static int FlagsToTextureSlotCount(EvaluationFlags flags); // 0x00000001823FCC30-0x00000001823FCCB0
		private static EvaluationFlags TextureSlotCountToFlags(TextureSlotCount count); // 0x00000001823FE610-0x00000001823FE690
		private void ApplyDrawCommandState(RenderChainCommand cmd, int textureSlot, Material newMat, bool newMatDiffers, MaterialPropertyBlock userProps, EvaluationFlags defaultTextureSlotCountFlags, bool kickRanges, Texture gradientSettings, ShaderInfoAllocator shaderInfoAllocator, ref EvaluationState st); // 0x00000001823FB2C0-0x00000001823FB5A0
		private void ApplyBatchState(ref EvaluationState st); // 0x00000001823FA720-0x00000001823FB2C0
		public void EvaluateChain(RenderChainCommand head, Material defaultMat, Texture gradientSettings, ShaderInfoAllocator shaderInfoAllocator, Rect? scissor, Rect drawBounds, float pixelsPerPoint, bool isSerializing, TextureSlotCount defaultTextureSlotCount, bool isRenderingNestedTreeRT, ref Exception immediateException, BaseVisualElementPanel panel); // 0x00000001823FBB30-0x00000001823FCC30
		private bool IsComponentDisabledForCommandListOwner(VisualElement owner); // 0x00000001823FD520-0x00000001823FD6A0
		private void ResetScreenSpaceMaterials(); // 0x00000001823FE120-0x00000001823FE400
		private void InitializeConstantProperties(MaterialPropertyBlock constantProps, Texture gradientSettings, ShaderInfoAllocator shaderInfoAllocator); // 0x00000001823FD2F0-0x00000001823FD520
		private void SetupCommandList(ref EvaluationState st, Texture gradientSettings, ShaderInfoAllocator shaderInfoAllocator, CommandFlags commandFlags); // 0x00000001823FE400-0x00000001823FE610
		private void UpdateFenceValue(); // 0x00000001823FE690-0x00000001823FE750
		private unsafe void KickRanges(DrawBufferRange* ranges, ref int rangesReady, ref int rangesStart, int rangesCount, Page curPage, CommandList commandList, KickRangesReason kickReason); // 0x00000001823FD6A0-0x00000001823FDB10
		private void DrawRanges(Utility.GPUBuffer ib, Utility.GPUBuffer vb, NativeSlice<DrawBufferRange> ranges, CommandList commandList, KickRangesReason kickReason); // 0x00000001823FB920-0x00000001823FBB30
		private void WaitOnCpuFence(uint fence); // 0x00000001823FE810-0x00000001823FE960
		public void AdvanceFrame(); // 0x00000001823FA2F0-0x00000001823FA670
		internal static void PrepareForGfxDeviceRecreate(); // 0x00000001823FDCD0-0x00000001823FDD30
		internal static void WrapUpGfxDeviceRecreate(); // 0x00000001823FE960-0x00000001823FE9C0
		internal static void FlushAllPendingDeviceDisposes(); // 0x00000001823FCCB0-0x00000001823FCD40
		private static KickRangesReason KickReasonForNonDrawCommand(CommandType type); // 0x00000001823EBD00-0x00000001823EBE90
		public static void ProcessDeviceFreeQueue(); // 0x00000001823FDD30-0x00000001823FE100
		private static void OnEngineUpdateGlobal(); // 0x00000001823FDB10-0x00000001823FDB50
		private static void OnFlushPendingResources(); // 0x00000001823FDB50-0x00000001823FDBB0
	}
}
