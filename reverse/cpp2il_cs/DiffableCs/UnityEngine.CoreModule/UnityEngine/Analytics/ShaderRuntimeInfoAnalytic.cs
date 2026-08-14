namespace UnityEngine.Analytics;

[ExcludeFromDocs]
[RequiredByNativeCode(GenerateProxy = True)]
internal class ShaderRuntimeInfoAnalytic : AnalyticsEventBase
{
	public long VariantsRequested; //Field offset: 0x30
	public long VariantsRequestedMissing; //Field offset: 0x38
	public long VariantsRequestedUnsupported; //Field offset: 0x40
	public long VariantsRequestedCompiled; //Field offset: 0x48
	public long VariantsRequestedViaWarmup; //Field offset: 0x50
	public long VariantsUnused; //Field offset: 0x58
	public int VariantsCompilationTimeTotal; //Field offset: 0x60
	public int VariantsCompilationTimeMax; //Field offset: 0x64
	public int VariantsCompilationTimeMedian; //Field offset: 0x68
	public int VariantsWarmupTimeTotal; //Field offset: 0x6C
	public int VariantsWarmupTimeMax; //Field offset: 0x70
	public int VariantsWarmupTimeMedian; //Field offset: 0x74
	public bool UseProgressiveWarmup; //Field offset: 0x78
	public int ShaderChunkSizeMin; //Field offset: 0x7C
	public int ShaderChunkSizeMax; //Field offset: 0x80
	public int ShaderChunkSizeAvg; //Field offset: 0x84
	public int ShaderChunkCountMin; //Field offset: 0x88
	public int ShaderChunkCountMax; //Field offset: 0x8C
	public int ShaderChunkCountAvg; //Field offset: 0x90

	private ShaderRuntimeInfoAnalytic() { }

	[RequiredByNativeCode]
	public static ShaderRuntimeInfoAnalytic CreateShaderRuntimeInfoAnalytic() { }

}

