namespace UnityEngine.Rendering.Universal;

internal struct ReflectionProbeManager : IDisposable
{
	private struct CachedProbe
	{
		[CompilerGenerated]
		[UnsafeValueType]
		internal struct <dataIndices>e__FixedBuffer
		{
			public int FixedElementField; //Field offset: 0x0

		}

		[CompilerGenerated]
		[UnsafeValueType]
		internal struct <levels>e__FixedBuffer
		{
			public int FixedElementField; //Field offset: 0x0

		}

		public uint updateCount; //Field offset: 0x0
		public Hash128 imageContentsHash; //Field offset: 0x8
		public int size; //Field offset: 0x18
		public int mipCount; //Field offset: 0x1C
		[FixedBuffer(typeof(int), 7)]
		public <dataIndices>e__FixedBuffer dataIndices; //Field offset: 0x20
		[FixedBuffer(typeof(int), 7)]
		public <levels>e__FixedBuffer levels; //Field offset: 0x3C
		public Texture texture; //Field offset: 0x58
		public int lastUsed; //Field offset: 0x60
		public Vector4 hdrData; //Field offset: 0x64

	}

	private static class ShaderProperties
	{
		public static readonly int BoxMin; //Field offset: 0x0
		public static readonly int BoxMax; //Field offset: 0x4
		public static readonly int ProbePosition; //Field offset: 0x8
		public static readonly int MipScaleOffset; //Field offset: 0xC
		public static readonly int Count; //Field offset: 0x10
		public static readonly int Atlas; //Field offset: 0x14

		private static ShaderProperties() { }

	}

	private const int k_MaxMipCount = 7; //Field offset: 0x0
	private const string k_ReflectionProbeAtlasName = "URP Reflection Probe Atlas"; //Field offset: 0x0
	private int2 m_Resolution; //Field offset: 0x0
	private RenderTexture m_AtlasTexture0; //Field offset: 0x8
	private RenderTexture m_AtlasTexture1; //Field offset: 0x10
	private RTHandle m_AtlasTexture0Handle; //Field offset: 0x18
	private BuddyAllocator m_AtlasAllocator; //Field offset: 0x20
	private Dictionary<Int32, CachedProbe> m_Cache; //Field offset: 0x48
	private Dictionary<Int32, Int32> m_WarningCache; //Field offset: 0x50
	private List<Int32> m_NeedsUpdate; //Field offset: 0x58
	private List<Int32> m_NeedsRemove; //Field offset: 0x60
	private Vector4[] m_BoxMax; //Field offset: 0x68
	private Vector4[] m_BoxMin; //Field offset: 0x70
	private Vector4[] m_ProbePosition; //Field offset: 0x78
	private Vector4[] m_MipScaleOffset; //Field offset: 0x80

	public RenderTexture atlasRT
	{
		 get { } //Length: 5
	}

	public RTHandle atlasRTHandle
	{
		 get { } //Length: 5
	}

	public static ReflectionProbeManager Create() { }

	public override void Dispose() { }

	public RenderTexture get_atlasRT() { }

	public RTHandle get_atlasRTHandle() { }

	private float4 GetScaleOffset(int level, int dataIndex, bool includePadding, bool yflip) { }

	private void Init() { }

	public void UpdateGpuData(CommandBuffer cmd, ref CullingResults cullResults) { }

}

