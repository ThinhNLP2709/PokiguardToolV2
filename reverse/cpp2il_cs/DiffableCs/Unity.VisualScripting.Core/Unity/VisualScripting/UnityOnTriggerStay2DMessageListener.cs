namespace Unity.VisualScripting;

[AddComponentMenu(null)]
public sealed class UnityOnTriggerStay2DMessageListener : MessageListener
{

	public UnityOnTriggerStay2DMessageListener() { }

	private void OnTriggerStay2D(Collider2D other) { }

}

