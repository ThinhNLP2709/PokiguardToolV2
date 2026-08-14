namespace UnityEngine.Rendering.UI;

public class DebugUIHandlerColor : DebugUIHandlerWidget
{
	public Text nameLabel; //Field offset: 0x60
	public UIFoldout valueToggle; //Field offset: 0x68
	public Image colorImage; //Field offset: 0x70
	public DebugUIHandlerIndirectFloatField fieldR; //Field offset: 0x78
	public DebugUIHandlerIndirectFloatField fieldG; //Field offset: 0x80
	public DebugUIHandlerIndirectFloatField fieldB; //Field offset: 0x88
	public DebugUIHandlerIndirectFloatField fieldA; //Field offset: 0x90
	private ColorField m_Field; //Field offset: 0x98
	private DebugUIHandlerContainer m_Container; //Field offset: 0xA0

	public DebugUIHandlerColor() { }

	[CompilerGenerated]
	private float <SetupSettings>b__11_0() { }

	[CompilerGenerated]
	private float <SetupSettings>b__11_1() { }

	[CompilerGenerated]
	private float <SetupSettings>b__11_2() { }

	[CompilerGenerated]
	private float <SetWidget>b__9_0() { }

	[CompilerGenerated]
	private void <SetWidget>b__9_1(float x) { }

	[CompilerGenerated]
	private float <SetWidget>b__9_2() { }

	[CompilerGenerated]
	private void <SetWidget>b__9_3(float x) { }

	[CompilerGenerated]
	private float <SetWidget>b__9_4() { }

	[CompilerGenerated]
	private void <SetWidget>b__9_5(float x) { }

	[CompilerGenerated]
	private float <SetWidget>b__9_6() { }

	[CompilerGenerated]
	private void <SetWidget>b__9_7(float x) { }

	public virtual DebugUIHandlerWidget Next() { }

	public virtual void OnAction() { }

	public virtual void OnDecrement(bool fast) { }

	public virtual void OnDeselection() { }

	public virtual void OnIncrement(bool fast) { }

	public virtual bool OnSelection(bool fromNext, DebugUIHandlerWidget previous) { }

	private void SetupSettings(DebugUIHandlerIndirectFloatField field) { }

	private void SetValue(float x, bool r = false, bool g = false, bool b = false, bool a = false) { }

	internal virtual void SetWidget(Widget widget) { }

	internal void UpdateColor() { }

}

