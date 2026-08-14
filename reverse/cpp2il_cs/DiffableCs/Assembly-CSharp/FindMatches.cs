//Type is in global namespace

public class FindMatches : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Int32, Int32, GameObject> <>9__19_1; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal GameObject <VirtualFindAllMatches>b__19_1(int x, int y) { }

	}

	[CompilerGenerated]
	private static FindMatches <Instance>k__BackingField; //Field offset: 0x0
	private Board _board; //Field offset: 0x20
	private BoardPVP _boardPVP; //Field offset: 0x28
	public List<GameObject> currentMatches; //Field offset: 0x30

	private int BoardHeight
	{
		private get { } //Length: 67
	}

	private int BoardWidth
	{
		private get { } //Length: 67
	}

	public private static FindMatches Instance
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	private bool IsPVP
	{
		private get { } //Length: 172
	}

	public FindMatches() { }

	[CompilerGenerated]
	private GameObject <VirtualFindAllMatches>b__19_0(int x, int y) { }

	private void AddToCurrentMatches(GameObject dot) { }

	private void Awake() { }

	public void FindAllMatches() { }

	private int get_BoardHeight() { }

	private int get_BoardWidth() { }

	[CompilerGenerated]
	public static FindMatches get_Instance() { }

	private bool get_IsPVP() { }

	private GameObject GetDot(int x, int y) { }

	private void OnDestroy() { }

	[CompilerGenerated]
	private static void set_Instance(FindMatches value) { }

	private void Start() { }

	public void VirtualFindAllMatches(HashSet<GameObject> matches) { }

}

