namespace Unity.VisualScripting;

public interface IEventMachine : IMachine, IGraphRoot, IGraphParent, IGraphNester, IAotStubbable
{

	public void TriggerAnimationEvent(AnimationEvent animationEvent) { }

	public void TriggerUnityEvent(string name) { }

}

