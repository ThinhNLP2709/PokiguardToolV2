namespace UnityEngine.UIElements;

internal interface IPointerEventInternal
{

	public IMouseEvent compatibilityMouseEvent
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public int displayIndex
	{
		 set { } //Length: 0
	}

	public bool triggeredByOS
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public IMouseEvent get_compatibilityMouseEvent() { }

	public bool get_triggeredByOS() { }

	public void set_compatibilityMouseEvent(IMouseEvent value) { }

	public void set_displayIndex(int value) { }

	public void set_triggeredByOS(bool value) { }

}

