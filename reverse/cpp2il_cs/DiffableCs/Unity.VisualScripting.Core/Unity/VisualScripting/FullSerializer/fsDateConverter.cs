namespace Unity.VisualScripting.FullSerializer;

public class fsDateConverter : fsConverter
{
	private const string DefaultDateTimeFormatString = "o"; //Field offset: 0x0
	private const string DateTimeOffsetFormatString = "o"; //Field offset: 0x0

	private string DateTimeFormatString
	{
		private get { } //Length: 84
	}

	public fsDateConverter() { }

	public virtual bool CanProcess(Type type) { }

	private string get_DateTimeFormatString() { }

	public virtual fsResult TryDeserialize(fsData data, ref object instance, Type storageType) { }

	public virtual fsResult TrySerialize(object instance, out fsData serialized, Type storageType) { }

}

