namespace Unity.VisualScripting;

public interface IGraphWithVariables : IGraph, IDisposable, IPrewarmable, IAotStubbable, ISerializationDepender, ISerializationCallbackReceiver
{

	public VariableDeclarations variables
	{
		 get { } //Length: 0
	}

	public VariableDeclarations get_variables() { }

	public IEnumerable<String> GetDynamicVariableNames(VariableKind kind, GraphReference reference) { }

}

