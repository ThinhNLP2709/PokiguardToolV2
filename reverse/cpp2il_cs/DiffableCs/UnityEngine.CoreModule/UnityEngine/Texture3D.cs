namespace UnityEngine;

[ExcludeFromPreset]
[NativeHeader("Runtime/Graphics/Texture3D.h")]
public sealed class Texture3D : Texture
{

	public virtual bool isReadable
	{
		 get { } //Length: 118
	}

	public Texture3D(int width, int height, int depth, TextureFormat textureFormat, int mipCount, IntPtr nativeTex, bool createUninitialized) { }

	public Texture3D(int width, int height, int depth, TextureFormat textureFormat, bool mipChain, IntPtr nativeTex) { }

	[ExcludeFromDocs]
	public Texture3D(int width, int height, int depth, DefaultFormat format, TextureCreationFlags flags) { }

	[ExcludeFromDocs]
	public Texture3D(int width, int height, int depth, DefaultFormat format, TextureCreationFlags flags, int mipCount) { }

	[ExcludeFromDocs]
	[RequiredByNativeCode]
	public Texture3D(int width, int height, int depth, GraphicsFormat format, TextureCreationFlags flags) { }

	[ExcludeFromDocs]
	public Texture3D(int width, int height, int depth, GraphicsFormat format, TextureCreationFlags flags, int mipCount) { }

	[ExcludeFromDocs]
	public Texture3D(int width, int height, int depth, TextureFormat textureFormat, int mipCount) { }

	public Texture3D(int width, int height, int depth, TextureFormat textureFormat, int mipCount, IntPtr nativeTex) { }

	public Texture3D(int width, int height, int depth, TextureFormat textureFormat, bool mipChain, bool createUninitialized) { }

	[ExcludeFromDocs]
	public Texture3D(int width, int height, int depth, TextureFormat textureFormat, bool mipChain) { }

	[ExcludeFromDocs]
	public void Apply() { }

	[ExcludeFromDocs]
	public void Apply(bool updateMipmaps) { }

	public void Apply(bool updateMipmaps, bool makeNoLongerReadable) { }

	[FreeFunction(Name = "Texture3DScripting::Apply", HasExplicitThis = True)]
	private void ApplyImpl(bool updateMipmaps, bool makeNoLongerReadable) { }

	private static void ApplyImpl_Injected(IntPtr _unity_self, bool updateMipmaps, bool makeNoLongerReadable) { }

	public virtual bool get_isReadable() { }

	private static bool get_isReadable_Injected(IntPtr _unity_self) { }

	private IntPtr GetImageData() { }

	private static IntPtr GetImageData_Injected(IntPtr _unity_self) { }

	public NativeArray<T> GetPixelData(int mipLevel) { }

	private static void Internal_Create(Texture3D mono, int w, int h, int d, int mipCount, GraphicsFormat format, TextureColorSpace colorSpace, TextureCreationFlags flags, IntPtr nativeTex) { }

	[FreeFunction("Texture3DScripting::Create")]
	private static bool Internal_CreateImpl(Texture3D mono, int w, int h, int d, int mipCount, GraphicsFormat format, TextureColorSpace colorSpace, TextureCreationFlags flags, IntPtr nativeTex) { }

	public void SetPixel(int x, int y, int z, Color color, int mipLevel) { }

	[NativeName("SetPixel")]
	private void SetPixelImpl(int mip, int x, int y, int z, Color color) { }

	private static void SetPixelImpl_Injected(IntPtr _unity_self, int mip, int x, int y, int z, in Color color) { }

	[FreeFunction(Name = "Texture3DScripting::SetPixels", HasExplicitThis = True, ThrowsException = True)]
	public void SetPixels(Color[] colors, int miplevel) { }

	private static void SetPixels_Injected(IntPtr _unity_self, ref ManagedSpanWrapper colors, int miplevel) { }

	private static void ValidateIsNotCrunched(TextureCreationFlags flags) { }

}

