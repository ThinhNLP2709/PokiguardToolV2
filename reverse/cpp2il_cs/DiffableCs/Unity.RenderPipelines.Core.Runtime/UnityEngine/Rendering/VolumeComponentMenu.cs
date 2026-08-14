namespace UnityEngine.Rendering;

[AttributeUsage(AttributeTargets::Class (4), AllowMultiple = False)]
public class VolumeComponentMenu : Attribute
{
	public readonly string menu; //Field offset: 0x10

	public VolumeComponentMenu(string menu) { }

}

