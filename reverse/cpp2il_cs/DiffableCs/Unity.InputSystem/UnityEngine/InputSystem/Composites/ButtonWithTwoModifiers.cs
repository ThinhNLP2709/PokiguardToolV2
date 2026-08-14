namespace UnityEngine.InputSystem.Composites;

[DesignTimeVisible(False)]
[DisplayStringFormat("{modifier1}+{modifier2}+{button}")]
public class ButtonWithTwoModifiers : InputBindingComposite<Single>
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
	[InputControl(layout = "Button")]
	public int button; //Field offset: 0x18
	[Obsolete("Use ModifiersOrder.Unordered with 'modifiersOrder' instead")]
	[Tooltip("Obsolete please use modifiers Order. If enabled, this will override the Input Consumption setting, allowing the modifier keys to be pressed after the button and the composite will still trigger.")]
	public bool overrideModifiersNeedToBePressedFirst; //Field offset: 0x1C
	[Tooltip("By default it follows the Input Consumption setting to determine if the modifers keys need to be pressed first.")]
	public ModifiersOrder modifiersOrder; //Field offset: 0x20

	public ButtonWithTwoModifiers() { }

	public virtual float EvaluateMagnitude(ref InputBindingCompositeContext context) { }

	protected virtual void FinishSetup(ref InputBindingCompositeContext context) { }

	private bool ModifiersArePressed(ref InputBindingCompositeContext context) { }

	public virtual float ReadValue(ref InputBindingCompositeContext context) { }

}

