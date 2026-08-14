namespace UnityEngine.Rendering.UI;

public class DebugUIHandlerMessageBox : DebugUIHandlerWidget
{
	private static Color32 k_WarningBackgroundColor; //Field offset: 0x0
	private static Color32 k_WarningTextColor; //Field offset: 0x4
	private static Color32 k_ErrorBackgroundColor; //Field offset: 0x8
	private static Color32 k_ErrorTextColor; //Field offset: 0xC
	public Text nameLabel; //Field offset: 0x60
	private MessageBox m_Field; //Field offset: 0x68

	private static DebugUIHandlerMessageBox() { }

	public DebugUIHandlerMessageBox() { }

	public virtual bool OnSelection(bool fromNext, DebugUIHandlerWidget previous) { }

	internal virtual void SetWidget(Widget widget) { }

	private void Update() { }

}

