//Type is in global namespace

public class ApiLoadRoom : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass15_0
	{
		public Button button; //Field offset: 0x10
		public ApiLoadRoom <>4__this; //Field offset: 0x18

		public <>c__DisplayClass15_0() { }

		internal void <Update>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <CallJoinRoomApi>d__16 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18

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
		public <CallJoinRoomApi>d__16(int <>1__state) { }

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

	private const string apiUrl = "https://pokiwar70-production.up.railway.app/api/v1/roomWait/join"; //Field offset: 0x0
	public LoadDataCard loadDataCard; //Field offset: 0x20
	public LoadDataPet loadDataPet; //Field offset: 0x28
	public LoadRoom loadRoom; //Field offset: 0x30
	[CompilerGenerated]
	private Action <OnComplete>k__BackingField; //Field offset: 0x38
	public int check; //Field offset: 0x40
	public List<Button> imageButtons; //Field offset: 0x48
	public Button selectBtn; //Field offset: 0x50
	public GameObject btnDown; //Field offset: 0x58
	public GameObject boardCard; //Field offset: 0x60
	private HashSet<Button> buttonsWithEvent; //Field offset: 0x68

	public internal Action OnComplete
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		internal set { } //Length: 13
	}

	public ApiLoadRoom() { }

	[IteratorStateMachine(typeof(<CallJoinRoomApi>d__16))]
	public IEnumerator CallJoinRoomApi(int userId, int enemyPetId) { }

	[CompilerGenerated]
	public Action get_OnComplete() { }

	public void LoadBoardCard(Button button) { }

	[CompilerGenerated]
	internal void set_OnComplete(Action value) { }

	private void Update() { }

}

