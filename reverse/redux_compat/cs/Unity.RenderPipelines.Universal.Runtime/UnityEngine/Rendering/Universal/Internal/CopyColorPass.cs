/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal.Internal
{
	public class CopyColorPass : ScriptableRenderPass // TypeDefIndex: 9903
	{
		// Fields
		private int m_SampleOffsetShaderHandle; // 0x60
		private Material m_SamplingMaterial; // 0x68
		private Downsampling m_DownsamplingMethod; // 0x70
		private Material m_CopyColorMaterial; // 0x78
		private static readonly string k_CopyColorPassName; // 0x00
		private static readonly string k_DownsampleAndCopyPassName; // 0x08
	
		// Nested types
		private class PassData // TypeDefIndex: 9904
		{
			// Fields
			internal TextureHandle source; // 0x10
			internal TextureHandle destination; // 0x20
			internal bool useProceduralBlit; // 0x30
			internal Material samplingMaterial; // 0x38
			internal Material copyColorMaterial; // 0x40
			internal Downsampling downsamplingMethod; // 0x48
			internal int sampleOffsetShaderHandle; // 0x4C
	
			// Constructors
			public PassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9905
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<PassData, RasterGraphContext> __9__16_0; // 0x08
	
			// Constructors
			static __c(); // 0x00000001820415F0-0x0000000182041660
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _AddDownsampleAndCopyColorRenderPass_b__16_0(PassData data, RasterGraphContext context); // 0x000000018203FFA0-0x0000000182040080
		}
	
		// Constructors
		public CopyColorPass(RenderPassEvent evt, Material samplingMaterial, Material copyColorMaterial = null, string customPassName = null); // 0x0000000182032630-0x0000000182032760
		static CopyColorPass(); // 0x0000000182032580-0x0000000182032630
	
		// Methods
		public static void ConfigureDescriptor(Downsampling downsamplingMethod, ref RenderTextureDescriptor descriptor, out FilterMode filterMode); // 0x0000000182031B40-0x0000000182031BC0
		internal static void ConfigureDescriptor(Downsampling downsamplingMethod, ref TextureDesc descriptor, out FilterMode filterMode); // 0x0000000182031AC0-0x0000000182031B40
		[Obsolete("Use RTHandles for source and destination #from(2022.1) #breakingFrom(2023.1).", true)]
		public void Setup(RenderTargetIdentifier source, RenderTargetHandle destination, Downsampling downsampling); // 0x0000000182032530-0x0000000182032580
		public void Setup(RTHandle source, RTHandle destination, Downsampling downsampling); // 0x0000000182032520-0x0000000182032530
		private static void ExecutePass(RasterCommandBuffer cmd, PassData passData, RTHandle source, bool useDrawProceduralBlit); // 0x0000000182031BC0-0x0000000182031ED0
		internal TextureHandle Render(RenderGraph renderGraph, ContextContainer frameData, out TextureHandle destination, [IsReadOnly] in TextureHandle source, Downsampling downsampling); // 0x0000000182032280-0x0000000182032520
		internal void RenderToExistingTexture(RenderGraph renderGraph, ContextContainer frameData, [IsReadOnly] in TextureHandle destination, [IsReadOnly] in TextureHandle source, Downsampling downsampling = Downsampling.None /* Metadata: 0x0069FD7D */); // 0x00000001820321D0-0x0000000182032280
		private void RenderInternal(RenderGraph renderGraph, [IsReadOnly] in TextureHandle destination, [IsReadOnly] in TextureHandle source, bool useProceduralBlit); // 0x0000000182031ED0-0x00000001820321D0
		private void AddDownsampleAndCopyColorRenderPass(RenderGraph renderGraph, [IsReadOnly] in TextureHandle destination, [IsReadOnly] in TextureHandle source, bool useProceduralBlit, string passName); // 0x0000000182031630-0x0000000182031AC0
	}
}
