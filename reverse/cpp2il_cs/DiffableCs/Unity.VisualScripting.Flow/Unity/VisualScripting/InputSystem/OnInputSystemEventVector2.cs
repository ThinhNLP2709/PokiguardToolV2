namespace Unity.VisualScripting.InputSystem;

public class OnInputSystemEventVector2 : OnInputSystemEvent
{

	protected virtual OutputType OutputType
	{
		 get { } //Length: 6
	}

	public OnInputSystemEventVector2() { }

	protected virtual OutputType get_OutputType() { }

}

