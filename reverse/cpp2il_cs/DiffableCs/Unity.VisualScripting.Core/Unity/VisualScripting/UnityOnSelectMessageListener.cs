namespace Unity.VisualScripting;

[AddComponentMenu(null)]
public sealed class UnityOnSelectMessageListener : MessageListener, ISelectHandler, IEventSystemHandler
{

	public UnityOnSelectMessageListener() { }

	public override void OnSelect(BaseEventData eventData) { }

}

