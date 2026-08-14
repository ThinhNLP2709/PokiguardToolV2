namespace WebSocketSharp.Server;

public abstract class WebSocketServiceHost
{
	private Logger _log; //Field offset: 0x10
	private string _path; //Field offset: 0x18
	private WebSocketSessionManager _sessions; //Field offset: 0x20

	public abstract Type BehaviorType
	{
		 get { } //Length: 0
	}

	public bool KeepClean
	{
		 get { } //Length: 38
		 set { } //Length: 30
	}

	protected Logger Log
	{
		 get { } //Length: 7
	}

	public string Path
	{
		 get { } //Length: 7
	}

	public WebSocketSessionManager Sessions
	{
		 get { } //Length: 7
	}

	internal ServerState State
	{
		internal get { } //Length: 36
	}

	public TimeSpan WaitTime
	{
		 get { } //Length: 27
		 set { } //Length: 30
	}

	protected WebSocketServiceHost(string path, Logger log) { }

	protected abstract WebSocketBehavior CreateSession() { }

	public abstract Type get_BehaviorType() { }

	public bool get_KeepClean() { }

	protected Logger get_Log() { }

	public string get_Path() { }

	public WebSocketSessionManager get_Sessions() { }

	internal ServerState get_State() { }

	public TimeSpan get_WaitTime() { }

	public void set_KeepClean(bool value) { }

	public void set_WaitTime(TimeSpan value) { }

	internal void Start() { }

	internal void StartSession(WebSocketContext context) { }

	internal void Stop(ushort code, string reason) { }

}

