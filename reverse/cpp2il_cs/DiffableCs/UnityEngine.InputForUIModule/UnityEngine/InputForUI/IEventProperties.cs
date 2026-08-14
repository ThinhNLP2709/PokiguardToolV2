namespace UnityEngine.InputForUI;

internal interface IEventProperties
{

	public EventModifiers eventModifiers
	{
		 get { } //Length: 0
	}

	public EventSource eventSource
	{
		 get { } //Length: 0
	}

	public EventModifiers get_eventModifiers() { }

	public EventSource get_eventSource() { }

}

