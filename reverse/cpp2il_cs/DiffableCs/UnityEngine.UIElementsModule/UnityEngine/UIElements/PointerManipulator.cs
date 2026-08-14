namespace UnityEngine.UIElements;

public abstract class PointerManipulator : MouseManipulator
{
	private int m_CurrentPointerId; //Field offset: 0x20

	protected PointerManipulator() { }

	protected bool CanStartManipulation(IPointerEvent e) { }

	protected bool CanStopManipulation(IPointerEvent e) { }

}

