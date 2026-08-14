//Type is in global namespace

public class GetUserBasicInfo : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <FetchUserInfo>d__11 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public string username; //Field offset: 0x20
		public GetUserBasicInfo <>4__this; //Field offset: 0x28
		private UnityWebRequest <request>5__2; //Field offset: 0x30

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <FetchUserInfo>d__11(int <>1__state) { }

		private void <>m__Finally1() { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	internal class UserBasicInfo
	{
		public long id; //Field offset: 0x10
		public int petId; //Field offset: 0x18
		public int avtId; //Field offset: 0x1C
		public int energy; //Field offset: 0x20
		public int energyFull; //Field offset: 0x24
		public long gold; //Field offset: 0x28
		public int ruby; //Field offset: 0x30
		public long requestAttack; //Field offset: 0x38
		public string name; //Field offset: 0x40
		public int lever; //Field offset: 0x48
		public int exp; //Field offset: 0x4C
		public int expCurrent; //Field offset: 0x50
		public int wheel; //Field offset: 0x54
		public int starWhite; //Field offset: 0x58
		public int starBlue; //Field offset: 0x5C
		public int starRed; //Field offset: 0x60
		public int secondsUntilNextRegen; //Field offset: 0x64

		public UserBasicInfo() { }

	}

	private class UsernameRequest
	{
		public string username; //Field offset: 0x10

		public UsernameRequest() { }

	}

	[CompilerGenerated]
	private static GetUserBasicInfo <Instance>k__BackingField; //Field offset: 0x0
	private string API_URL; //Field offset: 0x20
	private string authToken; //Field offset: 0x28
	private Dictionary<String, Action`1<UserBasicInfo>> callbacks; //Field offset: 0x30

	public private static GetUserBasicInfo Instance
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	public GetUserBasicInfo() { }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::BeforeSceneLoad (1))]
	private static void AutoInitialize() { }

	private void Awake() { }

	[IteratorStateMachine(typeof(<FetchUserInfo>d__11))]
	private IEnumerator FetchUserInfo(string username) { }

	[CompilerGenerated]
	public static GetUserBasicInfo get_Instance() { }

	public void GetUserInfo(string username, Action<UserBasicInfo> onFetched) { }

	private void LogUserInfo(string username, UserBasicInfo info) { }

	[CompilerGenerated]
	private static void set_Instance(GetUserBasicInfo value) { }

	private void Start() { }

}

