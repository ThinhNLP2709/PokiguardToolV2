namespace Unity.VisualScripting.FullSerializer;

public class AnimationCurve_DirectConverter : fsDirectConverter<AnimationCurve>
{

	public AnimationCurve_DirectConverter() { }

	public virtual object CreateInstance(fsData data, Type storageType) { }

	protected virtual fsResult DoDeserialize(Dictionary<String, fsData> data, ref AnimationCurve model) { }

	protected virtual fsResult DoSerialize(AnimationCurve model, Dictionary<String, fsData> serialized) { }

}

