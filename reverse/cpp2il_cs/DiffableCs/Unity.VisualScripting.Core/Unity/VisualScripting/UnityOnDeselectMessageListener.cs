namespace Unity.VisualScripting;

[AddComponentMenu(null)]
public sealed class UnityOnDeselectMessageListener : MessageListener, IDeselectHandler, IEventSystemHandler
{

	public UnityOnDeselectMessageListener() { }

	public override void OnDeselect(BaseEventData eventData) { }

}

