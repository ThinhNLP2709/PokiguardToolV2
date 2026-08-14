namespace UnityEngine.XR;

[NativeConditional("ENABLE_VR")]
[NativeHeader("Modules/VR/ScriptBindings/XR.bindings.h")]
[NativeHeader("Runtime/Interfaces/IVRDevice.h")]
[NativeHeader("Runtime/GfxDevice/GfxDeviceTypes.h")]
[NativeHeader("Modules/VR/VRModule.h")]
public static class XRSettings
{

	public static bool enabled
	{
		[StaticAccessor("GetIVRDeviceScripting()", StaticAccessorType::ArrowWithDefaultReturnIfNull (3))]
		 get { } //Length: 42
	}

	[NativeConditional("ENABLE_VR", "RenderTextureDesc()")]
	[NativeName("IntermediateEyeTextureDesc")]
	[StaticAccessor("GetIVRDeviceScripting()", StaticAccessorType::ArrowWithDefaultReturnIfNull (3))]
	public static RenderTextureDescriptor eyeTextureDesc
	{
		 get { } //Length: 73
	}

	[StaticAccessor("GetIVRDeviceScripting()", StaticAccessorType::ArrowWithDefaultReturnIfNull (3))]
	public static int eyeTextureHeight
	{
		 get { } //Length: 42
	}

	[StaticAccessor("GetIVRDeviceScripting()", StaticAccessorType::ArrowWithDefaultReturnIfNull (3))]
	public static int eyeTextureWidth
	{
		 get { } //Length: 42
	}

	[NativeName("Active")]
	[StaticAccessor("GetIVRDeviceScripting()", StaticAccessorType::ArrowWithDefaultReturnIfNull (3))]
	public static bool isDeviceActive
	{
		 get { } //Length: 42
	}

	[NativeName("DeviceName")]
	[StaticAccessor("GetIVRDeviceScripting()", StaticAccessorType::ArrowWithDefaultReturnIfNull (3))]
	public static string loadedDeviceName
	{
		 get { } //Length: 164
	}

	public static String[] supportedDevices
	{
		 get { } //Length: 42
	}

	[StaticAccessor("GetIVRDeviceScripting()", StaticAccessorType::ArrowWithDefaultReturnIfNull (3))]
	public static bool get_enabled() { }

	public static RenderTextureDescriptor get_eyeTextureDesc() { }

	private static void get_eyeTextureDesc_Injected(out RenderTextureDescriptor ret) { }

	public static int get_eyeTextureHeight() { }

	public static int get_eyeTextureWidth() { }

	public static bool get_isDeviceActive() { }

	public static string get_loadedDeviceName() { }

	private static void get_loadedDeviceName_Injected(out ManagedSpanWrapper ret) { }

	public static String[] get_supportedDevices() { }

}

