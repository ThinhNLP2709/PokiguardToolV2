namespace Unity.VisualScripting;

[AddComponentMenu(null)]
public sealed class UnityOnBeginDragMessageListener : MessageListener, IBeginDragHandler, IEventSystemHandler
{

	public UnityOnBeginDragMessageListener() { }

	public override void OnBeginDrag(PointerEventData eventData) { }

}

