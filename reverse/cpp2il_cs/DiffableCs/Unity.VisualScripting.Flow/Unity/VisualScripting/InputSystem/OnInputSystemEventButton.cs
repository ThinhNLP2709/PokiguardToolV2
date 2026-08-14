namespace Unity.VisualScripting.InputSystem;

public class OnInputSystemEventButton : OnInputSystemEvent
{

	protected virtual OutputType OutputType
	{
		 get { } //Length: 3
	}

	public OnInputSystemEventButton() { }

	protected virtual OutputType get_OutputType() { }

}

