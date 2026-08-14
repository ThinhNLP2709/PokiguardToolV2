namespace Unity.VisualScripting.FullSerializer;

public class fsTypeConverter : fsConverter
{

	public fsTypeConverter() { }

	public virtual bool CanProcess(Type type) { }

	public virtual object CreateInstance(fsData data, Type storageType) { }

	public virtual bool RequestCycleSupport(Type type) { }

	public virtual bool RequestInheritanceSupport(Type type) { }

	public virtual fsResult TryDeserialize(fsData data, ref object instance, Type storageType) { }

	public virtual fsResult TrySerialize(object instance, out fsData serialized, Type storageType) { }

}

