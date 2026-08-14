namespace UnityEngine.Rendering.UI;

public class DebugUIHandlerVector2 : DebugUIHandlerWidget
{
	public Text nameLabel; //Field offset: 0x60
	public UIFoldout valueToggle; //Field offset: 0x68
	public DebugUIHandlerIndirectFloatField fieldX; //Field offset: 0x70
	public DebugUIHandlerIndirectFloatField fieldY; //Field offset: 0x78
	private Vector2Field m_Field; //Field offset: 0x80
	private DebugUIHandlerContainer m_Container; //Field offset: 0x88

	public DebugUIHandlerVector2() { }

	[CompilerGenerated]
	private float <SetupSettings>b__8_0() { }

	[CompilerGenerated]
	private float <SetupSettings>b__8_1() { }

	[CompilerGenerated]
	private float <SetupSettings>b__8_2() { }

	[CompilerGenerated]
	private float <SetWidget>b__6_0() { }

	[CompilerGenerated]
	private void <SetWidget>b__6_1(float x) { }

	[CompilerGenerated]
	private float <SetWidget>b__6_2() { }

	[CompilerGenerated]
	private void <SetWidget>b__6_3(float x) { }

	public virtual DebugUIHandlerWidget Next() { }

	public virtual void OnAction() { }

	public virtual void OnDecrement(bool fast) { }

	public virtual void OnDeselection() { }

	public virtual void OnIncrement(bool fast) { }

	public virtual bool OnSelection(bool fromNext, DebugUIHandlerWidget previous) { }

	private void SetupSettings(DebugUIHandlerIndirectFloatField field) { }

	private void SetValue(float v, bool x = false, bool y = false) { }

	internal virtual void SetWidget(Widget widget) { }

}

