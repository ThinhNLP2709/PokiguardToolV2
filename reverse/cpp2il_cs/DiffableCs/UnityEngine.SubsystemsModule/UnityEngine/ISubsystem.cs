namespace UnityEngine;

public interface ISubsystem
{

	public bool running
	{
		 get { } //Length: 0
	}

	public void Destroy() { }

	public bool get_running() { }

	public void Start() { }

	public void Stop() { }

}

