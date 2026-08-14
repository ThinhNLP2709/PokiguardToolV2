//Type is in global namespace

public class ToggleManagerPVP : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<CardSelectionData, CardData> <>9__23_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal CardData <GetSelectedCards>b__23_0(CardSelectionData s) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass21_0
	{
		public ToggleManagerPVP <>4__this; //Field offset: 0x10
		public Toggle toggle; //Field offset: 0x18

		public <>c__DisplayClass21_0() { }

		internal void <RegisterToggle>b__0(bool _) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass29_0
	{
		public ToggleManagerPVP <>4__this; //Field offset: 0x10
		public CardSelectionData captured; //Field offset: 0x18
		public GameObject obj; //Field offset: 0x20

		public <>c__DisplayClass29_0() { }

		internal void <AddSelectedImage>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass30_0
	{
		public CardSelectionData captured; //Field offset: 0x10
		public GameObject capturedObj; //Field offset: 0x18
		public ToggleManagerPVP <>4__this; //Field offset: 0x20

		public <>c__DisplayClass30_0() { }

		internal void <RefreshLocalPlayerCardPanel>b__0() { }

	}

	[Header("Card Toggle List")]
	public GameObject listToggle; //Field offset: 0x20
	public GameObject togglePrefab; //Field offset: 0x28
	public int maxSelected; //Field offset: 0x30
	[Header("Selected Card Display")]
	public GameObject selectedImagePrefab; //Field offset: 0x38
	[Header("Panel Card theo Slot (index 0-3)")]
	public RectTransform panelCardUser0; //Field offset: 0x40
	public RectTransform panelCardUser1; //Field offset: 0x48
	public RectTransform panelCardUser2; //Field offset: 0x50
	public RectTransform panelCardUser3; //Field offset: 0x58
	[Header("Colors")]
	public Color selectedColor; //Field offset: 0x60
	public Color defaultColor; //Field offset: 0x70
	[HideInInspector]
	public int LocalSlotUIIndex; //Field offset: 0x80
	private List<Toggle> registeredToggles; //Field offset: 0x88
	private List<CardSelectionData> selectedCardsList; //Field offset: 0x90
	private Dictionary<Int32, Int32> selectedCountByCardId; //Field offset: 0x98
	private Dictionary<Int32, Toggle> togglesByCardId; //Field offset: 0xA0
	private Dictionary<String, GameObject> selectedImagesBySelectionId; //Field offset: 0xA8
	private HashSet<Int32> selectedAttackCardIds; //Field offset: 0xB0
	private bool isRestoring; //Field offset: 0xB8
	[CompilerGenerated]
	private Action OnSelectionChanged; //Field offset: 0xC0

	public event Action OnSelectionChanged
	{
		[CompilerGenerated]
		 add { } //Length: 162
		[CompilerGenerated]
		 remove { } //Length: 162
	}

	public ToggleManagerPVP() { }

	[CompilerGenerated]
	public void add_OnSelectionChanged(Action value) { }

	private void AddSelectedImage(CardSelectionData selectionData) { }

	public void ClearAllToggles() { }

	private GameObject CreateCardIconById(int cardId) { }

	private RectTransform GetPanelByIndex(int index) { }

	public List<CardData> GetSelectedCards() { }

	private bool IsAttackCard(CardData card) { }

	private void OnToggleChanged(Toggle changedToggle) { }

	private void ProcessCardSelection(CardData card, int cardId, bool isAttack, Toggle toggle) { }

	private void RebuildToggleIndex() { }

	public void RefreshLocalPlayerCardPanel() { }

	public void RegisterToggle(Toggle toggle) { }

	[CompilerGenerated]
	public void remove_OnSelectionChanged(Action value) { }

	public void RemoveSelectedCard(CardSelectionData selectionData) { }

	public int RestoreSelectionByCardIds(List<Int32> cardIds) { }

	private void UpdateToggleColor(Toggle toggle) { }

	private void UpdateToggleCountText(int cardId) { }

	private void UpdateToggleInteractable(Toggle toggle) { }

}

