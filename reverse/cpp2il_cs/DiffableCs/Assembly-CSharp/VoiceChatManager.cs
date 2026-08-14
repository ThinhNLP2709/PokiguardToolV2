//Type is in global namespace

[DisallowMultipleComponent]
public class VoiceChatManager : MonoBehaviour
{
	[CompilerGenerated]
	private static VoiceChatManager <Instance>k__BackingField; //Field offset: 0x0
	[HideInInspector]
	public bool debugEchoMode; //Field offset: 0x20
	[HideInInspector]
	public bool debugLogMicLevel; //Field offset: 0x21
	[HideInInspector]
	[Range(0, 1)]
	public float debugMicLevelThreshold; //Field offset: 0x24
	[HideInInspector]
	public bool debugLogRemoteSpeaking; //Field offset: 0x28
	[CompilerGenerated]
	private bool <IsMicOn>k__BackingField; //Field offset: 0x29
	[CompilerGenerated]
	private bool <IsSpeakerOn>k__BackingField; //Field offset: 0x2A
	[CompilerGenerated]
	private Action<Boolean> OnMicChanged; //Field offset: 0x30
	[CompilerGenerated]
	private Action<Boolean> OnSpeakerChanged; //Field offset: 0x38
	[CompilerGenerated]
	private Action<Int32, Boolean> OnRemotePlayerSpeaking; //Field offset: 0x40

	public event Action<Boolean> OnMicChanged
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public event Action<Int32, Boolean> OnRemotePlayerSpeaking
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public event Action<Boolean> OnSpeakerChanged
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public private static VoiceChatManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	public private bool IsMicOn
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public private bool IsSpeakerOn
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 170
	}

	public bool IsVoiceActive
	{
		 get { } //Length: 3
	}

	public VoiceChatManager() { }

	[CompilerGenerated]
	public void add_OnMicChanged(Action<Boolean> value) { }

	[CompilerGenerated]
	public void add_OnRemotePlayerSpeaking(Action<Int32, Boolean> value) { }

	[CompilerGenerated]
	public void add_OnSpeakerChanged(Action<Boolean> value) { }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::BeforeSceneLoad (1))]
	private static void AutoCreate() { }

	private void Awake() { }

	public void EnsureVoiceReady() { }

	[CompilerGenerated]
	public static VoiceChatManager get_Instance() { }

	[CompilerGenerated]
	public bool get_IsMicOn() { }

	[CompilerGenerated]
	public bool get_IsSpeakerOn() { }

	public bool get_IsVoiceActive() { }

	private void OnDestroy() { }

	private void OnValidate() { }

	public void RefreshRemoteSpeakers() { }

	[CompilerGenerated]
	public void remove_OnMicChanged(Action<Boolean> value) { }

	[CompilerGenerated]
	public void remove_OnRemotePlayerSpeaking(Action<Int32, Boolean> value) { }

	[CompilerGenerated]
	public void remove_OnSpeakerChanged(Action<Boolean> value) { }

	[CompilerGenerated]
	private static void set_Instance(VoiceChatManager value) { }

	[CompilerGenerated]
	private void set_IsMicOn(bool value) { }

	[CompilerGenerated]
	private void set_IsSpeakerOn(bool value) { }

	public void SetMic(bool on) { }

	public void SetSpeaker(bool on) { }

	public void ToggleMic() { }

	public void ToggleSpeaker() { }

}

