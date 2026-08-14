namespace UnityEngine.AdaptivePerformance;

public class AdaptivePerformanceScalerProfile : AdaptivePerformanceScalerSettings
{
	[SerializeField]
	[Tooltip("Name of the scaler profile.")]
	private string m_Name; //Field offset: 0x90

	public string Name
	{
		 get { } //Length: 8
		 set { } //Length: 19
	}

	public AdaptivePerformanceScalerProfile() { }

	public string get_Name() { }

	public void set_Name(string value) { }

}

