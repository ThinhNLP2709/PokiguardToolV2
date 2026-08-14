namespace UnityEngine.UIElements;

public enum PropagationPhase
{
	None = 0,
	TrickleDown = 1,
	BubbleUp = 3,
	AtTarget = 2,
	DefaultAction = 4,
	DefaultActionAtTarget = 5,
}

