namespace UnityEngine.InputSystem.Processors;

public class NormalizeVector3Processor : InputProcessor<Vector3>
{

	public NormalizeVector3Processor() { }

	public virtual Vector3 Process(Vector3 value, InputControl control) { }

	public virtual string ToString() { }

}

