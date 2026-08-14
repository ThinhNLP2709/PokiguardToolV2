namespace UnityEngine.Rendering;

[AttributeUsage(AttributeTargets::Field (256), Inherited = True)]
public abstract class ResourcePathsBaseAttribute : Attribute
{

	protected ResourcePathsBaseAttribute(String[] paths, bool isField, SearchType location) { }

}

