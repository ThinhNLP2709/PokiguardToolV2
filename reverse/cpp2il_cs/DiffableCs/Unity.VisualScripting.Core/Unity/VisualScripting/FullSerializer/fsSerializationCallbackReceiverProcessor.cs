namespace Unity.VisualScripting.FullSerializer;

public class fsSerializationCallbackReceiverProcessor : fsObjectProcessor
{

	public fsSerializationCallbackReceiverProcessor() { }

	public virtual bool CanProcess(Type type) { }

	public virtual void OnAfterDeserialize(Type storageType, object instance) { }

	public virtual void OnBeforeSerialize(Type storageType, object instance) { }

}

