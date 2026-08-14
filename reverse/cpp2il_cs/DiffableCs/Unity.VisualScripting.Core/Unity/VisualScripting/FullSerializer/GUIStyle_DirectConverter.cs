namespace Unity.VisualScripting.FullSerializer;

public class GUIStyle_DirectConverter : fsDirectConverter<GUIStyle>
{

	public GUIStyle_DirectConverter() { }

	public virtual object CreateInstance(fsData data, Type storageType) { }

	protected virtual fsResult DoDeserialize(Dictionary<String, fsData> data, ref GUIStyle model) { }

	protected virtual fsResult DoSerialize(GUIStyle model, Dictionary<String, fsData> serialized) { }

}

