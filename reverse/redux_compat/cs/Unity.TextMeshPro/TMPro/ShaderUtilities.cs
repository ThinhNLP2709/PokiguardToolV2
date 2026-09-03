/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	public static class ShaderUtilities // TypeDefIndex: 11873
	{
		// Fields
		public static readonly int ID_MainTex; // 0x00
		public static readonly int ID_FaceTex; // 0x04
		public static readonly int ID_FaceColor; // 0x08
		public static readonly int ID_FaceDilate; // 0x0C
		public static readonly int ID_Shininess; // 0x10
		public static readonly int ID_OutlineOffset1; // 0x14
		public static readonly int ID_OutlineOffset2; // 0x18
		public static readonly int ID_OutlineOffset3; // 0x1C
		public static readonly int ID_OutlineMode; // 0x20
		public static readonly int ID_IsoPerimeter; // 0x24
		public static readonly int ID_Softness; // 0x28
		public static readonly int ID_UnderlayColor; // 0x2C
		public static readonly int ID_UnderlayOffsetX; // 0x30
		public static readonly int ID_UnderlayOffsetY; // 0x34
		public static readonly int ID_UnderlayDilate; // 0x38
		public static readonly int ID_UnderlaySoftness; // 0x3C
		public static readonly int ID_UnderlayOffset; // 0x40
		public static readonly int ID_UnderlayIsoPerimeter; // 0x44
		public static readonly int ID_WeightNormal; // 0x48
		public static readonly int ID_WeightBold; // 0x4C
		public static readonly int ID_OutlineTex; // 0x50
		public static readonly int ID_OutlineWidth; // 0x54
		public static readonly int ID_OutlineSoftness; // 0x58
		public static readonly int ID_OutlineColor; // 0x5C
		public static readonly int ID_Outline2Color; // 0x60
		public static readonly int ID_Outline2Width; // 0x64
		public static readonly int ID_Padding; // 0x68
		public static readonly int ID_GradientScale; // 0x6C
		public static readonly int ID_ScaleX; // 0x70
		public static readonly int ID_ScaleY; // 0x74
		public static readonly int ID_PerspectiveFilter; // 0x78
		public static readonly int ID_Sharpness; // 0x7C
		public static readonly int ID_TextureWidth; // 0x80
		public static readonly int ID_TextureHeight; // 0x84
		public static readonly int ID_BevelAmount; // 0x88
		public static readonly int ID_GlowColor; // 0x8C
		public static readonly int ID_GlowOffset; // 0x90
		public static readonly int ID_GlowPower; // 0x94
		public static readonly int ID_GlowOuter; // 0x98
		public static readonly int ID_GlowInner; // 0x9C
		public static readonly int ID_LightAngle; // 0xA0
		public static readonly int ID_EnvMap; // 0xA4
		public static readonly int ID_EnvMatrix; // 0xA8
		public static readonly int ID_EnvMatrixRotation; // 0xAC
		public static readonly int ID_MaskCoord; // 0xB0
		public static readonly int ID_ClipRect; // 0xB4
		public static readonly int ID_MaskSoftnessX; // 0xB8
		public static readonly int ID_MaskSoftnessY; // 0xBC
		public static readonly int ID_VertexOffsetX; // 0xC0
		public static readonly int ID_VertexOffsetY; // 0xC4
		public static readonly int ID_UseClipRect; // 0xC8
		public static readonly int ID_StencilID; // 0xCC
		public static readonly int ID_StencilOp; // 0xD0
		public static readonly int ID_StencilComp; // 0xD4
		public static readonly int ID_StencilReadMask; // 0xD8
		public static readonly int ID_StencilWriteMask; // 0xDC
		public static readonly int ID_ShaderFlags; // 0xE0
		public static readonly int ID_ScaleRatio_A; // 0xE4
		public static readonly int ID_ScaleRatio_B; // 0xE8
		public static readonly int ID_ScaleRatio_C; // 0xEC
		public static readonly string Keyword_Bevel; // 0xF0
		public static readonly string Keyword_Glow; // 0xF8
		public static readonly string Keyword_Underlay; // 0x100
		public static readonly string Keyword_Ratios; // 0x108
		public static readonly string Keyword_MASK_SOFT; // 0x110
		public static readonly string Keyword_MASK_HARD; // 0x118
		public static readonly string Keyword_MASK_TEX; // 0x120
		public static readonly string Keyword_Outline; // 0x128
		public static readonly string ShaderTag_ZTestMode; // 0x130
		public static readonly string ShaderTag_CullMode; // 0x138
		public static readonly string ShaderTag_Spacewarp; // 0x140
		private static readonly float m_clamp; // 0x148
		[Obsolete("You no longer need to check if isInitialized is true. This class is now automatically initialized.", true)]
		public static bool isInitialized; // 0x14C
		private static Shader k_ShaderRef_MobileSDF; // 0x150
		private static Shader k_ShaderRef_MobileBitmap; // 0x158
	
		// Properties
		internal static Shader ShaderRef_MobileSDF { get; } // 0x00000001820C1F90-0x00000001820C2080 
		internal static Shader ShaderRef_MobileBitmap { get; } // 0x00000001820C1EA0-0x00000001820C1F90 
	
		// Constructors
		static ShaderUtilities(); // 0x00000001820C10C0-0x00000001820C1EA0
	
		// Methods
		[Obsolete("Calling this method is no longer required.", true)]
		public static void GetShaderPropertyIDs(); // 0x00000001802E76C0-0x00000001802E76D0
		public static void UpdateShaderRatios(Material mat); // 0x00000001820C0C30-0x00000001820C10C0
		public static Vector4 GetFontExtent(Material material); // 0x00000001820BF6E0-0x00000001820BF700
		public static bool IsMaskingEnabled(Material material); // 0x00000001820C0AC0-0x00000001820C0C30
		public static float GetPadding(Material material, bool enableExtraPadding, bool isBold); // 0x00000001820C02B0-0x00000001820C0AC0
		private static float ComputePaddingForProperties(Material mat); // 0x00000001820BF2C0-0x00000001820BF6E0
		public static float GetPadding(Material[] materials, bool enableExtraPadding, bool isBold); // 0x00000001820BF700-0x00000001820C02B0
	}
}
