/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Categorization;
using UnityEngine.Rendering.RenderGraphModule;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public static class STP // TypeDefIndex: 5660
	{
		// Fields
		private const int kNumDebugViews = 6; // Metadata: 0x00661772
		private static readonly GUIContent[] s_DebugViewDescriptions; // 0x00
		private static readonly int[] s_DebugViewIndices; // 0x08
		private const int kMaxPerViewConfigs = 2; // Metadata: 0x00661773
		[CompilerGenerated]
		private static PerViewConfig[] _perViewConfigs_k__BackingField; // 0x10
		private const int kNumHistoryTextureTypes = 4; // Metadata: 0x00661774
		private const int kTotalSetupViewConstantsCount = 16; // Metadata: 0x00661775
		private static readonly ProfilingSampler k_StpSetup; // 0x18
		private static readonly ProfilingSampler k_StpPreTaa; // 0x20
		private static readonly ProfilingSampler k_StpTaa; // 0x28
		private static readonly int kQualcommVendorId; // 0x30
	
		// Properties
		public static GUIContent[] debugViewDescriptions { get; } // 0x0000000181E9DB30-0x0000000181E9DB80 
		public static int[] debugViewIndices { get; } // 0x0000000181E9DB80-0x0000000181E9DBD0 
		public static PerViewConfig[] perViewConfigs { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181E9DBD0-0x0000000181E9DC20 0x0000000181E9DC20-0x0000000181E9DC90
	
		// Nested types
		public struct PerViewConfig // TypeDefIndex: 5661
		{
			// Fields
			public Matrix4x4 currentProj; // 0x00
			public Matrix4x4 lastProj; // 0x40
			public Matrix4x4 lastLastProj; // 0x80
			public Matrix4x4 currentView; // 0xC0
			public Matrix4x4 lastView; // 0x100
			public Matrix4x4 lastLastView; // 0x140
		}
	
		public struct Config // TypeDefIndex: 5662
		{
			// Fields
			public Texture2D noiseTexture; // 0x00
			public TextureHandle inputColor; // 0x08
			public TextureHandle inputDepth; // 0x18
			public TextureHandle inputMotion; // 0x28
			public TextureHandle inputStencil; // 0x38
			public TextureHandle debugView; // 0x48
			public TextureHandle destination; // 0x58
			public HistoryContext historyContext; // 0x68
			public bool enableHwDrs; // 0x70
			public bool enableTexArray; // 0x71
			public bool enableMotionScaling; // 0x72
			public float nearPlane; // 0x74
			public float farPlane; // 0x78
			public int frameIndex; // 0x7C
			public bool hasValidHistory; // 0x80
			public int stencilMask; // 0x84
			public int debugViewIndex; // 0x88
			public float deltaTime; // 0x8C
			public float lastDeltaTime; // 0x90
			public Vector2Int currentImageSize; // 0x94
			public Vector2Int priorImageSize; // 0x9C
			public Vector2Int outputImageSize; // 0xA4
			public int numActiveViews; // 0xAC
			public PerViewConfig[] perViewConfigs; // 0xB0
		}
	
		internal enum HistoryTextureType // TypeDefIndex: 5663
		{
			DepthMotion = 0,
			Luma = 1,
			Convergence = 2,
			Feedback = 3,
			Count = 4
		}
	
		public struct HistoryUpdateInfo // TypeDefIndex: 5664
		{
			// Fields
			public Vector2Int preUpscaleSize; // 0x00
			public Vector2Int postUpscaleSize; // 0x08
			public bool useHwDrs; // 0x10
			public bool useTexArray; // 0x11
		}
	
		public sealed class HistoryContext : IDisposable // TypeDefIndex: 5665
		{
			// Fields
			private RTHandle[] m_textures; // 0x10
			private Hash128 m_hash; // 0x18
	
			// Constructors
			public HistoryContext(); // 0x0000000181E8E480-0x0000000181E8E4F0
	
			// Methods
			public bool Update(ref HistoryUpdateInfo info); // 0x0000000181E8DEE0-0x0000000181E8E480
			internal RTHandle GetCurrentHistoryTexture(HistoryTextureType historyType, int frameIndex); // 0x0000000181E8DE60-0x0000000181E8DEA0
			internal RTHandle GetPreviousHistoryTexture(HistoryTextureType historyType, int frameIndex); // 0x0000000181E8DEA0-0x0000000181E8DEE0
			public void Dispose(); // 0x0000000181E8DD90-0x0000000181E8DE60
		}
	
		[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.core@4f216c697b2e\\Runtime\\STP\\STP.cs")]
		private enum StpSetupPerViewConstants // TypeDefIndex: 5666
		{
			Count = 8
		}
	
		[GenerateHLSL(PackingRules.Exact, true, false, false, 1, false, false, false, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.core@4f216c697b2e\\Runtime\\STP\\STP.cs", needAccessors = false, generateCBuffer = true)]
		private struct StpConstantBufferData // TypeDefIndex: 5667
		{
			// Fields
			public Vector4 _StpCommonConstant; // 0x00
			public Vector4 _StpSetupConstants0; // 0x10
			public Vector4 _StpSetupConstants1; // 0x20
			public Vector4 _StpSetupConstants2; // 0x30
			public Vector4 _StpSetupConstants3; // 0x40
			public Vector4 _StpSetupConstants4; // 0x50
			public Vector4 _StpSetupConstants5; // 0x60
			[HLSLArray(16, typeof(Vector4))]
			public unsafe fixed /* 0x00000000-0x00000000 */ float _StpSetupPerViewConstants[0]; // 0x70
			public Vector4 _StpDilConstants0; // 0x170
			public Vector4 _StpTaaConstants0; // 0x180
			public Vector4 _StpTaaConstants1; // 0x190
			public Vector4 _StpTaaConstants2; // 0x1A0
			public Vector4 _StpTaaConstants3; // 0x1B0
	
			// Nested types
			[CompilerGenerated]
			[UnsafeValueType]
			public struct __StpSetupPerViewConstants_e__FixedBuffer // TypeDefIndex: 5668
			{
				// Fields
				public float FixedElementField; // 0x00
			}
		}
	
		private static class ShaderResources // TypeDefIndex: 5669
		{
			// Fields
			public static readonly int _StpConstantBufferData; // 0x00
			public static readonly int _StpBlueNoiseIn; // 0x04
			public static readonly int _StpDebugOut; // 0x08
			public static readonly int _StpInputColor; // 0x0C
			public static readonly int _StpInputDepth; // 0x10
			public static readonly int _StpInputMotion; // 0x14
			public static readonly int _StpInputStencil; // 0x18
			public static readonly int _StpIntermediateColor; // 0x1C
			public static readonly int _StpIntermediateConvergence; // 0x20
			public static readonly int _StpIntermediateWeights; // 0x24
			public static readonly int _StpPriorLuma; // 0x28
			public static readonly int _StpLuma; // 0x2C
			public static readonly int _StpPriorDepthMotion; // 0x30
			public static readonly int _StpDepthMotion; // 0x34
			public static readonly int _StpPriorFeedback; // 0x38
			public static readonly int _StpFeedback; // 0x3C
			public static readonly int _StpPriorConvergence; // 0x40
			public static readonly int _StpConvergence; // 0x44
			public static readonly int _StpOutput; // 0x48
	
			// Constructors
			static ShaderResources(); // 0x0000000181E9E1A0-0x0000000181E9E500
		}
	
		private static class ShaderKeywords // TypeDefIndex: 5670
		{
			// Fields
			public static readonly string EnableDebugMode; // 0x00
			public static readonly string EnableLargeKernel; // 0x08
			public static readonly string EnableStencilResponsive; // 0x10
			public static readonly string DisableTexture2DXArray; // 0x18
	
			// Constructors
			static ShaderKeywords(); // 0x0000000181E9E070-0x0000000181E9E1A0
		}
	
		[Serializable]
		[CategoryInfo(Name = "R: STP", Order = 1000)]
		[ElementInfo(Order = 0)]
		[HideInInspector]
		[SupportedOnRenderPipeline(new Type[0])]
		internal class RuntimeResources : IRenderPipelineResources // TypeDefIndex: 5671
		{
			// Fields
			[ResourcePath("Runtime/STP/StpSetup.compute", SearchType.ProjectPath)]
			[SerializeField]
			private ComputeShader m_setupCS; // 0x10
			[ResourcePath("Runtime/STP/StpPreTaa.compute", SearchType.ProjectPath)]
			[SerializeField]
			private ComputeShader m_preTaaCS; // 0x18
			[ResourcePath("Runtime/STP/StpTaa.compute", SearchType.ProjectPath)]
			[SerializeField]
			private ComputeShader m_taaCS; // 0x20
	
			// Properties
			public int version { get; } // 0x00000001802E7860-0x00000001802E7870 
			public ComputeShader setupCS { get; set; } // 0x0000000180377550-0x0000000180377560 0x0000000181E98970-0x0000000181E989E0
			public ComputeShader preTaaCS { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x0000000181E98900-0x0000000181E98970
			public ComputeShader taaCS { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x0000000181E989E0-0x0000000181E98A50
	
			// Constructors
			public RuntimeResources(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private class SetupData // TypeDefIndex: 5672
		{
			// Fields
			public ComputeShader cs; // 0x10
			public int kernelIndex; // 0x18
			public int viewCount; // 0x1C
			public Vector2Int dispatchSize; // 0x20
			public StpConstantBufferData constantBufferData; // 0x28
			public TextureHandle noiseTexture; // 0x1E8
			public TextureHandle debugView; // 0x1F8
			public TextureHandle inputColor; // 0x208
			public TextureHandle inputDepth; // 0x218
			public TextureHandle inputMotion; // 0x228
			public TextureHandle inputStencil; // 0x238
			public TextureHandle intermediateColor; // 0x248
			public TextureHandle intermediateConvergence; // 0x258
			public TextureHandle priorDepthMotion; // 0x268
			public TextureHandle depthMotion; // 0x278
			public TextureHandle priorLuma; // 0x288
			public TextureHandle luma; // 0x298
			public TextureHandle priorFeedback; // 0x2A8
			public TextureHandle priorConvergence; // 0x2B8
	
			// Constructors
			public SetupData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private class PreTaaData // TypeDefIndex: 5673
		{
			// Fields
			public ComputeShader cs; // 0x10
			public int kernelIndex; // 0x18
			public int viewCount; // 0x1C
			public Vector2Int dispatchSize; // 0x20
			public TextureHandle noiseTexture; // 0x28
			public TextureHandle debugView; // 0x38
			public TextureHandle intermediateConvergence; // 0x48
			public TextureHandle intermediateWeights; // 0x58
			public TextureHandle luma; // 0x68
			public TextureHandle convergence; // 0x78
	
			// Constructors
			public PreTaaData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private class TaaData // TypeDefIndex: 5674
		{
			// Fields
			public ComputeShader cs; // 0x10
			public int kernelIndex; // 0x18
			public int viewCount; // 0x1C
			public Vector2Int dispatchSize; // 0x20
			public TextureHandle noiseTexture; // 0x28
			public TextureHandle debugView; // 0x38
			public TextureHandle intermediateColor; // 0x48
			public TextureHandle intermediateWeights; // 0x58
			public TextureHandle priorFeedback; // 0x68
			public TextureHandle depthMotion; // 0x78
			public TextureHandle convergence; // 0x88
			public TextureHandle feedback; // 0x98
			public TextureHandle output; // 0xA8
	
			// Constructors
			public TaaData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 5675
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<SetupData, ComputeGraphContext> __9__40_0; // 0x08
			public static BaseRenderFunc<PreTaaData, ComputeGraphContext> __9__40_1; // 0x10
			public static BaseRenderFunc<TaaData, ComputeGraphContext> __9__40_2; // 0x18
	
			// Constructors
			static __c(); // 0x0000000181EA1EB0-0x0000000181EA1F20
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Execute_b__40_0(SetupData data, ComputeGraphContext ctx); // 0x0000000181EA11C0-0x0000000181EA1700
			internal void _Execute_b__40_1(PreTaaData data, ComputeGraphContext ctx); // 0x0000000181EA1700-0x0000000181EA19C0
			internal void _Execute_b__40_2(TaaData data, ComputeGraphContext ctx); // 0x0000000181EA19C0-0x0000000181EA1D60
		}
	
		// Constructors
		static STP(); // 0x0000000181E9D5C0-0x0000000181E9DB30
	
		// Methods
		public static bool IsSupported(); // 0x0000000181E9BD10-0x0000000181E9BD40
		public static Vector2 Jit16(int frameIndex); // 0x0000000181E9BD40-0x0000000181E9BD90
		private static Hash128 ComputeHistoryHash(ref HistoryUpdateInfo info); // 0x0000000181E98B30-0x0000000181E98BA0
		private static Vector2Int CalculateConvergenceTextureSize(Vector2Int historyTextureSize); // 0x0000000181E98A50-0x0000000181E98AD0
		private static float CalculateMotionScale(float deltaTime, float lastDeltaTime); // 0x0000000181E98AD0-0x0000000181E98B30
		private static Matrix4x4 ExtractRotation(Matrix4x4 input); // 0x0000000181E9BC60-0x0000000181E9BD10
		private static int PackVector2ToInt(Vector2 value); // 0x0000000181E9BD90-0x0000000181E9BDD0
		private static void PopulateConstantData(ref Config config, ref StpConstantBufferData constants); // 0x0000000181E9BDD0-0x0000000181E9D4D0
		private static TextureHandle UseTexture(IBaseRenderGraphBuilder builder, [IsReadOnly] in TextureHandle texture, AccessFlags flags = AccessFlags.None | AccessFlags.Read /* Metadata: 0x00661771 */); // 0x0000000181E9D4D0-0x0000000181E9D5C0
		public static TextureHandle Execute(RenderGraph renderGraph, ref Config config); // 0x0000000181E98BA0-0x0000000181E9BC60
	}
}
