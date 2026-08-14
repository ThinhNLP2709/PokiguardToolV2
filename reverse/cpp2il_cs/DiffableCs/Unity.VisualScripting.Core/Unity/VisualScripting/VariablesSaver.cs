namespace Unity.VisualScripting;

[AddComponentMenu(null)]
[DisableAnnotation]
[IncludeInSettings(False)]
[Singleton(Name = "VisualScripting SavedVariablesSerializer", Automatic = True, Persistent = True)]
public class VariablesSaver : MonoBehaviour, ISingleton
{

	public static VariablesSaver instance
	{
		 get { } //Length: 81
	}

	public VariablesSaver() { }

	private void Awake() { }

	public static VariablesSaver get_instance() { }

	public static void Instantiate() { }

	private void OnApplicationPause(bool isPaused) { }

	private void OnApplicationQuit() { }

	private void OnDestroy() { }

}

