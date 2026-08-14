//Type is in global namespace

public class FusionPetPanelController : MonoBehaviour
{
	public const string PREFAB_PATH = "Prefabs/UI/FusionPetPanel"; //Field offset: 0x0
	private static FusionPetPanelController _active; //Field offset: 0x0
	[CompilerGenerated]
	private static Action OnSelectionChanged; //Field offset: 0x8
	private static string _migratedFor; //Field offset: 0x10
	[SerializeField]
	private Text txtTitle; //Field offset: 0x20
	[SerializeField]
	private Text txtHint; //Field offset: 0x28
	[SerializeField]
	private Text txtStatus; //Field offset: 0x30
	[SerializeField]
	private Button btnClose; //Field offset: 0x38
	[SerializeField]
	private Transform content; //Field offset: 0x40
	[SerializeField]
	private GameObject rowTemplate; //Field offset: 0x48
	[SerializeField]
	private GameObject window; //Field offset: 0x50
	private readonly List<FusionPetRowUI> _rows; //Field offset: 0x58
	private long _selectedUserPetId; //Field offset: 0x60
	private bool _legendNoticeShown; //Field offset: 0x68

	public static event Action OnSelectionChanged
	{
		[CompilerGenerated]
		 add { } //Length: 184
		[CompilerGenerated]
		 remove { } //Length: 184
	}

	public static long SavedPetId
	{
		 get { } //Length: 50
		 set { } //Length: 138
	}

	public static long SavedUserPetId
	{
		 get { } //Length: 9
		 set { } //Length: 90
	}

	public static string ServerRoomRejectReason
	{
		 get { } //Length: 30
	}

	public static long ServerRoomSelectedUserPetId
	{
		 get { } //Length: 71
	}

	public FusionPetPanelController() { }

	[CompilerGenerated]
	public static void add_OnSelectionChanged(Action value) { }

	private void AutoFindRefs() { }

	private void Awake() { }

	private void ClearRows() { }

	public void Close() { }

	public static string DescribeReason(string reason) { }

	public static string ElementVn(string element) { }

	private static Canvas FindHostCanvas() { }

	public static long get_SavedPetId() { }

	public static long get_SavedUserPetId() { }

	public static string get_ServerRoomRejectReason() { }

	public static long get_ServerRoomSelectedUserPetId() { }

	private static WsPlayerStateDTO GetMyRoomState() { }

	public static void HandleBattlePetChanged(int oldPetId, int newPetId) { }

	private void HandleFusionList(ChatMessageDTO m) { }

	public static void HandleServerReject(string reason) { }

	public static bool IsSelectionConfirmedByServer() { }

	private static string LoginIdentity() { }

	private static void MigrateLegacyKeyOnce(string user) { }

	private void OnDestroy() { }

	private void OnDisable() { }

	private void OnEnable() { }

	private void OnRowSelected(FusionPetRowUI row) { }

	public static void Open() { }

	public static bool PushSavedSelection(string caller) { }

	private static bool ReadBool(Dictionary<String, Object> p, string key) { }

	private static int ReadInt(Dictionary<String, Object> p, string key, int fb = 0) { }

	private static long ReadLong(Dictionary<String, Object> p, string key, long fb = 0) { }

	private static long ReadSaved(string suffix) { }

	private static string ReadStr(Dictionary<String, Object> p, string key) { }

	[CompilerGenerated]
	public static void remove_OnSelectionChanged(Action value) { }

	private void RequestList() { }

	private static string SavedKey() { }

	public static void set_SavedPetId(long value) { }

	public static void set_SavedUserPetId(long value) { }

	private void SetStatus(string text) { }

	private static void WriteSaved(string suffix, long value) { }

}

