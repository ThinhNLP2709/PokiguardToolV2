namespace UnityEngine.InputSystem.Composites;

[DisplayName("Up/Down/Left/Right Composite")]
[DisplayStringFormat("{up}/{left}/{down}/{right}")]
public class Vector2Composite : InputBindingComposite<Vector2>
{
	internal enum Mode
	{
		Analog = 2,
		DigitalNormalized = 0,
		Digital = 1,
	}

	[InputControl(layout = "Axis")]
	public int up; //Field offset: 0x10
	[InputControl(layout = "Axis")]
	public int down; //Field offset: 0x14
	[InputControl(layout = "Axis")]
	public int left; //Field offset: 0x18
	[InputControl(layout = "Axis")]
	public int right; //Field offset: 0x1C
	[Obsolete("Use Mode.DigitalNormalized with 'mode' instead")]
	public bool normalize; //Field offset: 0x20
	public Mode mode; //Field offset: 0x24

	public Vector2Composite() { }

	public virtual float EvaluateMagnitude(ref InputBindingCompositeContext context) { }

	public virtual Vector2 ReadValue(ref InputBindingCompositeContext context) { }

}

