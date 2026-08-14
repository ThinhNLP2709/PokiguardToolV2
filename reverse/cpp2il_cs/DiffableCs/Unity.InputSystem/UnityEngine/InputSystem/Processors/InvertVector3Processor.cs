namespace UnityEngine.InputSystem.Processors;

public class InvertVector3Processor : InputProcessor<Vector3>
{
	public bool invertX; //Field offset: 0x10
	public bool invertY; //Field offset: 0x11
	public bool invertZ; //Field offset: 0x12

	public InvertVector3Processor() { }

	public virtual Vector3 Process(Vector3 value, InputControl control) { }

	public virtual string ToString() { }

}

