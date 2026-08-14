namespace UnityEngine.TextCore.Text;

public class FastAction
{
	private LinkedList<Action`2<A, B>> delegates; //Field offset: 0x0
	private Dictionary<Action`2<A, B>, LinkedListNode`1<Action`2<A, B>>> lookup; //Field offset: 0x0

	public FastAction`2() { }

	public void Call(A a, B b) { }

}

