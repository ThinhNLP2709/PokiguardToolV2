/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
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
	[HelpURL("texture-type-default")]
	[NativeClass("Texture2D", PersistentTypeId = 28)]
	[NativeHeader("Runtime/Graphics/GeneratedTextures.h")]
	[NativeHeader("Runtime/Graphics/Texture2D.h")]
	[UsedByNativeCode]
	public sealed class Texture2D : Texture // TypeDefIndex: 7631
	{
		// Fields
		internal const int streamingMipmapsPriorityMin = -128; // Metadata: 0x0069D3E2
		internal const int streamingMipmapsPriorityMax = 127; // Metadata: 0x0069D3E4
	
		// Properties
		public TextureFormat format { [NativeName("GetTextureFormat")] get; } // 0x00000001821DBB60-0x00000001821DBBC0 
		public string mipmapLimitGroup { [NativeName("GetMipmapLimitGroupName")] get; } // 0x00000001821DC0F0-0x00000001821DC1E0 
		public int activeMipmapLimit { [NativeName("GetMipmapLimit")] get; } // 0x00000001821DB8F0-0x00000001821DB950 
		[StaticAccessor("builtintex", StaticAccessorType.DoubleColon)]
		public static Texture2D whiteTexture { get; } // 0x00000001821DC5B0-0x00000001821DC610 
		[StaticAccessor("builtintex", StaticAccessorType.DoubleColon)]
		public static Texture2D blackTexture { get; } // 0x00000001821DB980-0x00000001821DB9E0 
		[StaticAccessor("builtintex", StaticAccessorType.DoubleColon)]
		public static Texture2D redTexture { get; } // 0x00000001821DC2A0-0x00000001821DC300 
		[StaticAccessor("builtintex", StaticAccessorType.DoubleColon)]
		public static Texture2D grayTexture { get; } // 0x00000001821DBBF0-0x00000001821DBC50 
		[StaticAccessor("builtintex", StaticAccessorType.DoubleColon)]
		public static Texture2D linearGrayTexture { get; } // 0x00000001821DBDC0-0x00000001821DBE20 
		[StaticAccessor("builtintex", StaticAccessorType.DoubleColon)]
		public static Texture2D normalTexture { get; } // 0x00000001821DC210-0x00000001821DC270 
		public override bool isReadable { get; } // 0x00000001821DBD30-0x00000001821DBD90 
		[NativeConditional("ENABLE_VIRTUALTEXTURING && UNITY_EDITOR")]
		[NativeName("VTOnly")]
		public bool vtOnly { get; } // 0x00000001821DC520-0x00000001821DC580 
		internal bool isPreProcessed { get; } // 0x00000001821DBC90-0x00000001821DBCF0 
		public bool streamingMipmaps { get; } // 0x00000001821DC480-0x00000001821DC4E0 
		public int streamingMipmapsPriority { get; } // 0x00000001821DC3E0-0x00000001821DC440 
		public int requestedMipmapLevel { [FreeFunction(Name = "GetTextureStreamingManager().GetRequestedMipmapLevel", HasExplicitThis = true)] get; [FreeFunction(Name = "GetTextureStreamingManager().SetRequestedMipmapLevel", HasExplicitThis = true)] set; } // 0x00000001821DC340-0x00000001821DC3A0 0x00000001821DC840-0x00000001821DC8A0
		public int minimumMipmapLevel { [FreeFunction(Name = "GetTextureStreamingManager().GetMinimumMipmapLevel", HasExplicitThis = true)] get; [FreeFunction(Name = "GetTextureStreamingManager().SetMinimumMipmapLevel", HasExplicitThis = true)] set; } // 0x00000001821DC040-0x00000001821DC0A0 0x00000001821DC7A0-0x00000001821DC800
		internal bool loadAllMips { [FreeFunction(Name = "GetTextureStreamingManager().GetLoadAllMips", HasExplicitThis = true)] get; [FreeFunction(Name = "GetTextureStreamingManager().SetLoadAllMips", HasExplicitThis = true)] set; } // 0x00000001821DBE60-0x00000001821DBEC0 0x00000001821DC700-0x00000001821DC760
		public int calculatedMipmapLevel { [FreeFunction(Name = "GetTextureStreamingManager().GetCalculatedMipmapLevel", HasExplicitThis = true)] get; } // 0x00000001821DBA20-0x00000001821DBA80 
		public int desiredMipmapLevel { [FreeFunction(Name = "GetTextureStreamingManager().GetDesiredMipmapLevel", HasExplicitThis = true)] get; } // 0x00000001821DBAC0-0x00000001821DBB20 
		public int loadingMipmapLevel { [FreeFunction(Name = "GetTextureStreamingManager().GetLoadingMipmapLevel", HasExplicitThis = true)] get; } // 0x00000001821DBFA0-0x00000001821DC000 
		public int loadedMipmapLevel { [FreeFunction(Name = "GetTextureStreamingManager().GetLoadedMipmapLevel", HasExplicitThis = true)] get; } // 0x00000001821DBF00-0x00000001821DBF60 
		public bool ignoreMipmapLimit { get; set; } // 0x00000001821D8740-0x00000001821D87A0 0x00000001821DC610-0x00000001821DC6B0
	
		// Constructors
		internal Texture2D(int width, int height, GraphicsFormat format, TextureCreationFlags flags, int mipCount, IntPtr nativeTex, MipmapLimitDescriptor mipmapLimitDescriptor); // 0x00000001821DADB0-0x00000001821DB020
		[ExcludeFromDocs]
		public Texture2D(int width, int height, DefaultFormat format, TextureCreationFlags flags); // 0x00000001821DB390-0x00000001821DB460
		[ExcludeFromDocs]
		public Texture2D(int width, int height, DefaultFormat format, int mipCount, TextureCreationFlags flags); // 0x00000001821DB310-0x00000001821DB390
		[ExcludeFromDocs]
		[Obsolete("Please provide mipmap limit information using a MipmapLimitDescriptor argument", false)]
		public Texture2D(int width, int height, DefaultFormat format, int mipCount, string mipmapLimitGroupName, TextureCreationFlags flags); // 0x00000001821DB660-0x00000001821DB710
		[ExcludeFromDocs]
		public Texture2D(int width, int height, DefaultFormat format, int mipCount, TextureCreationFlags flags, MipmapLimitDescriptor mipmapLimitDescriptor); // 0x00000001821DAA50-0x00000001821DAAD0
		[ExcludeFromDocs]
		public Texture2D(int width, int height, GraphicsFormat format, TextureCreationFlags flags); // 0x00000001821DAB20-0x00000001821DABE0
		[ExcludeFromDocs]
		public Texture2D(int width, int height, GraphicsFormat format, int mipCount, TextureCreationFlags flags); // 0x00000001821DAAD0-0x00000001821DAB20
		[ExcludeFromDocs]
		[Obsolete("Please provide mipmap limit information using a MipmapLimitDescriptor argument", false)]
		public Texture2D(int width, int height, GraphicsFormat format, int mipCount, string mipmapLimitGroupName, TextureCreationFlags flags); // 0x00000001821DB020-0x00000001821DB0C0
		[ExcludeFromDocs]
		public Texture2D(int width, int height, GraphicsFormat format, int mipCount, TextureCreationFlags flags, MipmapLimitDescriptor mipmapLimitDescriptor); // 0x00000001821DB270-0x00000001821DB2C0
		internal Texture2D(int width, int height, TextureFormat textureFormat, int mipCount, bool linear, IntPtr nativeTex, bool createUninitialized, MipmapLimitDescriptor mipmapLimitDescriptor); // 0x00000001821DB0C0-0x00000001821DB270
		public Texture2D(int width, int height, [DefaultValue("TextureFormat.RGBA32")] TextureFormat textureFormat, [DefaultValue("-1")] int mipCount, [DefaultValue("false")] bool linear); // 0x00000001821DB2C0-0x00000001821DB310
		public Texture2D(int width, int height, [DefaultValue("TextureFormat.RGBA32")] TextureFormat textureFormat, [DefaultValue("-1")] int mipCount, [DefaultValue("false")] bool linear, [DefaultValue("false")] bool createUninitialized); // 0x00000001821DB530-0x00000001821DB590
		public Texture2D(int width, int height, [DefaultValue("TextureFormat.RGBA32")] TextureFormat textureFormat, [DefaultValue("-1")] int mipCount, [DefaultValue("false")] bool linear, [DefaultValue("false")] bool createUninitialized, MipmapLimitDescriptor mipmapLimitDescriptor); // 0x00000001821DA9F0-0x00000001821DAA50
		[Obsolete("Please provide mipmap limit information using a MipmapLimitDescriptor argument", false)]
		public Texture2D(int width, int height, [DefaultValue("TextureFormat.RGBA32")] TextureFormat textureFormat, [DefaultValue("-1")] int mipCount, [DefaultValue("false")] bool linear, [DefaultValue("false")] bool createUninitialized, [DefaultValue("true")] bool ignoreMipmapLimit, [DefaultValue("null")] string mipmapLimitGroupName); // 0x00000001821DB7F0-0x00000001821DB8B0
		public Texture2D(int width, int height, [DefaultValue("TextureFormat.RGBA32")] TextureFormat textureFormat, [DefaultValue("true")] bool mipChain, [DefaultValue("false")] bool linear); // 0x00000001821DB460-0x00000001821DB530
		public Texture2D(int width, int height, [DefaultValue("TextureFormat.RGBA32")] TextureFormat textureFormat, [DefaultValue("true")] bool mipChain, [DefaultValue("false")] bool linear, [DefaultValue("false")] bool createUninitialized); // 0x00000001821DB710-0x00000001821DB7F0
		public Texture2D(int width, int height, TextureFormat textureFormat, bool mipChain); // 0x00000001821DB590-0x00000001821DB660
		public Texture2D(int width, int height); // 0x00000001821DABE0-0x00000001821DADB0
	
		// Methods
		private bool IgnoreMipmapLimit(); // 0x00000001821D8740-0x00000001821D87A0
		private void SetIgnoreMipmapLimitAndReload(bool value); // 0x00000001821D9C20-0x00000001821D9C80
		public void Compress(bool highQuality); // 0x00000001821D6F90-0x00000001821D6FF0
		[FreeFunction("Texture2DScripting::CreateEmpty")]
		private static bool Internal_CreateEmptyImpl([Writable] Texture2D mono); // 0x00000001821D87A0-0x00000001821D87E0
		[FreeFunction("Texture2DScripting::Create")]
		private static bool Internal_CreateImpl([Writable] Texture2D mono, int w, int h, int mipCount, GraphicsFormat format, TextureColorSpace colorSpace, TextureCreationFlags flags, IntPtr nativeTex, bool ignoreMipmapLimit, string mipmapLimitGroupName); // 0x00000001821D8860-0x00000001821D8A30
		private static void Internal_Create([Writable] Texture2D mono, int w, int h, int mipCount, GraphicsFormat format, TextureColorSpace colorSpace, TextureCreationFlags flags, IntPtr nativeTex, bool ignoreMipmapLimit, string mipmapLimitGroupName); // 0x00000001821D8A30-0x00000001821D8AF0
		[NativeName("Apply")]
		private void ApplyImpl(bool updateMipmaps, bool makeNoLongerReadable); // 0x00000001821D6CB0-0x00000001821D6D20
		[NativeName("Reinitialize")]
		private bool ReinitializeImpl(int width, int height); // 0x00000001821D9560-0x00000001821D95D0
		[NativeName("SetPixel")]
		private void SetPixelImpl(int image, int mip, int x, int y, Color color); // 0x00000001821D9F10-0x00000001821D9FA0
		[NativeName("GetPixel")]
		private Color GetPixelImpl(int image, int mip, int x, int y); // 0x00000001821D7F50-0x00000001821D7FF0
		[NativeName("GetPixelBilinear")]
		private Color GetPixelBilinearImpl(int image, int mip, float u, float v); // 0x00000001821D7C70-0x00000001821D7D10
		[FreeFunction(Name = "Texture2DScripting::ReinitializeWithFormat", HasExplicitThis = true)]
		private bool ReinitializeWithFormatImpl(int width, int height, GraphicsFormat format, bool hasMipMap); // 0x00000001821D9640-0x00000001821D96D0
		[FreeFunction(Name = "Texture2DScripting::ReinitializeWithTextureFormat", HasExplicitThis = true)]
		private bool ReinitializeWithTextureFormatImpl(int width, int height, TextureFormat textureFormat, bool hasMipMap); // 0x00000001821D9740-0x00000001821D97D0
		[FreeFunction(Name = "Texture2DScripting::ReadPixels", HasExplicitThis = true)]
		private void ReadPixelsImpl(Rect source, int destX, int destY, bool recalculateMipMaps); // 0x00000001821D92E0-0x00000001821D9370
		[FreeFunction(Name = "Texture2DScripting::SetPixels", HasExplicitThis = true, ThrowsException = true)]
		private void SetPixelsImpl(int x, int y, int w, int h, Color[] pixel, int miplevel, int frame); // 0x00000001821DA360-0x00000001821DA470
		[FreeFunction(Name = "Texture2DScripting::LoadRawData", HasExplicitThis = true)]
		private bool LoadRawTextureDataImpl(IntPtr data, ulong size); // 0x00000001821D8D00-0x00000001821D8D70
		[FreeFunction(Name = "Texture2DScripting::LoadRawData", HasExplicitThis = true)]
		private bool LoadRawTextureDataImplArray(byte[] data); // 0x00000001821D8BE0-0x00000001821D8CA0
		[FreeFunction(Name = "Texture2DScripting::SetPixelDataSpan", HasExplicitThis = true, ThrowsException = true)]
		private bool SetPixelDataImplSpan(Span<byte> data, int mipLevel, int elementSize, int dataArraySize, int sourceDataStartIndex = 0 /* Metadata: 0x0069D3DD */); // 0x00000001821D9CF0-0x00000001821D9DC0
		[FreeFunction(Name = "Texture2DScripting::SetPixelData", HasExplicitThis = true, ThrowsException = true)]
		private bool SetPixelDataImpl(IntPtr data, int mipLevel, int elementSize, int dataArraySize, int sourceDataStartIndex = 0 /* Metadata: 0x0069D3DE */); // 0x00000001821D9E30-0x00000001821D9EB0
		private ulong GetDataSize(); // 0x00000001821D7BB0-0x00000001821D7C10
		private IntPtr GetWritableImageData(int mipLevel = 0 /* Metadata: 0x0069D3DF */); // 0x00000001821D8660-0x00000001821D8700
		[FreeFunction("Texture2DScripting::GenerateAtlas")]
		private static void GenerateAtlasImpl(Vector2[] sizes, int padding, int atlasSize, out Rect[] rect); // 0x00000001821D77C0-0x00000001821D78C0
		[FreeFunction(Name = "GetTextureStreamingManager().ClearRequestedMipmapLevel", HasExplicitThis = true)]
		public void ClearRequestedMipmapLevel(); // 0x00000001821D6EE0-0x00000001821D6F40
		[FreeFunction(Name = "GetTextureStreamingManager().IsRequestedMipmapLevelLoaded", HasExplicitThis = true)]
		public bool IsRequestedMipmapLevelLoaded(); // 0x00000001821D8B30-0x00000001821D8B90
		[FreeFunction(Name = "GetTextureStreamingManager().ClearMinimumMipmapLevel", HasExplicitThis = true)]
		public void ClearMinimumMipmapLevel(); // 0x00000001821D6E40-0x00000001821D6EA0
		[FreeFunction("Texture2DScripting::UpdateExternalTexture", HasExplicitThis = true)]
		public void UpdateExternalTexture(IntPtr nativeTex); // 0x00000001821DA770-0x00000001821DA7D0
		[FreeFunction("Texture2DScripting::SetAllPixels32", HasExplicitThis = true, ThrowsException = true)]
		private void SetAllPixels32(Color32[] colors, int miplevel); // 0x00000001821D99B0-0x00000001821D9A70
		[FreeFunction("Texture2DScripting::SetBlockOfPixels32", HasExplicitThis = true, ThrowsException = true)]
		private void SetBlockOfPixels32(int x, int y, int blockWidth, int blockHeight, Color32[] colors, int miplevel); // 0x00000001821D9AD0-0x00000001821D9BD0
		[FreeFunction("Texture2DScripting::GetRawTextureData", HasExplicitThis = true, ThrowsException = true)]
		public byte[] GetRawTextureData(); // 0x00000001821D8600-0x00000001821D8660
		[FreeFunction("Texture2DScripting::GetPixels", HasExplicitThis = true, ThrowsException = true)]
		public Color[] GetPixels(int x, int y, int blockWidth, int blockHeight, [DefaultValue("0")] int miplevel); // 0x00000001821D8540-0x00000001821D85C0
		[ExcludeFromDocs]
		public Color[] GetPixels(int x, int y, int blockWidth, int blockHeight); // 0x00000001821D8330-0x00000001821D83B0
		[FreeFunction("Texture2DScripting::GetPixels32", HasExplicitThis = true, ThrowsException = true)]
		public Color32[] GetPixels32([DefaultValue("0")] int miplevel); // 0x00000001821D8210-0x00000001821D8270
		[ExcludeFromDocs]
		public Color32[] GetPixels32(); // 0x00000001821D8270-0x00000001821D82D0
		[FreeFunction("Texture2DScripting::PackTextures", HasExplicitThis = true)]
		public Rect[] PackTextures(Texture2D[] textures, int padding, int maximumAtlasSize, bool makeNoLongerReadable); // 0x00000001821D91E0-0x00000001821D9270
		public Rect[] PackTextures(Texture2D[] textures, int padding, int maximumAtlasSize); // 0x00000001821D90E0-0x00000001821D9160
		public Rect[] PackTextures(Texture2D[] textures, int padding); // 0x00000001821D9160-0x00000001821D91E0
		[FreeFunction(Name = "Texture2DScripting::CopyPixels", HasExplicitThis = true, ThrowsException = true)]
		private void CopyPixels_Full(Texture src); // 0x00000001821D7040-0x00000001821D70C0
		[FreeFunction(Name = "Texture2DScripting::CopyPixels", HasExplicitThis = true, ThrowsException = true)]
		private void CopyPixels_Slice(Texture src, int srcElement, int srcMip, int dstMip); // 0x00000001821D7240-0x00000001821D72E0
		[FreeFunction(Name = "Texture2DScripting::CopyPixels", HasExplicitThis = true, ThrowsException = true)]
		private void CopyPixels_Region(Texture src, int srcElement, int srcMip, int srcX, int srcY, int srcWidth, int srcHeight, int dstMip, int dstX, int dstY); // 0x00000001821D7130-0x00000001821D71D0
		internal bool ValidateFormat(TextureFormat format, int width, int height); // 0x00000001821DA900-0x00000001821DA9F0
		internal bool ValidateFormat(GraphicsFormat format, int width, int height); // 0x00000001821DA7D0-0x00000001821DA900
		public static Texture2D CreateExternalTexture(int width, int height, TextureFormat format, bool mipChain, bool linear, IntPtr nativeTex); // 0x00000001821D7630-0x00000001821D7760
		[ExcludeFromDocs]
		public void SetPixel(int x, int y, Color color); // 0x00000001821D9FA0-0x00000001821DA070
		public void SetPixel(int x, int y, Color color, [DefaultValue("0")] int mipLevel); // 0x00000001821DA070-0x00000001821DA140
		public void SetPixels(int x, int y, int blockWidth, int blockHeight, Color[] colors, [DefaultValue("0")] int miplevel); // 0x00000001821DA470-0x00000001821DA5C0
		[ExcludeFromDocs]
		public void SetPixels(int x, int y, int blockWidth, int blockHeight, Color[] colors); // 0x00000001821DA640-0x00000001821DA670
		public void SetPixels(Color[] colors, [DefaultValue("0")] int miplevel); // 0x00000001821DA670-0x00000001821DA720
		[ExcludeFromDocs]
		public void SetPixels(Color[] colors); // 0x00000001821DA5C0-0x00000001821DA640
		[ExcludeFromDocs]
		public Color GetPixel(int x, int y); // 0x00000001821D7FF0-0x00000001821D80E0
		public Color GetPixel(int x, int y, [DefaultValue("0")] int mipLevel); // 0x00000001821D80E0-0x00000001821D81D0
		[ExcludeFromDocs]
		public Color GetPixelBilinear(float u, float v); // 0x00000001821D7E00-0x00000001821D7EF0
		public Color GetPixelBilinear(float u, float v, [DefaultValue("0")] int mipLevel); // 0x00000001821D7D10-0x00000001821D7E00
		public void LoadRawTextureData(IntPtr data, int size); // 0x00000001821D8F10-0x00000001821D9070
		public void LoadRawTextureData(byte[] data); // 0x00000001821D8D70-0x00000001821D8F10
		public void LoadRawTextureData<T>(NativeArray<T> data)
			where T : struct;
		public void SetPixelData<T>(T[] data, int mipLevel, [DefaultValue("0")] int sourceDataStartIndex = 0 /* Metadata: 0x0069D3E0 */);
		public void SetPixelData<T>(NativeArray<T> data, int mipLevel, [DefaultValue("0")] int sourceDataStartIndex = 0 /* Metadata: 0x0069D3E1 */)
			where T : struct;
		public NativeArray<T> GetPixelData<T>(int mipLevel)
			where T : struct;
		public NativeArray<T> GetRawTextureData<T>()
			where T : struct;
		public void Apply([DefaultValue("true")] bool updateMipmaps, [DefaultValue("false")] bool makeNoLongerReadable); // 0x00000001821D6D20-0x00000001821D6DE0
		[ExcludeFromDocs]
		public void Apply(bool updateMipmaps); // 0x00000001821D6DF0-0x00000001821D6E00
		[ExcludeFromDocs]
		public void Apply(); // 0x00000001821D6DE0-0x00000001821D6DF0
		public bool Reinitialize(int width, int height); // 0x00000001821D97D0-0x00000001821D9880
		public bool Reinitialize(int width, int height, TextureFormat format, bool hasMipMap); // 0x00000001821D9740-0x00000001821D97D0
		public bool Reinitialize(int width, int height, GraphicsFormat format, bool hasMipMap); // 0x00000001821D9880-0x00000001821D9950
		[Obsolete("Texture2D.Resize(int, int) has been deprecated because it actually reinitializes the texture. Use Texture2D.Reinitialize(int, int) instead (UnityUpgradable) -> Reinitialize([*] System.Int32, [*] System.Int32)", false)]
		public bool Resize(int width, int height); // 0x00000001821D97D0-0x00000001821D9880
		[Obsolete("Texture2D.Resize(int, int, TextureFormat, bool) has been deprecated because it actually reinitializes the texture. Use Texture2D.Reinitialize(int, int, TextureFormat, bool) instead (UnityUpgradable) -> Reinitialize([*] System.Int32, [*] System.Int32, UnityEngine.TextureFormat, [*] System.Boolean)", false)]
		public bool Resize(int width, int height, TextureFormat format, bool hasMipMap); // 0x00000001821D9740-0x00000001821D97D0
		[Obsolete("Texture2D.Resize(int, int, GraphicsFormat, bool) has been deprecated because it actually reinitializes the texture. Use Texture2D.Reinitialize(int, int, GraphicsFormat, bool) instead (UnityUpgradable) -> Reinitialize([*] System.Int32, [*] System.Int32, UnityEngine.Experimental.Rendering.GraphicsFormat, [*] System.Boolean)", false)]
		public bool Resize(int width, int height, GraphicsFormat format, bool hasMipMap); // 0x00000001821D9880-0x00000001821D9950
		public void ReadPixels(Rect source, int destX, int destY, [DefaultValue("true")] bool recalculateMipMaps); // 0x00000001821D9440-0x00000001821D9510
		[ExcludeFromDocs]
		public void ReadPixels(Rect source, int destX, int destY); // 0x00000001821D9370-0x00000001821D9440
		public static bool GenerateAtlas(Vector2[] sizes, int padding, int atlasSize, List<Rect> results); // 0x00000001821D78C0-0x00000001821D7B70
		public void SetPixels32(Color32[] colors, [DefaultValue("0")] int miplevel); // 0x00000001821D99B0-0x00000001821D9A70
		[ExcludeFromDocs]
		public void SetPixels32(Color32[] colors); // 0x00000001821DA140-0x00000001821DA200
		public void SetPixels32(int x, int y, int blockWidth, int blockHeight, Color32[] colors, [DefaultValue("0")] int miplevel); // 0x00000001821D9AD0-0x00000001821D9BD0
		[ExcludeFromDocs]
		public void SetPixels32(int x, int y, int blockWidth, int blockHeight, Color32[] colors); // 0x00000001821DA200-0x00000001821DA300
		public Color[] GetPixels([DefaultValue("0")] int miplevel); // 0x00000001821D83B0-0x00000001821D8480
		[ExcludeFromDocs]
		public Color[] GetPixels(); // 0x00000001821D8480-0x00000001821D8540
		public void CopyPixels(Texture src); // 0x00000001821D72E0-0x00000001821D73E0
		public void CopyPixels(Texture src, int srcElement, int srcMip, int dstMip); // 0x00000001821D7510-0x00000001821D7630
		public void CopyPixels(Texture src, int srcElement, int srcMip, int srcX, int srcY, int srcWidth, int srcHeight, int dstMip, int dstX, int dstY); // 0x00000001821D73E0-0x00000001821D7510
		private static TextureFormat get_format_Injected(IntPtr _unity_self); // 0x00000001821DBB20-0x00000001821DBB60
		private static bool IgnoreMipmapLimit_Injected(IntPtr _unity_self); // 0x00000001821D8700-0x00000001821D8740
		private static void SetIgnoreMipmapLimitAndReload_Injected(IntPtr _unity_self, bool value); // 0x00000001821D9BD0-0x00000001821D9C20
		private static void get_mipmapLimitGroup_Injected(IntPtr _unity_self, ); // 0x00000001821DC0A0-0x00000001821DC0F0
		private static int get_activeMipmapLimit_Injected(IntPtr _unity_self); // 0x00000001821DB8B0-0x00000001821DB8F0
		private static IntPtr get_whiteTexture_Injected(); // 0x00000001821DC580-0x00000001821DC5B0
		private static IntPtr get_blackTexture_Injected(); // 0x00000001821DB950-0x00000001821DB980
		private static IntPtr get_redTexture_Injected(); // 0x00000001821DC270-0x00000001821DC2A0
		private static IntPtr get_grayTexture_Injected(); // 0x00000001821DBBC0-0x00000001821DBBF0
		private static IntPtr get_linearGrayTexture_Injected(); // 0x00000001821DBD90-0x00000001821DBDC0
		private static IntPtr get_normalTexture_Injected(); // 0x00000001821DC1E0-0x00000001821DC210
		private static void Compress_Injected(IntPtr _unity_self, bool highQuality); // 0x00000001821D6F40-0x00000001821D6F90
		private static bool Internal_CreateImpl_Injected([Writable] Texture2D mono, int w, int h, int mipCount, GraphicsFormat format, TextureColorSpace colorSpace, TextureCreationFlags flags, IntPtr nativeTex, bool ignoreMipmapLimit, ref ManagedSpanWrapper mipmapLimitGroupName); // 0x00000001821D87E0-0x00000001821D8860
		private static new bool get_isReadable_Injected(IntPtr _unity_self); // 0x00000001821DBCF0-0x00000001821DBD30
		private static bool get_vtOnly_Injected(IntPtr _unity_self); // 0x00000001821DC4E0-0x00000001821DC520
		private static void ApplyImpl_Injected(IntPtr _unity_self, bool updateMipmaps, bool makeNoLongerReadable); // 0x00000001821D6C50-0x00000001821D6CB0
		private static bool ReinitializeImpl_Injected(IntPtr _unity_self, int width, int height); // 0x00000001821D9510-0x00000001821D9560
		private static void SetPixelImpl_Injected(IntPtr _unity_self, int image, int mip, int x, int y, in Color color); // 0x00000001821D9EB0-0x00000001821D9F10
		private static void GetPixelImpl_Injected(IntPtr _unity_self, int image, int mip, int x, int y, ); // 0x00000001821D7EF0-0x00000001821D7F50
		private static void GetPixelBilinearImpl_Injected(IntPtr _unity_self, int image, int mip, float u, float v, ); // 0x00000001821D7C10-0x00000001821D7C70
		private static bool ReinitializeWithFormatImpl_Injected(IntPtr _unity_self, int width, int height, GraphicsFormat format, bool hasMipMap); // 0x00000001821D95D0-0x00000001821D9640
		private static bool ReinitializeWithTextureFormatImpl_Injected(IntPtr _unity_self, int width, int height, TextureFormat textureFormat, bool hasMipMap); // 0x00000001821D96D0-0x00000001821D9740
		private static void ReadPixelsImpl_Injected(IntPtr _unity_self, in Rect source, int destX, int destY, bool recalculateMipMaps); // 0x00000001821D9270-0x00000001821D92E0
		private static void SetPixelsImpl_Injected(IntPtr _unity_self, int x, int y, int w, int h, ref ManagedSpanWrapper pixel, int miplevel, int frame); // 0x00000001821DA300-0x00000001821DA360
		private static bool LoadRawTextureDataImpl_Injected(IntPtr _unity_self, IntPtr data, ulong size); // 0x00000001821D8CA0-0x00000001821D8D00
		private static bool LoadRawTextureDataImplArray_Injected(IntPtr _unity_self, ref ManagedSpanWrapper data); // 0x00000001821D8B90-0x00000001821D8BE0
		private static bool SetPixelDataImplSpan_Injected(IntPtr _unity_self, ref ManagedSpanWrapper data, int mipLevel, int elementSize, int dataArraySize, int sourceDataStartIndex); // 0x00000001821D9C80-0x00000001821D9CF0
		private static bool SetPixelDataImpl_Injected(IntPtr _unity_self, IntPtr data, int mipLevel, int elementSize, int dataArraySize, int sourceDataStartIndex); // 0x00000001821D9DC0-0x00000001821D9E30
		private static ulong GetDataSize_Injected(IntPtr _unity_self); // 0x00000001821D7B70-0x00000001821D7BB0
		private static void GenerateAtlasImpl_Injected(ref ManagedSpanWrapper sizes, int padding, int atlasSize, out BlittableArrayWrapper rect); // 0x00000001821D7760-0x00000001821D77C0
		private static bool get_isPreProcessed_Injected(IntPtr _unity_self); // 0x00000001821DBC50-0x00000001821DBC90
		private static bool get_streamingMipmaps_Injected(IntPtr _unity_self); // 0x00000001821DC440-0x00000001821DC480
		private static int get_streamingMipmapsPriority_Injected(IntPtr _unity_self); // 0x00000001821DC3A0-0x00000001821DC3E0
		private static int get_requestedMipmapLevel_Injected(IntPtr _unity_self); // 0x00000001821DC300-0x00000001821DC340
		private static void set_requestedMipmapLevel_Injected(IntPtr _unity_self, int value); // 0x00000001821DC800-0x00000001821DC840
		private static int get_minimumMipmapLevel_Injected(IntPtr _unity_self); // 0x00000001821DC000-0x00000001821DC040
		private static void set_minimumMipmapLevel_Injected(IntPtr _unity_self, int value); // 0x00000001821DC760-0x00000001821DC7A0
		private static bool get_loadAllMips_Injected(IntPtr _unity_self); // 0x00000001821DBE20-0x00000001821DBE60
		private static void set_loadAllMips_Injected(IntPtr _unity_self, bool value); // 0x00000001821DC6B0-0x00000001821DC700
		private static int get_calculatedMipmapLevel_Injected(IntPtr _unity_self); // 0x00000001821DB9E0-0x00000001821DBA20
		private static int get_desiredMipmapLevel_Injected(IntPtr _unity_self); // 0x00000001821DBA80-0x00000001821DBAC0
		private static int get_loadingMipmapLevel_Injected(IntPtr _unity_self); // 0x00000001821DBF60-0x00000001821DBFA0
		private static int get_loadedMipmapLevel_Injected(IntPtr _unity_self); // 0x00000001821DBEC0-0x00000001821DBF00
		private static void ClearRequestedMipmapLevel_Injected(IntPtr _unity_self); // 0x00000001821D6EA0-0x00000001821D6EE0
		private static bool IsRequestedMipmapLevelLoaded_Injected(IntPtr _unity_self); // 0x00000001821D8AF0-0x00000001821D8B30
		private static void ClearMinimumMipmapLevel_Injected(IntPtr _unity_self); // 0x00000001821D6E00-0x00000001821D6E40
		private static void UpdateExternalTexture_Injected(IntPtr _unity_self, IntPtr nativeTex); // 0x00000001821DA720-0x00000001821DA770
		private static void SetAllPixels32_Injected(IntPtr _unity_self, ref ManagedSpanWrapper colors, int miplevel); // 0x00000001821D9950-0x00000001821D99B0
		private static void SetBlockOfPixels32_Injected(IntPtr _unity_self, int x, int y, int blockWidth, int blockHeight, ref ManagedSpanWrapper colors, int miplevel); // 0x00000001821D9A70-0x00000001821D9AD0
		private static byte[] GetRawTextureData_Injected(IntPtr _unity_self); // 0x00000001821D85C0-0x00000001821D8600
		private static Color[] GetPixels_Injected(IntPtr _unity_self, int x, int y, int blockWidth, int blockHeight, [DefaultValue("0")] int miplevel); // 0x00000001821D82D0-0x00000001821D8330
		private static Color32[] GetPixels32_Injected(IntPtr _unity_self, [DefaultValue("0")] int miplevel); // 0x00000001821D81D0-0x00000001821D8210
		private static Rect[] PackTextures_Injected(IntPtr _unity_self, Texture2D[] textures, int padding, int maximumAtlasSize, bool makeNoLongerReadable); // 0x00000001821D9070-0x00000001821D90E0
		private static void CopyPixels_Full_Injected(IntPtr _unity_self, IntPtr src); // 0x00000001821D6FF0-0x00000001821D7040
		private static void CopyPixels_Slice_Injected(IntPtr _unity_self, IntPtr src, int srcElement, int srcMip, int dstMip); // 0x00000001821D71D0-0x00000001821D7240
		private static void CopyPixels_Region_Injected(IntPtr _unity_self, IntPtr src, int srcElement, int srcMip, int srcX, int srcY, int srcWidth, int srcHeight, int dstMip, int dstX, int dstY); // 0x00000001821D70C0-0x00000001821D7130
	}
}
