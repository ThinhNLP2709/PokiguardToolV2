//Type is in global namespace

public class ManagerThuVien : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<String> <>9__26_1; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <LoadPetsPage>b__26_1(string error) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass28_0
	{
		public ManagerThuVien <>4__this; //Field offset: 0x10
		public Sprite petSprite; //Field offset: 0x18
		public PetLibDTO pet; //Field offset: 0x20

		public <>c__DisplayClass28_0() { }

		internal void <InstantiatePetItem>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <LoadPetsPage>d__26 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerThuVien <>4__this; //Field offset: 0x20
		public int page; //Field offset: 0x28

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
		public <LoadPetsPage>d__26(int <>1__state) { }

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

	internal class PetLibraryPageResponse
	{
		public PetLibDTO[] content; //Field offset: 0x10
		public int totalPages; //Field offset: 0x18
		public int totalElements; //Field offset: 0x1C
		public int number; //Field offset: 0x20
		public int size; //Field offset: 0x24
		public bool first; //Field offset: 0x28
		public bool last; //Field offset: 0x29
		public int numberOfElements; //Field offset: 0x2C

		public PetLibraryPageResponse() { }

	}

	public const string PANEL_KEY = "PanelThuVien"; //Field offset: 0x0
	private const int PETS_PER_PAGE = 12; //Field offset: 0x0
	[Header("Pet List")]
	public GameObject petUIPrefab; //Field offset: 0x20
	public Transform petListContainer; //Field offset: 0x28
	[Header("Pagination")]
	public Button btnPrevPetPage; //Field offset: 0x30
	public Button btnNextPetPage; //Field offset: 0x38
	public Text txtPetPageNum; //Field offset: 0x40
	[Header("Pet Detail")]
	public GameObject banner; //Field offset: 0x48
	public Text namePet; //Field offset: 0x50
	public Text txtHp; //Field offset: 0x58
	public Text txtMana; //Field offset: 0x60
	public Text txtDame; //Field offset: 0x68
	public Text txtWee; //Field offset: 0x70
	public Text txtLv; //Field offset: 0x78
	public Text des; //Field offset: 0x80
	public Image imgAtribute; //Field offset: 0x88
	public Image imgAtributeOther; //Field offset: 0x90
	[Header("Close")]
	public Button btnClose; //Field offset: 0x98
	private int currentPetPage; //Field offset: 0xA0
	private PetLibraryPageResponse currentPetPageData; //Field offset: 0xA8
	private bool hasLoadedPetsOnce; //Field offset: 0xB0
	private bool isLoadingPetPage; //Field offset: 0xB1

	public ManagerThuVien() { }

	[CompilerGenerated]
	private void <LoadPetsPage>b__26_0(PetLibraryPageResponse data) { }

	private void Awake() { }

	public void Close() { }

	private void DisplayCurrentPetPage() { }

	private void InstantiatePetItem(PetLibDTO pet) { }

	[IteratorStateMachine(typeof(<LoadPetsPage>d__26))]
	private IEnumerator LoadPetsPage(int page) { }

	private void OnPetClicked(Sprite petSprite, string name, int attack, int hp, int mana, int maxLevel, string elementType, string elementOther, double weaknessValue, string txtDes) { }

	public void Open() { }

	private void SetPetPaginationButtonsState(bool enabled) { }

	private void ShowNextPetPage() { }

	private void ShowPreviousPetPage() { }

	private void UpdatePetPaginationButtons() { }

}

