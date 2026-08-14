namespace Unity.VisualScripting;

public class RayConverter : fsDirectConverter<Ray>
{

	public RayConverter() { }

	public virtual object CreateInstance(fsData data, Type storageType) { }

	protected virtual fsResult DoDeserialize(Dictionary<String, fsData> data, ref Ray model) { }

	protected virtual fsResult DoSerialize(Ray model, Dictionary<String, fsData> serialized) { }

}

