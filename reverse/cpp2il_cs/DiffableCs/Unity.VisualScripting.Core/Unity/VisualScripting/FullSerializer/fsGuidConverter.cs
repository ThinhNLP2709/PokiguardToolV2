namespace Unity.VisualScripting.FullSerializer;

public class fsGuidConverter : fsConverter
{

	public fsGuidConverter() { }

	public virtual bool CanProcess(Type type) { }

	public virtual object CreateInstance(fsData data, Type storageType) { }

	public virtual bool RequestCycleSupport(Type storageType) { }

	public virtual bool RequestInheritanceSupport(Type storageType) { }

	public virtual fsResult TryDeserialize(fsData data, ref object instance, Type storageType) { }

	public virtual fsResult TrySerialize(object instance, out fsData serialized, Type storageType) { }

}

