namespace Unity.VisualScripting.FullSerializer;

public class GUIStyleState_DirectConverter : fsDirectConverter<GUIStyleState>
{

	public GUIStyleState_DirectConverter() { }

	public virtual object CreateInstance(fsData data, Type storageType) { }

	protected virtual fsResult DoDeserialize(Dictionary<String, fsData> data, ref GUIStyleState model) { }

	protected virtual fsResult DoSerialize(GUIStyleState model, Dictionary<String, fsData> serialized) { }

}

