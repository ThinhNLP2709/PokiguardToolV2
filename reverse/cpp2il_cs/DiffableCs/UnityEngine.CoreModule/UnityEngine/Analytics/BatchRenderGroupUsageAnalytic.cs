namespace UnityEngine.Analytics;

[RequiredByNativeCode(GenerateProxy = True)]
internal class BatchRenderGroupUsageAnalytic : AnalyticsEventBase
{
	public int maxBRGInstance; //Field offset: 0x30
	public int maxMeshCount; //Field offset: 0x34
	public int maxMaterialCount; //Field offset: 0x38
	public int maxDrawCommandBatch; //Field offset: 0x3C

	public BatchRenderGroupUsageAnalytic() { }

	[RequiredByNativeCode]
	public static BatchRenderGroupUsageAnalytic CreateBatchRenderGroupUsageAnalytic() { }

}

