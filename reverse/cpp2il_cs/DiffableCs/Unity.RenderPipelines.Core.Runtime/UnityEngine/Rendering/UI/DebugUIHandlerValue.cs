namespace UnityEngine.Rendering.UI;

public class DebugUIHandlerValue : DebugUIHandlerWidget
{
	private static readonly Color k_ZeroColor; //Field offset: 0x0
	public Text nameLabel; //Field offset: 0x60
	public Text valueLabel; //Field offset: 0x68
	private Value m_Field; //Field offset: 0x70
	protected private float m_Timer; //Field offset: 0x78

	private static DebugUIHandlerValue() { }

	public DebugUIHandlerValue() { }

	public virtual void OnDeselection() { }

	protected virtual void OnEnable() { }

	public virtual bool OnSelection(bool fromNext, DebugUIHandlerWidget previous) { }

	internal virtual void SetWidget(Widget widget) { }

	private void Update() { }

}

