namespace Unity.VisualScripting;

[AddComponentMenu(null)]
public sealed class UnityOnTriggerEnter2DMessageListener : MessageListener
{

	public UnityOnTriggerEnter2DMessageListener() { }

	private void OnTriggerEnter2D(Collider2D other) { }

}

