namespace Unity.VisualScripting.FullSerializer;

public class fsDictionaryConverter : fsConverter
{

	public fsDictionaryConverter() { }

	private fsResult AddItemToDictionary(IDictionary dictionary, object key, object value) { }

	public virtual bool CanProcess(Type type) { }

	public virtual object CreateInstance(fsData data, Type storageType) { }

	private static void GetKeyValueTypes(Type dictionaryType, out Type keyStorageType, out Type valueStorageType) { }

	public virtual fsResult TryDeserialize(fsData data, ref object instance_, Type storageType) { }

	public virtual fsResult TrySerialize(object instance_, out fsData serialized, Type storageType) { }

}

