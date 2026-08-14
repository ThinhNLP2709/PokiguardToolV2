namespace UnityEngine.UIElements;

internal interface IPointerOrMouseEvent
{

	public int pointerId
	{
		 get { } //Length: 0
	}

	public Vector3 position
	{
		 get { } //Length: 0
	}

	public int get_pointerId() { }

	public Vector3 get_position() { }

}

