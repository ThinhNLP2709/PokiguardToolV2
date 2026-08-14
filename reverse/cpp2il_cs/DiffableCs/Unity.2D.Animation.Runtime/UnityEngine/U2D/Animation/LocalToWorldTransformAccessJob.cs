namespace UnityEngine.U2D.Animation;

[BurstCompile]
internal struct LocalToWorldTransformAccessJob : IJobParallelForTransform
{
	[WriteOnly]
	public NativeArray<float4x4> outMatrix; //Field offset: 0x0

	public override void Execute(int index, TransformAccess transform) { }

}

