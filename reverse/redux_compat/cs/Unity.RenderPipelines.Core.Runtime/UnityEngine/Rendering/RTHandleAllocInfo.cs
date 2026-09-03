/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public struct RTHandleAllocInfo // TypeDefIndex: 5714
	{
		// Fields
		[CompilerGenerated]
		private int _slices_k__BackingField; // 0x00
		[CompilerGenerated]
		private GraphicsFormat _format_k__BackingField; // 0x04
		[CompilerGenerated]
		private FilterMode _filterMode_k__BackingField; // 0x08
		[CompilerGenerated]
		private TextureWrapMode _wrapModeU_k__BackingField; // 0x0C
		[CompilerGenerated]
		private TextureWrapMode _wrapModeV_k__BackingField; // 0x10
		[CompilerGenerated]
		private TextureWrapMode _wrapModeW_k__BackingField; // 0x14
		[CompilerGenerated]
		private TextureDimension _dimension_k__BackingField; // 0x18
		[CompilerGenerated]
		private bool _enableRandomWrite_k__BackingField; // 0x1C
		[CompilerGenerated]
		private bool _useMipMap_k__BackingField; // 0x1D
		[CompilerGenerated]
		private bool _autoGenerateMips_k__BackingField; // 0x1E
		[CompilerGenerated]
		private bool _isShadowMap_k__BackingField; // 0x1F
		[CompilerGenerated]
		private int _anisoLevel_k__BackingField; // 0x20
		[CompilerGenerated]
		private float _mipMapBias_k__BackingField; // 0x24
		[CompilerGenerated]
		private MSAASamples _msaaSamples_k__BackingField; // 0x28
		[CompilerGenerated]
		private bool _bindTextureMS_k__BackingField; // 0x2C
		[CompilerGenerated]
		private bool _useDynamicScale_k__BackingField; // 0x2D
		[CompilerGenerated]
		private bool _useDynamicScaleExplicit_k__BackingField; // 0x2E
		[CompilerGenerated]
		private RenderTextureMemoryless _memoryless_k__BackingField; // 0x30
		[CompilerGenerated]
		private VRTextureUsage _vrUsage_k__BackingField; // 0x34
		[CompilerGenerated]
		private bool _enableShadingRate_k__BackingField; // 0x38
		[CompilerGenerated]
		private string _name_k__BackingField; // 0x40
	
		// Properties
		public int slices { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
		public GraphicsFormat format { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802E7C60-0x00000001802E7DA0 0x0000000180732D40-0x0000000180732D50
		public FilterMode filterMode { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180732D20-0x0000000180732D30 0x0000000180732D60-0x0000000180732D70
		public TextureWrapMode wrapModeU { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180732D30-0x0000000180732D40 0x0000000180732D70-0x0000000180732D80
		public TextureWrapMode wrapModeV { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
		public TextureWrapMode wrapModeW { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180A5E110-0x0000000180A5E120 0x0000000180E02550-0x0000000180E02560
		public TextureDimension dimension { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
		public bool enableRandomWrite { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180E38E30-0x0000000180E38E40 0x0000000181E92340-0x0000000181E92350
		public bool useMipMap { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181B36780-0x0000000181B36790 0x0000000181B36830-0x0000000181B36840
		public bool autoGenerateMips { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181E92310-0x0000000181E92320 0x0000000181E92330-0x0000000181E92340
		public bool isShadowMap { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181E92320-0x0000000181E92330 0x0000000181E92350-0x0000000181E92360
		public int anisoLevel { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180C4F680-0x0000000180C4F690 0x0000000180E332D0-0x0000000180E332E0
		public float mipMapBias { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181CE2830-0x0000000181CE2840 0x0000000181CE28E0-0x0000000181CE28F0
		public MSAASamples msaaSamples { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377930-0x0000000180377940 0x0000000180378100-0x0000000180378110
		public bool bindTextureMS { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181B20770-0x0000000181B20780 0x0000000181B20790-0x0000000181B207A0
		public bool useDynamicScale { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181B20760-0x0000000181B20770 0x0000000181B20780-0x0000000181B20790
		public bool useDynamicScaleExplicit { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181DB5B90-0x0000000181DB5BA0 0x0000000181DB5BD0-0x0000000181DB5BE0
		public RenderTextureMemoryless memoryless { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D100-0x000000018033D110 0x000000018033E780-0x000000018033E790
		public VRTextureUsage vrUsage { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D0F0-0x000000018033D100 0x000000018033E770-0x000000018033E780
		public bool enableShadingRate { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180476380-0x0000000180476390 0x00000001804763A0-0x00000001804763B0
		public string name { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377940-0x0000000180377950 0x0000000180378120-0x0000000180378130
	
		// Constructors
		public RTHandleAllocInfo(string name = "" /* Metadata: 0x006617F0 */); // 0x0000000181E922C0-0x0000000181E92310
	}
}
