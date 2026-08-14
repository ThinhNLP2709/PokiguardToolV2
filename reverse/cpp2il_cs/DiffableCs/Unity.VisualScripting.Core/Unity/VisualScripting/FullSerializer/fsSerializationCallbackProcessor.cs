namespace Unity.VisualScripting.FullSerializer;

public class fsSerializationCallbackProcessor : fsObjectProcessor
{

	public fsSerializationCallbackProcessor() { }

	public virtual bool CanProcess(Type type) { }

	public virtual void OnAfterDeserialize(Type storageType, object instance) { }

	public virtual void OnAfterSerialize(Type storageType, object instance, ref fsData data) { }

	public virtual void OnBeforeDeserializeAfterInstanceCreation(Type storageType, object instance, ref fsData data) { }

	public virtual void OnBeforeSerialize(Type storageType, object instance) { }

}

