namespace Unity.VisualScripting.InputSystem;

public class OnInputSystemEventFloat : OnInputSystemEvent
{

	protected virtual OutputType OutputType
	{
		 get { } //Length: 6
	}

	public OnInputSystemEventFloat() { }

	protected virtual OutputType get_OutputType() { }

}

