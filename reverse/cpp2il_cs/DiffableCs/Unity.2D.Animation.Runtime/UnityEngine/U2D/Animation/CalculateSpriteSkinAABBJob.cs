namespace UnityEngine.U2D.Animation;

[BurstCompile]
internal struct CalculateSpriteSkinAABBJob : IJobParallelFor
{
	public NativeSlice<Byte> vertices; //Field offset: 0x0
	[ReadOnly]
	public NativeArray<Boolean> isSpriteSkinValidForDeformArray; //Field offset: 0x10
	[ReadOnly]
	public NativeArray<SpriteSkinData> spriteSkinData; //Field offset: 0x20
	[WriteOnly]
	public NativeArray<Bounds> bounds; //Field offset: 0x30

	public override void Execute(int i) { }

}

