namespace Unity.VisualScripting;

[AddComponentMenu(null)]
public sealed class UnityOnCollisionStayMessageListener : MessageListener
{

	public UnityOnCollisionStayMessageListener() { }

	private void OnCollisionStay(Collision collision) { }

}

