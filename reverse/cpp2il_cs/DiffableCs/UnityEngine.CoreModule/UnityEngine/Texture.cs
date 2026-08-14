namespace UnityEngine;

[NativeHeader("Runtime/Graphics/Texture.h")]
[NativeHeader("Runtime/Streaming/TextureStreamingManager.h")]
[UsedByNativeCode]
public class Texture : object
{
	public static readonly int GenerateAllMips; //Field offset: 0x0

	internal ColorSpace activeTextureColorSpace
	{
		[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule", "Unity.UIElements"})]
		internal get { } //Length: 172
	}

	public int anisoLevel
	{
		 get { } //Length: 151
		 set { } //Length: 164
	}

	public override TextureDimension dimension
	{
		 get { } //Length: 151
		 set { } //Length: 62
	}

	public FilterMode filterMode
	{
		 get { } //Length: 151
		 set { } //Length: 164
	}

	public override GraphicsFormat graphicsFormat
	{
		 get { } //Length: 73
	}

	public override int height
	{
		 get { } //Length: 151
		 set { } //Length: 62
	}

	public override bool isReadable
	{
		 get { } //Length: 151
	}

	public float mipMapBias
	{
		 get { } //Length: 151
		 set { } //Length: 167
	}

	public int mipmapCount
	{
		[NativeName("GetMipmapCount")]
		 get { } //Length: 151
	}

	public static bool streamingTextureDiscardUnusedMips
	{
		[FreeFunction(Name = "GetTextureStreamingManager().GetDiscardUnusedMips")]
		 get { } //Length: 42
		[FreeFunction(Name = "GetTextureStreamingManager().SetDiscardUnusedMips")]
		 set { } //Length: 51
	}

	public Vector2 texelSize
	{
		[NativeName("GetTexelSize")]
		 get { } //Length: 168
	}

	public uint updateCount
	{
		 get { } //Length: 151
	}

	public override int width
	{
		 get { } //Length: 151
		 set { } //Length: 62
	}

	public TextureWrapMode wrapMode
	{
		[NativeName("GetWrapModeU")]
		 get { } //Length: 151
		 set { } //Length: 164
	}

	public TextureWrapMode wrapModeU
	{
		 set { } //Length: 164
	}

	public TextureWrapMode wrapModeV
	{
		 set { } //Length: 164
	}

	public TextureWrapMode wrapModeW
	{
		 set { } //Length: 164
	}

	private static Texture() { }

	protected Texture() { }

	internal UnityException CreateNativeArrayLengthOverflowException() { }

	internal UnityException CreateNonReadableException(Texture t) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule", "Unity.UIElements"})]
	internal ColorSpace get_activeTextureColorSpace() { }

	public int get_anisoLevel() { }

	private static int get_anisoLevel_Injected(IntPtr _unity_self) { }

	public override TextureDimension get_dimension() { }

	public FilterMode get_filterMode() { }

	private static FilterMode get_filterMode_Injected(IntPtr _unity_self) { }

	public override GraphicsFormat get_graphicsFormat() { }

	public override int get_height() { }

	public override bool get_isReadable() { }

	private static bool get_isReadable_Injected(IntPtr _unity_self) { }

	public float get_mipMapBias() { }

	private static float get_mipMapBias_Injected(IntPtr _unity_self) { }

	[NativeName("GetMipmapCount")]
	public int get_mipmapCount() { }

	private static int get_mipmapCount_Injected(IntPtr _unity_self) { }

	[FreeFunction(Name = "GetTextureStreamingManager().GetDiscardUnusedMips")]
	public static bool get_streamingTextureDiscardUnusedMips() { }

	[NativeName("GetTexelSize")]
	public Vector2 get_texelSize() { }

	private static void get_texelSize_Injected(IntPtr _unity_self, out Vector2 ret) { }

	public uint get_updateCount() { }

	private static uint get_updateCount_Injected(IntPtr _unity_self) { }

	public override int get_width() { }

	[NativeName("GetWrapModeU")]
	public TextureWrapMode get_wrapMode() { }

	private static TextureWrapMode get_wrapMode_Injected(IntPtr _unity_self) { }

	[ThreadSafe]
	private int GetDataHeight() { }

	private static int GetDataHeight_Injected(IntPtr _unity_self) { }

	[ThreadSafe]
	private int GetDataWidth() { }

	private static int GetDataWidth_Injected(IntPtr _unity_self) { }

	[ThreadSafe]
	private TextureDimension GetDimension() { }

	private static TextureDimension GetDimension_Injected(IntPtr _unity_self) { }

	internal ulong GetPixelDataOffset(int mipLevel, int element = 0) { }

	private static ulong GetPixelDataOffset_Injected(IntPtr _unity_self, int mipLevel, int element) { }

	internal ulong GetPixelDataSize(int mipLevel, int element = 0) { }

	private static ulong GetPixelDataSize_Injected(IntPtr _unity_self, int mipLevel, int element) { }

	internal TextureColorSpace GetTextureColorSpace(bool linear) { }

	internal TextureColorSpace GetTextureColorSpace(GraphicsFormat format) { }

	public void IncrementUpdateCount() { }

	private static void IncrementUpdateCount_Injected(IntPtr _unity_self) { }

	[NativeMethod("GetActiveTextureColorSpace")]
	private int Internal_GetActiveTextureColorSpace() { }

	private static int Internal_GetActiveTextureColorSpace_Injected(IntPtr _unity_self) { }

	public void set_anisoLevel(int value) { }

	private static void set_anisoLevel_Injected(IntPtr _unity_self, int value) { }

	public override void set_dimension(TextureDimension value) { }

	public void set_filterMode(FilterMode value) { }

	private static void set_filterMode_Injected(IntPtr _unity_self, FilterMode value) { }

	public override void set_height(int value) { }

	public void set_mipMapBias(float value) { }

	private static void set_mipMapBias_Injected(IntPtr _unity_self, float value) { }

	[FreeFunction(Name = "GetTextureStreamingManager().SetDiscardUnusedMips")]
	public static void set_streamingTextureDiscardUnusedMips(bool value) { }

	public override void set_width(int value) { }

	public void set_wrapMode(TextureWrapMode value) { }

	private static void set_wrapMode_Injected(IntPtr _unity_self, TextureWrapMode value) { }

	public void set_wrapModeU(TextureWrapMode value) { }

	private static void set_wrapModeU_Injected(IntPtr _unity_self, TextureWrapMode value) { }

	public void set_wrapModeV(TextureWrapMode value) { }

	private static void set_wrapModeV_Injected(IntPtr _unity_self, TextureWrapMode value) { }

	public void set_wrapModeW(TextureWrapMode value) { }

	private static void set_wrapModeW_Injected(IntPtr _unity_self, TextureWrapMode value) { }

	public static void SetStreamingTextureMaterialDebugProperties(int materialTextureSlot) { }

	[FreeFunction("GetTextureStreamingManager().SetStreamingTextureMaterialDebugPropertiesWithSlot")]
	private static void SetStreamingTextureMaterialDebugPropertiesWithSlot(int materialTextureSlot) { }

	internal bool ValidateFormat(TextureFormat format) { }

	internal bool ValidateFormat(GraphicsFormat format, GraphicsFormatUsage usage) { }

}

