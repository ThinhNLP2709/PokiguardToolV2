//Type is in global namespace

public class ShowNotice : MonoBehaviour
{
	public GameObject notice; //Field offset: 0x20
	public Button showButton; //Field offset: 0x28
	public Button cancleNotice; //Field offset: 0x30
	[Tooltip("Gọi mỗi khi panel chuyển từ inactive → active (dùng để lazy-load dữ liệu)")]
	public UnityEvent onOpened; //Field offset: 0x38

	public ShowNotice() { }

	private void Start() { }

	private void ToggleNotice() { }

}

