namespace UnityEngine.Windows.WebCam;

[MovedFrom("UnityEngine.XR.WSA.WebCam")]
[NativeConditional("(PLATFORM_WIN || PLATFORM_WINRT) && !PLATFORM_XBOXONE")]
[NativeHeader("PlatformDependent/Win/Webcam/PhotoCaptureFrame.h")]
public sealed class PhotoCaptureFrame : IDisposable
{
	public static class BindingsMarshaller
	{

		public static IntPtr ConvertToNative(PhotoCaptureFrame photoCaptureFrame) { }

	}

	private IntPtr m_NativePtr; //Field offset: 0x10
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private int <dataLength>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <hasLocationData>k__BackingField; //Field offset: 0x1C
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private CapturePixelFormat <pixelFormat>k__BackingField; //Field offset: 0x20

	public private int dataLength
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	private bool hasLocationData
	{
		[CompilerGenerated]
		private set { } //Length: 4
	}

	private CapturePixelFormat pixelFormat
	{
		[CompilerGenerated]
		private set { } //Length: 4
	}

	internal PhotoCaptureFrame(IntPtr nativePtr) { }

	private void Cleanup() { }

	public override void Dispose() { }

	[NativeConditional("(PLATFORM_WIN || PLATFORM_WINRT) && !PLATFORM_XBOXONE")]
	[NativeName("Dispose")]
	[ThreadAndSerializationSafe]
	private void Dispose_Internal() { }

	private static void Dispose_Internal_Injected(IntPtr _unity_self) { }

	protected virtual void Finalize() { }

	[CompilerGenerated]
	public int get_dataLength() { }

	[ThreadAndSerializationSafe]
	private CapturePixelFormat GetCapturePixelFormat() { }

	private static CapturePixelFormat GetCapturePixelFormat_Injected(IntPtr _unity_self) { }

	[ThreadAndSerializationSafe]
	private int GetDataLength() { }

	private static int GetDataLength_Injected(IntPtr _unity_self) { }

	[ThreadAndSerializationSafe]
	private bool GetHasLocationData() { }

	private static bool GetHasLocationData_Injected(IntPtr _unity_self) { }

	[CompilerGenerated]
	private void set_dataLength(int value) { }

	[CompilerGenerated]
	private void set_hasLocationData(bool value) { }

	[CompilerGenerated]
	private void set_pixelFormat(CapturePixelFormat value) { }

}

