/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler;
using UnityEngine.Rendering.RendererUtils;
using UnityEngine.Scripting.APIUpdating;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule
{
	[MovedFrom(true, "UnityEngine.Experimental.Rendering.RenderGraphModule", "UnityEngine.Rendering.RenderGraphModule", null)]
	public class RenderGraph // TypeDefIndex: 5875
	{
		// Fields
		private NativePassCompiler nativeCompiler; // 0x10
		public static readonly int kMaxMRTCount; // 0x00
		[CompilerGenerated]
		private bool _nativeRenderPassesEnabled_k__BackingField; // 0x18
		internal RenderGraphResourceRegistry m_Resources; // 0x20
		internal RenderGraphObjectPool m_RenderGraphPool; // 0x28
		private RenderGraphBuilders m_builderInstance; // 0x30
		private RenderGraphValidationLayer m_ValidationLayer; // 0x38
		internal List<RenderGraphPass> m_RenderPasses; // 0x40
		private List<RendererListHandle> m_RendererLists; // 0x48
		private RenderGraphDebugParams m_DebugParameters; // 0x50
		private RenderGraphDefaultResources m_DefaultResources; // 0x58
		private Dictionary<int, ProfilingSampler> m_DefaultProfilingSamplers; // 0x60
		private InternalRenderGraphContext m_RenderGraphContext; // 0x68
		private CommandBuffer m_PreviousCommandBuffer; // 0x70
		private RenderGraphCompilationCache m_CompilationCache; // 0x78
		private EntityId m_CurrentExecutionId; // 0x80
		private bool m_CurrentExecutionCanGenerateDebugData; // 0x88
		private int m_ExecutionCount; // 0x8C
		private int m_CurrentFrameIndex; // 0x90
		private bool m_ExecutionExceptionWasRaised; // 0x94
		private bool m_EnableCompilationCaching; // 0x95
		internal static bool? s_EnableCompilationCachingForTests; // 0x04
		private RenderGraphState m_RenderGraphState; // 0x98
		private RenderTextureUVOriginStrategy m_renderTextureUVOriginStrategy; // 0x9C
		private static readonly Dictionary<RenderGraph, List<DebugExecutionItem>> s_RegisteredExecutions; // 0x08
		[CompilerGenerated]
		private string _name_k__BackingField; // 0xA0
		[CompilerGenerated]
		private static bool _enableValidityChecks_k__BackingField; // 0x10
		private const string k_BeginProfilingSamplerPassName = "BeginProfile"; // Metadata: 0x00661BF6
		private const string k_EndProfilingSamplerPassName = "EndProfile"; // Metadata: 0x00661C03
		[CompilerGenerated]
		private static OnGraphRegisteredDelegate onGraphRegistered; // 0x18
		[CompilerGenerated]
		private static OnGraphRegisteredDelegate onGraphUnregistered; // 0x20
		[CompilerGenerated]
		private static OnExecutionRegisteredDelegate onExecutionRegistered; // 0x28
		private static bool s_DebugSessionWasActive; // 0x30
		private Dictionary<int, TextureHandle> registeredGlobals; // 0xA8
	
		// Properties
		[Obsolete("RenderGraph always enables native render pass support. #from(6000.5)")]
		public bool nativeRenderPassesEnabled { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180F9E350-0x0000000180F9E360 0x00000001804C2E10-0x00000001804C2E20
		public string name { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805B5990-0x00000001805B59A0 0x00000001806CCE40-0x00000001806CCE60
		internal RenderGraphState RenderGraphState { get; set; } // 0x000000018033D1D0-0x000000018033D1E0 0x000000018033E7B0-0x000000018033E7C0
		public RenderTextureUVOriginStrategy renderTextureUVOriginStrategy { get; internal set; } // 0x000000018033D200-0x000000018033D210 0x000000018033E7E0-0x000000018033E7F0
		internal RenderGraphValidationLayer validationLayer { set; } // 0x00000001802E76C0-0x00000001802E76D0
		public static bool isRenderGraphViewerActive { get; } // 0x0000000181ECB280-0x0000000181ECB2C0 
		internal static bool enableValidityChecks { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181ECB230-0x0000000181ECB280 0x0000000181ECB530-0x0000000181ECB590
		public RenderGraphDefaultResources defaultResources { get; } // 0x00000001802F4000-0x00000001802F4010 
		internal RenderGraphDebugParams debugParams { get; } // 0x00000001806CCC00-0x00000001806CCC10 
		internal bool areAnySettingsActive { get; } // 0x0000000181ECB1F0-0x0000000181ECB230 
	
		// Events
		internal static event OnGraphRegisteredDelegate onGraphRegistered {
			add; // 0x0000000181ECB050-0x0000000181ECB120
			remove; // 0x0000000181ECB390-0x0000000181ECB460
		}
		internal static event OnGraphRegisteredDelegate onGraphUnregistered {
			add; // 0x0000000181ECB120-0x0000000181ECB1F0
			remove; // 0x0000000181ECB460-0x0000000181ECB530
		}
		internal static event OnExecutionRegisteredDelegate onExecutionRegistered {
			add; // 0x0000000181ECAF80-0x0000000181ECB050
			remove; // 0x0000000181ECB2C0-0x0000000181ECB390
		}
	
		// Nested types
		internal class DebugExecutionItem // TypeDefIndex: 5876
		{
			// Fields
			[CompilerGenerated]
			private readonly EntityId _id_k__BackingField; // 0x10
			[CompilerGenerated]
			private readonly string _name_k__BackingField; // 0x18
	
			// Properties
			public EntityId id { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
			public string name { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			public DebugExecutionItem(EntityId id, string name); // 0x0000000181533F60-0x0000000181533FB0
		}
	
		[Serializable]
		internal class DebugData // TypeDefIndex: 5877
		{
			// Fields
			public string executionName; // 0x10
			public bool valid; // 0x18
			public string captureSourceString; // 0x20
			public string captureTimestamp; // 0x28
			public int graphHash; // 0x30
			public List<PassData> passList; // 0x38
			public ResourceDataLists resourceLists; // 0x40
	
			// Nested types
			[Serializable]
			public class ResourceLists<T> // TypeDefIndex: 5878
			{
				// Fields
				[SerializeField]
				private List<T> m_Textures;
				[SerializeField]
				private List<T> m_Buffers;
				[SerializeField]
				private List<T> m_AccelerationStructures;
	
				// Properties
				public List<T> this[int index] { get => default; set {} }
	
				// Constructors
				public ResourceLists();
	
				// Methods
				public void Clear();
			}
	
			[Serializable]
			public class ResourceDataLists : ResourceLists<ResourceData> // TypeDefIndex: 5879
			{
				// Constructors
				public ResourceDataLists(); // 0x0000000181ECB690-0x0000000181ECB6D0
			}
	
			[Serializable]
			public class SerializableNativePassAttachment // TypeDefIndex: 5880
			{
				// Fields
				public RenderBufferLoadAction loadAction; // 0x10
				public RenderBufferStoreAction storeAction; // 0x14
				public bool memoryless; // 0x18
				public int mipLevel; // 0x1C
				public int depthSlice; // 0x20
	
				// Constructors
				public SerializableNativePassAttachment(NativePassAttachment att); // 0x0000000181ECB990-0x0000000181ECB9E0
			}
	
			[Serializable]
			[DebuggerDisplay("PassDebug: {name}")]
			public struct PassData // TypeDefIndex: 5881
			{
				// Fields
				public string name; // 0x00
				public RenderGraphPassType type; // 0x08
				public ResourceIdLists resourceReadLists; // 0x10
				public ResourceIdLists resourceWriteLists; // 0x18
				public bool culled; // 0x20
				public bool async; // 0x21
				public int nativeSubPassIndex; // 0x24
				public int syncToPassIndex; // 0x28
				public int syncFromPassIndex; // 0x2C
				public bool generateDebugData; // 0x30
				[SerializeReference]
				public NRPInfo nrpInfo; // 0x38
				public ScriptInfo scriptInfo; // 0x40
	
				// Nested types
				[Serializable]
				public class ResourceIdLists : ResourceLists<int> // TypeDefIndex: 5882
				{
					// Constructors
					public ResourceIdLists(); // 0x0000000181ECB6D0-0x0000000181ECB710
				}
	
				[Serializable]
				public class NRPInfo // TypeDefIndex: 5883
				{
					// Fields
					[SerializeReference]
					public NativeRenderPassInfo nativePassInfo; // 0x10
					public List<int> textureFBFetchList; // 0x18
					public List<int> setGlobals; // 0x20
					public int width; // 0x28
					public int height; // 0x2C
					public int volumeDepth; // 0x30
					public int samples; // 0x34
					public bool hasDepth; // 0x38
	
					// Nested types
					[Serializable]
					public class NativeRenderPassInfo // TypeDefIndex: 5884
					{
						// Fields
						public string passBreakReasoning; // 0x10
						public List<AttachmentInfo> attachmentInfos; // 0x18
						public SerializedDictionary<int, PassCompatibilityInfo> passCompatibility; // 0x20
						public List<int> mergedPassIds; // 0x28
	
						// Nested types
						[Serializable]
						public class AttachmentInfo // TypeDefIndex: 5885
						{
							// Fields
							public string resourceName; // 0x10
							public string loadReason; // 0x18
							public string storeReason; // 0x20
							public string storeMsaaReason; // 0x28
							public int attachmentIndex; // 0x30
							public SerializableNativePassAttachment attachment; // 0x38
	
							// Constructors
							public AttachmentInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
						}
	
						[Serializable]
						public struct PassCompatibilityInfo // TypeDefIndex: 5886
						{
							// Fields
							public string message; // 0x00
							public bool isCompatible; // 0x08
						}
	
						// Constructors
						public NativeRenderPassInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
					}
	
					// Constructors
					public NRPInfo(); // 0x0000000181EC3100-0x0000000181EC31B0
				}
			}
	
			[Serializable]
			public class BufferResourceData // TypeDefIndex: 5887
			{
				// Fields
				public int count; // 0x10
				public int stride; // 0x14
				public GraphicsBuffer.Target target; // 0x18
				public GraphicsBuffer.UsageFlags usage; // 0x1C
	
				// Constructors
				public BufferResourceData(); // 0x00000001802E5CB0-0x00000001802E5CC0
			}
	
			[Serializable]
			public class TextureResourceData // TypeDefIndex: 5888
			{
				// Fields
				public int width; // 0x10
				public int height; // 0x14
				public int depth; // 0x18
				public bool bindMS; // 0x1C
				public int samples; // 0x20
				public GraphicsFormat format; // 0x24
				public bool clearBuffer; // 0x28
	
				// Constructors
				public TextureResourceData(); // 0x00000001802E5CB0-0x00000001802E5CC0
			}
	
			[Serializable]
			[DebuggerDisplay("ResourceDebug: {name} [{creationPassIndex}:{releasePassIndex}]")]
			public struct ResourceData // TypeDefIndex: 5889
			{
				// Fields
				public string name; // 0x00
				public bool imported; // 0x08
				public int creationPassIndex; // 0x0C
				public int releasePassIndex; // 0x10
				public List<int> consumerList; // 0x18
				public List<int> producerList; // 0x20
				public bool memoryless; // 0x28
				[SerializeReference]
				public TextureResourceData textureData; // 0x30
				[SerializeReference]
				public BufferResourceData bufferData; // 0x38
				public ScriptInfo scriptInfo; // 0x40
			}
	
			[Serializable]
			public struct ScriptInfo // TypeDefIndex: 5890
			{
				// Fields
				public string filePath; // 0x00
				public int line; // 0x08
			}
	
			// Constructors
			public DebugData(string executionName); // 0x0000000181EBDE10-0x0000000181EBDF00
	
			// Methods
			public void Clear(); // 0x0000000181EBDD90-0x0000000181EBDE10
		}
	
		internal static class DebugDataSerialization // TypeDefIndex: 5891
		{
			// Methods
			public static string ToJson(DebugData debugData); // 0x0000000181EBDD60-0x0000000181EBDD90
			public static DebugData FromJson(string json); // 0x0000000181EBDD10-0x0000000181EBDD60
		}
	
		internal static class RenderGraphExceptionMessages // TypeDefIndex: 5892
		{
			// Fields
			[NoAutoStaticsCleanup]
			internal static bool enableCaller; // 0x00
			internal const string k_RenderGraphExecutionError = "Render Graph Execution error"; // Metadata: 0x00661C0E
			private static readonly Dictionary<RenderGraphState, string> m_RenderGraphStateMessages; // 0x08
			private const string k_ErrorDefaultMessage = "Invalid render graph state, impossible to log the exception."; // Metadata: 0x00661C2B
			internal const string k_NonTextureAsAttachmentError = "Only textures can be used as a fragment attachment."; // Metadata: 0x00661C68
			internal const string k_OneResourceTwoVersionsError = "A pass is using SetAttachment or UseTexture on two versions of the same resource. Make sure you only access the latest version."; // Metadata: 0x00661C9C
			internal const string k_UseTextureRandWriteTwoVersionsError = "A pass is using UseTextureRandomWrite on two versions of the same resource.  Make sure you only access the latest version."; // Metadata: 0x00661D1D
			internal const string k_InvalidGetRenderTargetInfoResultsError = "GetRenderTargetInfo returned invalid results. Check that the width, height, and number of MSAA samples is not 0."; // Metadata: 0x00661D99
			internal const string k_CannotDetermineSubPassFlagNoDepth = "SubPassFlag for merging cannot be determined if native pass doesn\'t have a depth attachment. Make sure your pass has a depth attachment."; // Metadata: 0x00661E0B
			internal const string k_AddingOlderAttachmentVersion = "The pass adds an older version while a higher version is already registered with the pass. Make sure you only access the latest version."; // Metadata: 0x00661E95
			internal const string k_GraphPassesCalledBeforeCompactedNonCulledRasterPasses = "Cannot iterate over compactedNonCulledRasterPasses, the data is null. Did you use GraphPasses() before calling CompactNonCulledPassesForRasterPasses?"; // Metadata: 0x00661F1F
			internal const string k_NonIncrementalCreationCall = "Something went wrong when compiling the graph. The Creation lists must be set-up incrementally for all passes, but AddFirstUse is called in an arbitrary non-incremental way."; // Metadata: 0x00661FB6
			internal const string k_NonIncrementalDestructionCall = "Something went wrong when compiling the graph. The Destruction lists must be set-up incrementally for all passes, AddLastUse is called in an arbitrary non-incremental way."; // Metadata: 0x00662065
			internal const string k_UndisposedBuilderPreviousPass = "Finish building the previous pass first by disposing of the pass builder object before adding a new pass. You can manually dispose of the builder with \'builder.Dispose()\'."; // Metadata: 0x00662112
			internal const string k_WriteToVersionedResource = "The pass writes to a versioned resource handle. You can only write to unversioned resource handles to avoid branches in the resource history."; // Metadata: 0x006621BF
			internal const string k_WriteToResourceTwice = "The pass writes to a resource twice. You can only write the same resource once within a pass."; // Metadata: 0x0066224E
			internal const string k_TextureAlreadyBeingUsedThroughSetAttachment = "UseTexture is called on a texture that is already used through SetRenderAttachment. Check your code and make sure the texture is only used once."; // Metadata: 0x006622AD
			internal const string k_SetRenderAttachmentTextureAlreadyUsed = "SetRenderAttachment is called on a texture that is already used through UseTexture/SetRenderAttachment. Check your code and make sure the texture is only used once."; // Metadata: 0x0066233F
			internal const string k_SetRenderAttachmentOnDepthTexture = "SetRenderAttachment is called on a texture that has a depth format. Use a texture with a color format instead, or call SetRenderDepthAttachment."; // Metadata: 0x006623E5
			internal const string k_SetRenderAttachmentOnGlobalTexture = "SetRenderAttachment is called on a texture that is currently bound to a global texture slot. Shaders might be using the texture using samplers. Make sure textures are not set as globals when using them as fragment attachments."; // Metadata: 0x00662477
			internal const string k_InvalidResource = "Using an invalid resource. Invalid resources can be resources leftover from a previous execution."; // Metadata: 0x0066255B
			internal const string k_ReadWriteTransient = "This pass is reading or writing a transient resource. Transient resources are always assumed to be both read and written using \'AccessFlags.ReadWrite\'."; // Metadata: 0x006625BE
			internal const string k_MoreThanOneResourceForMRTIndex = "You can only bind a single texture to a single index in a multiple render texture (MRT). Verify your indexes are correct."; // Metadata: 0x00662657
			internal const string k_MoreThanOneTextureForFragInputIndex = "You can only bind a single texture to a fragment input index. Verify your indexes are correct."; // Metadata: 0x006626D2
			internal const string k_MoreThanOneTextureRandomWriteInputIndex = "You can only bind a single texture to a random write input index. Verify your indexes are correct."; // Metadata: 0x00662732
			internal const string k_MultipleDepthTextures = "You can only set a single depth texture per pass."; // Metadata: 0x00662796
			internal const string k_LoadingMemorylessResource = "This pass is loading a resource marked as memoryless."; // Metadata: 0x006627C8
			internal const string k_ResolvignMemorylessResource = "This pass is storing or resolving a resource marked as memoryless"; // Metadata: 0x006627FE
			internal const string k_RenderPassIsEmpty = "Empty render pass"; // Metadata: 0x00662841
			internal const string k_RenderPassHasInvalidProperties = "Invalid render pass properties. One or more properties are zero."; // Metadata: 0x00662853
			internal const string k_ShadingRateImageAttachmentDoesNotMatch = "Low level rendergraph error: Shading rate image attachment in renderpass does not match."; // Metadata: 0x00662895
			internal const string k_AttachmentsDoNotMatch = "Low level rendergraph error: Attachments in renderpass do not match."; // Metadata: 0x006628EF
			internal const string k_MultisampledShaderResolveInvalidAttachmentSetup = "Low level rendergraph error: last subpass with shader resolve must have one color attachment."; // Metadata: 0x00662935
			internal const string k_MultisampledShaderResolveInputAttachmentNotMemoryless = "Low level rendergraph error: last subpass with shader resolve must have all input attachments as memoryless attachments."; // Metadata: 0x00662994
			internal const string k_InvalidMRTSetup = "Multiple render texture (MRT) setup is invalid. Some indices are not used."; // Metadata: 0x00662A0E
			internal const string k_NoDepthBufferMRT = "Setting multiple render textures (MRTs) without a depth buffer is not supported."; // Metadata: 0x00662A5A
			internal const string k_InvalidDepthAndColorTargets = "Neither depth nor color render targets are correctly set up."; // Metadata: 0x00662AAC
			internal const string k_InvalidResourceType = "Invalid resource type, expected texture or buffer"; // Metadata: 0x00662AE9
			internal const string k_NoRenderFunction = "RenderPass was not provided with an execute function."; // Metadata: 0x00662B1B
			internal const string k_BeginNoActivePass = "Compiler error: Pass is marked as beginning a native sub pass but no pass is currently active."; // Metadata: 0x00662B51
			internal const string k_NoActivePassForSubpass = "Compiler error: Generated a subpass pass but no pass is currently active."; // Metadata: 0x00662BB1
	
			// Constructors
			static RenderGraphExceptionMessages(); // 0x0000000181EC6AC0-0x0000000181EC6C40
	
			// Methods
			internal static string MismatchInDimensions(string name, int fragWidth, int fragHeight, int fragVolumeDepth, ResourceUnversionedData resInfo); // 0x0000000181EC6540-0x0000000181EC67F0
			internal static string MismatchInMSAASamlpes(string name, int expectedSamples, int actualSamples); // 0x0000000181EC67F0-0x0000000181EC69A0
			internal static string NoGlobalTextureAtPropertyID(int propertyId); // 0x0000000181EC69A0-0x0000000181EC6A00
			internal static string UseDepthWithColorFormat(GraphicsFormat colorFormat); // 0x0000000181EC6A00-0x0000000181EC6A60
			internal static string UseTransientTextureInWrongPass(int transientIndex); // 0x0000000181EC6A60-0x0000000181EC6AC0
			internal static string IncompatibleTextureUVOrigin(TextureUVOriginSelection origin, string attachmentType, string attachmentName, RenderGraphResourceType attachmentResourceType, int attachmentResourceIndex, TextureUVOriginSelection attachmentOrigin); // 0x0000000181EC6280-0x0000000181EC6540
			internal static string IncompatibleTextureUVOriginUseTexture(TextureUVOriginSelection origin); // 0x0000000181EC61F0-0x0000000181EC6280
			internal static string DepthInputAttachmentNotEnabled(string passName); // 0x0000000181EC5A60-0x0000000181EC5AB0
			internal static string DepthInputAttachmentNotSupported(string passName); // 0x0000000181EC5AB0-0x0000000181EC5C10
			internal static string DepthInputAttachmentWithWriteAccess(string passName); // 0x0000000181EC5CB0-0x0000000181EC5D00
			internal static string DepthInputAttachmentWithInvalidIndex(string passName); // 0x0000000181EC5C60-0x0000000181EC5CB0
			internal static string DepthInputAttachmentWithColorFormat(string passName); // 0x0000000181EC5C10-0x0000000181EC5C60
			internal static string IncompatibleTextureUVOriginStore(string firstAttachmentName, TextureUVOriginSelection firstAttachmentOrigin, string secondAttachmentName, TextureUVOriginSelection secondAttachmentOrigin); // 0x0000000181EC6000-0x0000000181EC61F0
			internal static string GetExceptionMessage(RenderGraphState state); // 0x0000000181EC5D00-0x0000000181EC5F20
			private static string GetHigherCaller(); // 0x0000000181EC5F20-0x0000000181EC6000
		}
	
		private class ProfilingScopePassData // TypeDefIndex: 5893
		{
			// Fields
			public ProfilingSampler sampler; // 0x10
	
			// Constructors
			public ProfilingScopePassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		internal delegate void OnGraphRegisteredDelegate(string graphName); // TypeDefIndex: 5894; 0x00000001804A78A0-0x00000001804A78B0
	
		internal delegate void OnExecutionRegisteredDelegate(string graphName, EntityId executionId, string executionName); // TypeDefIndex: 5895; 0x0000000180A72B30-0x0000000180A72B50
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 5896
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<ProfilingScopePassData, UnsafeGraphContext> __9__123_0; // 0x08
			public static BaseRenderFunc<ProfilingScopePassData, UnsafeGraphContext> __9__124_0; // 0x10
	
			// Constructors
			static __c(); // 0x0000000181ECE650-0x0000000181ECE6C0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _BeginProfilingSampler_b__123_0(ProfilingScopePassData data, UnsafeGraphContext ctx); // 0x00000001802E76C0-0x00000001802E76D0
			internal void _EndProfilingSampler_b__124_0(ProfilingScopePassData data, UnsafeGraphContext ctx); // 0x00000001802E76C0-0x00000001802E76D0
		}
	
		// Constructors
		public RenderGraph(string name = "RenderGraph" /* Metadata: 0x00661BD9 */); // 0x0000000181ECA9C0-0x0000000181ECAF80
		static RenderGraph(); // 0x0000000181ECA920-0x0000000181ECA9C0
	
		// Methods
		[Conditional("UNITY_ENABLE_CHECKS")]
		private void AddPassDebugMetadata(RenderGraphPass renderPass, string file, int line); // 0x00000001802E76C0-0x00000001802E76D0
		[Conditional("UNITY_ENABLE_CHECKS")]
		private void AddResourceDebugMetadata([IsReadOnly] in TextureHandle handle, string file, int line); // 0x00000001802E76C0-0x00000001802E76D0
		[Obsolete("This overload is deprecated, use ImportBackbuffer(RenderTargetIdentifier, RenderTargetInfo, ImportResourceParams) instead.", true)]
		public TextureHandle ImportBackbuffer(RenderTargetIdentifier rt); // 0x0000000180A69580-0x0000000180A69590
		[Obsolete("CreateSharedTexture() and shared texture workflow are deprecated, use ImportTexture() workflow instead.", true)]
		public TextureHandle CreateSharedTexture([IsReadOnly] in TextureDesc desc, bool explicitRelease = false /* Metadata: 0x00661BD3 */); // 0x0000000180A69580-0x0000000180A69590
		[Obsolete("RefreshSharedTextureDesc() and shared texture workflow are deprecated, use ImportTexture() workflow instead.", true)]
		public void RefreshSharedTextureDesc(TextureHandle handle, [IsReadOnly] in TextureDesc desc); // 0x00000001802E76C0-0x00000001802E76D0
		[Obsolete("ReleaseSharedTexture() and shared texture workflow are deprecated, use ImportTexture() workflow instead.", true)]
		public void ReleaseSharedTexture(TextureHandle texture); // 0x00000001802E76C0-0x00000001802E76D0
		[Obsolete("ImportBuffer with forceRelease parameter is deprecated. Use ImportBuffer without it instead. #from(6000.3)", true)]
		public BufferHandle ImportBuffer(GraphicsBuffer graphicsBuffer, bool forceRelease = false /* Metadata: 0x00661BD4 */); // 0x0000000180CC8D20-0x0000000180CC8D30
		[Obsolete("AddRenderPass() is deprecated, use AddRasterRenderPass/AddComputePass/AddUnsafePass() instead.", true)]
		public RenderGraphBuilder AddRenderPass<PassData>(string passName, out ref PassData passData, ProfilingSampler sampler, [CallerFilePath] string file = "" /* Metadata: 0x00661BD5 */, [CallerLineNumber] int line = 0 /* Metadata: 0x00661BD6 */)
			where PassData : class, new();
		[Obsolete("AddRenderPass() is deprecated, use AddRasterRenderPass/AddComputePass/AddUnsafePass() instead.", true)]
		public RenderGraphBuilder AddRenderPass<PassData>(string passName, out ref PassData passData, [CallerFilePath] string file = "" /* Metadata: 0x00661BD7 */, [CallerLineNumber] int line = 0 /* Metadata: 0x00661BD8 */)
			where PassData : class, new();
		internal NativePassCompiler CompileNativeRenderGraph(int graphHash); // 0x0000000181EC7DE0-0x0000000181EC8090
		private void ExecuteNativeRenderGraph(); // 0x0000000181EC8DE0-0x0000000181EC8EE0
		internal void CleanupResourcesAndGraph(); // 0x0000000181EC76F0-0x0000000181EC7840
		public void Cleanup(); // 0x0000000181EC7840-0x0000000181EC7910
		internal List<DebugUI.Widget> GetWidgetList(); // 0x0000000181EC9F10-0x0000000181EC9F30
		public void RegisterDebug(DebugUI.Panel panel = null); // 0x0000000181ECA350-0x0000000181ECA4F0
		public void UnRegisterDebug(); // 0x0000000181ECA7F0-0x0000000181ECA870
		public static List<RenderGraph> GetRegisteredRenderGraphs(); // 0x0000000181EC9D70-0x0000000181EC9E40
		internal static Dictionary<RenderGraph, List<DebugExecutionItem>> GetRegisteredExecutions(); // 0x0000000181EC9D20-0x0000000181EC9D70
		public void EndFrame(); // 0x0000000181EC8A00-0x0000000181EC8A20
		public TextureHandle ImportTexture(RTHandle rt); // 0x0000000181ECA1D0-0x0000000181ECA220
		public TextureHandle ImportShadingRateImageTexture(RTHandle rt); // 0x0000000181ECA030-0x0000000181ECA110
		public TextureHandle ImportTexture(RTHandle rt, ImportResourceParams importParams); // 0x0000000181ECA220-0x0000000181ECA270
		public TextureHandle ImportTexture(RTHandle rt, RenderTargetInfo info, ImportResourceParams importParams = default); // 0x0000000181ECA160-0x0000000181ECA1D0
		internal TextureHandle ImportTexture(RTHandle rt, bool isBuiltin); // 0x0000000181ECA110-0x0000000181ECA160
		public TextureHandle ImportBackbuffer(RenderTargetIdentifier rt, RenderTargetInfo info, ImportResourceParams importParams = default); // 0x0000000181EC9F30-0x0000000181EC9FA0
		public TextureHandle CreateTexture([IsReadOnly] in TextureDesc desc); // 0x0000000181EC8650-0x0000000181EC8690
		private TextureHandle CreateTextureFromDesc([IsReadOnly] in TextureDesc desc); // 0x0000000181EC8650-0x0000000181EC8690
		public TextureHandle CreateTexture(TextureHandle texture); // 0x0000000181EC8860-0x0000000181EC88D0
		public TextureHandle CreateTexture(TextureHandle texture, string name, bool clear = false /* Metadata: 0x00661BE5 */); // 0x0000000181EC8730-0x0000000181EC8860
		public void CreateTextureIfInvalid([IsReadOnly] in TextureDesc desc, ref TextureHandle texture); // 0x0000000181EC8690-0x0000000181EC8730
		public TextureDesc GetTextureDesc([IsReadOnly] in TextureHandle texture); // 0x0000000181EC9E80-0x0000000181EC9EF0
		public RenderTargetInfo GetRenderTargetInfo(TextureHandle texture); // 0x0000000181EC9E40-0x0000000181EC9E80
		public RendererListHandle CreateRendererList([IsReadOnly] in RendererListDesc desc); // 0x0000000181EC8330-0x0000000181EC8370
		public RendererListHandle CreateRendererList([IsReadOnly] in RendererListParams desc); // 0x0000000181EC82F0-0x0000000181EC8330
		public RendererListHandle CreateShadowRendererList(ref ShadowDrawingSettings shadowDrawingSettings); // 0x0000000181EC8370-0x0000000181EC83D0
		public RendererListHandle CreateGizmoRendererList([IsReadOnly] in Camera camera, [IsReadOnly] in GizmoSubset gizmoSubset); // 0x0000000181EC8290-0x0000000181EC82F0
		public RendererListHandle CreateUIOverlayRendererList([IsReadOnly] in Camera camera); // 0x0000000181EC8930-0x0000000181EC89A0
		public RendererListHandle CreateUIOverlayRendererList([IsReadOnly] in Camera camera, [IsReadOnly] in UISubset uiSubset); // 0x0000000181EC88D0-0x0000000181EC8930
		public RendererListHandle CreateWireOverlayRendererList([IsReadOnly] in Camera camera); // 0x0000000181EC89A0-0x0000000181EC8A00
		public RendererListHandle CreateSkyboxRendererList([IsReadOnly] in Camera camera); // 0x0000000181EC85F0-0x0000000181EC8650
		public RendererListHandle CreateSkyboxRendererList([IsReadOnly] in Camera camera, Matrix4x4 projectionMatrix, Matrix4x4 viewMatrix); // 0x0000000181EC83D0-0x0000000181EC84A0
		public RendererListHandle CreateSkyboxRendererList([IsReadOnly] in Camera camera, Matrix4x4 projectionMatrixL, Matrix4x4 viewMatrixL, Matrix4x4 projectionMatrixR, Matrix4x4 viewMatrixR); // 0x0000000181EC84A0-0x0000000181EC85F0
		public BufferHandle ImportBuffer(GraphicsBuffer graphicsBuffer); // 0x0000000181EC9FA0-0x0000000181EC9FE0
		public BufferHandle CreateBuffer([IsReadOnly] in BufferDesc desc); // 0x0000000181EC81D0-0x0000000181EC8220
		public BufferHandle CreateBuffer([IsReadOnly] in BufferHandle graphicsBuffer); // 0x0000000181EC8220-0x0000000181EC8290
		public BufferDesc GetBufferDesc([IsReadOnly] in BufferHandle graphicsBuffer); // 0x0000000181EC9890-0x0000000181EC98E0
		public RayTracingAccelerationStructureHandle ImportRayTracingAccelerationStructure([IsReadOnly] in RayTracingAccelerationStructure accelStruct, string name = null); // 0x0000000181EC9FE0-0x0000000181ECA030
		[Conditional("UNITY_ENABLE_CHECKS")]
		private void CheckNotUsedWhenExecuting(); // 0x0000000181EC7190-0x0000000181EC72A0
		[Conditional("UNITY_ENABLE_CHECKS")]
		private void CheckNotUsedWhenRecordingGraph(); // 0x0000000181EC74D0-0x0000000181EC75E0
		[Conditional("UNITY_ENABLE_CHECKS")]
		private void CheckNotUsedWhenRecordPassOrExecute(); // 0x0000000181EC73B0-0x0000000181EC74D0
		[Conditional("UNITY_ENABLE_CHECKS")]
		private void CheckNotUsedWhenRecordingPass(); // 0x0000000181EC75E0-0x0000000181EC76F0
		[Conditional("UNITY_ENABLE_CHECKS")]
		private void CheckNotUsedWhenActive(); // 0x0000000181EC7080-0x0000000181EC7190
		[Conditional("UNITY_ENABLE_CHECKS")]
		private void CheckNotUsedWhenIdle(); // 0x0000000181EC72A0-0x0000000181EC73B0
		public IRasterRenderGraphBuilder AddRasterRenderPass<PassData>(string passName, out ref PassData passData, [CallerFilePath] string file = "" /* Metadata: 0x00661BE6 */, [CallerLineNumber] int line = 0 /* Metadata: 0x00661BE7 */)
			where PassData : class, new();
		public IRasterRenderGraphBuilder AddRasterRenderPass<PassData>(string passName, out ref PassData passData, ProfilingSampler sampler, [CallerFilePath] string file = "" /* Metadata: 0x00661BE8 */, [CallerLineNumber] int line = 0 /* Metadata: 0x00661BE9 */)
			where PassData : class, new();
		public IComputeRenderGraphBuilder AddComputePass<PassData>(string passName, out ref PassData passData, [CallerFilePath] string file = "" /* Metadata: 0x00661BEA */, [CallerLineNumber] int line = 0 /* Metadata: 0x00661BEB */)
			where PassData : class, new();
		public IComputeRenderGraphBuilder AddComputePass<PassData>(string passName, out ref PassData passData, ProfilingSampler sampler, [CallerFilePath] string file = "" /* Metadata: 0x00661BEC */, [CallerLineNumber] int line = 0 /* Metadata: 0x00661BED */)
			where PassData : class, new();
		public IUnsafeRenderGraphBuilder AddUnsafePass<PassData>(string passName, out ref PassData passData, [CallerFilePath] string file = "" /* Metadata: 0x00661BEE */, [CallerLineNumber] int line = 0 /* Metadata: 0x00661BEF */)
			where PassData : class, new();
		public IUnsafeRenderGraphBuilder AddUnsafePass<PassData>(string passName, out ref PassData passData, ProfilingSampler sampler, [CallerFilePath] string file = "" /* Metadata: 0x00661BF0 */, [CallerLineNumber] int line = 0 /* Metadata: 0x00661BF1 */)
			where PassData : class, new();
		public void BeginRecording([IsReadOnly] in RenderGraphParameters parameters); // 0x0000000181EC6F20-0x0000000181EC7080
		public void EndRecordingAndExecute(); // 0x0000000181EC8CB0-0x0000000181EC8DE0
		public bool ResetGraphAndLogException(Exception e); // 0x0000000181ECA5F0-0x0000000181ECA6E0
		internal void Execute(); // 0x0000000181EC8EE0-0x0000000181EC8F90
		public void BeginProfilingSampler(ProfilingSampler sampler, [CallerFilePath] string file = "" /* Metadata: 0x00661BF2 */, [CallerLineNumber] int line = 0 /* Metadata: 0x00661BF3 */); // 0x0000000181EC6C90-0x0000000181EC6F20
		public void EndProfilingSampler(ProfilingSampler sampler, [CallerFilePath] string file = "" /* Metadata: 0x00661BF4 */, [CallerLineNumber] int line = 0 /* Metadata: 0x00661BF5 */); // 0x0000000181EC8A20-0x0000000181EC8CB0
		internal void ClearCurrentCompiledGraph(); // 0x0000000181EC7AC0-0x0000000181EC7AD0
		private void ClearCompiledGraph(); // 0x0000000181EC7A40-0x0000000181EC7AC0
		private void InvalidateContext(); // 0x0000000181ECA270-0x0000000181ECA2F0
		internal string GetTextureName([IsReadOnly] in TextureHandle textureHandle); // 0x0000000181EC9EF0-0x0000000181EC9F10
		internal int ComputeGraphHash(); // 0x0000000181EC8090-0x0000000181EC81D0
		internal bool GetImportedFallback(TextureDesc desc, out TextureHandle fallback); // 0x0000000181EC9A20-0x0000000181EC9D20
		private void ClearRenderPasses(); // 0x0000000181EC7CB0-0x0000000181EC7DE0
		private ProfilingSampler GetDefaultProfilingSampler(string name); // 0x00000001802E7860-0x00000001802E7870
		private void RegisterGraph(); // 0x0000000181ECA4F0-0x0000000181ECA5F0
		private void UnregisterGraph(); // 0x0000000181ECA870-0x0000000181ECA920
		private static string GetExecutionNameAllocates(EntityId entityId); // 0x0000000181EC98E0-0x0000000181EC99B0
		private void ClearCacheIfNewActiveDebugSession(); // 0x0000000181EC7910-0x0000000181EC7A40
		private void GenerateDebugData(int graphHash); // 0x0000000181EC8F90-0x0000000181EC9890
		internal void SetGlobal([IsReadOnly] in TextureHandle h, int globalPropertyId); // 0x0000000181ECA6E0-0x0000000181ECA7D0
		internal bool IsGlobal(int globalPropertyId); // 0x0000000181ECA2F0-0x0000000181ECA350
		internal Dictionary<int, TextureHandle> AllGlobals(); // 0x0000000181EC6C40-0x0000000181EC6C90
		internal TextureHandle GetGlobal(int globalPropertyId); // 0x0000000181EC99B0-0x0000000181EC9A20
		internal void ClearGlobalBindings(); // 0x0000000181EC7AD0-0x0000000181EC7CB0
		internal void SetIntraFrameMemoryAliasing(bool enabled); // 0x0000000181ECA7D0-0x0000000181ECA7F0
	}
}
