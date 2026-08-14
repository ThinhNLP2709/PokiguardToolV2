namespace Unity.VisualScripting;

[AddComponentMenu(null)]
[DisableAnnotation]
[IncludeInSettings(False)]
[Singleton(Name = "VisualScripting GlobalEventListener", Automatic = True, Persistent = True)]
[TypeIcon(typeof(MessageListener))]
public sealed class GlobalMessageListener : MonoBehaviour, ISingleton
{

	public GlobalMessageListener() { }

	private void OnApplicationFocus(bool focus) { }

	private void OnApplicationPause(bool paused) { }

	private void OnApplicationQuit() { }

	private void OnGUI() { }

	public static void Require() { }

}

