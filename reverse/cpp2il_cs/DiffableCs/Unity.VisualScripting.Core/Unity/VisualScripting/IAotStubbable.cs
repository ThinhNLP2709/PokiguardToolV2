namespace Unity.VisualScripting;

public interface IAotStubbable
{

	public IEnumerable<Object> GetAotStubs(HashSet<Object> visited) { }

}

