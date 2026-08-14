namespace Unity.Jobs;

[JobProducerType(typeof(JobParallelForBatchProducer`1))]
public interface IJobParallelForBatch
{

	public void Execute(int startIndex, int count) { }

}

