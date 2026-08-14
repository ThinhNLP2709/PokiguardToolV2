namespace Unity.VisualScripting.FullSerializer;

public class Rect_DirectConverter : fsDirectConverter<Rect>
{

	public Rect_DirectConverter() { }

	public virtual object CreateInstance(fsData data, Type storageType) { }

	protected virtual fsResult DoDeserialize(Dictionary<String, fsData> data, ref Rect model) { }

	protected virtual fsResult DoSerialize(Rect model, Dictionary<String, fsData> serialized) { }

}

