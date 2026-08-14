namespace UnityEngine.InputSystem.Processors;

public class NormalizeVector2Processor : InputProcessor<Vector2>
{

	public NormalizeVector2Processor() { }

	public virtual Vector2 Process(Vector2 value, InputControl control) { }

	public virtual string ToString() { }

}

