namespace UnityEngine.U2D.Animation;

[BurstCompile]
internal struct PrepareDeformJob : IJob
{
	[ReadOnly]
	public NativeArray<PerSkinJobData> perSkinJobData; //Field offset: 0x0
	[ReadOnly]
	public int batchDataSize; //Field offset: 0x10
	[WriteOnly]
	public NativeArray<int2> boneLookupData; //Field offset: 0x18
	[WriteOnly]
	public NativeArray<int2> vertexLookupData; //Field offset: 0x28

	public override void Execute() { }

}

