namespace Unity.VisualScripting;

public class NamespaceConverter : fsDirectConverter
{

	public virtual Type ModelType
	{
		 get { } //Length: 77
	}

	public NamespaceConverter() { }

	public virtual object CreateInstance(fsData data, Type storageType) { }

	public virtual Type get_ModelType() { }

	public virtual fsResult TryDeserialize(fsData data, ref object instance, Type storageType) { }

	public virtual fsResult TrySerialize(object instance, out fsData serialized, Type storageType) { }

}

