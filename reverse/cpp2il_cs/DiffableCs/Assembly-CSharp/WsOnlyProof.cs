//Type is in global namespace

public class WsOnlyProof : MonoBehaviour
{
	public const string PREF_ENABLED = "ws_only_proof"; //Field offset: 0x0
	public const string PREF_SEVER = "ws_only_proof_sever"; //Field offset: 0x0
	private static WsOnlyProof _instance; //Field offset: 0x0
	private bool _inMatch; //Field offset: 0x20
	private string _matchId; //Field offset: 0x28
	private string _matchType; //Field offset: 0x30
	private float _matchStartTime; //Field offset: 0x38
	private int _wsIn; //Field offset: 0x3C
	private int _wsOut; //Field offset: 0x40
	private readonly Dictionary<String, Int32> _wsInByType; //Field offset: 0x48
	private string _lastVerdict; //Field offset: 0x50
	private bool _showOverlay; //Field offset: 0x58
	private float _nextPoll; //Field offset: 0x5C

	public static bool IsEnabled
	{
		 get { } //Length: 629
	}

	public WsOnlyProof() { }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::AfterSceneLoad (0))]
	private static void AutoInit() { }

	private void Awake() { }

	private void BeginMatch(MatchService ms) { }

	private void EndMatch() { }

	public static bool get_IsEnabled() { }

	private static string Mark(bool ok) { }

	[Conditional("UNITY_EDITOR")]
	[Conditional("DEVELOPMENT_BUILD")]
	public static void NoteWsIn(string type) { }

	[Conditional("UNITY_EDITOR")]
	[Conditional("DEVELOPMENT_BUILD")]
	public static void NoteWsOut(string type) { }

	private void OnDestroy() { }

	private void OnGUI() { }

	private void Update() { }

	private void WriteReport(string body) { }

}

