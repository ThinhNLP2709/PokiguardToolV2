/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public class RTHandleSystem : IDisposable // TypeDefIndex: 5715
	{
		// Fields
		private bool m_HardwareDynamicResRequested; // 0x10
		private HashSet<RTHandle> m_AutoSizedRTs; // 0x18
		private RTHandle[] m_AutoSizedRTsArray; // 0x20
		private HashSet<RTHandle> m_ResizeOnDemandRTs; // 0x28
		private RTHandleProperties m_RTHandleProperties; // 0x30
		private int m_MaxWidths; // 0x60
		private int m_MaxHeights; // 0x64
	
		// Properties
		public RTHandleProperties rtHandleProperties { get; } // 0x0000000181C77EB0-0x0000000181C77ED0 
	
		// Nested types
		internal enum ResizeMode // TypeDefIndex: 5716
		{
			Auto = 0,
			OnDemand = 1
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 5717
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static ScaleFunc __9__32_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181EA1F90-0x0000000181EA2000
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal Vector2Int _Alloc_b__32_0(Vector2Int refSize); // 0x0000000181EA11B0-0x0000000181EA11C0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass37_0 // TypeDefIndex: 5718
		{
			// Fields
			public Vector2 scaleFactor; // 0x10
	
			// Constructors
			public __c__DisplayClass37_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal Vector2Int _Alloc_b__0(Vector2Int refSize); // 0x0000000181EA1E00-0x0000000181EA1E80
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass41_0 // TypeDefIndex: 5719
		{
			// Fields
			public ScaleFunc scaleFunc; // 0x10
	
			// Constructors
			public __c__DisplayClass41_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal Vector2Int _Alloc_b__0(Vector2Int refSize); // 0x0000000181EA1E80-0x0000000181EA1EB0
		}
	
		// Constructors
		public RTHandleSystem(); // 0x0000000181E95E40-0x0000000181E95F00
	
		// Methods
		public void Dispose(); // 0x0000000181E94D80-0x0000000181E94D90
		public void Initialize(int width, int height); // 0x0000000181E951E0-0x0000000181E95480
		[Obsolete("useLegacyDynamicResControl is deprecated. Please use SetHardwareDynamicResolutionState() instead. #from(2023.3)")]
		public void Initialize(int width, int height, bool useLegacyDynamicResControl = false /* Metadata: 0x006617F1 */); // 0x0000000181E951B0-0x0000000181E951E0
		public void Release(RTHandle rth); // 0x0000000181E95480-0x0000000181E954A0
		internal void Remove(RTHandle rth); // 0x0000000181E954A0-0x0000000181E95500
		public void ResetReferenceSize(int width, int height); // 0x0000000181E95500-0x0000000181E95530
		public void SetReferenceSize(int width, int height); // 0x0000000181E95D20-0x0000000181E95D40
		public void SetReferenceSize(int width, int height, bool reset); // 0x0000000181E95B10-0x0000000181E95D20
		internal Vector2 CalculateRatioAgainstMaxSize([IsReadOnly] in Vector2Int viewportSize); // 0x0000000181E94120-0x0000000181E94330
		public void SetHardwareDynamicResolutionState(bool enableHWDynamicRes); // 0x0000000181E95970-0x0000000181E95B10
		internal void SwitchResizeMode(RTHandle rth, ResizeMode mode); // 0x0000000181E95D40-0x0000000181E95E40
		private void DemandResize(RTHandle rth); // 0x0000000181E94890-0x0000000181E94BA0
		public int GetMaxWidth(); // 0x000000018150C180-0x000000018150C190
		public int GetMaxHeight(); // 0x00000001802F2020-0x00000001802F2030
		private void Dispose(bool disposing); // 0x0000000181E94BA0-0x0000000181E94D80
		private void Resize(int width, int height, bool sizeChanged); // 0x0000000181E95530-0x0000000181E95970
		public RTHandle Alloc(int width, int height, int slices = 1 /* Metadata: 0x006617F2 */, DepthBits depthBufferBits = DepthBits.None /* Metadata: 0x006617F3 */, GraphicsFormat colorFormat = GraphicsFormat.R8G8B8A8_SRGB /* Metadata: 0x006617F4 */, FilterMode filterMode = FilterMode.Point /* Metadata: 0x006617F5 */, TextureWrapMode wrapMode = TextureWrapMode.Repeat /* Metadata: 0x006617F6 */, TextureDimension dimension = TextureDimension.Tex2D /* Metadata: 0x006617F7 */, bool enableRandomWrite = false /* Metadata: 0x006617F8 */, bool useMipMap = false /* Metadata: 0x006617F9 */, bool autoGenerateMips = true /* Metadata: 0x006617FA */, bool isShadowMap = false /* Metadata: 0x006617FB */, int anisoLevel = 1 /* Metadata: 0x006617FC */, float mipMapBias = 0f /* Metadata: 0x006617FD */, MSAASamples msaaSamples = MSAASamples.None /* Metadata: 0x00661801 */, bool bindTextureMS = false /* Metadata: 0x00661802 */, bool useDynamicScale = false /* Metadata: 0x00661803 */, bool useDynamicScaleExplicit = false /* Metadata: 0x00661804 */, RenderTextureMemoryless memoryless = RenderTextureMemoryless.None /* Metadata: 0x00661805 */, VRTextureUsage vrUsage = VRTextureUsage.None /* Metadata: 0x00661806 */, string name = "" /* Metadata: 0x00661807 */); // 0x0000000181E92970-0x0000000181E92B00
		public RTHandle Alloc(int width, int height, GraphicsFormat format, int slices = 1 /* Metadata: 0x00661808 */, FilterMode filterMode = FilterMode.Point /* Metadata: 0x00661809 */, TextureWrapMode wrapMode = TextureWrapMode.Repeat /* Metadata: 0x0066180A */, TextureDimension dimension = TextureDimension.Tex2D /* Metadata: 0x0066180B */, bool enableRandomWrite = false /* Metadata: 0x0066180C */, bool useMipMap = false /* Metadata: 0x0066180D */, bool autoGenerateMips = true /* Metadata: 0x0066180E */, bool isShadowMap = false /* Metadata: 0x0066180F */, int anisoLevel = 1 /* Metadata: 0x00661810 */, float mipMapBias = 0f /* Metadata: 0x00661811 */, MSAASamples msaaSamples = MSAASamples.None /* Metadata: 0x00661815 */, bool bindTextureMS = false /* Metadata: 0x00661816 */, bool useDynamicScale = false /* Metadata: 0x00661817 */, bool useDynamicScaleExplicit = false /* Metadata: 0x00661818 */, RenderTextureMemoryless memoryless = RenderTextureMemoryless.None /* Metadata: 0x00661819 */, VRTextureUsage vrUsage = VRTextureUsage.None /* Metadata: 0x0066181A */, string name = "" /* Metadata: 0x0066181B */); // 0x0000000181E93D30-0x0000000181E93E20
		public RTHandle Alloc(int width, int height, TextureWrapMode wrapModeU, TextureWrapMode wrapModeV, TextureWrapMode wrapModeW = TextureWrapMode.Repeat /* Metadata: 0x0066181C */, int slices = 1 /* Metadata: 0x0066181D */, DepthBits depthBufferBits = DepthBits.None /* Metadata: 0x0066181E */, GraphicsFormat colorFormat = GraphicsFormat.R8G8B8A8_SRGB /* Metadata: 0x0066181F */, FilterMode filterMode = FilterMode.Point /* Metadata: 0x00661820 */, TextureDimension dimension = TextureDimension.Tex2D /* Metadata: 0x00661821 */, bool enableRandomWrite = false /* Metadata: 0x00661822 */, bool useMipMap = false /* Metadata: 0x00661823 */, bool autoGenerateMips = true /* Metadata: 0x00661824 */, bool isShadowMap = false /* Metadata: 0x00661825 */, int anisoLevel = 1 /* Metadata: 0x00661826 */, float mipMapBias = 0f /* Metadata: 0x00661827 */, MSAASamples msaaSamples = MSAASamples.None /* Metadata: 0x0066182B */, bool bindTextureMS = false /* Metadata: 0x0066182C */, bool useDynamicScale = false /* Metadata: 0x0066182D */, bool useDynamicScaleExplicit = false /* Metadata: 0x0066182E */, RenderTextureMemoryless memoryless = RenderTextureMemoryless.None /* Metadata: 0x0066182F */, VRTextureUsage vrUsage = VRTextureUsage.None /* Metadata: 0x00661830 */, string name = "" /* Metadata: 0x00661831 */); // 0x0000000181E930B0-0x0000000181E93250
		public RTHandle Alloc(int width, int height, GraphicsFormat format, TextureWrapMode wrapModeU, TextureWrapMode wrapModeV, TextureWrapMode wrapModeW = TextureWrapMode.Repeat /* Metadata: 0x00661832 */, int slices = 1 /* Metadata: 0x00661833 */, FilterMode filterMode = FilterMode.Point /* Metadata: 0x00661834 */, TextureDimension dimension = TextureDimension.Tex2D /* Metadata: 0x00661835 */, bool enableRandomWrite = false /* Metadata: 0x00661836 */, bool useMipMap = false /* Metadata: 0x00661837 */, bool autoGenerateMips = true /* Metadata: 0x00661838 */, bool isShadowMap = false /* Metadata: 0x00661839 */, int anisoLevel = 1 /* Metadata: 0x0066183A */, float mipMapBias = 0f /* Metadata: 0x0066183B */, MSAASamples msaaSamples = MSAASamples.None /* Metadata: 0x0066183F */, bool bindTextureMS = false /* Metadata: 0x00661840 */, bool useDynamicScale = false /* Metadata: 0x00661841 */, bool useDynamicScaleExplicit = false /* Metadata: 0x00661842 */, RenderTextureMemoryless memoryless = RenderTextureMemoryless.None /* Metadata: 0x00661843 */, VRTextureUsage vrUsage = VRTextureUsage.None /* Metadata: 0x00661844 */, string name = "" /* Metadata: 0x00661845 */); // 0x0000000181E92CD0-0x0000000181E92EF0
		private RenderTexture CreateRenderTexture(int width, int height, GraphicsFormat format, int slices, FilterMode filterMode, TextureWrapMode wrapModeU, TextureWrapMode wrapModeV, TextureWrapMode wrapModeW, TextureDimension dimension, bool enableRandomWrite, bool useMipMap, bool autoGenerateMips, bool isShadowMap, int anisoLevel, float mipMapBias, MSAASamples msaaSamples, bool bindTextureMS, bool useDynamicScale, bool useDynamicScaleExplicit, RenderTextureMemoryless memoryless, VRTextureUsage vrUsage, bool enableShadingRate, string name); // 0x0000000181E94330-0x0000000181E94890
		public RTHandle Alloc(int width, int height, RTHandleAllocInfo info); // 0x0000000181E93250-0x0000000181E934E0
		public Vector2Int CalculateDimensions(Vector2 scaleFactor); // 0x0000000181E94040-0x0000000181E940B0
		private static Vector2Int CalculateDimensions(Vector2 scaleFactor, Vector2Int size); // 0x0000000181E940B0-0x0000000181E94120
		public RTHandle Alloc(Vector2 scaleFactor, GraphicsFormat format, int slices = 1 /* Metadata: 0x00661846 */, FilterMode filterMode = FilterMode.Point /* Metadata: 0x00661847 */, TextureWrapMode wrapMode = TextureWrapMode.Repeat /* Metadata: 0x00661848 */, TextureDimension dimension = TextureDimension.Tex2D /* Metadata: 0x00661849 */, bool enableRandomWrite = false /* Metadata: 0x0066184A */, bool useMipMap = false /* Metadata: 0x0066184B */, bool autoGenerateMips = true /* Metadata: 0x0066184C */, bool isShadowMap = false /* Metadata: 0x0066184D */, int anisoLevel = 1 /* Metadata: 0x0066184E */, float mipMapBias = 0f /* Metadata: 0x0066184F */, MSAASamples msaaSamples = MSAASamples.None /* Metadata: 0x00661853 */, bool bindTextureMS = false /* Metadata: 0x00661854 */, bool useDynamicScale = false /* Metadata: 0x00661855 */, bool useDynamicScaleExplicit = false /* Metadata: 0x00661856 */, RenderTextureMemoryless memoryless = RenderTextureMemoryless.None /* Metadata: 0x00661857 */, VRTextureUsage vrUsage = VRTextureUsage.None /* Metadata: 0x00661858 */, string name = "" /* Metadata: 0x00661859 */); // 0x0000000181E93B00-0x0000000181E93CD0
		public RTHandle Alloc(Vector2 scaleFactor, int slices = 1 /* Metadata: 0x0066185A */, DepthBits depthBufferBits = DepthBits.None /* Metadata: 0x0066185B */, GraphicsFormat colorFormat = GraphicsFormat.R8G8B8A8_SRGB /* Metadata: 0x0066185C */, FilterMode filterMode = FilterMode.Point /* Metadata: 0x0066185D */, TextureWrapMode wrapMode = TextureWrapMode.Repeat /* Metadata: 0x0066185E */, TextureDimension dimension = TextureDimension.Tex2D /* Metadata: 0x0066185F */, bool enableRandomWrite = false /* Metadata: 0x00661860 */, bool useMipMap = false /* Metadata: 0x00661861 */, bool autoGenerateMips = true /* Metadata: 0x00661862 */, bool isShadowMap = false /* Metadata: 0x00661863 */, int anisoLevel = 1 /* Metadata: 0x00661864 */, float mipMapBias = 0f /* Metadata: 0x00661865 */, MSAASamples msaaSamples = MSAASamples.None /* Metadata: 0x00661869 */, bool bindTextureMS = false /* Metadata: 0x0066186A */, bool useDynamicScale = false /* Metadata: 0x0066186B */, bool useDynamicScaleExplicit = false /* Metadata: 0x0066186C */, RenderTextureMemoryless memoryless = RenderTextureMemoryless.None /* Metadata: 0x0066186D */, VRTextureUsage vrUsage = VRTextureUsage.None /* Metadata: 0x0066186E */, string name = "" /* Metadata: 0x0066186F */); // 0x0000000181E93730-0x0000000181E938B0
		public RTHandle Alloc(Vector2 scaleFactor, RTHandleAllocInfo info); // 0x0000000181E92EF0-0x0000000181E930B0
		public Vector2Int CalculateDimensions(ScaleFunc scaleFunc); // 0x0000000181E93FE0-0x0000000181E94040
		public RTHandle Alloc(ScaleFunc scaleFunc, int slices = 1 /* Metadata: 0x00661870 */, DepthBits depthBufferBits = DepthBits.None /* Metadata: 0x00661871 */, GraphicsFormat colorFormat = GraphicsFormat.R8G8B8A8_SRGB /* Metadata: 0x00661872 */, FilterMode filterMode = FilterMode.Point /* Metadata: 0x00661873 */, TextureWrapMode wrapMode = TextureWrapMode.Repeat /* Metadata: 0x00661874 */, TextureDimension dimension = TextureDimension.Tex2D /* Metadata: 0x00661875 */, bool enableRandomWrite = false /* Metadata: 0x00661876 */, bool useMipMap = false /* Metadata: 0x00661877 */, bool autoGenerateMips = true /* Metadata: 0x00661878 */, bool isShadowMap = false /* Metadata: 0x00661879 */, int anisoLevel = 1 /* Metadata: 0x0066187A */, float mipMapBias = 0f /* Metadata: 0x0066187B */, MSAASamples msaaSamples = MSAASamples.None /* Metadata: 0x0066187F */, bool bindTextureMS = false /* Metadata: 0x00661880 */, bool useDynamicScale = false /* Metadata: 0x00661881 */, bool useDynamicScaleExplicit = false /* Metadata: 0x00661882 */, RenderTextureMemoryless memoryless = RenderTextureMemoryless.None /* Metadata: 0x00661883 */, VRTextureUsage vrUsage = VRTextureUsage.None /* Metadata: 0x00661884 */, string name = "" /* Metadata: 0x00661885 */); // 0x0000000181E93990-0x0000000181E93B00
		public RTHandle Alloc(ScaleFunc scaleFunc, GraphicsFormat format, int slices = 1 /* Metadata: 0x00661886 */, FilterMode filterMode = FilterMode.Point /* Metadata: 0x00661887 */, TextureWrapMode wrapMode = TextureWrapMode.Repeat /* Metadata: 0x00661888 */, TextureDimension dimension = TextureDimension.Tex2D /* Metadata: 0x00661889 */, bool enableRandomWrite = false /* Metadata: 0x0066188A */, bool useMipMap = false /* Metadata: 0x0066188B */, bool autoGenerateMips = true /* Metadata: 0x0066188C */, bool isShadowMap = false /* Metadata: 0x0066188D */, int anisoLevel = 1 /* Metadata: 0x0066188E */, float mipMapBias = 0f /* Metadata: 0x0066188F */, MSAASamples msaaSamples = MSAASamples.None /* Metadata: 0x00661893 */, bool bindTextureMS = false /* Metadata: 0x00661894 */, bool useDynamicScale = false /* Metadata: 0x00661895 */, bool useDynamicScaleExplicit = false /* Metadata: 0x00661896 */, RenderTextureMemoryless memoryless = RenderTextureMemoryless.None /* Metadata: 0x00661897 */, VRTextureUsage vrUsage = VRTextureUsage.None /* Metadata: 0x00661898 */, string name = "" /* Metadata: 0x00661899 */); // 0x0000000181E92B00-0x0000000181E92CD0
		public RTHandle Alloc(ScaleFunc scaleFunc, RTHandleAllocInfo info); // 0x0000000181E93E20-0x0000000181E93FE0
		internal RTHandle AllocAutoSizedRenderTexture(int width, int height, int slices, GraphicsFormat format, FilterMode filterMode, TextureWrapMode wrapMode, TextureDimension dimension, bool enableRandomWrite, bool useMipMap, bool autoGenerateMips, bool isShadowMap, int anisoLevel, float mipMapBias, MSAASamples msaaSamples, bool bindTextureMS, bool useDynamicScale, bool useDynamicScaleExplicit, RenderTextureMemoryless memoryless, VRTextureUsage vrUsage, bool enableShadingRate, string name); // 0x0000000181E92740-0x0000000181E92970
		internal RTHandle AllocAutoSizedRenderTexture(int width, int height, RTHandleAllocInfo info); // 0x0000000181E92560-0x0000000181E92740
		public RTHandle Alloc(RenderTexture texture, bool transferOwnership = false /* Metadata: 0x0066189A */); // 0x0000000181E93660-0x0000000181E93730
		public RTHandle Alloc(Texture texture); // 0x0000000181E93550-0x0000000181E93660
		public RTHandle Alloc(RenderTargetIdentifier texture); // 0x0000000181E934E0-0x0000000181E93550
		public RTHandle Alloc(RenderTargetIdentifier texture, string name); // 0x0000000181E938B0-0x0000000181E93990
		private static RTHandle Alloc(RTHandle tex); // 0x0000000181E93CD0-0x0000000181E93D30
		internal string DumpRTInfo(); // 0x0000000181E94D90-0x0000000181E95140
		private GraphicsFormat GetStencilFormat(GraphicsFormat depthStencilFormat); // 0x0000000181E95140-0x0000000181E951B0
	}
}
