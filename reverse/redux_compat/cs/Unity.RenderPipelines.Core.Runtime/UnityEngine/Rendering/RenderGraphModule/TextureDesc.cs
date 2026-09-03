/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule
{
	public struct TextureDesc // TypeDefIndex: 5966
	{
		// Fields
		public TextureSizeMode sizeMode; // 0x00
		public int width; // 0x04
		public int height; // 0x08
		public int slices; // 0x0C
		public Vector2 scale; // 0x10
		public ScaleFunc func; // 0x18
		public GraphicsFormat format; // 0x20
		public FilterMode filterMode; // 0x24
		public TextureWrapMode wrapMode; // 0x28
		public TextureDimension dimension; // 0x2C
		public bool enableRandomWrite; // 0x30
		public bool useMipMap; // 0x31
		public bool autoGenerateMips; // 0x32
		public bool isShadowMap; // 0x33
		public int anisoLevel; // 0x34
		public float mipMapBias; // 0x38
		public MSAASamples msaaSamples; // 0x3C
		public bool bindTextureMS; // 0x40
		public bool useDynamicScale; // 0x41
		public bool useDynamicScaleExplicit; // 0x42
		public RenderTextureMemoryless memoryless; // 0x44
		public VRTextureUsage vrUsage; // 0x48
		public bool enableShadingRate; // 0x4C
		public string name; // 0x50
		public FastMemoryDesc fastMemoryDesc; // 0x58
		public bool fallBackToBlackTexture; // 0x64
		public bool disableFallBackToImportedTexture; // 0x65
		public bool clearBuffer; // 0x66
		public Color clearColor; // 0x68
		public bool discardBuffer; // 0x78
	
		// Properties
		public DepthBits depthBufferBits { get; set; } // 0x0000000181EEF5D0-0x0000000181EEF620 0x0000000181EEF620-0x0000000181EEF6B0
		public GraphicsFormat colorFormat { get; set; } // 0x0000000181EEF560-0x0000000181EEF5D0 0x0000000180E332D0-0x0000000180E332E0
	
		// Constructors
		public TextureDesc(int width, int height, bool dynamicResolution = false /* Metadata: 0x00662C41 */, bool xrReady = false /* Metadata: 0x00662C42 */); // 0x0000000181EEF280-0x0000000181EEF2D0
		public TextureDesc(Vector2 scale, bool dynamicResolution = false /* Metadata: 0x00662C43 */, bool xrReady = false /* Metadata: 0x00662C44 */); // 0x0000000181EEF350-0x0000000181EEF3B0
		public TextureDesc(ScaleFunc func, bool dynamicResolution = false /* Metadata: 0x00662C45 */, bool xrReady = false /* Metadata: 0x00662C46 */); // 0x0000000181EEF2D0-0x0000000181EEF350
		public TextureDesc(TextureDesc input); // 0x0000000181EEF3B0-0x0000000181EEF400
		public TextureDesc(RenderTextureDescriptor input); // 0x0000000181EEF400-0x0000000181EEF560
		public TextureDesc(RenderTexture input); // 0x0000000181EEF050-0x0000000181EEF280
	
		// Methods
		private void InitDefaultValues(bool dynamicResolution, bool xrReady); // 0x0000000181EEEF70-0x0000000181EEF050
		public override int GetHashCode(); // 0x0000000181EEEDC0-0x0000000181EEEF70
		public Vector2Int CalculateFinalDimensions(); // 0x0000000181EEECC0-0x0000000181EEEDC0
	}
}
