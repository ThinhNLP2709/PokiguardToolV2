//Type is in global namespace

public class BoardWsRunner : MonoBehaviour
{
	private static BoardWsRunner _instance; //Field offset: 0x0

	public static BoardWsRunner Instance
	{
		 get { } //Length: 288
	}

	public BoardWsRunner() { }

	public static BoardWsRunner get_Instance() { }

	public Coroutine Run(IEnumerator co) { }

	public void Stop(Coroutine co) { }

}

