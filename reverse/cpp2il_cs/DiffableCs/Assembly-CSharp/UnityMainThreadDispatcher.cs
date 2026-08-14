//Type is in global namespace

public class UnityMainThreadDispatcher : MonoBehaviour
{
	private static UnityMainThreadDispatcher _instance; //Field offset: 0x0
	private const double FRAME_BUDGET_MS = 4; //Field offset: 0x0
	private const int MIN_ACTIONS_PER_FRAME = 4; //Field offset: 0x0
	private static Queue<Action> _executionQueue; //Field offset: 0x8
	private readonly List<Action> _drainBuffer; //Field offset: 0x20
	private readonly Stopwatch _drainWatch; //Field offset: 0x28

	private static UnityMainThreadDispatcher() { }

	public UnityMainThreadDispatcher() { }

	public void Enqueue(Action action) { }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::BeforeSceneLoad (1))]
	private static void EnsureCreatedOnMainThread() { }

	public static UnityMainThreadDispatcher Instance() { }

	public static bool TryEnqueue(Action action) { }

	private void Update() { }

}

