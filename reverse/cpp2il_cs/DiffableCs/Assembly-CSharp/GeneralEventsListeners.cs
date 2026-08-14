//Type is in global namespace

public class GeneralEventsListeners : MonoBehaviour
{
	internal enum MyEvents
	{
		CHANGE_COLOR = 0,
		JUMP = 1,
		LENGTH = 2,
	}

	private Vector3 towardsRotation; //Field offset: 0x20
	private float turnForLength; //Field offset: 0x2C
	private float turnForIter; //Field offset: 0x30
	private Color fromColor; //Field offset: 0x34

	public GeneralEventsListeners() { }

	[CompilerGenerated]
	private void <changeColor>b__8_0(Color col) { }

	private void Awake() { }

	private void changeColor(LTEvent e) { }

	private void FixedUpdate() { }

	private void jumpUp(LTEvent e) { }

	private void OnCollisionEnter(Collision collision) { }

	private void OnCollisionStay(Collision collision) { }

	private void OnMouseDown() { }

	private void Start() { }

}

