namespace Unity.Jobs;

[JobProducerType(typeof(JobParallelForDeferProducer`1))]
public interface IJobParallelForDefer
{

	public void Execute(int index) { }

}

