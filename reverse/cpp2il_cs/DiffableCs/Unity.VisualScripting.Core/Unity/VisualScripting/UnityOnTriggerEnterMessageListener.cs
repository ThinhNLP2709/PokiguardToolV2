namespace Unity.VisualScripting;

[AddComponentMenu(null)]
public sealed class UnityOnTriggerEnterMessageListener : MessageListener
{

	public UnityOnTriggerEnterMessageListener() { }

	private void OnTriggerEnter(Collider other) { }

}

