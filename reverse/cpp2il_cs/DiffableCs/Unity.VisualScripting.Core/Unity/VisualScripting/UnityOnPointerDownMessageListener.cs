namespace Unity.VisualScripting;

[AddComponentMenu(null)]
public sealed class UnityOnPointerDownMessageListener : MessageListener, IPointerDownHandler, IEventSystemHandler
{

	public UnityOnPointerDownMessageListener() { }

	public override void OnPointerDown(PointerEventData eventData) { }

}

