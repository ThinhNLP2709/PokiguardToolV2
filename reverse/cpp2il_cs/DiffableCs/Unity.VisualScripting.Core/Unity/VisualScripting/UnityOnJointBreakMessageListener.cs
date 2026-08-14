namespace Unity.VisualScripting;

[AddComponentMenu(null)]
public sealed class UnityOnJointBreakMessageListener : MessageListener
{

	public UnityOnJointBreakMessageListener() { }

	private void OnJointBreak(float breakForce) { }

}

