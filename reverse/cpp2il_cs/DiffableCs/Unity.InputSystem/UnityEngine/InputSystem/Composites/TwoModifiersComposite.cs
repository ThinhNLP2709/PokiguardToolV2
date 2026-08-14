namespace UnityEngine.InputSystem.Composites;

[DisplayName("Binding With Two Modifiers")]
[DisplayStringFormat("{modifier1}+{modifier2}+{binding}")]
public class TwoModifiersComposite : InputBindingComposite
{
	internal enum ModifiersOrder
	{
		Default = 0,
		Ordered = 1,
		Unordered = 2,
	}

	[InputControl(layout = "Button")]
	public int modifier1; //Field offset: 0x10
	[InputControl(layout = "Button")]
	public int modifier2; //Field offset: 0x14
	[InputControl]
	public int binding; //Field offset: 0x18
	[Obsolete("Use ModifiersOrder.Unordered with 'modifiersOrder' instead")]
	[Tooltip("Obsolete please use modifiers Order. If enabled, this will override the Input Consumption setting, allowing the modifier keys to be pressed after the button and the composite will still trigger.")]
	public bool overrideModifiersNeedToBePressedFirst; //Field offset: 0x1C
	[Tooltip("By default it follows the Input Consumption setting to determine if the modifers keys need to be pressed first.")]
	public ModifiersOrder modifiersOrder; //Field offset: 0x20
	private int m_ValueSizeInBytes; //Field offset: 0x24
	private Type m_ValueType; //Field offset: 0x28
	private bool m_BindingIsButton; //Field offset: 0x30

	public virtual int valueSizeInBytes
	{
		 get { } //Length: 4
	}

	public virtual Type valueType
	{
		 get { } //Length: 5
	}

	public TwoModifiersComposite() { }

	public virtual float EvaluateMagnitude(ref InputBindingCompositeContext context) { }

	protected virtual void FinishSetup(ref InputBindingCompositeContext context) { }

	public virtual int get_valueSizeInBytes() { }

	public virtual Type get_valueType() { }

	private bool ModifiersArePressed(ref InputBindingCompositeContext context) { }

	public virtual void ReadValue(ref InputBindingCompositeContext context, Void* buffer, int bufferSize) { }

	public virtual object ReadValueAsObject(ref InputBindingCompositeContext context) { }

}

