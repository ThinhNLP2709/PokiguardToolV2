namespace Unity.VisualScripting;

[AddComponentMenu(null)]
public sealed class UnityOnMoveMessageListener : MessageListener, IMoveHandler, IEventSystemHandler
{

	public UnityOnMoveMessageListener() { }

	public override void OnMove(AxisEventData eventData) { }

}

