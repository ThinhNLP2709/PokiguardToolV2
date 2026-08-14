namespace UnityEngine.InputSystem.XR;

public class XRDeviceDescriptor
{
	public string deviceName; //Field offset: 0x10
	public string manufacturer; //Field offset: 0x18
	public string serialNumber; //Field offset: 0x20
	public InputDeviceCharacteristics characteristics; //Field offset: 0x28
	public int deviceId; //Field offset: 0x2C
	public List<XRFeatureDescriptor> inputFeatures; //Field offset: 0x30

	public XRDeviceDescriptor() { }

	public static XRDeviceDescriptor FromJson(string json) { }

	public string ToJson() { }

}

