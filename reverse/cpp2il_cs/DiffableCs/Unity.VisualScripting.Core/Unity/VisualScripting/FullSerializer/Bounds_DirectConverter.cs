namespace Unity.VisualScripting.FullSerializer;

public class Bounds_DirectConverter : fsDirectConverter<Bounds>
{

	public Bounds_DirectConverter() { }

	public virtual object CreateInstance(fsData data, Type storageType) { }

	protected virtual fsResult DoDeserialize(Dictionary<String, fsData> data, ref Bounds model) { }

	protected virtual fsResult DoSerialize(Bounds model, Dictionary<String, fsData> serialized) { }

}

