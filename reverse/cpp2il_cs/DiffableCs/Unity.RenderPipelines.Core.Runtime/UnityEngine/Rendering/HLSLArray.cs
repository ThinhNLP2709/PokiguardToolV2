namespace UnityEngine.Rendering;

[AttributeUsage(AttributeTargets::Field (256))]
public class HLSLArray : Attribute
{
	public int arraySize; //Field offset: 0x10
	public Type elementType; //Field offset: 0x18

	public HLSLArray(int arraySize, Type elementType) { }

}

