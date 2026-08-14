namespace UnityEngine.Rendering.UI;

public class DebugUIHandlerVector3 : DebugUIHandlerWidget
{
	public Text nameLabel; //Field offset: 0x60
	public UIFoldout valueToggle; //Field offset: 0x68
	public DebugUIHandlerIndirectFloatField fieldX; //Field offset: 0x70
	public DebugUIHandlerIndirectFloatField fieldY; //Field offset: 0x78
	public DebugUIHandlerIndirectFloatField fieldZ; //Field offset: 0x80
	private Vector3Field m_Field; //Field offset: 0x88
	private DebugUIHandlerContainer m_Container; //Field offset: 0x90

	public DebugUIHandlerVector3() { }

	[CompilerGenerated]
	private float <SetupSettings>b__9_0() { }

	[CompilerGenerated]
	private float <SetupSettings>b__9_1() { }

	[CompilerGenerated]
	private float <SetupSettings>b__9_2() { }

	[CompilerGenerated]
	private float <SetWidget>b__7_0() { }

	[CompilerGenerated]
	private void <SetWidget>b__7_1(float v) { }

	[CompilerGenerated]
	private float <SetWidget>b__7_2() { }

	[CompilerGenerated]
	private void <SetWidget>b__7_3(float v) { }

	[CompilerGenerated]
	private float <SetWidget>b__7_4() { }

	[CompilerGenerated]
	private void <SetWidget>b__7_5(float v) { }

	public virtual DebugUIHandlerWidget Next() { }

	public virtual void OnAction() { }

	public virtual void OnDecrement(bool fast) { }

	public virtual void OnDeselection() { }

	public virtual void OnIncrement(bool fast) { }

	public virtual bool OnSelection(bool fromNext, DebugUIHandlerWidget previous) { }

	private void SetupSettings(DebugUIHandlerIndirectFloatField field) { }

	private void SetValue(float v, bool x = false, bool y = false, bool z = false) { }

	internal virtual void SetWidget(Widget widget) { }

}

