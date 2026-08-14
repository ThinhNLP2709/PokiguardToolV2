//Type is in global namespace

public class ToggleManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass18_0
	{
		public ToggleManager <>4__this; //Field offset: 0x10
		public Toggle toggle; //Field offset: 0x18

		public <>c__DisplayClass18_0() { }

		internal void <RegisterToggle>b__0(bool <p0>) { }

	}

	[Header("Toggle Settings")]
	public GameObject listToggle; //Field offset: 0x20
	public GameObject togglePrefab; //Field offset: 0x28
	[Header("Display Settings")]
	public GameObject selectedImagePrefab; //Field offset: 0x30
	public Transform[] displayPanel; //Field offset: 0x38
	public int maxSelected; //Field offset: 0x40
	internal int LocalSlot; //Field offset: 0x44
	[Header("Colors")]
	public Color selectedColor; //Field offset: 0x48
	public Color defaultColor; //Field offset: 0x58
	private List<CardSelectionData> selectedCardsList; //Field offset: 0x68
	private Dictionary<Int32, Int32> selectedCountByCardId; //Field offset: 0x70
	private Dictionary<Int32, Toggle> togglesByCardId; //Field offset: 0x78
	private Dictionary<String, GameObject> selectedImagesBySelectionId; //Field offset: 0x80
	private HashSet<Int32> selectedAttackCardIds; //Field offset: 0x88
	private bool isRestoring; //Field offset: 0x90
	[CompilerGenerated]
	private Action OnSelectionChanged; //Field offset: 0x98

	public event Action OnSelectionChanged
	{
		[CompilerGenerated]
		 add { } //Length: 162
		[CompilerGenerated]
		 remove { } //Length: 162
	}

	public ToggleManager() { }

	[CompilerGenerated]
	public void add_OnSelectionChanged(Action value) { }

	private void AddSelectedImage(CardSelectionData selectionData) { }

	private void AddSelectedImage(Toggle toggle) { }

	public void ClearAllToggles() { }

	public List<CardData> GetSelectedCards() { }

	public int GetSelectedCount() { }

	private bool IsAttackCard(CardData card) { }

	private void OnToggleChanged(Toggle changedToggle) { }

	private void ProcessCardSelection(CardData card, int cardId, bool isAttack, Toggle toggle) { }

	private void RebuildToggleIndex() { }

	public void RegisterToggle(Toggle toggle) { }

	[CompilerGenerated]
	public void remove_OnSelectionChanged(Action value) { }

	public void RemoveSelectedCard(CardSelectionData selectionData) { }

	public void ResetAllToggles() { }

	public int RestoreSelectionByCardIds(List<Int32> cardIds) { }

	public void RestoreToggle(Toggle toggle, bool isOn) { }

	private void Start() { }

	private void UpdateToggleColor(Toggle toggle) { }

	private void UpdateToggleCountText(int cardId) { }

	private void UpdateToggleInteractable(Toggle toggle) { }

}

