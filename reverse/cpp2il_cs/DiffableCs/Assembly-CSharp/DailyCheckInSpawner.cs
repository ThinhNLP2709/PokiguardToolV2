//Type is in global namespace

public class DailyCheckInSpawner : MonoBehaviour
{
	[Header("Prefab")]
	[Tooltip("Drag PanelDiemDanh prefab vào đây")]
	public GameObject panelDiemDanhPrefab; //Field offset: 0x20
	[Header("Parent")]
	[Tooltip("Canvas để spawn vào (thường là Canvas chính)")]
	public Transform canvasTransform; //Field offset: 0x28
	[Header("Debug")]
	public bool debugMode; //Field offset: 0x30
	private GameObject spawnedPanelObject; //Field offset: 0x38
	private DailyCheckInManager spawnedPanelManager; //Field offset: 0x40

	public DailyCheckInSpawner() { }

	[CompilerGenerated]
	private void <SetupCloseCallback>b__9_0() { }

	[CompilerGenerated]
	private void <SetupCloseCallback>b__9_1() { }

	public void CloseDailyCheckIn() { }

	private void DestroyPanel() { }

	public bool IsPanelOpen() { }

	private void OnDestroy() { }

	public void OpenDailyCheckIn() { }

	private void SetupCloseCallback() { }

	private void SpawnPanel() { }

	private void Start() { }

	[ContextMenu("Test - Check Panel Status")]
	public void TestCheckStatus() { }

	[ContextMenu("Test - Close Panel")]
	public void TestClosePanel() { }

	[ContextMenu("Test - Open Panel")]
	public void TestOpenPanel() { }

	[ContextMenu("Test - Toggle Panel")]
	public void TestTogglePanel() { }

	public void TogglePanel() { }

}

