namespace UnityEngine.Rendering.UI;

public class DebugUIHandlerIndirectToggle : DebugUIHandlerWidget
{
	public Text nameLabel; //Field offset: 0x60
	public Toggle valueToggle; //Field offset: 0x68
	public Image checkmarkImage; //Field offset: 0x70
	public Func<Int32, Boolean> getter; //Field offset: 0x78
	public Action<Int32, Boolean> setter; //Field offset: 0x80
	internal int index; //Field offset: 0x88

	public DebugUIHandlerIndirectToggle() { }

	public void Init() { }

	public virtual void OnAction() { }

	public virtual void OnDeselection() { }

	public virtual bool OnSelection(bool fromNext, DebugUIHandlerWidget previous) { }

	private void OnToggleValueChanged(bool value) { }

	internal void UpdateValueLabel() { }

}

