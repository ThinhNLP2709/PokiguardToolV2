namespace Unity.VisualScripting;

[AddComponentMenu(null)]
public sealed class UnityOnTriggerStayMessageListener : MessageListener
{

	public UnityOnTriggerStayMessageListener() { }

	private void OnTriggerStay(Collider other) { }

}

