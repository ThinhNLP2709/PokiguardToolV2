namespace UnityEngine;

[AttributeUsage(384, Inherited = True, AllowMultiple = False)]
public sealed class TextAreaAttribute : PropertyAttribute
{
	public readonly int minLines; //Field offset: 0x18
	public readonly int maxLines; //Field offset: 0x1C

	public TextAreaAttribute(int minLines, int maxLines) { }

}

