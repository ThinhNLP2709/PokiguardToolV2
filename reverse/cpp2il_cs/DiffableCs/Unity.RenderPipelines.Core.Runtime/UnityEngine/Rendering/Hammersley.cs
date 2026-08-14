namespace UnityEngine.Rendering;

public static class Hammersley
{
	[GenerateHLSL(PackingRules::Exact (0), True, False, False, 1, False, False, False, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.core\\Runtime\\ShaderLibrary\\Sampling\\Hammersley.cs", needAccessors = False, generateCBuffer = True)]
	private struct Hammersley2dSeq16
	{
		[CompilerGenerated]
		[UnsafeValueType]
		internal struct <hammersley2dSeq16>e__FixedBuffer
		{
			public float FixedElementField; //Field offset: 0x0

		}

		[FixedBuffer(typeof(float), 64)]
		[HLSLArray(16, typeof(Vector4))]
		public <hammersley2dSeq16>e__FixedBuffer hammersley2dSeq16; //Field offset: 0x0

	}

	[GenerateHLSL(PackingRules::Exact (0), True, False, False, 1, False, False, False, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.core\\Runtime\\ShaderLibrary\\Sampling\\Hammersley.cs", needAccessors = False, generateCBuffer = True)]
	private struct Hammersley2dSeq256
	{
		[CompilerGenerated]
		[UnsafeValueType]
		internal struct <hammersley2dSeq256>e__FixedBuffer
		{
			public float FixedElementField; //Field offset: 0x0

		}

		[FixedBuffer(typeof(float), 1024)]
		[HLSLArray(256, typeof(Vector4))]
		public <hammersley2dSeq256>e__FixedBuffer hammersley2dSeq256; //Field offset: 0x0

	}

	[GenerateHLSL(PackingRules::Exact (0), True, False, False, 1, False, False, False, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.core\\Runtime\\ShaderLibrary\\Sampling\\Hammersley.cs", needAccessors = False, generateCBuffer = True)]
	private struct Hammersley2dSeq32
	{
		[CompilerGenerated]
		[UnsafeValueType]
		internal struct <hammersley2dSeq32>e__FixedBuffer
		{
			public float FixedElementField; //Field offset: 0x0

		}

		[FixedBuffer(typeof(float), 128)]
		[HLSLArray(32, typeof(Vector4))]
		public <hammersley2dSeq32>e__FixedBuffer hammersley2dSeq32; //Field offset: 0x0

	}

	[GenerateHLSL(PackingRules::Exact (0), True, False, False, 1, False, False, False, -1, ".\\Library\\PackageCache\\com.unity.render-pipelines.core\\Runtime\\ShaderLibrary\\Sampling\\Hammersley.cs", needAccessors = False, generateCBuffer = True)]
	private struct Hammersley2dSeq64
	{
		[CompilerGenerated]
		[UnsafeValueType]
		internal struct <hammersley2dSeq64>e__FixedBuffer
		{
			public float FixedElementField; //Field offset: 0x0

		}

		[FixedBuffer(typeof(float), 256)]
		[HLSLArray(64, typeof(Vector4))]
		public <hammersley2dSeq64>e__FixedBuffer hammersley2dSeq64; //Field offset: 0x0

	}

	private static Single[] k_Hammersley2dSeq16; //Field offset: 0x0
	private static Single[] k_Hammersley2dSeq32; //Field offset: 0x8
	private static Single[] k_Hammersley2dSeq64; //Field offset: 0x10
	private static Single[] k_Hammersley2dSeq256; //Field offset: 0x18
	private static readonly int s_hammersley2DSeq16Id; //Field offset: 0x20
	private static readonly int s_hammersley2DSeq32Id; //Field offset: 0x24
	private static readonly int s_hammersley2DSeq64Id; //Field offset: 0x28
	private static readonly int s_hammersley2DSeq256Id; //Field offset: 0x2C

	private static Hammersley() { }

	public static void BindConstants(CommandBuffer cmd, ComputeShader cs) { }

	public static void Initialize() { }

}

