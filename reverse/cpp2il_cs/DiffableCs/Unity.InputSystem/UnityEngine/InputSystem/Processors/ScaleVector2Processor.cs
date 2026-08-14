namespace UnityEngine.InputSystem.Processors;

public class ScaleVector2Processor : InputProcessor<Vector2>
{
	[Tooltip("Scale factor to multiply the incoming Vector2's X component by.")]
	public float x; //Field offset: 0x10
	[Tooltip("Scale factor to multiply the incoming Vector2's Y component by.")]
	public float y; //Field offset: 0x14

	public ScaleVector2Processor() { }

	public virtual Vector2 Process(Vector2 value, InputControl control) { }

	public virtual string ToString() { }

}

