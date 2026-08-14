//Type is in global namespace

[DisallowMultipleComponent]
public class CoopRoomRowUI : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass11_0
	{
		public Action<String, Int32, Int32> onJoin; //Field offset: 0x10
		public int enemyPetId; //Field offset: 0x18
		public int enemyPetLevel; //Field offset: 0x1C
		public string capturedId; //Field offset: 0x20

		public <>c__DisplayClass11_0() { }

		internal void <Bind>b__0() { }

	}

	private const int COOP_CAP_FALLBACK = 3; //Field offset: 0x0
	[SerializeField]
	private Text txtRoomId; //Field offset: 0x20
	[SerializeField]
	private Text txtOwner; //Field offset: 0x28
	[SerializeField]
	private Image imgBoss; //Field offset: 0x30
	[SerializeField]
	private Text txtBossName; //Field offset: 0x38
	[SerializeField]
	private Text txtMembers; //Field offset: 0x40
	[SerializeField]
	private Image imgLock; //Field offset: 0x48
	[SerializeField]
	private Button btnJoin; //Field offset: 0x50
	[SerializeField]
	private Text btnJoinLabel; //Field offset: 0x58

	public CoopRoomRowUI() { }

	private void AutoFindRefs() { }

	private void Awake() { }

	public void Bind(RoomSummaryDTO room, Action<String, Int32, Int32> onJoin) { }

	private static int GetPropInt(Dictionary<String, Object> props, string key) { }

	private static string GetPropString(Dictionary<String, Object> props, string key) { }

}

