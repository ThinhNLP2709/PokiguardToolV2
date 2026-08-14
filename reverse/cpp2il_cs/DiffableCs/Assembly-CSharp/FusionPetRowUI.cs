//Type is in global namespace

[DisallowMultipleComponent]
public class FusionPetRowUI : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass23_0
	{
		public Action<FusionPetRowUI> onSelect; //Field offset: 0x10
		public FusionPetRowUI <>4__this; //Field offset: 0x18

		public <>c__DisplayClass23_0() { }

		internal void <Bind>b__0() { }

	}

	private static readonly Color SelectedTint; //Field offset: 0x0
	[SerializeField]
	private Image imgtPet; //Field offset: 0x20
	[SerializeField]
	private Image imgGlow; //Field offset: 0x28
	[SerializeField]
	private Text txtRate; //Field offset: 0x30
	[SerializeField]
	private Button btnSelect; //Field offset: 0x38
	private Image _bg; //Field offset: 0x40
	private Color _bgDefault; //Field offset: 0x48
	private float _glowDefaultAlpha; //Field offset: 0x58
	private bool _stateCaptured; //Field offset: 0x5C
	[CompilerGenerated]
	private long <UserPetId>k__BackingField; //Field offset: 0x60
	[CompilerGenerated]
	private long <PetId>k__BackingField; //Field offset: 0x68
	[CompilerGenerated]
	private string <PetName>k__BackingField; //Field offset: 0x70

	public private long PetId
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 5
	}

	public private string PetName
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public private long UserPetId
	{
		[CompilerGenerated]
		 get { } //Length: 694
		[CompilerGenerated]
		private set { } //Length: 5
	}

	private static FusionPetRowUI() { }

	public FusionPetRowUI() { }

	private void AutoFindRefs() { }

	private void Awake() { }

	public void Bind(long userPetId, long petId, string petName, int level, string elementType, int ratePercent, int bonusHp, int bonusAttack, int bonusMana, Action<FusionPetRowUI> onSelect) { }

	private void CaptureDefaultState() { }

	private void EnsureClickable() { }

	[CompilerGenerated]
	public long get_PetId() { }

	[CompilerGenerated]
	public string get_PetName() { }

	[CompilerGenerated]
	public long get_UserPetId() { }

	[CompilerGenerated]
	private void set_PetId(long value) { }

	[CompilerGenerated]
	private void set_PetName(string value) { }

	[CompilerGenerated]
	private void set_UserPetId(long value) { }

	public void SetInteractable(bool on) { }

	public void SetSelected(bool selected) { }

}

