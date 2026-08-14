namespace Unity.VisualScripting;

[AddComponentMenu(null)]
public sealed class UnityOnPointerExitMessageListener : MessageListener, IPointerExitHandler, IEventSystemHandler
{

	public UnityOnPointerExitMessageListener() { }

	public override void OnPointerExit(PointerEventData eventData) { }

}

