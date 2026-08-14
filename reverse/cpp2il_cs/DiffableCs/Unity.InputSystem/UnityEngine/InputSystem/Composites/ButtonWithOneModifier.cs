namespace UnityEngine.InputSystem.Composites;

[DesignTimeVisible(False)]
[DisplayStringFormat("{modifier}+{button}")]
public class ButtonWithOneModifier : InputBindingComposite<Single>
{
	internal enum ModifiersOrder
	{
		Default = 0,
		Ordered = 1,
		Unordered = 2,
	}

	[InputControl(layout = "Button")]
	public int modifier; //Field offset: 0x10
	[InputControl(layout = "Button")]
	public int button; //Field offset: 0x14
	[Obsolete("Use ModifiersOrder.Unordered with 'modifiersOrder' instead")]
	[Tooltip("Obsolete please use modifiers Order. If enabled, this will override the Input Consumption setting, allowing the modifier keys to be pressed after the button and the composite will still trigger.")]
	public bool overrideModifiersNeedToBePressedFirst; //Field offset: 0x18
	[Tooltip("By default it follows the Input Consumption setting to determine if the modifers keys need to be pressed first.")]
	public ModifiersOrder modifiersOrder; //Field offset: 0x1C

	public ButtonWithOneModifier() { }

	public virtual float EvaluateMagnitude(ref InputBindingCompositeContext context) { }

	protected virtual void FinishSetup(ref InputBindingCompositeContext context) { }

	private bool ModifierIsPressed(ref InputBindingCompositeContext context) { }

	public virtual float ReadValue(ref InputBindingCompositeContext context) { }

}

