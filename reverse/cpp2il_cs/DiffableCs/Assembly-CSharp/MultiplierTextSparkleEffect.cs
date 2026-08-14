//Type is in global namespace

[RequireComponent(typeof(TextMesh))]
public class MultiplierTextSparkleEffect : MonoBehaviour
{
	private TextMesh _main; //Field offset: 0x20
	private TextMesh _outline; //Field offset: 0x28
	private Transform _mainTr; //Field offset: 0x30
	private Transform _outlineTr; //Field offset: 0x38
	private Vector3 _baseMainScale; //Field offset: 0x40
	private Vector3 _baseOutlineScale; //Field offset: 0x4C
	private Color _mainA; //Field offset: 0x58
	private Color _mainB; //Field offset: 0x68
	private Color _outlineA; //Field offset: 0x78
	private Color _outlineB; //Field offset: 0x88
	private int _tier; //Field offset: 0x98

	public MultiplierTextSparkleEffect() { }

	private void ApplyTierColors() { }

	private void ApplyTwinkle(float t, float colorHz, float scaleHz, float mainScaleAmp, float outlineScaleAmp) { }

	public void Setup(int multiplier, TextMesh outlineMesh, Transform outlineTransform) { }

	private static bool TryHex(string hex, out Color c) { }

	private void Update() { }

}

