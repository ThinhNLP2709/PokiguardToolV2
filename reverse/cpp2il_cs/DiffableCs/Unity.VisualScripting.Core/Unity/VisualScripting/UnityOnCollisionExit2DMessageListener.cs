namespace Unity.VisualScripting;

[AddComponentMenu(null)]
public sealed class UnityOnCollisionExit2DMessageListener : MessageListener
{

	public UnityOnCollisionExit2DMessageListener() { }

	private void OnCollisionExit2D(Collision2D collision) { }

}

