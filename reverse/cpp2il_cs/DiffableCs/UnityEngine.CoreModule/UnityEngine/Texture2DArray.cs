namespace UnityEngine;

[ExcludeFromPreset]
[NativeHeader("Runtime/Graphics/Texture2DArray.h")]
public sealed class Texture2DArray : Texture
{

	public static int allSlices
	{
		[NativeName("GetAllTextureLayersIdentifier")]
		 get { } //Length: 42
	}

	public virtual bool isReadable
	{
		 get { } //Length: 118
	}

	[ExcludeFromDocs]
	public Texture2DArray(int width, int height, int depth, GraphicsFormat format, TextureCreationFlags flags, int mipCount) { }

	[ExcludeFromDocs]
	public Texture2DArray(int width, int height, int depth, TextureFormat textureFormat, bool mipChain) { }

	public Texture2DArray(int width, int height, int depth, TextureFormat textureFormat, bool mipChain, bool linear) { }

	public Texture2DArray(int width, int height, int depth, TextureFormat textureFormat, bool mipChain, bool linear, bool createUninitialized) { }

	public Texture2DArray(int width, int height, int depth, TextureFormat textureFormat, int mipCount, bool linear) { }

	public Texture2DArray(int width, int height, int depth, TextureFormat textureFormat, int mipCount, bool linear, bool createUninitialized) { }

	[ExcludeFromDocs]
	public Texture2DArray(int width, int height, int depth, DefaultFormat format, TextureCreationFlags flags) { }

	[ExcludeFromDocs]
	public Texture2DArray(int width, int height, int depth, DefaultFormat format, TextureCreationFlags flags, int mipCount) { }

	[ExcludeFromDocs]
	public Texture2DArray(int width, int height, int depth, DefaultFormat format, TextureCreationFlags flags, int mipCount, MipmapLimitDescriptor mipmapLimitDescriptor) { }

	[RequiredByNativeCode]
	public Texture2DArray(int width, int height, int depth, GraphicsFormat format, TextureCreationFlags flags) { }

	public Texture2DArray(int width, int height, int depth, TextureFormat textureFormat, int mipCount, bool linear, bool createUninitialized, MipmapLimitDescriptor mipmapLimitDescriptor) { }

	[ExcludeFromDocs]
	public Texture2DArray(int width, int height, int depth, GraphicsFormat format, TextureCreationFlags flags, int mipCount, MipmapLimitDescriptor mipmapLimitDescriptor) { }

	[NativeName("GetAllTextureLayersIdentifier")]
	public static int get_allSlices() { }

	public virtual bool get_isReadable() { }

	private static bool get_isReadable_Injected(IntPtr _unity_self) { }

	private static void Internal_Create(Texture2DArray mono, int w, int h, int d, int mipCount, GraphicsFormat format, TextureColorSpace colorSpace, TextureCreationFlags flags, bool ignoreMipmapLimit, string mipmapLimitGroupName) { }

	[FreeFunction("Texture2DArrayScripting::Create")]
	private static bool Internal_CreateImpl(Texture2DArray mono, int w, int h, int d, int mipCount, GraphicsFormat format, TextureColorSpace colorSpace, TextureCreationFlags flags, bool ignoreMipmapLimit, string mipmapLimitGroupName) { }

	private static bool Internal_CreateImpl_Injected(Texture2DArray mono, int w, int h, int d, int mipCount, GraphicsFormat format, TextureColorSpace colorSpace, TextureCreationFlags flags, bool ignoreMipmapLimit, ref ManagedSpanWrapper mipmapLimitGroupName) { }

	internal bool ValidateFormat(GraphicsFormat format, int width, int height) { }

	internal bool ValidateFormat(TextureFormat format, int width, int height) { }

	private static void ValidateIsNotCrunched(TextureCreationFlags flags) { }

}

