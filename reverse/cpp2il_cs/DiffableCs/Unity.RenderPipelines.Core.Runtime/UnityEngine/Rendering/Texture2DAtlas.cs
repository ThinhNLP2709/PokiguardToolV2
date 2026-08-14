namespace UnityEngine.Rendering;

public class Texture2DAtlas
{
	private enum BlitType
	{
		Default = 0,
		CubeTo2DOctahedral = 1,
		SingleChannel = 2,
		CubeTo2DOctahedralSingleChannel = 3,
	}

	const int kGPUTexInvalid = 0; //Field offset: 0x0
	const int kGPUTexValidMip0 = 1; //Field offset: 0x0
	const int kGPUTexValidMipAll = 2; //Field offset: 0x0
	private static readonly Vector4 fullScaleOffset; //Field offset: 0x0
	private static readonly int s_MaxMipLevelPadding; //Field offset: 0x10
	 RTHandle m_AtlasTexture; //Field offset: 0x10
	 int m_Width; //Field offset: 0x18
	 int m_Height; //Field offset: 0x1C
	 GraphicsFormat m_Format; //Field offset: 0x20
	 bool m_UseMipMaps; //Field offset: 0x24
	private bool m_IsAtlasTextureOwner; //Field offset: 0x25
	private AtlasAllocator m_AtlasAllocator; //Field offset: 0x28
	[TupleElementNames(new IL2CPP_TYPE_STRING[] {"scaleOffset", "size"})]
	private Dictionary<Int32, ValueTuple`2<Vector4, Vector2Int>> m_AllocationCache; //Field offset: 0x30
	private Dictionary<Int32, Int32> m_IsGPUTextureUpToDate; //Field offset: 0x38
	private Dictionary<Int32, Int32> m_TextureHashes; //Field offset: 0x40

	public RTHandle AtlasTexture
	{
		 get { } //Length: 5
	}

	public static int maxMipLevelPadding
	{
		 get { } //Length: 78
	}

	private static Texture2DAtlas() { }

	public Texture2DAtlas(int width, int height, GraphicsFormat format, FilterMode filterMode = 0, bool powerOfTwoPadding = false, string name = "", bool useMipMap = true) { }

	public override bool AddTexture(CommandBuffer cmd, ref Vector4 scaleOffset, Texture texture) { }

	public override bool AllocateTexture(CommandBuffer cmd, ref Vector4 scaleOffset, Texture texture, int width, int height, int overrideInstanceID = -1) { }

	public override bool AllocateTextureWithoutBlit(int instanceId, int width, int height, ref Vector4 scaleOffset) { }

	public bool AllocateTextureWithoutBlit(Texture texture, int width, int height, ref Vector4 scaleOffset) { }

	private void Blit2DTexture(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, Vector4 sourceScaleOffset, bool blitMips, BlitType blitType) { }

	public override void BlitCubeTexture2D(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, bool blitMips = true, int overrideInstanceID = -1) { }

	public override void BlitOctahedralTexture(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, Vector4 sourceScaleOffset, bool blitMips = true, int overrideInstanceID = -1) { }

	public override void BlitTexture(CommandBuffer cmd, Vector4 scaleOffset, Texture texture, Vector4 sourceScaleOffset, bool blitMips = true, int overrideInstanceID = -1) { }

	public void ClearTarget(CommandBuffer cmd) { }

	internal bool EnsureTextureSlot(out bool isUploadNeeded, ref Vector4 scaleBias, int key, int width, int height) { }

	public RTHandle get_AtlasTexture() { }

	public static int get_maxMipLevelPadding() { }

	internal Vector2Int GetCachedTextureSize(int id) { }

	 int GetTextureHash(Texture textureA, Texture textureB) { }

	public int GetTextureID(Texture textureA, Texture textureB) { }

	public int GetTextureID(Texture texture) { }

	 int GetTextureMipmapCount(int width, int height) { }

	 bool Is2D(Texture texture) { }

	public bool IsCached(out Vector4 scaleOffset, Texture textureA, Texture textureB) { }

	public bool IsCached(out Vector4 scaleOffset, Texture texture) { }

	public bool IsCached(out Vector4 scaleOffset, int id) { }

	 bool IsSingleChannelBlit(Texture source, Texture destination) { }

	 void MarkGPUTextureInvalid(int instanceId) { }

	 void MarkGPUTextureValid(int instanceId, bool mipAreValid = false) { }

	public override bool NeedsUpdate(Texture texture, bool needMips = false) { }

	public override bool NeedsUpdate(int id, int updateCount, bool needMips = false) { }

	public override bool NeedsUpdate(Texture textureA, Texture textureB, bool needMips = false) { }

	public void Release() { }

	public void ResetAllocator() { }

	public override bool UpdateTexture(CommandBuffer cmd, Texture oldTexture, Texture newTexture, ref Vector4 scaleOffset, Vector4 sourceScaleOffset, bool updateIfNeeded = true, bool blitMips = true) { }

	public override bool UpdateTexture(CommandBuffer cmd, Texture texture, ref Vector4 scaleOffset, bool updateIfNeeded = true, bool blitMips = true) { }

}

