namespace Unity.VisualScripting;

public sealed class FieldsCloner : ReflectedCloner
{

	public FieldsCloner() { }

	protected virtual bool IncludeField(FieldInfo field) { }

	protected virtual bool IncludeProperty(PropertyInfo property) { }

}

