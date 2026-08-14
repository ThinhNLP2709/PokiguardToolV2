namespace Unity.VisualScripting;

[AddComponentMenu(null)]
public sealed class UnityOnDropMessageListener : MessageListener, IDropHandler, IEventSystemHandler
{

	public UnityOnDropMessageListener() { }

	public override void OnDrop(PointerEventData eventData) { }

}

