namespace UnityEngine;

[ExcludeFromPreset]
[HelpURL("texture-type-default")]
[NativeHeader("Runtime/Graphics/GeneratedTextures.h")]
[NativeHeader("Runtime/Graphics/Texture2D.h")]
[UsedByNativeCode]
public sealed class Texture2D : Texture
{
	internal const int streamingMipmapsPriorityMin = -128; //Field offset: 0x0
	internal const int streamingMipmapsPriorityMax = 127; //Field offset: 0x0

	[StaticAccessor("builtintex", StaticAccessorType::DoubleColon (2))]
	public static Texture2D blackTexture
	{
		 get { } //Length: 84
	}

	public TextureFormat format
	{
		[NativeName("GetTextureFormat")]
		 get { } //Length: 118
	}

	public virtual bool isReadable
	{
		 get { } //Length: 118
	}

	[StaticAccessor("builtintex", StaticAccessorType::DoubleColon (2))]
	public static Texture2D whiteTexture
	{
		 get { } //Length: 84
	}

	internal Texture2D(int width, int height, GraphicsFormat format, TextureCreationFlags flags, int mipCount, IntPtr nativeTex, MipmapLimitDescriptor mipmapLimitDescriptor) { }

	public Texture2D(int width, int height, TextureFormat textureFormat, bool mipChain) { }

	public Texture2D(int width, int height, TextureFormat textureFormat, int mipCount, bool linear) { }

	internal Texture2D(int width, int height, TextureFormat textureFormat, int mipCount, bool linear, IntPtr nativeTex, bool createUninitialized, MipmapLimitDescriptor mipmapLimitDescriptor) { }

	[ExcludeFromDocs]
	public Texture2D(int width, int height, GraphicsFormat format, TextureCreationFlags flags) { }

	[ExcludeFromDocs]
	public Texture2D(int width, int height, DefaultFormat format, TextureCreationFlags flags) { }

	[ExcludeFromDocs]
	public void Apply() { }

	public void Apply(bool updateMipmaps, bool makeNoLongerReadable) { }

	[NativeName("Apply")]
	private void ApplyImpl(bool updateMipmaps, bool makeNoLongerReadable) { }

	private static void ApplyImpl_Injected(IntPtr _unity_self, bool updateMipmaps, bool makeNoLongerReadable) { }

	public static Texture2D get_blackTexture() { }

	private static IntPtr get_blackTexture_Injected() { }

	[NativeName("GetTextureFormat")]
	public TextureFormat get_format() { }

	private static TextureFormat get_format_Injected(IntPtr _unity_self) { }

	public virtual bool get_isReadable() { }

	private static bool get_isReadable_Injected(IntPtr _unity_self) { }

	public static Texture2D get_whiteTexture() { }

	private static IntPtr get_whiteTexture_Injected() { }

	private ulong GetImageDataSize() { }

	private static ulong GetImageDataSize_Injected(IntPtr _unity_self) { }

	[ExcludeFromDocs]
	public Color GetPixelBilinear(float u, float v) { }

	[NativeName("GetPixelBilinear")]
	private Color GetPixelBilinearImpl(int image, int mip, float u, float v) { }

	private static void GetPixelBilinearImpl_Injected(IntPtr _unity_self, int image, int mip, float u, float v, out Color ret) { }

	public NativeArray<T> GetRawTextureData() { }

	private IntPtr GetWritableImageData(int frame) { }

	private static IntPtr GetWritableImageData_Injected(IntPtr _unity_self, int frame) { }

	private static void Internal_Create(Texture2D mono, int w, int h, int mipCount, GraphicsFormat format, TextureColorSpace colorSpace, TextureCreationFlags flags, IntPtr nativeTex, bool ignoreMipmapLimit, string mipmapLimitGroupName) { }

	[FreeFunction("Texture2DScripting::Create")]
	private static bool Internal_CreateImpl(Texture2D mono, int w, int h, int mipCount, GraphicsFormat format, TextureColorSpace colorSpace, TextureCreationFlags flags, IntPtr nativeTex, bool ignoreMipmapLimit, string mipmapLimitGroupName) { }

	private static bool Internal_CreateImpl_Injected(Texture2D mono, int w, int h, int mipCount, GraphicsFormat format, TextureColorSpace colorSpace, TextureCreationFlags flags, IntPtr nativeTex, bool ignoreMipmapLimit, ref ManagedSpanWrapper mipmapLimitGroupName) { }

	public bool Reinitialize(int width, int height) { }

	public bool Reinitialize(int width, int height, TextureFormat format, bool hasMipMap) { }

	[NativeName("Reinitialize")]
	private bool ReinitializeImpl(int width, int height) { }

	private static bool ReinitializeImpl_Injected(IntPtr _unity_self, int width, int height) { }

	[FreeFunction(Name = "Texture2DScripting::ReinitializeWithTextureFormat", HasExplicitThis = True)]
	private bool ReinitializeWithTextureFormatImpl(int width, int height, TextureFormat textureFormat, bool hasMipMap) { }

	private static bool ReinitializeWithTextureFormatImpl_Injected(IntPtr _unity_self, int width, int height, TextureFormat textureFormat, bool hasMipMap) { }

	[FreeFunction("Texture2DScripting::SetAllPixels32", HasExplicitThis = True, ThrowsException = True)]
	private void SetAllPixels32(Color32[] colors, int miplevel) { }

	private static void SetAllPixels32_Injected(IntPtr _unity_self, ref ManagedSpanWrapper colors, int miplevel) { }

	[ExcludeFromDocs]
	public void SetPixel(int x, int y, Color color) { }

	[NativeName("SetPixel")]
	private void SetPixelImpl(int image, int mip, int x, int y, Color color) { }

	private static void SetPixelImpl_Injected(IntPtr _unity_self, int image, int mip, int x, int y, in Color color) { }

	[ExcludeFromDocs]
	public void SetPixels(Color[] colors) { }

	public void SetPixels(int x, int y, int blockWidth, int blockHeight, Color[] colors, int miplevel) { }

	public void SetPixels32(Color32[] colors, int miplevel) { }

	[ExcludeFromDocs]
	public void SetPixels32(Color32[] colors) { }

	[FreeFunction(Name = "Texture2DScripting::SetPixels", HasExplicitThis = True, ThrowsException = True)]
	private void SetPixelsImpl(int x, int y, int w, int h, Color[] pixel, int miplevel, int frame) { }

	private static void SetPixelsImpl_Injected(IntPtr _unity_self, int x, int y, int w, int h, ref ManagedSpanWrapper pixel, int miplevel, int frame) { }

	internal bool ValidateFormat(GraphicsFormat format, int width, int height) { }

	internal bool ValidateFormat(TextureFormat format, int width, int height) { }

}

