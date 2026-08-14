namespace Unity.VisualScripting.FullSerializer;

public abstract class fsDirectConverter : fsDirectConverter
{

	public virtual Type ModelType
	{
		 get { } //Length: 56
	}

	protected fsDirectConverter`1() { }

	protected abstract fsResult DoDeserialize(Dictionary<String, fsData> data, ref TModel model) { }

	protected abstract fsResult DoSerialize(TModel model, Dictionary<String, fsData> serialized) { }

	public virtual Type get_ModelType() { }

	public virtual fsResult TryDeserialize(fsData data, ref object instance, Type storageType) { }

	public virtual fsResult TrySerialize(object instance, out fsData serialized, Type storageType) { }

}

