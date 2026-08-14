namespace Unity.Jobs;

[Obsolete("'IJobParallelForFilter' has been deprecated; use 'IJobFilter' instead. (UnityUpgradable) -> IJobFilter")]
public interface IJobParallelForFilter
{

	public bool Execute(int index) { }

}

