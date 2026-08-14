namespace UnityEngine.InputSystem.Processors;

public class InvertVector2Processor : InputProcessor<Vector2>
{
	public bool invertX; //Field offset: 0x10
	public bool invertY; //Field offset: 0x11

	public InvertVector2Processor() { }

	public virtual Vector2 Process(Vector2 value, InputControl control) { }

	public virtual string ToString() { }

}

