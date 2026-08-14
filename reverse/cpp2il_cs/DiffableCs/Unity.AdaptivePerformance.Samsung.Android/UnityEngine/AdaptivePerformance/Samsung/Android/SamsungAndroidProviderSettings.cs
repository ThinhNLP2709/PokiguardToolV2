namespace UnityEngine.AdaptivePerformance.Samsung.Android;

[AdaptivePerformanceConfigurationData("Samsung (Android)", "com.unity.adaptiveperformance.samsung.android.provider_settings")]
public class SamsungAndroidProviderSettings : IAdaptivePerformanceSettings
{
	public static SamsungAndroidProviderSettings s_RuntimeInstance; //Field offset: 0x0
	[SerializeField]
	[Tooltip("Enable Logging in Devmode")]
	private bool m_SamsungProviderLogging; //Field offset: 0x40
	[SerializeField]
	[Tooltip("Allow High-Speed Variable Refresh Rate. It is required if you want to use variable refresh rates higher than 60hz. Can increase device temperature when activated.")]
	private bool m_HighSpeedVRR; //Field offset: 0x41
	[SerializeField]
	[Tooltip("Enable Automatic Variable Refresh Rate. Only enabled if VRR is supported on the target device.")]
	private bool m_AutomaticVRR; //Field offset: 0x42

	public bool automaticVRR
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public bool highSpeedVRR
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public bool samsungProviderLogging
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public SamsungAndroidProviderSettings() { }

	private void Awake() { }

	public bool get_automaticVRR() { }

	public bool get_highSpeedVRR() { }

	public bool get_samsungProviderLogging() { }

	public static SamsungAndroidProviderSettings GetSettings() { }

	public void set_automaticVRR(bool value) { }

	public void set_highSpeedVRR(bool value) { }

	public void set_samsungProviderLogging(bool value) { }

}

