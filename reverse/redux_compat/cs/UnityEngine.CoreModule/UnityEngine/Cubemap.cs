/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Internal;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[ExcludeFromPreset]
	[NativeClass("Cubemap", PersistentTypeId = 89)]
	[NativeHeader("Runtime/Graphics/CubemapTexture.h")]
	public sealed class Cubemap : Texture // TypeDefIndex: 7632
	{
		// Properties
		public TextureFormat format { [NativeName("GetTextureFormat")] get; } // 0x00000001821CB550-0x00000001821CB5B0 
		public override bool isReadable { get; } // 0x00000001821CB690-0x00000001821CB6F0 
		internal bool isPreProcessed { get; } // 0x00000001821CB5F0-0x00000001821CB650 
		public bool streamingMipmaps { get; } // 0x00000001821CBA50-0x00000001821CBAB0 
		public int streamingMipmapsPriority { get; } // 0x00000001821CB9B0-0x00000001821CBA10 
		public int requestedMipmapLevel { [FreeFunction(Name = "GetTextureStreamingManager().GetRequestedMipmapLevel", HasExplicitThis = true)] get; [FreeFunction(Name = "GetTextureStreamingManager().SetRequestedMipmapLevel", HasExplicitThis = true)] set; } // 0x00000001821CB910-0x00000001821CB970 0x00000001821CBBA0-0x00000001821CBC00
		internal bool loadAllMips { [FreeFunction(Name = "GetTextureStreamingManager().GetLoadAllMips", HasExplicitThis = true)] get; [FreeFunction(Name = "GetTextureStreamingManager().SetLoadAllMips", HasExplicitThis = true)] set; } // 0x00000001821CB730-0x00000001821CB790 0x00000001821CBB00-0x00000001821CBB60
		public int desiredMipmapLevel { [FreeFunction(Name = "GetTextureStreamingManager().GetDesiredMipmapLevel", HasExplicitThis = true)] get; } // 0x00000001821CB4B0-0x00000001821CB510 
		public int loadingMipmapLevel { [FreeFunction(Name = "GetTextureStreamingManager().GetLoadingMipmapLevel", HasExplicitThis = true)] get; } // 0x00000001821CB870-0x00000001821CB8D0 
		public int loadedMipmapLevel { [FreeFunction(Name = "GetTextureStreamingManager().GetLoadedMipmapLevel", HasExplicitThis = true)] get; } // 0x00000001821CB7D0-0x00000001821CB830 
	
		// Constructors
		[ExcludeFromDocs]
		public Cubemap(int width, DefaultFormat format, TextureCreationFlags flags); // 0x00000001821CAD40-0x00000001821CADE0
		[ExcludeFromDocs]
		public Cubemap(int width, DefaultFormat format, TextureCreationFlags flags, int mipCount); // 0x00000001821CADE0-0x00000001821CAE30
		[ExcludeFromDocs]
		[RequiredByNativeCode]
		public Cubemap(int width, GraphicsFormat format, TextureCreationFlags flags); // 0x00000001821CAE30-0x00000001821CAED0
		[ExcludeFromDocs]
		public Cubemap(int width, GraphicsFormat format, TextureCreationFlags flags, int mipCount); // 0x00000001821CAED0-0x00000001821CB120
		internal Cubemap(int width, TextureFormat textureFormat, int mipCount, IntPtr nativeTex, bool createUninitialized); // 0x00000001821CB220-0x00000001821CB470
		public Cubemap(int width, TextureFormat textureFormat, bool mipChain); // 0x00000001821CB140-0x00000001821CB1F0
		public Cubemap(int width, TextureFormat textureFormat, bool mipChain, [DefaultValue("false")] bool createUninitialized); // 0x00000001821CAC90-0x00000001821CAD40
		public Cubemap(int width, TextureFormat format, int mipCount); // 0x00000001821CB120-0x00000001821CB140
		public Cubemap(int width, TextureFormat format, int mipCount, [DefaultValue("false")] bool createUninitialized); // 0x00000001821CB1F0-0x00000001821CB220
	
		// Methods
		[FreeFunction("CubemapScripting::Create")]
		private static bool Internal_CreateImpl([Writable] Cubemap mono, int ext, int mipCount, GraphicsFormat format, TextureColorSpace colorSpace, TextureCreationFlags flags, IntPtr nativeTex); // 0x00000001821C9FA0-0x00000001821CA000
		private static void Internal_Create([Writable] Cubemap mono, int ext, int mipCount, GraphicsFormat format, TextureColorSpace colorSpace, TextureCreationFlags flags, IntPtr nativeTex); // 0x00000001821CA000-0x00000001821CA0D0
		[FreeFunction(Name = "CubemapScripting::Apply", HasExplicitThis = true)]
		private void ApplyImpl(bool updateMipmaps, bool makeNoLongerReadable); // 0x00000001821C9220-0x00000001821C9290
		[FreeFunction("CubemapScripting::UpdateExternalTexture", HasExplicitThis = true)]
		public void UpdateExternalTexture(IntPtr nativeTexture); // 0x00000001821CA9C0-0x00000001821CAA20
		[NativeName("SetPixel")]
		private void SetPixelImpl(int image, int mip, int x, int y, Color color); // 0x00000001821CA410-0x00000001821CA4A0
		[NativeName("GetPixel")]
		private Color GetPixelImpl(int image, int mip, int x, int y); // 0x00000001821C9BE0-0x00000001821C9C80
		[NativeName("FixupEdges")]
		public void SmoothEdges([DefaultValue("1")] int smoothRegionWidthInPixels); // 0x00000001821CA910-0x00000001821CA970
		public void SmoothEdges(); // 0x00000001821CA8B0-0x00000001821CA910
		[FreeFunction(Name = "CubemapScripting::GetPixels", HasExplicitThis = true, ThrowsException = true)]
		public Color[] GetPixels(CubemapFace face, int miplevel); // 0x00000001821C9EB0-0x00000001821C9F20
		public Color[] GetPixels(CubemapFace face); // 0x00000001821C9F20-0x00000001821C9F80
		[FreeFunction(Name = "CubemapScripting::SetPixels", HasExplicitThis = true, ThrowsException = true)]
		public void SetPixels(Color[] colors, CubemapFace face, int miplevel); // 0x00000001821CA6D0-0x00000001821CA7A0
		[FreeFunction(Name = "CubemapScripting::SetPixelDataSpan", HasExplicitThis = true, ThrowsException = true)]
		private bool SetPixelDataImplSpan(Span<byte> data, int mipLevel, int face, int elementSize, int dataArraySize, int sourceDataStartIndex = 0 /* Metadata: 0x0069D3E6 */); // 0x00000001821CA1E0-0x00000001821CA2C0
		[FreeFunction(Name = "CubemapScripting::SetPixelData", HasExplicitThis = true, ThrowsException = true)]
		private bool SetPixelDataImpl(IntPtr data, int mipLevel, int face, int elementSize, int dataArraySize, int sourceDataStartIndex = 0 /* Metadata: 0x0069D3E7 */); // 0x00000001821CA330-0x00000001821CA3B0
		public void SetPixels(Color[] colors, CubemapFace face); // 0x00000001821CA7A0-0x00000001821CA870
		[FreeFunction(Name = "CubemapScripting::CopyPixels", HasExplicitThis = true, ThrowsException = true)]
		private void CopyPixels_Full(Texture src); // 0x00000001821C9460-0x00000001821C94E0
		[FreeFunction(Name = "CubemapScripting::CopyPixels", HasExplicitThis = true, ThrowsException = true)]
		private void CopyPixels_Slice(Texture src, int srcElement, int srcMip, int dstFace, int dstMip); // 0x00000001821C9660-0x00000001821C9700
		[FreeFunction(Name = "CubemapScripting::CopyPixels", HasExplicitThis = true, ThrowsException = true)]
		private void CopyPixels_Region(Texture src, int srcElement, int srcMip, int srcX, int srcY, int srcWidth, int srcHeight, int dstFace, int dstMip, int dstX, int dstY); // 0x00000001821C9550-0x00000001821C95F0
		private IntPtr GetWritableImageData(int element = 0 /* Metadata: 0x0069D3E8 */, int mipLevel = 0 /* Metadata: 0x0069D3E9 */); // 0x00000001821C9F80-0x00000001821C9FA0
		[FreeFunction(Name = "GetTextureStreamingManager().ClearRequestedMipmapLevel", HasExplicitThis = true)]
		public void ClearRequestedMipmapLevel(); // 0x00000001821C93B0-0x00000001821C9410
		[FreeFunction(Name = "GetTextureStreamingManager().IsRequestedMipmapLevelLoaded", HasExplicitThis = true)]
		public bool IsRequestedMipmapLevelLoaded(); // 0x00000001821CA110-0x00000001821CA170
		internal bool ValidateFormat(TextureFormat format, int width); // 0x00000001821CAA20-0x00000001821CAB00
		internal bool ValidateFormat(GraphicsFormat format, int width); // 0x00000001821CAB00-0x00000001821CAC30
		public static Cubemap CreateExternalTexture(int width, TextureFormat format, bool mipmap, IntPtr nativeTex); // 0x00000001821C9A50-0x00000001821C9B80
		public void SetPixelData<T>(T[] data, int mipLevel, CubemapFace face, [DefaultValue("0")] int sourceDataStartIndex = 0 /* Metadata: 0x0069D3EA */);
		public void SetPixelData<T>(NativeArray<T> data, int mipLevel, CubemapFace face, [DefaultValue("0")] int sourceDataStartIndex = 0 /* Metadata: 0x0069D3EB */)
			where T : struct;
		public NativeArray<T> GetPixelData<T>(int mipLevel, CubemapFace face)
			where T : struct;
		[ExcludeFromDocs]
		public void SetPixel(CubemapFace face, int x, int y, Color color); // 0x00000001821CA4A0-0x00000001821CA580
		public void SetPixel(CubemapFace face, int x, int y, Color color, [DefaultValue("0")] int mip); // 0x00000001821CA580-0x00000001821CA660
		[ExcludeFromDocs]
		public Color GetPixel(CubemapFace face, int x, int y); // 0x00000001821C9D70-0x00000001821C9E60
		public Color GetPixel(CubemapFace face, int x, int y, [DefaultValue("0")] int mip); // 0x00000001821C9C80-0x00000001821C9D70
		public void Apply([DefaultValue("true")] bool updateMipmaps, [DefaultValue("false")] bool makeNoLongerReadable); // 0x00000001821C92A0-0x00000001821C9360
		[ExcludeFromDocs]
		public void Apply(bool updateMipmaps); // 0x00000001821C9360-0x00000001821C9370
		[ExcludeFromDocs]
		public void Apply(); // 0x00000001821C9290-0x00000001821C92A0
		public void CopyPixels(Texture src); // 0x00000001821C9700-0x00000001821C9800
		public void CopyPixels(Texture src, int srcElement, int srcMip, CubemapFace dstFace, int dstMip); // 0x00000001821C9930-0x00000001821C9A50
		public void CopyPixels(Texture src, int srcElement, int srcMip, int srcX, int srcY, int srcWidth, int srcHeight, CubemapFace dstFace, int dstMip, int dstX, int dstY); // 0x00000001821C9800-0x00000001821C9930
		private static void ValidateIsNotCrunched(TextureCreationFlags flags); // 0x00000001821CAC30-0x00000001821CAC90
		private static TextureFormat get_format_Injected(IntPtr _unity_self); // 0x00000001821CB510-0x00000001821CB550
		private static void ApplyImpl_Injected(IntPtr _unity_self, bool updateMipmaps, bool makeNoLongerReadable); // 0x00000001821C91C0-0x00000001821C9220
		private static void UpdateExternalTexture_Injected(IntPtr _unity_self, IntPtr nativeTexture); // 0x00000001821CA970-0x00000001821CA9C0
		private static new bool get_isReadable_Injected(IntPtr _unity_self); // 0x00000001821CB650-0x00000001821CB690
		private static void SetPixelImpl_Injected(IntPtr _unity_self, int image, int mip, int x, int y, in Color color); // 0x00000001821CA3B0-0x00000001821CA410
		private static void GetPixelImpl_Injected(IntPtr _unity_self, int image, int mip, int x, int y, ); // 0x00000001821C9B80-0x00000001821C9BE0
		private static void SmoothEdges_Injected(IntPtr _unity_self, [DefaultValue("1")] int smoothRegionWidthInPixels); // 0x00000001821CA870-0x00000001821CA8B0
		private static Color[] GetPixels_Injected(IntPtr _unity_self, CubemapFace face, int miplevel); // 0x00000001821C9E60-0x00000001821C9EB0
		private static void SetPixels_Injected(IntPtr _unity_self, ref ManagedSpanWrapper colors, CubemapFace face, int miplevel); // 0x00000001821CA660-0x00000001821CA6D0
		private static bool SetPixelDataImplSpan_Injected(IntPtr _unity_self, ref ManagedSpanWrapper data, int mipLevel, int face, int elementSize, int dataArraySize, int sourceDataStartIndex); // 0x00000001821CA170-0x00000001821CA1E0
		private static bool SetPixelDataImpl_Injected(IntPtr _unity_self, IntPtr data, int mipLevel, int face, int elementSize, int dataArraySize, int sourceDataStartIndex); // 0x00000001821CA2C0-0x00000001821CA330
		private static void CopyPixels_Full_Injected(IntPtr _unity_self, IntPtr src); // 0x00000001821C9410-0x00000001821C9460
		private static void CopyPixels_Slice_Injected(IntPtr _unity_self, IntPtr src, int srcElement, int srcMip, int dstFace, int dstMip); // 0x00000001821C95F0-0x00000001821C9660
		private static void CopyPixels_Region_Injected(IntPtr _unity_self, IntPtr src, int srcElement, int srcMip, int srcX, int srcY, int srcWidth, int srcHeight, int dstFace, int dstMip, int dstX, int dstY); // 0x00000001821C94E0-0x00000001821C9550
		private static bool get_isPreProcessed_Injected(IntPtr _unity_self); // 0x00000001821CB5B0-0x00000001821CB5F0
		private static bool get_streamingMipmaps_Injected(IntPtr _unity_self); // 0x00000001821CBA10-0x00000001821CBA50
		private static int get_streamingMipmapsPriority_Injected(IntPtr _unity_self); // 0x00000001821CB970-0x00000001821CB9B0
		private static int get_requestedMipmapLevel_Injected(IntPtr _unity_self); // 0x00000001821CB8D0-0x00000001821CB910
		private static void set_requestedMipmapLevel_Injected(IntPtr _unity_self, int value); // 0x00000001821CBB60-0x00000001821CBBA0
		private static bool get_loadAllMips_Injected(IntPtr _unity_self); // 0x00000001821CB6F0-0x00000001821CB730
		private static void set_loadAllMips_Injected(IntPtr _unity_self, bool value); // 0x00000001821CBAB0-0x00000001821CBB00
		private static int get_desiredMipmapLevel_Injected(IntPtr _unity_self); // 0x00000001821CB470-0x00000001821CB4B0
		private static int get_loadingMipmapLevel_Injected(IntPtr _unity_self); // 0x00000001821CB830-0x00000001821CB870
		private static int get_loadedMipmapLevel_Injected(IntPtr _unity_self); // 0x00000001821CB790-0x00000001821CB7D0
		private static void ClearRequestedMipmapLevel_Injected(IntPtr _unity_self); // 0x00000001821C9370-0x00000001821C93B0
		private static bool IsRequestedMipmapLevelLoaded_Injected(IntPtr _unity_self); // 0x00000001821CA0D0-0x00000001821CA110
	}
}
