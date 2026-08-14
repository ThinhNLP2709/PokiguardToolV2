namespace Unity.Jobs;

[JobProducerType(typeof(JobFilterProducer`1))]
public interface IJobFilter
{

	public bool Execute(int index) { }

}

