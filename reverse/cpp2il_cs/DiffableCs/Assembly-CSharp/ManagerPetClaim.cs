//Type is in global namespace

public class ManagerPetClaim : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass23_0
	{
		public ManagerPetClaim <>4__this; //Field offset: 0x10
		public PetClaimDTO pet; //Field offset: 0x18

		public <>c__DisplayClass23_0() { }

		internal void <SetupClaimButton>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <ClaimPetFromServer>d__27 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public long petId; //Field offset: 0x20
		public ManagerPetClaim <>4__this; //Field offset: 0x28

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
		public <ClaimPetFromServer>d__27(int <>1__state) { }

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
	private sealed class <GetPetListFromServer>d__16 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerPetClaim <>4__this; //Field offset: 0x20

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
		public <GetPetListFromServer>d__16(int <>1__state) { }

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

	[Header("Panel References")]
	public GameObject panelPet; //Field offset: 0x20
	public GameObject panelResult; //Field offset: 0x28
	[Header("Gpet Items")]
	public GameObject gpet1; //Field offset: 0x30
	public GameObject gpet2; //Field offset: 0x38
	public GameObject gpet3; //Field offset: 0x40
	[Header("Panel Result")]
	public Text txtResultMessage; //Field offset: 0x48
	public GameObject resultPetAnimation; //Field offset: 0x50
	public Button btnOkResult; //Field offset: 0x58
	[Header("Default Assets (Optional)")]
	public Sprite defaultPetSprite; //Field offset: 0x60
	private List<PetClaimDTO> petList; //Field offset: 0x68
	private long userId; //Field offset: 0x70
	private bool isLoading; //Field offset: 0x78

	public ManagerPetClaim() { }

	private void Awake() { }

	[IteratorStateMachine(typeof(<ClaimPetFromServer>d__27))]
	private IEnumerator ClaimPetFromServer(long petId) { }

	public void CloseResultPanel() { }

	private void DisplayPetList() { }

	[IteratorStateMachine(typeof(<GetPetListFromServer>d__16))]
	private IEnumerator GetPetListFromServer() { }

	private void HideAllPetItems() { }

	public void LoadPetList() { }

	private void OnClaimError(string error) { }

	private void OnClaimPet(PetClaimDTO pet) { }

	private void OnClaimSuccess(PetClaimResponse response) { }

	private void OnEnable() { }

	private void OnPetListError(string error) { }

	private void OnPetListLoaded(PetListResponse response) { }

	private void ReplaceAnimations(Animator animator, AnimationClip[] newClips) { }

	private void SetupClaimButton(GameObject btnClaim, PetClaimDTO pet) { }

	private void SetupConditionText(GameObject parent, string textName, int current, int required) { }

	private void SetupPetAnimation(GameObject petObj, long petId) { }

	private void SetupPetItem(GameObject gpetObj, PetClaimDTO pet) { }

	private void SetupResultPanelButton() { }

	private void ShowResultPanel(bool success, string message, PetClaimDTO pet) { }

	private void Start() { }

}

