//Type is in global namespace

public class SpinBtn : MonoBehaviour
{
	[SerializeField]
	private Text label; //Field offset: 0x20
	[Header("Spin View")]
	[SerializeField]
	private Sprite spinSp; //Field offset: 0x28
	[SerializeField]
	private Color spinColor; //Field offset: 0x30
	[Header("Stop View")]
	[SerializeField]
	private Sprite stopSp; //Field offset: 0x40
	[SerializeField]
	private Color stopColor; //Field offset: 0x48
	private SlotMachine _parent; //Field offset: 0x58
	private bool _isSpin; //Field offset: 0x60
	private Image _background; //Field offset: 0x68

	public SpinBtn() { }

	public void Initialize(SlotMachine parent) { }

	private void OnClick() { }

	public void SetViewAsSpin() { }

	public void SetViewAsStop() { }

}

