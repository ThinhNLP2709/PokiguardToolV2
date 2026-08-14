//Type is in global namespace

public class ManagerThongBao : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <LoadThongBao>d__14 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerThongBao <>4__this; //Field offset: 0x20

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
		public <LoadThongBao>d__14(int <>1__state) { }

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

	internal class ThongBaoDTO
	{
		public long id; //Field offset: 0x10
		public string tieuDe; //Field offset: 0x18
		public string noiDung; //Field offset: 0x20
		public string thoiGian; //Field offset: 0x28
		public bool daDoc; //Field offset: 0x30

		public ThongBaoDTO() { }

	}

	internal class ThongBaoResponse
	{
		public List<ThongBaoDTO> item; //Field offset: 0x10

		public ThongBaoResponse() { }

	}

	public const string PANEL_KEY = "PanelThongBao"; //Field offset: 0x0
	[Header("Panel")]
	public GameObject panelThongBao; //Field offset: 0x20
	public Button btnDongThongBao; //Field offset: 0x28
	[Header("Content")]
	public Text txtThongBao; //Field offset: 0x30
	public Text txtTieuDe; //Field offset: 0x38
	public ScrollRect scrollRect; //Field offset: 0x40
	[Header("Loading")]
	public GameObject loadingIndicator; //Field offset: 0x48
	[Header("Badge (tuỳ chọn)")]
	public GameObject badge; //Field offset: 0x50
	public Text txtBadgeCount; //Field offset: 0x58

	public ManagerThongBao() { }

	private void Awake() { }

	public void DongPanel() { }

	private string FormatThoiGian(string isoString) { }

	[IteratorStateMachine(typeof(<LoadThongBao>d__14))]
	private IEnumerator LoadThongBao() { }

	public void MoPanel() { }

	private void OnError(string error) { }

	private void OnReceived(ThongBaoResponse response) { }

	private void SetContent(string tieuDe, string noiDung) { }

	private void SetLoading(bool isLoading) { }

	public void UpdateBadge(int unreadCount) { }

}

