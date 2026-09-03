/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public static class TextureXR // TypeDefIndex: 5727
	{
		// Fields
		[NoAutoStaticsCleanup]
		private static int s_MaxViews; // 0x00
		[NoAutoStaticsCleanup]
		private static Texture s_BlackUIntTexture2DArray; // 0x08
		[NoAutoStaticsCleanup]
		private static Texture s_BlackUIntTexture; // 0x10
		[NoAutoStaticsCleanup]
		private static RTHandle s_BlackUIntTexture2DArrayRTH; // 0x18
		[NoAutoStaticsCleanup]
		private static RTHandle s_BlackUIntTextureRTH; // 0x20
		[NoAutoStaticsCleanup]
		private static Texture2DArray s_ClearTexture2DArray; // 0x28
		[NoAutoStaticsCleanup]
		private static Texture2D s_ClearTexture; // 0x30
		[NoAutoStaticsCleanup]
		private static RTHandle s_ClearTexture2DArrayRTH; // 0x38
		[NoAutoStaticsCleanup]
		private static RTHandle s_ClearTextureRTH; // 0x40
		[NoAutoStaticsCleanup]
		private static Texture2DArray s_MagentaTexture2DArray; // 0x48
		[NoAutoStaticsCleanup]
		private static Texture2D s_MagentaTexture; // 0x50
		[NoAutoStaticsCleanup]
		private static RTHandle s_MagentaTexture2DArrayRTH; // 0x58
		[NoAutoStaticsCleanup]
		private static RTHandle s_MagentaTextureRTH; // 0x60
		[NoAutoStaticsCleanup]
		private static Texture2D s_BlackTexture; // 0x68
		[NoAutoStaticsCleanup]
		private static Texture3D s_BlackTexture3D; // 0x70
		[NoAutoStaticsCleanup]
		private static Texture2DArray s_BlackTexture2DArray; // 0x78
		[NoAutoStaticsCleanup]
		private static RTHandle s_BlackTexture2DArrayRTH; // 0x80
		[NoAutoStaticsCleanup]
		private static RTHandle s_BlackTextureRTH; // 0x88
		[NoAutoStaticsCleanup]
		private static RTHandle s_BlackTexture3DRTH; // 0x90
		[NoAutoStaticsCleanup]
		private static Texture2DArray s_WhiteTexture2DArray; // 0x98
		[NoAutoStaticsCleanup]
		private static RTHandle s_WhiteTexture2DArrayRTH; // 0xA0
		[NoAutoStaticsCleanup]
		private static RTHandle s_WhiteTextureRTH; // 0xA8
	
		// Properties
		public static int maxViews { set; } // 0x0000000181EBC490-0x0000000181EBC4F0
		public static int slices { get; } // 0x0000000181EBC3C0-0x0000000181EBC410 
		public static bool useTexArray { get; } // 0x0000000181EBC410-0x0000000181EBC490 
		public static TextureDimension dimension { get; } // 0x0000000181EBC2E0-0x0000000181EBC340 
		public static bool initialized { get; } // 0x0000000181EBC340-0x0000000181EBC3C0 
	
		// Constructors
		static TextureXR(); // 0x0000000181EBC2A0-0x0000000181EBC2E0
	
		// Methods
		[OnCodeInitializing]
		private static void ResetStaticsOnLoad(); // 0x0000000181EBC150-0x0000000181EBC1B0
		public static RTHandle GetBlackUIntTexture(); // 0x0000000181EBB500-0x0000000181EBB560
		public static RTHandle GetClearTexture(); // 0x0000000181EBB560-0x0000000181EBB5C0
		public static RTHandle GetMagentaTexture(); // 0x0000000181EBB5C0-0x0000000181EBB620
		public static RTHandle GetBlackTexture(); // 0x0000000181EBB490-0x0000000181EBB500
		public static RTHandle GetBlackTextureArray(); // 0x0000000181EBB430-0x0000000181EBB490
		public static RTHandle GetBlackTexture3D(); // 0x0000000181EBB3D0-0x0000000181EBB430
		public static RTHandle GetWhiteTexture(); // 0x0000000181EBB620-0x0000000181EBB690
		public static void Initialize(CommandBuffer cmd, ComputeShader clearR32_UIntShader); // 0x0000000181EBB690-0x0000000181EBC150
		public static void Cleanup(); // 0x0000000181EBA360-0x0000000181EBAC80
		private static Texture2DArray CreateTexture2DArrayFromTexture2D(Texture2D source, string name); // 0x0000000181EBB1C0-0x0000000181EBB3D0
		private static Texture CreateBlackUIntTextureArray(CommandBuffer cmd, ComputeShader clearR32_UIntShader); // 0x0000000181EBAD50-0x0000000181EBAFE0
		private static Texture CreateBlackUintTexture(CommandBuffer cmd, ComputeShader clearR32_UIntShader); // 0x0000000181EBAFE0-0x0000000181EBB1C0
		private static Texture3D CreateBlackTexture3D(string name); // 0x0000000181EBAC80-0x0000000181EBAD50
		[CompilerGenerated]
		internal static void UnityEngine_Rendering_TextureXR_ResetStaticsOnLoad_RegisterLifecycleMethod(); // 0x0000000181EBC1B0-0x0000000181EBC2A0
	}
}
