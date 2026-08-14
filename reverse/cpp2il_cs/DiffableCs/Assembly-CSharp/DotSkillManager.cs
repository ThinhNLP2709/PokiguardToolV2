//Type is in global namespace

public class DotSkillManager : MonoBehaviour
{
	public Transform parentPanel; //Field offset: 0x20
	public GameObject arrowPrefab; //Field offset: 0x28
	public int arrowCount; //Field offset: 0x30
	public int correctCount; //Field offset: 0x34
	private List<Image> currentArrows; //Field offset: 0x38
	private String[] directions; //Field offset: 0x40
	private int currentIndex; //Field offset: 0x48
	private Dictionary<String, Sprite> blueArrows; //Field offset: 0x50
	private Dictionary<String, Sprite> purpleArrows; //Field offset: 0x58

	public DotSkillManager() { }

	private void CheckArrow(string dir) { }

	private void ClearOldArrows() { }

	public void GenerateArrows() { }

	private string GetDirectionFromInput() { }

	public void OnButtonPress(string dir) { }

	private void ResetCombo() { }

	private void Start() { }

	private void Update() { }

}

