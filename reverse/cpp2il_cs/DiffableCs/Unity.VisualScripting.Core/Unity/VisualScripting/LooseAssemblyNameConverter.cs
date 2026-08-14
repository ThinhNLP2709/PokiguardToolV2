namespace Unity.VisualScripting;

public class LooseAssemblyNameConverter : fsDirectConverter
{

	public virtual Type ModelType
	{
		 get { } //Length: 77
	}

	public LooseAssemblyNameConverter() { }

	public virtual object CreateInstance(fsData data, Type storageType) { }

	public virtual Type get_ModelType() { }

	public virtual fsResult TryDeserialize(fsData data, ref object instance, Type storageType) { }

	public virtual fsResult TrySerialize(object instance, out fsData serialized, Type storageType) { }

}

