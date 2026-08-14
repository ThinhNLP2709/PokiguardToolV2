namespace UnityEngine.Rendering;

[BurstCompile(DisableSafetyChecks = True, OptimizeFor = OptimizeFor::Performance (1))]
internal struct RegisterNewInstancesJob : IJobParallelFor
{
	public const int k_BatchSize = 128; //Field offset: 0x0
	[ReadOnly]
	public NativeArray<Int32> instanceIDs; //Field offset: 0x0
	[ReadOnly]
	public NativeArray<T> batchIDs; //Field offset: 0x0
	[WriteOnly]
	public ParallelWriter<Int32, T> hashMap; //Field offset: 0x0

	public override void Execute(int index) { }

}

