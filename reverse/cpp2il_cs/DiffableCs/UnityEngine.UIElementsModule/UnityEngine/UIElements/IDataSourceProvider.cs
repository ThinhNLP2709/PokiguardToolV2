namespace UnityEngine.UIElements;

public interface IDataSourceProvider
{

	public object dataSource
	{
		 get { } //Length: 0
	}

	public PropertyPath dataSourcePath
	{
		 get { } //Length: 0
	}

	public object get_dataSource() { }

	public PropertyPath get_dataSourcePath() { }

}

