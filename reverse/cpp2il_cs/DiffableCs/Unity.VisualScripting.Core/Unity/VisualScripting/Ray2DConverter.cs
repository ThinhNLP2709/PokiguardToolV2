namespace Unity.VisualScripting;

public class Ray2DConverter : fsDirectConverter<Ray2D>
{

	public Ray2DConverter() { }

	public virtual object CreateInstance(fsData data, Type storageType) { }

	protected virtual fsResult DoDeserialize(Dictionary<String, fsData> data, ref Ray2D model) { }

	protected virtual fsResult DoSerialize(Ray2D model, Dictionary<String, fsData> serialized) { }

}

