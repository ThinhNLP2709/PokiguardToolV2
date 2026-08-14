namespace UnityEngine.Jobs;

[JobProducerType(typeof(TransformParallelForLoopStruct`1))]
public interface IJobParallelForTransform
{

	public void Execute(int index, TransformAccess transform) { }

}

