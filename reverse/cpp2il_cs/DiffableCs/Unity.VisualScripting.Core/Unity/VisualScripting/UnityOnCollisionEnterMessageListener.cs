namespace Unity.VisualScripting;

[AddComponentMenu(null)]
public sealed class UnityOnCollisionEnterMessageListener : MessageListener
{

	public UnityOnCollisionEnterMessageListener() { }

	private void OnCollisionEnter(Collision collision) { }

}

