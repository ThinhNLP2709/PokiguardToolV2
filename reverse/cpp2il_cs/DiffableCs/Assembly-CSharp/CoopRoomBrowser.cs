//Type is in global namespace

public class CoopRoomBrowser : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<RoomSummaryDTO, Boolean> <>9__24_0; //Field offset: 0x8
		public static Comparison<RoomSummaryDTO> <>9__24_1; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal bool <RebuildList>b__24_0(RoomSummaryDTO r) { }

		internal int <RebuildList>b__24_1(RoomSummaryDTO a, RoomSummaryDTO b) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass26_0
	{
		public CoopRoomBrowser <>4__this; //Field offset: 0x10
		public string capturedId; //Field offset: 0x18
		public int capPetId; //Field offset: 0x20
		public int capPetLv; //Field offset: 0x24

		public <>c__DisplayClass26_0() { }

		internal void <CreateRow>b__0() { }

	}

	private const string ROOM_TYPE = "ChinhPhuc"; //Field offset: 0x0
	private const int COOP_CAP_FALLBACK = 3; //Field offset: 0x0
	private const string PANEL_PREFAB_PATH = "Prefabs/UI/CoopRoomListPanel"; //Field offset: 0x0
	private ManagerChinhPhuc _host; //Field offset: 0x20
	private GameObject _openButton; //Field offset: 0x28
	private GameObject _panelRoot; //Field offset: 0x30
	private Transform _content; //Field offset: 0x38
	private Text _txtEmpty; //Field offset: 0x40
	private GameObject _rowTemplate; //Field offset: 0x48
	private bool _panelOpen; //Field offset: 0x50
	private bool _listening; //Field offset: 0x51
	private float _resubCheckAt; //Field offset: 0x54
	private Font _font; //Field offset: 0x58

	public CoopRoomBrowser() { }

	[CompilerGenerated]
	private void <BuildPanel>b__28_0() { }

	[CompilerGenerated]
	private void <BuildPanelFromPrefab>b__29_0() { }

	private void AttachListEvents() { }

	private void BuildPanel() { }

	private void BuildPanelFromPrefab(GameObject prefab, Canvas canvas) { }

	public void ClosePanel() { }

	private static GameObject CreateRect(string name, Transform parent, Vector2 anchorMin, Vector2 anchorMax, Vector2 size) { }

	private void CreateRow(RoomSummaryDTO room) { }

	private Text CreateText(Transform parent, string content, int fontSize, TextAnchor anchor) { }

	private void DetachListEvents() { }

	public static void EnsureAttached(ManagerChinhPhuc host) { }

	private void EnsureOpenButton() { }

	private static Transform FindDeep(Transform root, string name) { }

	private Font GetFont() { }

	private static int GetPropInt(Dictionary<String, Object> props, string key) { }

	private static string GetPropString(Dictionary<String, Object> props, string key) { }

	private static bool IsJoinable(RoomSummaryDTO room) { }

	private void OnDestroy() { }

	private void OnDisable() { }

	private void OnJoinClicked(string roomId, int enemyPetId, int enemyPetLevel) { }

	public void OpenPanel() { }

	private void RebuildList() { }

	private static void SetRect(RectTransform rt, Vector2 anchorMin, Vector2 anchorMax, Vector2 offsetMin, Vector2 offsetMax) { }

	private void Subscribe(WsRoomService ws) { }

	public void TogglePanel() { }

	private void Update() { }

}

