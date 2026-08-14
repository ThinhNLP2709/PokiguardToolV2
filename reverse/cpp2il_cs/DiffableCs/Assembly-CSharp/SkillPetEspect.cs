//Type is in global namespace

public class SkillPetEspect : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass16_0
	{
		public string targetSpriteName; //Field offset: 0x10

		public <>c__DisplayClass16_0() { }

		internal bool <UpdateNutSprite>b__0(Sprite sprite) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass16_1
	{
		public string newTargetSpriteName; //Field offset: 0x10

		public <>c__DisplayClass16_1() { }

		internal bool <UpdateNutSprite>b__1(Sprite sprite) { }

	}

	[CompilerGenerated]
	private sealed class <ScrollSlider>d__18 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public SkillPetEspect <>4__this; //Field offset: 0x20
		public float duration; //Field offset: 0x28
		private float <elapsed>5__2; //Field offset: 0x2C

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
		public <ScrollSlider>d__18(int <>1__state) { }

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

	public GameObject openBoard; //Field offset: 0x20
	public GameObject closeCardEspect; //Field offset: 0x28
	public GameObject nutPrefab; //Field offset: 0x30
	public Transform parentTransform; //Field offset: 0x38
	public Slider timeCombo; //Field offset: 0x40
	public int nutCount; //Field offset: 0x48
	public float spacing; //Field offset: 0x4C
	public float scaleFactor; //Field offset: 0x50
	private int dem; //Field offset: 0x54
	private List<GameObject> nutObjects; //Field offset: 0x58
	private List<String> nutNames; //Field offset: 0x60
	private String[] keyBindings; //Field offset: 0x68
	private Sprite[] nutSpriteComplete; //Field offset: 0x70

	public SkillPetEspect() { }

	private void CreateNuts() { }

	private void HandleKeyPress(string key) { }

	[IteratorStateMachine(typeof(<ScrollSlider>d__18))]
	private IEnumerator ScrollSlider(float duration) { }

	private void Start() { }

	private void Update() { }

	private void UpdateNutSprite(int index) { }

}

