namespace Unity.VisualScripting.FullSerializer;

public class fsIEnumerableConverter : fsConverter
{

	public fsIEnumerableConverter() { }

	public virtual bool CanProcess(Type type) { }

	public virtual object CreateInstance(fsData data, Type storageType) { }

	private static MethodInfo GetAddMethod(Type type) { }

	private static Type GetElementType(Type objectType) { }

	private static int HintSize(IEnumerable collection) { }

	private bool IsStack(Type type) { }

	private static void TryClear(Type type, object instance) { }

	public virtual fsResult TryDeserialize(fsData data, ref object instance_, Type storageType) { }

	private static int TryGetExistingSize(Type type, object instance) { }

	public virtual fsResult TrySerialize(object instance_, out fsData serialized, Type storageType) { }

}

