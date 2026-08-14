namespace UnityEngine.InputForUI;

internal class NavigationEventRepeatHelper
{
	private int m_ConsecutiveMoveCount; //Field offset: 0x10
	private Direction m_LastDirection; //Field offset: 0x14
	private DiscreteTime m_PrevActionTime; //Field offset: 0x18
	private readonly DiscreteTime m_InitialRepeatDelay; //Field offset: 0x20
	private readonly DiscreteTime m_ConsecutiveRepeatDelay; //Field offset: 0x28

	public NavigationEventRepeatHelper() { }

	public void Reset() { }

	public bool ShouldSendMoveEvent(DiscreteTime timestamp, Direction direction, bool axisButtonsWherePressedThisFrame) { }

}

