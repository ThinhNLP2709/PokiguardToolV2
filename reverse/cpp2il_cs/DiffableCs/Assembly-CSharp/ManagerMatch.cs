//Type is in global namespace

public class ManagerMatch : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<String> <>9__84_1; //Field offset: 0x8
		public static Action<String> <>9__84_3; //Field offset: 0x10
		public static Action<String> <>9__84_5; //Field offset: 0x18

		private static <>c() { }

		public <>c() { }

		internal void <TryRestMatchPrepFallback>b__84_1(string err) { }

		internal void <TryRestMatchPrepFallback>b__84_3(string err) { }

		internal void <TryRestMatchPrepFallback>b__84_5(string err) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass77_0
	{
		public int actor; //Field offset: 0x10

		public <>c__DisplayClass77_0() { }

		internal bool <ShowPopupDelta>b__0(int k) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass83_0
	{
		public string prepError; //Field offset: 0x10
		public ManagerMatch <>4__this; //Field offset: 0x18

		public <>c__DisplayClass83_0() { }

		internal void <LoadSceneAfterDelay>b__1(MatchPrepDataDTO data) { }

		internal void <LoadSceneAfterDelay>b__2(string err) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass84_0
	{
		public ManagerMatch <>4__this; //Field offset: 0x10
		public bool myDone; //Field offset: 0x18
		public bool enemyDone; //Field offset: 0x19

		public <>c__DisplayClass84_0() { }

		internal void <TryRestMatchPrepFallback>b__0(PetUserDTO pet) { }

		internal void <TryRestMatchPrepFallback>b__2(PetUserDTO pet) { }

		internal void <TryRestMatchPrepFallback>b__4(UserDTO user) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass94_0
	{
		public ManagerMatch <>4__this; //Field offset: 0x10
		public bool isEnemy; //Field offset: 0x18
		public string path; //Field offset: 0x20
		public int attempt; //Field offset: 0x28
		public string petId; //Field offset: 0x30

		public <>c__DisplayClass94_0() { }

		internal void <ApplyPetClips>b__0(AnimationClip[] clips) { }

	}

	[CompilerGenerated]
	private sealed class <ApplyClipsWhenUiReady>d__104 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerMatch <>4__this; //Field offset: 0x20
		public string path; //Field offset: 0x28
		public bool isEnemy; //Field offset: 0x30
		public AnimationClip[] clips; //Field offset: 0x38
		private float <waited>5__2; //Field offset: 0x40

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <ApplyClipsWhenUiReady>d__104(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <LoadSceneAfterDelay>d__83 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerMatch <>4__this; //Field offset: 0x20
		private <>c__DisplayClass83_0 <>8__1; //Field offset: 0x28
		private int <localUserId>5__2; //Field offset: 0x30
		private int <ePetId>5__3; //Field offset: 0x34
		private int <idPet>5__4; //Field offset: 0x38
		private Active <activeRef>5__5; //Field offset: 0x40
		private float <waited>5__6; //Field offset: 0x48

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <LoadSceneAfterDelay>d__83(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <RetryApplyPetClips>d__95 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public int attempt; //Field offset: 0x20
		public ManagerMatch <>4__this; //Field offset: 0x28
		public bool isEnemy; //Field offset: 0x30
		public string petId; //Field offset: 0x38

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <RetryApplyPetClips>d__95(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <TryRestMatchPrepFallback>d__84 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerMatch <>4__this; //Field offset: 0x20
		public int userId; //Field offset: 0x28
		public int idPet; //Field offset: 0x2C
		public int ePetId; //Field offset: 0x30
		private <>c__DisplayClass84_0 <>8__1; //Field offset: 0x38

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <TryRestMatchPrepFallback>d__84(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private class DebugPopup
	{
		public int delta; //Field offset: 0x10
		public float time; //Field offset: 0x14
		public Vector2 startPos; //Field offset: 0x18

		public DebugPopup() { }

	}

	public static ManagerMatch Instance; //Field offset: 0x0
	private const int PET_CLIP_MAX_RETRY = 3; //Field offset: 0x0
	[Header("Display Control")]
	[SerializeField]
	internal int displayActorNumber; //Field offset: 0x20
	[SerializeField]
	internal bool autoSyncDisplayActor; //Field offset: 0x24
	internal int lastDisplayActorNumber; //Field offset: 0x28
	public List<String> playerNamesInOrder; //Field offset: 0x30
	[Header("UI References")]
	public GameObject LoadingPanel; //Field offset: 0x38
	public Text txtHpUser; //Field offset: 0x40
	public Text txtManaUser; //Field offset: 0x48
	public Text txtPowerUser; //Field offset: 0x50
	public Text txtWeeUser; //Field offset: 0x58
	public Text txtUsername; //Field offset: 0x60
	public Text txtHpEnemy; //Field offset: 0x68
	public Text txtManaEnemy; //Field offset: 0x70
	public Text txtPowerEnemy; //Field offset: 0x78
	public Text txtWeeEnemy; //Field offset: 0x80
	public Text txtusernameEnemy; //Field offset: 0x88
	public Text txtNLUser; //Field offset: 0x90
	public Image attributeUser; //Field offset: 0x98
	public Image attributeEnemy; //Field offset: 0xA0
	public SpriteRenderer imgPetUser; //Field offset: 0xA8
	public SpriteRenderer imgPetEnemy; //Field offset: 0xB0
	public Animator anmtPetUser; //Field offset: 0xB8
	public Animator anmtPetEnemy; //Field offset: 0xC0
	public Slider sliderHpUser; //Field offset: 0xC8
	public Slider sliderManaUser; //Field offset: 0xD0
	public Slider sliderPowerUser; //Field offset: 0xD8
	public Slider sliderHpEnemy; //Field offset: 0xE0
	public Slider sliderManaEnemy; //Field offset: 0xE8
	public Slider sliderPowerEnemy; //Field offset: 0xF0
	public CardData cardData; //Field offset: 0xF8
	[Header("Ping / FPS (match)")]
	[Tooltip("Kéo Text (UI) trên Canvas trận đấu vào đây. Để trống thì không hiển thị.")]
	public Text txtPingFps; //Field offset: 0x100
	public bool showPingFpsHud; //Field offset: 0x108
	private float _pingFpsHudNextTick; //Field offset: 0x10C
	private float _pingFpsAccum; //Field offset: 0x110
	private int _pingFpsFrames; //Field offset: 0x114
	private int _pingFpsDisplay; //Field offset: 0x118
	[CompilerGenerated]
	private Action OnAllDataLoaded; //Field offset: 0x120
	private bool petsLoaded; //Field offset: 0x128
	private bool enemyPetsLoaded; //Field offset: 0x129
	private bool userLoaded; //Field offset: 0x12A
	private Active active; //Field offset: 0x130
	[Header("Boss Battle")]
	private bool isBossBattle; //Field offset: 0x138
	internal long currentBossScheduleId; //Field offset: 0x140
	private int totalDamageDealt; //Field offset: 0x148
	public PetUserDTO uPetsMatch; //Field offset: 0x150
	public PetUserDTO ePetsMatch; //Field offset: 0x158
	[Header("Debug GUI Settings")]
	public bool showDebugGUI; //Field offset: 0x160
	public float debugGUIFontSize; //Field offset: 0x164
	public float popupDuration; //Field offset: 0x168
	public int spaceCenterText; //Field offset: 0x16C
	private List<DebugPopup> debugPopups; //Field offset: 0x170
	private Dictionary<Int32, Int32> lastHP; //Field offset: 0x178
	private Dictionary<Int32, Int32> lastMana; //Field offset: 0x180
	private Dictionary<Int32, Int32> lastPower; //Field offset: 0x188
	private Dictionary<Int32, Int32> lastShield; //Field offset: 0x190
	private GUIStyle debugTitleStyle; //Field offset: 0x198
	private GUIStyle debugLineStyle; //Field offset: 0x1A0
	private GUIStyle popupStyleGreen; //Field offset: 0x1A8
	private GUIStyle popupStyleRed; //Field offset: 0x1B0
	private Vector2 scrollPos; //Field offset: 0x1B8
	private int _lastHudRtt; //Field offset: 0x1C0
	private int _lastHudFps; //Field offset: 0x1C4
	private int _lastAppliedEnemyDisplayPetId; //Field offset: 0x1C8
	private string _pendingEnemyClipPath; //Field offset: 0x1D0
	private string _pendingUserClipPath; //Field offset: 0x1D8
	private int _rigEnemyPetId; //Field offset: 0x1E0
	private int _rigUserPetId; //Field offset: 0x1E4
	private int _rigEnemyClipCount; //Field offset: 0x1E8
	private int _rigUserClipCount; //Field offset: 0x1EC

	public event Action OnAllDataLoaded
	{
		[CompilerGenerated]
		 add { } //Length: 162
		[CompilerGenerated]
		 remove { } //Length: 162
	}

	public SpriteRenderer PetHostEnemy
	{
		 get { } //Length: 212
	}

	public SpriteRenderer PetHostUser
	{
		 get { } //Length: 212
	}

	public ManagerMatch() { }

	[CompilerGenerated]
	private bool <LoadSceneAfterDelay>b__83_0() { }

	[CompilerGenerated]
	public void add_OnAllDataLoaded(Action value) { }

	public void AddBossDamage(int damage) { }

	private void ApplyClipsNow(AnimationClip[] clips, bool isEnemy, string path = null, bool outOfRetries = false) { }

	[IteratorStateMachine(typeof(<ApplyClipsWhenUiReady>d__104))]
	private IEnumerator ApplyClipsWhenUiReady(AnimationClip[] clips, bool isEnemy, string path) { }

	private void ApplyPetClips(string petId, bool isEnemy, int attempt = 0) { }

	private void ApplyPetSprite(string petId, bool isEnemy) { }

	private void Awake() { }

	private void CheckAndUpdateDisplayActor() { }

	public void EnsureEnemyDisplaySynced(bool force = false) { }

	public SpriteRenderer get_PetHostEnemy() { }

	public SpriteRenderer get_PetHostUser() { }

	public int GetTotalBossDamage() { }

	private void InitDebugGuiStyles() { }

	private void InitializeDisplayActor() { }

	public bool IsBossBattle() { }

	private bool IsDisplayOwnedByLocalPlayer() { }

	[IteratorStateMachine(typeof(<LoadSceneAfterDelay>d__83))]
	private IEnumerator LoadSceneAfterDelay() { }

	private void OnDestroy() { }

	private void OnEnemyPet(string petId) { }

	private void OnEPetsReceived(PetUserDTO pets) { }

	private void OnError(string error) { }

	private void OnPet(string petId) { }

	private void OnPetsReceived(PetUserDTO pets) { }

	private void OpenEnergyPurchasePopup() { }

	private static int ParsePetIdOrZero(string path) { }

	private static string PetIdFromClipPath(string path) { }

	[CompilerGenerated]
	public void remove_OnAllDataLoaded(Action value) { }

	[IteratorStateMachine(typeof(<RetryApplyPetClips>d__95))]
	private IEnumerator RetryApplyPetClips(string petId, bool isEnemy, int attempt) { }

	private void SetLocalUsernameTextSafe(string name) { }

	private void ShowPopupDelta(int actor, string statName, int delta) { }

	private void Start() { }

	public void SwitchDisplayToPlayer(int actorNumber) { }

	private void SyncBossPetDataId(int petId) { }

	[IteratorStateMachine(typeof(<TryRestMatchPrepFallback>d__84))]
	private IEnumerator TryRestMatchPrepFallback(int userId, int idPet, int ePetId) { }

	private void Update() { }

	private void UpdateDebugStatsRealtime() { }

	private void UpdatePingFpsHud() { }

	private void WireEnergyBuyButton() { }

}

