//Type is in global namespace

public class QuangTruongWeather : MonoBehaviour
{
	private class Drop
	{
		public RectTransform rt; //Field offset: 0x10
		public float speed; //Field offset: 0x18
		public float drift; //Field offset: 0x1C
		public float phase; //Field offset: 0x20
		public float sway; //Field offset: 0x24
		public float baseX; //Field offset: 0x28

		public Drop() { }

	}

	internal enum Mode
	{
		AutoByHour = 0,
		Manual = 1,
	}

	internal enum Weather
	{
		None = 0,
		Rain = 1,
		Snow = 2,
		Sun = 3,
	}

	private static Sprite _cachedDot; //Field offset: 0x0
	private static Sprite _cachedLine; //Field offset: 0x8
	[Header("Bật/tắt")]
	[Tooltip("Bỏ tick = tắt hẳn thời tiết (không sinh hạt, không chạy Update).")]
	public bool weatherEnabled; //Field offset: 0x20
	[Header("Chế độ")]
	public Mode mode; //Field offset: 0x24
	[Tooltip("Thời tiết khi Manual")]
	public Weather manualWeather; //Field offset: 0x28
	[Header("Lịch theo giờ (0-23)")]
	[Tooltip("Từ giờ này bắt đầu TUYẾT (mặc định 5h)")]
	public int snowStartHour; //Field offset: 0x2C
	[Tooltip("Từ giờ này bắt đầu NẮNG (mặc định 8h)")]
	public int sunStartHour; //Field offset: 0x30
	[Tooltip("Từ giờ này bắt đầu MƯA (mặc định 18h)")]
	public int rainStartHour; //Field offset: 0x34
	[Header("Số hạt")]
	public int rainCount; //Field offset: 0x38
	public int snowCount; //Field offset: 0x3C
	[Header("Tint nắng")]
	[Range(0, 0.4)]
	[Tooltip("Độ đậm ánh nắng ấm ban ngày (0 = tắt)")]
	public float sunTintStrength; //Field offset: 0x40
	public float tintFadeTime; //Field offset: 0x44
	[Header("Vị trí render trong hub Canvas")]
	[Tooltip("Chèn hiệu ứng NGAY TRÊN object này (nền 'Panel'). Mọi UI/panel sau nó sẽ đè lên.")]
	public string insertAfterChildName; //Field offset: 0x48
	private RectTransform _hubRect; //Field offset: 0x50
	private RectTransform _dropRoot; //Field offset: 0x58
	private Canvas _hubCanvas; //Field offset: 0x60
	private Canvas _dropCanvas; //Field offset: 0x68
	private bool _wasVisible; //Field offset: 0x70
	private Image _tint; //Field offset: 0x78
	private Sprite _dotSprite; //Field offset: 0x80
	private Sprite _lineSprite; //Field offset: 0x88
	private Color _targetTint; //Field offset: 0x90
	private float _hourTimer; //Field offset: 0xA0
	private Weather _active; //Field offset: 0xA4
	private readonly List<Drop> _drops; //Field offset: 0xA8

	public QuangTruongWeather() { }

	public void Apply() { }

	private bool BuildContainer() { }

	private Vector2 CanvasSize() { }

	private static bool InRange(int hour, int start, int end) { }

	private bool IsWeatherVisible() { }

	private Drop MakeDrop(Weather w) { }

	private Sprite MakeSprite(bool line) { }

	private void RebuildDrops(Weather w) { }

	public void SetWeatherEnabled(bool on) { }

	private void ShutdownWeather() { }

	private void Start() { }

	private void StepDrops() { }

	private static void Stretch(RectTransform rt) { }

	private void Update() { }

	private Weather WeatherForHour(int hour) { }

}

