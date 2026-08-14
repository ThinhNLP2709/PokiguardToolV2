namespace Unity.VisualScripting;

[AddComponentMenu(null)]
public sealed class UnityOnJointBreak2DMessageListener : MessageListener
{

	public UnityOnJointBreak2DMessageListener() { }

	private void OnJointBreak2D(Joint2D brokenJoint) { }

}

