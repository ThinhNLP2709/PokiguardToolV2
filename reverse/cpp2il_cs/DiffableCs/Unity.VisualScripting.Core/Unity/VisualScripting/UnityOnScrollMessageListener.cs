namespace Unity.VisualScripting;

[AddComponentMenu(null)]
public sealed class UnityOnScrollMessageListener : MessageListener, IScrollHandler, IEventSystemHandler
{

	public UnityOnScrollMessageListener() { }

	public override void OnScroll(PointerEventData eventData) { }

}

