namespace Unity.VisualScripting;

public class UnityObjectConverter : fsConverter
{

	private List<Object> objectReferences
	{
		private get { } //Length: 77
	}

	public UnityObjectConverter() { }

	public virtual bool CanProcess(Type type) { }

	public virtual object CreateInstance(fsData data, Type storageType) { }

	private List<Object> get_objectReferences() { }

	public virtual bool RequestCycleSupport(Type storageType) { }

	public virtual bool RequestInheritanceSupport(Type storageType) { }

	public virtual fsResult TryDeserialize(fsData storage, ref object instance, Type storageType) { }

	public virtual fsResult TrySerialize(object instance, out fsData serialized, Type storageType) { }

}

