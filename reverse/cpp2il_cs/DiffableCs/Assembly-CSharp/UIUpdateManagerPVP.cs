//Type is in global namespace

public class UIUpdateManagerPVP : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass19_0
	{
		public UIUpdateManagerPVP <>4__this; //Field offset: 0x10
		public Animator animator; //Field offset: 0x18
		public int token; //Field offset: 0x20
		public bool isEnemy; //Field offset: 0x24
		public string petId; //Field offset: 0x28
		public SpriteRenderer fallbackRenderer; //Field offset: 0x30

		public <>c__DisplayClass19_0() { }

		internal void <ApplyPetClipsAsync>b__0(AnimationClip[] clips) { }

	}

	[CompilerGenerated]
	private static UIUpdateManagerPVP <Instance>k__BackingField; //Field offset: 0x0
	internal ManagerMatchPVP managerMatch; //Field offset: 0x20
	internal ActivePVP active; //Field offset: 0x28
	internal BoardPVP board; //Field offset: 0x30
	private int _userClipToken; //Field offset: 0x38
	private int _enemyClipToken; //Field offset: 0x3C

	public private static UIUpdateManagerPVP Instance
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	public UIUpdateManagerPVP() { }

	public void ApplyPetClipsAsync(string petId, bool isEnemy) { }

	private void Awake() { }

	[CompilerGenerated]
	public static UIUpdateManagerPVP get_Instance() { }

	public int GetActorToDisplay() { }

	private void OnDestroy() { }

	public void RefreshDisplayUIForWsActor(int wsActor) { }

	public void ReplaceAnimationsEnemyPet(AnimationClip[] newClips) { }

	public void ReplaceAnimationsPetDisplay(AnimationClip[] newClips) { }

	[CompilerGenerated]
	private static void set_Instance(UIUpdateManagerPVP value) { }

	private void SetupDisplayPlayerPetAnimator(string petId) { }

	private void Start() { }

	public void UpdateBossHPSlider(MatchStatMask mask = 7) { }

	internal void UpdateDisplayPlayerUI(PetUserDTO petStats) { }

	public void UpdateDisplaySliders(MatchStatMask mask = 7) { }

	private void UpdateWeaknessText(PlayerStats displayStats) { }

}

