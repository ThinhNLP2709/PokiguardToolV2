namespace Unity.VisualScripting.FullSerializer;

public class fsForwardConverter : fsConverter
{
	private string _memberName; //Field offset: 0x18

	public fsForwardConverter(fsForwardAttribute attribute) { }

	public virtual bool CanProcess(Type type) { }

	public virtual object CreateInstance(fsData data, Type storageType) { }

	private fsResult GetProperty(object instance, out fsMetaProperty property) { }

	public virtual fsResult TryDeserialize(fsData data, ref object instance, Type storageType) { }

	public virtual fsResult TrySerialize(object instance, out fsData serialized, Type storageType) { }

}

