namespace Unity.VisualScripting;

[AddComponentMenu(null)]
[DisableAnnotation]
[IncludeInSettings(False)]
[Singleton(Name = "VisualScripting CoroutineRunner", Automatic = True, Persistent = True)]
public sealed class CoroutineRunner : MonoBehaviour, ISingleton
{

	public static CoroutineRunner instance
	{
		 get { } //Length: 81
	}

	public CoroutineRunner() { }

	private void Awake() { }

	public static CoroutineRunner get_instance() { }

	private void OnDestroy() { }

}

