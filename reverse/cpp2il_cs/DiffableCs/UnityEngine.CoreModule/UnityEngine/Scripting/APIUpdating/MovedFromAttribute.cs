namespace UnityEngine.Scripting.APIUpdating;

[AttributeUsage(5148)]
public class MovedFromAttribute : Attribute
{
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal MovedFromAttributeData data; //Field offset: 0x10

	public MovedFromAttribute(bool autoUpdateAPI, string sourceNamespace = null, string sourceAssembly = null, string sourceClassName = null) { }

	public MovedFromAttribute(string sourceNamespace) { }

}

