namespace UnityEngine.InputSystem.Processors;

public class ClampProcessor : InputProcessor<Single>
{
	public float min; //Field offset: 0x10
	public float max; //Field offset: 0x14

	public ClampProcessor() { }

	public virtual float Process(float value, InputControl control) { }

	public virtual string ToString() { }

}

