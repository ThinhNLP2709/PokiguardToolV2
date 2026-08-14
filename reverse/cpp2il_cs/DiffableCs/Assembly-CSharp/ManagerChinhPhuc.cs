//Type is in global namespace

public class ManagerChinhPhuc : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass19_0
	{
		public int index; //Field offset: 0x10
		public ManagerChinhPhuc <>4__this; //Field offset: 0x18

		public <>c__DisplayClass19_0() { }

		internal void <Start>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass26_0
	{
		public GameObject mainPanel; //Field offset: 0x10

		public <>c__DisplayClass26_0() { }

		internal void <ClosePanel>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass32_0
	{
		public List<GroupDTO> loadedData; //Field offset: 0x10
		public bool apiCompleted; //Field offset: 0x18
		public string errorMessage; //Field offset: 0x20

		public <>c__DisplayClass32_0() { }

		internal void <LoadDataCoroutine>b__0(List<GroupDTO> data) { }

		internal void <LoadDataCoroutine>b__1(string error) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass36_0
	{
		public Text text; //Field offset: 0x10
		public Color originalColor; //Field offset: 0x18

		public <>c__DisplayClass36_0() { }

		internal void <AnimateTextFadeIn>b__0(float val) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass37_0
	{
		public GameObject buttonObj; //Field offset: 0x10

		public <>c__DisplayClass37_0() { }

		internal void <AddButtonHoverEffect>b__0(BaseEventData data) { }

		internal void <AddButtonHoverEffect>b__1(BaseEventData data) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass38_0
	{
		public bool lockedForClick; //Field offset: 0x10
		public int lockedOrderForClick; //Field offset: 0x14
		public int requiredAttack; //Field offset: 0x18
		public int petId; //Field offset: 0x1C
		public string reA; //Field offset: 0x20
		public ManagerChinhPhuc <>4__this; //Field offset: 0x28

		public <>c__DisplayClass38_0() { }

		internal void <OnReceived>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass41_0
	{
		public GameObject btnObj; //Field offset: 0x10

		public <>c__DisplayClass41_0() { }

		internal void <PlayUnlockPunch>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass44_0
	{
		public int petId; //Field offset: 0x10
		public Func<PetEnemyDTO, Boolean> <>9__0; //Field offset: 0x18

		public <>c__DisplayClass44_0() { }

		internal bool <OpenRoomWithPetRoutine>b__0(PetEnemyDTO p) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass45_0
	{
		public Text textComponent; //Field offset: 0x10

		public <>c__DisplayClass45_0() { }

		internal void <AnimateNumberCount>b__0(float val) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass46_0
	{
		public Text textComponent; //Field offset: 0x10
		public Vector3 originalScale; //Field offset: 0x18

		public <>c__DisplayClass46_0() { }

		internal void <AnimateTextPulse>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <AnimatePanelContent>d__51 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public GameObject panel; //Field offset: 0x20
		public ManagerChinhPhuc <>4__this; //Field offset: 0x28
		private Button[] <panelButtons>5__2; //Field offset: 0x30
		private int <i>5__3; //Field offset: 0x38

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
		public <AnimatePanelContent>d__51(int <>1__state) { }

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
	private sealed class <BackSceneWithFade>d__50 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerChinhPhuc <>4__this; //Field offset: 0x20

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
		public <BackSceneWithFade>d__50(int <>1__state) { }

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
	private sealed class <LoadDataCoroutine>d__32 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerChinhPhuc <>4__this; //Field offset: 0x20
		public Action onComplete; //Field offset: 0x28
		private <>c__DisplayClass32_0 <>8__1; //Field offset: 0x30
		private bool <isRestoring>5__2; //Field offset: 0x38
		private ChinhPhucDataService <svc>5__3; //Field offset: 0x40
		private float <deadline>5__4; //Field offset: 0x48

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
		public <LoadDataCoroutine>d__32(int <>1__state) { }

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
	private sealed class <OpenRoomWithPetRoutine>d__44 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public int petId; //Field offset: 0x20
		private <>c__DisplayClass44_0 <>8__1; //Field offset: 0x28
		public ManagerChinhPhuc <>4__this; //Field offset: 0x30
		public ManagerRoom flow; //Field offset: 0x38

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
		public <OpenRoomWithPetRoutine>d__44(int <>1__state) { }

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
	private sealed class <ShowPanelWithLoadingCoroutine>d__29 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerChinhPhuc <>4__this; //Field offset: 0x20
		public int index; //Field offset: 0x28

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
		public <ShowPanelWithLoadingCoroutine>d__29(int <>1__state) { }

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

	public GameObject LoadingPanel; //Field offset: 0x20
	public GameObject[] panels; //Field offset: 0x28
	public Button[] buttons; //Field offset: 0x30
	public GameObject panelMain; //Field offset: 0x38
	public GameObject backBtn; //Field offset: 0x40
	public Text txtVang; //Field offset: 0x48
	public Text txtCt; //Field offset: 0x50
	public Text txtNl; //Field offset: 0x58
	public GameObject notice; //Field offset: 0x60
	public Button cancleNotice; //Field offset: 0x68
	[Header("UI")]
	[SerializeField]
	private Material grayscaleUIMaterial; //Field offset: 0x70
	[Header("Animation Settings")]
	[SerializeField]
	private float buttonPopDelay; //Field offset: 0x78
	[SerializeField]
	private float panelSlideSpeed; //Field offset: 0x7C
	[SerializeField]
	private bool enableParticleEffects; //Field offset: 0x80
	private Material _runtimeGrayMat; //Field offset: 0x88
	private bool isDataLoaded; //Field offset: 0x90
	private List<GroupDTO> cachedPetData; //Field offset: 0x98
	[Header("Close Button")]
	public Button btnClose; //Field offset: 0xA0
	private bool _subscribedToService; //Field offset: 0xA8
	private readonly Dictionary<Int32, Boolean> _lastLockedByPetId; //Field offset: 0xB0
	[Header("Transition")]
	public GameObject fadeOverlay; //Field offset: 0xB8
	private Sprite _huntBadgeBg; //Field offset: 0xC0
	private Sprite[] _huntDigitSprites; //Field offset: 0xC8

	public ManagerChinhPhuc() { }

	[CompilerGenerated]
	private void <BackSceneWithFade>b__50_0() { }

	[CompilerGenerated]
	private void <HideLoadingPanel>b__34_0() { }

	[CompilerGenerated]
	private void <ShowNoticeWithAnimation>b__54_0() { }

	private void AddButtonHoverEffect(GameObject buttonObj) { }

	private void AddPetButtonAnimation(GameObject btnObj) { }

	private void AnimateInitialUI() { }

	private void AnimateNumberCount(Text textComponent, int targetValue) { }

	[IteratorStateMachine(typeof(<AnimatePanelContent>d__51))]
	private IEnumerator AnimatePanelContent(GameObject panel) { }

	private void AnimateTextFadeIn(Text text, float delay) { }

	private void AnimateTextPulse(Text textComponent) { }

	public void BackScene() { }

	[IteratorStateMachine(typeof(<BackSceneWithFade>d__50))]
	private IEnumerator BackSceneWithFade() { }

	private void BuildHuntOrderDigits(Transform badgeT, int orderNumber, bool locked) { }

	public void ClosePanel() { }

	private void EnsureGrayMaterial() { }

	private void EnsureHuntOrderBadge(Transform petButton, int orderNumber, bool locked, bool cleared) { }

	private void HandleServiceDataChanged() { }

	private static bool HasServerLockFlags(GroupDTO group) { }

	public void HideAllPanels() { }

	private void HideLoadingPanel() { }

	private void HideNoticeWithAnimation() { }

	public void InitializeAndLoadData(Action onComplete = null) { }

	public void InvalidateCache() { }

	[IteratorStateMachine(typeof(<LoadDataCoroutine>d__32))]
	private IEnumerator LoadDataCoroutine(Action onComplete) { }

	private void OnDestroy() { }

	private void OnDisable() { }

	private void OnEnable() { }

	private void OnError(string error) { }

	public void OnReceived(List<GroupDTO> petE) { }

	private void OpenRoomWithPet(int petId, string reA) { }

	[IteratorStateMachine(typeof(<OpenRoomWithPetRoutine>d__44))]
	private IEnumerator OpenRoomWithPetRoutine(int petId, string reA, ManagerRoom flow) { }

	private void PlayUnlockPunch(GameObject btnObj) { }

	private void RebindIfServiceDataChanged() { }

	public void RestoreState(int panelIndex) { }

	private void SetImageGrayscale(Image img, bool enable) { }

	private void ShowLoadingPanel() { }

	private void ShowNoticeWithAnimation(string message = "") { }

	public void ShowPanel(int index, bool withAnimation = true) { }

	[IteratorStateMachine(typeof(<ShowPanelWithLoadingCoroutine>d__29))]
	private IEnumerator ShowPanelWithLoadingCoroutine(int index, bool withAnimation) { }

	private void Start() { }

	private void SubscribeServiceEvents() { }

	private void ToggleNotice() { }

	private void UnsubscribeServiceEvents() { }

}

