namespace UnityEngine.Rendering.UI;

public class DebugUIHandlerVector4 : DebugUIHandlerWidget
{
	public Text nameLabel; //Field offset: 0x60
	public UIFoldout valueToggle; //Field offset: 0x68
	public DebugUIHandlerIndirectFloatField fieldX; //Field offset: 0x70
	public DebugUIHandlerIndirectFloatField fieldY; //Field offset: 0x78
	public DebugUIHandlerIndirectFloatField fieldZ; //Field offset: 0x80
	public DebugUIHandlerIndirectFloatField fieldW; //Field offset: 0x88
	private Vector4Field m_Field; //Field offset: 0x90
	private DebugUIHandlerContainer m_Container; //Field offset: 0x98

	public DebugUIHandlerVector4() { }

	[CompilerGenerated]
	private float <SetupSettings>b__10_0() { }

	[CompilerGenerated]
	private float <SetupSettings>b__10_1() { }

	[CompilerGenerated]
	private float <SetupSettings>b__10_2() { }

	[CompilerGenerated]
	private float <SetWidget>b__8_0() { }

	[CompilerGenerated]
	private void <SetWidget>b__8_1(float x) { }

	[CompilerGenerated]
	private float <SetWidget>b__8_2() { }

	[CompilerGenerated]
	private void <SetWidget>b__8_3(float x) { }

	[CompilerGenerated]
	private float <SetWidget>b__8_4() { }

	[CompilerGenerated]
	private void <SetWidget>b__8_5(float x) { }

	[CompilerGenerated]
	private float <SetWidget>b__8_6() { }

	[CompilerGenerated]
	private void <SetWidget>b__8_7(float x) { }

	public virtual DebugUIHandlerWidget Next() { }

	public virtual void OnAction() { }

	public virtual void OnDecrement(bool fast) { }

	public virtual void OnDeselection() { }

	public virtual void OnIncrement(bool fast) { }

	public virtual bool OnSelection(bool fromNext, DebugUIHandlerWidget previous) { }

	private void SetupSettings(DebugUIHandlerIndirectFloatField field) { }

	private void SetValue(float v, bool x = false, bool y = false, bool z = false, bool w = false) { }

	internal virtual void SetWidget(Widget widget) { }

}

