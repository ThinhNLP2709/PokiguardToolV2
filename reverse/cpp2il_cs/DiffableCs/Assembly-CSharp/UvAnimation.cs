//Type is in global namespace

[RequireComponent(typeof(Image))]
public class UvAnimation : MonoBehaviour
{
	private Material _material; //Field offset: 0x20
	private Image _image; //Field offset: 0x28
	private SlotMachine _parent; //Field offset: 0x30
	private int _index; //Field offset: 0x38

	public UvAnimation() { }

	public void Initialize(SlotMachine parent, int index) { }

	public void SetLevel(BlurLevel level) { }

	public void SetShaderSettings(float blurAmount, float speed, Vector2 tiling) { }

	public void SetVisibility(bool status) { }

}

