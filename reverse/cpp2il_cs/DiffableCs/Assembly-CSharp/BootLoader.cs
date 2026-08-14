//Type is in global namespace

public class BootLoader : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action <>9__39_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <ShowSoftUpdatePrompt>b__39_0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass37_0
	{
		public bool ready; //Field offset: 0x10
		public Action<Boolean> <>9__0; //Field offset: 0x18
		public Action<Boolean> <>9__1; //Field offset: 0x20

		public <>c__DisplayClass37_0() { }

		internal void <Start>b__0(bool ok) { }

		internal void <Start>b__1(bool ok) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass39_0
	{
		public bool done; //Field offset: 0x10

		public <>c__DisplayClass39_0() { }

		internal void <ShowSoftUpdatePrompt>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass40_0
	{
		public bool manualRecheck; //Field offset: 0x10

		public <>c__DisplayClass40_0() { }

		internal void <RunBlockWall>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass42_0
	{
		public List<Object> validKeys; //Field offset: 0x10
		public bool verified; //Field offset: 0x18

		public <>c__DisplayClass42_0() { }

		internal void <RunDownloadFlow>b__0(List<Object> list) { }

		internal void <RunDownloadFlow>b__1(bool ok) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass42_1
	{
		public bool accepted; //Field offset: 0x10

		public <>c__DisplayClass42_1() { }

		internal void <RunDownloadFlow>b__2(bool ok) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass48_0
	{
		public Nullable<Boolean> choice; //Field offset: 0x10

		public <>c__DisplayClass48_0() { }

		internal void <ConfirmLargeDownload>b__0() { }

		internal void <ConfirmLargeDownload>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass49_0
	{
		public bool retry; //Field offset: 0x10

		public <>c__DisplayClass49_0() { }

		internal void <ShowRetryWall>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass51_0
	{
		public Action onPrimary; //Field offset: 0x10
		public Action onSecondary; //Field offset: 0x18

		public <>c__DisplayClass51_0() { }

		internal void <ShowBlockPanel>b__0() { }

		internal void <ShowBlockPanel>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <ConfirmLargeDownload>d__48 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public long totalBytes; //Field offset: 0x20
		public BootLoader <>4__this; //Field offset: 0x28
		public Action<Boolean> done; //Field offset: 0x30
		private <>c__DisplayClass48_0 <>8__1; //Field offset: 0x38

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
		public <ConfirmLargeDownload>d__48(int <>1__state) { }

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

	[CompilerGenerated]
	private sealed class <CountdownText>d__50 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public float seconds; //Field offset: 0x20
		public BootLoader <>4__this; //Field offset: 0x28
		public string formatWithPlaceholder; //Field offset: 0x30
		private float <left>5__2; //Field offset: 0x38
		private int <lastShown>5__3; //Field offset: 0x3C

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
		public <CountdownText>d__50(int <>1__state) { }

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

	[CompilerGenerated]
	private sealed class <FadeOut>d__57 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BootLoader <>4__this; //Field offset: 0x20
		private float <t>5__2; //Field offset: 0x28

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
		public <FadeOut>d__57(int <>1__state) { }

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

	[CompilerGenerated]
	private sealed class <ResolveValidKeys>d__43 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BootLoader <>4__this; //Field offset: 0x20
		public Action<List`1<Object>> done; //Field offset: 0x28
		private List<Object> <result>5__2; //Field offset: 0x30
		private String[] <>7__wrap2; //Field offset: 0x38
		private int <>7__wrap3; //Field offset: 0x40
		private string <key>5__5; //Field offset: 0x48
		private AsyncOperationHandle<IList`1<IResourceLocation>> <h>5__6; //Field offset: 0x50

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
		public <ResolveValidKeys>d__43(int <>1__state) { }

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

	[CompilerGenerated]
	private sealed class <RotateTips>d__54 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BootLoader <>4__this; //Field offset: 0x20
		private int <i>5__2; //Field offset: 0x28

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
		public <RotateTips>d__54(int <>1__state) { }

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

	[CompilerGenerated]
	private sealed class <RunAppGate>d__38 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BootLoader <>4__this; //Field offset: 0x20

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
		public <RunAppGate>d__38(int <>1__state) { }

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

	[CompilerGenerated]
	private sealed class <RunBlockWall>d__40 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BootLoader <>4__this; //Field offset: 0x20
		private <>c__DisplayClass40_0 <>8__1; //Field offset: 0x28
		private bool <maintenance>5__2; //Field offset: 0x30
		private string <title>5__3; //Field offset: 0x38
		private string <msg>5__4; //Field offset: 0x40
		private float <nextPoll>5__5; //Field offset: 0x48

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
		public <RunBlockWall>d__40(int <>1__state) { }

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

	[CompilerGenerated]
	private sealed class <RunDownloadFlow>d__42 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BootLoader <>4__this; //Field offset: 0x20
		public int attempt; //Field offset: 0x28
		public Action<Boolean> done; //Field offset: 0x30
		private <>c__DisplayClass42_0 <>8__1; //Field offset: 0x38
		private <>c__DisplayClass42_1 <>8__2; //Field offset: 0x40
		private AsyncOperationHandle<Int64> <sizeHandle>5__2; //Field offset: 0x48
		private long <totalBytes>5__3; //Field offset: 0x60
		private AsyncOperationHandle <downloadHandle>5__4; //Field offset: 0x68

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
		public <RunDownloadFlow>d__42(int <>1__state) { }

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

	[CompilerGenerated]
	private sealed class <ShowRetryWall>d__49 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BootLoader <>4__this; //Field offset: 0x20
		public string message; //Field offset: 0x28
		private <>c__DisplayClass49_0 <>8__1; //Field offset: 0x30

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
		public <ShowRetryWall>d__49(int <>1__state) { }

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

	[CompilerGenerated]
	private sealed class <ShowSoftUpdatePrompt>d__39 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BootLoader <>4__this; //Field offset: 0x20
		private <>c__DisplayClass39_0 <>8__1; //Field offset: 0x28

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
		public <ShowSoftUpdatePrompt>d__39(int <>1__state) { }

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

	[CompilerGenerated]
	private sealed class <Start>d__37 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BootLoader <>4__this; //Field offset: 0x20
		private <>c__DisplayClass37_0 <>8__1; //Field offset: 0x28
		private float <delay>5__2; //Field offset: 0x30
		private int <attempt>5__3; //Field offset: 0x34

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
		public <Start>d__37(int <>1__state) { }

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

	[CompilerGenerated]
	private sealed class <TrackDownload>d__45 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public AsyncOperationHandle handle; //Field offset: 0x20
		public long fallbackTotal; //Field offset: 0x38
		public BootLoader <>4__this; //Field offset: 0x40
		private float <elapsed>5__2; //Field offset: 0x48
		private long <lastBytes>5__3; //Field offset: 0x50
		private float <speedEma>5__4; //Field offset: 0x58
		private float <lastSampleTime>5__5; //Field offset: 0x5C
		private float <lastTextTime>5__6; //Field offset: 0x60
		private long <lastObservedBytes>5__7; //Field offset: 0x68
		private float <lastByteChangeTime>5__8; //Field offset: 0x70
		private bool <stalled>5__9; //Field offset: 0x74

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
		public <TrackDownload>d__45(int <>1__state) { }

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

	[CompilerGenerated]
	private sealed class <UpdateCatalogIfNeeded>d__41 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BootLoader <>4__this; //Field offset: 0x20
		private AsyncOperationHandle<List`1<String>> <checkHandle>5__2; //Field offset: 0x28
		private AsyncOperationHandle<List`1<IResourceLocator>> <updateHandle>5__3; //Field offset: 0x40

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
		public <UpdateCatalogIfNeeded>d__41(int <>1__state) { }

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

	[CompilerGenerated]
	private sealed class <VerifyNothingLeft>d__44 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public List<Object> keys; //Field offset: 0x20
		public Action<Boolean> done; //Field offset: 0x28
		private AsyncOperationHandle<Int64> <h>5__2; //Field offset: 0x30

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
		public <VerifyNothingLeft>d__44(int <>1__state) { }

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

	[CompilerGenerated]
	private sealed class <WaitForMinDisplayTime>d__56 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BootLoader <>4__this; //Field offset: 0x20
		private float <guard>5__2; //Field offset: 0x28

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
		public <WaitForMinDisplayTime>d__56(int <>1__state) { }

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

	private const float PROGRESS_LERP_SPEED = 3.5; //Field offset: 0x0
	private const float SPEED_EMA_ALPHA = 0.2; //Field offset: 0x0
	private const float TIP_INTERVAL = 4; //Field offset: 0x0
	private const float AUTO_RETRY_SECONDS = 5; //Field offset: 0x0
	private const float MAINTENANCE_POLL_SECONDS = 15; //Field offset: 0x0
	private static readonly String[] TIPS; //Field offset: 0x0
	private const float TEXT_REFRESH_INTERVAL = 0.25; //Field offset: 0x0
	[Header("UI cơ bản (đã có sẵn trong BootScene)")]
	public Slider progressBar; //Field offset: 0x20
	[Tooltip("Text tổng hợp: '32.5 MB / 48.7 MB  •  67%  •  Còn ~15s' hoặc text lỗi")]
	public Text progressText; //Field offset: 0x28
	[Header("Tường chặn — TÙY CHỌN, thiếu thì dồn thông điệp về progressText")]
	[Tooltip("Panel hiện khi buộc cập nhật / bảo trì / hỏi xác nhận tải")]
	public GameObject blockPanel; //Field offset: 0x30
	public Text blockTitleText; //Field offset: 0x38
	public Text blockMessageText; //Field offset: 0x40
	[Tooltip("Nút hành động chính: Cập nhật ngay / Tải xuống / Thử lại")]
	public Button blockPrimaryButton; //Field offset: 0x48
	public Text blockPrimaryLabel; //Field offset: 0x50
	[Tooltip("Nút phụ: Để sau / Hủy. Ẩn ở trạng thái chặn cứng.")]
	public Button blockSecondaryButton; //Field offset: 0x58
	public Text blockSecondaryLabel; //Field offset: 0x60
	[Header("Hiệu ứng — TÙY CHỌN")]
	[Tooltip("Logo nhấp nhô nhẹ trong lúc chờ")]
	public Transform logoTransform; //Field offset: 0x68
	[Tooltip("Dùng để fade khi chuyển sang Login (che khoảng lag của LoadScene)")]
	public CanvasGroup fadeCanvasGroup; //Field offset: 0x70
	[Tooltip("Dòng mẹo xoay vòng cho đỡ sốt ruột")]
	public Text tipText; //Field offset: 0x78
	[Header("Nội dung cần tải")]
	[Tooltip("Label/địa chỉ Addressables BẮT BUỘC phải tải xong trước khi cho vào game.\n\nĐỂ TRỐNG là lựa chọn đúng cho hầu hết trường hợp: người chơi vào game ngay, nội dung tải nền, và thứ nào cần cho một trận cụ thể thì đã có chốt chặn riêng ở phòng chờ (MatchAssetGate).\n\nCHỈ thêm key vào đây nếu thiếu nó thì màn hình đầu tiên đã hỏng. Mỗi key thêm vào là bắt MỌI người chơi ngồi chờ trước khi được vào game.")]
	public String[] addressableKeys; //Field offset: 0x80
	[Header("Tải xuống")]
	[Tooltip("Số lần thử lại tối đa khi tải hỏng")]
	public int maxRetry; //Field offset: 0x88
	[Tooltip("Chờ bao lâu trước lần thử lại đầu tiên (giây). Các lần sau nhân đôi.")]
	public float retryDelaySeconds; //Field offset: 0x8C
	[Tooltip("Nếu số byte không tăng trong (giây) → coi là nghẽn, hiện cảnh báo")]
	public float stallThresholdSeconds; //Field offset: 0x90
	[Tooltip("Gói lớn hơn ngưỡng này (MB) mà đang dùng dữ liệu di động thì hỏi trước khi tải. 0 = không hỏi.")]
	public float confirmOverCellularMB; //Field offset: 0x94
	[Header("Trải nghiệm")]
	[Tooltip("Giữ màn hình khởi động ít nhất bấy nhiêu giây — chống 'nháy qua' khi không cần tải")]
	public float minDisplaySeconds; //Field offset: 0x98
	[Tooltip("Thời gian fade khi chuyển sang Login")]
	public float fadeOutSeconds; //Field offset: 0x9C
	[Tooltip("Bỏ qua cổng phiên bản (chỉ dùng khi phát triển offline)")]
	public bool skipVersionGateInEditor; //Field offset: 0xA0
	[Header("Điều hướng")]
	public string nextSceneName; //Field offset: 0xA8
	private readonly StringBuilder _sb; //Field offset: 0xB0
	private float _bootStartTime; //Field offset: 0xB8
	private float _displayedProgress; //Field offset: 0xBC
	private float _targetProgress; //Field offset: 0xC0
	private bool _downloadCancelled; //Field offset: 0xC4
	private int _logoTweenId; //Field offset: 0xC8
	private Coroutine _tipRoutine; //Field offset: 0xD0

	private static BootLoader() { }

	public BootLoader() { }

	private static void AppendBytes(StringBuilder sb, long bytes) { }

	private void Awake() { }

	private string BuildProgressLine(long done, long total, float percent01, float speed, bool stalled) { }

	[IteratorStateMachine(typeof(<ConfirmLargeDownload>d__48))]
	private IEnumerator ConfirmLargeDownload(long totalBytes, Action<Boolean> done) { }

	[IteratorStateMachine(typeof(<CountdownText>d__50))]
	private IEnumerator CountdownText(string formatWithPlaceholder, float seconds) { }

	[IteratorStateMachine(typeof(<FadeOut>d__57))]
	private IEnumerator FadeOut() { }

	private static string FirstNonEmpty(string a, string b) { }

	private static string FormatBytes(long bytes) { }

	private static string FormatTime(int seconds) { }

	private void HideBlockPanel() { }

	private bool NeedsCellularConfirm(long totalBytes) { }

	[IteratorStateMachine(typeof(<ResolveValidKeys>d__43))]
	private IEnumerator ResolveValidKeys(Action<List`1<Object>> done) { }

	[IteratorStateMachine(typeof(<RotateTips>d__54))]
	private IEnumerator RotateTips() { }

	[IteratorStateMachine(typeof(<RunAppGate>d__38))]
	private IEnumerator RunAppGate() { }

	[IteratorStateMachine(typeof(<RunBlockWall>d__40))]
	private IEnumerator RunBlockWall() { }

	[IteratorStateMachine(typeof(<RunDownloadFlow>d__42))]
	private IEnumerator RunDownloadFlow(int attempt, Action<Boolean> done) { }

	private void SetProgressText(string msg) { }

	private void ShowBlockPanel(string title, string message, string primaryLabel, Action onPrimary, string secondaryLabel, Action onSecondary) { }

	private void ShowError(string msg) { }

	[IteratorStateMachine(typeof(<ShowRetryWall>d__49))]
	private IEnumerator ShowRetryWall(string message) { }

	[IteratorStateMachine(typeof(<ShowSoftUpdatePrompt>d__39))]
	private IEnumerator ShowSoftUpdatePrompt() { }

	[IteratorStateMachine(typeof(<Start>d__37))]
	private IEnumerator Start() { }

	private void StartLogoPulse() { }

	private void StopProgressUi() { }

	[IteratorStateMachine(typeof(<TrackDownload>d__45))]
	private IEnumerator TrackDownload(AsyncOperationHandle handle, long fallbackTotal) { }

	private static string Truncate(string s, int max) { }

	private void Update() { }

	[IteratorStateMachine(typeof(<UpdateCatalogIfNeeded>d__41))]
	private IEnumerator UpdateCatalogIfNeeded() { }

	[IteratorStateMachine(typeof(<VerifyNothingLeft>d__44))]
	private IEnumerator VerifyNothingLeft(List<Object> keys, Action<Boolean> done) { }

	[IteratorStateMachine(typeof(<WaitForMinDisplayTime>d__56))]
	private IEnumerator WaitForMinDisplayTime() { }

}

