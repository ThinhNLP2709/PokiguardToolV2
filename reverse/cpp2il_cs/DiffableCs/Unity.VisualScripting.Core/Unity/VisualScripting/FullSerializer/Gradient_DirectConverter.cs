namespace Unity.VisualScripting.FullSerializer;

public class Gradient_DirectConverter : fsDirectConverter<Gradient>
{

	public Gradient_DirectConverter() { }

	public virtual object CreateInstance(fsData data, Type storageType) { }

	protected virtual fsResult DoDeserialize(Dictionary<String, fsData> data, ref Gradient model) { }

	protected virtual fsResult DoSerialize(Gradient model, Dictionary<String, fsData> serialized) { }

	private static void LogWarning(string phase) { }

}

