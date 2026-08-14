namespace Unity.VisualScripting;

[AddComponentMenu(null)]
public sealed class UnityOnPointerUpMessageListener : MessageListener, IPointerUpHandler, IEventSystemHandler
{

	public UnityOnPointerUpMessageListener() { }

	public override void OnPointerUp(PointerEventData eventData) { }

}

