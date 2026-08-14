//Type is in global namespace

public class MatchTeamPanelController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Int32, Int32> <>9__21_1; //Field offset: 0x8
		public static Func<PlayerStats, Int32> <>9__22_1; //Field offset: 0x10
		public static Func<PlayerStats, Int32> <>9__22_2; //Field offset: 0x18
		public static Func<PlayerStats, Int32> <>9__22_4; //Field offset: 0x20
		public static Func<PlayerStats, Int32> <>9__22_5; //Field offset: 0x28

		private static <>c() { }

		public <>c() { }

		internal int <RebuildCoOp>b__21_1(int a) { }

		internal int <RebuildPvp>b__22_1(PlayerStats s) { }

		internal int <RebuildPvp>b__22_2(PlayerStats s) { }

		internal int <RebuildPvp>b__22_4(PlayerStats s) { }

		internal int <RebuildPvp>b__22_5(PlayerStats s) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass21_0
	{
		public int enemyActor; //Field offset: 0x10

		public <>c__DisplayClass21_0() { }

		internal bool <RebuildCoOp>b__0(int a) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass22_0
	{
		public int myTeam; //Field offset: 0x10

		public <>c__DisplayClass22_0() { }

		internal bool <RebuildPvp>b__0(PlayerStats s) { }

		internal bool <RebuildPvp>b__3(PlayerStats s) { }

	}

	[CompilerGenerated]
	private struct <>c__DisplayClass26_0
	{
		public ActivePVP active; //Field offset: 0x0

	}

	[CompilerGenerated]
	private static MatchTeamPanelController <Instance>k__BackingField; //Field offset: 0x0
	[Header("Mode")]
	[SerializeField]
	private MatchTeamPanelMode panelMode; //Field offset: 0x20
	[Header("Containers (RectTransform)")]
	[SerializeField]
	private RectTransform pnlTeam; //Field offset: 0x28
	[SerializeField]
	private RectTransform pnlTeam2; //Field offset: 0x30
	[Header("Prefabs")]
	[SerializeField]
	private GameObject prefabAllySlot; //Field offset: 0x38
	[SerializeField]
	private GameObject prefabOpponentSlot; //Field offset: 0x40
	private readonly List<MatchTeamMemberSlotUI> _allySlots; //Field offset: 0x48
	private readonly List<MatchTeamMemberSlotUI> _enemySlots; //Field offset: 0x50
	private int _currentTurnActor; //Field offset: 0x58
	private bool _subscribed; //Field offset: 0x5C

	public private static MatchTeamPanelController Instance
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	public MatchTeamPanelController() { }

	[CompilerGenerated]
	internal static void <RefreshPvpStats>g__ApplyList|26_0(List<MatchTeamMemberSlotUI> list, ref <>c__DisplayClass26_0 unnamed_param_1) { }

	private void ApplyWeaponBadge(MatchTeamMemberSlotUI slot, int actorNumber) { }

	private void Awake() { }

	private static void ClearPanel(RectTransform panel, List<MatchTeamMemberSlotUI> list) { }

	public MatchTeamMemberSlotUI FindSlotByActor(int actorNumber) { }

	[CompilerGenerated]
	public static MatchTeamPanelController get_Instance() { }

	private static MatchTeamMemberSlotUI GetOrAddSlot(GameObject go) { }

	private static Sprite LoadAvatarSprite(int avatarId) { }

	private static Sprite LoadPetIconSprite(int petId) { }

	public static void NotifyStatsReady(MatchTeamPanelMode mode) { }

	private void OnDestroy() { }

	private void OnDisable() { }

	private void OnEnable() { }

	private void OnTurnStarted(int actorNumber) { }

	private void Rebuild() { }

	private void RebuildCoOp() { }

	private void RebuildPvp() { }

	public void RefreshAllStats() { }

	private void RefreshCoOpStats() { }

	private void RefreshPvpStats() { }

	private void RefreshTurnIndicators() { }

	private int ResolveAvatarId(int actorNumber) { }

	[CompilerGenerated]
	private static void set_Instance(MatchTeamPanelController value) { }

	private void Start() { }

	private void TrySubscribeTurns() { }

	private void UnsubscribeTurns() { }

}

