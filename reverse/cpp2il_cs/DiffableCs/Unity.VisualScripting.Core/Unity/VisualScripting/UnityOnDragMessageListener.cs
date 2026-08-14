namespace Unity.VisualScripting;

[AddComponentMenu(null)]
public sealed class UnityOnDragMessageListener : MessageListener, IDragHandler, IEventSystemHandler
{

	public UnityOnDragMessageListener() { }

	public override void OnDrag(PointerEventData eventData) { }

}

