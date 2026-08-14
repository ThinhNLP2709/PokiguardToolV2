namespace UnityEngine.Rendering;

public class PowerOfTwoTextureAtlas : Texture2DAtlas
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		[TupleElementNames(new IL2CPP_TYPE_STRING[] {"instanceId", "size"})]
		public static Comparison<ValueTuple`2<Int32, Vector2Int>> <>9__23_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal int <RelayoutEntries>b__23_0(ValueTuple<Int32, Vector2Int> c1, ValueTuple<Int32, Vector2Int> c2) { }

	}

	private enum BlitType
	{
		Padding = 0,
		PaddingMultiply = 1,
		OctahedralPadding = 2,
		OctahedralPaddingMultiply = 3,
	}

	private const float k_MipmapFactorApprox = 1.33; //Field offset: 0x0
	private readonly int m_MipPadding; //Field offset: 0x48
	private Dictionary<Int32, Vector2Int> m_RequestedTextures; //Field offset: 0x50

	public int mipPadding
	{
		 get { } //Length: 4
	}

	public PowerOfTwoTextureAtlas(int size, int mipPadding, GraphicsFormat format, FilterMode filterMode = 0, string name = "", bool useMipMap = true) { }

	public virtual bool AllocateTexture(CommandBuffer cmd, ref Vector4 scaleOffset, Texture texture, int width, int height, int overrideInstanceID = -1) { }

	private void Blit2DTexture(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, Vector4 sourceScaleOffset, bool blitMips, BlitType blitType) { }

	public virtual void BlitOctahedralTexture(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, Vector4 sourceScaleOffset, bool blitMips = true, int overrideInstanceID = -1) { }

	public void BlitOctahedralTextureMultiply(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, Vector4 sourceScaleOffset, bool blitMips = true, int overrideInstanceID = -1) { }

	public virtual void BlitTexture(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, Vector4 sourceScaleOffset, bool blitMips = true, int overrideInstanceID = -1) { }

	public void BlitTextureMultiply(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, Vector4 sourceScaleOffset, bool blitMips = true, int overrideInstanceID = -1) { }

	public int get_mipPadding() { }

	public static long GetApproxCacheSizeInByte(int nbElement, int resolution, bool hasMipmap, GraphicsFormat format) { }

	public static int GetMaxCacheSizeForWeightInByte(int weight, bool hasMipmap, GraphicsFormat format) { }

	public Vector4 GetPayloadScaleOffset(Texture texture, in Vector4 scaleOffset) { }

	public static Vector4 GetPayloadScaleOffset(in Vector2 textureSize, in Vector2 paddingSize, in Vector4 scaleOffset) { }

	private Vector2 GetPowerOfTwoTextureSize(Texture texture) { }

	private int GetTexturePadding() { }

	public bool RelayoutEntries() { }

	public bool ReserveSpace(Texture texture) { }

	public bool ReserveSpace(Texture texture, int width, int height) { }

	public bool ReserveSpace(Texture textureA, Texture textureB, int width, int height) { }

	public bool ReserveSpace(int id, int width, int height) { }

	public void ResetRequestedTexture() { }

	private void TextureSizeToPowerOfTwo(Texture texture, ref int width, ref int height) { }

}

