//Type is in global namespace

[DisallowMultipleComponent]
public class PetShardItemUI : MonoBehaviour
{
	[Header("Ảnh")]
	public Image imgPet; //Field offset: 0x20
	[Tooltip("Lớp phủ mảnh — PHẢI đứng SAU imgPet trong hierarchy để vẽ đè lên.")]
	public Image imgPiece; //Field offset: 0x28
	[Header("Chữ")]
	public Text txtCount; //Field offset: 0x30
	public Text txtName; //Field offset: 0x38
	[Header("Phụ")]
	public PetStarRowUI starRow; //Field offset: 0x40
	[Tooltip("Viền sáng khi đã đủ mảnh để nâng sao ngay HOẶC đã đủ mảnh để đổi pet.")]
	public Outline readyOutline; //Field offset: 0x48
	[Header("Đổi pet — chỉ hiện với pet CHƯA sở hữu")]
	public Button btnExchange; //Field offset: 0x50
	public Text txtExchange; //Field offset: 0x58
	private bool _wired; //Field offset: 0x60
	private long _petId; //Field offset: 0x68
	private bool _pulsing; //Field offset: 0x70
	[CompilerGenerated]
	private bool <CanExchange>k__BackingField; //Field offset: 0x71

	public private bool CanExchange
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public long PetId
	{
		 get { } //Length: 5
	}

	public PetShardItemUI() { }

	private void ApplyExchangeState(PetShardDTO dto, int exchangeCost) { }

	private void AutoWire() { }

	private void Awake() { }

	public void CancelFx() { }

	private Image FindImage(string n) { }

	private Text FindText(string n) { }

	[CompilerGenerated]
	public bool get_CanExchange() { }

	public long get_PetId() { }

	private void HideExchange() { }

	private void OnDisable() { }

	[CompilerGenerated]
	private void set_CanExchange(bool value) { }

	public void SetData(PetShardDTO dto, int maxStar = 6, int exchangeCost = 0) { }

	public void SetSimple(long petId, string petName, int amount) { }

	private void StartPulse() { }

	private void StopPulse() { }

}

