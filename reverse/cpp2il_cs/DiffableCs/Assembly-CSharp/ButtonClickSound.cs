//Type is in global namespace

public class ButtonClickSound : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public static AudioClip clickSound; //Field offset: 0x0
	public static AudioSource audioSource; //Field offset: 0x8
	[Range(0, 1)]
	public float volume; //Field offset: 0x20
	private Button button; //Field offset: 0x28

	public ButtonClickSound() { }

	private void Awake() { }

	private void OnDisable() { }

	private void OnEnable() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private void OnVolumeChanged(float newValue) { }

	private void UpdateAudioSourceVolume() { }

}

