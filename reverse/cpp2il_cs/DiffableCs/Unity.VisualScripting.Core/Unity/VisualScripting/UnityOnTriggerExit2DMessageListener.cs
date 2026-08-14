namespace Unity.VisualScripting;

[AddComponentMenu(null)]
public sealed class UnityOnTriggerExit2DMessageListener : MessageListener
{

	public UnityOnTriggerExit2DMessageListener() { }

	private void OnTriggerExit2D(Collider2D other) { }

}

