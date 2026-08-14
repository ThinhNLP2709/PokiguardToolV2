namespace UnityEngine.U2D.Animation;

[BurstCompile]
internal struct CopySpriteRendererBoneTransformBuffersJob : IJobParallelFor
{
	[ReadOnly]
	public NativeArray<Boolean> isSpriteSkinValidForDeformArray; //Field offset: 0x0
	[ReadOnly]
	public NativeArray<SpriteSkinData> spriteSkinData; //Field offset: 0x10
	[ReadOnly]
	public NativeArray<PerSkinJobData> perSkinJobData; //Field offset: 0x20
	[NativeDisableUnsafePtrRestriction]
	[ReadOnly]
	public IntPtr ptrBoneTransforms; //Field offset: 0x30
	[WriteOnly]
	public NativeArray<IntPtr> buffers; //Field offset: 0x38
	[WriteOnly]
	public NativeArray<Int32> bufferSizes; //Field offset: 0x48

	public override void Execute(int i) { }

}

