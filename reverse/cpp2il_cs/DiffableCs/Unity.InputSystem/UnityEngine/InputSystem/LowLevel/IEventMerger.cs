namespace UnityEngine.InputSystem.LowLevel;

internal interface IEventMerger
{

	public bool MergeForward(InputEventPtr currentEventPtr, InputEventPtr nextEventPtr) { }

}

