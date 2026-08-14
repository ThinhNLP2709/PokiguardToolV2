namespace Unity.VisualScripting;

[AddComponentMenu(null)]
public sealed class UnityOnTriggerExitMessageListener : MessageListener
{

	public UnityOnTriggerExitMessageListener() { }

	private void OnTriggerExit(Collider other) { }

}

