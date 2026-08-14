//Type is in global namespace

[DisallowMultipleComponent]
public class PVPBrowseRoomRowUI : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass11_0
	{
		public Action<String> onJoin; //Field offset: 0x10
		public PVPBrowseRoomRowUI <>4__this; //Field offset: 0x18

		public <>c__DisplayClass11_0() { }

		internal void <Bind>b__0() { }

	}

	[SerializeField]
	private Text roomNameText; //Field offset: 0x20
	[SerializeField]
	private Image imgUser1Pet; //Field offset: 0x28
	[SerializeField]
	private Image imgUser12Pet; //Field offset: 0x30
	[SerializeField]
	private Button btnJoin; //Field offset: 0x38
	[SerializeField]
	private Text btnJoinLabel; //Field offset: 0x40
	private string _roomId; //Field offset: 0x48
	private bool _twinkleActive; //Field offset: 0x50
	private float _twinkleTimer; //Field offset: 0x54
	private ColorBlock _originalColors; //Field offset: 0x58

	public PVPBrowseRoomRowUI() { }

	private static void ApplyPetIcon(Image img, int petId) { }

	private static void ApplyWeaponBadge(Image petIcon, int imageId, string rarity) { }

	private void AutoFindRefs() { }

	private void Awake() { }

	public void Bind(RoomSummaryDTO room, int fullAtPlayerCount, Action<String> onJoin) { }

	private static string BuildDisplayId(string roomId) { }

	private static int GetPropInt(Dictionary<String, Object> props, string key) { }

	private static string GetPropString(Dictionary<String, Object> props, string key) { }

	private void OnDisable() { }

	private void Update() { }

}

