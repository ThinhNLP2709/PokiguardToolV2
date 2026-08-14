namespace UnityEngine;

[ExcludeFromPreset]
[NativeHeader("Runtime/Graphics/CubemapArrayTexture.h")]
public sealed class CubemapArray : Texture
{

	public virtual bool isReadable
	{
		 get { } //Length: 118
	}

	public CubemapArray(int width, int cubemapCount, TextureFormat textureFormat, int mipCount, bool linear, bool createUninitialized) { }

	public CubemapArray(int width, int cubemapCount, TextureFormat textureFormat, bool mipChain) { }

	[ExcludeFromDocs]
	public CubemapArray(int width, int cubemapCount, TextureFormat textureFormat, bool mipChain, bool linear) { }

	[ExcludeFromDocs]
	public CubemapArray(int width, int cubemapCount, DefaultFormat format, TextureCreationFlags flags) { }

	[ExcludeFromDocs]
	public CubemapArray(int width, int cubemapCount, DefaultFormat format, TextureCreationFlags flags, int mipCount) { }

	[RequiredByNativeCode]
	public CubemapArray(int width, int cubemapCount, GraphicsFormat format, TextureCreationFlags flags) { }

	[ExcludeFromDocs]
	public CubemapArray(int width, int cubemapCount, GraphicsFormat format, TextureCreationFlags flags, int mipCount) { }

	public CubemapArray(int width, int cubemapCount, TextureFormat textureFormat, int mipCount, bool linear) { }

	public CubemapArray(int width, int cubemapCount, TextureFormat textureFormat, bool mipChain, bool linear, bool createUninitialized) { }

	[ExcludeFromDocs]
	public void Apply() { }

	public void Apply(bool updateMipmaps, bool makeNoLongerReadable) { }

	[FreeFunction(Name = "CubemapArrayScripting::Apply", HasExplicitThis = True)]
	private void ApplyImpl(bool updateMipmaps, bool makeNoLongerReadable) { }

	private static void ApplyImpl_Injected(IntPtr _unity_self, bool updateMipmaps, bool makeNoLongerReadable) { }

	public virtual bool get_isReadable() { }

	private static bool get_isReadable_Injected(IntPtr _unity_self) { }

	private static void Internal_Create(CubemapArray mono, int ext, int count, int mipCount, GraphicsFormat format, TextureColorSpace colorSpace, TextureCreationFlags flags) { }

	[FreeFunction("CubemapArrayScripting::Create")]
	private static bool Internal_CreateImpl(CubemapArray mono, int ext, int count, int mipCount, GraphicsFormat format, TextureColorSpace colorSpace, TextureCreationFlags flags) { }

	[FreeFunction(Name = "CubemapArrayScripting::SetPixels", HasExplicitThis = True, ThrowsException = True)]
	public void SetPixels(Color[] colors, CubemapFace face, int arrayElement, int miplevel) { }

	public void SetPixels(Color[] colors, CubemapFace face, int arrayElement) { }

	private static void SetPixels_Injected(IntPtr _unity_self, ref ManagedSpanWrapper colors, CubemapFace face, int arrayElement, int miplevel) { }

	private static void ValidateIsNotCrunched(TextureCreationFlags flags) { }

}

