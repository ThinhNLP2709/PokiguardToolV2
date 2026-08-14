namespace Unity.VisualScripting.FullSerializer;

public abstract class fsObjectProcessor
{

	protected fsObjectProcessor() { }

	public override bool CanProcess(Type type) { }

	public override void OnAfterDeserialize(Type storageType, object instance) { }

	public override void OnAfterSerialize(Type storageType, object instance, ref fsData data) { }

	public override void OnBeforeDeserialize(Type storageType, ref fsData data) { }

	public override void OnBeforeDeserializeAfterInstanceCreation(Type storageType, object instance, ref fsData data) { }

	public override void OnBeforeSerialize(Type storageType, object instance) { }

}

