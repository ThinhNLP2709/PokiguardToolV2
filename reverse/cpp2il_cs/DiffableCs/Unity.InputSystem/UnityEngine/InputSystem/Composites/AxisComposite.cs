namespace UnityEngine.InputSystem.Composites;

[DisplayName("Positive/Negative Binding")]
[DisplayStringFormat("{negative}/{positive}")]
public class AxisComposite : InputBindingComposite<Single>
{
	internal enum WhichSideWins
	{
		Neither = 0,
		Positive = 1,
		Negative = 2,
	}

	[InputControl(layout = "Axis")]
	public int negative; //Field offset: 0x10
	[InputControl(layout = "Axis")]
	public int positive; //Field offset: 0x14
	[Tooltip("Value to return when the negative side is fully actuated.")]
	public float minValue; //Field offset: 0x18
	[Tooltip("Value to return when the positive side is fully actuated.")]
	public float maxValue; //Field offset: 0x1C
	[Tooltip("If both the positive and negative side are actuated, decides what value to return. 'Neither' (default) means that the resulting value is the midpoint between min and max. 'Positive' means that max will be returned. 'Negative' means that min will be returned.")]
	public WhichSideWins whichSideWins; //Field offset: 0x20

	public float midPoint
	{
		 get { } //Length: 19
	}

	public AxisComposite() { }

	public virtual float EvaluateMagnitude(ref InputBindingCompositeContext context) { }

	public float get_midPoint() { }

	public virtual float ReadValue(ref InputBindingCompositeContext context) { }

}

