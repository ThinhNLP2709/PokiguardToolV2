namespace Unity.VisualScripting;

public interface ISerializationDepender : ISerializationCallbackReceiver
{

	public IEnumerable<ISerializationDependency> deserializationDependencies
	{
		 get { } //Length: 0
	}

	public IEnumerable<ISerializationDependency> get_deserializationDependencies() { }

	public void OnAfterDependenciesDeserialized() { }

}

