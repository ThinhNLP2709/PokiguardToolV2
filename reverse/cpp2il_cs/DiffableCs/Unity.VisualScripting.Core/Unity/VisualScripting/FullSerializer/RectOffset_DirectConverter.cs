namespace Unity.VisualScripting.FullSerializer;

public class RectOffset_DirectConverter : fsDirectConverter<RectOffset>
{

	public RectOffset_DirectConverter() { }

	public virtual object CreateInstance(fsData data, Type storageType) { }

	protected virtual fsResult DoDeserialize(Dictionary<String, fsData> data, ref RectOffset model) { }

	protected virtual fsResult DoSerialize(RectOffset model, Dictionary<String, fsData> serialized) { }

}

