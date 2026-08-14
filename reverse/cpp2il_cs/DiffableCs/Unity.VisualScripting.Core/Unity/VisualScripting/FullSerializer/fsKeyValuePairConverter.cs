namespace Unity.VisualScripting.FullSerializer;

public class fsKeyValuePairConverter : fsConverter
{

	public fsKeyValuePairConverter() { }

	public virtual bool CanProcess(Type type) { }

	public virtual bool RequestCycleSupport(Type storageType) { }

	public virtual bool RequestInheritanceSupport(Type storageType) { }

	public virtual fsResult TryDeserialize(fsData data, ref object instance, Type storageType) { }

	public virtual fsResult TrySerialize(object instance, out fsData serialized, Type storageType) { }

}

