namespace Unity.VisualScripting.FullSerializer;

public interface fsISerializationCallbacks
{

	public void OnAfterDeserialize(Type storageType) { }

	public void OnAfterSerialize(Type storageType, ref fsData data) { }

	public void OnBeforeDeserialize(Type storageType, ref fsData data) { }

	public void OnBeforeSerialize(Type storageType) { }

}

