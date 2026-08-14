namespace Unity.Jobs;

[JobProducerType(typeof(ForJobStruct`1))]
public interface IJobFor
{

	public void Execute(int index) { }

}

