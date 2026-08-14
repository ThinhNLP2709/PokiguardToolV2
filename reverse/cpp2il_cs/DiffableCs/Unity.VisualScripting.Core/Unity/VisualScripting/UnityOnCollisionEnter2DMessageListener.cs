namespace Unity.VisualScripting;

[AddComponentMenu(null)]
public sealed class UnityOnCollisionEnter2DMessageListener : MessageListener
{

	public UnityOnCollisionEnter2DMessageListener() { }

	private void OnCollisionEnter2D(Collision2D collision) { }

}

