namespace Unity.VisualScripting;

[AddComponentMenu(null)]
public sealed class UnityOnEndDragMessageListener : MessageListener, IEndDragHandler, IEventSystemHandler
{

	public UnityOnEndDragMessageListener() { }

	public override void OnEndDrag(PointerEventData eventData) { }

}

