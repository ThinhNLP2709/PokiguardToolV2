//Type is in global namespace

public class DeviceManager : MonoBehaviour
{
	private static DeviceManager _instance; //Field offset: 0x0

	public static DeviceManager Instance
	{
		 get { } //Length: 288
	}

	public DeviceManager() { }

	public static DeviceManager get_Instance() { }

	public static string GetDeviceId() { }

	public static string GetDeviceName() { }

	public static void SaveDeviceInfo() { }

}

