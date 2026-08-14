namespace Unity.VisualScripting;

[AddComponentMenu(null)]
public sealed class UnityOnCancelMessageListener : MessageListener, ICancelHandler, IEventSystemHandler
{

	public UnityOnCancelMessageListener() { }

	public override void OnCancel(BaseEventData eventData) { }

}

