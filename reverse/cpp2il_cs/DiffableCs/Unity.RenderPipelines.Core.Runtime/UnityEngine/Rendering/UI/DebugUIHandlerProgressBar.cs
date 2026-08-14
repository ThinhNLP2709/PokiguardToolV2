namespace UnityEngine.Rendering.UI;

public class DebugUIHandlerProgressBar : DebugUIHandlerWidget
{
	public Text nameLabel; //Field offset: 0x60
	public Text valueLabel; //Field offset: 0x68
	public RectTransform progressBarRect; //Field offset: 0x70
	private ProgressBarValue m_Value; //Field offset: 0x78
	private float m_Timer; //Field offset: 0x80

	public DebugUIHandlerProgressBar() { }

	public virtual void OnDeselection() { }

	protected virtual void OnEnable() { }

	public virtual bool OnSelection(bool fromNext, DebugUIHandlerWidget previous) { }

	internal virtual void SetWidget(Widget widget) { }

	private void Update() { }

	private void UpdateValue() { }

}

