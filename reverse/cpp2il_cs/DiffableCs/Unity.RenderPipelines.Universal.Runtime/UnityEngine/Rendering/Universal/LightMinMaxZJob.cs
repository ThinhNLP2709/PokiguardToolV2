namespace UnityEngine.Rendering.Universal;

[BurstCompile]
internal struct LightMinMaxZJob : IJobFor
{
	public Fixed2<float4x4> worldToViews; //Field offset: 0x0
	[ReadOnly]
	public NativeArray<VisibleLight> lights; //Field offset: 0x80
	public NativeArray<float2> minMaxZs; //Field offset: 0x90

	public override void Execute(int index) { }

}

