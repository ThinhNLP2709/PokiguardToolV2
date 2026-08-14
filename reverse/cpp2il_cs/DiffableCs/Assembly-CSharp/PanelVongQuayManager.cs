//Type is in global namespace

public class PanelVongQuayManager : MonoBehaviour
{
	public const string PANEL_KEY = "PanelVongQuay"; //Field offset: 0x0
	[Header("Panels")]
	public GameObject panelVongQuay; //Field offset: 0x20
	public GameObject panelKhamHT; //Field offset: 0x28
	[Header("Buttons")]
	public Button btnEvent4; //Field offset: 0x30
	public Button btnClosePanelVongQuay; //Field offset: 0x38
	public Button btnOpenPanelHT; //Field offset: 0x40
	public Button btnClosePanelKhamHT; //Field offset: 0x48

	public PanelVongQuayManager() { }

	private void Awake() { }

	private void ClosePanelKhamHT() { }

	private void ClosePanelVongQuay() { }

	private void OnDestroy() { }

	private void OpenPanelKhamHT() { }

	public void OpenPanelVongQuay() { }

}

