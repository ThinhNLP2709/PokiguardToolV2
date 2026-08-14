namespace Unity.VisualScripting;

public interface IGraphDataWithVariables : IGraphData
{

	public VariableDeclarations variables
	{
		 get { } //Length: 0
	}

	public VariableDeclarations get_variables() { }

}

