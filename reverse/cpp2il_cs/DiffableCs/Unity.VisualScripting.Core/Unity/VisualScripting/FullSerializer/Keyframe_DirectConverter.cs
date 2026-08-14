namespace Unity.VisualScripting.FullSerializer;

public class Keyframe_DirectConverter : fsDirectConverter<Keyframe>
{

	public Keyframe_DirectConverter() { }

	public virtual object CreateInstance(fsData data, Type storageType) { }

	protected virtual fsResult DoDeserialize(Dictionary<String, fsData> data, ref Keyframe model) { }

	protected virtual fsResult DoSerialize(Keyframe model, Dictionary<String, fsData> serialized) { }

}

