namespace UnityEngine.AdaptivePerformance;

public class AdaptivePerformanceGeneralSettings : ScriptableObject
{
	public static string k_SettingsKey; //Field offset: 0x0
	internal static AdaptivePerformanceGeneralSettings s_RuntimeSettingsInstance; //Field offset: 0x8
	[SerializeField]
	internal AdaptivePerformanceManagerSettings m_LoaderManagerInstance; //Field offset: 0x18
	[SerializeField]
	[Tooltip("Enable this to automatically start up Adaptive Performance at runtime.")]
	internal bool m_InitManagerOnStart; //Field offset: 0x20
	private AdaptivePerformanceManagerSettings m_AdaptivePerformanceManager; //Field offset: 0x28
	private bool m_ProviderIntialized; //Field offset: 0x30
	private bool m_ProviderStarted; //Field offset: 0x31

	public AdaptivePerformanceManagerSettings AssignedSettings
	{
		 get { } //Length: 5
	}

	public bool InitManagerOnStart
	{
		 get { } //Length: 5
	}

	public static AdaptivePerformanceGeneralSettings Instance
	{
		 get { } //Length: 79
	}

	public bool IsProviderInitialized
	{
		 get { } //Length: 5
	}

	public bool IsProviderStarted
	{
		 get { } //Length: 5
	}

	public AdaptivePerformanceManagerSettings Manager
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	private static AdaptivePerformanceGeneralSettings() { }

	public AdaptivePerformanceGeneralSettings() { }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::AfterAssembliesLoaded (2))]
	internal static void AttemptInitializeAdaptivePerformanceOnLoad() { }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::BeforeSplashScreen (3))]
	internal static void AttemptStartAdaptivePerformanceOnBeforeSplashScreen() { }

	private void Awake() { }

	internal void DeInitAdaptivePerformance() { }

	public AdaptivePerformanceManagerSettings get_AssignedSettings() { }

	public bool get_InitManagerOnStart() { }

	public static AdaptivePerformanceGeneralSettings get_Instance() { }

	public bool get_IsProviderInitialized() { }

	public bool get_IsProviderStarted() { }

	public AdaptivePerformanceManagerSettings get_Manager() { }

	internal void InitAdaptivePerformance() { }

	private void OnDestroy() { }

	private static void Quit() { }

	public void set_Manager(AdaptivePerformanceManagerSettings value) { }

	internal void StartAdaptivePerformance() { }

	internal void StopAdaptivePerformance() { }

}

