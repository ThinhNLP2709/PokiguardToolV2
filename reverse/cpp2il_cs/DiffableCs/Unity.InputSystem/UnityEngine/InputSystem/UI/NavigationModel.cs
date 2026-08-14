namespace UnityEngine.InputSystem.UI;

internal struct NavigationModel
{
	public Vector2 move; //Field offset: 0x0
	public int consecutiveMoveCount; //Field offset: 0x8
	public MoveDirection lastMoveDirection; //Field offset: 0xC
	public float lastMoveTime; //Field offset: 0x10
	public AxisEventData eventData; //Field offset: 0x18
	public InputDevice device; //Field offset: 0x20

	public void Reset() { }

}

