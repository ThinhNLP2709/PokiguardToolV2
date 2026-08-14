//Type is in global namespace

public class AudioSettingsManager : MonoBehaviour
{
	private const string MASTER_VOLUME_KEY = "MasterVolume"; //Field offset: 0x0
	private const string BGM_VOLUME_KEY = "BGMVolume"; //Field offset: 0x0
	private const string SFX_VOLUME_KEY = "SFXVolume"; //Field offset: 0x0
	[Header("Volume Settings")]
	[Range(0, 1)]
	public float masterVolume; //Field offset: 0x20
	[Range(0, 1)]
	public float bgmVolume; //Field offset: 0x24
	[Range(0, 1)]
	public float sfxVolume; //Field offset: 0x28

	public AudioSettingsManager() { }

	public void ApplySettingsToCurrentScene() { }

	public static AudioSettings GetSavedSettings() { }

	public void LoadSettings() { }

	public void SaveSettings() { }

	public void SetBGMVolume(float volume) { }

	public void SetMasterVolume(float volume) { }

	public void SetSFXVolume(float volume) { }

	private void Start() { }

}

