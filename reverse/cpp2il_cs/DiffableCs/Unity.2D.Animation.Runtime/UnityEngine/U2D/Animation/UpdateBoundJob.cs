namespace UnityEngine.U2D.Animation;

[BurstCompile]
internal struct UpdateBoundJob : IJobParallelFor
{
	[ReadOnly]
	public NativeArray<Int32> rootTransformId; //Field offset: 0x0
	[ReadOnly]
	public NativeArray<Int32> rootBoneTransformId; //Field offset: 0x10
	[ReadOnly]
	public NativeArray<float4x4> rootTransform; //Field offset: 0x20
	[ReadOnly]
	public NativeArray<float4x4> boneTransform; //Field offset: 0x30
	[ReadOnly]
	public NativeHashMap<Int32, TransformData> rootTransformIndex; //Field offset: 0x40
	[ReadOnly]
	public NativeHashMap<Int32, TransformData> boneTransformIndex; //Field offset: 0x48
	[ReadOnly]
	public NativeArray<Bounds> spriteSkinBound; //Field offset: 0x50
	public NativeArray<Bounds> bounds; //Field offset: 0x60

	public override void Execute(int i) { }

}

