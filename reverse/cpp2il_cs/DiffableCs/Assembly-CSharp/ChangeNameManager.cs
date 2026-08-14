//Type is in global namespace

public class ChangeNameManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <ChangeNameCoroutine>d__13 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ChangeNameManager <>4__this; //Field offset: 0x20
		public string newName; //Field offset: 0x28

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
		public <ChangeNameCoroutine>d__13(int <>1__state) { }

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

	private const int CHANGE_NAME_COST = 300000; //Field offset: 0x0
	[Header("Panel")]
	public GameObject panelChangeName; //Field offset: 0x20
	public Button btnOpenChangeName; //Field offset: 0x28
	[Header("UI Components (trong Rewards)")]
	public Text txtOldName; //Field offset: 0x30
	public Text txtMessage; //Field offset: 0x38
	public InputField inputNewName; //Field offset: 0x40
	public Button btnClose; //Field offset: 0x48
	public Button btnChange; //Field offset: 0x50
	private int userId; //Field offset: 0x58

	public ChangeNameManager() { }

	[CompilerGenerated]
	private void <ChangeNameCoroutine>b__13_0(ChangeNameResponse response) { }

	[CompilerGenerated]
	private void <ChangeNameCoroutine>b__13_1(string error) { }

	[IteratorStateMachine(typeof(<ChangeNameCoroutine>d__13))]
	private IEnumerator ChangeNameCoroutine(string newName) { }

	private void ClosePanel() { }

	private void OnClickChangeName() { }

	private void OnDestroy() { }

	public void OpenPanel() { }

	private void ShowMessage(string message, bool isSuccess) { }

	private void Start() { }

	private void UpdateUIAfterChangeName(string newName, int remainingGold) { }

}

