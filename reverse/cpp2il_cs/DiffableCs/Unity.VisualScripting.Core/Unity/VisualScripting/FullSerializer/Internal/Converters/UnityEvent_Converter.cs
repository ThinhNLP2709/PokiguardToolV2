namespace Unity.VisualScripting.FullSerializer.Internal.Converters;

public class UnityEvent_Converter : fsConverter
{

	public UnityEvent_Converter() { }

	public virtual bool CanProcess(Type type) { }

	public virtual bool RequestCycleSupport(Type storageType) { }

	public virtual fsResult TryDeserialize(fsData data, ref object instance, Type storageType) { }

	public virtual fsResult TrySerialize(object instance, out fsData serialized, Type storageType) { }

}

