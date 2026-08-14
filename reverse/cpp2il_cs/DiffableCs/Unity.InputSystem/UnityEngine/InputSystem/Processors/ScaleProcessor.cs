namespace UnityEngine.InputSystem.Processors;

public class ScaleProcessor : InputProcessor<Single>
{
	[Tooltip("Scale factor to multiply incoming float values by.")]
	public float factor; //Field offset: 0x10

	public ScaleProcessor() { }

	public virtual float Process(float value, InputControl control) { }

	public virtual string ToString() { }

}

