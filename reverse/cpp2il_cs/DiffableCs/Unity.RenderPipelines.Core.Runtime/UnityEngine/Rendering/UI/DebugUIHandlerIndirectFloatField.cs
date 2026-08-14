namespace UnityEngine.Rendering.UI;

public class DebugUIHandlerIndirectFloatField : DebugUIHandlerWidget
{
	public Text nameLabel; //Field offset: 0x60
	public Text valueLabel; //Field offset: 0x68
	public Func<Single> getter; //Field offset: 0x70
	public Action<Single> setter; //Field offset: 0x78
	public Func<Single> incStepGetter; //Field offset: 0x80
	public Func<Single> incStepMultGetter; //Field offset: 0x88
	public Func<Single> decimalsGetter; //Field offset: 0x90

	public DebugUIHandlerIndirectFloatField() { }

	private void ChangeValue(bool fast, float multiplier) { }

	public void Init() { }

	public virtual void OnDecrement(bool fast) { }

	public virtual void OnDeselection() { }

	public virtual void OnIncrement(bool fast) { }

	public virtual bool OnSelection(bool fromNext, DebugUIHandlerWidget previous) { }

	private void UpdateValueLabel() { }

}

