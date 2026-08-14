namespace Unity.VisualScripting.FullSerializer;

public class fsPrimitiveConverter : fsConverter
{

	public fsPrimitiveConverter() { }

	public virtual bool CanProcess(Type type) { }

	public virtual bool RequestCycleSupport(Type storageType) { }

	public virtual bool RequestInheritanceSupport(Type storageType) { }

	public virtual fsResult TryDeserialize(fsData storage, ref object instance, Type storageType) { }

	public virtual fsResult TrySerialize(object instance, out fsData serialized, Type storageType) { }

	private static bool UseBool(Type type) { }

	private static bool UseDouble(Type type) { }

	private static bool UseInt64(Type type) { }

	private static bool UseString(Type type) { }

}

