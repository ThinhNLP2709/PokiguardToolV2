//Type is in global namespace

public class UIUpdateManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass19_0
	{
		public UIUpdateManager <>4__this; //Field offset: 0x10
		public int token; //Field offset: 0x18
		public int petId; //Field offset: 0x1C

		public <>c__DisplayClass19_0() { }

		internal void <SetupDisplayPetAnimatorCached>b__0(AnimationClip[] clips) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass25_0
	{
		public UIUpdateManager <>4__this; //Field offset: 0x10
		public int token; //Field offset: 0x18
		public string petId; //Field offset: 0x20

		public <>c__DisplayClass25_0() { }

		internal void <SetupDisplayPlayerPetAnimator>b__0(AnimationClip[] clips) { }

	}

	[CompilerGenerated]
	private sealed class <ApplyDisplayPetClipsWhenIdle>d__20 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public int token; //Field offset: 0x20
		public UIUpdateManager <>4__this; //Field offset: 0x28
		public int petId; //Field offset: 0x30
		public AnimationClip[] clips; //Field offset: 0x38
		private float <deadline>5__2; //Field offset: 0x40

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
		public <ApplyDisplayPetClipsWhenIdle>d__20(int <>1__state) { }

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
	private static UIUpdateManager <Instance>k__BackingField; //Field offset: 0x0
	internal ManagerMatch managerMatch; //Field offset: 0x20
	internal Active active; //Field offset: 0x28
	internal Board board; //Field offset: 0x30
	private int _displayPetToken; //Field offset: 0x38
	private int _lastBoundDisplayPetId; //Field offset: 0x3C

	public private static UIUpdateManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	public UIUpdateManager() { }

	private void ApplyDisplayPetClips(int petId, AnimationClip[] clips) { }

	[IteratorStateMachine(typeof(<ApplyDisplayPetClipsWhenIdle>d__20))]
	private IEnumerator ApplyDisplayPetClipsWhenIdle(int petId, AnimationClip[] clips, int token) { }

	private bool ApplyStaticDisplayPet(int petId) { }

	private void Awake() { }

	private void BindDisplayPlayerPet(AnimationClip[] clips, string petId) { }

	[CompilerGenerated]
	public static UIUpdateManager get_Instance() { }

	public int GetActorToDisplay() { }

	private void OnDestroy() { }

	public static void PrewarmDisplayPetClips(int petId) { }

	public void RefreshDisplayUIForWsActor(int wsActor) { }

	public bool ReplaceAnimationsEnemyPet(AnimationClip[] newClips, out bool complete) { }

	public bool ReplaceAnimationsEnemyPet(AnimationClip[] newClips) { }

	public bool ReplaceAnimationsPetDisplay(AnimationClip[] newClips, out bool complete) { }

	public bool ReplaceAnimationsPetDisplay(AnimationClip[] newClips) { }

	public void ResetDisplayBindCache() { }

	private static string ResolveDisplayNameForActor(int wsActor) { }

	[CompilerGenerated]
	private static void set_Instance(UIUpdateManager value) { }

	private void SetupDisplayPetAnimatorCached(int petId) { }

	private void SetupDisplayPlayerPetAnimator(string petId) { }

	private void Start() { }

	public void UpdateBossHPSlider(MatchStatMask mask = 7) { }

	internal void UpdateDisplayPlayerUI(PetUserDTO petStats) { }

	public void UpdateDisplaySliders(MatchStatMask mask = 7) { }

	private void UpdateWeaknessText(PlayerStats displayStats) { }

}

