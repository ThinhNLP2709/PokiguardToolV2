//Type is in global namespace

public class AppBootstrapData
{
	public long serverTime; //Field offset: 0x10
	public string updateMode; //Field offset: 0x18
	public string latestVersion; //Field offset: 0x20
	public string minSupportedVersion; //Field offset: 0x28
	public string updateTitle; //Field offset: 0x30
	public string updateMessage; //Field offset: 0x38
	public string storeUrl; //Field offset: 0x40
	public string apkUrl; //Field offset: 0x48
	public string assetChannel; //Field offset: 0x50
	public string contentVersion; //Field offset: 0x58
	public string contentMinBinary; //Field offset: 0x60
	public string contentBaseUrl; //Field offset: 0x68
	public bool maintenanceEnabled; //Field offset: 0x70
	public string maintenanceMessage; //Field offset: 0x78
	public long maintenanceUntil; //Field offset: 0x80
	public string announcement; //Field offset: 0x88

	public AppBootstrapData() { }

}

