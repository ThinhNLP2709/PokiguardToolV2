/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeClass("Texture", PersistentTypeId = 27)]
	[NativeHeader("Runtime/Streaming/TextureStreamingManager.h")]
	[NativeHeader("Runtime/Graphics/Texture.h")]
	[UsedByNativeCode]
	public class Texture : Object // TypeDefIndex: 7630
	{
		// Fields
		public static readonly int GenerateAllMips; // 0x00
	
		// Properties
		public int mipmapCount { [NativeName("GetMipmapCount")] get; } // 0x00000001821DE580-0x00000001821DE610 
		public virtual GraphicsFormat graphicsFormat { get; } // 0x00000001821DE350-0x00000001821DE3A0 
		public virtual int width { get; set; } // 0x00000001821DD610-0x00000001821DD6A0 0x00000001821DEC40-0x00000001821DEC80
		public virtual int height { get; set; } // 0x00000001821DD540-0x00000001821DD5D0 0x00000001821DEAD0-0x00000001821DEB10
		public virtual TextureDimension dimension { get; set; } // 0x00000001821DD6E0-0x00000001821DD770 0x00000001821DE9B0-0x00000001821DE9F0
		public virtual bool isReadable { get; } // 0x00000001821DE3E0-0x00000001821DE470 
		public TextureWrapMode wrapMode { [NativeName("GetWrapModeU")] get; set; } // 0x00000001821DE840-0x00000001821DE8D0 0x00000001821DEF60-0x00000001821DF000
		public TextureWrapMode wrapModeU { set; } // 0x00000001821DECC0-0x00000001821DED60
		public TextureWrapMode wrapModeV { set; } // 0x00000001821DEDA0-0x00000001821DEE40
		public TextureWrapMode wrapModeW { set; } // 0x00000001821DEE80-0x00000001821DEF20
		public FilterMode filterMode { get; set; } // 0x00000001821DE2C0-0x00000001821DE350 0x00000001821DEA30-0x00000001821DEAD0
		public int anisoLevel { get; set; } // 0x00000001821DE1F0-0x00000001821DE280 0x00000001821DE910-0x00000001821DE9B0
		public float mipMapBias { get; set; } // 0x00000001821DE4B0-0x00000001821DE540 0x00000001821DEB60-0x00000001821DEC00
		public Vector2 texelSize { [NativeName("GetTexelSize")] get; } // 0x00000001821DE690-0x00000001821DE730 
		public uint updateCount { get; } // 0x00000001821DE770-0x00000001821DE800 
		internal ColorSpace activeTextureColorSpace { [VisibleToOtherModules(new string[2] {"UnityEngine.UIElementsModule", "Unity.UIElements" })] get; } // 0x00000001821DE100-0x00000001821DE1B0 
		public static bool streamingTextureDiscardUnusedMips { [FreeFunction(Name = "GetTextureStreamingManager().GetDiscardUnusedMips")] get; [FreeFunction(Name = "GetTextureStreamingManager().SetDiscardUnusedMips")] set; } // 0x00000001821DE610-0x00000001821DE640 0x00000001821DEC00-0x00000001821DEC40
	
		// Constructors
		protected Texture(); // 0x00000001821DE0B0-0x00000001821DE100
		static Texture(); // 0x00000001821DE070-0x00000001821DE0B0
	
		// Methods
		[NativeMethod(IsThreadSafe = true)]
		private int GetDataWidth(); // 0x00000001821DD610-0x00000001821DD6A0
		[NativeMethod(IsThreadSafe = true)]
		private int GetDataHeight(); // 0x00000001821DD540-0x00000001821DD5D0
		[NativeMethod(IsThreadSafe = true)]
		private TextureDimension GetDimension(); // 0x00000001821DD6E0-0x00000001821DD770
		public void IncrementUpdateCount(); // 0x00000001821DDBC0-0x00000001821DDC50
		[NativeMethod("GetActiveTextureColorSpace")]
		private int Internal_GetActiveTextureColorSpace(); // 0x00000001821DDC90-0x00000001821DDD20
		[NativeMethod("GetWritableImageData")]
		private protected IntPtr GetWritableImageDataImpl(int element, int mipLevel, int depthSlice); // 0x00000001821DDA30-0x00000001821DDAF0
		[FreeFunction("GetTextureStreamingManager().SetStreamingTextureMaterialDebugPropertiesWithSlot")]
		private static void SetStreamingTextureMaterialDebugPropertiesWithSlot(int materialTextureSlot); // 0x00000001821DDD20-0x00000001821DDD60
		public static void SetStreamingTextureMaterialDebugProperties(int materialTextureSlot); // 0x00000001821DDD60-0x00000001821DDDD0
		internal ulong GetPixelDataSize(int mipLevel, int element = 0 /* Metadata: 0x0069D3DB */); // 0x00000001821DD8C0-0x00000001821DD970
		internal ulong GetPixelDataOffset(int mipLevel, int element = 0 /* Metadata: 0x0069D3DC */); // 0x00000001821DD7C0-0x00000001821DD870
		internal TextureColorSpace GetTextureColorSpace(bool linear); // 0x00000001821DD9C0-0x00000001821DD9D0
		internal TextureColorSpace GetTextureColorSpace(GraphicsFormat format); // 0x00000001821DD970-0x00000001821DD9C0
		internal bool ValidateFormat(TextureFormat format); // 0x00000001821DDDD0-0x00000001821DDF50
		internal bool ValidateFormat(GraphicsFormat format, GraphicsFormatUsage usage); // 0x00000001821DDF50-0x00000001821DE070
		internal UnityException CreateNonReadableException(Texture t); // 0x00000001821DD470-0x00000001821DD500
		internal UnityException IgnoreMipmapLimitCannotBeToggledException(Texture t); // 0x00000001821DDAF0-0x00000001821DDB80
		internal UnityException CreateNativeArrayLengthOverflowException(); // 0x00000001821DD410-0x00000001821DD470
		private static int get_mipmapCount_Injected(IntPtr _unity_self); // 0x00000001821DE540-0x00000001821DE580
		private static int GetDataWidth_Injected(IntPtr _unity_self); // 0x00000001821DD5D0-0x00000001821DD610
		private static int GetDataHeight_Injected(IntPtr _unity_self); // 0x00000001821DD500-0x00000001821DD540
		private static TextureDimension GetDimension_Injected(IntPtr _unity_self); // 0x00000001821DD6A0-0x00000001821DD6E0
		private static bool get_isReadable_Injected(IntPtr _unity_self); // 0x00000001821DE3A0-0x00000001821DE3E0
		private static TextureWrapMode get_wrapMode_Injected(IntPtr _unity_self); // 0x00000001821DE800-0x00000001821DE840
		private static void set_wrapMode_Injected(IntPtr _unity_self, TextureWrapMode value); // 0x00000001821DEF20-0x00000001821DEF60
		private static void set_wrapModeU_Injected(IntPtr _unity_self, TextureWrapMode value); // 0x00000001821DEC80-0x00000001821DECC0
		private static void set_wrapModeV_Injected(IntPtr _unity_self, TextureWrapMode value); // 0x00000001821DED60-0x00000001821DEDA0
		private static void set_wrapModeW_Injected(IntPtr _unity_self, TextureWrapMode value); // 0x00000001821DEE40-0x00000001821DEE80
		private static FilterMode get_filterMode_Injected(IntPtr _unity_self); // 0x00000001821DE280-0x00000001821DE2C0
		private static void set_filterMode_Injected(IntPtr _unity_self, FilterMode value); // 0x00000001821DE9F0-0x00000001821DEA30
		private static int get_anisoLevel_Injected(IntPtr _unity_self); // 0x00000001821DE1B0-0x00000001821DE1F0
		private static void set_anisoLevel_Injected(IntPtr _unity_self, int value); // 0x00000001821DE8D0-0x00000001821DE910
		private static float get_mipMapBias_Injected(IntPtr _unity_self); // 0x00000001821DE470-0x00000001821DE4B0
		private static void set_mipMapBias_Injected(IntPtr _unity_self, float value); // 0x00000001821DEB10-0x00000001821DEB60
		private static void get_texelSize_Injected(IntPtr _unity_self, ); // 0x00000001821DE640-0x00000001821DE690
		private static uint get_updateCount_Injected(IntPtr _unity_self); // 0x00000001821DE730-0x00000001821DE770
		private static void IncrementUpdateCount_Injected(IntPtr _unity_self); // 0x00000001821DDB80-0x00000001821DDBC0
		private static int Internal_GetActiveTextureColorSpace_Injected(IntPtr _unity_self); // 0x00000001821DDC50-0x00000001821DDC90
		private static IntPtr GetWritableImageDataImpl_Injected(IntPtr _unity_self, int element, int mipLevel, int depthSlice); // 0x00000001821DD9D0-0x00000001821DDA30
		private static ulong GetPixelDataSize_Injected(IntPtr _unity_self, int mipLevel, int element); // 0x00000001821DD870-0x00000001821DD8C0
		private static ulong GetPixelDataOffset_Injected(IntPtr _unity_self, int mipLevel, int element); // 0x00000001821DD770-0x00000001821DD7C0
	}
}
