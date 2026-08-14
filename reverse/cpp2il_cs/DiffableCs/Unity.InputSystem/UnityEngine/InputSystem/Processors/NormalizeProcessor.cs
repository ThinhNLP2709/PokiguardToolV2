namespace UnityEngine.InputSystem.Processors;

public class NormalizeProcessor : InputProcessor<Single>
{
	public float min; //Field offset: 0x10
	public float max; //Field offset: 0x14
	public float zero; //Field offset: 0x18

	public NormalizeProcessor() { }

	internal static float Denormalize(float value, float min, float max, float zero) { }

	public static float Normalize(float value, float min, float max, float zero) { }

	public virtual float Process(float value, InputControl control) { }

	public virtual string ToString() { }

}

