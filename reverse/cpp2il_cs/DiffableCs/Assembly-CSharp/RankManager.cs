//Type is in global namespace

public class RankManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <LoadFromCurrentUser>d__22 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public RankManager <>4__this; //Field offset: 0x20
		private float <elapsed>5__2; //Field offset: 0x28

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
		public <LoadFromCurrentUser>d__22(int <>1__state) { }

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
	private sealed class <LoadRankTiersFromServer>d__21 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public RankManager <>4__this; //Field offset: 0x20
		private float <elapsed>5__2; //Field offset: 0x28

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
		public <LoadRankTiersFromServer>d__21(int <>1__state) { }

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

	internal class RankTier
	{
		public int minPoints; //Field offset: 0x10
		public int maxPoints; //Field offset: 0x14
		public string rankName; //Field offset: 0x18
		public string iconName; //Field offset: 0x20

		public RankTier() { }

	}

	[CompilerGenerated]
	private static RankManager <Instance>k__BackingField; //Field offset: 0x0
	private const string PREFS_KEY = "RankPoints"; //Field offset: 0x0
	private static readonly List<RankTier> FALLBACK_TIERS; //Field offset: 0x8
	[Header("UI References")]
	public Slider rankSlider; //Field offset: 0x20
	public Text txtCurrentPoints; //Field offset: 0x28
	public Text txtPointsToNextRank; //Field offset: 0x30
	public Text txtRankName; //Field offset: 0x38
	public Image imgRankIcon; //Field offset: 0x40
	[Header("Testing")]
	public bool isTesting; //Field offset: 0x48
	[Header("Rank Tiers - Load từ server, fallback hardcode")]
	public List<RankTier> rankTiers; //Field offset: 0x50
	private bool _tiersLoaded; //Field offset: 0x58
	private int _currentPoints; //Field offset: 0x5C

	public int CurrentPoints
	{
		 get { } //Length: 4
	}

	public private static RankManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 78
		[CompilerGenerated]
		private set { } //Length: 105
	}

	private static RankManager() { }

	public RankManager() { }

	[CompilerGenerated]
	private void <LoadRankTiersFromServer>b__21_0(PvpRankTierResponse response) { }

	[CompilerGenerated]
	private void <LoadRankTiersFromServer>b__21_1(string err) { }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::BeforeSceneLoad (1))]
	private static void AutoInitialize() { }

	private void Awake() { }

	public int get_CurrentPoints() { }

	[CompilerGenerated]
	public static RankManager get_Instance() { }

	public RankTier GetCurrentTier(int points) { }

	[IteratorStateMachine(typeof(<LoadFromCurrentUser>d__22))]
	private IEnumerator LoadFromCurrentUser() { }

	[IteratorStateMachine(typeof(<LoadRankTiersFromServer>d__21))]
	private IEnumerator LoadRankTiersFromServer() { }

	private void OnEnable() { }

	private void OnRankUp(RankTier newTier) { }

	public void RefreshUI() { }

	[CompilerGenerated]
	private static void set_Instance(RankManager value) { }

	public void UpdateRankPoints(int delta) { }

}

