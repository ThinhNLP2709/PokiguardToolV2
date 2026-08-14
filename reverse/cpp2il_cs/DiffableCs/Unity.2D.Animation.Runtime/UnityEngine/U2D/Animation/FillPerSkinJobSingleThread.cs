namespace UnityEngine.U2D.Animation;

[BurstCompile]
internal struct FillPerSkinJobSingleThread : IJob
{
	public PerSkinJobData combinedSkinBatch; //Field offset: 0x0
	[ReadOnly]
	public NativeArray<Boolean> isSpriteSkinValidForDeformArray; //Field offset: 0x18
	public NativeArray<SpriteSkinData> spriteSkinDataArray; //Field offset: 0x28
	public NativeArray<PerSkinJobData> perSkinJobDataArray; //Field offset: 0x38
	public NativeArray<PerSkinJobData> combinedSkinBatchArray; //Field offset: 0x48

	public override void Execute() { }

}

