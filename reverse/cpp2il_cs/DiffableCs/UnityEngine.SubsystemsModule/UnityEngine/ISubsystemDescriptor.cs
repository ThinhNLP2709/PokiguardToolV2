namespace UnityEngine;

public interface ISubsystemDescriptor
{

	public string id
	{
		 get { } //Length: 0
	}

	public ISubsystem Create() { }

	public string get_id() { }

}

