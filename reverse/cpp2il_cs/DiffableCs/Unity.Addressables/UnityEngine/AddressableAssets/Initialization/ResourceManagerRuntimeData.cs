namespace UnityEngine.AddressableAssets.Initialization;

public class ResourceManagerRuntimeData
{
	public const string kCatalogAddress = "AddressablesMainContentCatalog"; //Field offset: 0x0
	[SerializeField]
	private string m_buildTarget; //Field offset: 0x10
	[FormerlySerializedAs("m_settingsHash")]
	[SerializeField]
	private string m_SettingsHash; //Field offset: 0x18
	[FormerlySerializedAs("m_catalogLocations")]
	[SerializeField]
	private List<ResourceLocationData> m_CatalogLocations; //Field offset: 0x20
	[FormerlySerializedAs("m_logResourceManagerExceptions")]
	[SerializeField]
	private bool m_LogResourceManagerExceptions; //Field offset: 0x28
	[FormerlySerializedAs("m_extraInitializationData")]
	[SerializeField]
	private List<ObjectInitializationData> m_ExtraInitializationData; //Field offset: 0x30
	[SerializeField]
	private bool m_DisableCatalogUpdateOnStart; //Field offset: 0x38
	[SerializeField]
	private bool m_IsLocalCatalogInBundle; //Field offset: 0x39
	[SerializeField]
	private SerializedType m_CertificateHandlerType; //Field offset: 0x40
	[SerializeField]
	private string m_AddressablesVersion; //Field offset: 0x60
	[SerializeField]
	private int m_maxConcurrentWebRequests; //Field offset: 0x68
	[SerializeField]
	private int m_CatalogRequestsTimeout; //Field offset: 0x6C

	public string AddressablesVersion
	{
		 get { } //Length: 694
		 set { } //Length: 13
	}

	public string BuildTarget
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public List<ResourceLocationData> CatalogLocations
	{
		 get { } //Length: 5
	}

	public int CatalogRequestsTimeout
	{
		 get { } //Length: 4
		 set { } //Length: 29
	}

	public Type CertificateHandlerType
	{
		 get { } //Length: 11
		 set { } //Length: 12
	}

	public bool DisableCatalogUpdateOnStartup
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public List<ObjectInitializationData> InitializationObjects
	{
		 get { } //Length: 5
	}

	public bool IsLocalCatalogInBundle
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public bool LogResourceManagerExceptions
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public int MaxConcurrentWebRequests
	{
		 get { } //Length: 4
		 set { } //Length: 33
	}

	public string SettingsHash
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public ResourceManagerRuntimeData() { }

	public string get_AddressablesVersion() { }

	public string get_BuildTarget() { }

	public List<ResourceLocationData> get_CatalogLocations() { }

	public int get_CatalogRequestsTimeout() { }

	public Type get_CertificateHandlerType() { }

	public bool get_DisableCatalogUpdateOnStartup() { }

	public List<ObjectInitializationData> get_InitializationObjects() { }

	public bool get_IsLocalCatalogInBundle() { }

	public bool get_LogResourceManagerExceptions() { }

	public int get_MaxConcurrentWebRequests() { }

	public string get_SettingsHash() { }

	public void set_AddressablesVersion(string value) { }

	public void set_BuildTarget(string value) { }

	public void set_CatalogRequestsTimeout(int value) { }

	public void set_CertificateHandlerType(Type value) { }

	public void set_DisableCatalogUpdateOnStartup(bool value) { }

	public void set_IsLocalCatalogInBundle(bool value) { }

	public void set_LogResourceManagerExceptions(bool value) { }

	public void set_MaxConcurrentWebRequests(int value) { }

	public void set_SettingsHash(string value) { }

}

