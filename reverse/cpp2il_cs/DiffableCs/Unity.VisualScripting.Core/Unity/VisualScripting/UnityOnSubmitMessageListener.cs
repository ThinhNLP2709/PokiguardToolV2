namespace Unity.VisualScripting;

[AddComponentMenu(null)]
public sealed class UnityOnSubmitMessageListener : MessageListener, ISubmitHandler, IEventSystemHandler
{

	public UnityOnSubmitMessageListener() { }

	public override void OnSubmit(BaseEventData eventData) { }

}

