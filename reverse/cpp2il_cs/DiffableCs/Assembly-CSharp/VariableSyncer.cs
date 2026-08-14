//Type is in global namespace

public class VariableSyncer : MonoBehaviour
{
	[Header("Nguồn & Đích")]
	public MonoBehaviour sourceScript; //Field offset: 0x20
	public MonoBehaviour targetScript; //Field offset: 0x28
	[Header("Tuỳ chọn")]
	[Tooltip("Chỉ sync các field được đánh dấu [SyncVariable]")]
	public bool useAttributeFilter; //Field offset: 0x30
	[Tooltip("Bỏ qua nếu kiểu dữ liệu khác nhau")]
	public bool strictTypeMatch; //Field offset: 0x31

	public VariableSyncer() { }

	private int SyncFields(MonoBehaviour from, MonoBehaviour to) { }

	[ContextMenu("🔄 Sync Variables ← Source (đảo ngược)")]
	public void SyncToSource() { }

	[ContextMenu("🔄 Sync Variables → Target")]
	public void SyncToTarget() { }

	private bool Validate() { }

}

