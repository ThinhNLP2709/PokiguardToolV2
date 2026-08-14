namespace Unity.Properties;

public interface IProperty
{

	public string Name
	{
		 get { } //Length: 0
	}

	public Type DeclaredValueType() { }

	public string get_Name() { }

}

