namespace UnityEngine.Rendering;

public static class TextureXR
{
	private static int m_MaxViews; //Field offset: 0x0
	private static Texture m_BlackUIntTexture2DArray; //Field offset: 0x8
	private static Texture m_BlackUIntTexture; //Field offset: 0x10
	private static RTHandle m_BlackUIntTexture2DArrayRTH; //Field offset: 0x18
	private static RTHandle m_BlackUIntTextureRTH; //Field offset: 0x20
	private static Texture2DArray m_ClearTexture2DArray; //Field offset: 0x28
	private static Texture2D m_ClearTexture; //Field offset: 0x30
	private static RTHandle m_ClearTexture2DArrayRTH; //Field offset: 0x38
	private static RTHandle m_ClearTextureRTH; //Field offset: 0x40
	private static Texture2DArray m_MagentaTexture2DArray; //Field offset: 0x48
	private static Texture2D m_MagentaTexture; //Field offset: 0x50
	private static RTHandle m_MagentaTexture2DArrayRTH; //Field offset: 0x58
	private static RTHandle m_MagentaTextureRTH; //Field offset: 0x60
	private static Texture2D m_BlackTexture; //Field offset: 0x68
	private static Texture3D m_BlackTexture3D; //Field offset: 0x70
	private static Texture2DArray m_BlackTexture2DArray; //Field offset: 0x78
	private static RTHandle m_BlackTexture2DArrayRTH; //Field offset: 0x80
	private static RTHandle m_BlackTextureRTH; //Field offset: 0x88
	private static RTHandle m_BlackTexture3DRTH; //Field offset: 0x90
	private static Texture2DArray m_WhiteTexture2DArray; //Field offset: 0x98
	private static RTHandle m_WhiteTexture2DArrayRTH; //Field offset: 0xA0
	private static RTHandle m_WhiteTextureRTH; //Field offset: 0xA8

	public static TextureDimension dimension
	{
		 get { } //Length: 115
	}

	public static int maxViews
	{
		 set { } //Length: 82
	}

	public static int slices
	{
		 get { } //Length: 77
	}

	public static bool useTexArray
	{
		 get { } //Length: 69
	}

	private static TextureXR() { }

	private static Texture3D CreateBlackTexture3D(string name) { }

	private static Texture CreateBlackUintTexture(CommandBuffer cmd, ComputeShader clearR32_UIntShader) { }

	private static Texture CreateBlackUIntTextureArray(CommandBuffer cmd, ComputeShader clearR32_UIntShader) { }

	private static Texture2DArray CreateTexture2DArrayFromTexture2D(Texture2D source, string name) { }

	public static TextureDimension get_dimension() { }

	public static int get_slices() { }

	public static bool get_useTexArray() { }

	public static RTHandle GetBlackTexture() { }

	public static RTHandle GetBlackTexture3D() { }

	public static RTHandle GetBlackTextureArray() { }

	public static RTHandle GetBlackUIntTexture() { }

	public static RTHandle GetClearTexture() { }

	public static RTHandle GetMagentaTexture() { }

	public static RTHandle GetWhiteTexture() { }

	public static void Initialize(CommandBuffer cmd, ComputeShader clearR32_UIntShader) { }

	public static void set_maxViews(int value) { }

}

