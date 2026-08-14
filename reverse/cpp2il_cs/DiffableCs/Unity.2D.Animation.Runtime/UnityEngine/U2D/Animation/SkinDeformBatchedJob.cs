namespace UnityEngine.U2D.Animation;

[BurstCompile]
internal struct SkinDeformBatchedJob : IJobParallelFor
{
	public NativeSlice<Byte> vertices; //Field offset: 0x0
	[ReadOnly]
	public NativeArray<float4x4> finalBoneTransforms; //Field offset: 0x10
	[ReadOnly]
	public NativeArray<PerSkinJobData> perSkinJobData; //Field offset: 0x20
	[ReadOnly]
	public NativeArray<SpriteSkinData> spriteSkinData; //Field offset: 0x30
	[ReadOnly]
	public NativeArray<int2> vertexLookupData; //Field offset: 0x40

	public override void Execute(int i) { }

}

