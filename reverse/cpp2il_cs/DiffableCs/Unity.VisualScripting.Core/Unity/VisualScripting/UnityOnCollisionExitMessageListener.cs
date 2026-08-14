namespace Unity.VisualScripting;

[AddComponentMenu(null)]
public sealed class UnityOnCollisionExitMessageListener : MessageListener
{

	public UnityOnCollisionExitMessageListener() { }

	private void OnCollisionExit(Collision collision) { }

}

