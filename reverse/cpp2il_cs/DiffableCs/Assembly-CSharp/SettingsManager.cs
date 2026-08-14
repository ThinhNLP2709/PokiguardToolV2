//Type is in global namespace

public class SettingsManager : MonoBehaviour
{
	[Header("Panels")]
	public GameObject panelSettings; //Field offset: 0x20
	[Header("Buttons")]
	public Button btnOpenSettings; //Field offset: 0x28
	public Button btnCloseSettings; //Field offset: 0x30
	public Button btnLogout; //Field offset: 0x38
	[Header("Volume Sliders")]
	public Slider sliderMasterVolume; //Field offset: 0x40
	public Slider sliderBGMVolume; //Field offset: 0x48
	public Slider sliderSFXVolume; //Field offset: 0x50
	[Header("Volume Texts (Optional)")]
	public Text txtMasterVolume; //Field offset: 0x58
	public Text txtBGMVolume; //Field offset: 0x60
	public Text txtSFXVolume; //Field offset: 0x68
	[Header("Confirm Logout Panel (Optional)")]
	public GameObject panelConfirmLogout; //Field offset: 0x70
	public Button btnConfirmLogout; //Field offset: 0x78
	public Button btnCancelLogout; //Field offset: 0x80
	private AudioSettingsManager audioSettingsManager; //Field offset: 0x88

	public SettingsManager() { }

	private void CancelLogout() { }

	private void ClearAllUserData() { }

	private void CloseSettings() { }

	private void ConfirmLogout() { }

	private void LoadCurrentVolumes() { }

	private void OnBGMVolumeChanged(float value) { }

	private void OnDestroy() { }

	private void OnMasterVolumeChanged(float value) { }

	private void OnSFXVolumeChanged(float value) { }

	public void OpenSettings() { }

	private void ShowLogoutConfirmation() { }

	private void Start() { }

	private void UpdateVolumeText(Text textComponent, float value) { }

}

