namespace UnityEngine.Rendering.Universal;

[BurstCompile(FloatMode = FloatMode::Fast (3), DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
internal struct ZBinningJob : IJobFor
{
	public const int batchSize = 128; //Field offset: 0x0
	public const int headerLength = 2; //Field offset: 0x0
	[NativeDisableParallelForRestriction]
	public NativeArray<UInt32> bins; //Field offset: 0x0
	[ReadOnly]
	public NativeArray<float2> minMaxZs; //Field offset: 0x10
	public float zBinScale; //Field offset: 0x20
	public float zBinOffset; //Field offset: 0x24
	public int binCount; //Field offset: 0x28
	public int wordsPerTile; //Field offset: 0x2C
	public int lightCount; //Field offset: 0x30
	public int reflectionProbeCount; //Field offset: 0x34
	public int batchCount; //Field offset: 0x38
	public int viewCount; //Field offset: 0x3C
	public bool isOrthographic; //Field offset: 0x40

	private static ValueTuple<UInt32, UInt32> DecodeHeader(uint zBin) { }

	private static uint EncodeHeader(uint min, uint max) { }

	public override void Execute(int jobIndex) { }

	private void FillZBins(int binStart, int binEnd, int itemStart, int itemEnd, int headerIndex, int itemOffset, int binOffset) { }

}

