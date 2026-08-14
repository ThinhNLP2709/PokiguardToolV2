//Type is in global namespace

public class SkillLg : MonoBehaviour
{
	public Slider slider; //Field offset: 0x20
	public Button button; //Field offset: 0x28
	private float durationSlider; //Field offset: 0x30
	private float durationLogic; //Field offset: 0x34
	private float elapsedTime; //Field offset: 0x38
	private bool isSliding; //Field offset: 0x3C
	private DotSkillManager skillManager; //Field offset: 0x40
	public GameObject timeSkillLegend; //Field offset: 0x48
	public GameObject arrowPanel; //Field offset: 0x50
	public GameObject GroupDot; //Field offset: 0x58
	public GameObject boardObj; //Field offset: 0x60

	public SkillLg() { }

	private void Start() { }

	private void StartSliding() { }

	private void Update() { }

}

