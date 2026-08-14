//Type is in global namespace

[DisallowMultipleComponent]
public class ServerStateDebugOverlay : MonoBehaviour
{
	[CompilerGenerated]
	private static ServerStateDebugOverlay <Instance>k__BackingField; //Field offset: 0x0
	private Text _text; //Field offset: 0x20
	private bool _visible; //Field offset: 0x28

	public private static ServerStateDebugOverlay Instance
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	public ServerStateDebugOverlay() { }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::AfterSceneLoad (0))]
	private static void AutoInit() { }

	private void Awake() { }

	private void BuildUI() { }

	[CompilerGenerated]
	public static ServerStateDebugOverlay get_Instance() { }

	private void Refresh() { }

	[CompilerGenerated]
	private static void set_Instance(ServerStateDebugOverlay value) { }

	private void Update() { }

}

