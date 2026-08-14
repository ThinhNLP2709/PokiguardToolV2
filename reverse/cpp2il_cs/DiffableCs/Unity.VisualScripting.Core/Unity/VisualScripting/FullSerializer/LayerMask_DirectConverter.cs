namespace Unity.VisualScripting.FullSerializer;

public class LayerMask_DirectConverter : fsDirectConverter<LayerMask>
{

	public LayerMask_DirectConverter() { }

	public virtual object CreateInstance(fsData data, Type storageType) { }

	protected virtual fsResult DoDeserialize(Dictionary<String, fsData> data, ref LayerMask model) { }

	protected virtual fsResult DoSerialize(LayerMask model, Dictionary<String, fsData> serialized) { }

}

