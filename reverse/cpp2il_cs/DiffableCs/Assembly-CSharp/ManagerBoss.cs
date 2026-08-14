//Type is in global namespace

public class ManagerBoss : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <UpdateCountdownLoop>d__19 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerBoss <>4__this; //Field offset: 0x20
		private WaitForSeconds <wait>5__2; //Field offset: 0x28

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
		public <UpdateCountdownLoop>d__19(int <>1__state) { }

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

	[Header("UI References")]
	public Button btnClose; //Field offset: 0x20
	public GameObject panelBoss; //Field offset: 0x28
	public GameObject panelBossTG; //Field offset: 0x30
	public GameObject panelNotice; //Field offset: 0x38
	public Button btnXepHang; //Field offset: 0x40
	public GameObject panelXepHang; //Field offset: 0x48
	[Header("Status Display")]
	public Text txtStatusOutside; //Field offset: 0x50
	public GameObject statusObject; //Field offset: 0x58
	public GameObject anmtObject; //Field offset: 0x60
	private List<WorldBossDTO> bossList; //Field offset: 0x68
	private List<BossItem> bossItems; //Field offset: 0x70
	private Coroutine _countdownCo; //Field offset: 0x78

	public ManagerBoss() { }

	public void ClosePanel() { }

	private void DisplayBosses() { }

	private void FindExistingBossItems() { }

	private void HideStatusAndAnimation() { }

	private void LoadBossList() { }

	private void OnBossListReceived(List<WorldBossDTO> bosses) { }

	private void OnDestroy() { }

	private void OnError(string error) { }

	public void OpenPanel() { }

	public void OpenPanelXepHang() { }

	public void RefreshBossList() { }

	private void Start() { }

	[IteratorStateMachine(typeof(<UpdateCountdownLoop>d__19))]
	private IEnumerator UpdateCountdownLoop() { }

}

