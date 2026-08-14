namespace Unity.VisualScripting;

[AddComponentMenu(null)]
public sealed class UnityOnPointerClickMessageListener : MessageListener, IPointerClickHandler, IEventSystemHandler
{

	public UnityOnPointerClickMessageListener() { }

	public override void OnPointerClick(PointerEventData eventData) { }

}

