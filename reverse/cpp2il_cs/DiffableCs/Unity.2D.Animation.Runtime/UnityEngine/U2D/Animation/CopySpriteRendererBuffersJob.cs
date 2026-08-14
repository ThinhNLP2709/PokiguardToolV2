namespace UnityEngine.U2D.Animation;

[BurstCompile]
internal struct CopySpriteRendererBuffersJob : IJobParallelFor
{
	[ReadOnly]
	public NativeArray<Boolean> isSpriteSkinValidForDeformArray; //Field offset: 0x0
	[ReadOnly]
	public NativeArray<SpriteSkinData> spriteSkinData; //Field offset: 0x10
	[NativeDisableUnsafePtrRestriction]
	[ReadOnly]
	public IntPtr ptrVertices; //Field offset: 0x20
	[WriteOnly]
	public NativeArray<IntPtr> buffers; //Field offset: 0x28
	[WriteOnly]
	public NativeArray<Int32> bufferSizes; //Field offset: 0x38

	public override void Execute(int i) { }

}

