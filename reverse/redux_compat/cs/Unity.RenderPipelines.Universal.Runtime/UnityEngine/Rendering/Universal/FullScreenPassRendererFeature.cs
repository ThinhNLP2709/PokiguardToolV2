/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Scripting.APIUpdating;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	[MovedFrom("")]
	public class FullScreenPassRendererFeature : ScriptableRendererFeature, ISerializationCallbackReceiver // TypeDefIndex: 9711
	{
		// Fields
		public InjectionPoint injectionPoint; // 0x28
		public bool fetchColorBuffer; // 0x2C
		public ScriptableRenderPassInput requirements; // 0x30
		public Material passMaterial; // 0x38
		public int passIndex; // 0x40
		public bool bindDepthStencilAttachment; // 0x44
		private FullScreenRenderPass m_FullScreenPass; // 0x48
		[HideInInspector]
		[SerializeField]
		private Version m_Version; // 0x50
	
		// Nested types
		public enum InjectionPoint // TypeDefIndex: 9712
		{
			BeforeRenderingTransparents = 450,
			BeforeRenderingPostProcessing = 550,
			AfterRenderingPostProcessing = 600
		}
	
		internal class FullScreenRenderPass : ScriptableRenderPass // TypeDefIndex: 9713
		{
			// Fields
			private Material m_Material; // 0x60
			private int m_PassIndex; // 0x68
			private bool m_FetchActiveColor; // 0x6C
			private bool m_BindDepthStencilAttachment; // 0x6D
			private readonly MaterialPropertyBlock m_MaterialPropertyBlock; // 0x70
	
			// Nested types
			private class MainPassData // TypeDefIndex: 9714
			{
				// Fields
				internal Material material; // 0x10
				internal MaterialPropertyBlock materialPropertyBlock; // 0x18
				internal int passIndex; // 0x20
				internal TextureHandle source; // 0x24
				internal TextureHandle destination; // 0x34
	
				// Constructors
				public MainPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
			}
	
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 9715
			{
				// Fields
				public static readonly __c __9; // 0x00
				public static BaseRenderFunc<MainPassData, RasterGraphContext> __9__9_0; // 0x08
	
				// Constructors
				static __c(); // 0x0000000181FD7110-0x0000000181FD7180
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal void _AddFullscreenRenderPassInputPass_b__9_0(MainPassData data, RasterGraphContext rgContext); // 0x0000000181FD59C0-0x0000000181FD5C20
			}
	
			// Constructors
			public FullScreenRenderPass(string passName); // 0x0000000181FC4340-0x0000000181FC43F0
	
			// Methods
			public void SetupMembers(Material material, int passIndex, bool fetchActiveColor, bool bindDepthStencilAttachment); // 0x0000000181FC42F0-0x0000000181FC4340
			private static void ExecuteMainPass(RasterCommandBuffer cmd, MaterialPropertyBlock mbp, RTHandle sourceTexture, Material material, int passIndex, Vector4 blitScaleBias); // 0x0000000181FC3D80-0x0000000181FC3F20
			public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000181FC3F20-0x0000000181FC42F0
			private void AddFullscreenRenderPassInputPass(RenderGraph renderGraph, UniversalResourceData resourcesData, UniversalCameraData cameraData, [IsReadOnly] in TextureHandle source, [IsReadOnly] in TextureHandle destination); // 0x0000000181FC3340-0x0000000181FC3D80
		}
	
		private enum Version // TypeDefIndex: 9716
		{
			Uninitialised = -1,
			Initial = 0,
			AddFetchColorBufferCheckbox = 1,
			Latest = 1,
			Count = 2
		}
	
		// Constructors
		public FullScreenPassRendererFeature(); // 0x0000000181FC3320-0x0000000181FC3340
	
		// Methods
		public override void Create(); // 0x0000000181FC3170-0x0000000181FC3270
		internal override bool RequireRenderingLayers(bool isDeferred, bool needsGBufferAccurateNormals, out RenderingLayerUtils.Event atEvent, out RenderingLayerUtils.MaskSize maskSize); // 0x0000000181FC32E0-0x0000000181FC3300
		internal bool IsCompatibleWithTileOnlyMode(); // 0x0000000181FC3270-0x0000000181FC32E0
		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData); // 0x0000000181FC2DA0-0x0000000181FC3170
		private void UpgradeIfNeeded(); // 0x00000001802E76C0-0x00000001802E76D0
		void ISerializationCallbackReceiver.OnBeforeSerialize(); // 0x0000000181FC3310-0x0000000181FC3320
		void ISerializationCallbackReceiver.OnAfterDeserialize(); // 0x0000000181FC3300-0x0000000181FC3310
	}
}
