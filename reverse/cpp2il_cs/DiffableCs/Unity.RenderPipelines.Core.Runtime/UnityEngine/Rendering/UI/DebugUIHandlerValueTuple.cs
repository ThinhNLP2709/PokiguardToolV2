namespace UnityEngine.Rendering.UI;

public class DebugUIHandlerValueTuple : DebugUIHandlerWidget
{
	private const float k_XOffset = 230; //Field offset: 0x0
	private static readonly Color k_ZeroColor; //Field offset: 0x0
	public Text nameLabel; //Field offset: 0x60
	public Text valueLabel; //Field offset: 0x68
	protected private ValueTuple m_Field; //Field offset: 0x70
	protected private Text[] valueElements; //Field offset: 0x78
	private float m_Timer; //Field offset: 0x80

	private static DebugUIHandlerValueTuple() { }

	public DebugUIHandlerValueTuple() { }

	public virtual void OnDeselection() { }

	protected virtual void OnEnable() { }

	public virtual bool OnSelection(bool fromNext, DebugUIHandlerWidget previous) { }

	internal virtual void SetWidget(Widget widget) { }

	private void Update() { }

	internal override void UpdateValueLabels() { }

}

