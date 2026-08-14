namespace UnityEngine.U2D.Animation;

[BurstCompile]
internal struct BoneDeformBatchedJob : IJobParallelFor
{
	[ReadOnly]
	public NativeArray<float4x4> boneTransform; //Field offset: 0x0
	[ReadOnly]
	public NativeArray<float4x4> rootTransform; //Field offset: 0x10
	[ReadOnly]
	public NativeArray<int2> boneLookupData; //Field offset: 0x20
	[ReadOnly]
	public NativeArray<SpriteSkinData> spriteSkinData; //Field offset: 0x30
	[ReadOnly]
	public NativeHashMap<Int32, TransformData> rootTransformIndex; //Field offset: 0x40
	[ReadOnly]
	public NativeHashMap<Int32, TransformData> boneTransformIndex; //Field offset: 0x48
	[WriteOnly]
	public NativeArray<float4x4> finalBoneTransforms; //Field offset: 0x50

	public override void Execute(int i) { }

}

