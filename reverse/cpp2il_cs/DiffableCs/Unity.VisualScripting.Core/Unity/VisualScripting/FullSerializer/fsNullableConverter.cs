namespace Unity.VisualScripting.FullSerializer;

public class fsNullableConverter : fsConverter
{

	public fsNullableConverter() { }

	public virtual bool CanProcess(Type type) { }

	public virtual object CreateInstance(fsData data, Type storageType) { }

	public virtual fsResult TryDeserialize(fsData data, ref object instance, Type storageType) { }

	public virtual fsResult TrySerialize(object instance, out fsData serialized, Type storageType) { }

}

