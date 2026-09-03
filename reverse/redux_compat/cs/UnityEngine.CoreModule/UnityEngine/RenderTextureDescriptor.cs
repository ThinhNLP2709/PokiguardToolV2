/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Internal;
using UnityEngine.Rendering;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	public struct RenderTextureDescriptor // TypeDefIndex: 7638
	{
		// Fields
		[CompilerGenerated]
		private int _width_k__BackingField; // 0x00
		[CompilerGenerated]
		private int _height_k__BackingField; // 0x04
		[CompilerGenerated]
		private int _msaaSamples_k__BackingField; // 0x08
		[CompilerGenerated]
		private int _volumeDepth_k__BackingField; // 0x0C
		[CompilerGenerated]
		private int _mipCount_k__BackingField; // 0x10
		private GraphicsFormat _graphicsFormat; // 0x14
		[CompilerGenerated]
		private GraphicsFormat _stencilFormat_k__BackingField; // 0x18
		[CompilerGenerated]
		private GraphicsFormat _depthStencilFormat_k__BackingField; // 0x1C
		[CompilerGenerated]
		private TextureDimension _dimension_k__BackingField; // 0x20
		[CompilerGenerated]
		private ShadowSamplingMode _shadowSamplingMode_k__BackingField; // 0x24
		[CompilerGenerated]
		private VRTextureUsage _vrUsage_k__BackingField; // 0x28
		private RenderTextureCreationFlags _flags; // 0x2C
		[CompilerGenerated]
		private RenderTextureMemoryless _memoryless_k__BackingField; // 0x30
	
		// Properties
		public int width { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
		public int height { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802E7C60-0x00000001802E7DA0 0x0000000180732D40-0x0000000180732D50
		public int msaaSamples { [CompilerGenerated] [IsReadOnly] get; [CompilerGenerated] set; } // 0x0000000180732D20-0x0000000180732D30 0x0000000180732D60-0x0000000180732D70
		public int volumeDepth { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180732D30-0x0000000180732D40 0x0000000180732D70-0x0000000180732D80
		public int mipCount { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
		public GraphicsFormat graphicsFormat { get; set; } // 0x0000000180A5E110-0x0000000180A5E120 0x00000001821D0AB0-0x00000001821D0B20
		public GraphicsFormat stencilFormat { [CompilerGenerated] set; } // 0x0000000180F9EB90-0x0000000180F9EBA0
		public GraphicsFormat depthStencilFormat { [CompilerGenerated] [IsReadOnly] get; [CompilerGenerated] set; } // 0x0000000180B232F0-0x0000000180B23300 0x0000000180E025C0-0x0000000180E025D0
		public RenderTextureFormat colorFormat { get; set; } // 0x00000001821D0710-0x00000001821D0780 0x00000001821D08B0-0x00000001821D0A20
		public bool sRGB { get; set; } // 0x00000001821D07F0-0x00000001821D0840 0x00000001821D0B20-0x00000001821D0C00
		public int depthBufferBits { get; set; } // 0x00000001821D0780-0x00000001821D07D0 0x00000001821D0A40-0x00000001821D0A70
		public TextureDimension dimension { [CompilerGenerated] [IsReadOnly] get; [CompilerGenerated] set; } // 0x0000000180C4F680-0x0000000180C4F690 0x0000000180E332D0-0x0000000180E332E0
		public ShadowSamplingMode shadowSamplingMode { [CompilerGenerated] [IsReadOnly] get; [CompilerGenerated] set; } // 0x0000000180D17D10-0x0000000180D17D20 0x0000000180E02560-0x0000000180E02570
		public VRTextureUsage vrUsage { [CompilerGenerated] [IsReadOnly] get; [CompilerGenerated] set; } // 0x0000000180377930-0x0000000180377940 0x0000000180378100-0x0000000180378110
		public RenderTextureMemoryless memoryless { [CompilerGenerated] [IsReadOnly] get; [CompilerGenerated] set; } // 0x000000018033D100-0x000000018033D110 0x000000018033E780-0x000000018033E790
		public bool useMipMap { get; set; } // 0x00000001821D0860-0x00000001821D0870 0x00000001821D0C40-0x00000001821D0C60
		public bool autoGenerateMips { get; set; } // 0x00000001821D06F0-0x00000001821D0700 0x00000001821D0870-0x00000001821D0890
		public bool enableRandomWrite { get; set; } // 0x00000001821D07D0-0x00000001821D07E0 0x00000001821D0A70-0x00000001821D0A90
		public bool bindMS { get; set; } // 0x00000001821D0700-0x00000001821D0710 0x00000001821D0890-0x00000001821D08B0
		internal bool createdFromScript { set; } // 0x00000001821D0A20-0x00000001821D0A40
		public bool useDynamicScale { get; set; } // 0x00000001821D0850-0x00000001821D0860 0x00000001821D0C20-0x00000001821D0C40
		public bool useDynamicScaleExplicit { get; set; } // 0x00000001821D0840-0x00000001821D0850 0x00000001821D0C00-0x00000001821D0C20
		public bool enableShadingRate { get; set; } // 0x00000001821D07E0-0x00000001821D07F0 0x00000001821D0A90-0x00000001821D0AB0
	
		// Constructors
		[ExcludeFromDocs]
		public RenderTextureDescriptor(int width, int height); // 0x00000001821CFC80-0x00000001821CFDE0
		[ExcludeFromDocs]
		public RenderTextureDescriptor(int width, int height, RenderTextureFormat colorFormat); // 0x00000001821D01D0-0x00000001821D0350
		[ExcludeFromDocs]
		public RenderTextureDescriptor(int width, int height, RenderTextureFormat colorFormat, int depthBufferBits); // 0x00000001821D0570-0x00000001821D06F0
		[ExcludeFromDocs]
		public RenderTextureDescriptor(int width, int height, GraphicsFormat colorFormat, int depthBufferBits); // 0x00000001821CFDE0-0x00000001821CFF10
		[ExcludeFromDocs]
		public RenderTextureDescriptor(int width, int height, RenderTextureFormat colorFormat, int depthBufferBits, int mipCount); // 0x00000001821CFFB0-0x00000001821D0100
		public RenderTextureDescriptor(int width, int height, [DefaultValue("RenderTextureFormat.Default")] RenderTextureFormat colorFormat, [DefaultValue("0")] int depthBufferBits, [DefaultValue("Texture.GenerateAllMips")] int mipCount, [DefaultValue("RenderTextureReadWrite.Linear")] RenderTextureReadWrite readWrite); // 0x00000001821D0420-0x00000001821D0570
		[ExcludeFromDocs]
		public RenderTextureDescriptor(int width, int height, GraphicsFormat colorFormat, int depthBufferBits, int mipCount); // 0x00000001821D0350-0x00000001821D0420
		[ExcludeFromDocs]
		public RenderTextureDescriptor(int width, int height, GraphicsFormat colorFormat, GraphicsFormat depthStencilFormat); // 0x00000001821CFF10-0x00000001821CFFB0
		[ExcludeFromDocs]
		public RenderTextureDescriptor(int width, int height, GraphicsFormat colorFormat, GraphicsFormat depthStencilFormat, int mipCount); // 0x00000001821D0100-0x00000001821D01D0
	
		// Methods
		private void SetOrClearRenderTextureCreationFlag(bool value, RenderTextureCreationFlags flag); // 0x00000001821CFC60-0x00000001821CFC80
	}
}
