namespace Unity.VisualScripting;

[AddComponentMenu(null)]
public sealed class UnityOnPointerEnterMessageListener : MessageListener, IPointerEnterHandler, IEventSystemHandler
{

	public UnityOnPointerEnterMessageListener() { }

	public override void OnPointerEnter(PointerEventData eventData) { }

}

