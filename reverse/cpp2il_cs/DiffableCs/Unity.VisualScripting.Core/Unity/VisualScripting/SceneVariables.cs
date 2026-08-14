namespace Unity.VisualScripting;

[AddComponentMenu(null)]
[DisableAnnotation]
[IncludeInSettings(False)]
[RequireComponent(typeof(Variables))]
[Singleton(Name = "VisualScripting SceneVariables", Automatic = True, Persistent = False)]
public sealed class SceneVariables : MonoBehaviour, ISingleton
{
	private Variables _variables; //Field offset: 0x20

	public Variables variables
	{
		 get { } //Length: 151
	}

	public SceneVariables() { }

	private void Awake() { }

	public static VariableDeclarations For(Nullable<Scene> scene) { }

	public Variables get_variables() { }

	public static SceneVariables Instance(Scene scene) { }

	public static bool InstantiatedIn(Scene scene) { }

	private void OnDestroy() { }

}

