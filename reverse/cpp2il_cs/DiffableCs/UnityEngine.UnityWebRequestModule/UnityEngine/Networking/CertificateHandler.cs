namespace UnityEngine.Networking;

[NativeHeader("Modules/UnityWebRequest/Public/CertificateHandler/CertificateHandlerScript.h")]
public class CertificateHandler
{
	public static class BindingsMarshaller
	{

		public static IntPtr ConvertToNative(CertificateHandler handler) { }

	}

	internal IntPtr m_Ptr; //Field offset: 0x10

	public override void Dispose() { }

	[NativeMethod(IsThreadSafe = True)]
	private void ReleaseFromScripting() { }

	private static void ReleaseFromScripting_Injected(IntPtr _unity_self) { }

	protected override bool ValidateCertificate(Byte[] certificateData) { }

	[RequiredByNativeCode]
	internal bool ValidateCertificateNative(Byte[] certificateData) { }

}

