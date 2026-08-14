namespace Unity.VisualScripting;

public interface ISerializationDependency : ISerializationCallbackReceiver
{

	internal bool IsDeserialized
	{
		internal get { } //Length: 0
		internal set { } //Length: 0
	}

	internal bool get_IsDeserialized() { }

	internal void set_IsDeserialized(bool value) { }

}

