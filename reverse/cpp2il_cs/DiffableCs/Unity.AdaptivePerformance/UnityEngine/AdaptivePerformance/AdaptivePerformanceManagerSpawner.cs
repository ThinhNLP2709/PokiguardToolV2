namespace UnityEngine.AdaptivePerformance;

internal class AdaptivePerformanceManagerSpawner : ScriptableObject
{
	public const string AdaptivePerformanceManagerObjectName = "AdaptivePerformanceManager"; //Field offset: 0x0
	private GameObject m_ManagerGameObject; //Field offset: 0x18

	public GameObject ManagerGameObject
	{
		 get { } //Length: 5
	}

	public AdaptivePerformanceManagerSpawner() { }

	public void Deinitialize() { }

	public GameObject get_ManagerGameObject() { }

	public void Initialize(bool isCheckingProvider) { }

	private void InstallScalers() { }

	private void OnEnable() { }

}

